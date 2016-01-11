using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WechatBuilder.Web.weixin.sjb
{
    /// <summary>
    /// jc 的摘要说明
    /// </summary>
    public class jc : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            string _action = MyCommFun.QueryString("myact");
            string openid = MyCommFun.RequestOpenid();  //得到微信用户的openid
            if (_action == "jingcai")
            {
                try
                {
                    #region 提交竞猜信息

                    int bisaiId = MyCommFun.RequestInt("bisaiId");//比赛表id
                    int jcRetType = MyCommFun.RequestInt("jcRetType");//选择类型
                    int wid = MyCommFun.RequestInt("wid");

                    if (wid == 0 || bisaiId == 0 || jcRetType == 0)
                    {
                        context.Response.Write("{\"msg\":\"提交出现异常！！\",\"success\":\"0\"}");
                        return;
                    }
                    BLL.wx_sjb_users uBll = new BLL.wx_sjb_users();
                    Model.wx_sjb_users user = new Model.wx_sjb_users();
                    int uid = 0;
                    if (!uBll.ExistsByOpenid(openid, wid))
                    {
                        //不存在
                        user.openid = openid;
                        user.wid = wid;
                        user.succTimes = 0;
                        user.failTimes = 0;
                        uid = uBll.Add(user);
                    }
                    else
                    {
                        //存在
                        user = uBll.GetModelList("openid='" + openid + "'")[0];
                        uid = user.id;
                    }


                    BLL.wx_sjb_jcDetail dBll = new BLL.wx_sjb_jcDetail();
                    Model.wx_sjb_jcDetail detail = new Model.wx_sjb_jcDetail();
                    detail.uid = uid;
                    detail.bsId = bisaiId;
                    detail.jcRetType = jcRetType;
                    detail.createDate = DateTime.Now;
                    dBll.Add(detail);

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