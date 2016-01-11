using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WechatBuilder.Common;

namespace WechatBuilder.WeiXinComm
{
    /// <summary>
    /// 该处主要处理模块插入回复信息的处理
    /// </summary>
    public partial class WeiXCommFun
    {
        /// <summary>
        /// 判断模版名称【以后只要再这个方法里添加模版的判断，再写好自己的方法】
        /// </summary>
        /// <param name="modelFunctionName"></param>
        /// <param name="modelFunctionId"></param>
        /// <param name="openid"></param>
        /// <param name="apiid"></param>
        /// <param name="responseType"></param>
        /// <param name="responseVaule"></param>
        private IList<Model.ResponseContentEntity> PanDuanMoudle(string modelFunctionName, int modelFunctionId, string openid, int apiid)
        {
            IList<Model.ResponseContentEntity> responselist = new List<Model.ResponseContentEntity>();


            if (modelFunctionName == "刮刮卡")
            {
                responselist = GGKReponse(modelFunctionId, apiid, openid);
            }
            else if (modelFunctionName == "大转盘")
            {
                responselist = DZPReponse(modelFunctionId, apiid, openid);
            }
            else if (modelFunctionName == "优惠券简单版")
            {
                responselist = yhqjdReponse(modelFunctionId, apiid, openid);
            }

            else if (modelFunctionName == "喜帖")
            {
                responselist = xitieReponse(modelFunctionId, apiid, openid);
            }
            else if (modelFunctionName == "会员卡")
            {
                responselist = ucardReponse(modelFunctionId, apiid, openid);
            }



            return responselist;
        }




        /// <summary>
        /// 刮刮卡回复内容
        /// </summary>
        /// <param name="id">模块主键Id</param>
        /// <param name="apiid">微帐号主键id</param>
        /// <param name="openid">openid</param>
        /// <param name="responseType">回复类型：1纯文字，2图文</param>
        /// <param name="responseVaule">回复的内容</param>
        private IList<Model.ResponseContentEntity> GGKReponse(int id, int apiid, string openid)
        {

            IList<Model.ResponseContentEntity> responselist = new List<Model.ResponseContentEntity>();

            Model.ResponseContentEntity responseEntity = new Model.ResponseContentEntity();
            responseEntity.id = id;
            responseEntity.wid = apiid;

            BLL.wx_ggkActionInfo ggkActBll = new BLL.wx_ggkActionInfo();
            Model.wx_ggkActionInfo actModel = ggkActBll.GetModel(id);
            if (actModel.beginDate > DateTime.Now)
            {  //活动尚未开始 

                responseEntity.rcType = Model.ReponseContentType.text;
                responseEntity.rContent = "活动【" + actModel.actName + "】将于" + actModel.beginDate + "开始。";
            }
            else if (actModel.endDate <= DateTime.Now)
            {
                //活动结束
                responseEntity.rcType = Model.ReponseContentType.txtpic;
                responseEntity.rContent = actModel.endNotice;
                responseEntity.rContent2 = actModel.endContent;
                responseEntity.detailUrl = MyCommFun.getWebSite() + "/weixin/ggk/end.aspx?wid=" + apiid + "&aid=" + id;
                responseEntity.picUrl = actModel.endPic;
            }
            else
            {
                //活动正在进行中
                responseEntity.rcType = Model.ReponseContentType.txtpic;
                responseEntity.rContent = actModel.actName;
                responseEntity.rContent2 = actModel.brief;
                responseEntity.detailUrl = MyCommFun.getWebSite() + "/weixin/ggk/index.aspx?wid=" + apiid + "&aid=" + id;
                responseEntity.picUrl = actModel.beginPic;
            }
            responselist.Add(responseEntity);

            return responselist;
        }

        /// <summary>
        /// 大转盘回复内容
        /// </summary>
        /// <param name="id">模块主键Id</param>
        /// <param name="apiid">微帐号主键id</param>
        /// <param name="openid">openid</param>
        /// <param name="responseType">回复类型：1纯文字，2图文</param>
        /// <param name="responseVaule">回复的内容</param>
        private IList<Model.ResponseContentEntity> DZPReponse(int id, int apiid, string openid)
        {
            IList<Model.ResponseContentEntity> responselist = new List<Model.ResponseContentEntity>();
            Model.ResponseContentEntity responseEntity = new Model.ResponseContentEntity();
            responseEntity.id = id;
            responseEntity.wid = apiid;


            BLL.wx_dzpActionInfo ggkActBll = new BLL.wx_dzpActionInfo();
            Model.wx_dzpActionInfo actModel = ggkActBll.GetModel(id);
            if (actModel.beginDate > DateTime.Now)
            {  //活动尚未开始 
                responseEntity.rcType = Model.ReponseContentType.text;
                responseEntity.rContent = "活动【" + actModel.actName + "】将于" + actModel.beginDate + "开始。";
            }
            else if (actModel.endDate <= DateTime.Now)
            {
                //活动结束
                responseEntity.rcType = Model.ReponseContentType.txtpic;
                responseEntity.rContent = actModel.endNotice;
                responseEntity.rContent2 = actModel.endContent;
                responseEntity.detailUrl = MyCommFun.getWebSite() + "/weixin/dzp/end.aspx?wid=" + apiid + "&aid=" + id;
                responseEntity.picUrl = actModel.endPic;

            }
            else
            {
                //活动正在进行中

                responseEntity.rcType = Model.ReponseContentType.txtpic;
                responseEntity.rContent = actModel.actName;
                responseEntity.rContent2 = actModel.brief;
                responseEntity.detailUrl = MyCommFun.getWebSite() + "/weixin/dzp/index.aspx?wid=" + apiid + "&aid=" + id;
                responseEntity.picUrl = actModel.beginPic;
            }
            responselist.Add(responseEntity);
            return responselist;

        }

        /// <summary>
        /// 优惠券简单版回复内容
        /// </summary>
        /// <param name="id">模块主键Id</param>
        /// <param name="apiid">微帐号主键id</param>
        /// <param name="openid">openid</param>
        /// <param name="responseType">回复类型：1纯文字，2图文</param>
        /// <param name="responseVaule">回复的内容</param>
        private IList<Model.ResponseContentEntity> yhqjdReponse(int id, int apiid, string openid)
        {

            IList<Model.ResponseContentEntity> responselist = new List<Model.ResponseContentEntity>();
            Model.ResponseContentEntity responseEntity = new Model.ResponseContentEntity();
            responseEntity.id = id;
            responseEntity.wid = apiid;


            BLL.wx_sTicket sttActBll = new BLL.wx_sTicket();
            Model.wx_sTicket actModel = sttActBll.GetModel(id);
            if (actModel.beginDate > DateTime.Now)
            {  //活动尚未开始 
                responseEntity.rcType = Model.ReponseContentType.text;
                responseEntity.rContent = "活动【" + actModel.actionName + "】将于" + actModel.beginDate + "开始。";

            }
            else if (actModel.endDate <= DateTime.Now)
            {
                //活动结束

                responseEntity.rcType = Model.ReponseContentType.txtpic;
                responseEntity.rContent = actModel.endNotice;
                responseEntity.rContent2 = actModel.endContent;
                responseEntity.detailUrl = MyCommFun.getWebSite() + "/weixin/sticket/end.aspx?wid=" + apiid + "&aid=" + id;
                responseEntity.picUrl = actModel.endPic;
            }
            else
            {
                //活动正在进行中

                responseEntity.rcType = Model.ReponseContentType.txtpic;
                responseEntity.rContent = actModel.actionName;
                responseEntity.rContent2 = actModel.brief;
                responseEntity.detailUrl = MyCommFun.getWebSite() + "/weixin/sticket/index.aspx?wid=" + apiid + "&aid=" + id;
                responseEntity.picUrl = actModel.beginPic;

            }

            responselist.Add(responseEntity);
            return responselist;

        }

        /// <summary>
        /// 喜帖
        /// </summary>
        /// <param name="id"></param>
        /// <param name="apiid"></param>
        /// <param name="openid"></param>
        /// <returns></returns>
        private IList<Model.ResponseContentEntity> xitieReponse(int id, int apiid, string openid)
        {
            IList<Model.ResponseContentEntity> responselist = new List<Model.ResponseContentEntity>();
            Model.ResponseContentEntity responseEntity = new Model.ResponseContentEntity();
            responseEntity.id = id;
            responseEntity.wid = apiid;


            BLL.wx_xt_base xtBll = new BLL.wx_xt_base();
            Model.wx_xt_base actModel = xtBll.GetModel(id);
            if (actModel.statedate < DateTime.Now)
            {  //活动尚未开始 
                responseEntity.rcType = Model.ReponseContentType.text;
                responseEntity.rContent = "【" + actModel.wxTitle + "】将于" + actModel.statedate + "举办，现已经结束";

            }

            else
            {
                //活动正在进行中

                responseEntity.rcType = Model.ReponseContentType.txtpic;
                responseEntity.rContent = actModel.wxTitle;
                responseEntity.rContent2 = actModel.word;
                responseEntity.detailUrl = MyCommFun.getWebSite() + "/weixin/xitie/index.aspx?wid=" + apiid + "&xid=" + id;
                responseEntity.picUrl = actModel.fengmian;

            }

            responselist.Add(responseEntity);
            return responselist;
        }


        /// <summary>
        /// 会员卡
        /// </summary>
        /// <param name="id"></param>
        /// <param name="apiid"></param>
        /// <param name="openid"></param>
        /// <returns></returns>
        private IList<Model.ResponseContentEntity> ucardReponse(int id, int apiid, string openid)
        {
            IList<Model.ResponseContentEntity> responselist = new List<Model.ResponseContentEntity>();
            Model.ResponseContentEntity responseEntity = new Model.ResponseContentEntity();
            responseEntity.id = id;
            responseEntity.wid = apiid;

            BLL.wx_ucard_store ucardBll = new BLL.wx_ucard_store();
            Model.wx_ucard_store ucard = ucardBll.GetModel(id);

            

            responseEntity.rcType = Model.ReponseContentType.txtpic;
            responseEntity.rContent = ucard.storeName;
            responseEntity.rContent2 = ucard.cardBrief;
            responseEntity.detailUrl = MyCommFun.getWebSite() + "/weixin/ucard/index.aspx?wid=" + apiid + "&id=" + id;
            responseEntity.picUrl = ucard.hfPic;
            responselist.Add(responseEntity);
            return responselist;
        }
    }
}
