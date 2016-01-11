using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using System.Text;

namespace WechatBuilder.Web.weixin.ucard
{
    public partial class shopping_history : WeiXinPage
    {
        protected string openid = "";
        protected int wid = 0;
        protected int sid = 0;//店铺的主键id
        protected int degreeNum = 0;
        protected int uid = 0;
        protected string detailStr = "";
        BLL.wx_ucard_users_consumeinfo cBll = new BLL.wx_ucard_users_consumeinfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            OnlyWeiXinLook();

            openid = MyCommFun.RequestOpenid();
            wid = MyCommFun.RequestInt("wid");
            sid = MyCommFun.RequestInt("sid");
            if (openid == "" || wid == 0 || sid == 0)
            {
                hidStatus.Value = "-1";
                hidErrInfo.Value = "参数错误";
                return;
            }
            bindData();

        }
        private void bindData()
        {
            BLL.wx_ucard_cardinfo cardBll = new BLL.wx_ucard_cardinfo();
            Model.wx_ucard_cardinfo cardinfo = cardBll.GetModelBySid(sid);
            if (cardinfo != null)
            {
                imgTopPic.ImageUrl = cardinfo.shopingPic;
            }
            BLL.wx_ucard_users userBll = new BLL.wx_ucard_users();
            Model.wx_ucard_users user = userBll.GetStoreUserInfo(openid, sid);
            bool hasLq = true;
            if (user == null || user.id <= 0)
            {
                //说明该用户还未领取这个会员卡
                hidStatus.Value = "-1";
                hidErrInfo.Value = "请先领取会员卡";
            }
            else
            {
                bindJiFen(user);
                uid = user.id;
              
                int month = MyCommFun.RequestInt("m");
                bindMonthXFinfo(user, month);

            }


        }

        /// <summary>
        /// 查询该月的消费信息
        /// </summary>
        /// <param name="user"></param>
        /// <param name="month">如果为0，则表示当月的数据，</param>
        private void bindMonthXFinfo(Model.wx_ucard_users user, int month)
        {
            int year = DateTime.Now.Year;
            int todayMonth = DateTime.Now.Month;
            if (month == 0)
            {
                month = todayMonth;
            }
            IList<Model.wx_ucard_users_consumeinfo> clist = cBll.GetModelList("sId=" + sid + " and uid=" + user.id + " and moduleType!='签到' and year(addTime)=" + year + " and month(addTime)=" + month + " order by addTime desc");

            StringBuilder xfSb = new StringBuilder("");
            decimal ttMoney = 0;
            int ttScore = 0;
            if (clist != null && clist.Count > 0)
            {

                Model.wx_ucard_users_consumeinfo c = new Model.wx_ucard_users_consumeinfo();
                for (int i = 0; i < clist.Count; i++)
                {
                    c = clist[i];
                    xfSb.Append("<tr><td>"+c.addTime.Value.ToString("yyyy-MM-dd")+"</td>  <td>"+MyCommFun.Obj2Decimal(c.consumeMoney,0)+"</td> <td>"+MyCommFun.Obj2Int(c.score)+"</td>  </tr>");
                    ttMoney += MyCommFun.Obj2Decimal(c.consumeMoney, 0);
                    ttScore += MyCommFun.Obj2Int(c.score);
                }

                BindDaysDetailInfo(clist);
            }
            litXFStr.Text = xfSb.ToString();
            litttMoney.Text = ttMoney.ToString();
            litttScore.Text = ttScore.ToString();
        }


        /// <summary>
        /// 绑定每天消费的详情
        /// </summary>
        /// <param name="clist"></param>
        private void   BindDaysDetailInfo( IList<Model.wx_ucard_users_consumeinfo> clist)
        {
            StringBuilder dStr=new StringBuilder("");
            Model.wx_ucard_users_consumeinfo tmpCon = clist[0];

            IList<Model.wx_ucard_users_consumeinfo> tmplist = (from c in clist where c.addTime.Value.Year ==tmpCon.addTime.Value.Year && c.addTime.Value.Month == tmpCon.addTime.Value.Month && c.addTime.Value.Day==tmpCon.addTime.Value.Day  select c).ToArray<Model.wx_ucard_users_consumeinfo>();
            if (tmplist != null)
            {
                decimal ttMoney = tmplist.Sum(t => t.consumeMoney == null ? 0 : t.consumeMoney.Value);
                int ttScore = tmplist.Sum(t => t.score == null ? 0 : t.score.Value);
                //处理逻辑
                dStr.Append(" <div id=\"test"+tmpCon.id+"-header\" class=\"accordion_headings\">");
                dStr.Append("  <div class=\"tab\"> <span class=\"title\">" + tmpCon.addTime.Value.ToString("yyyy-MM-dd") + "消费详情<p>消费" + ttMoney + "元 获得积分" + ttScore + "分</p>");
                 dStr.Append(" </span> </div>");
                 dStr.Append(" <div id=\"test"+tmpCon.id+"-content\" style=\"display: none; overflow: hidden;\">");
                 dStr.Append(" <div class=\"accordion_child\">");
                 dStr.Append(" <table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"integral_table\">");
                 dStr.Append("<thead> <tr> <th>消费详情</th> <th>消费金额</th> <th>积分</th> </tr> </thead> <tbody>");

                for (int i = 0; i < tmplist.Count; i++)
                {
                    dStr.Append(" <tr> <td>"+tmplist[i].moduleActionName+"</td> <td>"+MyCommFun.Obj2Decimal( tmplist[i].consumeMoney,0)+"</td>  <td>"+MyCommFun.Obj2Int(tmplist[i].score)+"</td> </tr>");
                    clist.Remove(tmplist[i]);
                }
                dStr.Append(" </tbody> <tfoot> <tr> <td class=\"right\">合计</td> <td><span class=\"heji\">" + ttMoney + "元 </span></td> <td><span class=\"heji\">"+ttScore+" 积分 </span></td>");
                dStr.Append(" </tr> </tfoot> </table> </div> </div> </div>");
                detailStr += dStr.ToString();
                //最终
                if (clist.Count > 0)
                {
                    BindDaysDetailInfo(clist);
                }
            }

            
        }
        

        /// <summary>
        /// 绑定积分信息
        /// </summary>
        /// <param name="user"></param>
        private void bindJiFen(Model.wx_ucard_users user)
        {
            StringBuilder jiStr = new StringBuilder("");
            jiStr.Append("<div class=\"jifen-box\" style=\"margin-top:13px;\"><ul class=\"zongjifen\">");
            jiStr.Append("<li>  <div class=\"fengexian\">  <p>会员总积分</p>  <span>" + MyCommFun.ObjToStr(user.ttScore, "0") + "</span> </div>  </li>");

            jiStr.Append(" <li><a href=\"qiandao.aspx?wid=" + wid + "&sid=" + sid + "&openid=" + openid + "\">");
            jiStr.Append("  <div class=\"fengexian\"> <p>签到积分</p> <span>" + MyCommFun.ObjToStr(user.qdScore, "0") + "</span> </div> </a></li>");

            jiStr.Append(" <li><a href=\"shopping_history.aspx?wid=" + wid + "&sid=" + sid + "&openid=" + openid + "\">");
            jiStr.Append("<p>消费积分</p>  <span>" + MyCommFun.ObjToStr(user.consumeScore, "0") + "</span></a></li>");

            jiStr.Append(" </ul><div class=\"clr\"></div></div>");
            litJiFen.Text = jiStr.ToString();
        }

    }
}