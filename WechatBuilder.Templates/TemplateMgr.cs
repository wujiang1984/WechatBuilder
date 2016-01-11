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
    public class TemplateMgr
    {
        WechatBuilder.DAL.templatesDal tDal = new DAL.templatesDal();

        #region 属性
        protected internal string ccRight = "(c)2014 daniel 技术提供";
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
        /// 微帐号
        /// </summary>
        public int wid { get; set; }

        public string openid { get; set; }

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
        public TemplateMgr(string tPath, int wid)
        {
            this.Document = new TemplateDocument(tPath, Encoding.UTF8, this.DocumentConfig);
            this.wid = wid;

        }

        /// <summary>
        /// 输出最终的html
        /// </summary>
        /// <param name="templateFileName"></param>
        /// <param name="tPath"></param>
        /// <param name="wid"></param>
        public void OutPutHtml(string templateFileName, int wid)
        {
            //注册一个自定义函数
            this.Document.RegisterGlobalFunction(this.GetNewsUrl);

            //对VT模板里的config变量赋值 
            Model.wxcodeconfig wxconfig = tDal.GetModelByWid(wid, "/templates/index/" + templateFileName);

            //if (wxconfig == null || wxconfig.sitename.Trim() == "")
            //{
            //    HttpContext.Current.Response.Write("请填写【微网站设置】相关信息");

            //}
            //else
            //    if (wxconfig.wxstatus == 0)
            //{
            //    HttpContext.Current.Response.Write("帐号已过期！请及时充值！");
            //}
            this.Document.Variables.SetValue("config", wxconfig);
            //获得幻灯片列表方法一：缺点无法从模版页面控制记录数量
            this.Document.Variables.SetValue("photo", tDal.GetHDPByWid(wid, -1));

            this.Document.SetValue("wid", wid);

            this.Document.SetValue("bottomtype", "2");
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
                CategoryPage();
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
            int category_id = MyCommFun.RequestInt("cid");
            //--=====begin: 将这个列表（文章类别）的基本信息展示出来 ====--
            Model.article_category category = tDal.GetCategoryByWid(wid, category_id);
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
                artlist = artDal.GetList("news", category_id, pageSize, currPage, "wid=" + wid, orderby, out recordCount);
                if (artlist != null && artlist.Tables.Count > 0 && artlist.Tables[0].Rows.Count > 0)
                {
                    DataRow dr;
                    for (int i = 0; i < artlist.Tables[0].Rows.Count; i++)
                    {
                        dr = artlist.Tables[0].Rows[i];
                        if (dr["link_url"] != null && dr["link_url"].ToString().Trim().Length > 0)
                        {
                            dr["link_url"] = MyCommFun.urlAddOpenid(dr["link_url"].ToString().Trim(), openid);
                        }
                        else
                        {
                            dr["link_url"] = MyCommFun.urlAddOpenid("detail.aspx?wid=" + wid + "&aid=" + dr["id"].ToString(), openid);
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
                beforePageStr = "";
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
                nextPageStr = "";
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

        public void ArticleDetailPage()
        {
            DAL.article artDal = new DAL.article();
            int aid = MyCommFun.RequestInt("aid");
            Model.article article = artDal.GetModel(aid);
            if (article != null)
            {
                this.Document.SetValue("model", article);
            }
        }

        /// <summary>
        /// 频道，即二级分类
        /// </summary>
        public void CategoryPage()
        {

            int parentId = MyCommFun.RequestInt("cid");
            this.Document.SetValue("parentid", parentId);//父级id
            BLL.article_category cateBll = new BLL.article_category();
            Model.article_category pCategory = cateBll.GetModel(parentId);
            if (pCategory == null)
            {
                return;
            }
            this.Document.SetValue("pcategory", pCategory);//父级分类基本信息
            //去二级分类
            IList<Model.article_category> categorylist = tDal.GetCategoryListByWid(wid, -1, parentId, 2);
            if (categorylist != null && categorylist.Count > 0)
            {
                Model.article_category cat = new Model.article_category();
                for (int i = 0; i < categorylist.Count; i++)
                {
                    cat = categorylist[i];
                    if (cat.hasSun)
                    {  //有子分类
                        cat.link_url = MyCommFun.urlAddOpenid("/category.aspx?wid=" + wid + "&cid=" + cat.id, openid);
                    }
                    else
                    {
                        if (cat.link_url == null || cat.link_url.Trim() == "")
                        {  //如果link_url为空，则直接调用本系统的信息
                            cat.link_url = MyCommFun.urlAddOpenid("/list.aspx?wid=" + wid + "&cid=" + cat.id, openid);

                        }
                        else
                        {
                            cat.link_url = MyCommFun.urlAddOpenid(cat.link_url, openid);
                        }
                    }

                }

                this.Document.SetValue("clist", categorylist);//二级分类列表
            }

        }

        /// <summary>
        /// 获得幻灯片列表二：优点：（1）使用function标签与foreach结合，可以从模版页面控制记录数量；（2）不需要实现注册到模版里
        /// </summary>
        /// <returns></returns>
        public IList<Model.article> getHdp()
        {
            Tag tag = this.Document.CurrentRenderingTag;

            var attribute = tag.Attributes["rows"];
            IList<Model.article> artlist = new List<Model.article>();

            int rows = -1;//若为-1，则不做限制条件
            if (attribute != null && MyCommFun.isNumber(attribute.Value.GetValue()))
            {
                rows = MyCommFun.Obj2Int(attribute.Value.GetValue());
            }

            artlist = tDal.GetHDPByWid(wid, rows);

            if (artlist != null && artlist.Count > 0)
            {
                Model.article cat = new Model.article();
                for (int i = 0; i < artlist.Count; i++)
                {
                    cat = artlist[i];

                    if (cat.link_url == null || cat.link_url.Trim() == "")
                    {  //如果link_url为空，则直接调用本系统的信息
                        cat.link_url = "javascript:;";

                    }
                    else
                    {
                        cat.link_url = MyCommFun.urlAddOpenid(cat.link_url, openid);
                    }

                }
            }


            return artlist;
        }

        /// <summary>
        /// 获得wid的用户分类信息 
        /// </summary>
        /// <returns></returns>
        public IList<Model.article_category> getCategory()
        {
            Tag tag = this.Document.CurrentRenderingTag;

            ///classlayer表示取类别深度，如果为-1，则取所有分类的深度，如果为1，则取第一层目录，如果为2，则去第2层目录
            var classlayer = tag.Attributes["classlayer"];
            var parentidObj = tag.Attributes["parentid"];
            int parentid = -1;
            if (parentidObj != null && MyCommFun.isNumber(parentidObj.Value.GetValue()))
            {
                parentid = MyCommFun.Obj2Int(parentidObj.Value.GetValue());
            }
            int class_layer = -1;
            if (classlayer != null && MyCommFun.isNumber(classlayer.Value.GetValue()))
            {
                class_layer = MyCommFun.Obj2Int(classlayer.Value.GetValue());
            }

            IList<Model.article_category> categorylist = tDal.GetCategoryListByWid(wid, -1, parentid, class_layer);
            if (categorylist != null && categorylist.Count > 0)
            {
                Model.article_category cat = new Model.article_category();
                for (int i = 0; i < categorylist.Count; i++)
                {
                    cat = categorylist[i];
                    if (cat.hasSun)
                    {  //有子分类
                        cat.link_url = MyCommFun.urlAddOpenid("/category.aspx?wid=" + wid + "&cid=" + cat.id, openid);
                    }
                    else
                    {
                        if (cat.link_url == null || cat.link_url.Trim() == "")
                        {  //如果link_url为空，则直接调用本系统的信息
                            cat.link_url = MyCommFun.urlAddOpenid("/list.aspx?wid=" + wid + "&cid=" + cat.id, openid);

                        }
                        else if (!isContainsNoOpenid_hz(cat.link_url))
                        {
                            cat.link_url = MyCommFun.urlAddOpenid(cat.link_url, openid);
                        }
                    }
                }
            }

            return categorylist;
        }





        /// <summary>
        /// 获得底部菜单
        /// </summary>
        /// <returns></returns>
        public IList<Model.article_category> getBottomMenu()
        {
            string openid = MyCommFun.RequestOpenid();

            Tag tag = this.Document.CurrentRenderingTag;
            var classlayer = tag.Attributes["classlayer"];
            var parentidObj = tag.Attributes["parentid"];
            int parentid = -1;
            if (parentidObj != null && MyCommFun.isNumber(parentidObj.Value.GetValue()))
            {
                parentid = MyCommFun.Obj2Int(parentidObj.Value.GetValue());
            }
            int class_layer = -1;
            if (classlayer != null && MyCommFun.isNumber(classlayer.Value.GetValue()))
            {
                class_layer = MyCommFun.Obj2Int(classlayer.Value.GetValue());
            }

            IList<Model.article_category> bmenulist = tDal.GetBottomMenuByWid(wid, -1, parentid, class_layer);

            if (bmenulist != null && bmenulist.Count > 0)
            {
                Model.article_category cat = new Model.article_category();
                for (int i = 0; i < bmenulist.Count; i++)
                {
                    cat = bmenulist[i];
                    if (cat.link_url == null || cat.link_url.Trim() == "" || isContainsNoOpenid_hz(cat.link_url))
                    {
                    }
                    else
                    {
                        cat.link_url = MyCommFun.urlAddOpenid(cat.link_url, openid);
                    }
                }
            }


            return bmenulist;
        }


        /// <summary>
        /// 获得所有分类+底部菜单（排除url为空的）
        /// </summary>
        /// <returns></returns>
        public IList<Model.article_category> getAllCateMenu()
        {
            IList<Model.article_category> category = getCategory();
            IList<Model.article_category> bmenulist = tDal.GetBottomMenuByWid(wid, -1, -1, -1);
            if (bmenulist != null && bmenulist.Count > 0)
            {
                Model.article_category cat = new Model.article_category();
                for (int i = 0; i < bmenulist.Count; i++)
                {
                    cat = bmenulist[i];
                    if (cat.link_url != null && cat.link_url.Trim() != "")
                    {
                        cat.link_url = MyCommFun.urlAddOpenid(cat.link_url, openid);
                        category.Add(cat);
                    }
                }
            }
            return category;
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
                string ret = "/list.aspx?wid=" + wid + "&cid=" + news[0].ToString();
                if (openid != "")
                {
                    ret += "&openid=" + openid;
                }
                return ret;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 是否包含了不需要加后缀(openid)的
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private bool isContainsNoOpenid_hz(string url)
        {
            bool ret = false;
            if (string.IsNullOrEmpty(url))
            {
                return true;
            }
            if (url.Contains("tel:"))
            {
                ret = true;
            }
            else if (url.Contains("sms:"))
            {
                ret = true;
            }
            return ret;
        }


        #endregion


    }
}
