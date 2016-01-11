using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;

namespace WechatBuilder.Web.weixin.dzp
{
    /// <summary>
    /// 大转盘
    /// </summary>
    public partial class index : WeiXinPage
    {
        /// <summary>
        /// ErrLevel:100表示正确无误，1表示严重错误，2表示业务方面有问题;3直接跳转到结束页面
        /// </summary>
        public int ErrLevel = 100;
        public string ErrorInfo = "";
        public  Model.wx_dzpActionInfo dzpAction;
        public int picIndex = 0;
        public int aid = 0;
        public int wid = 0;
        public bool isZhJing = false;
        public string openid = "";
        public string shuzu = "";
        BLL.wx_dzpAwardUser ubll = new BLL.wx_dzpAwardUser();
        BLL.wx_dzpUsersTemp utbll = new BLL.wx_dzpUsersTemp();
        BLL.wx_dzpActionInfo actBll = new BLL.wx_dzpActionInfo();
        BLL.wx_dzpAwardItem itemBll = new BLL.wx_dzpAwardItem();

        protected void Page_Load(object sender, EventArgs e)
        {
            OnlyWeiXinLook();
            aid = MyCommFun.RequestInt("aid", 0);
            wid = MyCommFun.RequestInt("wid", 0);
            openid = MyCommFun.RequestOpenid();

            if (aid == 0 || wid == 0 || openid.Trim() == "")
            {
                ErrLevel = 1;
                ErrorInfo = "访问参数错误！";
                return;
            }
            BindData();
        }


        private void BindData()
        {
            dzpAction = actBll.GetModel(aid);
            IList<Model.wx_dzpAwardItem> itemlist = itemBll.GetModelList("actId=" + aid);
            if (dzpAction == null || itemlist == null || itemlist.Count <= 0)
            {
                ErrLevel = 1;
                ErrorInfo = "未获得到数据";
                return;
            }
            this.Title = dzpAction.actName;

            if (dzpAction.endDate <= DateTime.Now)
            {   //说明活动已经结束
                ErrLevel = 101;
                ErrorInfo = "活动已结束";
                return;
            }

            StringBuilder sb = new StringBuilder("");
            Model.wx_dzpAwardItem item = new Model.wx_dzpAwardItem();
            int ttJpNum = 0;
            shuzu = "[";
            for (int i = 0; i < itemlist.Count; i++)
            {
                item = itemlist[i];
                sb.Append("<p>" + item.jxName + "：" + item.jpName + "  数量：" + item.jpNum + "</p>");
                ttJpNum += item.jpRealNum.Value;
                picIndex++;
                if (i < (itemlist.Count - 1))
                {
                    shuzu += item.jiaodu_min + ",";
                }
                else
                {
                    shuzu += item.jiaodu_min;
                }
            }
            shuzu += "]";
            litJiangXing.Text = sb.ToString();
            litRemark.Text = dzpAction.brief;
            litContentInfo.Text = dzpAction.contractInfo;

            littotTimes.Text = dzpAction.personMaxTimes == null ? "0" : dzpAction.personMaxTimes.Value.ToString();
            litdaysTimes.Text = dzpAction.dayMaxTimes == null ? "0" : dzpAction.dayMaxTimes.Value.ToString();
            if (dzpAction.djPwd.Trim().Length > 0)
            {
                litPwd.Text = "  <p>  <input name=\"\" class=\"px\" id=\"parssword\" type=\"password\" value=\"\" placeholder=\"商家输入兑奖密码\"></p>";
            }
            if (dzpAction.beginDate > DateTime.Now)
            {
                hidStatus.Value = "-2";
                ErrorInfo = hidErrInfo.Value = "活动尚未开始";
            }
            int hasCjTimes = utbll.getCJCiShu(aid, openid);//返回该用户的抽奖次数
            this.litHasUsedTimes.Text = hasCjTimes.ToString();

            int dayMaxTimes = dzpAction.dayMaxTimes == null ? 0 : dzpAction.dayMaxTimes.Value;
            int perMaxTimes = dzpAction.personMaxTimes == null ? 0 : dzpAction.personMaxTimes.Value;
            //判断是否中奖了

            Model.wx_dzpAwardUser award = ubll.getZJinfoByOpenid(aid, openid);
            if (award != null && award.id>0)
            {    //您中奖了
                if (award.uTel != null && award.uTel.ToString().Trim() != "")
                {//已经中奖，并且提交了
                    litJp.Text = "[" + award.jxName + "] " + award.jpName;
                    litSNM.Text = award.sn;
                    isZhJing = true;
                }
                else
                { //已经中奖，但是未提交
                    hidStatus.Value = "100";
                    litzjlJP.Text = "[" + award.jxName + "] " + award.jpName;
                    litzjlSN.Text = award.sn;
                    hidAwardId.Value = award.id.ToString();

                    litJp.Text = "[" + award.jxName + "] " + award.jpName;
                    litSNM.Text = award.sn;
                }
              
              
            }
            else
            {
                //判断每人最大抽奖次数，是否超过了
                if (hasCjTimes >= dzpAction.personMaxTimes)
                {
                  hidStatus.Value = "2";
                  litOtherTip.Text = "<p class='red'>您已经抽了" + hasCjTimes + "次了。</p>";
                }
                if (isTodayOverSum(dayMaxTimes))
                {
                    hidStatus.Value = "2";
                    litOtherTip.Text = "<p class='red'>每人每天只有" + dayMaxTimes.ToString() + "次抽奖机会，您已经使用完了。</p>";
                }

            }

            

        }


        #region 方法



        /// <summary>
        /// 判断今天是否已经超出抽奖次数
        /// todayTTTimes:能抽奖的总次数
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="todayTTTimes">每天的抽奖总次数</param>
        /// <returns></returns>
        private bool isTodayOverSum( int todayTTTimes)
        {
            if (todayTTTimes <= 0)
            {
                return true;
            }
 
            DateTime todaybegin = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime mingtianBegin = todaybegin.AddDays(1);
            if (!utbll.ExistsOpenid(" actId=" + aid + "  and  openid='" + openid + "' and  createDate>='" + todaybegin + "' and createDate<'" + mingtianBegin + "'"))
            {   
                return false;

            }

            Model.wx_dzpUsersTemp model = utbll.getModelByAidOpenid(aid, openid);
            if (model.times >= todayTTTimes)
            {
                return true;
            }
            else
            {
                
                return false;
            }

        }

        #endregion
    }
}