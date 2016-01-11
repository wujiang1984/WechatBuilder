using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using WechatBuilder.BLL;

namespace WechatBuilder.Web.admin.weixin
{
    public partial class editorWeiXin : Web.UI.ManagePage
    {

        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        BLL.wx_userweixin bll = new BLL.wx_userweixin();
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {
                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.wx_userweixin().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            else
            {
                //添加，则需要判断可以添加的微信号数量
                if (IsChaoGuoWxNum())
                {
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                txtapiurl.Text = MyCommFun.getWebSite() + "api/weixin/api.aspx";
                //  ChkAdminLevel("manager_list", MXEnums.ActionEnum.View.ToString()); //检查权限
                Model.manager model = GetAdminInfo(); //取得管理员信息

                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }



        #region 赋值操作=================================
        private void ShowInfo(int id)
        {

            Model.wx_userweixin model = bll.GetModel(id);
            this.id = model.id;

            this.txtwxName.Text = model.wxName;
            this.txtwxId.Text = model.wxId;

            this.txtweixinCode.Text = model.weixinCode;

            this.txtImgUrl.Text = model.headerpic;
            //this.txtapiurl.Text = model.apiurl;
            this.txtwxToken.Text = model.wxToken;

            this.txtAppId.Text = model.AppId;
            this.txtAppSecret.Text = model.AppSecret;
            txtapiurl.Text = MyCommFun.getWebSite() + "/api/weixin/api.aspx?apiid=" + model.id;
        }

        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
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
            Model.manager manager = GetAdminInfo();
            int uId = manager.id;
            string wxName = this.txtwxName.Text;
            string wxId = this.txtwxId.Text;

            string weixinCode = this.txtweixinCode.Text;
            string wxPwd = "";
            string headerpic = this.txtImgUrl.Text;
            string apiurl = "";
            string wxToken = this.txtwxToken.Text;
            string wxProvince = "";
            string wxCity = "";
            string AppId = this.txtAppId.Text;
            string AppSecret = this.txtAppSecret.Text;
            DateTime createDate = DateTime.Now;
            DateTime endDate = DateTime.Now.AddYears(1);


            Model.wx_userweixin model = new Model.wx_userweixin();

            model.uId = uId;
            model.wxName = wxName;
            model.wxId = wxId;
            model.yixinId = "";
            model.weixinCode = weixinCode;
            model.wxPwd = wxPwd;
            model.headerpic = headerpic;
            model.apiurl = apiurl;
            model.wxToken = wxToken;
            model.wxProvince = wxProvince;
            model.wxCity = wxCity;
            model.AppId = AppId;
            model.AppSecret = AppSecret;
            model.Access_Token = "";
            model.openIdStr = "";
            model.createDate = createDate;
            model.endDate = endDate;
            model.wenziMaxNum = -1;//-1为无限制
            model.tuwenMaxNum = -1;
            model.yuyinMaxNum = -1;
            model.wenziDefineNum = 0;
            model.tuwenDefineNum = 0;
            model.yuyinDefineNum = 0;
            model.requestTTNum = 0;
            model.requestUsedNum = 0;
            model.smsTTNum = 0;
            model.smsUsedNum = 0;
            model.isDelete = false;

            model.remark = "";
            model.seq = 99;

            if (IsChaoGuoWxNum())
            {
                return false;
            }

            int wId = bll.Add(model);
            this.id = wId;
            if (wId > 0)
            {
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加微信号，主键为:" + model.id + ",微信号为：" + model.weixinCode); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
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
            string apiurl = MyCommFun.getWebSite() + "/api/weixin/api.aspx?apiid=" + _id;
            string wxToken = this.txtwxToken.Text;
            string AppId = this.txtAppId.Text;
            string AppSecret = this.txtAppSecret.Text;
            bool noChangeAppProp = true;
            Model.wx_userweixin model = bll.GetModel(_id);

            model.wxName = wxName;
            model.wxId = wxId;
            model.weixinCode = weixinCode;
            model.headerpic = headerpic;
            model.apiurl = apiurl;
            model.wxToken = wxToken;

            if (model.AppId != AppId || model.AppSecret != AppSecret)
            {
                //改变了
                noChangeAppProp = false;
            }
            model.AppId = AppId;
            model.AppSecret = AppSecret;

            bool ret = bll.Update(model);

            if (ret)
            {
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改微信号，主键为:" + model.id + ",微信号为：" + model.weixinCode); //记录日志
                if (!noChangeAppProp)
                {  //更新access_token值
                    UpdateAccess_Token(_id, AppId, AppSecret);
                }
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
                // ChkAdminLevel("manager_list", MXEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改微信公众帐号信息成功！", "myweixinlist.aspx", "Success");
            }
            else //添加
            {
                // ChkAdminLevel("manager_list", MXEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }

                JscriptMsg("添加微信公众帐号信息成功！", "editorWeiXin.aspx?action=" + MXEnums.ActionEnum.Edit + "&id=" + this.id, "Success");
            }
        }

        /// <summary>
        ///  判断已经有的微信个数，若超过，则不能添加
        /// </summary>
        /// <returns>超过为true,未超过为false</returns>
        private bool IsChaoGuoWxNum()
        {
            Model.manager manager = GetAdminInfo();
            int hasNum = bll.GetUserWxNumCount(manager.id);
            if (hasNum >= manager.wxNum)
            {
                JscriptMsg("你只能添加" + manager.wxNum + "个微信公众帐号,若想添加多个，请联系管理员！", "myweixinlist.aspx", "Error");
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///  //更新access_token值
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="AppId"></param>
        /// <param name="AppSecret"></param>
        private void UpdateAccess_Token(int _id, string AppId, string AppSecret)
        {
            try
            {
                wx_property_info pBll = new wx_property_info();

                if (!pBll.ExistsWid(_id))
                {
                    return;
                }
                string newToken = "";

                try
                {
                    var result = Senparc.Weixin.MP.CommonAPIs.CommonApi.GetToken(AppId, AppSecret);
                    newToken = result.access_token;

                }
                catch (Exception ex)
                {
                    JscriptMsg("AppId或者AppSecret填写错误！", "", "Error");

                }
                finally
                {
                    //更新到数据库里
                    WechatBuilder.Model.wx_property_info wxProperty = pBll.GetModelList("iName='access_token' and wid=" + _id)[0];
                    wxProperty.iContent = newToken;
                    wxProperty.createDate = DateTime.Now;
                    pBll.Update(wxProperty);
                }
            }
            catch (Exception ex)
            {

            }


        }

    }
}