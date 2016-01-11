using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using WechatBuilder.Common;

namespace WechatBuilder.Web.UI.Page
{
    public partial class userpoint : Web.UI.UserPage
    {
        protected string action = string.Empty;
        protected int page;         //当前页码
        protected int totalcount;   //OUT数据总数

        /// <summary>
        /// 重写虚方法,此方法在Init事件执行
        /// </summary>
        protected override void InitPage()
        {
            action = MXRequest.GetQueryString("action");
            page = MXRequest.GetQueryInt("page", 1);
        }

    }
}
