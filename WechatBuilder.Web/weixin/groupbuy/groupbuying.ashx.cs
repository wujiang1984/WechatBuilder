using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WechatBuilder.Web.weixin.groupbuy
{
    /// <summary>
    /// groupbuying 的摘要说明
    /// </summary>
    public class groupbuying : IHttpHandler
    {
        protected Model.wx_purchase_base basemodel;
        protected int totalCount = 0;
        protected int count = 0;
        protected int limitCount = 0;
        protected string huodname = "";
        protected int tuangj = 0;
        protected int yg = 0;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            string _action = MyCommFun.QueryString("myact");
            string shopsPwd = MyCommFun.QueryString("shopsPwd");
            string sn = MyCommFun.QueryString("sn");
            int id = MyCommFun.RequestInt("baseid");
            int baseid = MyCommFun.RequestInt("baseid");
            string customerName = MyCommFun.QueryString("customerName");
            string tel = MyCommFun.QueryString("tel");
            int customerNum = MyCommFun.RequestInt("customerNum");
            string address = MyCommFun.QueryString("address");
            string Remark = MyCommFun.QueryString("Remark");



            BLL.wx_purchase_base basebll = new BLL.wx_purchase_base();
            Dictionary<string, string> jsonDict = new Dictionary<string, string>();
            BLL.wx_purchase_customer customerbll = new BLL.wx_purchase_customer();
            Model.wx_purchase_customer model = new Model.wx_purchase_customer();
            string openid = MyCommFun.RequestOpenid();  //得到微信用户的openid
            if (_action == "commit")
            {


                basemodel = basebll.GetModel(id);
                if (basemodel != null)
                {
                   


                    totalCount = Convert.ToInt32(basemodel.totalCount);
                    limitCount = Convert.ToInt32(basemodel.limitCount);
                    count = totalCount - customerbll.GetRecordAmount(id);//剩余的商品数量
                    yg = customerbll.GetRecordyg(openid, id);  //个人剩余的可购买数量

                    if (shopsPwd == "" && sn == "")
                    {
                        #region    //新增一次消费

                        if (count < customerNum)
                        {
                            jsonDict.Add("ret", "fail");
                            jsonDict.Add("content", "超过数量！");

                            context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                            return;
                        }
                        int aa = limitCount - yg;
                        if (aa <= 0)
                        {
                            jsonDict.Add("ret", "fail");
                            jsonDict.Add("content", "超过数量！");

                            context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                            return;

                        }



                        baseid = MyCommFun.RequestInt("baseid");
                        customerName = MyCommFun.QueryString("customerName");
                        tel = MyCommFun.QueryString("tel");
                        customerNum = MyCommFun.RequestInt("customerNum");
                        address = MyCommFun.QueryString("address");

                        model.openid = openid;
                        model.baseid = baseid;
                        model.customerName = customerName;
                        model.tel = tel;
                        model.customerNum = customerNum;
                        model.address = address;
                        sn = Utils.Number(18);
                        model.sn = sn;
                        model.status = 0;//未消费

                        model.craeteTime = DateTime.Now;
                        model.dateJoin = DateTime.Now;
                        model.Remark = Remark;

                        customerbll.Add(model);

                        jsonDict.Add("ret", "ok");
                        jsonDict.Add("content", "抢购成功！");

                        context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                        #endregion



                    }
                    else
                    {
                        #region 确认消费

                        int oldNum = MyCommFun.RequestInt("oldNum"); //本次的原始消费数量
                        customerNum -= oldNum;
                        yg -= oldNum;
                        if (count < customerNum)
                        {
                            jsonDict.Add("ret", "fail");
                            jsonDict.Add("content", "超过数量！");

                            context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                            return;
                        }
                        int aa = limitCount - yg;
                        if (aa <= 0)
                        {
                            jsonDict.Add("ret", "fail");
                            jsonDict.Add("content", "超过数量！");

                            context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                            return;

                        }



                        model = customerbll.GetModellist(id);//最近一条记录

                        if (shopsPwd == "")
                        {
                            jsonDict.Add("ret", "fail");
                            jsonDict.Add("content", "请输入密码！");
                            context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                            return;
                        }

                        if (basemodel == null || basemodel.shopsPwd != shopsPwd)
                        {
                            //JscriptMsg("消费密码不正确！", "back", "Error");
                            jsonDict.Add("ret", "fail");
                            jsonDict.Add("content", "密码错误！");

                            context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                            return;
                            //消费
                        }







                        model.baseid = id;
                        model.status = 2;
                        model.dateUse = DateTime.Now;
                        customerbll.Update(model);

                        jsonDict.Add("ret", "ok");
                        jsonDict.Add("content", "消费成功！");

                        context.Response.Write(MyCommFun.getJsonStr(jsonDict));


                        #endregion

                    }


                }
            }
            else
            {
                jsonDict.Add("ret", "fail");
                jsonDict.Add("content", "提交失败！");

                context.Response.Write(MyCommFun.getJsonStr(jsonDict));
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