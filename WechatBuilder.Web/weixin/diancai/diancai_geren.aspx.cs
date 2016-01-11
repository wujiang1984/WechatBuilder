using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.weixin.diancai
{
    public partial class diancai_geren : WeiXinPage
    {
        public int aid = 0;
        public int shopid = 0;
        public string openid = "";
        BLL.wx_diancai_member menberbll = new BLL.wx_diancai_member();
        Model.wx_diancai_member member = new Model.wx_diancai_member();
        BLL.wx_diancai_shopinfo shopBll = new BLL.wx_diancai_shopinfo();
        Model.wx_diancai_shopinfo shopinfo = new Model.wx_diancai_shopinfo();
        public string hotelName = "";
        public int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                aid = MyCommFun.RequestInt("aid");
                shopid = MyCommFun.RequestInt("shopid");
                openid = MyCommFun.QueryString("openid");
                shopinfo = shopBll.GetModel(shopid);
                hotelName = shopinfo.hotelName;

            
            }
        }
    }
}