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
    public partial class diancai_oder : WeiXinPage
    {
        public int aid = 0;
        public int shopid = 0;
        public string openid = "";
        BLL.wx_diancai_dingdan_manage managebll= new BLL.wx_diancai_dingdan_manage();
        Model.wx_diancai_dingdan_manage manage = new Model.wx_diancai_dingdan_manage();
        public  string str = "";
        BLL.wx_diancai_shopinfo shopBll = new BLL.wx_diancai_shopinfo();
        Model.wx_diancai_shopinfo shopinfo = new Model.wx_diancai_shopinfo();
        public string hotelName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                aid = MyCommFun.RequestInt("aid");
                shopid = MyCommFun.RequestInt("shopid");

                openid = MyCommFun.QueryString("openid");
                shopid = MyCommFun.RequestInt("shopid");
                shopinfo = shopBll.GetModel(shopid);
                hotelName = shopinfo.hotelName;

                if (openid!="")
                {
                    List(openid);
                }

             }
           }


        public void List(string openid)
        {

            DataSet dr = managebll.GetListList(openid);
            if(dr.Tables[0].Rows.Count>0)
            {
                for (int i = 0; i < dr.Tables[0].Rows.Count;i++ )
                {
                    str += "<ul class=\"round\">";
                    str += "<li class=\"title\"><a href=\"diancai_dingdan.aspx?aid=" + aid + "&shopid=" + shopid + "&dingdan=" + dr.Tables[0].Rows[i]["id"].ToString() + "&openid=" + openid + "\"><span>" + dr.Tables[0].Rows[i]["oderTime"].ToString() + " </span></a></li>";
                    str+=" <table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"cpbiaoge\">";
                    str += "<tr><th>订单编号</th>";
                    str += "<th width=\"70\" class=\"cc\">订单金额</th><th width=\"55\" class=\"cc\">订单状态</th></tr>";
                    str += "<tr><td>" + dr.Tables[0].Rows[i]["orderNumber"].ToString() + "</td><td class=\"cc\">" + dr.Tables[0].Rows[i]["payAmount"].ToString() + "元</td>";
                    str += "<td class=\"cc\"> ";
                    if (dr.Tables[0].Rows[i]["payStatus"].ToString() == "1")
                    {
                        str += "<em class=\"ok\">已处理</em>";
                    }
                    else
                    {
                        str += "<em class=\"no\">未处理</em>";
                    }
                    str+=" </td></tr></table></ul>";
                }
            }

        }


        }
      }

    

   