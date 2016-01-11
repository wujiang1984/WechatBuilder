using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.API.OAuth;
using WechatBuilder.Common;
using LitJson;

namespace WechatBuilder.Web.api.oauth.taobao
{
    public partial class result_json : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string oauth_access_token = string.Empty;
            string oauth_openid = string.Empty;
            string oauth_name = string.Empty;

            if (Session["oauth_name"] == null || Session["oauth_access_token"] == null || Session["oauth_openid"] == null)
            {
                Response.Write("{\"ret\":\"1\", \"msg\":\"出错啦，Access Token已过期或不存在！\"}");
                return;
            }
            oauth_name = Session["oauth_name"].ToString();
            oauth_access_token = Session["oauth_access_token"].ToString();
            oauth_openid = Session["oauth_openid"].ToString();
            JsonData jd1 = taobao_helper.get_info(oauth_access_token, "user_id,nick,avatar,sex");
            if (jd1 == null)
            {
                Response.Write("{\"ret\":\"1\", \"msg\":\"出错啦，无法获取授权用户信息！\"}");
                return;
            }
            JsonData jd = jd1[0][0];

            StringBuilder str = new StringBuilder();
            str.Append("{");
            str.Append("\"ret\": \"0\", ");
            str.Append("\"msg\": \"获得用户信息成功！\", ");
            str.Append("\"oauth_name\": \"" + oauth_name + "\", ");
            str.Append("\"oauth_access_token\": \"" + oauth_access_token + "\", ");
            str.Append("\"oauth_openid\": \"" + jd["user_id"].ToString() + "\", ");
            str.Append("\"nick\": \"" + jd["nick"].ToString() + "\", ");
            str.Append("\"avatar\": \"" + jd["avatar"].ToString() + "\", ");
            if (jd["sex"].ToString() == "m")
            {
                str.Append("\"sex\": \"男\", ");
            }
            else if (jd["sex"].ToString() == "f")
            {
                str.Append("\"sex\": \"女\", ");
            }
            else
            {
                str.Append("\"sex\": \"保密\", ");
            }
            str.Append("\"birthday\": \"\"");
            str.Append("}");

            Response.Write(str.ToString());
            return;
        }
    }
}