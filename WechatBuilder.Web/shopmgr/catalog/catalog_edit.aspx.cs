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
    public partial class catalog_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        wx_shop_catalog clBll = new wx_shop_catalog();

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            int id = 0;
            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {

                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out  id))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!clBll.Exists(id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {

                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(id);
                }

            }
        }



        #region 赋值操作=================================
        private void ShowInfo(int id)
        {
            hidid.Value = id.ToString();
            Model.wx_shop_catalog catalog = clBll.GetModel(id);
            hidid.Value = catalog.id.ToString();
            txtcTitle.Text = catalog.cTitle.ToString();
            txtremark.Value = catalog.remark;
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
            if (this.txtcTitle.Text.Trim().Length == 0)
            {
                strErr += "商品类型名称不能为空！";
            }

            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }

            #endregion

            #region 赋值
            Model.wx_shop_catalog catalog = new Model.wx_shop_catalog();

            if (id > 0)
            {
                catalog = clBll.GetModel(id);
            }

            catalog.cTitle = txtcTitle.Text.Trim();
            catalog.remark = txtremark.Value.Trim();
            catalog.sort_id = MyCommFun.Str2Int(txtsort_id.Text.Trim());
           

            #endregion

            if (id <= 0)
            {  //新增
                catalog.wid = weixin.id;
                catalog.createDate = DateTime.Now;
                //1新增主表
                id = clBll.Add(catalog);

                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加商品类型，主键为" + id); //记录日志
                JscriptMsg("添加商品类型成功！", "catalog_list.aspx", "Success");
            }
            else
            {   //修改

                clBll.Update(catalog);

                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改商品类型，主键为" + id); //记录日志
                JscriptMsg("修改商品类型成功！", "catalog_list.aspx", "Success");
            }

        }
    }
}