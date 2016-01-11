using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WechatBuilder.Web.weixin.vote
{
    /// <summary>
    /// vote 的摘要说明
    /// </summary>
    public class vote : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            string _action = MyCommFun.QueryString("myact");
            string openid = MyCommFun.RequestOpenid();  //得到微信用户的openid
            Dictionary<string, string> jsonDict = new Dictionary<string, string>();

            if (_action == "commit")
            { //提交投票
                int wid = MyCommFun.RequestInt("wid");
                int baseid = MyCommFun.RequestInt("baseid");
                string itemid = MyCommFun.QueryString("itemid");

                BLL.wx_vote_result resultBll = new BLL.wx_vote_result();
                Model.wx_vote_result result = new Model.wx_vote_result();
                BLL.wx_vote_item iBll = new BLL.wx_vote_item();

                if (MyCommFun.QueryString("isradio") == "true")
                {
                    result.baseid = baseid;
                    result.itemid = Convert.ToInt32(itemid);
                    result.openId = openid;
                    result.createDate = DateTime.Now;
                    resultBll.Add(result);
                    iBll.Update(result.itemid.Value, result.baseid.Value);
                }
                else
                {

                    string[] sArray = itemid.Split(',');
                    for (int i = 0; i < sArray.Length;i++ )
                    {
                        result.baseid = baseid;
                        result.itemid = Convert.ToInt32(sArray[i]);
                        result.openId = openid;
                        result.createDate = DateTime.Now;
                        resultBll.Add(result);
                        iBll.Update(result.itemid.Value, result.baseid.Value);
                    }

                }

                //AddAdminLog(MXEnums.ActionEnum.Add.ToString(), ""); //记录日志


                jsonDict.Add("ret", "ok");
                jsonDict.Add("content", "投票成功");

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