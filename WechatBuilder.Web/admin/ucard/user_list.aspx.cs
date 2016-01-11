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
    public partial class user_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected int sid = 0;//店铺主键id
        BLL.wx_ucard_users uBll = new BLL.wx_ucard_users();
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = MXRequest.GetQueryString("keywords");
            sid = MyCommFun.RequestInt("id");

            if (sid == 0)
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }
            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {

                RptBind(CombSqlTxt(keywords), "id desc");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {

            Model.wx_userweixin weixin = GetWeiXinCode();
            _strWhere = "sId=" + sid + " " + _strWhere;
            this.page = MXRequest.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            DataSet ds = uBll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            //计算级别
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) {
                BLL.wx_ucard_udegree degreeBll = new BLL.wx_ucard_udegree();
                IList<Model.wx_ucard_udegree> degreelist = degreeBll.GetModelList("sid=" + sid);
                DataRow dr;
                int count = ds.Tables[0].Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    dr = ds.Tables[0].Rows[i];
                    int score=MyCommFun.Obj2Int(dr["ttScore"]);
                    dr["jibie"] = ComputeJiBie(score, degreelist);
                    ds.AcceptChanges();
                }
            }
           

            this.rptList.DataSource = ds;
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("user_list.aspx?id=" + sid, "keywords={0}&page={1}", this.keywords, "__id__");
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
                strTemp.Append(" and  realName like  '%" + _keywords + "%'  ");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("user_list_page_size"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("user_list.aspx", "id={0}&keywords={1}", this.sid.ToString(), txtKeywords.Text));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("user_list_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("user_list.aspx", "id={0}&keywords={1}", this.sid.ToString(), this.keywords));
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
                    if (uBll.Delete(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(MXEnums.ActionEnum.Delete.ToString(), "删除分店信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志

            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("user_list.aspx", "id={0}&keywords={1}", this.sid.ToString(), this.keywords), "Success");
        }


        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    Literal litJibie = e.Item.FindControl("litJibie") as Literal;

            //}
        }


        /// <summary>
        /// 根据级别算级别
        /// </summary>
        /// <param name="score"></param>
        /// <param name="degreelist"></param>
        /// <returns></returns>
        private string ComputeJiBie(int score, IList<Model.wx_ucard_udegree> degreelist)
        {
            string jibie = "";

            IList<Model.wx_ucard_udegree> tmpDegree = (from d in degreelist where d.score_min <= score && d.score_max > score orderby d.degreeNum ascending select d).ToArray < Model.wx_ucard_udegree>();
            if (tmpDegree != null&& tmpDegree.Count>0)
            {
                jibie = tmpDegree[0].callName;
            }
            return jibie;
        }
    }
}