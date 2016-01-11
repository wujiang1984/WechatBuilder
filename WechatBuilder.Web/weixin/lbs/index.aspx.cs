using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.weixin.lbs
{
    public partial class index : System.Web.UI.Page
    {
        public string xPoint;
        public string yPoint;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                float xPoint = MyCommFun.RequestFloat("x",0);
                float yPoint = MyCommFun.RequestFloat("y", 0);
                if (xPoint == 0 || yPoint == 0)
                {
                    return;
                }
               int   wid = MyCommFun.RequestWid();
                if (wid==0)
                {
                    return;
                }

                BindData(xPoint, yPoint, wid);
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        protected void BindData(float x, float y,int wid)
        {
            BLL.wx_lbs_setting setBll = new BLL.wx_lbs_setting();
            Model.wx_lbs_setting setting = setBll.GetSettingByWid(wid);

            bannerPic.ImageUrl = setting.bannerPicUrl;
            BLL.wx_lbs_shopInfo sBll = new BLL.wx_lbs_shopInfo();
            //SELECT * FROM wx_lbs_shopInfo WHERE dbo.[ufn_GetMapDistance](121.4624,31.220933,yPoint, xPoint) < 5
            IList<Model.wx_lbs_shopInfo> shopList = sBll.GetDetailList(wid,"dbo.[ufn_GetMapDistance](" + y + "," + x + ",yPoint, xPoint) < " + setting.searchRadius);
            StringBuilder rpLocationStr =new StringBuilder("");
            if (shopList != null && shopList.Count > 0)
            {
                string juli = "0";
                for (int i = 0; i < shopList.Count; i++)
                {
                    juli = (sBll.getMapDistance((double)y, (double)x, (double)(shopList[i].yPoint.Value), (double)(shopList[i].xPoint.Value))).ToString("F1");

                    rpLocationStr.Append("<li>");
                    string dUrl = DetailUrl(wid, shopList[i].id, x, y, shopList[i].wUrl);
                    rpLocationStr.Append("<a href=\"" + dUrl + "\" rel=\"external\" data-ajax=\"false\">");
                    rpLocationStr.Append(" <h2><img src=\"images/1.gif\" /><span onclick='" + shopList[i].telphone + "'>" + shopList[i].telphone+ "</span></h2>");

                    rpLocationStr.Append("<p>地址：" + shopList[i].detailAddr + " &nbsp; 距离：约" + juli + "公里 </p>");
                    rpLocationStr.Append("<p> 简介：" + shopList[i].brief + "</p>");
                    rpLocationStr.Append("</li>");
                }
                txtrpLocationStr.Text = rpLocationStr.ToString();
                litshopNum.Text = shopList.Count.ToString();
            }
            else {
                txtrpLocationStr.Text = "暂无数据";
            }
        }

        public string DetailUrl(int wid,int  id, float  x, float  y, string  wUrl)
        {
           
            string openid = MyCommFun.RequestOpenid();
            string newurl = "";
            if (wUrl == null || wUrl.ToString().Trim().Length <= 0)
            {
                //到detailAddr.aspx
                newurl = "detailAddr.aspx?shopid=" + id.ToString() + "&x=" + x.ToString() + "&y=" + y.ToString() + "&wid=" + wid.ToString() + "&openid=" + openid;
            }
            else
            {
                newurl = MyCommFun.urlAddOpenid(wUrl.ToString(),openid);
            }

            return newurl;
        }


    }
}