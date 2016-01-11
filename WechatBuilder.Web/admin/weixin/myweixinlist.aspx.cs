using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;


namespace WechatBuilder.Web.admin.weixin
{
    public partial class myweixinlist : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page=1;
        protected int pageSize=20;
        BLL.wx_userweixin bll = new BLL.wx_userweixin();
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = MXRequest.GetQueryString("keywords");
            if (!Page.IsPostBack)
            {
                RptBind(CombSqlTxt(keywords), "createDate desc,id desc");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            Model.manager model = GetAdminInfo(); //取得当前管理员信息
            _strWhere = "uId=" + model.id +" and isDelete=0 " + _strWhere+" order by "+_orderby;
          
            txtKeywords.Text = this.keywords;
            IList<Model.wx_userweixin> wxList=bll.GetModelList( _strWhere);

            if (wxList != null)
            {
                lblHasNum.Text = wxList.Count.ToString();
            }
            lblTotNum.Text = model.wxNum.ToString();

            this.rptList.DataSource = wxList;
            this.rptList.DataBind();
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (wxName like  '%" + _keywords + "%' or weixinCode like '%" + _keywords + "%')");
            }

            return strTemp.ToString();
        }
        #endregion

       

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("myweixinlist.aspx", "keywords={0}", txtKeywords.Text));
        }

        

        /// <summary>
        /// 选择某一个微信公众帐号，并且将其保存到session里
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "toIndex":
                    {
                        int wid = int.Parse(e.CommandArgument.ToString());
                        Model.wx_userweixin weixin = bll.GetModel(wid);
                        Session["nowweixin"] = weixin;
                        Utils.WriteCookie("nowweixinId", "WechatBuilder", e.CommandArgument.ToString());
                        Response.Write("<script>parent.location.href='/admin/index.aspx'</script>");
                    }
                    break;
                case "delete":
                    {
                        int wid = int.Parse(e.CommandArgument.ToString());
                        BLL.wx_userweixin bll = new BLL.wx_userweixin();
                        bll.Delete(wid);
                        JscriptMsg("删除公众号成功！", "?", "Success");
                    }
                    break;
            } 
        }
    }
}