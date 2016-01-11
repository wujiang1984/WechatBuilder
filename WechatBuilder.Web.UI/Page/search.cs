using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Text;
using WechatBuilder.Common;

namespace WechatBuilder.Web.UI.Page
{
    public partial class search : Web.UI.BasePage
    {
        protected int page;         //当前页码
        protected string keyword = string.Empty; //关健字
        protected int totalcount;   //OUT数据总数
        protected string channel_name = string.Empty;//频道名称
        /// <summary>
        /// 重写虚方法,此方法将在Init事件前执行
        /// </summary>
        protected override void ShowPage()
        {
            page = MXRequest.GetQueryInt("page", 1);
            keyword = MXRequest.GetQueryStringValue("keyword");
            channel_name = MXRequest.GetQueryStringValue("channel_name");
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        protected DataTable get_search_list(int _pagesize, out int _totalcount)
        {
            string strwhere = string.Empty;
            if (!string.IsNullOrEmpty(channel_name))
                strwhere += " and b.name='" + channel_name+"'";
            //组合查询条件
            string strWhere = "(a.title like '%" + keyword + "%' or a.zhaiyao like '%" + keyword + "%') " + strwhere;

            //创建一个DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("title", Type.GetType("System.String"));
            dt.Columns.Add("remark", Type.GetType("System.String"));
            dt.Columns.Add("channel_id", Type.GetType("System.String"));
            dt.Columns.Add("link_url", Type.GetType("System.String"));
            dt.Columns.Add("add_time", Type.GetType("System.String"));
            dt.Columns.Add("img_url", Type.GetType("System.String"));
            dt.Columns.Add("name", Type.GetType("System.String"));
            DataSet ds = new BLL.article().GetList(_pagesize, page, strWhere, "add_time desc,id desc", out _totalcount);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr1 = ds.Tables[0].Rows[i];
                    string link_url = get_url_rewrite(Utils.StrToInt(dr1["channel_id"].ToString(), 0), dr1["call_index"].ToString(), Utils.StrToInt(dr1["id"].ToString(), 0));
                    if (!string.IsNullOrEmpty(link_url))
                    {
                        DataRow dr = dt.NewRow();
                        dr["title"] = dr1["title"]; //标题
                        dr["remark"] = dr1["zhaiyao"]; //摘要
                        dr["link_url"] = link_url; //链接地址
                        dr["add_time"] = dr1["add_time"]; //发布时间
                        dr["channel_id"] = dr1["channel_id"]; //频道ID
                        dr["img_url"] = dr1["img_url"]; //发布时间
                        dr["name"] = dr1["name"]; //发布时间
                        dt.Rows.Add(dr);
                    }
                }
            }
            return dt;
        }

        //查找匹配的URL
        private string get_url_rewrite(int channel_id, string call_index, int id)
        {
            if (channel_id == 0)
            {
                return string.Empty;
            }
            string querystring = id.ToString();
            string channel_name = new BLL.channel().GetChannelName(channel_id);
            if (string.IsNullOrEmpty(channel_name))
            {
                return string.Empty;
            }
            if (!string.IsNullOrEmpty(call_index))
            {
                querystring = call_index;
            }
            BLL.url_rewrite bll = new BLL.url_rewrite();
            Model.url_rewrite model = bll.GetInfo(channel_name, "detail");
            if (model != null)
            {
                return linkurl(model.name, querystring);
            }
            return string.Empty;
        }

    }
}
