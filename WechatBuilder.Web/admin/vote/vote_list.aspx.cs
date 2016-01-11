using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.admin.vote
{
    public partial class vote_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected int typeid=0;
        BLL.wx_vote_base gbll = new BLL.wx_vote_base();
        protected int wid = 0;
        protected string yuming = "";
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = MXRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
           
                yuming = MyCommFun.getWebSite();
                typeid = MyCommFun.RequestInt("typeid");
                RptBind(typeid, CombSqlTxt(keywords), "id desc");

            }
        }

        protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("vote_list.aspx", "typeid={0}&keywords={1}", ddlProperty.SelectedValue, this.keywords));
        }


        #region 数据绑定=================================
        private void RptBind(int typeid,string _strWhere, string _orderby)
        {

            Model.wx_userweixin weixin = GetWeiXinCode();
            wid = weixin.id;
            //判断是否已经设置了微留言基本信息
            _strWhere = "wId=" + weixin.id + " " + _strWhere;
            if (typeid == 0)
            {
               
            }
            else
            {

                _strWhere = "voteType=" + typeid + " and " + _strWhere;
            }
          
            this.page = MXRequest.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            ddlProperty.SelectedValue = typeid.ToString();
            DataSet ds = gbll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            // DataSet ds = gbll.GetList( _strWhere);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr;

                int count = ds.Tables[0].Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    dr = ds.Tables[0].Rows[i];

                }
                ds.AcceptChanges();
            }
            this.rptList.DataSource = ds;
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("vote_list.aspx", "typeid={0}&keywords={1}&page={2}",ddlProperty.SelectedValue, this.keywords, "__id__");
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
                strTemp.Append(" and  title like  '%" + _keywords + "%' ");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("vote_list_page_size"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("vote_list.aspx", "typeid={0}&keywords={1}", ddlProperty.SelectedValue,this.txtKeywords.Text));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("vote_list_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("vote_list.aspx", "typeid={0}&keywords={1}", ddlProperty.SelectedValue, this.txtKeywords.Text));
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
            AddAdminLog(MXEnums.ActionEnum.Delete.ToString(), "信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志

            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("vote_list.aspx","typeid={0}&keywords={1}", ddlProperty.SelectedValue, this.txtKeywords.Text), "Success");
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "end":
                    {
                        int id = int.Parse(e.CommandArgument.ToString());
                        Model.wx_vote_base baseinfo = gbll.GetModel(id);
                        if (baseinfo.endTime <= DateTime.Now)
                        {

                        }
                        else
                        {
                            gbll.UpdateField(id, "endTime='" + DateTime.Now + "'");
                        }
                    }
                    break;
            }
            JscriptMsg("操作成功", Utils.CombUrlTxt("vote_list.aspx", "typeid={0}&keywords={1}", ddlProperty.SelectedValue, this.txtKeywords.Text), "Success");

        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

            }
        }

        public string bianjiStr(object id, object voteType)
        {
            if (voteType.ToString().ToLower() == "1")
            { 
                //文字
                return "<a href=\"vote_editcharact.aspx?id=" + id.ToString() + "\"  >编辑</a>";
            }
            else
            { //图片

                return "<a href=\"vote_editepicture.aspx?id=" + id.ToString() + "\"  >编辑</a>";
            }


        }

        public string voteresult(object id, object wid)
        {
            
            return "<a href=\"vote_result.aspx?aid=" + id.ToString() + "&wid="+wid.ToString()+"\"  >投票结果</a>";
            
        }

    }
}