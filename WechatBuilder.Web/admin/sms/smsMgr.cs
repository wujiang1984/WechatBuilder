using WechatBuilder.BLL;
using System;

namespace WechatBuilder.Web.admin.sms
{
    public class smsMgr  
    {

        /**
         * 参数	说明	是否必须
         oginname	传递的登录帐号	 是

    password	传递的登录密码 建议MD5加密 加密后大写	是

    telphone  需要发送的手机号码，多个号码以逗号分割 ,建议200一组提交	是

    content 发送的内容，发送内容需要UTF-8编码处理	 是

    dsdate 传递定时时间，如果发送定时，传递此参数 参数格式 2012-07-27 08:20:00	否
         */


        /*
         * 返回参数

    标识	描述
    0	成功（具体返回0， 
    批次号码 类似0, 201207121512033125d9171d2a34d9）
    -1	帐号密码错误
    -2	帐号被停用
    -3	帐号类型不允许使用
    -4	手机号码为空
    -5	内容为空
    -6	内容包含黑字典字样
    -7	通道分配错误
    -8	余额不足
    -9	定时时间格式不正确 2012-07-27 08:30:00
    -14	短码范围不正确
    -99	必须输入企业签名【签名字样】
    -100	系统未知错误
    **/
        WechatBuilder.Web.lzcats.ILzServices sms = new WechatBuilder.Web.lzcats.ILzServices();
        wx_sms_config scBll = new wx_sms_config();
        string ucode = "";
        string pwd = "";
        string qianming ="";
        int wid;

        public smsMgr(int wid)
        { 
            this.wid=wid;
            Model.wx_sms_config smsConfig = scBll.GetWidModel(wid);
            if (smsConfig != null)
            {
                ucode = smsConfig.ucode;
                pwd = smsConfig.pwd;
                qianming = smsConfig.qianming;

            }
        }

        /// <summary>
        /// 短信发送需要发送的手机号码，多个号码以逗号分割 ,建议200一组提交
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public string SendSMS(string phone, string content)
        {
            return SendSMS(phone, content, "", "", 0);
        }

        /// <summary>
        /// 短信发送需要发送的手机号码，多个号码以逗号分割 ,建议200一组提交
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="content"></param>
        /// <param name="moduleName"></param>
        /// <returns></returns>
        public string SendSMS(string phone, string content, string moduleName)
        {
            return SendSMS(  phone,   content,   moduleName,  "", 0);
        }
        
       /// <summary>
        /// 短信发送需要发送的手机号码，多个号码以逗号分割 ,建议200一组提交
       /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="content">短信内容</param>
        /// <param name="moduleName">发送短信的模块名称</param>
        /// <param name="actionName">模块活动的名称</param>
        /// <param name="actionId">模块活动的主键id</param>
        /// <returns>需要发送的手机号码，多个号码以逗号分割 ,建议200一组提交</returns>
        public string SendSMS(string phone, string content, string moduleName, string actionName, int actionId)
        {
            BLL.wx_sms_info smsBll = new BLL.wx_sms_info();
            Model.wx_sms_info smsinfo = new Model.wx_sms_info();
            
            if (ucode == "" || pwd == "" || qianming=="")
            {
                return "失败：帐号、密码或者签名未填写";
            }
            if (qianming.Contains("【") && qianming.Contains("】"))
            {
                //签名必须包含“【”和“】”
            }
            else
            {
                return "失败：签名填写错误";
            }
            try
            {
                if (phone.Trim() == "")
                {
                    return "失败：手机号码为空";
                }
                if (content.Trim() == "")
                {
                    return "失败：短信内容为空";
                }


                string[] phoneArr = phone.Split(',');
                string ret = "";
                for (int i = 0; i < phoneArr.Length; i++)
                {
                    if (phoneArr[i].Trim() != "" && phoneArr[i].Trim().Length > 5)
                    {
                        ret = sms.LZ_SendSms(ucode, pwd, phoneArr[i], content + " " + qianming, "");
                        //----- 记录日志 begin -----\\
                        smsinfo = new Model.wx_sms_info();
                        smsinfo.wid =wid;
                        smsinfo.createDate = DateTime.Now;
                        smsinfo.moduleName = moduleName;
                        smsinfo.actionName = actionName;
                        smsinfo.actionId = actionId;
                        smsinfo.tel = phoneArr[i];
                        smsinfo.smsContent = content + " " + qianming;
                        smsinfo.sStatusNum = ret;
                        smsinfo.sStatus = smsSendReturnValue(ret);
                        smsBll.Add(smsinfo);
                        //----- 记录日志 end -----\\
                    }
                }

                
                return (smsSendReturnValue(ret));
            }
            catch (Exception ex)
            {
                 
                smsinfo = new Model.wx_sms_info();
                smsinfo.wid = wid;
                smsinfo.createDate = DateTime.Now;
                smsinfo.moduleName = moduleName;
                smsinfo.actionName = actionName;
                smsinfo.actionId = actionId;
                smsinfo.tel = phone;
                smsinfo.smsContent = content;
                smsinfo.sStatusNum = "失败：短信发送失败：" + ex.Message;
                smsinfo.sStatus = "发送失败，抛出异常信息";
                smsBll.Add(smsinfo);

                return "失败：短信发送失败：" + ex.Message;
            }


        }

        /// <summary>
        /// 查询余额
        /// </summary>
        /// <returns></returns>
        public string getBlance()
        {
            string ret = "";
            ret = sms.LZ_GetBlance(ucode, pwd);

            return ret;
        }

        /// <summary>
        /// 短信发送返回的状态
        /// </summary>
        /// <param name="smsStatus"></param>
        /// <returns></returns>
        public string smsSendReturnValue(string smsStatus)
        {
            string ret = "";
            try
            {
                string status = smsStatus.Substring(0, 2);
                switch (status)
                {

                    case "0,":
                        ret = "成功";
                        break;
                    case "-1":
                        ret = "失败：帐号密码错误";
                        break;
                    case "-2":
                        ret = "失败：帐号被停用";
                        break;
                    case "-3":
                        ret = "失败：帐号类型不允许使用";
                        break;
                    case "-4":
                        ret = "失败：手机号码为空";
                        break;
                    case "-5":
                        ret = "失败：短信内容为空";
                        break;
                    case "-6":
                        ret = "失败：内容包含黑字典字样";
                        break;
                    case "-7":
                        ret = "失败：通道分配错误";
                        break;
                    case "-8":
                        ret = "失败：余额不足";
                        break;
                    case "-9":
                        ret = "失败：定时时间格式不正确 2012-07-27 08:30:00";
                        break;
                    default:
                        ret = "失败：短信发送异常";
                        break;



                }
            }
            catch (Exception ex)
            {
                ret = "失败：短信发送异常，" + ex.Message;
            }

            return ret;

        }

    }
}