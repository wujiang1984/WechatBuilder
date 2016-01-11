using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;

namespace WechatBuilder.Web.admin.channel
{
    public partial class channel_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int category_id;
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.category_id = MXRequest.GetQueryInt("category_id");
            this.keywords = MXRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("site_channel_list", MXEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind(); //绑定类别
                RptBind("id>0" + CombSqlTxt(category_id, keywords), "sort_id asc,id desc");
            }
        }

        #region 绑定类别=================================
        private void TreeBind()
        {
            BLL.channel_category bll = new BLL.channel_category();
            DataTable dt = bll.GetList(0, "", "sort_id asc,id desc").Tables[0];

            this.ddlCategoryId.Items.Clear();
            this.ddlCategoryId.Items.Add(new ListItem("所有类别", ""));
            foreach (DataRow dr in dt.Rows)
            {
                this.ddlCategoryId.Items.Add(new ListItem(dr["title"].ToString(), dr["id"].ToString()));
            }
        }
        #endregion

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = MXRequest.GetQueryInt("page", 1);
            ddlCategoryId.SelectedValue = this.category_id.ToString();
            txtKeywords.Text = this.keywords;
            BLL.channel bll = new BLL.channel();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("channel_list.aspx", "category_id={0}&keywords={1}&page={2}", this.category_id.ToString(), this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _category_id, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (_category_id > 0)
            {
                strTemp.Append(" and category_id=" + _category_id);
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (name like  '%" + _keywords + "%' or title like '%" + _keywords + "%')");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("channel_page_size"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("channel_list.aspx", "category_id={0}&keywords={1}", this.category_id.ToString(), txtKeywords.Text));
        }

        //筛选类型
        protected void ddlCategoryId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("channel_list.aspx", "category_id={0}&keywords={1}", ddlCategoryId.SelectedValue, this.keywords));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("channel_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("channel_list.aspx", "category_id={0}&keywords={1}", this.category_id.ToString(), this.keywords));
        }

        //保存排序
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("site_channel_list", MXEnums.ActionEnum.Edit.ToString()); //检查权限
            BLL.channel bll = new BLL.channel();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
                {
                    sortId = 99;
                }
                bll.UpdateSort(id, sortId);
            }
            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "保存频道排序"); //记录日志
            JscriptMsg("保存排序成功！", Utils.CombUrlTxt("channel_list.aspx", "category_id={0}&keywords={1}", this.category_id.ToString(), this.keywords), "Success", "parent.loadMenuTree");
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("site_channel_list", MXEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.channel bll = new BLL.channel();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    //检查该频道下是否还有文章
                    int articleCount = new BLL.article().GetCount("channel_id=" + id);
                    if (articleCount > 0)
                    {
                        errorCount += 1;
                        continue;
                    }
                    Model.channel model = bll.GetModel(id);
                    if (bll.Delete(id))
                    {
                        sucCount += 1;
                        //删除URL配置
                        new BLL.url_rewrite().Remove("channel", model.name);
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(MXEnums.ActionEnum.Delete.ToString(), "删除频道成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！",
                Utils.CombUrlTxt("channel_list.aspx", "category_id={0}&keywords={1}", this.category_id.ToString(), this.keywords), "Success", "parent.loadMenuTree");
        }
    }
}