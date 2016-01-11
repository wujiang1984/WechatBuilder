using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;

namespace WechatBuilder.Web.admin
{
    public partial class index : Web.UI.ManagePage
    {
        protected Model.manager admin_info;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                admin_info = GetAdminInfo();
            }
        }

        //安全退出
        protected void lbtnExit_Click(object sender, EventArgs e)
        {
            Session[MXKeys.SESSION_ADMIN_INFO] = null;
            Utils.WriteCookie("AdminName", "WechatBuilder", -14400);
            Utils.WriteCookie("AdminPwd", "WechatBuilder", -14400);

            Session["yubomId"] = null;
            Utils.WriteCookie("yubomId", "WechatBuilder", -14400);

            Response.Redirect("login.aspx");
        }

    }
}