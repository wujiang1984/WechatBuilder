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
    public partial class sms_config : Web.UI.ManagePage
    {
        
        wx_sms_config scBll = new wx_sms_config();
     
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
            Model.wx_userweixin weixin = GetWeiXinCode();
          
            Model.wx_sms_config smsConfig = scBll.GetWidModel(weixin.id);
            if (smsConfig != null)
            {
                hidid.Value = smsConfig.id.ToString();
                txtucode.Text = smsConfig.ucode;
                txtpwd.Text = smsConfig.pwd;
                txtqianming.Text = smsConfig.qianming;
                txtremark.Value = smsConfig.remark;
            }
        }

        #endregion



        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();

          
            int id = MyCommFun.Str2Int(hidid.Value);
            #region  //先判断
            string strErr = "";
            if (this.txtucode.Text.Trim().Length == 0)
            {
                strErr += "帐号不能为空！";
            }
            if (this.txtpwd.Text.Trim().Length == 0)
            {
                strErr += "密码不能为空！";
            }

            if (txtqianming.Text.Trim().Length == 0 )
            {
                strErr += "签名不能为空！";
            }
            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }
           
            #endregion

            #region 赋值
            Model.wx_sms_config smsconfig = new Model.wx_sms_config();
            if (id > 0)
            {
                smsconfig = scBll.GetModel(id);
            }
            smsconfig.ucode = txtucode.Text.Trim();
            smsconfig.pwd = txtpwd.Text.Trim();
            smsconfig.qianming = txtqianming.Text.Trim();
            smsconfig.remark = txtremark.Value.ToString();
           

            #endregion

            if (id <= 0)
            {  //新增
                smsconfig.wid = weixin.id;
                smsconfig.createDate = DateTime.Now;
                smsconfig.sortId = 0;
                //1新增主表
                id = scBll.Add(smsconfig);

                
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加短信接口设置，主键为" + id); //记录日志
                JscriptMsg("添加短信接口设置成功！", "sms_list.aspx", "Success");
            }
            else
            {   //修改
                //1修改主表
                scBll.Update(smsconfig);
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改短信接口设置，主键为" + id); //记录日志
                JscriptMsg("修改短信接口设置成功！", "sms_list.aspx", "Success");
            }

        }


       

    }
}