using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WechatBuilder.Web.weixin.ggk
{
    /// <summary>
    /// ggkAct 的摘要说明
    /// </summary>
    public class ggkAct : IHttpHandler
    {

        
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            string _action = MyCommFun.QueryString("myact");
            string openid = MyCommFun.RequestOpenid();  //得到微信用户的openid
            if (_action == "update")
            {
                try
                {
                    #region 提交手机
                    /// 提交手机号码
                   string  tel = MyCommFun.QueryString("tel");
                    string pwd = MyCommFun.QueryString("pwd");
                    string  snumber = MyCommFun.QueryString("snumber");
                    int  id = MyCommFun.RequestInt("id");
                    int aid = MyCommFun.RequestInt("aid");
                    if (aid==0 || id == 0 || snumber == "" || tel == "")
                    {
                        context.Response.Write("{\"msg\":\"提交出现异常！！\",\"success\":\"0\"}");
                        return;
                    }
                    BLL.wx_ggkActionInfo actBll = new BLL.wx_ggkActionInfo();
                    if (pwd.Trim().Length>0 &&(!actBll.ExistsPwd(aid, pwd)))
                    {
                        context.Response.Write("{\"msg\":\"商家兑换密码错误！！\",\"success\":\"0\"}");
                        return;
                    }


                    BLL.wx_ggkAwardUser ubll = new BLL.wx_ggkAwardUser();
                    Model.wx_ggkAwardUser model = ubll.GetModel(id);
                    if (model == null)
                    {
                        context.Response.Write("{\"msg\":\"提交出现异常2！！\",\"success\":\"0\"}");
                        return;
                    }
                    model.uTel = tel;
                    if (pwd.Trim().Length > 0)
                    {
                        model.hasLingQu = true;
                    }
                    else
                    {
                        model.hasLingQu = false;
                    }
                    ubll.Update(model);

                    context.Response.Write("{\"msg\":\"提交成功！\",\"success\":\"1\"}");
                    return;
                    #endregion

                }
                catch
                {
                    context.Response.Write("{\"msg\":\"提交出现异常！！\",\"success\":\"0\"}");

                    return;
                }

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