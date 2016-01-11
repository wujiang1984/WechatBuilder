using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;

namespace WechatBuilder.Web.admin.channel
{
    public partial class channel_edit : Web.UI.ManagePage
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
                if (!new BLL.channel().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("site_channel_list", MXEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind(); //绑定类别
                FieldBind(); //绑定扩展字段
                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                else
                {
                    txtTitle.Attributes.Add("onBlur", "change2cn(this.value, this.form.txtName)");
                    txtName.Attributes.Add("ajaxurl", "../../tools/admin_ajax.ashx?action=channel_validate");
                }
            }
        }

        #region 返回页面的类型===========================
        protected string GetPageTypeTxt(string type_name)
        {
            string result = "";
            switch (type_name)
            {
                case "index":
                    result = "首页";
                    break;
                case "category":
                    result = "栏目页";
                    break;
                case "list":
                    result = "列表页";
                    break;
                case "detail":
                    result = "详细页";
                    break;
            }
            return result;
        }
        #endregion

        #region 返回页面继承类===========================
        private string GetInherit(string page_type)
        {
            string result = "";
            switch (page_type)
            {
                case "index":
                    result = "WechatBuilder.Web.UI.Page.article";
                    break;
                case "category":
                    result = "WechatBuilder.Web.UI.Page.category";
                    break;
                case "list":
                    result = "WechatBuilder.Web.UI.Page.article_list";
                    break;
                case "detail":
                    result = "WechatBuilder.Web.UI.Page.article_show";
                    break;
            }
            return result;
        }
        #endregion

        #region 绑定类别=================================
        private void TreeBind()
        {
            BLL.channel_category bll = new BLL.channel_category();
            DataTable dt = bll.GetList(0, "", "sort_id asc,id desc").Tables[0];

            this.ddlCategoryId.Items.Clear();
            this.ddlCategoryId.Items.Add(new ListItem("请选择类别...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                this.ddlCategoryId.Items.Add(new ListItem(dr["title"].ToString(), dr["id"].ToString()));
            }
        }
        #endregion

        #region 绑定扩展字段=============================
        private void FieldBind()
        {
            BLL.article_attribute_field bll = new BLL.article_attribute_field();
            DataTable dt = bll.GetList(0, "", "sort_id asc,id desc").Tables[0];

            this.cblAttributeField.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                this.cblAttributeField.Items.Add(new ListItem(dr["title"].ToString(), dr["id"].ToString()));
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.channel bll = new BLL.channel();
            Model.channel model = bll.GetModel(_id);

            txtTitle.Text = model.title;
            txtName.Text = model.name;
            txtName.Focus(); //设置焦点，防止JS无法提交
            txtName.Attributes.Add("ajaxurl", "../../tools/admin_ajax.ashx?action=channel_validate&old_channel_name=" + Utils.UrlEncode(model.name));
            ddlCategoryId.SelectedValue = model.category_id.ToString();
            if (model.is_albums == 1)
            {
                cbIsAlbums.Checked = true;
            }
            if (model.is_attach == 1)
            {
                cbIsAttach.Checked = true;
            }
            if (model.is_group_price == 1)
            {
                cbIsGroupPrice.Checked = true;
            }
            txtPageSize.Text = model.page_size.ToString();
            txtSortId.Text = model.sort_id.ToString();
            
            //赋值扩展字段
            if (model.channel_fields != null)
            {
                for (int i = 0; i < cblAttributeField.Items.Count; i++)
                {
                    Model.channel_field modelt = model.channel_fields.Find(p => p.field_id == int.Parse(cblAttributeField.Items[i].Value)); //查找对应的字段ID
                    if (modelt != null)
                    {
                        cblAttributeField.Items[i].Selected = true;
                    }
                }
            }

            //绑定URL配置列表
            rptList.DataSource = new BLL.url_rewrite().GetList(model.name);
            rptList.DataBind();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.channel model = new Model.channel();
            BLL.channel bll = new BLL.channel();

            model.category_id = Utils.StrToInt(ddlCategoryId.SelectedValue, 0);
            model.name = txtName.Text.Trim();
            model.title = txtTitle.Text.Trim();
            if (cbIsAlbums.Checked == true)
            {
                model.is_albums = 1;
            }
            if (cbIsAttach.Checked == true)
            {
                model.is_attach = 1;
            }
            if (cbIsGroupPrice.Checked == true)
            {
                model.is_group_price = 1;
            }
            model.page_size = Utils.StrToInt(txtPageSize.Text.Trim(), 10);
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);

            //添加频道扩展字段
            List<Model.channel_field> ls = new List<Model.channel_field>();
            for (int i = 0; i < cblAttributeField.Items.Count; i++)
            {
                if (cblAttributeField.Items[i].Selected)
                {
                    ls.Add(new Model.channel_field { field_id = Utils.StrToInt(cblAttributeField.Items[i].Value, 0) });
                }
            }
            model.channel_fields = ls;

            if (bll.Add(model) < 1)
            {
                return false;
            }

            #region 保存URL配置
            BLL.url_rewrite urlBll = new BLL.url_rewrite();
            urlBll.Remove("channel", model.name); //先删除
            string[] itemTypeArr = Request.Form.GetValues("item_type");
            string[] itemNameArr = Request.Form.GetValues("item_name");
            string[] itemPageArr = Request.Form.GetValues("item_page");
            string[] itemTempletArr = Request.Form.GetValues("item_templet");
            string[] itemRewriteArr = Request.Form.GetValues("item_rewrite");

            if (itemTypeArr != null && itemNameArr != null && itemPageArr != null && itemTempletArr != null && itemRewriteArr != null)
            {
                if ((itemTypeArr.Length == itemNameArr.Length) && (itemNameArr.Length == itemPageArr.Length)
                    && (itemPageArr.Length == itemTempletArr.Length) && (itemTempletArr.Length == itemRewriteArr.Length))
                {
                    for (int i = 0; i < itemTypeArr.Length; i++)
                    {
                        Model.url_rewrite urlModel = new Model.url_rewrite();
                        urlModel.name = itemNameArr[i].Trim();
                        urlModel.type = itemTypeArr[i].Trim();
                        urlModel.page = itemPageArr[i].Trim();
                        urlModel.inherit = GetInherit(urlModel.type);
                        urlModel.templet = itemTempletArr[i].Trim();
                        urlModel.channel = model.name;

                        List<Model.url_rewrite_item> itemLs = new List<Model.url_rewrite_item>();
                        string[] urlRewriteArr = itemRewriteArr[i].Split('&'); //分解URL重写字符串
                        for (int j = 0; j < urlRewriteArr.Length; j++)
                        {
                            string[] urlItemArr = urlRewriteArr[j].Split(',');
                            if (urlItemArr.Length == 3)
                            {
                                itemLs.Add(new Model.url_rewrite_item { path = urlItemArr[0], pattern = urlItemArr[1], querystring = urlItemArr[2] });
                            }
                        }
                        urlModel.url_rewrite_items = itemLs;
                        urlBll.Add(urlModel);
                    }
                }
            }
            #endregion

            AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加频道" + model.title); //记录日志
            return true;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            BLL.channel bll = new BLL.channel();
            Model.channel model = bll.GetModel(_id);

            string old_name = model.name;
            model.category_id = Utils.StrToInt(ddlCategoryId.SelectedValue, 0);
            model.name = txtName.Text.Trim();
            model.title = txtTitle.Text.Trim();
            model.is_albums = 0;
            model.is_attach = 0;
            model.is_group_price = 0;
            if (cbIsAlbums.Checked == true)
            {
                model.is_albums = 1;
            }
            if (cbIsAttach.Checked == true)
            {
                model.is_attach = 1;
            }
            if (cbIsGroupPrice.Checked == true)
            {
                model.is_group_price = 1;
            }
            model.page_size = Utils.StrToInt(txtPageSize.Text.Trim(), 10);
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);

            //添加频道扩展字段
            List<Model.channel_field> ls = new List<Model.channel_field>();
            for (int i = 0; i < cblAttributeField.Items.Count; i++)
            {
                if (cblAttributeField.Items[i].Selected)
                {
                    ls.Add(new Model.channel_field { channel_id = model.id, field_id = Utils.StrToInt(cblAttributeField.Items[i].Value, 0) });
                }
            }
            model.channel_fields = ls;

            if (!bll.Update(model))
            {
                return false;
            }

            #region 保存URL配置
            BLL.url_rewrite urlBll = new BLL.url_rewrite();
            urlBll.Remove("channel", old_name); //先删除旧的
            string[] itemTypeArr = Request.Form.GetValues("item_type");
            string[] itemNameArr = Request.Form.GetValues("item_name");
            string[] itemPageArr = Request.Form.GetValues("item_page");
            string[] itemTempletArr = Request.Form.GetValues("item_templet");
            string[] itemRewriteArr = Request.Form.GetValues("item_rewrite");

            if (itemTypeArr != null && itemNameArr != null && itemPageArr != null && itemTempletArr != null && itemRewriteArr != null)
            {
                if ((itemTypeArr.Length == itemNameArr.Length) && (itemNameArr.Length == itemPageArr.Length)
                    && (itemPageArr.Length == itemTempletArr.Length) && (itemTempletArr.Length == itemRewriteArr.Length))
                {
                    for (int i = 0; i < itemTypeArr.Length; i++)
                    {
                        Model.url_rewrite urlModel = new Model.url_rewrite();
                        urlModel.name = itemNameArr[i].Trim();
                        urlModel.type = itemTypeArr[i].Trim();
                        urlModel.page = itemPageArr[i].Trim();
                        urlModel.inherit = GetInherit(urlModel.type);
                        urlModel.templet = itemTempletArr[i].Trim();
                        urlModel.channel = model.name;

                        List<Model.url_rewrite_item> itemLs = new List<Model.url_rewrite_item>();
                        string[] urlRewriteArr = itemRewriteArr[i].Split('&'); //分解URL重写字符串
                        for (int j = 0; j < urlRewriteArr.Length; j++)
                        {
                            string[] urlItemArr = urlRewriteArr[j].Split(',');
                            if (urlItemArr.Length == 3)
                            {
                                itemLs.Add(new Model.url_rewrite_item { path = urlItemArr[0], pattern = urlItemArr[1], querystring = urlItemArr[2] });
                            }
                        }
                        urlModel.url_rewrite_items = itemLs;
                        urlBll.Add(urlModel);
                    }
                }
            }
            #endregion

            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改频道" + model.title); //记录日志
            return true;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("site_channel_list", MXEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改频道信息成功！", "channel_list.aspx", "Success", "parent.loadMenuTree");
            }
            else //添加
            {
                ChkAdminLevel("site_channel_list", MXEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加频道信息成功！", "channel_list.aspx", "Success", "parent.loadMenuTree");
            }
        }
    }
}