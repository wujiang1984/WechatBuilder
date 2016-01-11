using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using System.Text;
using System.Data;

namespace WechatBuilder.Web.shopmgr.catalog
{
    public partial class attribute_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        BLL.wx_shop_catalog_attribute caBll = new BLL.wx_shop_catalog_attribute();
        protected int catalogId = 0;
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = MXRequest.GetQueryString("keywords");
            catalogId = MyCommFun.RequestInt("id");
            if (catalogId == 0)
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                BLL.wx_shop_catalog cataBll = new BLL.wx_shop_catalog();
                Model.wx_shop_catalog cata = cataBll.GetModel(catalogId);
                lblCatalogName.Text = cata.cTitle;

                RptBind(CombSqlTxt(keywords), "sort_id asc,id desc");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {

            Model.wx_userweixin weixin = GetWeiXinCode();
            lblWid.Text = weixin.id.ToString();

            _strWhere = "wid=" + weixin.id + " and catalogId=" + catalogId + "" + _strWhere;
            this.page = MXRequest.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            DataSet ds = caBll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);

            this.rptList.DataSource = ds;
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("attribute_list.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
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
                strTemp.Append(" and  aName like  '%" + _keywords + "%' ");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("attribute_list_page_size"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("attribute_list.aspx", "keywords={0}", txtKeywords.Text));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("attribute_list_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("attribute_list.aspx", "keywords={0}", this.keywords));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
             catalogId = MyCommFun.RequestInt("id");

            // ChkAdminLevel("manager_list", MXEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (caBll.DeleteAttribute(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }

            AddAdminLog(MXEnums.ActionEnum.Delete.ToString(), "删除商品属性信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志

            if (errorCount > 0)
            {
                JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！ 属性被商品使用，则无法删除！", Utils.CombUrlTxt("attribute_list.aspx?id=" + catalogId, "keywords={0}", this.keywords), "Error");

            }
            else
            {

                JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("attribute_list.aspx?id=" + catalogId, "keywords={0}", this.keywords), "Success");
            }

        }

        /// <summary>
        /// 选择某一个微信公众帐号，并且将其保存到session里
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblaType = e.Item.FindControl("lblaType") as Label;
                if (lblaType.Text == "1")
                {
                    lblaType.Text = "供客户查看";
                }
                else  if (lblaType.Text == "2")
                {
                    lblaType.Text = "客户可选规格";
                }
                else if (lblaType.Text == "3")
                {
                    lblaType.Text = "供客户填写";
                }
            }
        }
    }
}