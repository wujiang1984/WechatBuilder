using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WechatBuilder.Web.weixin.message
{
    /// <summary>
    /// message 的摘要说明
    /// </summary>
    public class message : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            string _action = MyCommFun.QueryString("myact");
            string openid = MyCommFun.RequestOpenid();  //得到微信用户的openid
            Dictionary<string, string> jsonDict = new Dictionary<string, string>();

            //黑名单权限openid


            BLL.wx_message_blacklist blackBll = new BLL.wx_message_blacklist();

            if (_action == "commit")
            {
                //留言



                if (blackBll.ExistsByOpenid(openid))
                {
                    jsonDict.Add("ret", "fail");
                    jsonDict.Add("content", "留言失败");

                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));

                    return;
                }
                else
                {

                    int wid = MyCommFun.RequestInt("wid");
                    string nickname = MyCommFun.QueryString("nickname");
                    string info = MyCommFun.QueryString("info");
                    bool hasSH = Convert.ToBoolean(MyCommFun.QueryString("hasSH"));

                    BLL.wx_message_list mBll = new BLL.wx_message_list();
                    Model.wx_message_list message = new Model.wx_message_list();
                    message.wid = wid;
                    message.title = info;
                    message.userName = nickname;
                    message.createDate = DateTime.Now;
                    message.openId = openid;
                    message.parentId = 0;
                    if (hasSH)
                    {
                        message.hasSH = false;
                    }
                    else
                    {
                        message.hasSH = true;
                    }
                    mBll.Add(message);

                    //AddAdminLog(MXEnums.ActionEnum.Add.ToString(), ""); //记录日志


                    jsonDict.Add("ret", "ok");
                    jsonDict.Add("content", "留言成功");

                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));

                }
            }
            //回复
            if (_action == "setly")
            {
                if (blackBll.ExistsByOpenid(openid))
                {
                    jsonDict.Add("ret", "fail");
                    jsonDict.Add("content", "留言失败");

                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));

                    return;
                }
                else
                {

                    int wid = MyCommFun.RequestInt("wid");
                    string info = MyCommFun.QueryString("info");
                    bool hasSH = Convert.ToBoolean(MyCommFun.QueryString("hasSH"));
                    int parentid = MyCommFun.RequestInt("parentid");
                    string nickname = MyCommFun.QueryString("nickname");
                    BLL.wx_message_list mBll = new BLL.wx_message_list();
                    Model.wx_message_list message = new Model.wx_message_list();
                    message.wid = wid;
                    message.title = info;
                    message.userName = nickname;
                    message.createDate = DateTime.Now;
                    message.openId = openid;
                    message.parentId = parentid;

                    if (hasSH)
                    {
                        message.hasSH = false;
                    }
                    else
                    {
                        message.hasSH = true;
                    }
                    mBll.Add(message);

                    //AddAdminLog(MXEnums.ActionEnum.Add.ToString(), ""); //记录日志


                    jsonDict.Add("ret", "ok");
                    jsonDict.Add("content", "回复成功");

                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
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