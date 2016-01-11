using WechatBuilder.API.Payment.wxpay;
using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.api.payment
{
    public partial class paypage : System.Web.UI.Page
    {

        public String packageValue = "";
        protected int wid = 0;
        protected string openid = "";
        /// <summary>
        /// 订单付款的有效持续时间（单位为分）
        /// </summary>
        protected int expireMinute = 0; 

        protected void Page_Load(object sender, EventArgs e)
        {
            openid = MyCommFun.RequestOpenid();
            int otid = MyCommFun.RequestInt("orderid");
            wid = MyCommFun.RequestInt("wid");
            expireMinute = MyCommFun.RequestInt("expireminute");
            if (expireMinute == 0)
            {
                expireMinute = 30;
            }
            else if(expireMinute==-1)
            {  //如果为-1，则有限期间为1年
                expireMinute = 60 * 12 * 365;
            }
            if (openid == "" || otid == 0 || wid==0)
            {
                return;
            }
            BLL.orders otBll = new BLL.orders();
            Model.orders orderEntity = otBll.GetModel(otid,wid);
            litout_trade_no.Text = orderEntity.order_no;
            litMoney.Text = orderEntity.order_amount.ToString();
            litDate.Text = orderEntity.add_time.ToString();
            WxPayData(orderEntity.order_amount, orderEntity.id.ToString(), orderEntity.order_no);
        }

        /// <summary>
        /// 微信支付：生成请求数据
        /// </summary>
        /// <param name="openid">微信用户id</openid>
        /// <param name="ttFee">商品总价格</param>
        /// <param name="busiBody"></param>
        /// <returns></returns>
        protected void WxPayData(decimal ttFee, string busiBody, string out_trade_no)
        {
            WxPayHelper wxPayHelper = new WxPayHelper();
            BLL.wx_payment_wxpay wxPayBll = new BLL.wx_payment_wxpay();
            Model.wx_payment_wxpay paymentInfo = wxPayBll.GetModelByWid(wid);

            //先设置基本信息
            string partnerId = paymentInfo.partnerId;// "1218574001";//  
            string appId = paymentInfo.appId;// "wxa9b8e33e48ac5e0f";// 
            string partnerKey = paymentInfo.partnerKey;// "huyuxianghuyuxianghuyuxiang12345";//  
            //paysignkey(非appkey) 
            string appKey = paymentInfo.paySignKey; //"nwRmqgvSG08pe3vU5qzBLb7Bvih0WOABGzUPvqgFqE0iSkJlJ8wh7JlLYy2cXFgFA3v1bM8eTDm1y1UcyeW9IGq2py2qei7J5xDoVR9lfO3cS6fMjFbMQeeqBRit0bKp";// 

            wxPayHelper.SetAppId(appId);
            wxPayHelper.SetAppKey(appKey);
            wxPayHelper.SetPartnerKey(partnerKey);
            wxPayHelper.SetSignType("SHA1");
            //设置请求package信息
            wxPayHelper.SetParameter("bank_type", "WX");
            wxPayHelper.SetParameter("body", busiBody);
            wxPayHelper.SetParameter("attach",wid+"|"+busiBody);
            wxPayHelper.SetParameter("partner", partnerId);
            wxPayHelper.SetParameter("out_trade_no", out_trade_no);
            wxPayHelper.SetParameter("total_fee", ((int)(ttFee * 100)).ToString());
            wxPayHelper.SetParameter("fee_type", "1");
           // wxPayHelper.SetParameter("notify_url", "http://" + HttpContext.Current.Request.Url.Authority + "/api/payment/wxpay/notify_url.aspx?wid="+wid);

            wxPayHelper.SetParameter("notify_url", "http://" + HttpContext.Current.Request.Url.Authority + "/api/payment/wxpay/notify_url.aspx");//不能带参数
            wxPayHelper.SetParameter("spbill_create_ip", MXRequest.GetIP());
            wxPayHelper.SetParameter("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));
            //---------有效期截至日期------
          
            wxPayHelper.SetParameter("time_expire", DateTime.Now.AddMinutes(expireMinute).ToString("yyyyMMddHHmmss"));

            wxPayHelper.SetParameter("input_charset", "UTF-8");
            packageValue = wxPayHelper.CreateBizPackage();


        }

    }
}