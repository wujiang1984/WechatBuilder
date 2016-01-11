using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;

namespace WechatBuilder.Web.weixin.sticket
{
    public partial class index : WeiXinPage
    {
        Model.wx_sTicket sstAction = new Model.wx_sTicket();
        BLL.wx_sTicket actbll = new BLL.wx_sTicket();
        BLL.wx_sttAwardItem itemBll = new BLL.wx_sttAwardItem();
        BLL.wx_sttAwardUser ubll = new BLL.wx_sttAwardUser();
        public string stitle = "";
        public string sbrief = "";
        /// <summary>
        /// hidStatus：-2,隐藏中奖卡，弹出错误信息；
        ///            -1，直接跳转到结束页面；
        ///            2，中奖了，显示中奖卡；
        ///            3,中奖的最终结果展示；中奖卡隐藏；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            OnlyWeiXinLook();
            if (!IsPostBack)
            {
                int aid = MyCommFun.RequestInt("aid", 0);
                int wid = MyCommFun.RequestInt("wid", 0);
                string openid = MyCommFun.RequestOpenid();
                if (aid == 0 || wid == 0 || openid.Trim() == "")
                {
                    hidStatus.Value = "-2";
                    hidErrInfo.Value = "访问的参数有问题";
                    return;
                }

                bindData(aid, openid);

            }
        }
        
        /// <summary>
        /// 绑定页面上的基本信息
        /// </summary>
        /// <param name="id">活动主键id</param>
        /// <param name="openid"></param>
        private void bindData(int id, string openid)
        {
            #region 活动详情
            sstAction = actbll.GetModel(id);
            if (sstAction == null)
            {
                hidStatus.Value = "-2";
                hidErrInfo.Value = "该活动不存在！";
                return;
            }
            this.Title = sstAction.actionName;
            stitle = sstAction.actionName;
            sbrief = sstAction.brief;
            List<Model.wx_sttAwardItem> itemlist = itemBll.GetModelList("actId=" + id);
            StringBuilder sb = new StringBuilder("");
            Model.wx_sttAwardItem item = new Model.wx_sttAwardItem();
            int ttJpNum = 0;//最大的奖品数量
            for (int i = 0; i < itemlist.Count; i++)
            {
                item = itemlist[i];
                sb.Append("<p>优惠券名称:" + item.jpName + "  数量：" + item.jpRealNum + "</p>");
                ttJpNum += item.jpRealNum.Value;
            }
            zjpic.ImageUrl = sstAction.bannerPic == null ? "images/banner.jpg" : sstAction.bannerPic;
            litJiangXing.Text = sb.ToString();

            litusedRemark.Text = sstAction.usedRemark;
            litaContent.Text = sstAction.aContent ;
           
            #endregion
            #region 判断

            if (sstAction.endDate <= DateTime.Now)
            { //说明活动已经结束
                //非活动期间
                hidStatus.Value = "-1";
                hidErrInfo.Value = "活动已结束！";
                return;
            }
            else if (sstAction.beginDate > DateTime.Now)
            {
                //活动未开始
                //非活动期间
                hidStatus.Value = "-2";
                hidErrInfo.Value = "活动尚未开始！";
                return;
            }
           
            #endregion

            #region 计算中奖信息

             
            Model.wx_sttAwardUser awardUser = ubll.getZJinfoByOpenid(id, openid);
            if (awardUser != null && awardUser.id > 0 )
            {
              

                if (awardUser.uTel != null && awardUser.uTel.Trim() != "")
                {
                    //说明已经提交成功了
                    hidStatus.Value = "3";
                    hidErrInfo.Value = "恭喜你中奖了！";
                    litJp.Text = awardUser.jpName;
                    hidAwardId.Value = awardUser.id.ToString();
                    litSNM.Text = awardUser.sn;
                }
                else
                { //未提交
                    //中奖了
                    hidStatus.Value = "2";
                    hidErrInfo.Value = "恭喜你中奖了！";
                    litJiangPing.Text = awardUser.jpName;
                    hidAwardId.Value = awardUser.id.ToString();
                    litSn.Text = awardUser.sn;
                    
                }
                return;
            }

            IList<Model.wx_sttAwardUser> auserlist = ubll.getHasZJList(id);//已经中奖的人列表
            int ZhongJiangNum = 0; //中奖人数
            if (auserlist != null)
            {
                ZhongJiangNum = auserlist.Count; //已经中奖的人数
            }
            int syZjNum = ttJpNum - ZhongJiangNum; //剩余的奖品数量
            if (syZjNum <= 0)
            {  //说明已经没有奖品了
                hidStatus.Value = "-2";
                hidErrInfo.Value = "优惠券已经被领取完了，请下次再来吧！";
                return;
            }
            
            Random rd = new Random((int)DateTime.Now.Ticks);
            int radNum = rd.Next(0, syZjNum);//从0到剩余的奖品里随机出一个值
            if (radNum < syZjNum)
            {
                //中奖了，再从剩余奖品里抽取一个奖品
                Model.wx_sttAwardItem dajiang = getZJItem(itemlist, auserlist);
                if (dajiang != null)
                {
                  
                    //这是中的中奖了
                    string snumber = Get_snumber(id);
                    int uId = ubll.Add(id, "", "", openid, dajiang.jpName, snumber);
                    hidStatus.Value = "2";
                    hidErrInfo.Value = "恭喜你中奖了！";
                    litJiangPing.Text = dajiang.jpName;
                    hidAwardId.Value = uId.ToString();
                    litSn.Text = snumber;
                    return;
                }
                else
                {
                    //奖品已经全部中完了
                    hidStatus.Value = "-2";
                    hidErrInfo.Value = "优惠券已经被领取完了，请下次再来吧！";
                    return;
                }

            }
            else
            {
                //这个条件说明：未中奖
                //抛出未中奖的数据 
                hidStatus.Value = "-2";
                hidErrInfo.Value = "优惠券已经被领取完了，请下次再来吧！";
                return;
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
        private Model.wx_sttAwardItem getZJItem(IList<Model.wx_sttAwardItem> itemlist, IList<Model.wx_sttAwardUser> haszjlist)
        {
            IList<Model.wx_sttAwardItem> zjItemlist = new List<Model.wx_sttAwardItem>();//剩余奖品列表

            Model.wx_sttAwardItem tmpItem = new Model.wx_sttAwardItem();
            Model.wx_sttAwardItem stmpItem = new Model.wx_sttAwardItem();
            IList<Model.wx_sttAwardUser> thiszjRs;

            for (int i = 0; i < itemlist.Count; i++)
            {
                tmpItem = itemlist[i];
                thiszjRs = (from user in haszjlist where user.jpName == tmpItem.jpName  select user).ToArray<Model.wx_sttAwardUser>();
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
                    stmpItem = new Model.wx_sttAwardItem();
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
        /// 返回中奖序列号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Get_snumber(int aid)
        {
            Random rd = new Random((int)DateTime.Now.Ticks);
            int radNum = rd.Next(0, 9);//从0到9里随机出一个值

            return "SNsticket" + aid + "_" + MyCommFun.ConvertDateTimeInt(DateTime.Now) + radNum;
        }


        #endregion


    }
}