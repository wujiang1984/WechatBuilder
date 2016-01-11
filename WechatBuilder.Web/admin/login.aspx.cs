using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using System.Security.Cryptography;
using System.Text;

namespace WechatBuilder.Web.admin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                #region 测试
                //string test = DESEncrypt.Decrypt("785528A58C55A6F7D9669B9534635E6070A99BE42E445E552F9F66FAA55F9FB376357C467EBF7F7E3B3FC77F37866FEFB0237D95CCCE157A", "Key");
                //string keys = "http://www.yubom.net/upgrade.ashx?u={0}&i={1}&v={2}";
                //string keysJM = DESEncrypt.Encrypt(keys, "Key");
                //string test = DESEncrypt.Decrypt(DTKeys.FILE_URL_UPGRADE_CODE, "DT");
                //string test2 = DESEncrypt.Decrypt(DTKeys.FILE_URL_NOTICE_CODE, "DT");
                //string sj = "http://www.yubom.net/upgrade.ashx?t=1";
                //string notice = "http://www.yubom.net/upgrade.ashx?t=2";
                //string sjJM = DESEncrypt.Encrypt(sj);
                //string noticeJM = DESEncrypt.Encrypt(notice);
                #endregion

                txtUserName.Text = Utils.GetCookie("DTRememberName");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string userPwd = txtPassword.Text.Trim();

            if (userName.Equals("") || userPwd.Equals(""))
            {
                msgtip.InnerHtml = "请输入用户名或密码";
                return;
            }
            if (Session["AdminLoginSun"] == null)
            {
                Session["AdminLoginSun"] = 1;
            }
            else
            {
                Session["AdminLoginSun"] = Convert.ToInt32(Session["AdminLoginSun"]) + 1;
            }
            //判断登录错误次数
            if (Session["AdminLoginSun"] != null && Convert.ToInt32(Session["AdminLoginSun"]) > 5)
            {
                msgtip.InnerHtml = "错误超过5次，关闭浏览器重新登录！";
                return;
            }
            BLL.manager bll = new BLL.manager();
            
            Model.manager model = bll.GetModel(userName, userPwd, true);
            if (model == null)
            {
                msgtip.InnerHtml = "用户名或密码有误，请重试！";
                return;
            }
            // 保存当前的后台管理员
            Session[MXKeys.SESSION_ADMIN_INFO] = model;
            Session.Timeout = 45;
            //写入登录日志
            Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
            if (siteConfig.logstatus > 0)
            {
                new BLL.manager_log().Add(model.id, model.user_name, MXEnums.ActionEnum.Login.ToString(), "用户登录");
            }
            //写入Cookies
            Utils.WriteCookie("DTRememberName", model.user_name, 14400);
            Utils.WriteCookie("AdminName", "WechatBuilder", model.user_name);
            Utils.WriteCookie("AdminPwd", "WechatBuilder", model.password);
            Response.Redirect("wxIndex.aspx");
            return;
        }

    }
}