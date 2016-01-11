using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.weixin.albums
{
    public partial class index : WeiXinPage
    {
        public int wid;
        protected string openid;
        protected string bgPic = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            OnlyWeiXinLook();

            if (!IsPostBack)
            {
                 wid = MyCommFun.RequestInt("wid");
                 openid = MyCommFun.RequestOpenid();
                if (wid == 0)
                {
                    MessageBox.Show(this,"参数不正确！");
                    return;
                }
                 BLL.wx_albums_sys bll = new  BLL.wx_albums_sys();
                 IList<Model.wx_albums_sys> modellist = bll.GetModelList("wid="+wid);
                if (modellist != null && modellist.Count > 0)
                {
                    bgPic =  modellist[0].bannerPic;
                }
               

                litCopyRight.Text = getwebcopyright(wid);

                BLL.wx_albums_type tBll = new BLL.wx_albums_type();
                IList<Model.wx_albums_type> tlist = tBll.GetModelList("wid=" + wid +" order by  sort_id asc");
                if (tlist != null && tlist.Count > 0)
                {
                    Model.wx_albums_type type = new Model.wx_albums_type();
                    StringBuilder sbtl = new StringBuilder("");
                    for (int i = 0; i < tlist.Count; i++)
                    {
                        type = new Model.wx_albums_type();
                        type = tlist[i];
                        sbtl.Append(" <li class=\"list_item\"><a href=\"alubmslist.aspx?wid=" + wid + "&tid=" + type.id + "&openid=" + openid + "\">" + type.typeName + "</a></li>");
                    }
                    litTypelist.Text = sbtl.ToString();

                }

            }
        }

      
    }
}