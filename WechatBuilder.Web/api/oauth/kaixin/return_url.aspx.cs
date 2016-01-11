using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.API.OAuth;
using WechatBuilder.Common;
using LitJson;

namespace WechatBuilder.Web.api.oauth.kaixin
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
            string client_id = string.Empty;
            string openid = string.Empty;

            if (Session["oauth_state"] == null || Session["oauth_state"].ToString() == "" || state != Session["oauth_state"].ToString())
            {
                Response.Write("出错啦，state未初始化！");
                return;
            }
            
            //第一步：获取Access Token
            JsonData jd = kaixin_helper.get_access_token(code, state);
            if (jd == null)
            {
                Response.Write("出错了，无法获取Access Token，请检查App Key是否正确！");
                return;
            }
            access_token = jd["access_token"].ToString();
            expires_in = jd["expires_in"].ToString();

            //第二步：通过Access Token来获取用户的ID
            JsonData jd2 = kaixin_helper.get_info(access_token, "uid");
            if (jd2 == null)
            {
                Response.Write("出错啦，无法获取用户授权uid！");
                return;
            }
            openid = jd2["uid"].ToString();
            //储存获取数据用到的信息
            Session["oauth_name"] = "kaixin";
            Session["oauth_access_token"] = access_token;
            Session["oauth_openid"] = openid;

            //第三步：跳转到指定页面
            Response.Redirect(new Web.UI.BasePage().linkurl("oauth_login"));
            return;

        }
    }
}