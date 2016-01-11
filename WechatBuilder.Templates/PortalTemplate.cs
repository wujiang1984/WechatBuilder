using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WechatBuilder.Common;
using VTemplate.Engine;

namespace WechatBuilder.Templates
{
    public class PortalTemplate
    {
        WechatBuilder.DAL.templatesDal tDal = new DAL.templatesDal();

        #region 属性
        protected internal string ccRight = "(c)2014 XX公司 技术提供";
        /// <summary>
        /// 当前页面的模板文档对象
        /// </summary>
        protected TemplateDocument Document
        {
            get;
            private set;
        }

        /// <summary>
        /// 当前页面的模板文档的配置参数
        /// </summary>
        protected virtual TemplateDocumentConfig DocumentConfig
        {
            get
            {
                return TemplateDocumentConfig.Default;
            }
        }

        /// <summary>
        /// 模版类型
        /// </summary>
        public TemplateType tType { get; set; }

        #endregion

        /// <summary>
        /// 模版初始化
        /// </summary>
        /// <param name="tPath">模版文件的完全路径</param>
        /// <param name="wid"></param>
        public PortalTemplate(string tPath)
        {
            this.Document = new TemplateDocument(tPath, Encoding.UTF8, this.DocumentConfig);


        }

        /// <summary>
        /// 输出最终的html
        /// </summary>
        /// <param name="templateFileName"></param>
        /// <param name="tPath"></param>
        /// <param name="wid"></param>
        public void OutPutHtml(string templateFileName)
        {
            ////注册一个自定义函数
            //this.Document.RegisterGlobalFunction(this.GetNewsUrl);

            //对VT模板里的config变量赋值 
            Model.siteconfig config = new BLL.siteconfig().loadConfig();
            string dd = Utils.ObjectToStr(config.webkeyword);
            this.Document.Variables.SetValue("config", config);

            this.Document.SetValue("ccright", ccRight);
            this.Document.SetValue("thisurl", MyCommFun.getTotalUrl());
            this.Document.SetValue("yuming", MyCommFun.getWebSite());
            string openid = MyCommFun.RequestOpenid();
            this.Document.SetValue("openid", openid);
            this.Document.Variables.SetValue("this", this);
            if (tType == TemplateType.Class)
            { //如果为列表页面
                ArticleClassPage();
            }
            if (tType == TemplateType.News)
            {
                ArticleDetailPage();
            }
            if (tType == TemplateType.Channel)
            {
                ArticleChannelPage();
            }

            //输出最终呈现的数据 
            this.Document.Render(HttpContext.Current.Response.Output);

        }

        #region 方法集合：注册到模版或者供模版调用
        /// <summary>
        /// 列表页面独有的数据
        /// </summary>
        public void ArticleClassPage()
        {
            int category_id = 0;
            int channel_id = 0;
            category_id = MyCommFun.RequestInt("cid");

            if (category_id == 0)
            {
                var categoryid = this.Document.GetChildTagById("categoryid");
                category_id = MyCommFun.Obj2Int(categoryid.Attributes["value"].Value.ToString());
            }
            var channelid = this.Document.GetChildTagById("channel_id");
            channel_id = MyCommFun.Obj2Int(channelid.Attributes["value"].Value.ToString());


            //--=====begin: 将这个列表（文章类别）的基本信息展示出来 ====--
            DAL.article_category cateDal = new DAL.article_category("dt_");
            Model.article_category category = cateDal.GetModel(category_id);
            this.Document.SetValue("category", category);
            //--=====end: 将这个列表（文章类别）的基本信息展示出来 ====--

            Tag orderByTag = this.Document.GetChildTagById("norderby");
            string orderby = orderByTag.Attributes["value"].Value.ToString();

            Tag pagesizeTag = this.Document.GetChildTagById("npagesize");
            string pagesizeStr = pagesizeTag.Attributes["value"].Value.ToString();

            int currPage = 1;//当前页面
            int recordCount = 0;//总记录数
            int totPage = 1;//总页数
            int pageSize = MyCommFun.Str2Int(pagesizeStr);//每页的记录数
            if (pageSize <= 0)
            {
                pageSize = 10;
            }
            if (MyCommFun.RequestInt("page") > 0)
            {
                currPage = MyCommFun.RequestInt("page");
            }

            DataSet artlist = new DataSet();
            if (category_id != 0)
            {

                DAL.article artDal = new DAL.article();
                artlist = artDal.GetList("hotnews", category_id, pageSize, currPage, "channel_id=" + channel_id, orderby, out recordCount);
                if (artlist != null && artlist.Tables.Count > 0 && artlist.Tables[0].Rows.Count > 0)
                {
                    DataRow dr;
                    for (int i = 0; i < artlist.Tables[0].Rows.Count; i++)
                    {
                        dr = artlist.Tables[0].Rows[i];
                        if (dr["link_url"] == null || dr["link_url"].ToString().Trim().Length <= 0)
                        {
                            dr["link_url"] = "/portalpage/weixin_news_detail.aspx?id=" + dr["id"].ToString();
                        }

                        artlist.AcceptChanges();
                    }

                    totPage = recordCount / pageSize;
                    int yushu = recordCount % pageSize;
                    if (yushu > 0)
                    {
                        totPage += 1;
                    }
                    if (totPage < 1)
                    {
                        totPage = 1;
                    }
                }
                if (currPage > totPage)
                {
                    currPage = totPage;
                }
            }
            else
            {
                currPage = 1;
                recordCount = 0;
                totPage = 1;
            }
            this.Document.SetValue("totPage", totPage);//总页数
            this.Document.SetValue("currPage", currPage);//当前页
            this.Document.SetValue("newslist", artlist);//文章列表

            string beforePageStr = ""; //上一页
            string nextPageStr = ""; //下一页
            string bgrey = "c-p-grey";
            string ngrey = "c-p-grey";
            if (currPage <= 1)
            {
                beforePageStr = "javascript:;";
                bgrey = "c-p-grey";
            }
            else
            {
                beforePageStr = MyCommFun.ChangePageNum(MyCommFun.getTotalUrl(), (currPage - 1));
                beforePageStr = "href=\"" + beforePageStr + "\"";
                bgrey = "";
            }

            if (currPage >= totPage)
            {
                nextPageStr = "javascript:;";
                ngrey = " c-p-grey";
            }
            else
            {
                nextPageStr = MyCommFun.ChangePageNum(MyCommFun.getTotalUrl(), (currPage + 1));
                nextPageStr = "href=\"" + nextPageStr + "\"";
                ngrey = "";
            }
            this.Document.SetValue("bpage", beforePageStr);//上一页
            this.Document.SetValue("npage", nextPageStr);//下一页
            this.Document.SetValue("bgrey", bgrey);//上一页灰色的样式
            this.Document.SetValue("ngrey", ngrey);//下一页灰色的样式



        }

        /// <summary>
        /// 信息详情页面
        /// </summary>
        public void ArticleDetailPage()
        {
            DAL.article artDal = new DAL.article();
            int aid = MyCommFun.RequestInt("id");
            if (aid == 0)
            {
                var article_id = this.Document.GetChildTagById("article_id");
                if (article_id != null && article_id.Attributes["value"]!=null)
                {
                    aid = MyCommFun.Obj2Int(article_id.Attributes["value"].Value.ToString());
                }
            }

            Model.article article = artDal.GetModel(aid);
            if (article != null)
            {
                this.Document.SetValue("model", article);
            }
        }


        /// <summary>
        /// 频道页面
        /// </summary>
        public void ArticleChannelPage()
        {
            int cid = MyCommFun.RequestInt("cid");
            if (cid == 0)
            {
                var category_id = this.Document.GetChildTagById("category_id");
                if (category_id != null && category_id.Attributes["value"] != null)
                {
                    cid = MyCommFun.Obj2Int(category_id.Attributes["value"].Value.ToString());
                }
            }
            DAL.article_category cateDal = new DAL.article_category("dt_");
            Model.article_category category = cateDal.GetModel(cid);
            if (category != null)
            {
                this.Document.SetValue("model", category);
            }

        }

        /// <summary>
        /// 取频道下的分类
        /// </summary>
        public DataTable CategoryListByChannelName()
        {
            Tag tag = this.Document.CurrentRenderingTag;

            var attribute = tag.Attributes["channel_name"];

            string channel_name = attribute.Text;
         
            //--=====begin: 将这个频道下的所有分类的基本信息 ====--
            BLL.article_category cateDal = new BLL.article_category();
            DataTable dt = cateDal.GetList(0, channel_name);
            return dt;
            //--=====end: 将这个频道下的所有分类的基本信息 ====--
        }

        /// <summary>
        /// 获得某个分类下的文章
        /// </summary>
        /// <returns></returns>
        public DataSet getArticleByCategory()
        {
            Tag tag = this.Document.CurrentRenderingTag;

            var attribute = tag.Attributes["rows"];
            var categoryid = tag.Attributes["categoryid"];
           // int category_id = MyCommFun.Obj2Int(categoryid.Text);
            int category_id = MyCommFun.Obj2Int(categoryid.Value.GetValue());

            int rows = -1;//若为-1，则不做限制条件
            if (attribute != null && MyCommFun.isNumber(attribute.Value.GetValue()))
            {
                rows = MyCommFun.Obj2Int(attribute.Value.GetValue());
            }

            DataSet ds = tDal.GetPc_Article(category_id, "", rows, " sort_id asc ");

            if (ds != null && ds.Tables.Count > 0)
            {
                DataRow dr;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dr = ds.Tables[0].Rows[i];

                    if (dr["link_url"] == null || dr["link_url"].ToString().Trim() == "")
                    {  //如果link_url为空，则直接调用本系统的信息
                        dr["link_url"] = "javascript:;";

                    }


                }
            }


            return ds;
        }




        /// <summary>
        /// 分类页面的url链接
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        private object GetNewsUrl(object[] news)
        {
            if (news.Length > 0 && news[0] != null)
            {
                string ret = "/list.aspx?cid=" + news[0].ToString();

                return ret;
            }
            else
            {
                return string.Empty;
            }
        }



        #endregion



    }
}
