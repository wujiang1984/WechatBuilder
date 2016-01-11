using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.weixin.diancai
{
    public partial class caidan_guanyu : WeiXinPage
    {
        public int aid = 0;
        public int shopid = 0;
        BLL.wx_diancai_shopinfo shopBll = new BLL.wx_diancai_shopinfo();
        Model.wx_diancai_shopinfo shopinfo = new Model.wx_diancai_shopinfo();

        public string kcType = "";
        public decimal sendPrice = 0;
        public string radius = "";
        public string sendArea = "";
        public string tel = "";
        public decimal xplace = 0;
        public decimal yplace = 0;
        public string hotelName = "";
        public string address = "";
        public string hotelintroduction = "";

        public string hoteltimeBegin = "";
        public string hoteltimeEnd = "";
        public string hoteltimeBegin1 = "";
        public string hoteltimeEnd1= "";
        public string hoteltimeBegin2 = "";
        public string hoteltimeEnd2 = "";
        public string yingye1 = "";
        public string yingye2 = "";
        public string yingye3 = "";
        public string status = "";
        public string openid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                openid = MyCommFun.QueryString("openid");
                aid = MyCommFun.RequestInt("aid");
                shopid = MyCommFun.RequestInt("shopid");
                shopinfo = shopBll.GetModel(aid);
                kcType = shopinfo.kcType;
                sendPrice = Convert.ToDecimal( shopinfo.sendPrice);
                radius = shopinfo.radius;
                sendArea = shopinfo.sendArea;
                tel = shopinfo.tel;
                xplace = Convert.ToDecimal( shopinfo.xplace);
                yplace = Convert.ToDecimal( shopinfo.yplace);
                hotelName = shopinfo.hotelName;
                address = shopinfo.address;
                hotelintroduction = shopinfo.hotelintroduction;

                hoteltimeBegin = shopinfo.hoteltimeBegin.Value.ToString("HH:mm");
                hoteltimeEnd = shopinfo.hoteltimeEnd.Value.ToString("HH:mm");
                yingye1 = "<tr><td>营业时间：" + hoteltimeBegin + "-" + hoteltimeEnd + "</td></tr>";

                int stats = 0;

                if (string.Compare(shopinfo.hoteltimeEnd.Value.ToString("HH:mm"), DateTime.Now.ToShortTimeString().ToString()) < 0 || string.Compare(shopinfo.hoteltimeBegin.Value.ToString("HH:mm"), DateTime.Now.ToShortTimeString().ToString()) > 0)
                {
                  
          
                }
                else
                {
                    stats += 1;
                }

                if (string.Compare(shopinfo.hoteltimeEnd1.Value.ToString("HH:mm"), DateTime.Now.ToShortTimeString().ToString()) < 0 || string.Compare(shopinfo.hoteltimeBegin1.Value.ToString("HH:mm"), DateTime.Now.ToShortTimeString().ToString()) > 0)
                {
                  
                   
                }
                else
                {
                    stats += 1;
                }

                if (string.Compare(shopinfo.hoteltimeEnd2.Value.ToString("HH:mm"), DateTime.Now.ToShortTimeString().ToString()) < 0 || string.Compare(shopinfo.hoteltimeBegin2.Value.ToString("HH:mm"), DateTime.Now.ToShortTimeString().ToString()) > 0)
                {
                  

                }
                else
                {
                    stats += 1;
                }



                if (stats > 0)
                {
                    status = "<tr><td width=\"70\">店铺状态：<em class=\"ok\">营业中</em>  </tr>";
                }
                else
                {
                    status = "<tr><td width=\"70\">店铺状态：<em class=\"no\">未营业</em>  </tr>";
                }




                if (shopinfo.hoteltimeBegin1 != null && shopinfo.hoteltimeEnd1!=null)
                {
                    hoteltimeBegin1 = shopinfo.hoteltimeBegin1.Value.ToString("HH:mm");
                    hoteltimeEnd1 = shopinfo.hoteltimeEnd1.Value.ToString("HH:mm");
                    yingye2 = "<tr><td>营业时间1：" + hoteltimeBegin1 + "-" + hoteltimeEnd1 + "</td></tr>";
                }

                if (shopinfo.hoteltimeBegin2 != null && shopinfo.hoteltimeEnd2 != null)
                {
                    hoteltimeBegin2 = shopinfo.hoteltimeBegin2.Value.ToString("HH:mm");
                    hoteltimeEnd2 = shopinfo.hoteltimeEnd2.Value.ToString("HH:mm");
                    yingye3 = "<tr><td>营业时间2：" + hoteltimeBegin2 + "-" + hoteltimeEnd2 + "</td></tr>";
                }


                //if (hoteltimeEnd<DateTime.Now.ToString("HH:mm"))
                //{
                //}





              
               
            }
        }
    }
}