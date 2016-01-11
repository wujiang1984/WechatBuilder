using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
namespace WechatBuilder.Web.admin.yuyue
{
    public partial class userResult : Web.UI.ManagePage
    {
        BLL.wx_yy_result retBll = new BLL.wx_yy_result();
 

        protected void Page_Load(object sender, EventArgs e)
        {
            int formid = MyCommFun.RequestInt("id");
            if (!IsPostBack)
            {
                RptBind(formid);
            }
        }

        #region 数据绑定=================================
        private void RptBind(int formid)
        {
            DataSet ds = retBll.GetResultInfo(formid);
            StringBuilder sbTable = new StringBuilder("");
            sbTable.Append(" <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"ltable\"><thead>");
            if (ds == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0)
            {
                return;
            }
            DataTable dt = ds.Tables[0];
            int rowsNum=dt.Rows.Count;
            int colNum=dt.Columns.Count;
            //table头部
            sbTable.Append(" <thead>  <tr> \r\n");
            for (int i = 0; i < colNum; i++)
            {
                if (dt.Columns[i].ToString() == "createDate")
                {
                    sbTable.Append("<th>提交时间</th>");
                }
                else
                {
                    sbTable.Append("<th>" + dt.Columns[i].ToString() + "</th>");
                }
            }
            sbTable.Append(" </tr> </thead>\r\n");
            
            //table 内容部分
            sbTable.Append(" <tbody class=\"ltbody\">");
            DataRow dr;
            for (int i = 0; i < rowsNum; i++)
            {
                dr = dt.Rows[i];
                 sbTable.Append("<tr class=\"td_c\">");
                 for (int j = 0; j < colNum; j++)
                 {
                     sbTable.Append(" <td>" + dr[j] + "</td>");
                 }
                sbTable.Append(" </tr>");
            }
            sbTable.Append(" </tbody>");
            sbTable.Append("  </table>");
            litTable.Text = sbTable.ToString();
 
        }
        #endregion
 
 
    }
}