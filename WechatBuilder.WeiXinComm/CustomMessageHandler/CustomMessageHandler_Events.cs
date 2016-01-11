using System;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Senparc.Weixin.MP.Agent;
using Senparc.Weixin.MP.Context;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Helpers;
using Senparc.Weixin.MP.MessageHandlers;
using WechatBuilder.BLL;

namespace WechatBuilder.WeiXinComm.CustomMessageHandler
{
    /// <summary>
    /// 自定义MessageHandler
    /// </summary>
    public partial class CustomMessageHandler
    {
        wx_requestRule rBll = new wx_requestRule();
        wx_requestRuleContent rcBll = new wx_requestRuleContent();
        WeiXCommFun wxcomm = new WeiXCommFun();

        /// <summary>
        /// 菜单点击事件
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_ClickRequest(RequestMessageEvent_Click requestMessage)
        {
            IResponseMessageBase reponseMessage = null;
            #region 注释掉
            ////菜单点击，需要跟创建菜单时的Key匹配
            //switch (requestMessage.EventKey)
            //{
            //    case "OneClick":
            //        {
            //            var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
            //            reponseMessage = strongResponseMessage;
            //            strongResponseMessage.Content = "您点击了底部按钮。\r\n为了测试微信软件换行bug的应对措施，这里做了一个——\r\n换行";
            //        }
            //        break;
            //    case "SubClickRoot_Text":
            //        {
            //            var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
            //            reponseMessage = strongResponseMessage;
            //            strongResponseMessage.Content = "您点击了子菜单按钮。";
            //        }
            //        break;
            //    case "SubClickRoot_News":
            //        {
            //            var strongResponseMessage = CreateResponseMessage<ResponseMessageNews>();
            //            reponseMessage = strongResponseMessage;
            //            strongResponseMessage.Articles.Add(new Article()
            //            {
            //                Title = "您点击了子菜单图文按钮",
            //                Description = "您点击了子菜单图文按钮，这是一条图文信息。",
            //                PicUrl = "http://weixin.senparc.com/Images/qrcode.jpg",
            //                Url = "http://weixin.senparc.com"
            //            });
            //        }
            //        break;
            //    case "SubClickRoot_Music":
            //        {
            //            var strongResponseMessage = CreateResponseMessage<ResponseMessageMusic>();
            //            reponseMessage = strongResponseMessage;
            //            strongResponseMessage.Music.MusicUrl = "http://weixin.senparc.com/Content/music1.mp3";
            //        }
            //        break;
            //    case "SubClickRoot_Agent"://代理消息
            //        {
            //            //获取返回的XML
            //            DateTime dt1 = DateTime.Now;
            //            reponseMessage = MessageAgent.RequestResponseMessage(this, agentUrl, agentToken, RequestDocument.ToString());
            //            //上面的方法也可以使用扩展方法：this.RequestResponseMessage(this,agentUrl, agentToken, RequestDocument.ToString());

            //            DateTime dt2 = DateTime.Now;

            //            if (reponseMessage is ResponseMessageNews)
            //            {
            //                (reponseMessage as ResponseMessageNews)
            //                    .Articles[0]
            //                    .Description += string.Format("\r\n\r\n代理过程总耗时：{0}毫秒", (dt2 - dt1).Milliseconds);
            //            }
            //        }
            //        break;
            //    case "Member"://托管代理会员信息
            //        {
            //            //原始方法为：MessageAgent.RequestXml(this,agentUrl, agentToken, RequestDocument.ToString());//获取返回的XML
            //            reponseMessage = this.RequestResponseMessage(agentUrl, agentToken, RequestDocument.ToString());
            //        }
            //        break;
            //    case "OAuth"://OAuth授权测试
            //        {
            //            var strongResponseMessage = CreateResponseMessage<ResponseMessageNews>();
            //            strongResponseMessage.Articles.Add(new Article()
            //            {
            //                Title = "OAuth2.0测试",
            //                Description = "点击【查看全文】进入授权页面。\r\n注意：此页面仅供测试（是专门的一个临时测试账号的授权，并非Senparc.Weixin.MP SDK官方账号，所以如果授权后出现错误页面数正常情况），测试号随时可能过期。请将此DEMO部署到您自己的服务器上，并使用自己的appid和secret。",
            //                Url = "http://weixin.senparc.com/oauth2",
            //                PicUrl = "http://weixin.senparc.com/Images/qrcode.jpg"
            //            });
            //            reponseMessage = strongResponseMessage;
            //        }
            //        break;
            //}
            #endregion
            string keywords = requestMessage.EventKey;
            int apiid = wxcomm.getApiid();


            string EventName = "";
            if (requestMessage.Event.ToString().Trim() != "")
            {
                EventName = requestMessage.Event.ToString();
            }
            else if (requestMessage.EventKey != null)
            {
                EventName += requestMessage.EventKey.ToString();
            }

            if (!wxcomm.ExistApiidAndWxId(apiid, requestMessage.ToUserName))
            {  //验证接收方是否为我们系统配置的帐号，即验证微帐号与微信原始帐号id是否一致，如果不一致，说明【1】配置错误，【2】数据来源有问题
                DAL.wxResponseBaseMgr.Add(apiid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "none", "未取到关键词对应的数据", requestMessage.ToUserName);
                return wxcomm.GetResponseMessageTxtByContent(requestMessage, "验证微帐号与微信原始帐号id不一致，可能原因【1】系统配置错误，【2】非法的数据来源有问题", apiid);
            }


            int responseType = 0;
            string modelFunctionName = "";
            int modelFunctionId = 0;
            int rid = rBll.GetRuleIdByKeyWords(apiid, keywords, out responseType, out modelFunctionName, out modelFunctionId);
            if (rid <= 0 || responseType <= 0)
            {
                // 2014-9-18 暂时性功能 针对ID为 gh_04bf23f25940的平台客户 保存发送者的ID 及 生成抽奖序号 并保存。
                if (requestMessage.ToUserName == "gh_c80ca634fa2a" && requestMessage.EventKey == "wdsluckdraw20140920")
                {
                    //发送纯文字
                    reponseMessage = wxcomm.GetResponseMessageTxt(requestMessage, apiid);
                    return reponseMessage;
                }
                else
                {
                    // 2014-9-18原功能
                    DAL.wxResponseBaseMgr.Add(apiid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "none", "未取到关键词对应的数据", requestMessage.ToUserName);
                    return wxcomm.GetResponseMessageTxtByContent(requestMessage, "", apiid);
                }
            }

            if (modelFunctionId > 0)
            {  //模块功能回复
                return wxcomm.GetModuleResponse(requestMessage, modelFunctionName, modelFunctionId, apiid);
            }

            switch (responseType)
            {
                case 1:
                    //发送纯文字
                    reponseMessage = wxcomm.GetResponseMessageTxt(requestMessage, rid, apiid);
                    break;
                case 2:
                    //发送多图文
                    reponseMessage = wxcomm.GetResponseMessageNews(requestMessage, rid, apiid);
                    break;
                case 3:
                    //发送语音
                    reponseMessage = wxcomm.GetResponseMessageeMusic(requestMessage, rid, apiid);
                    break;
                default:
                    break;
            }

            return reponseMessage;
        }

        public override IResponseMessageBase OnEvent_EnterRequest(RequestMessageEvent_Enter requestMessage)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            responseMessage.Content = "您刚才发送了ENTER事件请求。";
            return responseMessage;
        }

        public override IResponseMessageBase OnEvent_LocationRequest(RequestMessageEvent_Location requestMessage)
        {
            ////这里是微信客户端（通过微信服务器）自动发送过来的位置信息
            //var responseMessage = CreateResponseMessage<ResponseMessageText>();
            //responseMessage.Content = "这里写什么都无所谓，比如：上帝爱你！";
            //return responseMessage;//这里也可以返回null（需要注意写日志时候null的问题）
            return null;
        }

        /// <summary>
        /// 订阅（关注）事件
        /// </summary>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_SubscribeRequest(RequestMessageEvent_Subscribe requestMessage)
        {
            return EventProcess(6, requestMessage);
        }

        /// <summary>
        /// 退订
        /// 实际上用户无法收到非订阅账号的消息，所以这里可以随便写。
        /// unsubscribe事件的意义在于及时删除网站应用中已经记录的OpenID绑定，消除冗余数据。并且关注用户流失的情况。
        /// </summary>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_UnsubscribeRequest(RequestMessageEvent_Unsubscribe requestMessage)
        {
            return EventProcess(7, requestMessage);
        }

        private IResponseMessageBase EventProcess(int type, RequestMessageEventBase requestMessage)
        {
            int apiid = wxcomm.getApiid();


            string EventName = "";
            if (requestMessage.Event.ToString().Trim() != "")
            {
                EventName = requestMessage.Event.ToString();
            }
            else if (requestMessage.EventKey != null)
            {
                EventName += requestMessage.EventKey.ToString();
            }

            if (!wxcomm.ExistApiidAndWxId(apiid, requestMessage.ToUserName))
            {  //验证接收方是否为我们系统配置的帐号，即验证微帐号与微信原始帐号id是否一致，如果不一致，说明【1】配置错误，【2】数据来源有问题
                DAL.wxResponseBaseMgr.Add(apiid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "none", "未取到关键词对应的数据", requestMessage.ToUserName);
                return wxcomm.GetResponseMessageTxtByContent(requestMessage, "验证微帐号与微信原始帐号id不一致，可能原因【1】系统配置错误，【2】非法的数据来源", apiid);
            }


            int responseType = 0;
            int rid = rBll.GetRuleIdAndResponseType(apiid, "reqestType=" + type, out responseType);  //取消关注
            if (rid <= 0 || responseType <= 0)
            {
                DAL.wxResponseBaseMgr.Add(apiid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "none", "未取到关键词对应的数据", requestMessage.ToUserName);
                return null;
            }

            IResponseMessageBase reponseMessage = null;
            switch (responseType)
            {
                case 1:
                    //发送纯文字
                    reponseMessage = wxcomm.GetResponseMessageTxt(requestMessage, rid, apiid);
                    break;
                case 2:
                    //发送多图文
                    reponseMessage = wxcomm.GetResponseMessageNews(requestMessage, rid, apiid);
                    break;
                case 3:
                    //发送语音
                    reponseMessage = wxcomm.GetResponseMessageeMusic(requestMessage, rid, apiid);
                    break;
                default:
                    break;
            }

            return reponseMessage;

        }

    }
}