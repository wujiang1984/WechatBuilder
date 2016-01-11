using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WechatBuilder.Web.weixin.diancai
{
    /// <summary>
    /// diancai_login 的摘要说明
    /// </summary>
    public class diancai_login : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            Dictionary<string, string> jsonDict = new Dictionary<string, string>();
            context.Response.ContentType = "text/json";
            string _action = MyCommFun.QueryString("myact");
            string username = MyCommFun.QueryString("username");
            string parssword = MyCommFun.QueryString("parssword");
            string id = MyCommFun.QueryString("id");
            string openid = MyCommFun.QueryString("openid");
            string state = MyCommFun.QueryString("state");
            string goodsData = QueryString("goodsData");
            int shopid = MyCommFun.RequestInt("shopid");


            BLL.wx_diancai_dianyuan dianyuanbll = new BLL.wx_diancai_dianyuan();
            Model.wx_diancai_dianyuan dianyuan = new Model.wx_diancai_dianyuan();


            BLL.wx_diancai_caipin_category categorybll = new BLL.wx_diancai_caipin_category();

            BLL.wx_diancai_member menberbll = new BLL.wx_diancai_member();
            Model.wx_diancai_member member = new Model.wx_diancai_member();

            BLL.wx_diancai_dingdan_manage manage = new BLL.wx_diancai_dingdan_manage();
            Model.wx_diancai_dingdan_manage managemodel = new Model.wx_diancai_dingdan_manage();
            BLL.wx_diancai_dingdan_caiping caipinbll = new BLL.wx_diancai_dingdan_caiping();
            Model.wx_diancai_dingdan_caiping caipin = new Model.wx_diancai_dingdan_caiping();

            if (_action == "login")
            {
                if (dianyuanbll.Exists(username, parssword))
                {
                    jsonDict.Add("ret", "ok");
                    jsonDict.Add("content", "登录成功！");

                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                }
                else
                {
                    jsonDict.Add("ret", "fail");
                    jsonDict.Add("content", "密码错误！");

                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                }
            }

            else  if (_action == "setstatus")
            {
                //id

                if (manage.Updatestatus(id, state))
                {
                    jsonDict.Add("ret", "ok");
                    jsonDict.Add("content", "提交成功！");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                }

            }

            else if (_action =="addmember")
            {

                member.shopid = shopid;
                openid = Utils.Number(18);
                member.openid = openid;
                member.weixinName = MyCommFun.QueryString("weixinName");
                member.memberName = MyCommFun.QueryString("username");
                member.menberTel = MyCommFun.QueryString("customerTel");
                member.memberAddress = MyCommFun.QueryString("address");
                member.successDingdan = 0;
                member.failDingdan = 0;
                member.cancelDingdan = 0;
                member.zongjifen = 0;
                member.zongcje = 0;
                member.status = 1;
                member.createDate = DateTime.Now;
                menberbll.Add(member);

               jsonDict.Add("ret", "ok");
               jsonDict.Add("content", "提交成功！");
               context.Response.Write(MyCommFun.getJsonStr(jsonDict));
               return;

             }

            else  if (_action == "addcaidan")
            {

                if (goodsData == "")
                {
                    jsonDict.Add("ret", "err");
                    jsonDict.Add("content", "goodsData为空值！");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }

                if (openid == "")
                {
                    jsonDict.Add("ret", "fail");
                    jsonDict.Add("content", "订单提交失败！");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }
                //用户信息   

                managemodel.shopinfoid = shopid;
                managemodel.openid = openid;
                managemodel.orderNumber = Utils.Number(13);//订单号
                managemodel.deskNumber = "";//桌号
                // manage.customerName = this.name.Value;
                //manage.customerTel = this.phone.Value;
                managemodel.payStatus = 0;
                managemodel.oderRemark = "";
                managemodel.oderTime = DateTime.Now;
                managemodel.createDate = DateTime.Now;
                int idf = manage.Add(managemodel);

                decimal payAmount = 0;

                //菜品
                string[] sArray = goodsData.Split(';');
                for (int i = 0; i < sArray.Length - 1; i++)
                {

                    string[] sAr = sArray[i].Split(',');
                    caipin.dingId = idf;
                    caipin.caiId = Convert.ToInt32(sAr[0]);//菜品ID
                    caipin.num = Convert.ToInt32(sAr[1]);//菜品件数
                    caipin.price = Convert.ToDecimal(sAr[2]);//菜品单价
                    caipin.totpric = Convert.ToInt32(sAr[1]) * Convert.ToDecimal(sAr[2]);//总价
                    payAmount += Convert.ToInt32(sAr[1]) * Convert.ToDecimal(sAr[2]);//客户购买总价
                    caipinbll.Add(caipin);
                }
               bool isOk=  manage.Update(idf, payAmount);
               if (isOk)
               {
                   jsonDict.Add("ret", "ok");
                   jsonDict.Add("content", "订单提交成功！请到订单查看！");
                   context.Response.Write(MyCommFun.getJsonStr(jsonDict));
               }
               else
               {
                   jsonDict.Add("ret", "err");
                   jsonDict.Add("content", "订单提交失败！");
                   context.Response.Write(MyCommFun.getJsonStr(jsonDict));
               }
                context.Response.End();

            }
        }



        public static string QueryString(string param)
        {
            if (HttpContext.Current.Request[param] == null || HttpContext.Current.Request[param].ToString().Trim() == "")
            {
                return "";
            }
            string ret = HttpContext.Current.Request[param].ToString().Trim();
            return ret;
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