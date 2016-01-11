using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WechatBuilder.Common;

namespace WechatBuilder.Web.weixin.xitie
{
    /// <summary>
    /// xitie 的摘要说明
    /// </summary>
    public class xitie : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            string openid = MyCommFun.QueryString("openid");//openid
            int bid = MyCommFun.RequestInt("id");
            string tel = MyCommFun.QueryString("telephone");
            string name = MyCommFun.QueryString("userName");

            string type = MyCommFun.QueryString("type");
            Dictionary<string, string> jsonDict = new Dictionary<string, string>();

            if (type == "bm")
            {
                int renshu = MyCommFun.RequestInt("count");
                //报名参与婚礼
                BLL.wx_xt_user ubll = new BLL.wx_xt_user();
                Model.wx_xt_user user = new Model.wx_xt_user();
                user.bId = bid;
                user.openid = openid;
                user.phone = tel;
                user.uName = name;
                user.pNum = renshu;
                user.createDate = DateTime.Now;
                int ret = ubll.Add(user);
                if (ret > 0)
                {
                    jsonDict.Add("ret", "报名成功！");
                }
                else
                {
                    jsonDict.Add("ret", "报名失败，请重新报名！");
                }

                context.Response.Write(MyCommFun.getJsonStr(jsonDict));
            }
            else if (type == "zf")
            {
                string content = MyCommFun.QueryString("content");

                //祝福语
                 BLL.wx_xt_zhufu zbll = new BLL.wx_xt_zhufu();
                 Model.wx_xt_zhufu zf = new Model.wx_xt_zhufu();
                zf.message = content;
                zf.openid = openid;
                zf.phone = tel;
                zf.uName = name;
                zf.createDate = DateTime.Now;
                zf.bId = bid;

                int ret = zbll.Add(zf);
                if (ret > 0)
                {
                    jsonDict.Add("ret", "评论成功！");
                }
                else
                {
                    jsonDict.Add("ret", "评论失败，请重新评论！");
                }

                context.Response.Write(MyCommFun.getJsonStr(jsonDict));
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