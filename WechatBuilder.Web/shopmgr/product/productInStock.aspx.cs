using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using System.Text;
using System.Data;

namespace WechatBuilder.Web.shopmgr.product
{
    public partial class productInStock : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        BLL.wx_shop_product caBll = new BLL.wx_shop_product();
        protected int catalogId = 0;
        protected int category_id;
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = MXRequest.GetQueryString("keywords");
            this.category_id = MXRequest.GetQueryInt("category_id");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                TreeBind();
                RptBind(this.category_id, CombSqlTxt(keywords), "sort_id asc,id desc");
            }
        }
        #region 绑定类别=================================
        private void TreeBind()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();

            BLL.wx_shop_category bll = new BLL.wx_shop_category();
            DataTable dt = bll.GetWCodeList(weixin.id, 0);

            this.ddlCategoryId.Items.Clear();
            this.ddlCategoryId.Items.Add(new ListItem("所有类别", ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                int ClassLayer = int.Parse(dr["class_layer"].ToString());
                string Title = dr["title"].ToString().Trim();

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
            if (this.category_id > 0)
            {
                this.ddlCategoryId.SelectedValue = _category_id.ToString();
            }
            _strWhere = " upselling=0   " + _strWhere;
            

            Model.wx_userweixin weixin = GetWeiXinCode();
            lblWid.Text = weixin.id.ToString();

            this.page = MXRequest.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            DataSet ds = caBll.GetList(weixin.id, this.category_id, this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);

            this.rptList.DataSource = ds;
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("productInStock.aspx", "category_id={0}&keywords={1}&page={2}", _category_id.ToString(), this.keywords, "__id__");
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
                strTemp.Append(" and  productName like  '%" + _keywords + "%' ");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("productInStock_list_page_size"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("productInStock.aspx", "category_id={0}&keywords={1}", this.category_id.ToString(), txtKeywords.Text));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("productInStock_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("productInStock.aspx", "category_id={0}&keywords={1}", this.category_id.ToString(), this.keywords));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // ChkAdminLevel("manager_list", MXEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (caBll.Delete(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(MXEnums.ActionEnum.Delete.ToString(), "删除商品信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志

            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("productInStock.aspx", "category_id={0}&keywords={1}", this.category_id.ToString(), this.keywords), "Success");
        }

        //保存排序
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //ChkAdminLevel("channel_" + this.channel_name + "_list", MXEnums.ActionEnum.Edit.ToString()); //检查权限
            BLL.wx_shop_product bll = new BLL.wx_shop_product();
            Repeater rptList = this.rptList;

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
                {
                    sortId = 99;
                }
                bll.UpdateField(id, "sort_id=" + sortId.ToString());
            }
            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "保存出售中的商品内容排序"); //记录日志
            JscriptMsg("保存排序成功啦！", Utils.CombUrlTxt("productInStock.aspx", "category_id={0}&keywords={1}", this.category_id.ToString(), this.keywords), "Success");
        }

        //保存排序
        protected void btnXiJia_Click(object sender, EventArgs e)
        {
            //ChkAdminLevel("channel_" + this.channel_name + "_list", MXEnums.ActionEnum.Edit.ToString()); //检查权限
            BLL.wx_shop_product bll = new BLL.wx_shop_product();
            Repeater rptList = this.rptList;

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.UpdateField(id, "upselling=1");
                }
            }
            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "上架出售中的商品"); //记录日志
            JscriptMsg("商品上架成功啦！", Utils.CombUrlTxt("productInStock.aspx", "category_id={0}&keywords={1}", this.category_id.ToString(), this.keywords), "Success");

        }


        //筛选类别
        protected void ddlCategoryId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("productInStock.aspx", "category_id={0}&keywords={1}", ddlCategoryId.SelectedValue, this.keywords));
        }

        /// <summary>
        ///  设置操作
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(((HiddenField)e.Item.FindControl("hidId")).Value);
            BLL.wx_shop_product bll = new BLL.wx_shop_product();
            Model.wx_shop_product model = bll.GetModel(id);
            switch (e.CommandName)
            {
                case "lbtnIslatest"://最新
                    if (model.latest)
                        bll.UpdateField(id, "latest=0");
                    else
                        bll.UpdateField(id, "latest=1");
                    break;
                case "lbtnIshotsale":
                    if (model.hotsale)
                        bll.UpdateField(id, "hotsale=0");
                    else
                        bll.UpdateField(id, "hotsale=1");
                    break;
                case "lbtnIsspecialOffer":
                    if (model.specialOffer)
                        bll.UpdateField(id, "specialOffer=0");
                    else
                        bll.UpdateField(id, "specialOffer=1");
                    break;

            }
            this.RptBind(this.category_id, CombSqlTxt(this.keywords), "sort_id asc,id desc");
        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal litlatest = e.Item.FindControl("litlatest") as Literal;
                Literal lithotsale = e.Item.FindControl("lithotsale") as Literal;
                Literal litspecialOffer = e.Item.FindControl("litspecialOffer") as Literal;

                if (litlatest.Text.ToLower() == "true")
                {
                    litlatest.Text = " <img alt=\"\" src=\"../../images/yes.gif\" />";
                }
                else
                {
                    litlatest.Text = " <img alt=\"\" src=\"../../images/no.gif\" />";
                }

                if (lithotsale.Text.ToLower() == "true")
                {
                    lithotsale.Text = " <img alt=\"\" src=\"../../images/yes.gif\" />";
                }
                else
                {
                    lithotsale.Text = " <img alt=\"\" src=\"../../images/no.gif\" />";
                }

                if (litspecialOffer.Text.ToLower() == "true")
                {
                    litspecialOffer.Text = " <img alt=\"\" src=\"../../images/yes.gif\" />";
                }
                else
                {
                    litspecialOffer.Text = " <img alt=\"\" src=\"../../images/no.gif\" />";
                }




            }
        }
    }
}