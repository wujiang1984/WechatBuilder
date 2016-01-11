using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;

namespace WechatBuilder.Web.admin.manager
{
    /// <summary>
    /// 编辑用户
    /// </summary>
    public partial class manager_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

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
                if (!new BLL.manager().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                    return;
                }
               
            }


            if (!Page.IsPostBack)
            {
                
                BindDdlProvince(ddlProvince);
                BindDdlCity(ddlCity);

                ChkAdminLevel("manager_list", MXEnums.ActionEnum.View.ToString()); //检查权限
                Model.manager model = GetAdminInfo(); //取得管理员信息
                RoleBind(ddlRoleId, model.role_type);
                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 角色类型=================================
        private void RoleBind(DropDownList ddl, int role_type)
        {
            BLL.manager_role bll = new BLL.manager_role();
            DataTable dt = bll.GetList("").Tables[0];

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("请选择角色...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["role_type"]) >= role_type)
                {
                    ddl.Items.Add(new ListItem(dr["role_name"].ToString(), dr["id"].ToString()));
                }
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            litpwdtip.Text = "不填则不修改密码";
            BLL.manager bll = new BLL.manager();
            Model.manager model = bll.GetModel(_id);
            ddlRoleId.SelectedValue = model.role_id.ToString();
            if (model.is_lock == 0)
            {
                cbIsLock.Checked = true;
            }
            else
            {
                cbIsLock.Checked = false;
            }
            txtUserName.Text = model.user_name;
            txtUserName.ReadOnly = true;
            txtUserName.Attributes.Remove("ajaxurl");
           
            txtRealName.Text = model.real_name;
            txtTelephone.Text = model.telephone;
            txtEmail.Text = model.email;
            txtMaxNum.Text = model.wxNum.ToString();
            ddlProvince.SelectedValue = model.province;
            ddlCity.SelectedValue = model.city;
            txtArea.Text = model.county;
            txtqq.Text = model.qq;
            txtEmail.Text = model.email;
            txtSortid.Text = MyCommFun.ObjToStr(model.sort_id);  // model.sort_id;
          

          }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            //地区
            string prov = ddlProvince.SelectedItem.Value;
            string city = ddlCity.SelectedItem.Value;
            string dist = txtArea.Text.Trim();


            Model.manager model = new Model.manager();
            BLL.manager bll = new BLL.manager();
            model.role_id = int.Parse(ddlRoleId.SelectedValue);
            model.role_type = new BLL.manager_role().GetModel(model.role_id).role_type;
            if (cbIsLock.Checked == true)
            {
                model.is_lock = 0;
            }
            else
            {
                model.is_lock = 1;
            }
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
            model.email = txtEmail.Text.Trim();
            model.add_time = DateTime.Now;
            model.wxNum = int.Parse(txtMaxNum.Text);
            model.agentId = GetAdminInfo().id;
            model.qq = txtqq.Text;
            model.email = txtEmail.Text;
            model.reg_ip = MXRequest.GetIP();
            model.province = prov;
            model.city = city;
            model.county = dist;
            model.sort_id=MyCommFun.Obj2Int(txtSortid.Text);

            if (bll.Add(model) > 0)
            {
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加用户:" + model.user_name); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            //地区
            string prov = ddlProvince.SelectedItem.Value;
            string city = ddlCity.SelectedItem.Value;
            string dist = txtArea.Text.Trim();


            bool result = false;
            BLL.manager bll = new BLL.manager();
            Model.manager model = bll.GetModel(_id);

            model.role_id = int.Parse(ddlRoleId.SelectedValue);
            model.role_type = new BLL.manager_role().GetModel(model.role_id).role_type;
            if (cbIsLock.Checked == true)
            {
                model.is_lock = 0;
            }
            else
            {
                model.is_lock = 1;
            }
            //判断密码是否更改
            if (txtPassword.Text.Trim() != "")
            {
                //获取用户已生成的salt作为密钥加密
                model.password = DESEncrypt.Encrypt(txtPassword.Text.Trim(), model.salt);
            }
            model.real_name = txtRealName.Text.Trim();
            model.telephone = txtTelephone.Text.Trim();
            model.email = txtEmail.Text.Trim();
            model.wxNum = int.Parse(txtMaxNum.Text);

            model.qq = txtqq.Text;
            model.email = txtEmail.Text;
          
            model.province = prov;
            model.city = city;
            model.county = dist;
            model.sort_id = MyCommFun.Str2Int(txtSortid.Text);

            if (bll.Update(model))
            {
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改用户:" + model.user_name); //记录日志
                result = true;
            }

            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (txtMaxNum.Text == "" || !MyCommFun.isNumber(txtMaxNum.Text))
            {
                JscriptMsg("请输入 可创建的微信帐号数量！", "", "Error");
                return;
            }
            if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("manager_list", MXEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改用户信息成功！", "manager_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("manager_list", MXEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加用户信息成功！", "manager_list.aspx", "Success");
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
    }
}