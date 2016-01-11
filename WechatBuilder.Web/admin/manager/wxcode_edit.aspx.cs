using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using WechatBuilder.BLL;
namespace WechatBuilder.Web.admin.manager
{
    public partial class wxcode_edit : Web.UI.ManagePage
    {
        BLL.wx_userweixin bll = new BLL.wx_userweixin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                 int id = 0;

                if (!int.TryParse(Request.QueryString["id"] as string, out id))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.wx_userweixin().Exists(id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                    return;
                }

                ShowInfo(id);
            }
        }



        #region 赋值操作=================================
        private void ShowInfo(int id)
        {

            Model.wx_userweixin model = bll.GetModel(id);
            lblId.Text = model.id.ToString();
            this.txtwxName.Text = model.wxName;
            this.txtwxId.Text = model.wxId;
            this.txtweixinCode.Text = model.weixinCode;
            this.txtImgUrl.Text = model.headerpic;
            this.txtapiurl.Text =MyCommFun.getWebSite()+"/api/weixin/api.aspx?apiid="+ model.id;
            this.txtwxToken.Text = model.wxToken;

            this.txtAppId.Text = model.AppId;
            this.txtAppSecret.Text = model.AppSecret;
            txtEndTime.Text = model.endDate.Value.ToString("yyyy-MM-dd");
            lblEndDate.Text = model.endDate.Value.ToString("yyyy-MM-dd");
            lblAddDate.Text = model.createDate.Value.ToString("yyyy-MM-dd");
        }

        #endregion



        #region 修改操作=================================
        private bool DoEdit()
        {
            int _id =MyCommFun.Str2Int(lblId.Text);
            string strErr = "";
            if (this.txtwxName.Text.Trim().Length == 0)
            {
                strErr += "公众帐号名称不能为空！";
            }
            if (this.txtwxId.Text.Trim().Length == 0)
            {
                strErr += "公众号原始id不能为空！";
            }

            if (this.txtweixinCode.Text.Trim().Length == 0)
            {
                strErr += "微信号不能为空！";
            }
            if (this.txtwxToken.Text.Trim().Length == 0)
            {
                strErr += "TOKEN值不能为空！";
            }

            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return false;
            }

            string wxName = this.txtwxName.Text;
            string wxId = this.txtwxId.Text;
            string weixinCode = this.txtweixinCode.Text;
            string headerpic = this.txtImgUrl.Text;
            string apiurl = this.txtapiurl.Text;
            string wxToken = this.txtwxToken.Text;
            string AppId = this.txtAppId.Text;
            string AppSecret = this.txtAppSecret.Text;
            string endDate=this.txtEndTime.Text;
            Model.wx_userweixin model = bll.GetModel(_id);

            model.wxName = wxName;
            model.wxId = wxId;
            model.weixinCode = weixinCode;
            model.headerpic = headerpic;
            model.apiurl = apiurl;
            model.wxToken = wxToken;
            model.AppId = AppId;
            model.AppSecret = AppSecret;
            model.endDate =DateTime.Parse(endDate);
            bool ret = bll.Update(model);

            if (ret)
            {
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "【管理】修改微信号，主键为:" + model.id + ",微信号为：" + model.weixinCode); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            if (!DoEdit())
            {
                JscriptMsg("保存过程中发生错误！", "", "Error");
                return;
            }
            JscriptMsg("修改微信公众帐号信息成功！", "wxcodemgr.aspx", "Success");
        }


    }
}