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
    public class ShopBasePage : System.Web.UI.Page
    {
         /// <summary>
        /// 模版的物理路径
        /// </summary>
        public string serverPath { get; set; }

        /// <summary>
        /// 模版的虚拟路径，比如/shop/templates/default
        /// </summary>
        public string tPath { get; set; }

        /// <summary>
        /// 模版文件名称
        /// </summary>
        public string templateFileName { get; set; }

        /// <summary>
        /// 微帐号wid
        /// </summary>
        public int wid { get; set; }
         
        /// <summary>
        /// 初始化模版的错误信息
        /// </summary>
        public string errInitTemplates { get; set; }

        public ShopBasePage()
        {
            serverPath = "";
            templateFileName = "";
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
