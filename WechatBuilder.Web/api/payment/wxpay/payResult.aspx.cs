using WechatBuilder.API.Payment.wxpay;
using WechatBuilder.Common;
using WechatBuilder.WeiXinComm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.api.payment.wxpay
{
    public partial class payResult : System.Web.UI.Page
    {
        protected Model.orders ordertmp = new Model.orders();
        protected string openid = "";
        protected int otid = 0;
        protected string fahuoInfo = "";
        protected string token = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                openid = MyCommFun.RequestOpenid();
                otid = MyCommFun.RequestInt("otid");
                int wid = MyCommFun.RequestWid();
                if (openid == "" || otid == 0 || wid == 0)
                {
                    return;
                }

                WeiXinCRMComm wxComm = new WeiXinCRMComm();
                string err = "";
                token = wxComm.getAccessToken(wid, out err);

                BLL.orders otBll = new BLL.orders();
                ordertmp = otBll.GetModel(otid, wid);

            }
        }


    }
}