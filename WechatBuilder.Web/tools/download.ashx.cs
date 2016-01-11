using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Web;
using System.Web.SessionState;
using WechatBuilder.Web.UI;
using WechatBuilder.Common;

namespace WechatBuilder.Web.tools
{
    /// <summary>
    /// download 的摘要说明
    /// </summary>
    public class download : IHttpHandler, IRequiresSessionState
    {

        Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
        public void ProcessRequest(HttpContext context)
        {
            int id = MXRequest.GetQueryInt("id");
            //获得下载ID
            if (id < 1)
            {
                context.Response.Redirect(siteConfig.webpath + "error.aspx?msg=" + Utils.UrlEncode("出错啦，参数传值不正确哦！"));
                return;
            }
            //检查下载记录是否存在
            BLL.article_attach bll = new BLL.article_attach();
            if (!bll.Exists(id))
            {
                context.Response.Redirect(siteConfig.webpath + "error.aspx?msg=" + Utils.UrlEncode("出错啦，您要下载的文件不存在或已经被删除啦！"));
                return;
            }
            Model.article_attach model = bll.GetModel(id);
            //检查积分是否足够
            if (model.point > 0)
            {
                //检查用户是否登录
                Model.users userModel = new Web.UI.BasePage().GetUserInfo();
                if (userModel == null)
                {
                    //自动跳转URL
                    HttpContext.Current.Response.Redirect(new Web.UI.BasePage().linkurl("login"));
                }
                //防止重复扣积分
                string cookie = Utils.GetCookie(MXKeys.COOKIE_DOWNLOAD_KEY, "attach_" + userModel.id.ToString());
                if (cookie != model.id.ToString())
                {
                    //检查积分
                    if (model.point > userModel.point)
                    {
                        context.Response.Redirect(siteConfig.webpath + "error.aspx?msg=" + Utils.UrlEncode("出错啦，您的积分不足支付本次下载！"));
                        return;
                    }
                    //扣取积分
                    new BLL.user_point_log().Add(userModel.id, userModel.user_name, model.point * -1, "下载附件：“" + model.file_name + "”，扣减积分", false);
                    //写入Cookie
                    Utils.WriteCookie(MXKeys.COOKIE_DOWNLOAD_KEY, "attach_" + userModel.id.ToString(), model.id.ToString(), 8640);
                }
            }
            //下载次数+1
            bll.UpdateField(id, "down_num=down_num+1");
            //检查文件本地还是远程
            if (model.file_path.ToLower().StartsWith("http://"))
            {
                context.Response.Redirect(model.file_path);
                return;
            }
            else
            {
                //取得文件物理路径
                string fullFileName = Utils.GetMapPath(model.file_path);
                if (!File.Exists(fullFileName))
                {
                    context.Response.Redirect(siteConfig.webpath + "error.aspx?msg=" + Utils.UrlEncode("出错啦，您要下载的文件不存在或已经被删除啦！"));
                    return;
                }
                FileInfo file = new FileInfo(fullFileName);//路径
                context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8"); //解决中文乱码
                context.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(model.file_name)); //解决中文文件名乱码    
                context.Response.AddHeader("Content-length", file.Length.ToString());
                context.Response.ContentType = "application/pdf";
                context.Response.WriteFile(file.FullName);
                context.Response.End();
            }

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