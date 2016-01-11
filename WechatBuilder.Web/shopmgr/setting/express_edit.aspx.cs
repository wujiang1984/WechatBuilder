using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;

namespace WechatBuilder.Web.shopmgr.setting
{
    public partial class express_edit : Web.UI.ManagePage
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
                if (!new BLL.express().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("order_express", MXEnums.ActionEnum.View.ToString()); //检查权限
                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.express bll = new BLL.express();
            Model.express model = bll.GetModel(_id);

            txtTitle.Text = model.title;
            txtExpressCode.Text = model.express_code;
            txtExpressFee.Text = model.express_fee.ToString();
            txtWebSite.Text = model.website;
            txtRemark.Text = Utils.ToTxt(model.remark);
            if (model.is_lock == 0)
            {
                cbIsLock.Checked = true;
            }
            else
            {
                cbIsLock.Checked = false;
            }
            txtSortId.Text = model.sort_id.ToString();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.express model = new Model.express();
            BLL.express bll = new BLL.express();
            Model.wx_userweixin weixin = GetWeiXinCode();
            model.title = txtTitle.Text.Trim();
            model.express_code = txtExpressCode.Text.Trim();
            model.express_fee = Utils.StrToDecimal(txtExpressFee.Text.Trim(), 0);
            model.website = txtWebSite.Text.Trim();
            model.remark = Utils.ToHtml(txtRemark.Text);
            model.wid = weixin.id;
            if (cbIsLock.Checked == true)
            {
                model.is_lock = 0;
            }
            else
            {
                model.is_lock = 1;
            }
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);

            if (bll.Add(model) > 0)
            {
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加配送方式:" + model.title); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.express bll = new BLL.express();
            Model.express model = bll.GetModel(_id);

            model.title = txtTitle.Text.Trim();
            model.express_code = txtExpressCode.Text.Trim();
            model.express_fee = Utils.StrToDecimal(txtExpressFee.Text.Trim(), 0);
            model.website = txtWebSite.Text.Trim();
            model.remark = Utils.ToHtml(txtRemark.Text);
            if (cbIsLock.Checked == true)
            {
                model.is_lock = 0;
            }
            else
            {
                model.is_lock = 1;
            }
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);

            if (bll.Update(model))
            {
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改配送方式:" + model.title); //记录日志
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
                ChkAdminLevel("order_express", MXEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改物流配送成功！", "express_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("order_express", MXEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加物流配送成功！", "express_list.aspx", "Success");
            }
        }
    }
}