using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using WechatBuilder.BLL;

namespace WechatBuilder.Web.admin.sms
{
    public partial class sms_send : Web.UI.ManagePage
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                ShowInfo();
            }
        }



        #region 赋值操作=================================
        private void ShowInfo()
        {
             //短信条数查询
            Model.wx_userweixin weixin = GetWeiXinCode();  
            smsMgr mgr = new smsMgr(weixin.id);
            lblsmsNum.Text = mgr.getBlance();
        }

        #endregion



        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            smsMgr mgr = new smsMgr(weixin.id);
            #region  //先判断
            string strErr = "";
            if (this.txtcontent.Value.Trim().Length == 0)
            {
                strErr += "短信内容不能为空！";
            }
            if (this.txttel.Value.Trim().Length == 0)
            {
                strErr += "手机号不能为空！";
            }

            
            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }

            #endregion
            string tel=txttel.Value.Trim();
            string content=txtcontent.Value.Trim();
            lblRet.Text=  mgr.SendSMS(tel, content, "手动发送短信信息");
           

        }


    }
}