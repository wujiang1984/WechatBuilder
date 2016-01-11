using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using WechatBuilder.BLL;

namespace WechatBuilder.Web.shopmgr.catalog
{
    public partial class attribute_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        wx_shop_catalog_attribute caBll = new wx_shop_catalog_attribute();
        public int catalogId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            int id = 0;
            catalogId = MyCommFun.RequestInt("catalogid");
            if (catalogId == 0)
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }
            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {

                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out  id))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!caBll.Exists(id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                bindCatalog(_action);

                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(id);
                }

            }
        }

        /// <summary>
        /// 绑定商品类型
        /// </summary>
        private void bindCatalog(string _action)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            BLL.wx_shop_catalog cataBll = new wx_shop_catalog();
            IList<Model.wx_shop_catalog> cataList = cataBll.GetModelList("wid="+weixin.id);
            ddlCatalog.DataTextField = "cTitle";
            ddlCatalog.DataValueField = "id";
            ddlCatalog.DataSource = cataList;
            ddlCatalog.DataBind();
            if (string.IsNullOrEmpty(_action) || _action == MXEnums.ActionEnum.Add.ToString())
            {
                ddlCatalog.SelectedValue = catalogId.ToString();
            }

        }


        #region 赋值操作=================================
        private void ShowInfo(int id)
        {
            hidid.Value = id.ToString();
            Model.wx_shop_catalog_attribute catalog = caBll.GetModel(id);
            hidid.Value = catalog.id.ToString();
            txtaName.Text = catalog.aName.ToString();
            ddlCatalog.SelectedValue = catalog.catalogId.Value.ToString();
            radType.SelectedValue = catalog.aType.Value.ToString();
            txtaValue.Value = catalog.aValue;
            txtsort_id.Text = catalog.sort_id.Value.ToString();

        }

        #endregion



        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            int id = MyCommFun.Str2Int(hidid.Value);
            #region  //先判断
            string strErr = "";
            if (this.txtaName.Text.Trim().Length == 0)
            {
                strErr += "商品属性名称不能为空！";
            }

            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }

            #endregion

            #region 赋值
            Model.wx_shop_catalog_attribute cataAttr = new Model.wx_shop_catalog_attribute();

            if (id > 0)
            {
                cataAttr = caBll.GetModel(id);
            }

            cataAttr.aName = txtaName.Text.Trim();
            cataAttr.catalogId =MyCommFun.Str2Int(ddlCatalog.SelectedItem.Value);
            cataAttr.aType = MyCommFun.Str2Int(radType.SelectedItem.Value);
            cataAttr.aValue = txtaValue.Value.Trim();
            cataAttr.sort_id = MyCommFun.Str2Int(txtsort_id.Text.Trim());


            #endregion

            if (id <= 0)
            {  //新增
                cataAttr.wid = weixin.id;
                cataAttr.createDate = DateTime.Now;
                //1新增主表
                id = caBll.Add(cataAttr);

                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加商品属性，主键为" + id); //记录日志
                JscriptMsg("添加商品属性成功！", "attribute_list.aspx?id=" + catalogId, "Success");
            }
            else
            {   //修改

                caBll.Update(cataAttr);

                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改商品属性，主键为" + id); //记录日志
                JscriptMsg("修改商品属性成功！", "attribute_list.aspx?id=" + catalogId, "Success");
            }

        }
    }
}