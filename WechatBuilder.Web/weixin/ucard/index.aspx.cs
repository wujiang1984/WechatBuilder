using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.weixin.ucard
{
    public partial class index : WeiXinPage
    {
        protected string openid = "";
        protected int wid = 0;
        protected int id = 0;//店铺的主键id
        protected int degreeNum = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            OnlyWeiXinLook();

            openid = MyCommFun.RequestOpenid();
            wid = MyCommFun.RequestInt("wid");
            id = MyCommFun.RequestInt("id");
            if (openid == "" || wid == 0 || id == 0)
            {
                hidStatus.Value = "-1";
                hidErrInfo.Value = "参数错误";
                return;
            }
            bindData();
        }

        private void bindData()
        {
            string jibie = "会员卡号";

            BLL.wx_ucard_cardinfo cardBll = new BLL.wx_ucard_cardinfo();
            Model.wx_ucard_cardinfo cardinfo = cardBll.GetModelBySid(id);

            BLL.wx_ucard_users userBll = new BLL.wx_ucard_users();
            Model.wx_ucard_users user = userBll.GetStoreUserInfo(openid, id);
            bool hasLq = true;
            if (user == null || user.id <= 0)
            {
                //说明该用户还未领取这个会员卡
                hasLq = false;
                StringBuilder lqStr = new StringBuilder("");
                lqStr.Append(" <div class=\"msk\"><p class=\"explain2\">");
                lqStr.Append("<a id=\"showcard\" class=\"receive\" href=\"javascript:void(0)\">领取您的新会员卡</a><span>微时代会员卡，方便携带收藏，永不挂失</span>");
                lqStr.Append("</p></div>");
                litLQK.Text = lqStr.ToString();
            }
            else
             {
                 jibie = BLL.wx_ucard_fun.userDegree(id,MyCommFun.Obj2Int(user.ttScore), jibie, out degreeNum);

                //已经领取了会员卡
                 bindJiFen(user); //展示积分
                 bindNewInfo(user);
                 QDInof(user);
            }
            if (cardinfo != null)
            {
                Page.Title = cardinfo.cardName;
                //卡版面设计
                StringBuilder sbStr = new StringBuilder("");
                string bgPic = "";
                if (cardinfo.bgUrl == null || cardinfo.bgUrl.Trim().Length <= 0)
                {
                    bgPic = cardinfo.bgTypeUrl;
                }
                else
                {
                    bgPic = cardinfo.bgUrl;
                }
                sbStr.Append(" <img class=\"cardbg\" src=\"" + bgPic + "\">");
                sbStr.Append(" <img id=\"cardlogo\" class=\"logo\" src=\"" + cardinfo.logo + "\">");
                sbStr.Append(" <h1 style=\"color: " + cardinfo.cardNameColor + "\">" + cardinfo.cardName + "</h1>");
                if (hasLq)
                {
                    sbStr.Append(" <strong class=\"pdo verify\" style=\"color: " + cardinfo.cardNoColor + "\"><span id=\"cdnb\"><em>" + jibie + "</em>" + user.cardNo + "</span></strong>");
                }
                else
                {
                    sbStr.Append(" <strong class=\"pdo verify\" style=\"color: #A985FF\"><span id=\"cdnb\"><em>普通会员</em>00000000</span></strong>");
                }
                litCardInfo.Text = sbStr.ToString();
            }
            //店铺信息
            BLL.wx_ucard_store storeBll = new BLL.wx_ucard_store();
            Model.wx_ucard_store store = storeBll.GetModel(id);
            if (store != null)
            {
                litTel.Text =MyCommFun.ObjToStr( store.tel);
                litAddr.Text = MyCommFun.ObjToStr(store.addr);
                aAddr.HRef = "http://api.map.baidu.com/marker?location="+store.yPoint+","+store.xPoint+"&amp;title="+store.addr+"&amp;content="+store.cardBrief+"&amp;output=html";
                aTel.HRef = "tel:" + store.tel; ;
            }
        }

        /// <summary>
        /// 通知，特权，优惠券，礼品券
        /// </summary>
        private void bindNewInfo(Model.wx_ucard_users user)
        { 
            //通知列表
            BLL.wx_ucard_notice noticeBll = new BLL.wx_ucard_notice();
            int noticeNum = noticeBll.GetRecordCount(" sid=" + id + " and ( userDegree ='0' or userDegree like '%," + degreeNum + ",%' ) ");
            StringBuilder sbStr = new StringBuilder("");
            if (noticeNum > 0)
            {
                sbStr.Append(" <li><a href=\"ucardNotice.aspx?wid=" + wid + "&sid=" + id + "&openid=" + openid + "\"><span>最新通知<em class=\"ok\">" + noticeNum + "</em></span></a></li>");
            }
            //特权
            BLL.wx_ucard_privileges privilegesBLL = new BLL.wx_ucard_privileges();
            int privilegesNum = privilegesBLL.GetRecordCount(" sid=" + id + " and ( userDegree ='0' or userDegree like '%," + degreeNum + ",%' ) and beginDate<='" + DateTime.Now + "' and endDate>='" + DateTime.Now + "' ");
            if (privilegesNum > 0)
            {
                sbStr.Append(" <li><a href=\"ucardPrivileges.aspx?wid=" + wid + "&sid=" + id + "&openid=" + openid + "\"><span>最新特权<em class=\"ok\">" + privilegesNum + "</em></span></a></li>");
            }

            //优惠券
            BLL.wx_ucard_ticket ticketBLL = new BLL.wx_ucard_ticket();
            string ticketStr = ticketBLL.getUserTicketStr(id, user.id, degreeNum, MyCommFun.Obj2Int(user.consumeMoney, 0));
            if (ticketStr != null)
            {
                string[] strArr = Utils.SplitString(ticketStr, ",");
                int ticketNum = 0;
                for (int i = 0; i < strArr.Length; i++)
                {
                    if (strArr[i].Trim().Length > 0)
                    {
                        ticketNum++;
                    }
                }
                sbStr.Append("<li><a href=\"ucardTicket.aspx?wid="+wid+"&sid="+id+"&openid="+openid+"\"><span>会员优惠券<em class=\"ok\">" + ticketNum + "</em></span></a></li>");
            }

            //礼品券
            BLL.wx_ucard_gift giftBll = new BLL.wx_ucard_gift();
            int giftNum = giftBll.GetRecordCount(" sid=" + id + " and   beginDate>='" + DateTime.Now + "' and endDate<'" + DateTime.Now + "'");
            if (giftNum > 0)
            {
                sbStr.Append("<li><a href=\"ucardGift.aspx?wid=" + wid + "&sid=" + id + "&openid=" + openid + "\"><span>会员礼品券<em class=\"ok\">" + giftNum + "</em></span></a></li>");
            }
            litNotice.Text = sbStr.ToString();

        }


        /// <summary>
        /// 绑定积分信息
        /// </summary>
        /// <param name="user"></param>
        private void bindJiFen(Model.wx_ucard_users user)
        {
            StringBuilder jiStr = new StringBuilder("");
            jiStr.Append("<div class=\"jifen-box\"><ul class=\"zongjifen\">");
            jiStr.Append("<li>  <div class=\"fengexian\">  <p>会员总积分</p>  <span>"+MyCommFun.ObjToStr(user.ttScore,"0")+"</span> </div>  </li>");

            jiStr.Append(" <li><a href=\"qiandao.aspx?wid="+wid+"&sid="+id+"&openid="+openid+"\">");
            jiStr.Append("  <div class=\"fengexian\"> <p>签到积分</p> <span>"+MyCommFun.ObjToStr(user.qdScore,"0")+"</span> </div> </a></li>");

            jiStr.Append(" <li><a href=\"shopping_history.aspx?wid=" + wid + "&sid=" + id + "&openid=" + openid + "\">");
            jiStr.Append("<p>消费积分</p>  <span>"+MyCommFun.ObjToStr(user.consumeScore,"0")+"</span></a></li>");

            jiStr.Append(" </ul><div class=\"clr\"></div></div>");
            litJiFen.Text = jiStr.ToString();
        }

        /// <summary>
        /// 今天是否签到
        /// </summary>
        /// <param name="user"></param>
        private void QDInof(Model.wx_ucard_users user)
        {
            BLL.wx_ucard_users_consumeinfo qdBll = new BLL.wx_ucard_users_consumeinfo();
            bool hasQd = qdBll.hasDayQD(id, user.id, DateTime.Now);
            if (hasQd)
            {
                litHasQD.Text = "<em class=\"ok\">今日已签到</em>";
            }
            else
            {
                litHasQD.Text = "<em class=\"error\">今日未签到</em>";
            }
        }
       
    }
}