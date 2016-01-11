using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using WechatBuilder.Common;

namespace WechatBuilder.Web.UI.Page
{
    public partial class shopping : Web.UI.BasePage
    {
        protected string action = string.Empty;
        protected Model.cart_total cartModel;
        protected Model.users userModel;
        protected Model.orderconfig orderConfig = new BLL.orderconfig().loadConfig();

        /// <summary>
        /// 重写父类的虚方法,此方法将在Init事件前执行
        /// </summary>
        protected override void ShowPage()
        {
            action = MXRequest.GetQueryString("action");
            this.Init += new EventHandler(shopping_Init); //加入Init事件
        }
        /// <summary>
        /// 将在Init事件执行
        /// </summary>
        protected void shopping_Init(object sender, EventArgs e)
        {
            int group_id = 0;
            userModel = GetUserInfo();
            if (userModel != null)
            {
                group_id = userModel.group_id;
            }
            if (action == "confirm" && userModel == null)
            {
                userModel = new Model.users();
                if (orderConfig.anonymous == 0)
                {
                    //自动跳转URL
                    HttpContext.Current.Response.Redirect(linkurl("login"));
                }
            }
            cartModel = Web.UI.ShopCart.GetTotal(group_id);
        }
    }
}
