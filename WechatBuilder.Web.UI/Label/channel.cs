using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace WechatBuilder.Web.UI
{
    public partial class BasePage : System.Web.UI.Page
    {
        /// <summary>
        /// 返回频道列表
        /// </summary>
        /// <param name="category_id">频道类别ID</param>
        /// <returns>DataTable</returns>
        protected DataTable get_channel_list(int categoryid)
        {
            DataTable dt = new DataTable();
            BLL.channel bll = new BLL.channel();
            dt = bll.GetList(0, "category_id=" + categoryid, "sort_id asc,id desc").Tables[0];
            return dt;
        }

   
    }
}
