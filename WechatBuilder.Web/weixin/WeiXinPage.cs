using WechatBuilder.BLL;
using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WechatBuilder.Web.weixin
{
    public class WeiXinPage : System.Web.UI.Page
    {
        public string mywebSite = MyCommFun.getWebSite();
        /// <summary>
        /// 只允许微信里访问
        /// </summary>
        /// <param name="flg"></param>
        public void OnlyWeiXinLook()
        {

            string value = BLL.wx_sysConfig.GetConfigValue("onlyweixinlook");
            if (value.ToLower() == "true")
            {
                String userAgent = Request.UserAgent;
                if (userAgent.IndexOf("MicroMessenger") <= -1)
                {
                    Response.Write("请在微信浏览器里访问");
                    Response.End();

                }
            }

        
        }

        public Model.wxcodeconfig getwebsiteinfo(int wid)
        {
            wsiteBll wBll = new wsiteBll();
            return wBll.GetModelByWid(wid, "");
        }

        /// <summary>
        /// 获得版权信息
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        public string getwebcopyright(int wid)
        {
            wsiteBll wBll = new wsiteBll();
            Model.wxcodeconfig config= wBll.GetModelByWid(wid, "");
            if (config != null)
            {
                return config.wcopyright;
            }
            else
            {
                return "";
            }


        }
    }
}