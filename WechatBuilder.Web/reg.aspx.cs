using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using WechatBuilder.Web.UI;
namespace WechatBuilder.Web
{
    public partial class reg : System.Web.UI.Page
    {
        ManagePage mp = new ManagePage();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                BindDdlProvince(ddlProvince);
                BindDdlCity(ddlCity);
            }
        }
        #region 地区绑定
        /// <summary>
        /// 绑定省份
        /// </summary>
        /// <param name="ddl"></param>
        public void BindDdlProvince(DropDownList ddl)
        {
            BLL.pre_common_district disBll = new BLL.pre_common_district();
            IList<Model.pre_common_district> disList = disBll.GetModelList("level=1");
            if (disList != null)
            {
                ddl.DataTextField = "name";
                ddl.DataValueField = "id";
                ddl.DataSource = disList;
                ddl.DataBind();
            }

        }

        /// <summary>
        /// 绑定省份
        /// </summary>
        /// <param name="ddl"></param>
        public void BindDdlCity(DropDownList ddl)
        {
            BLL.pre_common_district disBll = new BLL.pre_common_district();
            IList<Model.pre_common_district> disList = disBll.GetModelList("level=2");
            if (disList != null)
            {
                ddl.DataTextField = "name";
                ddl.DataValueField = "id";
                ddl.DataSource = disList;
                ddl.DataBind();
            }

        }

        /// <summary>
        /// 省级选择完以后，联动带出城市
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            string provId = ddlProvince.SelectedItem.Value;
            BLL.pre_common_district disBll = new BLL.pre_common_district();
            IList<Model.pre_common_district> disList = disBll.GetModelList("level=2 and upid=" + provId);
            if (disList != null)
            {
                ddlCity.DataTextField = "name";
                ddlCity.DataValueField = "id";
                ddlCity.DataSource = disList;
                ddlCity.DataBind();
            }
            MessageBox.ResponseScript(this, "$(\"#txtUserName\").focus();");

        }

        #endregion 
        #region 增加操作=================================
        private bool DoAdd()
        {
            //地区
            string prov = ddlProvince.SelectedItem.Value;
            string city = ddlCity.SelectedItem.Value;
            string dist = "";


            Model.manager model = new Model.manager();
            BLL.manager bll = new BLL.manager();
            model.role_id = 2;
            model.role_type = new BLL.manager_role().GetModel(model.role_id).role_type;
            model.is_lock = 0;
          
            //检测用户名是否重复
            if (bll.Exists(txtUserName.Text.Trim()))
            {
                return false;
            }
            model.user_name = txtUserName.Text.Trim();
            //获得6位的salt加密字符串
            model.salt = Utils.GetCheckCode(6);
            //以随机生成的6位字符串做为密钥加密
            model.password = DESEncrypt.Encrypt(txtPassword.Text.Trim(), model.salt);
            model.real_name = txtRealName.Text.Trim();
            model.telephone = txtTelephone.Text.Trim();
            model.email ="";
            model.add_time = DateTime.Now;
            model.wxNum = 3;
            model.agentId = 1;
            model.qq = txtqq.Text;
            model.email = "";
            model.reg_ip = MXRequest.GetIP();
            model.province = prov;
            model.city = city;
            model.county = dist;
            model.sort_id = 99;

            if (bll.Add(model) > 0)
            {
               // mp.AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "注册用户:" + model.user_name); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
          
            if (!DoAdd())
            {
                string msbox = "parent.jsprint(\"保存过程中发生错误！\", \"\", \"Error\")";
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
                //JscriptMsg("保存过程中发生错误！", "", "Error");
                return;
            }
           // JscriptMsg("注册成功,请等待审核通过！", "default.aspx", "Success");

            string msbox2 = "parent.jsprint(\"注册成功！请等待管理员审核\", \"default.aspx\", \"success\")";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox2, true);
        }
    }
}