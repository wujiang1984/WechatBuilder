using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.admin.message
{
    public partial class messagehasSH : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id = Convert.ToInt32(Request.Params["id"]);

                BLL.wx_message_list settingBll = new BLL.wx_message_list();
                Model.wx_message_list setting = new Model.wx_message_list();
                Model.wx_userweixin weixin = GetWeiXinCode();
                int wid = weixin.id;
                setting.id = id;
                setting.wid = wid;
                setting.hasSH =true;
                settingBll.Update(setting);

                // AddAdminLog(MXEnums.ActionEnum.Delete.ToString(), ""); //记录日志
                AddAdminLog(MXEnums.ActionEnum.Delete.ToString(), "审核留言，id为" + id); //记录日志
                JscriptMsg("审核成功！", Utils.CombUrlTxt("message_list.aspx", "keywords={0}", ""), "Success");
            }

        }
    }
}