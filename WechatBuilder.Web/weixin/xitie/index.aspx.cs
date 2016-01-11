using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;

namespace WechatBuilder.Web.weixin.xitie
{
    public partial class index : WeiXinPage
    {
        public  Model.wx_xt_base xitie = new  Model.wx_xt_base();
        public string photolistStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            OnlyWeiXinLook();
            if (!IsPostBack)
            {
                int xid = MyCommFun.RequestInt("xid");
                int  wid = MyCommFun.RequestInt("wid");
               string  openid = MyCommFun.RequestOpenid();
                if (wid == 0 || openid=="")
                {
                    MessageBox.Show(this, "参数不正确！");
                    return;
                }

                if (xid > 0 && wid>0)
                {

                    BLL.wx_xt_base bll = new BLL.wx_xt_base();
                    xitie = bll.GetModel(xid);
                    xitie.music = MyCommFun.getWebSite() + xitie.music;
                    this.Title = xitie.wxTitle;
                    BLL.wx_xt_photo pbll = new BLL.wx_xt_photo();
                    IList<Model.wx_xt_photo> plist = pbll.GetModelList("bId=" + xid );
                    if (plist == null || plist.Count <= 0)
                    {
                        return;
                    }
                    for (int i = 0; i < plist.Count; i++)
                    {
                        photolistStr += "<li class=\"pb_10\"><img src=\"" + plist[i].pUrl + "\" style=\"width: 100%;\"></li>";

                    }
                }

                

            }


        }
    }
}