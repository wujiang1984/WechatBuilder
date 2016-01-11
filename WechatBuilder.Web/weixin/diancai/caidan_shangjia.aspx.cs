using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.weixin.diancai
{
    public partial class caidan_shangjia : WeiXinPage
    {
        public int aid = 0;
        public int shopid = 0;
        public string openid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                aid = MyCommFun.RequestInt("aid");
                shopid = MyCommFun.RequestInt("shopid");
                openid = MyCommFun.QueryString("openid");
            }
        }
    }
}