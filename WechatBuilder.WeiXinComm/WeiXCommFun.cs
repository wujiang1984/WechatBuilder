using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WechatBuilder.Common;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Helpers;
using Senparc.Weixin.MP;
using System.Diagnostics;
using WechatBuilder.BLL;
using WechatBuilder.DAL;

namespace WechatBuilder.WeiXinComm
{
    public partial class WeiXCommFun
    {
        #region 请求为“文字的”

        /// <summary>
        /// 推送纯文字
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IResponseMessageBase GetResponseMessageTxt(RequestMessageText requestMessage, int Indexid, int wid)
        {

            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);

            string openid = requestMessage.FromUserName;
            string token = ConvertDateTimeInt(DateTime.Now).ToString();
            responseMessage.Content = getDataTxtComm(wid, Indexid, openid, token);
            wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "text", responseMessage.Content, requestMessage.ToUserName);
            return responseMessage;
        }



        /// <summary>
        /// 处理语音请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public IResponseMessageBase GetResponseMessageeMusic(RequestMessageText requestMessage, int Indexid, int wid)
        {

            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageMusic>(requestMessage);
            Model.wx_requestRuleContent model_wx = getDataMusicComm(wid, Indexid);
            if (model_wx == null)
            {
                wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "music", "-1", requestMessage.ToUserName);
            }
            else
            {
                responseMessage.Music.MusicUrl = model_wx.mediaUrl;
                responseMessage.Music.Title = model_wx.rContent;
                responseMessage.Music.Description = model_wx.rContent2;
                wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "music", "音乐链接：" + model_wx.mediaUrl + "|标题：" + model_wx.rContent + "|描述：" + model_wx.rContent2, requestMessage.ToUserName);

            }

            return responseMessage;
        }

        /// <summary>
        /// 推送多图文
        /// update note 1:
        ///    李朴 2013-8-20 添加会员卡的cardno参数
        ///    注意：如果该会员注册过，则字符串没有cardno参数；
        ///    只有在会员注册过，在数据库里查询到该会员的cadno，则在url里添加节点cardno。
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <param name="Indexid"></param>
        /// <returns></returns>
        public IResponseMessageBase GetResponseMessageNews(RequestMessageText requestMessage, int Indexid, int wid)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageNews>(requestMessage);
            string openid = requestMessage.FromUserName;
            string token = ConvertDateTimeInt(DateTime.Now).ToString();
            List<Article> picTxtList = getDataPicTxtComm(wid, Indexid, openid, token);
            if (picTxtList == null || picTxtList.Count <= 0)
            {
                wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "txtpic", "-1", requestMessage.ToUserName);
            }
            else
            {
                wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "txtpic", "这次发了" + picTxtList.Count + "条图文", requestMessage.ToUserName);
            }
            responseMessage.Articles.AddRange(picTxtList);
            return responseMessage;
        }



        /// <summary>
        /// 推送纯文字
        /// 2013-9-12
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IResponseMessageBase GetResponseMessageTxtByContent(RequestMessageText requestMessage, string content,int wid)
        {

            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            var locationService = new LocationService();
            responseMessage.Content = content;
            wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "text","文字请求，推送纯粹文字，内容为："+ content, requestMessage.ToUserName);
            return responseMessage;
        }

        /// <summary>
        /// 推送纯文字
        /// 2013-9-12
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IResponseMessageBase GetResponseMessageTxtByContent(RequestMessageImage requestMessage, string content, int wid)
        {

            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            var locationService = new LocationService();
            responseMessage.Content = content;
            wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), "微信上墙", "text", "文字请求，推送纯粹文字，内容为：" + content, requestMessage.ToUserName);
            return responseMessage;
        }


        #endregion

        #region 请求为“事件的”
        /// <summary>
        /// 推送纯文字
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IResponseMessageBase GetResponseMessageTxt(RequestMessageEventBase requestMessage, int Indexid, int wid)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            string openid = requestMessage.FromUserName;
            string token = ConvertDateTimeInt(DateTime.Now).ToString();
            responseMessage.Content = getDataTxtComm(wid, Indexid, openid, token);

            string EventName = "";
            if (requestMessage.Event.ToString().Trim() != "")
            {
                EventName = requestMessage.Event.ToString();
            }
            else if (requestMessage.EventKey != null)
            {
                EventName += requestMessage.EventKey.ToString();
            }

            wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "text", responseMessage.Content, requestMessage.ToUserName);

            return responseMessage;
        }
        /// <summary>
        /// 2014-9-8新增抽奖功能
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <param name="Indexid"></param>
        /// <param name="wid"></param>
        /// <returns></returns>
        public IResponseMessageBase GetResponseMessageTxt(RequestMessageEventBase requestMessage, int wid)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            string openid = requestMessage.FromUserName;
            string token = ConvertDateTimeInt(DateTime.Now).ToString();
            responseMessage.Content = string.Format("感谢您参与本次活动，您的幸运号码为 WDS2014920{0} ,请凭本号码参与后续精彩活动！",getDataTxtComm(openid));

            string EventName = "";
            if (requestMessage.Event.ToString().Trim() != "")
            {
                EventName = requestMessage.Event.ToString();
            }
            else if (requestMessage.EventKey != null)
            {
                EventName += requestMessage.EventKey.ToString();
            }

            wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "text", responseMessage.Content, requestMessage.ToUserName);

            return responseMessage;
        }
        /// <summary>
        /// 处理语音请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public IResponseMessageBase GetResponseMessageeMusic(RequestMessageEventBase requestMessage, int Indexid, int wid)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageMusic>(requestMessage);
            string EventName = "";
            if (requestMessage.Event.ToString().Trim() != "")
            {
                EventName = requestMessage.Event.ToString();
            }
            else if (requestMessage.EventKey != null)
            {
                EventName += requestMessage.EventKey.ToString();
            }


            Model.wx_requestRuleContent model = getDataMusicComm(wid, Indexid);
            if (model == null)
            {
              
                wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "music", "-1", requestMessage.ToUserName);
            }
            else
            {
                responseMessage.Music.MusicUrl = model.mediaUrl;
                responseMessage.Music.Title = model.rContent;
                responseMessage.Music.Description = model.rContent2;
                wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "music", "音乐链接：" + model.mediaUrl + "|标题：" + model.rContent + "|描述：" + model.rContent2, requestMessage.ToUserName);

            }
            return responseMessage;
        }

        /// <summary>
        /// 推送多图文
        /// update note 1:
        ///    李朴 2013-8-20 添加会员卡的cardno参数
        ///    注意：如果该会员注册过，则字符串没有cardno参数；
        ///    只有在会员注册过，在数据库里查询到该会员的cadno，则在url里添加节点cardno。
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <param name="Indexid"></param>
        /// <param name="wid">微帐号主键Id</param>
        /// <returns></returns>
        public IResponseMessageBase GetResponseMessageNews(RequestMessageEventBase requestMessage, int Indexid, int wid)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageNews>(requestMessage);
            string openid = requestMessage.FromUserName;
            string token = ConvertDateTimeInt(DateTime.Now).ToString();
            List<Article> picTxtList = getDataPicTxtComm(wid, Indexid, openid, token);
            string EventName = "";
            if (requestMessage.Event.ToString().Trim() != "")
            {
                EventName = requestMessage.Event.ToString();
            }
            else if (requestMessage.EventKey != null)
            {
                EventName += requestMessage.EventKey.ToString();
            }

            if (picTxtList == null || picTxtList.Count <= 0)
            {
                wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "txtpic", "-1", requestMessage.ToUserName);
            }
            else
            {
                wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "txtpic", "这次发了" + picTxtList.Count + "条图文", requestMessage.ToUserName);
            }

            responseMessage.Articles.AddRange(picTxtList);
            return responseMessage;
        }

        /// <summary>
        /// 推送纯文字
        /// 2013-9-12
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IResponseMessageBase GetResponseMessageTxtByContent(RequestMessageEventBase requestMessage, string content,int wid)
        {

            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            var locationService = new LocationService();
            responseMessage.Content = content;
            string EventName = "";
            if (requestMessage.Event.ToString().Trim() != "")
            {
                EventName = requestMessage.Event.ToString();
            }
            else if (requestMessage.EventKey != null)
            {
                EventName += requestMessage.EventKey.ToString();
            }
            wxResponseBaseMgr.Add(wid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "text", "事件：推送纯粹的文字，内容为:" + content, requestMessage.ToUserName);

            return responseMessage;
        }


        #endregion

        #region 模块功能的回复内容

        /// <summary>
        /// 模块功能回复【请求为‘文字’类型】
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <param name="modelFunctionName"></param>
        /// <param name="modelFunctionId"></param>
        /// <param name="apiid"></param>
        /// <returns></returns>
        public IResponseMessageBase GetModuleResponse(RequestMessageText requestMessage, string modelFunctionName, int modelFunctionId, int apiid)
        {
            string openid = requestMessage.FromUserName;
            string token = ConvertDateTimeInt(DateTime.Now).ToString();

            IList<Model.ResponseContentEntity> responselist = new List<Model.ResponseContentEntity>();

             responselist= PanDuanMoudle(modelFunctionName, modelFunctionId, openid, apiid);
             if (responselist == null || responselist.Count <= 0)
             {
                 var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
                  responseMessage.Content = "【" + modelFunctionName + "】功能模块未获得到数据";
                  return responseMessage;
             }
            Model.ReponseContentType responseType = responselist[0].rcType;
            if (responseType == Model.ReponseContentType.text)
            {
                var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);

                responseMessage.Content = responselist[0].rContent.ToString();
                wxResponseBaseMgr.Add(apiid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "text", responseMessage.Content, requestMessage.ToUserName);
                return responseMessage;
            }
            else if (responseType == Model.ReponseContentType.txtpic)
            {
                var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageNews>(requestMessage);
                IList<Article> rArticlelist = new List<Article>();
                Article article = new Article();
                foreach (Model.ResponseContentEntity response in responselist)
                {
                    article = new Article();
                    article.Title = response.rContent;
                    article.Description = response.rContent2;
                    article.Url =getWXApiUrl(response.detailUrl, token, openid) + getWxUrl_suffix();
                    if (response.picUrl == null || response.picUrl.ToString().Trim() == "")
                    {
                        article.PicUrl = "";
                    }
                    else
                    {
                        if (!response.picUrl.Contains("http://"))
                        {
                            article.PicUrl = MyCommFun.getWebSite() + response.picUrl;
                        }
                        else
                        {
                            article.PicUrl = response.picUrl;
                        }
                    }
                    rArticlelist.Add(article);

                }

                responseMessage.Articles.AddRange(rArticlelist);
                wxResponseBaseMgr.Add(apiid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "txtpic", "这次发了" + rArticlelist.Count+ "条图文", requestMessage.ToUserName);

                return responseMessage;

            }
            else
            {
                return null;
            }
           

        }


        /// <summary>
        /// 模块功能回复【请求为‘事件’类型】
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <param name="modelFunctionName"></param>
        /// <param name="modelFunctionId"></param>
        /// <param name="apiid"></param>
        /// <returns></returns>
        public IResponseMessageBase GetModuleResponse(RequestMessageEventBase requestMessage, string modelFunctionName, int modelFunctionId, int apiid)
        {
            string openid = requestMessage.FromUserName;
            string token = ConvertDateTimeInt(DateTime.Now).ToString();

            IList<Model.ResponseContentEntity> responselist = new List<Model.ResponseContentEntity>();
                
           responselist= PanDuanMoudle( modelFunctionName,  modelFunctionId, openid,  apiid);
           if (responselist == null || responselist.Count <= 0)
           {
               var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
               responseMessage.Content = "【" + modelFunctionName + "】功能模块未获得到数据";
               return responseMessage;
           }

           Model.ReponseContentType responseType = responselist[0].rcType;

           if (responseType == Model.ReponseContentType.text)
            {
                var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);

                responseMessage.Content = responselist[0].rContent.ToString();
                return responseMessage;
            }
           else if (responseType == Model.ReponseContentType.txtpic)
            {
                  var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageNews>(requestMessage);
                IList<Article> rArticlelist = new List<Article>();
                Article article = new Article();
                foreach (Model.ResponseContentEntity response in responselist)
                {
                    article = new Article();
                    article.Title = response.rContent;
                    article.Description = response.rContent2;
                    article.Url = getWXApiUrl(response.detailUrl, token, openid) + getWxUrl_suffix();
                    if (response.picUrl == null || response.picUrl.ToString().Trim() == "")
                    {
                        article.PicUrl = "";
                    }
                    else
                    {
                        if (!response.picUrl.Contains("http://"))
                        {
                            article.PicUrl = MyCommFun.getWebSite() + response.picUrl;
                        }
                        else
                        {
                            article.PicUrl = response.picUrl;
                        }
                    }
                    rArticlelist.Add(article);

                }
                responseMessage.Articles.AddRange(rArticlelist);
                return responseMessage;
            }
            else
            {
                return null;
            }
            

        }
       
      



        #endregion


        #region 从数据库里读取数据

        BLL.wx_requestRuleContent rcBll = new BLL.wx_requestRuleContent();

        /// <summary>
        /// 从数据库里取文本类型的值
        /// </summary>
        /// <param name="Indexid"></param>
        /// <returns></returns>
        public string getDataTxtComm(int wid, int Indexid, string openid, string token)
        {
            //随机数

            string content = rcBll.GetTxtContent(Indexid);
            if (content.Contains("{openid}"))
            {
                content = content.Replace("{openid}", openid);
            }
            content = ProcTitle(content, openid);
            return content;

        }
        /// <summary>
        /// 2014-9-18 新增抽奖功能
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="openid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public string getDataTxtComm(string openid)
        {
            string content = rcBll.GetTxtContent(openid);
       
            return content;

        }
        /// <summary>
        /// 从数据库里取语音类型的值
        /// </summary>
        /// <param name="wid">微帐号主键Id</param>
        /// <param name="Indexid"></param>
        /// <returns></returns>
        public Model.wx_requestRuleContent getDataMusicComm(int wid, int Indexid)
        {

            Model.wx_requestRuleContent model = rcBll.GetMusicContent(Indexid);
            return model;

        }

        /// <summary>
        /// 从数据库里取图文类型的值
        /// </summary>
        /// <param name="wid">微帐号主键id</param>
        /// <param name="Indexid"></param>
        /// <param name="openid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<Article> getDataPicTxtComm(int wid, int Indexid, string openid, string token)
        {
            List<Article> retlist = new List<Article>();
            string website = MyCommFun.getWebSite();



            IList<Model.wx_requestRuleContent> twList = rcBll.GetTuWenContent(Indexid);


            Article article = new Article();
            for (int i = 0; i < twList.Count(); i++)
            {
                article = new Article();
                article.Title = ProcTitle(twList[i].rContent, openid);
                article.Description = twList[i].rContent2;
                article.Url = getWXApiUrl(twList[i].detailUrl, token, openid) + rcBll.cardnoStr(wid, openid) + getWxUrl_suffix();
                if (twList[i].picUrl == null || twList[i].picUrl.ToString().Trim() == "")
                {
                    article.PicUrl = "";
                }
                else
                {
                    if (twList[i].picUrl.Contains("http://"))
                    {
                        article.PicUrl = twList[i].picUrl;
                       
                    }
                    else
                    {
                        article.PicUrl = website + twList[i].picUrl;
                    }
                }
                retlist.Add(article);
            }

            return retlist;

        }

        /// <summary>
        /// 判断该微帐号与原始Id号是否一致，如果不一致，则返回false，如果一致则返回true
        /// </summary>
        /// <param name="apiid"></param>
        /// <param name="wxid">原始Id号</param>
        /// <returns></returns>
        public bool ExistApiidAndWxId(int apiid, string wxid)
        {
            bool exists = true;
            DAL.wx_userweixin weixinDal = new DAL.wx_userweixin();
            if (weixinDal.ExistsWidAndWxId(apiid, wxid))
            {
                exists = true;
            }
            else
            {
                exists = false;
            }

            return exists;
        }
        /// <summary>
        /// 如果content包含了sn码，则将sn码动态替换成一个值
        /// [jintian]==当天的日期
        /// [zuotian]==昨天的日期
        /// [mingtian]==明天的日期
        /// </summary>
        /// <param name="title"></param>
        /// <param name="openid"></param>
        /// <returns></returns>
        private string ProcTitle(string content, string openid)
        {
            //if (content.Contains("[sn]"))
            //{
            //    MxWeiXin.BLL.wx_sn_info snBll = new MxWeiXin.BLL.wx_sn_info();
            //    content = content.Replace("[sn]", snBll.getNewRadmInfo(openid));
            //}
            content = content.Replace("[jintian]", DateTime.Now.ToString("yyyy年MM月dd日"));
            content = content.Replace("[zuotian]", DateTime.Now.AddDays(-1).ToString("yyyy年MM月dd日"));
            content = content.Replace("[mingtian]", DateTime.Now.AddDays(1).ToString("yyyy年MM月dd日"));
            return content;
        }

        #endregion

        #region 常用的一些小方法
        public int getApiid()
        {
            if (HttpContext.Current.Request["apiid"] == null || HttpContext.Current.Request["apiid"].ToString().Length < 1)
            {
                return 0;
            }
            int tmpInt = 0;
            if (!int.TryParse(HttpContext.Current.Request["apiid"].ToString(), out tmpInt))
            {
                return 0;
            }
            int apiid = int.Parse(HttpContext.Current.Request["apiid"].ToString());
            return apiid;

        }

        public string getWXApiUrl(string url, string token, string openid)
        {
            
            string ret = "";
            if (url.Contains("?"))
            {
                ret = url + "&token=" + token + "&openid=" + openid;
            }
            else
            {
                ret = url + "?token=" + token + "&openid=" + openid;
            }
           
            return ret;
        }

        /// <summary>
        /// 设置微信url地址的后缀
        /// </summary>
        /// <returns></returns>
        public string getWxUrl_suffix()
        {
            string nati_suffix = Utils.GetAppSettingValue("nati_suffix");
            if (nati_suffix == "")
            {
                return "#mp.weixin.qq.com";
            }
            else
            {
                return "&" + nati_suffix;
            }

        }


        public long ConvertDateTimeInt(System.DateTime time)
        {
            long intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            intResult = (long)(time - startTime).TotalSeconds;
            return intResult;
        }
        #endregion


    }
}
