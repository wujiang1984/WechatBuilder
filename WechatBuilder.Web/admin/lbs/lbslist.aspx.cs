using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;

namespace WechatBuilder.Web.admin.lbs
{
    public partial class lbslist : Web.UI.ManagePage
    {
       
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string keywords = string.Empty;

        BLL.wx_lbs_shopInfo bll = new BLL.wx_lbs_shopInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = MXRequest.GetQueryString("keywords");
            this.pageSize = GetPageSize(10); //每页数量

            if (!Page.IsPostBack)
            {
                RptBind( "id>0" + CombSqlTxt(this.keywords), "seq asc, id desc");
            }
        }



        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            _strWhere = "wid=" + weixin.id + " and "+ _strWhere;
            this.page = MXRequest.GetQueryInt("page", 1);

            this.txtKeywords.Text = this.keywords;
           
            DataSet ds = bll.GetList( this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            
            this.rptList1.DataSource = ds;
            this.rptList1.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("lbslist.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
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
                strTemp.Append(" and shopName like '%" + _keywords + "%'");
            }
             
            return strTemp.ToString();
        }
        #endregion

        #region 返回图文每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("lbslist_page_size"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("lbslist.aspx", "keywords={0}", txtKeywords.Text));
        }


        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("lbslist_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("lbslist.aspx", "keywords={0}", this.keywords));
        }

       

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int sucCount = 0; //成功数量
            int errorCount = 0; //失败数量
            Repeater rptList = new Repeater();
            rptList = this.rptList1;

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        sucCount++;
                    }
                    else
                    {
                        errorCount++;
                    }
                }
            }
            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "删除lbs数据管理内容成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("lbslist.aspx", "keywords={0}", this.keywords), "Success");
        }

        
    }
}