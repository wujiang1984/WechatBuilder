using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;

namespace WechatBuilder.Web.weixin.ggk
{
    public partial class index : WeiXinPage
    {
        
      public  Model.wx_ggkActionInfo ggkAction = new Model.wx_ggkActionInfo();
        BLL.wx_ggkActionInfo actbll = new BLL.wx_ggkActionInfo();
        BLL.wx_ggkAwardItem itemBll = new BLL.wx_ggkAwardItem();
        BLL.wx_ggkAwardUser ubll = new BLL.wx_ggkAwardUser();
        BLL.wx_ggkUsersTemp utbll = new BLL.wx_ggkUsersTemp();
        string NoAward = "谢谢参与";

        protected void Page_Load(object sender, EventArgs e)
        {
            OnlyWeiXinLook();
            if (!IsPostBack)
            {
                int aid = MyCommFun.RequestInt("aid", 0);
                int wid = MyCommFun.RequestInt("wid", 0);
                string openid = MyCommFun.RequestOpenid();
                if (aid == 0 || wid == 0 || openid.Trim()=="")
                {
                    hidStatus.Value = "-2";
                    hidErrInfo.Value = "访问的参数有问题！";
                    MessageBox.ResponseScript(this,"alert(\"访问的参数有问题\");");
                    return;
                }

                bindData(aid, openid);
              
            }
        }
        /// <summary>
        /// 绑定页面上的基本信息
        /// </summary>
        private void bindData(int id, string openid)
        {
            #region 活动详情
            ggkAction = actbll.GetModel(id);
            if (ggkAction == null)
            {
                hidStatus.Value = "-2";
                hidErrInfo.Value = "该活动不存在！";
                MessageBox.ResponseScript(this, "alert(\"该活动不存在\");");
                return;
            }
            this.Title = ggkAction.actName;
            List<Model.wx_ggkAwardItem> itemlist = itemBll.GetModelList("actId="+id);
            StringBuilder sb = new StringBuilder("");
            Model.wx_ggkAwardItem item = new Model.wx_ggkAwardItem();
            int ttJpNum = 0;
            for (int i = 0; i < itemlist.Count; i++)
            {
                item = itemlist[i];
                sb.Append("<p>" +item.jxName + "：" + item.jpName + "  数量：" + item.jpNum + "</p>");
                ttJpNum += item.jpRealNum.Value;
            }

            if (ggkAction.djPwd.Trim().Length > 0)
            {
                litPwd.Text = "  <p>  <input name=\"\" class=\"px\" id=\"parssword\" type=\"password\" value=\"\" placeholder=\"商家输入兑奖密码\"></p>";
            }

            litJiangXing.Text = sb.ToString();

            litRemark.Text = ggkAction.brief;
            litContentInfo.Text = ggkAction.contractInfo;
            litTTTimes.Text = ggkAction.personMaxTimes == null ? "0" : ggkAction.personMaxTimes.Value.ToString();

            #endregion
            #region 判断

            if (ggkAction.endDate <= DateTime.Now)
            { //说明活动已经结束
                //非活动期间
                hidStatus.Value = "-1";
                hidErrInfo.Value = "活动已结束！";
                return;
            }
            else if (ggkAction.beginDate > DateTime.Now)
            { 
                //活动未开始
                //非活动期间
                hidStatus.Value = "-2";
                hidErrInfo.Value = "活动尚未开始！";
                return;
            }

            Model.wx_ggkAwardUser awardUser = ubll.getZJinfoByOpenid(id, openid);
            if (awardUser != null &&  awardUser.id > 0)
            {  //说明已经中奖了

                litPrize.Text = awardUser.jxName;
              
                hidAwardId.Value = awardUser.id.ToString();
             
              

                if (awardUser.uTel != null && awardUser.uTel.Trim() != "")
                { //说明已经提交成功了 
                    hidStatus.Value = "110";
                    hidErrInfo.Value = "您已中过奖了，欢迎下次再来！";
                    litJp.Text = awardUser.jxName + " " + awardUser.jpName;
                    litSNM.Text = awardUser.sn;
                }
                else
                {  //中奖了，但是未提交 
                    hidStatus.Value = "100";
                    hidErrInfo.Value = "您已中奖，请提交！";
                    litJiangPing.Text = awardUser.jpName;
                    litSnCode.Text = awardUser.sn;

                    litJp.Text = awardUser.jxName + " " + awardUser.jpName;
                    litSNM.Text = awardUser.sn;

                }
                return;
            }


            int dayMaxTimes = ggkAction.dayMaxTimes == null ? 0 : ggkAction.dayMaxTimes.Value;
            int perMaxTimes = ggkAction.personMaxTimes == null ? 0 : ggkAction.personMaxTimes.Value;
            //判断每人最大抽奖次数，是否超过了
            if (personCJTimes(openid, id) >= ggkAction.personMaxTimes)
            {
                hidStatus.Value = "0";
                hidErrInfo.Value = "您已抽过奖了，欢迎下次再来！";
                return;
            }
            if (isTodayOverSum(id, openid, dayMaxTimes))
            {
                hidStatus.Value = "0";
                hidErrInfo.Value = "每人每天只有" + dayMaxTimes.ToString() + "次抽奖机会。";
                return;
            }

          
            #endregion

            #region 计算中奖信息

            /// 处理是否中奖
            /// hidStatus 状态为-1：不能抽奖，直接跳转到end.aspx页面；
            /// 0：抽奖次数超过设置的最高次数；
            /// 1：还可以继续抽奖；
            /// 2：中奖了；
            IList<Model.wx_ggkAwardUser> auserlist = ubll.getHasZJList(id);//已经中奖的人列表
            int ZhongJiangNum = 0;
            if (auserlist != null)
            {
                ZhongJiangNum = auserlist.Count; //已经中奖的人数
            }
            int syZjNum = ttJpNum - ZhongJiangNum; //剩余的奖品数量
            if (syZjNum <= 0)
            {  //说明已经没有奖品了
                hidStatus.Value = "1";
                hidErrInfo.Value = ggkAction.cfcjhf;
                litPrize.Text = NoAward;
                return;
            }
            ggkAction.personNum = MyCommFun.Obj2Int(ggkAction.personNum, 1);
            ggkAction.personMaxTimes = MyCommFun.Obj2Int(ggkAction.personMaxTimes, 1);
            int fenmo = ggkAction.personNum.Value * ggkAction.personMaxTimes.Value;

            Random rd = new Random((int)DateTime.Now.Ticks);
            int radNum = rd.Next(0, fenmo);//从0到fenmo里随机出一个值
            if (radNum < syZjNum)
            {
                //中奖了，再从剩余奖品里抽取一个奖品
                Model.wx_ggkAwardItem dajiang = getZJItem(itemlist, auserlist);
                if (dajiang != null)
                {
                    //这是中的中奖了
                    string snumber = Get_snumber(id);
                    int uId = ubll.Add(id, "", "", openid, dajiang.jxName, dajiang.jpName, snumber);
                    hidStatus.Value = "2";
                    hidErrInfo.Value = "恭喜你中奖了！";
                    litPrize.Text = dajiang.jxName;
                    litJiangPing.Text = dajiang.jpName;
                    hidAwardId.Value = uId.ToString();
                    litSnCode.Text = snumber;

                    litJp.Text = dajiang.jxName + " " + dajiang.jpName;
                    litSNM.Text = snumber;
                    return;
                }
                else
                {
                    //奖品已经全部中完了
                    hidStatus.Value = "1";
                    hidErrInfo.Value = ggkAction.cfcjhf;
                    litPrize.Text = NoAward;
                    return;
                }

            }
            else
            {
                //这个条件说明：未中奖
                //抛出未中奖的数据 
                hidStatus.Value = "1";
                hidErrInfo.Value = ggkAction.cfcjhf;
                litPrize.Text = NoAward;
            }




            #endregion


        }

        #region 方法

        /// <summary>
        /// 取中奖的项目
        /// </summary>
        /// <param name="itemlist">所有的奖品信息</param>
        /// <param name="haszjlist">已经中奖的列表</param>
        /// <returns></returns>
        private Model.wx_ggkAwardItem getZJItem(IList<Model.wx_ggkAwardItem> itemlist, IList<Model.wx_ggkAwardUser> haszjlist)
        {
            IList<Model.wx_ggkAwardItem> zjItemlist = new List<Model.wx_ggkAwardItem>();//剩余奖品列表
           
            Model.wx_ggkAwardItem tmpItem = new Model.wx_ggkAwardItem();
             Model.wx_ggkAwardItem stmpItem = new Model.wx_ggkAwardItem();
            IList<Model.wx_ggkAwardUser> thiszjRs;
           
            for (int i = 0; i < itemlist.Count; i++)
            {
                tmpItem = itemlist[i];
                thiszjRs = (from user in haszjlist where user.jpName == tmpItem.jpName && user.jxName == tmpItem.jxName select user).ToArray<Model.wx_ggkAwardUser>();
                int tmpSYNum = 0;
                if (thiszjRs != null)
                {
                    tmpSYNum = MyCommFun.Obj2Int(tmpItem.jpRealNum) - thiszjRs.Count;
                }
                if (tmpSYNum <= 0)
                {
                    continue;
                }
                for (int j = 0; j < tmpSYNum; j++)
                {
                    stmpItem = new Model.wx_ggkAwardItem();
                    stmpItem.jpName = tmpItem.jpName;
                    stmpItem.jxName = tmpItem.jxName;
                    zjItemlist.Add(stmpItem);
                }
            }

            Random rd = new Random((int)DateTime.Now.Ticks);
            int jpIndex = rd.Next(0, zjItemlist.Count);//从0到zjItemlist.Count里随机出一个值
            return zjItemlist[jpIndex];
        }


        /// <summary>
        /// 判断该用户的抽奖次数
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        private int personCJTimes(string openid, int aid)
        {
            int times = 0;
            times= utbll.GetRecordCount("actId=" + aid + " and openid='"+openid+"'");
            return times;
        }
        /// <summary>
        /// 查询该帐号已经抽了多少次了
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="aid"></param>
        private void ShowHasTimes(string openid, int aid)
        { 
            
        }

        /// <summary>
        /// 判断今天是否已经超出抽奖次数
        /// todayTTTimes:能抽奖的总次数
        /// </summary>
        /// <param name="aid">活动主键id</param>
        /// <param name="openid"></param>
        /// <param name="todayTTTimes">每天的抽奖总次数</param>
        /// <returns></returns>
        private bool isTodayOverSum(int aid, string openid, int todayTTTimes)
        {
            if (todayTTTimes <= 0)
            {
                return true;
            }

            Model.wx_ggkUsersTemp model = new Model.wx_ggkUsersTemp();
            model.openid = openid;
            DateTime todaybegin = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime mingtianBegin = todaybegin.AddDays(1);
            if (!utbll.ExistsOpenid(" actId=" + aid + "  and  openid='" + openid + "' and  createDate>='" + todaybegin + "' and createDate<'" + mingtianBegin + "'"))
            { //第一次，插入
                model.times = 1;
                model.createDate = DateTime.Now;
                model.openid = openid;
                model.actId = aid;
                utbll.Add(model);
                litRemainTimes.Text = (model.times - 1).ToString();
                return false;

            }

            model = utbll.getModelByAidOpenid(aid,openid);
           
            litRemainTimes.Text = (model.times).ToString();

            if (model.times >= todayTTTimes)
            {
                return true;
            }
            else
            {
                model.times += 1;
                utbll.Update(model);
                return false;
            }

        }

        /// <summary>
        /// 返回中奖序列号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Get_snumber(int aid)
        {
            Random rd = new Random((int)DateTime.Now.Ticks);
            int radNum = rd.Next(0, 9);//从0到9里随机出一个值

            return "SNggk" + aid + "_" + MyCommFun.ConvertDateTimeInt(DateTime.Now) + radNum;
        }

        
        #endregion


      
    }

}