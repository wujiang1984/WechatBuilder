using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WechatBuilder.Common;
using System.Text;
using WechatBuilder.Web.admin.sms;

namespace WechatBuilder.Web.weixin.yuyue
{
    /// <summary>
    /// yuyueApi 的摘要说明
    /// </summary>
    public class yuyueApi : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //暂只考虑添加留言信息
            context.Response.ContentType = "text/json";
            try
            {

                string openid = MyCommFun.QueryString("openid");//openid
                int formid = MyCommFun.RequestInt("formid");
                int wid = MyCommFun.RequestInt("wid");
                BLL.wx_yy_base ybBll = new BLL.wx_yy_base();
                Model.wx_yy_base baseinfo=ybBll.GetModel(formid);


                BLL.wx_yy_control cBll = new BLL.wx_yy_control();
                BLL.wx_yy_result rBll = new BLL.wx_yy_result();
                Model.wx_yy_result ret = new Model.wx_yy_result();
                IList<Model.wx_yy_control> clist = cBll.GetModelList("formId=" + formid);
                
               // rBll.DeleteByOpenid(openid, formid);
                StringBuilder smsContent = new StringBuilder("活动名称：" + baseinfo.title+ ",客户表单内容：");
                for (int i = 0; i < clist.Count; i++)
                {
                    ret = new Model.wx_yy_result();
                    ret.formId = formid;
                    ret.openid = openid;
                    ret.cId = clist[i].id;
                    ret.userResult = MyCommFun.QueryString("control_" + clist[i].id);
                    ret.cName = clist[i].cName;
                    ret.createDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                    rBll.Add(ret);
                    smsContent.Append(ret.cName + ":" + ret.userResult+" ");
                }
                if (baseinfo.needSMS)
                {
                    smsMgr smgr = new smsMgr(wid);
                    smgr.SendSMS(baseinfo.phone, smsContent.ToString(),"在线预约",baseinfo.title,baseinfo.id);
                }
                context.Response.Write("{\"success\":\"true\",\"content\":\"提交成功！\"}");

            }
            catch (Exception ex)
            {
                context.Response.Write("{\"success\":\"false\",\"content\":\"系统出现问题，请重新提交！\"}");
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