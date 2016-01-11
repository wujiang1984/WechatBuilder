using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web.Configuration;
using Senparc.Weixin.MP.Agent;
using Senparc.Weixin.MP.Context;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.MessageHandlers;
using Senparc.Weixin.MP.Helpers;
using System.Xml;
using System.Xml.Linq;
using WechatBuilder.DAL;
using WechatBuilder.Common;

namespace WechatBuilder.WeiXinComm.CustomMessageHandler
{
    public partial class CustomMessageHandler
    {
        /// <summary>
        ///  处理文字请求 autor:lipu
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        {
            IResponseMessageBase IR = null;
            int apiid = 0;
            try
            {

              //  var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
                string keywords = requestMessage.Content; //发送了文字信息
                apiid = wxcomm.getApiid();//这里的appiid即为微帐号主键Id(wid)

                if (!wxcomm.ExistApiidAndWxId(apiid, requestMessage.ToUserName))
                {  //验证接收方是否为我们系统配置的帐号，即验证微帐号与微信原始帐号id是否一致，如果不一致，说明【1】配置错误，【2】数据来源有问题
                    wxResponseBaseMgr.Add(apiid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "none", "验证微帐号与微信原始帐号id不一致，说明【1】配置错误，【2】数据来源有问题", requestMessage.ToUserName);
                    return wxcomm.GetResponseMessageTxtByContent(requestMessage, "验证微帐号与微信原始帐号id不一致，可能原因【1】系统配置错误，【2】非法的数据来源", apiid);
                }

                int responseType = 0;
                string modelFunctionName = "";
                int  modelFunctionId = 0;
                int ruleId = rBll.GetRuleIdByKeyWords(apiid, keywords, out responseType, out modelFunctionName, out modelFunctionId);
                if (ruleId <= 0 || responseType<=0)
                {
                    // 2014-9-18 暂时性功能 针对ID为 gh_04bf23f25940的平台客户 保存发送者的ID 及 生成抽奖序号 并保存。
                    //if (requestMessage.ToUserName == "gh_04bf23f25940" && requestMessage.Content = "橘州抽奖")
                    //{}
                    //else
                    //{
                        // 2014-9-18原功能
                    wxResponseBaseMgr.Add(apiid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "none", "未取到关键词对应的数据", requestMessage.ToUserName);
                    return  wxcomm.GetResponseMessageTxtByContent(requestMessage,"未找到匹配的关键词",apiid);
                    //}
                }
                if (modelFunctionId > 0)
                {  //模块功能回复
                    return wxcomm.GetModuleResponse(requestMessage, modelFunctionName, modelFunctionId, apiid);
                }
                switch (responseType)
                {
                    case 1:
                        //发送纯文字
                        IR = wxcomm.GetResponseMessageTxt(requestMessage, ruleId, apiid);
                        break;
                    case 2:
                        //发送多图文
                        IR = wxcomm.GetResponseMessageNews(requestMessage, ruleId, apiid);
                        break;
                    case 3:
                        //发送语音
                        IR = wxcomm.GetResponseMessageeMusic(requestMessage, ruleId, apiid);
                        break;
                    default:
                        break;
                }
               //  wxRequestBaseMgr.Add(apiid, requestMessage.MsgType.ToString(), requestMessage.FromUserName, requestMessage.CreateTime.ToString(), requestMessage.Content, requestMessage.ToString());

            }
            catch (Exception ex)
            {
                BLL.wx_logs logs = new BLL.wx_logs();
                logs.AddErrLog(apiid, "用户请求文字", "CustomMessageHandler.OnTextRequest", "错误："+ex.Message);
                
            }

            return IR;
        }



        //public override IResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        //{
        //    //TODO:这里的逻辑可以交给Service处理具体信息，参考OnLocationRequest方法或/Service/LocationSercice.cs

        //    //方法一（v0.1），此方法调用太过繁琐，已过时（但仍是所有方法的核心基础），建议使用方法二到四
        //    //var responseMessage =
        //    //    ResponseMessageBase.CreateFromRequestMessage(RequestMessage, ResponseMsgType.Text) as
        //    //    ResponseMessageText;

        //    //方法二（v0.4）
        //    //var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(RequestMessage);

        //    //方法三（v0.4），扩展方法，需要using Senparc.Weixin.MP.Helpers;
        //    //var responseMessage = RequestMessage.CreateResponseMessage<ResponseMessageText>();

        //    //方法四（v0.6+），仅适合在HandlerMessage内部使用，本质上是对方法三的封装
        //    //注意：下面泛型ResponseMessageText即返回给客户端的类型，可以根据自己的需要填写ResponseMessageNews等不同类型。
        //    var responseMessage = base.CreateResponseMessage<ResponseMessageText>();

        //    if (requestMessage.Content == "约束")
        //    {
        //        responseMessage.Content = "<a href=\"http://weixin.senparc.com/FilterTest/\">点击这里</a>进行客户端约束测试（地址：http://weixin.senparc.com/FilterTest/）。";
        //    }
        //    if (requestMessage.Content == "托管" || requestMessage.Content == "代理")
        //    {
        //        //开始用代理托管，把请求转到其他服务器上去，然后拿回结果
        //        //甚至也可以将所有请求在DefaultResponseMessage()中托管到外部。

        //        DateTime dt1 = DateTime.Now;//计时开始

        //        var responseXml = MessageAgent.RequestXml(this, agentUrl, agentToken, RequestDocument.ToString());//获取返回的XML
        //        //上面的方法也可以使用扩展方法：this.RequestResponseMessage(this,agentUrl, agentToken, RequestDocument.ToString());

        //        /* 如果有SouideaKey，可以直接使用下面的这个MessageAgent.RequestSouideaXml()方法。
        //         * SouideaKey专门用于对接www.souidea.com平台，获取方式见：http://www.souidea.com/ApiDocuments/Item/25#51
        //         */
        //        //var responseXml = MessageAgent.RequestSouideaXml(souideaKey, RequestDocument.ToString());//获取Souidea返回的XML

        //        DateTime dt2 = DateTime.Now;//计时结束

        //        //转成实体。
        //        /* 如果要写成一行，可以直接用：
        //         * responseMessage = MessageAgent.RequestResponseMessage(agentUrl, agentToken, RequestDocument.ToString());
        //         * 或
        //         * 
        //         */
        //        responseMessage = responseXml.CreateResponseMessage() as ResponseMessageText;

        //        responseMessage.Content += string.Format("\r\n\r\n代理过程总耗时：{0}毫秒", (dt2 - dt1).Milliseconds);
        //    }
        //    else
        //    {
        //        var result = new StringBuilder();
        //        result.AppendFormat("您刚才发送了文字信息：{0}\r\n\r\n", requestMessage.Content);

        //        if (CurrentMessageContext.RequestMessages.Count > 1)
        //        {
        //            result.AppendFormat("您刚才还发送了如下消息（{0}/{1}）：\r\n", CurrentMessageContext.RequestMessages.Count, CurrentMessageContext.StorageData);
        //            for (int i = CurrentMessageContext.RequestMessages.Count - 2; i >= 0; i--)
        //            {
        //                var historyMessage = CurrentMessageContext.RequestMessages[i];
        //                result.AppendFormat("{0} 【{1}】{2}\r\n",
        //                                    historyMessage.CreateTime.ToShortTimeString(),
        //                                    historyMessage.MsgType.ToString(),
        //                                    (historyMessage is RequestMessageText)
        //                                        ? (historyMessage as RequestMessageText).Content
        //                                        : "[非文字类型]"
        //                    );
        //            }
        //            result.AppendLine("\r\n");
        //        }

        //        result.AppendFormat("如果您在{0}分钟内连续发送消息，记录将被自动保留（当前设置：最多记录{1}条）。过期后记录将会自动清除。\r\n", WeixinContext.ExpireMinutes, WeixinContext.MaxRecordCount);
        //        result.AppendLine("\r\n");
        //        result.AppendLine("您还可以发送【位置】【图片】【语音】【视频】等类型的信息（注意是这几种类型，不是这几个文字），查看不同格式的回复。\r\nSDK官方地址：http://weixin.senparc.com");

        //        responseMessage.Content = result.ToString();
        //    }
        //    return responseMessage;
        //}


    }
}
