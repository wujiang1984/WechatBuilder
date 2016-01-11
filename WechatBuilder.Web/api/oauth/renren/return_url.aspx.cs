using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.API.OAuth;
using WechatBuilder.Common;
using LitJson;

namespace WechatBuilder.Web.api.oauth.renren
{
    public partial class return_url : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //取得返回参数
            string state = MXRequest.GetQueryString("state");
            string code = MXRequest.GetQueryString("code");

            string access_token = string.Empty;
            string expires_in = string.Empty;
            string openid = string.Empty;

            if (Session["oauth_state"] == null || Session["oauth_state"].ToString() == "" || state != Session["oauth_state"].ToString())
            {
                Response.Write("出错啦，state未初始化！");
                return;
            }
            if (string.IsNullOrEmpty(code))
            {
                Response.Write("授权被取消，相关信息：" + MXRequest.GetQueryString("error"));
                return;
            }
            
            //获取Access Token
            JsonData jd = renren_helper.get_access_token(code);
            if (jd == null)
            {
                Response.Write("错误代码：，无法获取Access Token，请检查App Key是否正确！");
            }

            access_token = jd["access_token"].ToString();
            expires_in = jd["expires_in"].ToString();
            openid = jd["user"]["id"].ToString();
            //储存获取数据用到的信息
            Session["oauth_name"] = "renren";
            Session["oauth_access_token"] = access_token;
            Session["oauth_openid"] = openid;

            //跳转到指定页面
            Response.Redirect(new Web.UI.BasePage().linkurl("oauth_login"));
            return;

        }
    }
}