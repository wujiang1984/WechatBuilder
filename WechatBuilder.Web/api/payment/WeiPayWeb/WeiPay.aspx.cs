using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using WeiPay;
using MxWeiXinPF.BLL;
using System.Collections.Generic;
using System.Net;
using MxWeiXinPF.Common;


namespace MxWeiXinPF.Web.api.payment.WeiPayWeb
{
    
    public partial class WeiPay : System.Web.UI.Page
    {
        //页面输出 不用操作
        public static string Code = "";     //微信端传来的code
        public static string PrepayId = ""; //预支付ID
        public static string Sign = "";     //为了获取预支付ID的签名
        public static string PaySign = "";  //进行支付需要的签名
        public static string Package = "";  //进行支付需要的包
        public static string TimeStamp = ""; //时间戳 程序生成 无需填写
        public static string NonceStr = ""; //随机字符串  程序生成 无需填写


        //支付相关参数 ，以下参数请从需要支付的页面通过get方式传递过来
        protected string OrderSN = ""; //商户自己订单号
        protected string Body = ""; //商品描述
        protected string TotalFee = "";  //总支付金额，单位为：分，不能有小数
        protected string Attach = ""; //用户自定义参数，原样返回
        protected string UserOpenId = "";//微信用户openid

        protected void Page_Load(object sender, EventArgs e)
        {
           
            this.BindData();

            LogUtil.WriteLog("============ 单次支付开始 ===============");
            LogUtil.WriteLog(string.Format("传递支付参数：OrderSN={0}、Body={1}、TotalFee={2}、Attach={3}、UserOpenId={4}",
           this.OrderSN, this.Body, this.TotalFee, this.Attach,  this.UserOpenId));


            #region 支付操作============================


            #region 基本参数===========================
            //时间戳 
            TimeStamp = TenpayUtil.getTimestamp();
            //随机字符串 
            NonceStr = TenpayUtil.getNoncestr();

            int  wid = MyCommFun.RequestInt("wid");
            BLL.wx_payment_wxpay wxPayBll = new BLL.wx_payment_wxpay();
            Model.wx_payment_wxpay paymentInfo = wxPayBll.GetModelByWid(wid);

            //创建支付应答对象
            var packageReqHandler = new RequestHandler(Context);
            //初始化
            packageReqHandler.init();

            //设置package订单参数  具体参数列表请参考官方pdf文档，请勿随意设置
            packageReqHandler.setParameter("body", this.Body); //商品信息 127字符
            packageReqHandler.setParameter("appid", PayConfig.AppId);
            packageReqHandler.setParameter("mch_id", PayConfig.MchId);
            packageReqHandler.setParameter("nonce_str", NonceStr.ToLower());
            packageReqHandler.setParameter("notify_url", PayConfig.NotifyUrl);
            packageReqHandler.setParameter("openid", this.UserOpenId);
            packageReqHandler.setParameter("out_trade_no", this.OrderSN); //商家订单号
            packageReqHandler.setParameter("spbill_create_ip", Page.Request.UserHostAddress); //用户的公网ip，不是商户服务器IP
            packageReqHandler.setParameter("total_fee", this.TotalFee); //商品金额,以分为单位(money * 100).ToString()
            packageReqHandler.setParameter("trade_type", "JSAPI");
            if (!string.IsNullOrEmpty(this.Attach))
                packageReqHandler.setParameter("attach", this.Attach);//自定义参数 127字符
       
            #endregion

            #region sign===============================
            Sign = packageReqHandler.CreateMd5Sign("key", PayConfig.AppKey);
            LogUtil.WriteLog("WeiPay 页面  sign：" + Sign);
            #endregion

            #region 获取package包======================
            packageReqHandler.setParameter("sign", Sign);

            string data = packageReqHandler.parseXML();
            LogUtil.WriteLog("WeiPay 页面  package（XML）：" + data);

            string prepayXml = HttpUtil.Send(data, "https://api.mch.weixin.qq.com/pay/unifiedorder");
            LogUtil.WriteLog("WeiPay 页面  package（Back_XML）：" + prepayXml);

            //获取预支付ID
            var xdoc = new XmlDocument();
            xdoc.LoadXml(prepayXml);
            XmlNode xn = xdoc.SelectSingleNode("xml");
            XmlNodeList xnl = xn.ChildNodes;
            if (xnl.Count > 7)
            {
                PrepayId = xnl[7].InnerText;
                Package = string.Format("prepay_id={0}", PrepayId);
                LogUtil.WriteLog("WeiPay 页面  package：" + Package);
            }
            #endregion

            #region 设置支付参数 输出页面  该部分参数请勿随意修改 ==============
            var paySignReqHandler = new RequestHandler(Context);
            paySignReqHandler.setParameter("appId", PayConfig.AppId);
            paySignReqHandler.setParameter("timeStamp", TimeStamp);
            paySignReqHandler.setParameter("nonceStr", NonceStr);
            paySignReqHandler.setParameter("package", Package);
            paySignReqHandler.setParameter("signType", "MD5");
            PaySign = paySignReqHandler.CreateMd5Sign("key", PayConfig.AppKey);

            LogUtil.WriteLog("WeiPay 页面  paySign：" + PaySign);
            #endregion
            #endregion
        }


        /// <summary>
        /// 获取传递的支付参数，并绑定页面上
        /// </summary>
        private void BindData()
        {
            this.OrderSN = this.Request.QueryString["OrderSN"];
            this.Body = this.Request.QueryString["Body"];
            this.TotalFee = this.Request.QueryString["TotalFee"];
            this.Attach = this.Request.QueryString["Attach"];
            this.UserOpenId = this.Request.QueryString["UserOpenId"];

            this.lblPrice.Text = this.TotalFee;
            this.lblBody.Text = this.Body;
            this.lblOrderSN.Text = this.OrderSN;
            this.lblAttach.Text = this.Attach;
            this.lblOpenId.Text = this.UserOpenId;
        }

    }


 
}
