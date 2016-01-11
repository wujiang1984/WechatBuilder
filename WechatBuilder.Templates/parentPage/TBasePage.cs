using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WechatBuilder.Templates
{
    public class TBasePage : System.Web.UI.Page
    {
        
        /// <summary>
        /// 模版的物理路径
        /// </summary>
        public string tPath { get; set; }
        
        /// <summary>
        /// 首页的模版文件名称
        /// </summary>
        public string templateIndexFileName { get; set; }
         
        /// <summary>
        /// 列表页面的模版文件名称
        /// </summary>
        public string templateListFileName { get; set; }
        

        /// <summary>
        /// 详情页面的模版文件名称
        /// </summary>
        public string templateDetailName { get; set; }
         
        /// <summary>
        /// 微帐号wid
        /// </summary>
        public int wid { get; set; }
         
        /// <summary>
        /// 初始化模版的错误信息
        /// </summary>
        public string errInitTemplates { get; set; }

        public TBasePage()
        {
            tPath = "";
            templateIndexFileName = "";
            templateListFileName = "";
            templateDetailName = "";
            errInitTemplates = "";

             wid =  MyCommFun.RequestInt("wid");
             if (wid == 0)
            {
                errInitTemplates = "链接地址或者参数错误！";
                return;
            }
          
        }
    }
}
