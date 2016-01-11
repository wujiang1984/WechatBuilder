using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using WechatBuilder.BLL;

namespace WechatBuilder.Web.admin.product
{
    public partial class product_sys_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        WechatBuilder.BLL.wx_product_sys bll = new WechatBuilder.BLL.wx_product_sys();
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
                if (!bll.Exists(this.id))
                {
                    JscriptMsg("产品库不存在或已被删除！", "back", "Error");
                    return;
                }
            }

            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int id)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            lblweixinUrl.Text = MyCommFun.getWebSite() + "/weixin/product/all.aspx?wid=" + weixin.id+"&pid="+id;

           
            WechatBuilder.Model.wx_product_sys model = bll.GetModel(id);
            this.lblId.Text = model.id.ToString();
            this.txthdTitle.Text = model.title;
            this.txtbgPic.Text = model.banner;
            imgBanner.ImageUrl = model.banner;
            txtwBrief.Text = model.remark;
            lblId.Text = id.ToString();

        }
        #endregion



        /// <summary>
        /// 保存配置信息
        /// </summary>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            WechatBuilder.Model.wx_product_sys model = new WechatBuilder.Model.wx_product_sys();

            try
            {
                Model.wx_userweixin weixin = GetWeiXinCode();
                int wId = weixin.id;
                string strErr = "";
                if (this.txthdTitle.Text.Trim().Length == 0)
                {
                    strErr += "活动标题不能为空！\\n";
                }
                if (this.txtbgPic.Text.Trim().Length == 0)
                {
                    strErr += "图片不能为空！\\n";
                }

                if (strErr != "")
                {
                    JscriptMsg(strErr, "", "Error");
                    return;
                }
                int id = int.Parse(this.lblId.Text);
                string hdTitle = this.txthdTitle.Text;
                string banner = this.txtbgPic.Text;

                bool isAdd = false;
                if (id == 0)
                {
                    isAdd = true;
                }
                else
                {
                    model = bll.GetModel(id);
                }
                model.title = hdTitle;
                model.banner = banner;
                model.wid = weixin.id;
                model.remark = txtwBrief.Text.Trim();
                model.sort_id = MyCommFun.Str2Int(txtSortId.Text);
                if (isAdd)
                {
                    bll.Add(model);
                }
                else
                {
                    bll.Update(model);
                }

                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "产品库设置成功"); //记录日志
                JscriptMsg("产品库设置成功！", "product_Sys.aspx", "Success");
            }
            catch
            {
                JscriptMsg("产品库设置失败！", "", "Error");
            }
        }
    }
}