using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.weixin.ggk
{
    public partial class end : WeiXinPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OnlyWeiXinLook();

            if (!IsPostBack)
            {
                int id = MyCommFun.RequestInt("aid");
                if (id == 0)
                {
                    return;
                }
                BLL.wx_ggkActionInfo aBll = new BLL.wx_ggkActionInfo();
                Model.wx_ggkActionInfo action = aBll.GetModel(id);
                if (action == null)
                {
                    return;
                }
                litEndNotice.Text = action.endContent;
            }
        }
    }
}