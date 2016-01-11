using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using WechatBuilder.Common;

namespace WechatBuilder.Web.UI.Page
{
    public partial class repassword: Web.UI.BasePage
    {
        protected string action;
        protected Model.user_code model;

        /// <summary>
        /// 重写父类的虚方法,此方法将在Init事件前执行
        /// </summary>
        protected override void ShowPage()
        {
            action = MXRequest.GetQueryString("action");
            if (action == "reset")
            {
                string strcode = MXRequest.GetQueryString("code");
                if (strcode != null)
                {
                    model = new BLL.user_code().GetModel(strcode);
                    if (model == null)
                    {
                        HttpContext.Current.Response.Redirect(linkurl("repassword", "error"));
                        return;
                    }
                }
            }
        }

    }
}
