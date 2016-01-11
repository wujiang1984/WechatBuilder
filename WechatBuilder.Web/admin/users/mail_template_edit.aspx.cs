using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;

namespace WechatBuilder.Web.admin.users
{
    public partial class mail_template_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {
                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = MXRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.mail_template().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("user_mail_template", MXEnums.ActionEnum.View.ToString()); //检查权限
                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.mail_template bll = new BLL.mail_template();
            Model.mail_template model = bll.GetModel(_id);

            txtTitle.Text = model.title;
            txtCallIndex.Text = model.call_index;
            txtMailTitle.Text = model.maill_title;
            txtContent.Value = model.content;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.mail_template model = new Model.mail_template();
            BLL.mail_template bll = new BLL.mail_template();

            model.title = txtTitle.Text.Trim();
            model.call_index = txtCallIndex.Text.Trim();
            model.maill_title = txtMailTitle.Text.Trim();
            model.content = txtContent.Value;

            if (bll.Add(model) > 0)
            {
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加邮件模板:" + model.title); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.mail_template bll = new BLL.mail_template();
            Model.mail_template model = bll.GetModel(_id);

            model.title = txtTitle.Text.Trim();
            model.call_index = txtCallIndex.Text.Trim();
            model.maill_title = txtMailTitle.Text.Trim();
            model.content = txtContent.Value;

            if (bll.Update(model))
            {
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改邮件模板:" + model.title); //记录日志
                result = true;
            }

            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("user_mail_template", MXEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改邮件模板成功！", "mail_template_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("user_mail_template", MXEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加邮件模板成功！", "mail_template_list.aspx", "Success");
            }
        }

    }
}