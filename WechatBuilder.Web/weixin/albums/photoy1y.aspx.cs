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
    public partial class photoy1y : WeiXinPage
    {
        public int wid;
        protected string openid;
        protected int aid;
        protected string bgMusic = "";
        protected int num = 0;
        protected Model.wx_albums_info albums=new Model.wx_albums_info();
        protected void Page_Load(object sender, EventArgs e)
        {
            OnlyWeiXinLook();
            if (!IsPostBack)
            {
                wid = MyCommFun.RequestInt("wid");
                openid = MyCommFun.RequestOpenid();
                aid = MyCommFun.RequestInt("aid");
                if (wid == 0 || aid == 0)
                {
                    MessageBox.Show(this, "参数不正确！");
                    return;
                }
                BLL.wx_albums_info aBll = new BLL.wx_albums_info();
               albums = aBll.GetModel(aid);
                if (albums != null)
                {
                    if (albums.music != null && albums.music.Trim() != "")
                    {
                        bgMusic = "  var audio = new Audio();  audio.src = \"" + MyCommFun.getWebSite() + albums.music.Trim() + "\";  audio.play();";
                        // bgMusic = "  var audio = new Audio();  audio.src = \"http://bcs.duapp.com/baemp3mp3/mp3/138305426164953243.mp3\";  audio.play();";
                    }
                }
                BindPhotoList();

                
            }
        }
        private void BindPhotoList()
        {
            int tmpInt = 0;
            BLL.wx_albums_photo pbll = new BLL.wx_albums_photo();
            IList<Model.wx_albums_photo> plist = pbll.GetModelList(" aId=" + aid + " and isHidden=0 order by seq asc");
            if (plist == null || plist.Count() <= 0)
            {
                return;
            }
            StringBuilder sbPic = new StringBuilder("");
            StringBuilder sbPicNum = new StringBuilder("");
            num = plist.Count;
            for (int i = 0; i < plist.Count; i++)
            {
                sbPic.Append(" <li> <p>"+plist[i].pName+"</p>");
                sbPic.Append("<img src=\""+plist[i].photoPic+"\">");
                sbPic.Append("</li>");
                if (i == 0)
                {
                    sbPicNum.Append(" <li class=\"active\">1</li>"); 
                }
                else
                {
                    sbPicNum.Append(" <li>"+(i+1)+"</li>");
                }
            }

            litPiclist.Text = sbPic.ToString();
            litPicNumlist.Text = sbPicNum.ToString();


        }

    }
}