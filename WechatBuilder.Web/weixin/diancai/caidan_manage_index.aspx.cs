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
    public partial class caidan_manage_index : WeiXinPage
    {
        public int shopid = 0;
        BLL.wx_diancai_dingdan_manage managebll = new BLL.wx_diancai_dingdan_manage();
        Model.wx_diancai_dingdan_manage manage = new Model.wx_diancai_dingdan_manage();

        BLL.wx_diancai_shopinfo shopBll = new BLL.wx_diancai_shopinfo();
        Model.wx_diancai_shopinfo shopinfo = new Model.wx_diancai_shopinfo();
        public string hotelName = "";
        public  string str = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                shopid = MyCommFun.RequestInt("shopid");
                shopinfo = shopBll.GetModel(shopid);
                hotelName = shopinfo.hotelName;


                DataSet dr = managebll.GetListshop(shopid);
                if(dr.Tables[0].Rows.Count>0)
                {
                    for (int i = 0; i < dr.Tables[0].Rows.Count;i++ )
                    {
                        //05月22日14时01分
                        str += "<li class=\"dandanb\"><a href=\"caidan_manage_indexdetail.aspx?shopid=" + shopid + "&id=" + dr.Tables[0].Rows[i]["id"].ToString() + "\">";
                        str += "<span class=\"none\">" + dr.Tables[0].Rows[i]["oderTime"].ToString() + "订单详情";
                        if (dr.Tables[0].Rows[i]["payStatus"].ToString() == "1")
                        {
                            str += "<em class=\"ok\">成功</em>";
                        }
                        else
                        {
                            str += "<em class=\"no\">未处理</em>";
                        }

                        str += " <p>" + dr.Tables[0].Rows[i]["id"].ToString() + "，" + dr.Tables[0].Rows[i]["payAmount"].ToString() + "元</p></span></a></li>";
                    }
                }
            }
        }  
    }
}