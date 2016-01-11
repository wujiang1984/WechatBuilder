using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.weixin.diancai
{
    public partial class diancai_shoppingCart : WeiXinPage
    {
        public int aid = 0;
        public int shopid = 0;
        public  string shopping = "";
        public string categories = "";
        public   string openid = "";
        BLL.wx_diancai_caipin_category categorybll = new BLL.wx_diancai_caipin_category();

        BLL.wx_diancai_dingdan_manage managebll = new BLL.wx_diancai_dingdan_manage();
        Model.wx_diancai_dingdan_manage manage = new Model.wx_diancai_dingdan_manage();

        BLL.wx_diancai_dingdan_caiping caipinbll = new BLL.wx_diancai_dingdan_caiping();
        Model.wx_diancai_dingdan_caiping caipin = new Model.wx_diancai_dingdan_caiping();

        BLL.wx_diancai_member menberbll = new BLL.wx_diancai_member();
        Model.wx_diancai_member member = new Model.wx_diancai_member();

        BLL.wx_diancai_shopinfo shopBll = new BLL.wx_diancai_shopinfo();
        Model.wx_diancai_shopinfo shopinfo = new Model.wx_diancai_shopinfo();
        public string hotelName = "";
        public static int idf = 0;
        public string name = "";
        public string phone = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                openid = MyCommFun.QueryString("openid");
                aid = MyCommFun.RequestInt("aid");
                shopid = MyCommFun.RequestInt("shopid");
              
                shopinfo = shopBll.GetModel(shopid);
                hotelName = shopinfo.hotelName;
                idf = MyCommFun.RequestInt("id");
                if (idf != 0)
                {
                    member = menberbll.GetModel(idf);
                    name = member.memberName;
                    phone = member.menberTel;
                    this.note.InnerText = member.memberAddress;
                }


                categories = "{";

                DataSet category1 = categorybll.GetList(shopid);
                if (category1.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < category1.Tables[0].Rows.Count; i++)
                    {
                        categories += "\"" + category1.Tables[0].Rows[i]["id"].ToString() + "\"" + ":" + "\"" + category1.Tables[0].Rows[i]["categoryName"].ToString() + "\"" + ",";
                    }
                }
                categories = categories.Substring(0, categories.Length - 1);
                categories += "}";
       
            }
        }

      


    }
}