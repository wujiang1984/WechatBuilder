using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using System.Text;
using System.Data;


namespace WechatBuilder.Web.admin.albums
{
    public partial class index : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        BLL.wx_albums_info tbll = new BLL.wx_albums_info();
        protected string keywords = string.Empty;
        protected int typeId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = MXRequest.GetQueryString("keywords");
            this.typeId = MXRequest.GetQueryInt("typeId");
            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                TypeBind();
                RptBind(typeId,CombSqlTxt(keywords), "seq asc,id desc");
            }
        }

        /// <summary>
        /// 绑定类别
        /// </summary>
        private void TypeBind()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();

            BLL.wx_albums_type bll = new BLL.wx_albums_type();
            IList<Model.wx_albums_type> dt = bll.GetModelList("wid=" + weixin.id + " order by sort_id asc");

            this.ddlCategoryId.DataTextField = "typeName";
            this.ddlCategoryId.DataValueField = "id";
            this.ddlCategoryId.DataSource = dt;
            this.ddlCategoryId.DataBind();
            ddlCategoryId.Items.Insert(0,new ListItem("请选择类别","0"));
        }

        #region 数据绑定=================================
        private void RptBind(int typeId,string _strWhere, string _orderby)
        {

            Model.wx_userweixin weixin = GetWeiXinCode();
            lblWid.Text = weixin.id.ToString();
            litwUrl.Text = MyCommFun.getWebSite() + "/weixin/albums/index.aspx?wid=" + weixin.id;
            _strWhere = " a.wid=" + weixin.id + " " + _strWhere;
            this.page = MXRequest.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            this.ddlCategoryId.SelectedValue = typeId.ToString();
            DataSet ds = tbll.GetList(this.pageSize, this.page,typeId, _strWhere, _orderby, out this.totalCount);
            
            this.rptList.DataSource = ds;
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("index.aspx", "keywords={0}&typeId={1}&page={2}", this.keywords,this.typeId.ToString(), "__id__");
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
            if (int.TryParse(Utils.GetCookie("albums_page_size"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("index.aspx", "keywords={0}&typeId={1}", txtKeywords.Text,this.ddlCategoryId.SelectedValue));
        }
        //筛选类别
        protected void ddlCategoryId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("index.aspx", "keywords={0}&typeId={1}", this.keywords, ddlCategoryId.SelectedValue));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("albums_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("index.aspx", "keywords={0}&typeId={1}", this.keywords,this.typeId.ToString()));
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
                    if (tbll.DeleteAlbums(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(MXEnums.ActionEnum.Delete.ToString(), "删除相册信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志

            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("index.aspx", "keywords={0}&typeId={1}", this.keywords,this.typeId.ToString()), "Success");
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

            }
        }
    }
}