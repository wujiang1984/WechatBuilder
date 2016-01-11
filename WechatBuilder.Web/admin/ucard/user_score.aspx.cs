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
    public partial class user_score : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected int sid = 0;//店铺主键id
        protected int id = 0;
        BLL.wx_ucard_users uBll = new BLL.wx_ucard_users();
        BLL.wx_ucard_users_consumeinfo cBll = new BLL.wx_ucard_users_consumeinfo();
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = MXRequest.GetQueryString("keywords");
            sid = MyCommFun.RequestInt("sid");
            id = MyCommFun.RequestInt("id");
            if (sid == 0 || id==0)
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }
            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {

                RptBind(CombSqlTxt(keywords), "addTime desc");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            //绑定用户的基本信息
            Model.wx_ucard_users user = uBll.GetModel(id);
            lblrealName.Text = user.realName;
            lblCardNo.Text = user.cardNo;
            lblTel.Text = user.mobile;
            lblAddr.Text = user.addr;

            //绑定消费积分信息
            _strWhere = "c.sId=" + sid + " and  c.uid="+id+" " + _strWhere;
            this.page = MXRequest.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            DataSet ds = cBll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
 
            this.rptList.DataSource = ds;
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("user_score.aspx?id=" + id + "&sid=" + sid, "keywords={0}&page={1}", this.keywords, "__id__");
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
                strTemp.Append(" and  ( c.moduleActionName like  '%" + _keywords + "%' or c.moduleType like '%" + _keywords + "%'  ");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("user_score_page_size"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("user_score.aspx?id=" + id+"&sid="+sid, "keywords={0}", this.txtKeywords.Text));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("user_score_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("user_score.aspx?id=" + id + "&sid=" + sid, "keywords={0}", this.keywords));
        }

        


        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    Literal litJibie = e.Item.FindControl("litJibie") as Literal;

            //}
        }


       
    }
}