using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using System.Text;
using System.Data;

namespace WechatBuilder.Web.admin.product
{
    public partial class product_list : Web.UI.ManagePage
    {

        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int category_id;

        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            ChkAdminLevel("productlist", MXEnums.ActionEnum.View.ToString()); //检查权限
            this.category_id = MXRequest.GetQueryInt("category_id");
            this.keywords = MXRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每页数量

            if (!Page.IsPostBack)
            {

                TreeBind(); //绑定类别
                RptBind(this.category_id, "id>0" + CombSqlTxt(this.keywords), "extInt asc,createdate desc ");
            }
        }

        #region 绑定类别=================================
        private void TreeBind()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();

            BLL.wx_product_type bll = new BLL.wx_product_type();
            DataTable dt = bll.GetWCodeList(weixin.id,0);

            this.ddlCategoryId.Items.Clear();
            this.ddlCategoryId.Items.Add(new ListItem("所有类别", ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                int ClassLayer = int.Parse(dr["class_layer"].ToString());
                string Title = dr["tName"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
                }
                else
                {
                    Title = "├ " + Title;
                    Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                    this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
                }
            }
        }
        #endregion

        #region 数据绑定=================================
        private void RptBind(int _category_id, string _strWhere, string _orderby)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();

            this.page = MXRequest.GetQueryInt("page", 1);
            if (this.category_id > 0)
            {
                this.ddlCategoryId.SelectedValue = _category_id.ToString();
            }

            this.txtKeywords.Text = this.keywords;
            //列表显示
            BLL.wx_product bll = new BLL.wx_product();
            DataSet artDs = bll.GetWCodeList(weixin.id,_category_id, this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);

            //链接处理，待做
            if (artDs != null)
            {
                DataRow dr;
                for (int i = 0; i < artDs.Tables[0].Rows.Count; i++)
                {
                    dr = artDs.Tables[0].Rows[i];
                    dr["url"] = " <a href=\"javascript:;\">" + MyCommFun.getWebSite() + "/weixin/product/detail.aspx?wid=" + MyCommFun.ObjToStr(dr["wid"]) + "&id=" + dr["id"] + "</a>";
                }
            }

            this.rptList1.DataSource = artDs;
            this.rptList1.DataBind();
            

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("product_list.aspx", "category_id={0}&keywords={1}&page={2}", ddlCategoryId.SelectedValue, this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords )
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and hdName like '%" + _keywords + "%'");
            }
            
            
            return strTemp.ToString();
        }
        #endregion

        #region 返回图文每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("product_list_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //设置操作
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
           
        }

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string keyw = txtKeywords.Text;
            Response.Redirect(Utils.CombUrlTxt("product_list.aspx", "category_id={0}&keywords={1}",
              ddlCategoryId.SelectedValue, keyw));
        }

        //筛选类别
        protected void ddlCategoryId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("product_list.aspx", "category_id={0}&keywords={1}",
               ddlCategoryId.SelectedValue, this.keywords));
        }
 
        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("product_list_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("product_list.aspx", "category_id={0}&keywords={1}",
              ddlCategoryId.SelectedValue, this.keywords));
        }

        //保存排序
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("productlist", MXEnums.ActionEnum.Edit.ToString()); //检查权限
            BLL.wx_product bll = new BLL.wx_product();
            Repeater rptList = new Repeater();
             rptList = this.rptList1;
                
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
                {
                    sortId = 99;
                }
                bll.UpdateField(id, "extInt=" + sortId.ToString());
            }
            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "保存产品库排序"); //记录日志
            Response.Redirect(Utils.CombUrlTxt("product_list.aspx", "category_id={0}&keywords={1}",
               ddlCategoryId.SelectedValue, this.keywords));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("productlist", MXEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0; //成功数量
            int errorCount = 0; //失败数量
            BLL.wx_product bll = new BLL.wx_product();
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
            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "删除产品库内容成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            Response.Redirect(Utils.CombUrlTxt("product_list.aspx", "category_id={0}&keywords={1}",
              ddlCategoryId.SelectedValue, this.keywords));
        }
    }
}