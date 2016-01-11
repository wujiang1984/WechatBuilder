using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Configuration;
using System.Xml;
using WechatBuilder.Common;

namespace WechatBuilder.Web.UI
{
    /// <summary>
    /// WechatBuilder的HttpModule类
    /// </summary>
    public class HttpModule : System.Web.IHttpModule
    {
        /// <summary>
        /// 实现接口的Init方法
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(ReUrl_BeginRequest);
        }

        /// <summary>
        /// 实现接口的Dispose方法
        /// </summary>
        public void Dispose()
        { }

        #region 页面请求事件处理================================================
        /// <summary>
        /// 页面请求事件处理
        /// </summary>
        /// <param name="sender">事件的源</param>
        /// <param name="e">包含事件数据的 EventArgs</param>
        private void ReUrl_BeginRequest(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            string requestDomain = context.Request.Url.Authority.ToLower(); //获得当前域名(含端口号)
            string requestPath = context.Request.Path.ToLower(); //获得当前页面(含目录)
            Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息

            //如果虚拟目录(不含安装目录)与站点根目录名相同则不需要重写
            if (IsDirExist(MXKeys.CACHE_SITE_DIRECTORY, siteConfig.webpath, siteConfig.webpath, requestPath))
            {
                return;
            }

            //检查网站重写状态0表示不开启重写、1开启重写、2生成静态
            if (siteConfig.staticstatus == 0)
            {
                #region 站点不开启重写处理方法=======================================
                ////遍历URL字典，匹配URL页面部分
                //foreach (Model.url_rewrite model in SiteUrls.GetSiteUrls().Urls)
                //{
                //    //查找到与页面部分匹配的节点
                //    if (model.page == requestPath.Substring(requestPath.LastIndexOf("/") + 1))
                //    {
                //        //如果该页面属于插件页则映射到插件目录，否则映射到频道分类目录
                //        if (model.type == MXKeys.DIRECTORY_REWRITE_PLUGIN)
                //        {
                //            context.RewritePath(string.Format("{0}{1}/{2}{3}", 
                //                siteConfig.webpath, MXKeys.DIRECTORY_REWRITE_ASPX, MXKeys.DIRECTORY_REWRITE_PLUGIN, requestPath));
                //            return;
                //        }
                //        else
                //        {
                //            ////默认的频道目录
                //            string defaultPath = SiteDomains.GetSiteDomains().DefaultPath;
                //            //获取绑定域名的频道分类目录
                //            string domainPath = GetDomainPath(siteConfig.webpath, requestPath, requestDomain);
                //            //获取虚拟目录的频道分类目录
                //            string categoryPath = GetCategoryPath(siteConfig.webpath, requestPath, requestDomain);
                //            if (domainPath != string.Empty)
                //            {
                //                defaultPath = domainPath;
                //            }
                //            else if (categoryPath != string.Empty)
                //            {
                //                defaultPath = categoryPath;
                //            }

                //            context.RewritePath(string.Format("{0}{1}/{2}{3}",
                //                siteConfig.webpath, MXKeys.DIRECTORY_REWRITE_ASPX, defaultPath, requestPath));
                //            return;
                //        }
                //    }
                //}
                #endregion
            }
            else
            {
                #region 站点开启重写或静态处理方法===================================
                ////默认的频道目录
                string defaultPath = SiteDomains.GetSiteDomains().DefaultPath;
                //获取绑定域名的频道分类目录
                string domainPath = GetDomainPath(siteConfig.webpath, requestPath, requestDomain);
                //获取虚拟目录的频道分类目录
                string categoryPath = GetCategoryPath(siteConfig.webpath, requestPath, requestDomain);

                //遍历URL字典
                foreach (Model.url_rewrite model in SiteUrls.GetSiteUrls().Urls)
                {
                    //如果没有重写表达式则不需要重写
                    if (model.url_rewrite_items.Count == 0 &&
                        Utils.GetUrlExtension(model.page, siteConfig.staticextension) == requestPath.Substring(requestPath.LastIndexOf("/") + 1))
                    {
                        //如果该页面属于插件页则映射到插件目录，否则映射到频道分类目录
                        if (model.type == MXKeys.DIRECTORY_REWRITE_PLUGIN)
                        {
                            context.RewritePath(string.Format("{0}{1}/{2}/{3}",
                                siteConfig.webpath, MXKeys.DIRECTORY_REWRITE_ASPX, MXKeys.DIRECTORY_REWRITE_PLUGIN, model.page));
                            return;
                        }
                        else
                        {
                            if (domainPath == string.Empty)
                            {
                                domainPath = SiteDomains.GetSiteDomains().DefaultPath; //默认的频道目录
                            }
                            context.RewritePath(string.Format("{0}{1}/{2}/{3}", siteConfig.webpath, MXKeys.DIRECTORY_REWRITE_ASPX, domainPath, model.page));
                            return;
                        }
                    }
                    //遍历URL字典的子节点
                    foreach (Model.url_rewrite_item item in model.url_rewrite_items)
                    {
                        if (domainPath != string.Empty)
                        {
                            defaultPath = domainPath; //如果是绑定的域名访问则将对应的目录赋值
                        }
                        else if (categoryPath != string.Empty)
                        {
                            defaultPath = categoryPath; //如果是虚拟目录访问则将对应的目录赋值
                        }
                        string patternPath = siteConfig.webpath;
                        if (domainPath == string.Empty && categoryPath != string.Empty)
                        {
                            patternPath += categoryPath + "/";
                        }
                        string newPattern = Utils.GetUrlExtension(item.pattern, siteConfig.staticextension); //替换扩展名

                        //如果与URL节点匹配则重写
                        if (Regex.IsMatch(requestPath, string.Format("^{0}{1}$", patternPath, newPattern), RegexOptions.None | RegexOptions.IgnoreCase)
                            || (model.page == "index.aspx" && Regex.IsMatch(requestPath, string.Format("^{0}{1}$", patternPath, item.pattern), RegexOptions.None | RegexOptions.IgnoreCase)))
                        {
                            //如果开启生成静态、不是手机网站且是频道页或首页,则映射重写到HTML目录
                            if (siteConfig.staticstatus == 2 && defaultPath != MXKeys.DIRECTORY_REWRITE_MOBILE && 
                                (model.channel.Length > 0 || model.page.ToLower() == "index.aspx")) //频道页
                            {
                                if (domainPath == string.Empty && categoryPath != string.Empty)
                                {
                                    context.RewritePath(siteConfig.webpath + MXKeys.DIRECTORY_REWRITE_HTML + Utils.GetUrlExtension(requestPath, siteConfig.staticextension, true));
                                }
                                else
                                {
                                    context.RewritePath(siteConfig.webpath + MXKeys.DIRECTORY_REWRITE_HTML + "/" + defaultPath + Utils.GetUrlExtension(requestPath, siteConfig.staticextension, true));
                                }
                                return;
                            }
                            else if (model.type == MXKeys.DIRECTORY_REWRITE_PLUGIN) //插件页
                            {
                                string queryString = Regex.Replace(requestPath, string.Format("{0}{1}",patternPath, newPattern), 
                                    item.querystring, RegexOptions.None | RegexOptions.IgnoreCase);
                                context.RewritePath(string.Format("{0}{1}/{2}/{3}", siteConfig.webpath, MXKeys.DIRECTORY_REWRITE_ASPX, MXKeys.DIRECTORY_REWRITE_PLUGIN, model.page), 
                                    string.Empty, queryString);
                                return;
                            }
                            else //其它
                            {
                                string queryString = Regex.Replace(requestPath, string.Format("{0}{1}", patternPath, newPattern),
                                    item.querystring, RegexOptions.None | RegexOptions.IgnoreCase);
                                context.RewritePath(string.Format("{0}{1}/{2}/{3}",
                                    siteConfig.webpath, MXKeys.DIRECTORY_REWRITE_ASPX, defaultPath, model.page), string.Empty, queryString);
                                return;
                            }

                        }
                    }
                }
                #endregion
            }
        }
        #endregion

        #region 辅助方法(私有)==================================================
        /// <summary>
        /// 获取URL的虚拟目录(除安装目录)
        /// </summary>
        /// <param name="webPath">网站安装目录</param>
        /// <param name="requestPath">当前页面，包含目录</param>
        /// <returns>String</returns>
        private string GetFirstPath(string webPath, string requestPath)
        {
            if (requestPath.StartsWith(webPath))
            {
                string tempStr = requestPath.Substring(webPath.Length);
                if (tempStr.IndexOf("/") > 0)
                {
                    return tempStr.Substring(0, tempStr.IndexOf("/")).ToLower();
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取绑定域名的频道分类目录名
        /// </summary>
        /// <param name="webPath">网站安装目录</param>
        /// <param name="requestPath">当前页面，包含目录</param>
        /// <param name="requestDomain">当前的域名(含端口号)</param>
        /// <returns>String</returns>
        private string GetDomainPath(string webPath, string requestPath, string requestDomain)
        {
            //获取绑定域名的目录
            if (SiteDomains.GetSiteDomains().CategoryDirs.ContainsValue(requestDomain))
            {
                return SiteDomains.GetSiteDomains().Domains[requestDomain];
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取虚拟目录的频道分类目录名
        /// </summary>
        /// <param name="webPath">网站安装目录</param>
        /// <param name="requestPath">当前页面，包含目录</param>
        /// <param name="requestDomain">当前的域名(含端口号)</param>
        /// <returns>String</returns>
        private string GetCategoryPath(string webPath, string requestPath, string requestDomain)
        {
            //获取URL的虚拟目录(除安装目录)
            string requestFirstPath = GetFirstPath(webPath, requestPath);
            if (requestFirstPath != string.Empty && SiteDomains.GetSiteDomains().CategoryDirs.ContainsKey(requestFirstPath))
            {
                return requestFirstPath;
            }
            return string.Empty;
        }

        /// <summary>
        /// 遍历指定路径的子目录，检查是否匹配
        /// </summary>
        /// <param name="cacheKey">缓存KEY</param>
        /// <param name="webPath">网站安装目录，以“/”结尾</param>
        /// <param name="dirPath">指定的路径，以“/”结尾</param>
        /// <param name="requestPath">获取的URL全路径</param>
        /// <returns>布尔值</returns>
        private bool IsDirExist(string cacheKey, string webPath, string dirPath, string requestPath)
        {
            ArrayList list = GetSiteDirs(cacheKey, dirPath); //取得所有目录
            string requestFirstPath = string.Empty; //获得当前页面除站点安装目录的虚拟目录名称
            string tempStr = string.Empty; //临时变量
            if (requestPath.StartsWith(webPath))
            {
                tempStr = requestPath.Substring(webPath.Length);
                if (tempStr.IndexOf("/") > 0)
                {
                    requestFirstPath = tempStr.Substring(0, tempStr.IndexOf("/"));
                }
            }
            if (requestFirstPath.Length > 0 && list.Contains(requestFirstPath.ToLower()))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 遍历指定路径目录，如果缓存存在则直接返回
        /// </summary>
        /// <param name="cacheKey">缓存KEY</param>
        /// <param name="dirPath">指定路径</param>
        /// <returns>ArrayList</returns>
        private ArrayList GetSiteDirs(string cacheKey, string dirPath)
        {
            ArrayList _cache = CacheHelper.Get<ArrayList>(cacheKey); //从续存中取
            if (_cache == null)
            {
                _cache = new ArrayList();
                DirectoryInfo dirInfo = new DirectoryInfo(Utils.GetMapPath(dirPath));
                foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                {
                    _cache.Add(dir.Name.ToLower());
                }
                CacheHelper.Insert(cacheKey, _cache, 2); //存入续存，弹性2分钟
            }
            return _cache;
        }

        #endregion

    }

    #region 站点URL字典信息类===================================================
    /// <summary>
    /// 站点伪Url信息类
    /// </summary>
    public class SiteUrls
    {
        //属性声明
        private static object lockHelper = new object();
        private static volatile SiteUrls instance = null;
        private ArrayList _urls;
        public ArrayList Urls
        {
            get { return _urls; }
            set { _urls = value; }
        }
        //构造函数
        private SiteUrls()
        {
            Urls = new ArrayList();
            BLL.url_rewrite bll = new BLL.url_rewrite();
            List<Model.url_rewrite> ls = bll.GetList("");
            foreach(Model.url_rewrite model in ls)
            {
                foreach (Model.url_rewrite_item item in model.url_rewrite_items)
                {
                    item.querystring = item.querystring.Replace("^", "&");
                }
                Urls.Add(model);
            }
        }
        //返回URL字典
        public static SiteUrls GetSiteUrls()
        {
            SiteUrls _cache = CacheHelper.Get<SiteUrls>(MXKeys.CACHE_SITE_HTTP_MODULE);
            lock (lockHelper)
            {
                if (_cache == null)
                {
                    CacheHelper.Insert(MXKeys.CACHE_SITE_HTTP_MODULE, new SiteUrls(), Utils.GetXmlMapPath(MXKeys.FILE_URL_XML_CONFING));
                    instance = CacheHelper.Get<SiteUrls>(MXKeys.CACHE_SITE_HTTP_MODULE);
                }
            }
            return instance;
        }

    }
    #endregion

    #region 站点绑定域名信息类==================================================
    /// <summary>
    /// 域名字典
    /// </summary>
    public class SiteDomains
    {
        private static object lockHelper = new object();
        private static volatile SiteDomains instance = null;
        //默认目录
        private string _default_path = string.Empty;
        public string DefaultPath
        {
            get { return _default_path; }
            set { _default_path = value; }
        }
        //频道分类列表
        private Dictionary<string, string> _category_dirs;
        public Dictionary<string, string> CategoryDirs
        {
            get { return _category_dirs; }
            set { _category_dirs = value; }
        }
        //绑定的域名列表
        private Dictionary<string, string> _domains;
        public Dictionary<string, string> Domains
        {
            get { return _domains; }
            set { _domains = value; }
        }
        //构造函数
        public SiteDomains()
        {
            DefaultPath = new BLL.channel_category().GetDefaultPath(); //默认目录
            CategoryDirs = new BLL.channel_category().GetCategoryDirs(); //分类目录
            Domains = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> kvp in CategoryDirs)
            {
                if (kvp.Value.Length > 0 && !Domains.ContainsKey(kvp.Value))
                {
                    Domains.Add(kvp.Value, kvp.Key);
                }
            }
        }
        /// <summary>
        /// 返回域名字典
        /// </summary>
        public static SiteDomains GetSiteDomains()
        {
            SiteDomains _cache = CacheHelper.Get<SiteDomains>(MXKeys.CACHE_SITE_HTTP_DOMAIN);
            lock (lockHelper)
            {
                if (_cache == null)
                {
                    CacheHelper.Insert(MXKeys.CACHE_SITE_HTTP_DOMAIN, new SiteDomains(), 10);
                    instance = CacheHelper.Get<SiteDomains>(MXKeys.CACHE_SITE_HTTP_DOMAIN);
                }
            }
            return instance;
        }
    }
    #endregion
}