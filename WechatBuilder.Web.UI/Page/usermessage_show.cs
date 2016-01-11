using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using WechatBuilder.Common;

namespace WechatBuilder.Web.UI.Page
{
    public partial class usermessage_show : Web.UI.UserPage
    {
        protected int id;
        protected Model.user_message model = new Model.user_message();

        /// <summary>
        /// 重写虚方法,此方法在Init事件执行
        /// </summary>
        protected override void InitPage()
        {
            id = MXRequest.GetQueryInt("id");
            BLL.user_message bll = new BLL.user_message();
            if (!bll.Exists(id))
            {
                HttpContext.Current.Response.Redirect(linkurl("error", "?msg=" + Utils.UrlEncode("出错啦，您要浏览的页面不存在或已删除啦！")));
                return;
            }
            model = bll.GetModel(id);
            //设为已阅读状态
            bll.UpdateField(id, "is_read=1,read_time='" + DateTime.Now + "'");
        }

    }
}
