using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;

namespace WechatBuilder.Web.admin.order
{
    public partial class order_config : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("order_config", MXEnums.ActionEnum.View.ToString()); //检查权限
                ShowInfo();
            }
        }

        #region 赋值操作=================================
        private void ShowInfo()
        {
            BLL.orderconfig bll = new BLL.orderconfig();
            Model.orderconfig model = bll.loadConfig();

            if (model.anonymous == 1)
            {
                anonymous.Checked = true;
            }
            else
            {
                anonymous.Checked = false;
            }
            confirmmsg.SelectedValue = model.confirmmsg.ToString();
            confirmcallindex.Text = model.confirmcallindex;
            expressmsg.SelectedValue = model.expressmsg.ToString();
            expresscallindex.Text = model.expresscallindex;
            completemsg.SelectedValue = model.completemsg.ToString();
            completecallindex.Text = model.completecallindex;

            kuaidiapi.Text = model.kuaidiapi;
            kuaidikey.Text = model.kuaidikey;
            kuaidishow.SelectedValue = model.kuaidishow.ToString();
            kuaidimuti.SelectedValue = model.kuaidimuti.ToString();
            kuaidiorder.SelectedValue = model.kuaidiorder;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("order_config", MXEnums.ActionEnum.Edit.ToString()); //检查权限
            BLL.orderconfig bll = new BLL.orderconfig();
            Model.orderconfig model = bll.loadConfig();
            try
            {
                if (anonymous.Checked == true)
                {
                    model.anonymous = 1;
                }
                else
                {
                    model.anonymous = 0;
                }
                model.confirmmsg = Utils.StrToInt(confirmmsg.SelectedValue, 0);
                model.confirmcallindex = confirmcallindex.Text;
                model.expressmsg = Utils.StrToInt(expressmsg.SelectedValue, 0);
                model.expresscallindex = expresscallindex.Text;
                model.completemsg = Utils.StrToInt(completemsg.SelectedValue, 0);
                model.completecallindex = completecallindex.Text;

                model.kuaidiapi = kuaidiapi.Text;
                model.kuaidikey = kuaidikey.Text;
                model.kuaidishow = Utils.StrToInt(kuaidishow.SelectedValue, 3);
                model.kuaidimuti = Utils.StrToInt(kuaidimuti.SelectedValue, 1);
                model.kuaidiorder = kuaidiorder.SelectedValue;

                bll.saveConifg(model);
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改订单配置信息"); //记录日志
                JscriptMsg("修改订单配置成功！", "order_config.aspx", "Success");
            }
            catch
            {
                JscriptMsg("文件写入失败，请检查是否有权限！", "", "Error");
            }
        }

    }
}