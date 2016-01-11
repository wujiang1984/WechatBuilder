using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WechatBuilder.Common;

namespace WechatBuilder.Web.weixin.ucard
{
    /// <summary>
    /// ucardprocess 的摘要说明
    /// </summary>
    public class ucardprocess : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            string _action = MyCommFun.QueryString("myact");
            string openid = MyCommFun.RequestOpenid();  //得到微信用户的openid
            Dictionary<string, string> jsonDict = new Dictionary<string, string>();
            int sid = MyCommFun.RequestInt("sid");
            int uid = 0;
            BLL.wx_ucard_store storeBll = new BLL.wx_ucard_store();
            BLL.wx_ucard_users_consumeinfo conBll = new BLL.wx_ucard_users_consumeinfo();
            BLL.wx_ucard_score scoreBll = new BLL.wx_ucard_score();
            BLL.wx_ucard_users userBll = new BLL.wx_ucard_users();
            Model.wx_ucard_users_consumeinfo consume = new Model.wx_ucard_users_consumeinfo();
            Model.wx_ucard_score score = new Model.wx_ucard_score();
            Model.wx_ucard_store store = storeBll.GetModel(sid);
            if (store == null)
            {
                jsonDict.Add("ret", "err");
                jsonDict.Add("msg", "店铺不存在");
                context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                return;
            }

            if (_action == "userreg")
            {
                #region //用户第一次领取卡
                jsonDict = new Dictionary<string, string>();

                if (sid == 0)
                {
                    jsonDict.Add("ret", "error");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }
                string tel = MyCommFun.QueryString("tel");
                string realName = MyCommFun.QueryString("truename");

                WechatBuilder.Model.wx_ucard_users user = userBll.GetStoreUserInfo(openid, sid);
                if (user == null)
                { //第一次添加
                    user = new Model.wx_ucard_users();
                    user.mobile = tel;
                    user.realName = realName;
                    user.regTime = DateTime.Now;
                    user.sid = sid;
                    user.openid = openid;
                    user.ttScore = 0;
                    user.consumeScore = 0;
                    user.qdScore = 0;
                    user.consumeMoney = 0;
                    user.regIp = MXRequest.GetIP();
                    int ret = userBll.Add(user);
                    if (ret > 0)
                    {
                        jsonDict.Add("ret", "succ");
                        context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    }
                    else
                    {
                        jsonDict.Add("ret", "err");
                        context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    }

                }
                else
                {
                    user.mobile = tel;
                    user.realName = realName;
                    user.regTime = DateTime.Now;
                    user.sid = sid;
                    user.openid = openid;
                    user.regIp = MXRequest.GetIP();
                    bool ret = userBll.Update(user);
                    if (ret)
                    {
                        jsonDict.Add("ret", "succ");
                        context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    }
                    else
                    {
                        jsonDict.Add("ret", "err");
                        context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    }

                }

                context.Response.End();
                #endregion

            }
            else if (_action == "qiandao")
            {
                #region 签到
                jsonDict = new Dictionary<string, string>();
                sid = MyCommFun.RequestInt("sid");
                uid = MyCommFun.RequestInt("uid");
                if (sid == 0 || uid == 0)
                {
                    jsonDict.Add("ret", "error");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }

                bool hasqd = conBll.hasDayQD(sid, uid, DateTime.Now);
                int retScore = 0;
                if (!hasqd)
                {
                    //新增
                    //取签到积分策略
                    score = scoreBll.GetStoreModel(sid);
                    if (score != null)
                    {
                        //判断是否6天连续签到，并且6天内没有给额外的奖励

                        DateTime day6before = DateTime.Now.AddDays(-6);

                        int record = conBll.GetRecordCount("sId=" + sid + " and uid=" + uid + " and moduleType='签到' and addTime>='" + day6before.ToShortDateString() + "' and addTime<'" + DateTime.Now.ToShortDateString() + "' and  moduleActionId=6 ");

                        if (record >= 5)
                        {
                            consume = new Model.wx_ucard_users_consumeinfo();
                            consume.sId = sid;
                            consume.uid = uid;
                            consume.moduleType = "签到";
                            consume.moduleActionName = "连续6天签到奖励";
                            consume.moduleActionId = 6;
                            consume.score = MyCommFun.Obj2Int(score.qiandao6Score) + score.qiandaoScore.Value;
                            conBll.AddJiFen(consume, 0);
                            retScore = MyCommFun.Obj2Int(score.qiandao6Score) + score.qiandaoScore.Value;
                        }
                        else
                        {
                            consume = new Model.wx_ucard_users_consumeinfo();
                            consume.sId = sid;
                            consume.uid = uid;
                            consume.moduleType = "签到";
                            consume.score = score.qiandaoScore.Value;
                            conBll.AddJiFen(consume, 0);
                            retScore = score.qiandaoScore.Value;
                        }

                    }
                }

                jsonDict.Add("ret", "succ");
                jsonDict.Add("msg", "+" + retScore + "分，明天继续");
                context.Response.Write(MyCommFun.getJsonStr(jsonDict));

                #endregion

            }
            else if (_action == "tequan")
            {
                #region  //消费： 特权 ,注意，只有在新增这个的时候记录user表总积分，修改的时候 对user表的总积分和金额先减后加

                jsonDict = new Dictionary<string, string>();
                sid = MyCommFun.RequestInt("sid");  //店铺id
                uid = MyCommFun.RequestInt("uid");//用户id
                string sn = MyCommFun.QueryString("sncode");
                string pwd = MyCommFun.QueryString("parssword");
                float money = MyCommFun.RequestFloat("money", 0);
                int pid = MyCommFun.RequestInt("pid");//特权主键id
                string type = MyCommFun.QueryString("type");//tequan:特权
                if (sid == 0 || uid == 0 || pid == 0)
                {
                    jsonDict.Add("ret", "error");
                    jsonDict.Add("msg", "error");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }
                if (pwd != store.consumePwd)
                {
                    jsonDict.Add("ret", "error");
                    jsonDict.Add("msg", "密码错误");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }
                int ssid = userBll.ExistsStoreAndUser(uid);
                if (ssid == 0 || sid != ssid)
                {  //验证，用户存在，店铺存在，并且用户属于这个店铺
                    return;
                }
                BLL.wx_ucard_privileges privBll = new BLL.wx_ucard_privileges();
                Model.wx_ucard_privileges privileges = privBll.GetModel(pid);
                if (privileges == null)
                {
                    jsonDict.Add("ret", "error");
                    jsonDict.Add("msg", "特权不存在");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }

                //积分策略
                score = scoreBll.GetStoreModel(sid);
                int avgScore = score.consumeMoneyScore.Value / score.consumeMoney.Value;
                //1先添加消费明细,和修改用户的总积分和总消费金额
                //IList<Model.wx_ucard_users_consumeinfo> conlist = conBll.GetModelList("moduleType='特权' and moduleActionId=" + privileges.id + " and sid=" + sid + " and uid=" + uid);
                //if (conlist == null || conlist.Count <= 0 || conlist[0] == null)
                //{  
                //新增
                    consume = new Model.wx_ucard_users_consumeinfo();
                    consume.moduleActionId = 10;
                    consume.moduleType = "特权";
                    consume.moduleActionId = privileges.id;
                    consume.moduleActionName = privileges.pName;
                    consume.sId = sid;
                    consume.uid = uid;
                    consume.consumeMoney = (decimal)money;
                    consume.addTime = DateTime.Now;
                    consume.sn = sn;
                    consume.pwd = pwd;
                    consume.cMoneyType = 2;
                    consume.score = (int)(avgScore * money);
                    consume.cScoreType = 1;
                    conBll.Add(consume,true);

                //}
                //else
                //{
                //    //修改
                //    consume = conlist[0];
                //    decimal oldMoney = MyCommFun.Obj2Decimal(consume.consumeMoney, 0);
                //    int oldScore = MyCommFun.Obj2Int(consume.score);


                //    consume.moduleActionName = privileges.pName;
                //    consume.consumeMoney = (decimal)money;
                //    consume.sn = sn;
                //    consume.pwd = pwd;
                //    consume.cMoneyType = 2;
                //    consume.score = (int)(avgScore * money);
                //    conBll.UpdateInfoAndUserTT(consume, oldMoney, oldScore);
                //}
                jsonDict.Add("ret", "succ");
                jsonDict.Add("msg", "获得" + consume.score.Value + "积分 ");
                context.Response.Write(MyCommFun.getJsonStr(jsonDict));

                #endregion
            }
            else if (_action == "lq_yhq")
            {
                #region 领取优惠券

                jsonDict = new Dictionary<string, string>();
                sid = MyCommFun.RequestInt("sid");  //店铺id
                uid = MyCommFun.RequestInt("uid");//用户id
                string sn = MyCommFun.QueryString("sncode");
                string pwd = MyCommFun.QueryString("parssword");
                float money = MyCommFun.RequestFloat("money", 0);
                int ticketId = MyCommFun.RequestInt("cid");//优惠券主键id

                if (sid == 0 || uid == 0 || ticketId == 0)
                {
                    jsonDict.Add("ret", "error");
                    jsonDict.Add("msg", "error");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }
                if (pwd != store.consumePwd)
                {
                    jsonDict.Add("ret", "error");
                    jsonDict.Add("msg", "密码错误");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }
                int ssid = userBll.ExistsStoreAndUser(uid);
                if (ssid == 0 || sid != ssid)
                {  //验证，用户存在，店铺存在，并且用户属于这个店铺
                    return;
                }
                BLL.wx_ucard_ticket ticketBll = new BLL.wx_ucard_ticket();
                Model.wx_ucard_ticket ticket = ticketBll.GetModel(ticketId);
                if (ticket == null)
                {
                    jsonDict.Add("ret", "error");
                    jsonDict.Add("msg", "优惠券不存在");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }
                int syTimes = ticketBll.getsyTimesByTicket(uid, ticketId);
                if (syTimes <= 0)
                {
                    jsonDict.Add("ret", "error");
                    jsonDict.Add("msg", "已没有使用次数");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }

                //积分策略
                score = scoreBll.GetStoreModel(sid);
                int avgScore = score.consumeMoneyScore.Value / score.consumeMoney.Value;
                //1先添加消费明细,和修改用户的总积分和总消费金额

                //新增
                consume = new Model.wx_ucard_users_consumeinfo();
                consume.moduleActionId = 10;
                consume.moduleType = "优惠券";
                consume.moduleActionId = ticket.id;
                consume.moduleActionName = ticket.tName;
                consume.sId = sid;
                consume.uid = uid;
                consume.consumeMoney = (decimal)money;
                consume.addTime = DateTime.Now;
                consume.sn = sn;
                consume.pwd = pwd;
                consume.cMoneyType = 2;
                consume.score = (int)(avgScore * money);
                consume.cScoreType = 1;
                conBll.Add(consume,true);
                syTimes -= 1;

                jsonDict.Add("ret", "succ");
                jsonDict.Add("msg", "获得" + consume.score.Value + "积分 ");
                jsonDict.Add("sy", syTimes.ToString());
                context.Response.Write(MyCommFun.getJsonStr(jsonDict));


                #endregion
            }
            else if (_action == "gift")
            {
                #region 兑换礼品券

                jsonDict = new Dictionary<string, string>();
                sid = MyCommFun.RequestInt("sid");  //店铺id
                uid = MyCommFun.RequestInt("uid");//用户id
                string sn = MyCommFun.QueryString("sncode");
                string pwd = MyCommFun.QueryString("parssword");
                float money = MyCommFun.RequestFloat("money", 0);
                int giftId = MyCommFun.RequestInt("gid");//礼品主键id

                if (sid == 0 || uid == 0 || giftId == 0)
                {
                    jsonDict.Add("ret", "error");
                    jsonDict.Add("msg", "error");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }
                if (pwd != store.consumePwd)
                {
                    jsonDict.Add("ret", "error");
                    jsonDict.Add("msg", "密码错误");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }
                int ssid = userBll.ExistsStoreAndUser(uid);
                if (ssid == 0 || sid != ssid)
                {  //验证，用户存在，店铺存在，并且用户属于这个店铺
                    return;
                }
                BLL.wx_ucard_gift giftBll = new BLL.wx_ucard_gift();
                Model.wx_ucard_gift gift = giftBll.GetModel(giftId);
                if (gift == null)
                {
                    jsonDict.Add("ret", "error");
                    jsonDict.Add("msg", "优惠券不存在");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }
                int userTTScore = userBll.GetUserJiFen(uid);
                if (userTTScore <gift.score.Value)
                {
                    jsonDict.Add("ret", "error");
                    jsonDict.Add("msg", "积分不够");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }

                //1先添加消费明细,和修改用户的总积分和总消费金额

                //新增
                consume = new Model.wx_ucard_users_consumeinfo();
                consume.moduleActionId = 10;
                consume.moduleType = "礼品券";
                consume.moduleActionId = gift.id;
                consume.moduleActionName = gift.gName;
                consume.sId = sid;
                consume.uid = uid;
                consume.addTime = DateTime.Now;
                consume.sn = sn;
                consume.pwd = pwd;
                consume.score = -gift.score.Value;
                consume.cScoreType = 1;
                conBll.Add(consume,false);
               
                jsonDict.Add("ret", "succ");
                jsonDict.Add("msg", "成功兑换礼品扣除 " + gift.score.Value + " 积分 ");
              
                context.Response.Write(MyCommFun.getJsonStr(jsonDict));


                #endregion
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}