using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.weixin.product
{
    public partial class index : System.Web.UI.Page
    {
        BLL.wx_product hdBll = new BLL.wx_product();
        int tid = MyCommFun.RequestInt("tid");
        int wid = MyCommFun.RequestInt("wid");
        int pageSize = 10;
        string openid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            openid = MyCommFun.RequestOpenid();
            if (!IsPostBack)
            {
                if (MyCommFun.RequestInt("tid")==0)
                {
                    return;
                }
               
                BLL.wx_product_type sbll = new BLL.wx_product_type();
                Model.wx_product_type type = sbll.GetModel(tid);
                if (type != null  )
                {
                    imgBanner.ImageUrl = type.icoPic;
                    this.Title =type.tName;
                }
                else
                {
                    imgBanner.Style.Add("display", "none");
                }
                BindData();
                BindRepeater(MyCommFun.RequestInt("page", 1));
            }
        }

        /// <summary>
        /// 绑定页码等基本信息
        /// </summary>
        public void BindData()
        {

            int page = MyCommFun.RequestInt("page", 1);

            IList<Model.wx_product> hdList = hdBll.GetModelList("typeId=" + tid + " order by extInt asc,createdate desc");
            if (hdList == null || hdList.Count <= 0)
            {
                return;
            }
            int count = hdList.Count;
            int totPage = count / pageSize;
            if (count % pageSize > 0)
            {
                totPage += 1;
            }
            litTotalPage.Text = totPage.ToString();
            litCurrentPage.Text = page.ToString();
            //上一页
            if (page == 1)
            {
                litGoBefore.Text = " <div class=\"c-p-pre  c-p-grey  \"> <span class=\"c-p-p\"><em></em></span><a>上一页</a> </div>";
            }
            else
            {
                litGoBefore.Text = " <div class=\"c-p-pre \"> <span class=\"c-p-p\"><em></em></span><a href=\"" + GetNewUrl(page - 1) + "\">上一页</a> </div>";
            }

            //下一页
            if (page == totPage)
            {
                litGoAfter.Text = " <div class=\"c-p-next  c-p-grey  \"><a>下一页</a><span class=\"c-p-p\"><em></em></span></div>";
            }
            else
            {
                litGoAfter.Text = " <div class=\"c-p-next   \"><a href=\"" + GetNewUrl(page + 1) + "\">下一页</a><span class=\"c-p-p\"><em></em></span></div>";
            }
            //分页的下拉列表
            string selectPageStr = "<select class=\"c-p-select\" onchange=\"fenyedourl(\'" + removePageUrl() + "\'+this.value)\">";
            for (int i = 1; i < totPage + 1; i++)
            {
                if (i == page)
                {
                    selectPageStr += "<option  selected=\"selected\"  value=\"" + i + "\" >第" + i + "页</option> ";
                }
                else
                {
                    selectPageStr += "<option  value=\"" + i + "\" >第" + i + "页</option> ";
                }

            }
            selectPageStr += "</select>";
            litPSelect.Text = selectPageStr;
        }
        /// <summary>
        /// 根据pageNum设置新的带有页码的url地址
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        private string GetNewUrl(int page)
        {
            string url = Request.Url.ToString();
            int pageNum = MyCommFun.RequestInt("page");
            if (url.Contains("page="))
            {
                url = url.Replace("page=" + pageNum, "page=" + page);
            }
            else
            {
                if (url.Contains("?"))
                {
                    url = url + "&page=" + page;
                }
                else
                {
                    url = url + "?page=" + page;
                }
            }
            url = MyCommFun.urlAddOpenid(url, openid);
            return url;
        }
        /// <summary>
        /// 去除url的page的值，并且将page参数放到url的最后
        /// </summary>
        /// <returns></returns>
        private string removePageUrl()
        {
            string url = Request.Url.ToString();
            int pageNum = MyCommFun.RequestInt("page");
            if (url.Contains("?page="))
            {
                url = url.Replace("?page=" + pageNum, "?page=");
            }
            else if (url.Contains("&page="))
            {
                url = url.Replace("&page=" + pageNum, "");
                url += "&page=";
            }
            else
            {
                if (url.Contains("?"))
                {
                    url = url + "&page=";
                }
                else
                {
                    url = url + "?page=";
                }
            }
            url = MyCommFun.urlAddOpenid(url, openid);
            return url;
        }

        /// <summary>
        /// 绑定页面的repeater活动列表
        /// </summary>
        /// <param name="currentPage"></param>
        public void BindRepeater(int currentPage)
        {
           
            int RecordCount = 0;
            //currentPage -= 1;
            DataSet hdDt = hdBll.GetPageList("typeId=" + tid, pageSize, currentPage, out RecordCount, " extInt asc,createdate desc");
            string showinfoStr = "";
            if (hdDt != null && hdDt.Tables.Count > 0 && hdDt.Tables[0].Rows.Count > 0)
            {
                DataRow dr;
                for (int i = 0; i < hdDt.Tables[0].Rows.Count; i++)
                {
                    dr = hdDt.Tables[0].Rows[i];
                    showinfoStr = "";
                    if (dr["showDate"].ToString().ToLower() == "true")
                    {
                        showinfoStr += " <span class=\"list_span\">" + dateStr(dr["createDate"]) + "</span>";
                    }
                    if (dr["showPrice"].ToString().ToLower() == "true")
                    {
                        showinfoStr += "<span class=\"list_span span_money\">￥" + dr["price"].ToString() + "</span>";
                    }
                    if (dr["showYuDing"].ToString().ToLower() == "true")
                    {
                        showinfoStr += " <a href='" + MyCommFun.urlAddOpenid(MyCommFun.ObjToStr(dr["url"]), openid) + "' class=\"a_yuding\">" + (MyCommFun.ObjToStr(dr["btnName"]) == null ? "预定" : MyCommFun.ObjToStr(dr["btnName"])) + "</a>";
                    }
                    if (showinfoStr != "")
                    {
                        dr["showInfo"] = " <div class=\"list_div\">" + showinfoStr + " </div>  ";
                    }

                }
            }


            rpAction.DataSource = hdDt;
            rpAction.DataBind();
            litCurrentPage.Text = currentPage.ToString();
        }

        #region 页面上repeater调用的方法
        public string getTypeUrl(object tId)
        {
            string openid = MyCommFun.RequestOpenid();

            string ret = "index.aspx?openid=" + openid + "&tid=" + tId.ToString() + "&wid" + wid;
            return ret;
        }

        public string getDetailUrl(object id, object tid)
        {
            string openid = MyCommFun.RequestOpenid();

            string ret = "detail.aspx?id=" + id.ToString() + "&openid=" + openid + "&tid=" + tid.ToString() + "&wid=" + wid;
            return ret;
        }
        #endregion

        private string dateStr(object t)
        {
            if (t == null)
            {
                return "";
            }
            DateTime tmpDate = new DateTime();
            if (DateTime.TryParse(t.ToString(), out tmpDate))
            {
                return tmpDate.ToShortDateString();
            }
            else
            {
                return "";
            }
        }

        
    }
}