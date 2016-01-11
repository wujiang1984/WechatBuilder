using System;
using System.Text;
using System.Collections.Generic;
using System.Web.SessionState;
using System.Web;
using WechatBuilder.Common;

namespace WechatBuilder.Web.tools
{
    /// <summary>
    /// 检测浏览器
    /// </summary>
    public class browser_redirect : IHttpHandler, IRequiresSessionState
    {
        Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
        public void ProcessRequest(HttpContext context)
        {
            //检查是否开启手机网站，如果没有不检测
            if (siteConfig.mobilestatus == 0)
            {
                return;
            }

            StringBuilder str = new StringBuilder();
            //读Cookie的涵数
            str.Append("function getMCookie(objName){");
            str.Append("var arrStr=document.cookie.split(\"; \");");
            str.Append("for(var i=0;i<arrStr.length;i++){");
            str.Append("var temp=arrStr[i].split(\"=\");");
            str.Append("if(temp[0]==objName){return unescape(temp[1]);}");
            str.Append("}");
            str.Append("return \"\";");
            str.Append("}");
            //检测是否移动设备访问做跳转函数
            str.Append("function browserRedirect(){");
            str.Append("var sUserAgent=navigator.userAgent.toLowerCase();");
            str.Append("var bIsIpad=sUserAgent.match(/ipad/i)==\"ipad\";");
            str.Append("var bIsIphoneOs=sUserAgent.match(/iphone os/i)==\"iphone os\";");
            str.Append("var bIsMidp=sUserAgent.match(/midp/i)==\"midp\";");
            str.Append("var bIsUc7=sUserAgent.match(/rv:1.2.3.4/i)==\"rv:1.2.3.4\";");
            str.Append("var bIsUc=sUserAgent.match(/ucweb/i)==\"ucweb\";");
            str.Append("var bIsAndroid=sUserAgent.match(/android/i)==\"android\";");
            str.Append("var bIsCE=sUserAgent.match(/windows ce/i)==\"windows ce\";");
            str.Append("var bIsWM=sUserAgent.match(/windows mobile/i)==\"windows mobile\";");
            str.Append("if (bIsIpad || bIsIphoneOs || bIsMidp || bIsUc7 || bIsUc || bIsAndroid || bIsCE || bIsWM){");
            if (siteConfig.mobiledomain != "")
            {
                str.Append("location.href='http://" + siteConfig.mobiledomain + "';");
            }
            else
            {
                str.Append("location.href='" + siteConfig.webpath + "mobile/index.aspx';");
            }
            str.Append("}");
            str.Append("}");
            //检查当前URL是否带有m2w参数，有则说明从移动设备链接过来的
            str.Append("var pageurl=window.location.search;");
            str.Append("if(pageurl=='?m2w'){");
            str.Append("document.cookie=\"m2wcookie=\" + escape(\"1\");");
            str.Append("}");
            str.Append("if(getMCookie(\"m2wcookie\")!=\"1\") browserRedirect();");

            context.Response.Write(str.ToString());
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}