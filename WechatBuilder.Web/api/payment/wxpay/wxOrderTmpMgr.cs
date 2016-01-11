using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Runtime.CompilerServices;
using WechatBuilder.API.Payment.wxpay;


namespace WechatBuilder.Web.api.payment.wxpay
{
    /// <summary>
    /// 单例模式 处理订单
    /// </summary>
    public class wxOrderTmpMgr
    {
        static wxOrderTmpMgr uniCounter;
        private int totNum = 0;
        private wxOrderTmpMgr()
        {
            Thread.Sleep(400); //假设多线程的时候因某种原因阻塞400毫秒 
        }
        [MethodImpl(MethodImplOptions.Synchronized)] //方法的同步属性 
        static public wxOrderTmpMgr instance()
        {
            if (null == uniCounter)
            {
                uniCounter = new wxOrderTmpMgr();
            }
            return uniCounter;
        }


        /// <summary>
        /// 【微支付】 订单付款成功，处理订单：1将订单的状态改成付款完成；
        /// 
        /// </summary>
        /// <param name="beforeFunName"></param>
        /// <param name="notify_id">通知id</param>
        /// <param name="out_trade_no">商户订单号</param>
        /// <param name="transaction_id">订单交易号</param>
        /// <param name="pay_info">支付结果</param>
        /// <param name="total_fee">付款金额（单位为分）</param>
        /// <param name="otid">订单临时表id</param>
        /// <returns>有错误则返回错误信息，正确，则返回空字符串</returns>
        public string ProcessPaySuccess_wx(string beforeFunName, string notify_id, string out_trade_no, string transaction_id, string pay_info, int total_fee, int otid, int wid)
        {
            string payTmpType = "【微支付】";
            total_fee = total_fee / 100;
            BLL.orders orderBll = new BLL.orders();

            string funName = payTmpType + beforeFunName + " ProcessPaySuccess_wx ";

            BLL.wx_logs logBll = new BLL.wx_logs();
            logBll.AddLog(wid, "微支付", funName, "开始执行ProcessPaySuccess_wx方法[otid:" + otid + "]");
            try
            {
                #region 数据同步前
                IList<Model.orders> orderlist = orderBll.GetModelList("id=" + otid + " and order_no='" + out_trade_no + "'");
                if (orderlist == null || orderlist.Count <= 0)
                {
                    logBll.AddLog(wid,payTmpType, funName, "订单号【" + out_trade_no + "】订单号不存在", 0);
                    return "订单号不存在";
                }
                //这个暂时不处理
                if (logBll.ExistsFlg((out_trade_no + otid)))
                {  //如果已经处理过，则不再处理
                    return "";
                }
                logBll.AddFlg(wid,payTmpType, funName, (out_trade_no + otid));//加标志，防止重复提交

                Model.orders orderEntity = orderlist[0];
                if (orderEntity.order_amount > total_fee)
                {
                    return "付款的金额(" + total_fee + ")小于订单的预付款金额(" + orderEntity.order_amount + ")信息，直接退款";
                }
                orderEntity.notify_id = notify_id;
                orderEntity.trade_no = transaction_id;
                orderEntity.pay_info = pay_info;
                orderEntity.order_amount = total_fee;
                orderEntity.payment_time = DateTime.Now;
                orderEntity.status = 2;
                orderEntity.payment_status = 2;

                //判断是否需要立即发货
                if (orderEntity.express_status == 0)
                {
                    //立即发货
                    FaHuoProc fahuo = new FaHuoProc();
                    
                    BLL.wx_payment_wxpay payBll = new BLL.wx_payment_wxpay();
                    Model.wx_payment_wxpay paymentInfo = payBll.GetModelByWid(wid);
                    Dictionary<string, object> fahuoDict = fahuo.fahuomgr(paymentInfo, orderEntity);
                    string errcode = fahuoDict["errcode"].ToString();
                    string errmsg = fahuoDict["errmsg"].ToString();
                    orderEntity.fahuoCode = errcode;
                    orderEntity.fahuoMsg = errmsg;
                    if (errcode == "0")
                    {
                        orderEntity.express_status = 2;
                        orderEntity.express_time = DateTime.Now;
                    }
                    else
                    {
                        orderEntity.express_status =1;
                    }
                }

                bool ret = orderBll.Update(orderEntity);
                if (!ret)
                {
                    logBll.AddLog(wid,payTmpType, funName, "订单号【" + out_trade_no + "】支付成功后处理数据失败", 0);
                    return "订单号【" + out_trade_no + "】支付成功后处理数据失败";
                }

                logBll.AddLog(payTmpType, funName, "订单号【" + out_trade_no + "】支付成功后，处理数据成功", 1);
                return "";

                #endregion

            }
            catch (Exception ex)
            {

                logBll.AddLog(wid,payTmpType, funName, "订单号【" + out_trade_no + "】支付成功后处理数据同步出现错误：" + ex.Message, 0);
                return null;
            }

        }


        public void Inc() { totNum++; }
        public int GetCounter() { return totNum; }
    }
}