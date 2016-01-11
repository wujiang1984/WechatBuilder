using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;

namespace WechatBuilder.Web.admin.users
{
    public partial class oauth_app_edit : Web.UI.ManagePage
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
                if (!new BLL.user_oauth_app().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("user_oauth", MXEnums.ActionEnum.View.ToString()); //检查权限
                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.user_oauth_app bll = new BLL.user_oauth_app();
            Model.user_oauth_app model = bll.GetModel(_id);
            txtTitle.Text = model.title;
            if (model.is_lock == 0)
            {
                cbIsLock.Checked = true;
            }
            else
            {
                cbIsLock.Checked = false;
            }
            txtSortId.Text = model.sort_id.ToString();
            txtApiPath.Text = model.api_path;
            txtAppId.Text = model.app_id;
            txtAppKey.Text = model.app_key;
            txtImgUrl.Text = model.img_url;
            txtRemark.Text = model.remark;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.user_oauth_app model = new Model.user_oauth_app();
            BLL.user_oauth_app bll = new BLL.user_oauth_app();

            model.title = txtTitle.Text.Trim();
            if (cbIsLock.Checked == true)
            {
                model.is_lock = 0;
            }
            else
            {
                model.is_lock = 1;
            }
            model.sort_id = int.Parse(txtSortId.Text.Trim());
            model.api_path = txtApiPath.Text.Trim();
            model.app_id = txtAppId.Text.Trim();
            model.app_key = txtAppKey.Text.Trim();
            model.img_url = txtImgUrl.Text.Trim();
            model.remark = txtRemark.Text;
            if (bll.Add(model) > 0)
            {
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加OAuth信息:" + model.title); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.user_oauth_app bll = new BLL.user_oauth_app();
            Model.user_oauth_app model = bll.GetModel(_id);

            model.title = txtTitle.Text.Trim();
            if (cbIsLock.Checked == true)
            {
                model.is_lock = 0;
            }
            else
            {
                model.is_lock = 1;
            }
            model.sort_id = int.Parse(txtSortId.Text.Trim());
            model.api_path = txtApiPath.Text.Trim();
            model.app_id = txtAppId.Text.Trim();
            model.app_key = txtAppKey.Text.Trim();
            model.img_url = txtImgUrl.Text.Trim();
            model.remark = txtRemark.Text;
            if (bll.Update(model))
            {
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改OAuth信息:" + model.title); //记录日志
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
                ChkAdminLevel("user_oauth", MXEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改OAuth应用成功！", "oauth_app_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("user_oauth", MXEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加OAuth应用成功！", "oauth_app_list.aspx", "Success");
            }
        }

    }
}