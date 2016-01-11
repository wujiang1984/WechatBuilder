using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.weixin.diancai
{
    public partial class diancai_Login : WeiXinPage
    {
        public int shopid = 0;
  
        BLL.wx_diancai_shopinfo shopBll = new BLL.wx_diancai_shopinfo();
        Model.wx_diancai_shopinfo shopinfo = new Model.wx_diancai_shopinfo();
        public  string shopname = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)              
            {
                shopid = MyCommFun.RequestInt("shopid");
                shopinfo = shopBll.GetModel(shopid);
                shopname = shopinfo.hotelName;
            }
               

        }
    }
}