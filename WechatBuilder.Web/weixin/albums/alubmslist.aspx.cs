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
    public partial class alubmslist : WeiXinPage
    {
        public int wid;
        public int tid = 0;
        protected string openid;
        protected void Page_Load(object sender, EventArgs e)
        {
            OnlyWeiXinLook();

            if (!IsPostBack)
            {
                wid = MyCommFun.RequestInt("wid");
                tid = MyCommFun.RequestInt("tid");
                openid = MyCommFun.RequestOpenid();
                if (wid == 0)
                {
                    MessageBox.Show(this, "参数不正确！");
                    return;
                }
                BLL.wx_albums_type bll = new BLL.wx_albums_type();
                 Model.wx_albums_type type = bll.GetModel(tid);
                if (type != null && type.bannerPic != null && type.bannerPic.Trim()!="")
                {
                    litBanner.Text = "  <a href=\"javascript:;\"><img src=\"" + type.bannerPic + "\"></a> ";
                }
                BindAlbumsList();

                litCopyRight.Text = getwebcopyright(wid);
            }
        }

        /// <summary>
        /// 绑定相册的封面以及其他基本信息
        /// </summary>
        private void BindAlbumsList()
        {
            BLL.wx_albums_info bll = new BLL.wx_albums_info();
            IList<Model.wx_albums_info> alist = new List<Model.wx_albums_info>();
            if (tid == 0)
            {
                alist = bll.GetModelList("wid=" + wid + " and  isHidden=0 order by seq asc ");
            }
            else
            {
                alist = bll.GetModelList("wid=" + wid + " and  isHidden=0 and typeId=" + tid + " order by seq asc");
            }
            StringBuilder sb = new StringBuilder("");
            if (alist == null || alist.Count <= 0)
            {
                return;
            }
            Model.wx_albums_info albums = new Model.wx_albums_info();
            for (int i = 0; i < alist.Count; i++)
            {
                albums = alist[i];
                if (albums.showContent)
                {   //显示描述
                    sb.Append(" <li class=\"media mediaFullText\">");
                    if (albums.showType == 2)
                    {
                        //摇一摇
                        sb.Append(" <a href=\"photoy1y.aspx?aid=" + albums.id + "&wid=" + wid + "&openid=" + openid + "\">");
                    }
                    else
                    {
                        sb.Append(" <a href=\"photo.aspx?aid=" + albums.id + "&wid=" + wid + "&openid=" + openid + "\">");
                    }
                  
                    sb.Append(" <div class=\"mediaPanel\"><div class=\"mediaHead\">");
                    sb.Append("  <span class=\"title\">" + albums.aName + "</span>");
                    sb.Append("<div class=\"clr\"></div></div>");
                    sb.Append("<div class=\"mediaImg\">");
                    sb.Append("<img src=\"" + albums.facePic + "\">");
                    sb.Append("</div>");

                    sb.Append(" <div class=\"mediaContent mediaContentP\"> <p>" + albums.aContent + "</p></div>");

                    sb.Append(" <div class=\"mediaFooter\">");
                    sb.Append("<span class=\"mesgIcon right\"></span><span class=\"bt\">查看全部</span>");
                    sb.Append("<div class=\"clr\"></div>");
                    sb.Append("  </div>  </div>");
                }
                else
                { //不显示描述
                    sb.Append(" <li class=\"media mediaFullText\">");
                    if (albums.showType == 2)
                    {
                        //摇一摇
                        sb.Append(" <a href=\"photoy1y.aspx?aid=" + albums.id + "&wid=" + wid + "&openid=" + openid + "\">");
                    }
                    else
                    {
                        sb.Append(" <a href=\"photo.aspx?aid=" + albums.id + "&wid=" + wid + "&openid=" + openid + "\">");
                    }
                    sb.Append(" <div class=\"mediaPanel\"><div class=\"mediaHead\">");
                    sb.Append("<div class=\"clr\"></div></div>");
                    sb.Append("<div class=\"mediaImg\">");
                    sb.Append("<img src=\"" + albums.facePic + "\">");
                    sb.Append("</div>");
                    sb.Append(" <div class=\"mediaFooter\">");
                    sb.Append("<span class=\"mesgIcon right\"></span><span class=\"bt\">" + albums.aName + "</span>");
                    sb.Append("<div class=\"clr\"></div>");
                    sb.Append("  </div>  </div>");
                }

            }//end for

            litAlbumsList.Text = sb.ToString();
        }
    }
}