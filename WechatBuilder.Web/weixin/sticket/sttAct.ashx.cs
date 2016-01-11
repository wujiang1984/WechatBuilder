using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WechatBuilder.Web.weixin.sticket
{
    /// <summary>
    /// sttAct 的摘要说明
    /// </summary>
    public class sttAct : IHttpHandler
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
                    string tel = MyCommFun.QueryString("tel");
                    string pwd = MyCommFun.QueryString("pwd");
                    string snumber = MyCommFun.QueryString("snumber");
                    int id = MyCommFun.RequestInt("id");
                    int aid = MyCommFun.RequestInt("aid");
                    if (aid == 0 || id == 0 || snumber == "" || tel == "" || pwd == "")
                    {
                        context.Response.Write("{\"msg\":\"提交出现异常！！\",\"success\":\"0\"}");
                        return;
                    }
                    BLL.wx_sTicket actBll = new BLL.wx_sTicket();
                    if (!actBll.ExistsPwd(aid, pwd))
                    {
                        context.Response.Write("{\"msg\":\"商家兑换密码错误！！\",\"success\":\"0\"}");
                        return;
                    }


                    BLL.wx_sttAwardUser ubll = new BLL.wx_sttAwardUser();
                    Model.wx_sttAwardUser model = ubll.GetModel(id);
                    if (model == null)
                    {
                        context.Response.Write("{\"msg\":\"提交出现异常2！！\",\"success\":\"0\"}");
                        return;
                    }
                    model.uTel = tel;
                    model.hasLingQu = true;
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