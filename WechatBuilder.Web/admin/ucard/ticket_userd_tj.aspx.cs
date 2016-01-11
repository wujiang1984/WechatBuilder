using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using System.Text;
using System.Data;

namespace WechatBuilder.Web.admin.ucard
{
    public partial class ticket_userd_tj : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected int sid = 0;//店铺主键id
        protected int id = 0;//特权id
        BLL.wx_ucard_users_consumeinfo tbll = new BLL.wx_ucard_users_consumeinfo();
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = MXRequest.GetQueryString("keywords");
            sid = MyCommFun.RequestInt("sid");
            id = MyCommFun.RequestInt("id");
            if (id == 0)
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }
            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {

                RptBind(CombSqlTxt(keywords), " addTime desc");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {

            _strWhere = "c.moduleType='优惠券' and c.sid= " + sid + " and c.moduleActionId=" + id + " " + _strWhere;
            this.page = MXRequest.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            DataSet ds = tbll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataSource = ds;
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("ticket_userd_tj.aspx?id=" + id + "&sid=" + sid, "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and  ( u.realName like  '%" + _keywords + "%' or u.cardNo like  '%" + _keywords + "%') ");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("ticket_userd_tj_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("ticket_userd_tj.aspx?id=" + id + "&sid=" + sid, "keywords={0}", this.txtKeywords.Text));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("ticket_userd_tj_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("ticket_userd_tj.aspx?id=" + id + "&sid=" + sid, "keywords={0}", this.keywords));
        }

        
    }
}