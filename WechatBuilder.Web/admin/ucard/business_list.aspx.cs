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
    public partial class business_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        BLL.wx_ucard_store gbll = new BLL.wx_ucard_store();
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = MXRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                Model.wx_userweixin weixin = GetWeiXinCode();
                litUrl.Text = MyCommFun.getWebSite() + "/weixin/ucard/ucardlist.aspx?wid=" + weixin.id;

                RptBind(CombSqlTxt(keywords), "createDate desc,id desc");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {

            Model.wx_userweixin weixin = GetWeiXinCode();
            _strWhere = "wid=" + weixin.id + " " + _strWhere;
            this.page = MXRequest.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            DataSet ds = gbll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataSource = ds;
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("business_list.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
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
                strTemp.Append(" and  storeName like  '%" + _keywords + "%' ");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("business_list_page_size"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("business_list.aspx", "keywords={0}", txtKeywords.Text));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("business_list_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("business_list.aspx", "keywords={0}", this.keywords));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("ucard_business", MXEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (gbll.Delete(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(MXEnums.ActionEnum.Delete.ToString(), "删除会员卡商家信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志

            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("business_list.aspx", "keywords={0}", this.keywords), "Success");
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string cName = e.CommandName;
            string cArgument = e.CommandArgument.ToString();
            HiddenField hidId = e.Item.FindControl("hidId") as HiddenField;
            int id =MyCommFun.Str2Int( hidId.Value);
            if (cName == "recommend")
            {
                string v = "1";
                if (cArgument.ToLower() == "true")
                {
                    v = "0";
                }
                else
                {
                    v = "1";
                }
                gbll.UpdateField(id, "isRecommend="+v);
                
            }

            Response.Redirect(Utils.CombUrlTxt("business_list.aspx", "keywords={0}", this.keywords));
       
        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                TextBox txtscardurl = e.Item.FindControl("txtscardurl") as TextBox;
                HiddenField hidId = e.Item.FindControl("hidId") as HiddenField;
                Model.wx_userweixin weixin = GetWeiXinCode();
                txtscardurl.Text = MyCommFun.getWebSite() + "/weixin/ucard/index.aspx?wid=" + weixin.id + "&id=" + hidId.Value ;
                LinkButton lnkbtnRecommend = e.Item.FindControl("lnkbtnRecommend") as LinkButton;
                if (lnkbtnRecommend.Text.ToString().ToLower() == "true")
                {
                    lnkbtnRecommend.Text = "已推荐";
                }
                else
                {
                    lnkbtnRecommend.Text = "未推荐";
                }

            }
        }
    }
}