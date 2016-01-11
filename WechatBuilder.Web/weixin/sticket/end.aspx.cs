using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;

namespace WechatBuilder.Web.weixin.sticket
{
    public partial class end : WeiXinPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OnlyWeiXinLook();
            if (!IsPostBack)
            {
                int aid = MyCommFun.RequestInt("aid", 0);
                if (aid == 0 )
                {
                    return;
                }
                BLL.wx_sTicket actbll = new BLL.wx_sTicket();
                Model.wx_sTicket sstAction = actbll.GetModel(aid);
                if (sstAction != null)
                {
                    imgEnd.ImageUrl = sstAction.endPic == null ? "images/end.jpg" : sstAction.endPic.ToString();
                }
            }
        }
    }
}