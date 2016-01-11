using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Web.Caching;
using WechatBuilder.Common;

namespace WechatBuilder.BLL
{
    public partial class siteconfig
    {
        private readonly DAL.siteconfig dal = new DAL.siteconfig();

        /// <summary>
        ///  读取配置文件
        /// </summary>
        public Model.siteconfig loadConfig()
        {
            Model.siteconfig model = CacheHelper.Get<Model.siteconfig>(MXKeys.CACHE_SITE_CONFIG);
            if (model == null)
            {
                CacheHelper.Insert(MXKeys.CACHE_SITE_CONFIG, dal.loadConfig(Utils.GetXmlMapPath(MXKeys.FILE_SITE_XML_CONFING)),
                    Utils.GetXmlMapPath(MXKeys.FILE_SITE_XML_CONFING));
                model = CacheHelper.Get<Model.siteconfig>(MXKeys.CACHE_SITE_CONFIG);
            }
            return model;
        }

        /// <summary>
        ///  保存配置文件
        /// </summary>
        public Model.siteconfig saveConifg(Model.siteconfig model)
        {
            return dal.saveConifg(model, Utils.GetXmlMapPath(MXKeys.FILE_SITE_XML_CONFING));
        }

    }
}
