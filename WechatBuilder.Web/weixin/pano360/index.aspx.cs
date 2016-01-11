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
    public partial class index : WeiXinPage
    {
        public int wid;
        protected string openid;
        protected void Page_Load(object sender, EventArgs e)
        {
            OnlyWeiXinLook();
            if (!IsPostBack)
            {
                wid = MyCommFun.RequestInt("wid");
                
                openid = MyCommFun.RequestOpenid();
                if (wid == 0)
                {
                    MessageBox.Show(this, "参数不正确！");
                    return;
                }
                litCopyRight.Text = getwebcopyright(wid);

                BLL.wx_pano_jd bll = new  BLL.wx_pano_jd();
                IList< Model.wx_pano_jd> jdlist = bll.GetModelList("wid="+wid+"  order by seq asc");
                if (jdlist == null || jdlist.Count <= 0)
                {
                    return;
                }
                StringBuilder sb = new StringBuilder("");
                for (int i = 0; i < jdlist.Count; i++)
                {
                    sb.Append("<li><a href=\"pano.aspx?id=" + jdlist[i].id + "\">" + jdlist[i].jdName + "</a></li>");
                }
                litpanoList.Text = sb.ToString();
            }
        }
    }
}