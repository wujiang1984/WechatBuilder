using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.admin.message
{
    public partial class BlackCancle : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int wid = Convert.ToInt32(Request.Params["wid"]);
                string openid = Request.Params["openid"];
                string txtKeywords = "";
                BLL.wx_message_blacklist gbll = new BLL.wx_message_blacklist();
                gbll.Deleteblack(wid, openid);
            
                AddAdminLog(MXEnums.ActionEnum.Delete.ToString(), "删除黑名单，openid" + openid); //记录日志
                JscriptMsg("取消黑名单成功！", Utils.CombUrlTxt("BlackManage.aspx", "keywords={0}", txtKeywords), "Success");
            }
        }
    }
}