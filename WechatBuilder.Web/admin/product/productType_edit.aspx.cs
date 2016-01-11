using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;

namespace WechatBuilder.Web.admin.product
{
    public partial class productType_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型
      
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
           
            this.id = MXRequest.GetQueryInt("id");

         
            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {
                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.wx_product_type().Exists(this.id))
                {
                    JscriptMsg("类别不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                TreeBind();
                ProductTreeBind();
                ChkAdminLevel("producttype", MXEnums.ActionEnum.View.ToString()); //检查权限
                
                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                 
            }
        }

        #region 绑定类别=================================
        private void TreeBind()
        {
            BLL.wx_product_type bll = new BLL.wx_product_type();

            Model.wx_userweixin weixin = GetWeiXinCode();

            DataTable dt = bll.GetWCodeList(weixin.id,0);

            this.ddlParentId.Items.Clear();
            this.ddlParentId.Items.Add(new ListItem("无父级分类", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                int ClassLayer = int.Parse(dr["class_layer"].ToString());
                string Title = dr["tName"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    this.ddlParentId.Items.Add(new ListItem(Title, Id));
                }
                else
                {
                    Title = "├ " + Title;
                    Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                    this.ddlParentId.Items.Add(new ListItem(Title, Id));
                }
            }
        }
        #endregion

        #region 绑定产品库=================================
        private void ProductTreeBind()
        {
            BLL.wx_product_sys sbll = new BLL.wx_product_sys();

            Model.wx_userweixin weixin = GetWeiXinCode();

            DataTable dt = sbll.GetWCodeList(weixin.id);

            this.ddlPStore.Items.Clear();
            this.ddlPStore.Items.Add(new ListItem("默认产品库", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                
                string Title = dr["title"].ToString().Trim();

                this.ddlPStore.Items.Add(new ListItem(Title, Id));
               
            }
        }
        #endregion


        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.wx_product_type bll = new BLL.wx_product_type();
            Model.wx_product_type model = bll.GetModel(_id);

            txtTitle.Text = model.tName;
            txtSortId.Text = model.sort_id.ToString();
           
            txtLinkUrl.Text = model.tUrl;
            
            txtContent.Value = model.remark;
            txtImgICO.Text = model.icoPic;
            if (model.icoPic != null && model.icoPic.Trim() != "")
            {
                if (model.icoPic.Contains("/"))
                {
                    imgIco.ImageUrl = model.icoPic;
                }
                else
                {
                    imgIco.Style.Add("display", "none");
                    litImgIco.Text = "<span class=\"" + model.icoPic + "\"></span>";
                }
            }

            //父级分类
            ddlParentId.SelectedValue = model.parentId.ToString();
            if (model.store_id != null)
            {
                ddlPStore.SelectedValue = model.store_id.Value.ToString();
            }

            txttel.Text = model.tel;
            txtdaohangurl.Text = model.daohangurl;
            rblshowDefault.SelectedValue = model.showDefault == null ? "0" : (model.showDefault ? "1" : "0");


        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            try
            {
                Model.wx_product_type model = new Model.wx_product_type();
                BLL.wx_product_type bll = new BLL.wx_product_type();
              
                model.tName = txtTitle.Text.Trim();
               
                model.sort_id = int.Parse(txtSortId.Text.Trim());
                
                model.tUrl = txtLinkUrl.Text.Trim();
               int parentid=int.Parse(ddlParentId.SelectedValue);
                model.parentId = parentid;
                if (parentid > 0)
                {
                    Model.wx_product_type parentModel = bll.GetModel(parentid);
                    model.class_layer = parentModel.class_layer + 1;
                }
                else
                {
                    model.class_layer = 1;
                }
                model.store_id = int.Parse(ddlPStore.SelectedValue) ;
                model.remark = txtContent.Value;
                model.icoPic = Request.Form["txtImgICO"].Trim();// txtImgICO.Text;
                Model.wx_userweixin weixin = GetWeiXinCode();
                model.wid = weixin.id;
                model.creatDate = DateTime.Now;
                model.tel = txttel.Text;
                model.daohangurl = txtdaohangurl.Text;
                model.showDefault = rblshowDefault.SelectedItem.Value=="1"?true:false;

                if (bll.Add(model) > 0)
                {
                    AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加产品库分类:" + model.tName); //记录日志
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            try
            {
                BLL.wx_product_type bll = new BLL.wx_product_type();
                Model.wx_product_type model = bll.GetModel(_id);

                int parentid = int.Parse(ddlParentId.SelectedValue);
                model.parentId = parentid;
                if (parentid > 0)
                {
                    Model.wx_product_type parentModel = bll.GetModel(parentid);
                    model.class_layer = parentModel.class_layer + 1;
                }
                else
                {
                    model.class_layer = 1;
                }

                model.tName = txtTitle.Text.Trim();
                 
                model.sort_id = int.Parse(txtSortId.Text.Trim());
               
                model.tUrl = txtLinkUrl.Text.Trim();
                model.store_id = int.Parse(ddlPStore.SelectedValue);
                model.remark = txtContent.Value;
                model.icoPic = Request.Form["txtImgICO"].Trim();// txtImgICO.Text;
                model.tel = txttel.Text;
                model.daohangurl = txtdaohangurl.Text;
                model.showDefault = rblshowDefault.SelectedItem.Value == "1" ? true : false;
                if (bll.Update(model))
                {
                    AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改产品库分类:" + model.tName); //记录日志
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        #endregion

        //保存类别
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("producttype", MXEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {

                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改类别成功！", "prouductType_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("producttype", MXEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加类别成功！", "prouductType_list.aspx", "Success");
            }
        }
    }
}