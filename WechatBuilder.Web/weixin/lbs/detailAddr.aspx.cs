using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.weixin.lbs
{
    public partial class detailAddr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int shopid = MyCommFun.RequestInt("shopid");
                if (shopid == 0)
                {
                    Response.Redirect("index.aspx");
                }
                float x = MyCommFun.RequestFloat("x",0);
                float y = MyCommFun.RequestFloat("y",0);

                int wid = MyCommFun.RequestWid();
                if (wid == 0)
                {
                    return;
                }

                if (x==0|| y==0)
                {
                    Response.Redirect("index.aspx");
                }
                 
                BindData(wid,shopid, x, y);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shopid"></param>
        /// <param name="x">客户传过来的纬度x</param>
        /// <param name="y">客户传过来的经度y</param>
        protected void BindData(int wid,int shopid, float x, float y)
        {
            // 页面上部链接
            BLL.wx_lbs_shopInfo shopBll = new BLL.wx_lbs_shopInfo();
           Model.wx_lbs_shopInfo  shop = shopBll.GetModel(shopid);
           string openid = MyCommFun.RequestOpenid();
           if (shop == null)
            {
                return;
            }

           string aInfo = " <a data-role=\"button\" data-ajax=\"false\" rel=\"external\" href=\"index.aspx?x=" + x + "&y=" + y + "&wid=" + wid + "&openid=" + openid + "\">更多..." + br();
            aInfo += "</a>" + br();
            aInfo += "<a data-role=\"button\" href=\"tel:" + shop.telphone + "\">拨打电话</a>";
            litAInfo.Text = aInfo;


            //页面Js

            string jsInfo = " <script type=\"text/javascript\">" + br();
            jsInfo += "  var map = new BMap.Map(\"allmap\"); " + br();
            jsInfo += "  var point = new BMap.Point(" + shop.yPoint + ", " + shop.xPoint + "); " + br();
            jsInfo += " map.centerAndZoom(point, 15);                 " + br();
            jsInfo += " map.enableScrollWheelZoom();                         " + br();
            jsInfo += "  map.addControl(new BMap.NavigationControl()); " + br();

            jsInfo += "  var marker = new BMap.Marker(point);  " + br();
            jsInfo += " map.addOverlay(marker);            " + br();
            jsInfo += "   marker.setAnimation(BMAP_ANIMATION_BOUNCE);" + br();

            jsInfo += "  var p1 = new BMap.Point(" + y + ", " + x + ");" + br();
            jsInfo += "  var p2 = new BMap.Point(" + shop.yPoint + ", " + shop.xPoint + "); " + br();

            jsInfo += "  var driving = new BMap.DrivingRoute(map, { renderOptions: { map: map, autoViewport: true } });" + br();
            jsInfo += "  driving.search(p1, p2);" + br();

            jsInfo += "  $('#allmap').height($(window).height() - 60);" + br();
            jsInfo += "  document.title = '" + shop.city + "';" + br();

            jsInfo += "</script>";

            litJavaScript.Text = jsInfo;
        }

        public string br()
        {
            return "\r\n";
        }
    }
}