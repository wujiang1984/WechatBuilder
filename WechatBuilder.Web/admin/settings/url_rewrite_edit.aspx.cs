using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;

namespace WechatBuilder.Web.admin.settings
{
    public partial class url_rewrite_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型
        private string urlName = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {
                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                this.urlName = MXRequest.GetQueryString("name");
                if (string.IsNullOrEmpty(this.urlName))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("site_url_rewrite", MXEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind(); //绑定频道
                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(urlName);
                }
                else
                {
                    txtName.Attributes.Add("ajaxurl", "../../tools/admin_ajax.ashx?action=urlrewrite_name_validate");
                }
            }
        }

        #region 绑定频道=================================
        private void TreeBind()
        {
            BLL.channel bll = new BLL.channel();
            DataTable dt = bll.GetList(0, "", "sort_id asc,id desc").Tables[0];

            this.ddlChannel.Items.Clear();
            this.ddlChannel.Items.Add(new ListItem("不属于频道", ""));
            foreach (DataRow dr in dt.Rows)
            {
                this.ddlChannel.Items.Add(new ListItem(dr["title"].ToString(), dr["name"].ToString()));
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(string _urlName)
        {
            BLL.url_rewrite bll = new BLL.url_rewrite();
            Model.url_rewrite model = bll.GetInfo(_urlName);

            txtName.Text = model.name;
            txtName.ReadOnly = true;
            ddlType.SelectedValue = model.type;
            ddlChannel.SelectedValue = model.channel;
            txtPage.Text = model.page;
            txtInherit.Text = model.inherit;
            txtTemplet.Text = model.templet;
            //绑定URL配置列表
            rptList.DataSource = model.url_rewrite_items;
            rptList.DataBind();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            BLL.url_rewrite bll = new BLL.url_rewrite();
            Model.url_rewrite model = new Model.url_rewrite();

            model.name = txtName.Text.Trim();
            model.type = ddlType.SelectedValue;
            model.channel = ddlChannel.SelectedValue;
            model.page = txtPage.Text.Trim();
            model.inherit = txtInherit.Text.Trim();
            model.templet = txtTemplet.Text.Trim();
            //添加URL重写节点
            List<Model.url_rewrite_item> items = new List<Model.url_rewrite_item>();
            string[] itemPathArr = Request.Form.GetValues("itemPath");
            string[] itemPatternArr = Request.Form.GetValues("itemPattern");
            string[] itemQuerystringArr = Request.Form.GetValues("itemQuerystring");
            if (itemPathArr != null && itemPatternArr != null && itemQuerystringArr != null)
            {
                for (int i = 0; i < itemPathArr.Length; i++)
                {
                    items.Add(new Model.url_rewrite_item { path = itemPathArr[i], pattern = itemPatternArr[i], querystring = itemQuerystringArr[i] });
                }
            }
            model.url_rewrite_items = items;

            if (bll.Add(model))
            {
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加URL配置信息:" + model.name); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(string _urlName)
        {
            BLL.url_rewrite bll = new BLL.url_rewrite();
            Model.url_rewrite model = bll.GetInfo(_urlName);

            model.type = ddlType.SelectedValue;
            model.channel = ddlChannel.SelectedValue;
            model.page = txtPage.Text.Trim();
            model.inherit = txtInherit.Text.Trim();
            model.templet = txtTemplet.Text.Trim();
            //添加URL重写节点
            List<Model.url_rewrite_item> items = new List<Model.url_rewrite_item>();
            string[] itemPathArr = Request.Form.GetValues("itemPath");
            string[] itemPatternArr = Request.Form.GetValues("itemPattern");
            string[] itemQuerystringArr = Request.Form.GetValues("itemQuerystring");
            if (itemPathArr != null && itemPatternArr != null && itemQuerystringArr != null)
            {
                for (int i = 0; i < itemPathArr.Length; i++)
                {
                    items.Add(new Model.url_rewrite_item { path = itemPathArr[i], pattern = itemPatternArr[i], querystring = itemQuerystringArr[i] });
                }
            }
            model.url_rewrite_items = items;

            if (bll.Edit(model))
            {
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改URL配置信息:" + model.name); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("site_url_rewrite", MXEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.urlName))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改配置成功！", "url_rewrite_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("site_url_rewrite", MXEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加配置成功！", "url_rewrite_list.aspx", "Success");
            }
        }

    }
}