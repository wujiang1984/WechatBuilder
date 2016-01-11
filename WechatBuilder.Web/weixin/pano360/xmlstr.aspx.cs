using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.weixin.pano360
{
    public partial class xmlstr : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.ContentType = "text/xml";
                int id = MyCommFun.RequestInt("id");
                if (id <= 0)
                { return; }
                BLL.wx_pano_jd pbll = new BLL.wx_pano_jd();
                Model.wx_pano_jd pano = pbll.GetModel(id);
                StringBuilder sb = new StringBuilder("");
                sb.Append("<panorama id=\"\">");
                sb.Append("<view fovmode=\"0\" pannorth=\"0\"><start pan=\"0\" fov=\"70\" tilt=\"0\"/><min pan=\"0\" fov=\"5\" tilt=\"-90\"/>");
                sb.Append("<max pan=\"360\" fov=\"120\" tilt=\"90\"/></view>");

                sb.Append("<input tilesize=\"685\" tilescale=\"1.014598540145985\" tile0url=\"" + getPicUrl(pano.pic_front) + "\" tile1url=\"" + getPicUrl(pano.pic_right) + "\" tile2url=\"" + getPicUrl(pano.pic_behind) + "\" tile3url=\"" + getPicUrl(pano.pic_left) + "\" tile4url=\"" + getPicUrl(pano.pic_top) + "\" tile5url=\"" + getPicUrl(pano.pic_bottom) + "\" />");

                sb.Append("<userdata title=\"mxweixin_pano\" datetime=\"2011:11:03 09:41:07\" description=\"description\" copyright=\"copyright\" tags=\"tags\" author=\"author\" source=\"source\" comment=\"comment\" info=\"info\" longitude=\"0\" latitude=\"\"/>");
                sb.Append("<autorotate speed=\"0.200\" nodedelay=\"0.00\" startloaded=\"1\" returntohorizon=\"0.000\" delay=\"5.00\"/>");
                sb.Append("<control sensitivity=\"8\" simulatemass=\"1\" lockedmouse=\"0\" lockedkeyboard=\"0\" lockedwheel=\"0\" invertwheel=\"0\" speedwheel=\"1\" dblclickfullscreen=\"0\" invertcontrol=\"1\" />");
                sb.Append("<sounds></sounds>");
                sb.Append("</panorama>");
                Response.Write(sb.ToString());

            }
        }

        /// <summary>
        /// 获得图片的url
        /// </summary>
        /// <param name="orginUrl"></param>
        /// <returns></returns>
        public string getPicUrl(string orginUrl)
        {
            if (orginUrl == null)
            {
                return "";
            }
            string ret = orginUrl;
            if (ret.IndexOf("http") <= 0 || ret.IndexOf("www") <= 0)
            {
                return ret;
            }
            else
            {
                return MyCommFun.getWebSite() + orginUrl;
            }

        }
    }
}