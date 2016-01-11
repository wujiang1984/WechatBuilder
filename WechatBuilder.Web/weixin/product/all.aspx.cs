using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.weixin.product
{
    public partial class all : System.Web.UI.Page
    {

        BLL.wx_product hdBll = new BLL.wx_product();
        int wid = MyCommFun.RequestInt("wid");
        int pid = MyCommFun.RequestInt("pid");
        int pageSize = 10;
        string openid = MyCommFun.RequestOpenid();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                
                BLL.wx_product_sys bll = new BLL.wx_product_sys();

                IList<Model.wx_product_sys> sys = bll.GetModelList("wid=" + wid+" and id="+pid);
                if (sys != null && sys.Count >= 0)
                {
                    imgBanner.ImageUrl = sys[0].banner;
                    this.Title = sys[0].title;
                }
                else
                {
                    imgBanner.Style.Add("display", "none");
                }
                BindTypeData();
                BindPageInfoData();
                BindRepeater(MyCommFun.RequestInt("page", 1));

            }
        }

        /// <summary>
        /// 绑定活动类别的方法
        /// </summary>
        public void BindTypeData()
        {
            BLL.wx_product_type sbll = new BLL.wx_product_type();
            IList<Model.wx_product_type> typelist = sbll.GetModelList("wid=" + wid + " and store_id="+pid+" order by sort_id asc");
            if (typelist != null && typelist.Count > 0)
            {
                StringBuilder sb = new StringBuilder("");
                for (int i = 0; i < typelist.Count; i++)
                {
                    string url = "";
                    if (typelist[i].tUrl != null && typelist[i].tUrl.Trim().Length > 0)
                    {
                        url = MyCommFun.urlAddOpenid(typelist[i].tUrl, openid);
                    }
                    else
                    {
                        url = MyCommFun.urlAddOpenid("index.aspx?tid=" + typelist[i].id + "&wid=" + wid + "&pid=" + pid,openid);
                    }
                    sb.Append(" <li>");
                    sb.Append("<a href=\"" + url + "\">" + typelist[i].tName);
                    sb.Append("</a></li>");
                
                }
                litTypeInfo.Text = sb.ToString();
            }
           

        }
        /// <summary>
        /// 初始化分页里的数据
        /// </summary>
        public void BindPageInfoData()
        {
            IList<Model.wx_product> hdList = hdBll.GetModelList(" typeId in (select id from  wx_product_type where  wid=" + wid + " and store_id=" + pid + ")  order by extInt asc,createdate desc");
             
            if (hdList == null || hdList.Count <= 0)
            {
                return;
            }
            int page = MyCommFun.RequestInt("page", 1);
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

           // currentPage -= 1;
            DataSet hdDt = hdBll.GetPageList(" typeId  in (select id from  wx_product_type where wid=" + wid + "  and store_id=" + pid + ")", pageSize, currentPage, out RecordCount, " extInt asc,createdate desc");
            
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
                        showinfoStr += "<span class=\"list_span span_money\">￥" +MyCommFun.ObjToStr(dr["price"]) + "</span>";
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
       

        public string getDetailUrl(object id, object tid)
        {
            string openid = MyCommFun.RequestOpenid();

            string ret = "detail.aspx?id=" + id.ToString() + "&openid=" + openid + "&tid=" + tid.ToString()+"&wid="+wid+"&pid="+pid;
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
               return  "";
            }
        }
    }
}