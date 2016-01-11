using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WechatBuilder.Common;

namespace WechatBuilder.Web.weixin.dzp
{
    /// <summary>
    /// dzpAct 的摘要说明
    /// </summary>
    public class dzpAct : IHttpHandler
    {
        BLL.wx_dzpActionInfo actbll = new BLL.wx_dzpActionInfo();
        BLL.wx_dzpAwardUser ubll = new BLL.wx_dzpAwardUser();
        BLL.wx_dzpUsersTemp utbll = new BLL.wx_dzpUsersTemp();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            string _action = MyCommFun.QueryString("myact");
            int aid = MyCommFun.RequestInt("aid");
            string openid = MyCommFun.RequestOpenid();  //得到微信用户的openid
            if (_action == "choujiang")
            {
                Dictionary<string, string> jsonDict = new Dictionary<string, string>();

                try
                {
                    //抽奖
                    Model.wx_dzpActionInfo dzpAction = new Model.wx_dzpActionInfo();
                  
                    BLL.wx_dzpAwardItem itemBll = new BLL.wx_dzpAwardItem();



                    #region 判断
                    int wid = MyCommFun.RequestInt("wid");
                    if (aid == 0 || wid == 0 || openid.Trim() == "")
                    {
                        jsonDict.Add("error", "sys");
                        jsonDict.Add("content", "参数错误！");
                        context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                        return;

                    }
                    dzpAction = actbll.GetModel(aid);
                    if (dzpAction == null)
                    {
                        jsonDict.Add("error", "sys");
                        jsonDict.Add("content", "参数错误！");
                        context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                        return;
                    }

                    if (dzpAction.endDate <= DateTime.Now)
                    { //说明活动已经结束
                        //非活动期间
                        jsonDict.Add("error", "end");
                        jsonDict.Add("content", "活动已结束");
                        context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                        return;
                    }
                    else if (dzpAction.beginDate > DateTime.Now)
                    {
                        //活动未开始
                        //非活动期间
                        jsonDict.Add("error", "nostart");
                        jsonDict.Add("content", "活动未开始");
                        context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                        return;
                    }
                    int dayMaxTimes = dzpAction.dayMaxTimes == null ? 0 : dzpAction.dayMaxTimes.Value;
                    int perMaxTimes = dzpAction.personMaxTimes == null ? 0 : dzpAction.personMaxTimes.Value;
                    //判断每人最大抽奖次数，是否超过了
                    if (personCJTimes(openid, aid) >= dzpAction.personMaxTimes)
                    {
                        jsonDict.Add("error", "notimes");
                        jsonDict.Add("content", "您已抽过奖了，欢迎下次再来！");
                        context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                        return;
                    }
                    if (isTodayOverSum(aid, openid, dayMaxTimes))
                    {
                        jsonDict.Add("error", "notimes");
                        jsonDict.Add("content", "每人每天只有" + dayMaxTimes.ToString() + "次抽奖机会。");
                        context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                        return;
                    }
                    Model.wx_dzpAwardUser award = ubll.getZJinfoByOpenid(aid, openid);
                    if (award != null)
                    {
                        //您中奖了
                        jsonDict.Add("error", "notimes");
                        jsonDict.Add("content", "您已奖了，欢迎下次再来！");
                        context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                        return;
                    }


                    #endregion

                    #region 计算中奖信息

                    /// 处理是否中奖
                    /// hidStatus 状态为-1：不能抽奖，直接跳转到end.aspx页面；
                    /// 0：抽奖次数超过设置的最高次数；
                    /// 1：还可以继续抽奖；
                    /// 2：中奖了；

                    List<Model.wx_dzpAwardItem> itemlist = itemBll.GetModelList("actId=" + aid);//该活动的所有奖项信息
                    int ttJpNum = 0;
                    for (int i = 0; i < itemlist.Count; i++)
                    {
                        ttJpNum += itemlist[i].jpRealNum.Value;
                    }


                    IList<Model.wx_dzpAwardUser> auserlist = ubll.getHasZJList(aid);//已经中奖的人列表
                    int ZhongJiangNum = 0;
                    if (auserlist != null)
                    {
                        ZhongJiangNum = auserlist.Count; //已经中奖的人数
                    }

                    int syZjNum = ttJpNum - ZhongJiangNum; //剩余的奖品数量
                    if (syZjNum <= 0)
                    {  //说明已经没有奖品了
                        jsonDict.Add("error", "-1");
                        jsonDict.Add("content", dzpAction.cfcjhf);
                        context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                        return;
                    }
                    dzpAction.personNum = MyCommFun.Obj2Int(dzpAction.personNum, 1);
                    dzpAction.personMaxTimes = MyCommFun.Obj2Int(dzpAction.personMaxTimes, 1);
                    int fenmo = dzpAction.personNum.Value * dzpAction.personMaxTimes.Value;

                    Random rd = new Random((int)DateTime.Now.Ticks);
                    int radNum = rd.Next(0, fenmo);//从0到fenmo里随机出一个值
                    if (radNum < syZjNum)
                    {
                        //中奖了，再从剩余奖品里抽取一个奖品
                        Model.wx_dzpAwardItem dajiang = getZJItem(itemlist, auserlist);
                        if (dajiang != null)
                        {
                            //这是中的中奖了
                            string snumber = Get_snumber(aid);
                            int uId = ubll.Add(aid, "", "", openid, dajiang.jxName, dajiang.jpName, snumber);

                            jsonDict.Add("error", "succ");
                            jsonDict.Add("content", "恭喜你中奖了!");
                            jsonDict.Add("sortid", dajiang.sort_id.Value.ToString());
                            jsonDict.Add("jxname", dajiang.jxName);
                            jsonDict.Add("jpname", dajiang.jpName);
                            jsonDict.Add("uid", uId.ToString());
                            jsonDict.Add("sn", snumber);
                            context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                            return;
                        }
                        else
                        {
                            //奖品已经全部中完了
                            jsonDict.Add("error", "-1");
                            jsonDict.Add("content", dzpAction.cfcjhf);
                            context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                            return;
                        }

                    }
                    else
                    {
                        //这个条件说明：未中奖
                        //抛出未中奖的数据 

                        jsonDict.Add("error", "-1");
                        jsonDict.Add("content", dzpAction.cfcjhf);
                        context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                        return;

                    }




                    #endregion
                }
                catch (Exception ex)
                {
                    jsonDict.Add("error", "sys");
                    jsonDict.Add("content", "计算抽奖出现未知错误，请联系管理员！");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }




            }
            else if (_action == "update")
            {
                try
                {
                    #region 提交手机
                    /// 提交手机号码
                    string tel = MyCommFun.QueryString("tel");
                    string pwd = MyCommFun.QueryString("pwd");
                    string snumber = MyCommFun.QueryString("snumber");
                    int id = MyCommFun.RequestInt("id");

                    if (aid == 0 || id == 0 || snumber == "" || tel == "")
                    {
                        context.Response.Write("{\"msg\":\"提交出现异常！！\",\"success\":\"0\"}");
                        return;
                    }

                    if ((pwd.Length>0) &&( !actbll.ExistsPwd(aid, pwd)))
                    {
                        context.Response.Write("{\"msg\":\"商家兑换密码错误！！\",\"success\":\"0\"}");
                        return;
                    }


                    BLL.wx_dzpAwardUser ubll = new BLL.wx_dzpAwardUser();
                    Model.wx_dzpAwardUser model = ubll.GetModel(id);
                    if (model == null)
                    {
                        context.Response.Write("{\"msg\":\"提交出现异常2！！\",\"success\":\"0\"}");
                        return;
                    }
                    model.uTel = tel;
                    if (pwd.Length > 0)
                    {
                        model.hasLingQu = true;
                    }
                    else
                    {
                        model.hasLingQu = false;
                    }
                    ubll.Update(model);

                    context.Response.Write("{\"msg\":\"提交成功！\",\"success\":\"1\"}");
                    return;
                    #endregion

                }
                catch
                {
                    context.Response.Write("{\"msg\":\"提交出现异常！！\",\"success\":\"0\"}");

                    return;
                }

            }
        }


        #region 方法

        /// <summary>
        /// 取中奖的项目
        /// </summary>
        /// <param name="itemlist">所有的奖品信息</param>
        /// <param name="haszjlist">已经中奖的列表</param>
        /// <returns></returns>
        private Model.wx_dzpAwardItem getZJItem(IList<Model.wx_dzpAwardItem> itemlist, IList<Model.wx_dzpAwardUser> haszjlist)
        {
            IList<Model.wx_dzpAwardItem> zjItemlist = new List<Model.wx_dzpAwardItem>();//剩余奖品列表

            Model.wx_dzpAwardItem tmpItem = new Model.wx_dzpAwardItem();
            Model.wx_dzpAwardItem stmpItem = new Model.wx_dzpAwardItem();
            IList<Model.wx_dzpAwardUser> thiszjRs;

            for (int i = 0; i < itemlist.Count; i++)
            {
                tmpItem = itemlist[i];
                thiszjRs = (from user in haszjlist where user.jpName == tmpItem.jpName && user.jxName == tmpItem.jxName select user).ToArray<Model.wx_dzpAwardUser>();
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
                    stmpItem = new Model.wx_dzpAwardItem();
                    stmpItem.jpName = tmpItem.jpName;
                    stmpItem.jxName = tmpItem.jxName;
                    stmpItem.sort_id = tmpItem.sort_id;
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
            times = utbll.GetRecordCount("actId=" + aid + " and openid='" + openid + "'");
            return times;
        }

        /// <summary>
        /// 判断今天是否已经超出抽奖次数
        /// todayTTTimes:能抽奖的总次数
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="todayTTTimes">每天的抽奖总次数</param>
        /// <returns></returns>
        private bool isTodayOverSum(int aid, string openid, int todayTTTimes)
        {
            if (todayTTTimes <= 0)
            {
                return true;
            }

            Model.wx_dzpUsersTemp model = new Model.wx_dzpUsersTemp();
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
                return false;
            }

            model = utbll.getModelByAidOpenid(aid, openid);
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

            return "SNdzp" + aid + "_" + MyCommFun.ConvertDateTimeInt(DateTime.Now) + radNum;
        }


        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}