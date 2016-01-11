using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using System.Text;

namespace WechatBuilder.Web.weixin.ucard
{
    public partial class ucardFenDian : WeiXinPage
    {
        protected string openid = "";
        protected int wid = 0;
        protected int sid = 0;//店铺的主键id
        protected int degreeNum = 0;
        protected int uid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            OnlyWeiXinLook();

            openid = MyCommFun.RequestOpenid();
            wid = MyCommFun.RequestInt("wid");
            sid = MyCommFun.RequestInt("sid");
            if (openid == "" || wid == 0 || sid == 0)
            {
                hidStatus.Value = "-1";
                hidErrInfo.Value = "参数错误";
                return;
            }
            bindData();
        }

        private void bindData()
        {
            BLL.wx_ucard_cardinfo cardBll = new BLL.wx_ucard_cardinfo();
            Model.wx_ucard_cardinfo cardinfo = cardBll.GetModelBySid(sid);
            if (cardinfo != null)
            {
                imgTopPic.ImageUrl = cardinfo.contactusPic;
            }

            BLL.wx_ucard_store_fendian scoreBll = new BLL.wx_ucard_store_fendian();
            IList<Model.wx_ucard_store_fendian> slist = scoreBll.GetModelList("sid=" + sid + " order by sort_id asc");
            StringBuilder fdStr = new StringBuilder();
            if (slist != null && slist.Count > 0)
            {
                Model.wx_ucard_store_fendian fd = new Model.wx_ucard_store_fendian();
                string tel = "";
                for (int i = 0; i < slist.Count; i++)
                {
                    fd = slist[i];
                    fdStr.Append(" <h2>"+fd.area+"</h2>");
                    fdStr.Append(" <ul class=\"round\">");
                    fdStr.Append(" <li class=\"addr\">");
                  
                    fdStr.Append("<a href=\"http://api.map.baidu.com/marker?location=" + fd.yPoint + "," + fd.xPoint + "&amp;title=" + fd.addr + "&amp;content=" + fd.area + "&amp;output=html\">");
                    fdStr.Append("<span>" + fd.addr + "</span></a>");
                    fdStr.Append("</li>");
                    tel = MyCommFun.ObjToStr(fd.tel);
                    fdStr.Append("<li class=\"tel\"><a href=\"tel:" + tel + "\"><span>"+tel+"</span></a></li>");
                    fdStr.Append("</ul>");
                }

            }
            litFenDianList.Text = fdStr.ToString();
        }

    }
}