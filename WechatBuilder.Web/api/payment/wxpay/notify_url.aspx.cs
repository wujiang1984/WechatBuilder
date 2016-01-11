using WechatBuilder.API.Payment.wxpay;
using WechatBuilder.BLL;
using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.api.payment.wxpay
{
    public partial class notify_url : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //int wid = MyCommFun.RequestWid();
            int wid =0;
             BLL.wx_logs logBll = new  BLL.wx_logs();
            logBll.AddLog("【微支付】微信预定", "notify_url Page_Load", "从微支付返回到notify_url.aspx页面", 1);
            BLL.wx_payment_wxpay payBll = new BLL.wx_payment_wxpay();

         

            ResponseHandler resHandler = new ResponseHandler(Context);
    
            resHandler.init();
            //取wid
            string attach = resHandler.getParameter("attach");
            string[] attachArr = attach.Split('|');
            wid = MyCommFun.Str2Int(attachArr[0]);
            int otid = MyCommFun.Str2Int(attachArr[1]);
            Model.wx_payment_wxpay paymentInfo = payBll.GetModelByWid(wid);
            logBll.AddLog(wid,"【微支付】微信预定", "notify_url Page_Load", "取到wid="+wid, 1);
            resHandler.setKey(paymentInfo.partnerKey, paymentInfo.paySignKey);// TenpayUtil.key, TenpayUtil.appkey);
            //resHandler.setKey("huyuxianghuyuxianghuyuxiang12345", "nwRmqgvSG08pe3vU5qzBLb7Bvih0WOABGzUPvqgFqE0iSkJlJ8wh7JlLYy2cXFgFA3v1bM8eTDm1y1UcyeW9IGq2py2qei7J5xDoVR9lfO3cS6fMjFbMQeeqBRit0bKp");
            //判断签名
            if (resHandler.isTenpaySign())
            {
                logBll.AddLog(wid,"【微支付】微信预定", "notify_url Page_Load", "resHandler.isTenpaySign()", 1);
                if (resHandler.isWXsign())
                {
                    //商户在收到后台通知后根据通知ID向财付通发起验证确认，采用后台系统调用交互模式
                    string notify_id = resHandler.getParameter("notify_id");
                    //取结果参数做业务处理
                    string out_trade_no = resHandler.getParameter("out_trade_no");
                    //财付通订单号
                    string transaction_id = resHandler.getParameter("transaction_id");
                    //金额,以分为单位
                    string total_fee = resHandler.getParameter("total_fee");
                    //如果有使用折扣券，discount有值，total_fee+discount=原请求的total_fee
                    string discount = resHandler.getParameter("discount");
                    //支付结果
                    string trade_state = resHandler.getParameter("trade_state");

                  
                    string pay_info = resHandler.getParameter("pay_info");
                   

                    logBll.AddLog(wid,"【微支付】微信预定", "notify_url Page_Load", "notify_id=" + notify_id + " out_trade_no=" + out_trade_no + " transaction_id=" + transaction_id + " total_fee=" + total_fee + " trade_state=" + trade_state + " orderid=" + otid + " wid=" + wid + "  pay_info=" + pay_info, 1);

                    //即时到账，支付成功
                    if ("0".Equals(trade_state))
                    {
                        logBll.AddLog(wid,"【微支付】微信预定", "notify_url Page_Load", "支付成功了", 1);
                        //------------------------------
                        //处理业务开始
                        //------------------------------
                        wxOrderTmpMgr Totbll = wxOrderTmpMgr.instance();
                        string ret = Totbll.ProcessPaySuccess_wx("notify_url", notify_id, out_trade_no, transaction_id, pay_info, MyCommFun.Str2Int(total_fee), otid,wid);
                        ret = ret == "" ? "处理数据同步发送成功" : ret;
                        logBll.AddLog(wid,"微信预定", "【微支付】notify_url Page_Load", ret, 1);
                        //处理数据库逻辑
                        //注意交易单不要重复处理
                        //注意判断返回金额


                        //------------------------------
                        //处理业务完毕
                        //------------------------------

                        //给财付通系统发送成功信息，财付通系统收到此结果后不再进行后续通知
                        Response.Write("success");
                    }
                    else
                    {
                        logBll.AddLog(wid,"【微支付】微信预定", "notify_url Page_Load", "支付失败", 1);
                        Response.Write("支付失败");
                    }
                    //回复服务器处理成功
                    Response.Write("success");
                }

                else
                {//SHA1签名失败
                    logBll.AddLog("微信预定", "【微支付】notify_url Page_Load", "fail -SHA1 failed", 0);
                    Response.Write("fail -SHA1 failed");
                    Response.Write(resHandler.getDebugInfo());
                }
            }
            else
            {//md5签名失败
                logBll.AddLog(wid, "微信预定", "【微支付】notify_url Page_Load", "fail -md5 failed", 0);
                Response.Write("fail -md5 failed");
                Response.Write(resHandler.getDebugInfo());
            }

        }



        private void WriteContent(string str)
        {
            Response.Output.Write(str);
        }
    }
}