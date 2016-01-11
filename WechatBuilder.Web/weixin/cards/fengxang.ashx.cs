using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WechatBuilder.Web.weixin.cards
{
    /// <summary>
    /// fengxang 的摘要说明
    /// </summary>
    public class fengxang : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
           context.Response.ContentType = "text/json";
            string _action = MyCommFun.QueryString("myact");
            int id = MyCommFun.RequestInt("id");
            string openid = MyCommFun.RequestOpenid();  //得到微信用户的openid
            if (_action == "zf")
            {
                  
                //转发
                Dictionary<string, string> jsonDict = new Dictionary<string, string>();

                BLL.wx_cards_gl countgbll = new BLL.wx_cards_gl();
                Model.wx_cards_gl cardscountg = new Model.wx_cards_gl();
                BLL.wx_cards gbll = new BLL.wx_cards();

                gbll.update(id);
                //转发记录
                cardscountg.cardsid = id;
                cardscountg.openid = MyCommFun.QueryString("openid");
                countgbll.Add(cardscountg);

                jsonDict.Add("error", "ok");
                jsonDict.Add("content", "ok");
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