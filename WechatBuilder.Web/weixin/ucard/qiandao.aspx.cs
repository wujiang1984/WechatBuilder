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
    public partial class qiandao : WeiXinPage
    {
        protected string openid = "";
        protected int wid = 0;
        protected int sid = 0;//店铺的主键id
        protected int degreeNum = 0;
        protected int uid = 0;

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
                imgTopPic.ImageUrl = cardinfo.qiandaoPic;
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
                QDInof(user);
                int month = MyCommFun.RequestInt("m");
                bindMonthQD(user, month);

            }

            
        }

        /// <summary>
        /// 查询该月的签到信息
        /// </summary>
        /// <param name="user"></param>
        /// <param name="month">如果为0，则表示当月的数据，</param>
        private void bindMonthQD(Model.wx_ucard_users user,int month)
        {
            int year = DateTime.Now.Year;
            int todayMonth = DateTime.Now.Month;
            if (month == 0)
            {
                month = todayMonth;
            }
            IList<Model.wx_ucard_users_consumeinfo> qdlist = cBll.GetModelList("sId=" + sid + " and uid=" + user.id + " and moduleType='签到' and year(addTime)=" + year + " and month(addTime)=" + month + " order by addTime desc");

            DateTime thisBeginTimes = DateTime.Parse(year + "-" + month + "-1");
            DateTime thisEndTimes;
            if (todayMonth == month)
            {
                //当前月
                thisEndTimes = DateTime.Now;
            }
            else
            { 
                //非当前月
                thisEndTimes = thisBeginTimes.AddMonths(1).AddDays(-1);
            }

            int maxDays = thisEndTimes.Day;
            StringBuilder qdStr = new StringBuilder("");
            DateTime tmpTimes = new DateTime();
            Model.wx_ucard_users_consumeinfo tmpConsume = new Model.wx_ucard_users_consumeinfo();
            int totqdjifen = 0;
            for (int i = maxDays; i > 0; i--)
            { 
                //待完成
                tmpTimes = DateTime.Parse(year+"-"+month+"-"+i);
                tmpConsume = getqdInfo(qdlist, tmpTimes);
                if (tmpConsume != null)
                { //已经签到
                    qdStr.Append(getqdStr(tmpTimes,tmpConsume.score.Value,true));
                    totqdjifen += tmpConsume.score.Value;
                }
                else
                { 
                    //未签到
                    qdStr.Append(getqdStr(tmpTimes,0, false));
                }

            }
            litQDStr.Text = qdStr.ToString();
            litTTqdScore.Text = totqdjifen.ToString();
        }

        private Model.wx_ucard_users_consumeinfo getqdInfo(IList<Model.wx_ucard_users_consumeinfo> qdlist, DateTime thisTimes)
        { 
            IList<Model.wx_ucard_users_consumeinfo> tqdlist=(from qd in qdlist where qd.addTime.Value.Year==thisTimes.Year &&  qd.addTime.Value.Month==thisTimes.Month && qd.addTime.Value.Day==thisTimes.Day select qd ).ToArray<Model.wx_ucard_users_consumeinfo>();
            if(tqdlist==null || tqdlist.Count<=0)
            {
                return null;
            }
            else
            {
                return tqdlist[0];
            }
        
        }

        /// <summary>
        /// 签到的字符串
        /// </summary>
        /// <param name="times">日期</param>
        /// <param name="jifen">签到得到的积分</param>
        /// <param name="isQD">签到了</param>
        /// <returns></returns>
        private string  getqdStr(DateTime times, int jifen, bool isQD)
        {
            string str = "";
            string timesStr = times.ToString("MM月dd日");
            string qx = Utils.GetDayName(times);//星期

            if (isQD)
            {
                //签到了
                str = " <tr> <td>" + timesStr + " " + qx + "</td>  <td><span class=\"yqian\">已签</span></td>  <td>+" + jifen + "</td></tr>";
            }
            else
            {
                str = "<tr> <td>" + timesStr + " " + qx + "</td>  <td><span class=\"wqian\">未签</span></td>  <td>+0</td></tr>";
            }


            return str;
        }
        /// <summary>
        /// 今天是否签到
        /// </summary>
        /// <param name="user"></param>
        private void QDInof(Model.wx_ucard_users user)
        {

            bool hasQd = cBll.hasDayQD(sid, user.id, DateTime.Now);
            if (hasQd)
            {
                litQDinfo.Text = "您今天已经签到了！";
            }
            else
            {
                litQDinfo.Text = "点击这里签到赚积分";
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