using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using WechatBuilder.BLL;
using System.Linq;

namespace WechatBuilder.Web.admin.yuyue
{
    public partial class editYuyue : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        wx_yy_base yyBll = new wx_yy_base();
        wx_yy_control cBll = new wx_yy_control();

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
                if (!yyBll.Exists(id))
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
            Model.wx_yy_base yuyue = yyBll.GetModel(id);
            hidid.Value = yuyue.id.ToString();
            txttitle.Text = yuyue.title.ToString();
            txtaddr.Value = yuyue.addr;
            txtphone.Text = yuyue.phone;
            txtcontent.InnerText = yuyue.content;
            rblSMSTXType.SelectedValue =   yuyue.needSMS==true?"1":"0";
            //封面图片
            if (yuyue.picUrl != null && yuyue.picUrl.Trim()!="" && yuyue.picUrl.Trim() != "/images/noneimg.jpg")
            {
                txtImgUrl.Text = yuyue.picUrl;
                imgfacePicPic.ImageUrl = yuyue.picUrl;
            }

            //绑定控件的值
            //绑定奖项信息
            IList<Model.wx_yy_control> itemlist = cBll.GetModelList("formId=" + id + " order by seq asc");
           
           //系统内置控件
            //1手机号
            IList<Model.wx_yy_control> itemlist_sys_tel = (from c in itemlist where c.isSys == true && c.sysControlerType == "tel" select c).ToArray<Model.wx_yy_control>();
            if (itemlist_sys_tel != null && itemlist_sys_tel.Count > 0)
            {
                chkTelNeed.Checked = true;
                txtTelNeedName.Text = itemlist_sys_tel[0].cName;
                txtTelNeedValue.Text = itemlist_sys_tel[0].defaultValue;
                chkTelNeedBT.Checked = itemlist_sys_tel[0].isBiTian;
                txtTelNeedSortid.Text = itemlist_sys_tel[0].seq.ToString();
            }

            //2姓名
            IList<Model.wx_yy_control> itemlist_sys_name = (from c in itemlist where c.isSys == true && c.sysControlerType == "name" select c).ToArray<Model.wx_yy_control>();
            if (itemlist_sys_name != null && itemlist_sys_name.Count > 0)
            {
                chkNameNeed.Checked = true;
                txtNameNeedName.Text = itemlist_sys_name[0].cName;
                txtNameNeedValue.Text = itemlist_sys_name[0].defaultValue;
                chkNameNeedBT.Checked = itemlist_sys_name[0].isBiTian;
                txtNameNeedSortid.Text = itemlist_sys_name[0].seq.ToString();
            }

            //1时间
            IList<Model.wx_yy_control> itemlist_sys_date = (from c in itemlist where c.isSys == true && c.sysControlerType == "date" select c).ToArray<Model.wx_yy_control>();
            if (itemlist_sys_date != null && itemlist_sys_date.Count > 0)
            {
                chkDateNeed.Checked = true;
                txtDateNeedName.Text = itemlist_sys_date[0].cName;
                txtDateNeedValue.Text = itemlist_sys_date[0].defaultValue;
                chkDateNeedBT.Checked = itemlist_sys_date[0].isBiTian;
                txtDateNeedSortid.Text = itemlist_sys_date[0].seq.ToString();
            }



            //自定义控件
            IList<Model.wx_yy_control> itemlist_zdy = (from c in itemlist where c.isSys !=true select c).ToArray<Model.wx_yy_control>();
            if (itemlist_zdy != null && itemlist_zdy.Count > 0)
            {
                int count = itemlist_zdy.Count;
                DropDownList ddlType;
                TextBox txtName;
                TextBox txtValue;
                CheckBox chkBT;
                TextBox txtSeq;

                Model.wx_yy_control itemEntity = new Model.wx_yy_control();
                for (int i = 1; i <= count; i++)
                {
                    itemEntity = itemlist_zdy[(i - 1)];

                    ddlType = this.FindControl("ddl" + i + "Type") as DropDownList;
                    txtName = this.FindControl("txt" + i + "Name") as TextBox;
                    txtValue = this.FindControl("txt" + i + "Value") as TextBox;
                    txtSeq = this.FindControl("txt" + i + "Seq") as TextBox;
                    chkBT = this.FindControl("chk" + i + "Btx") as CheckBox;

                    ddlType.SelectedValue = itemEntity.cType;
                    txtName.Text = itemEntity.cName;
                    txtValue.Text = itemEntity.defaultValue;
                    txtSeq.Text =MyCommFun.Obj2Int(itemEntity.seq).ToString();
                    chkBT.Checked = itemEntity.isBiTian;

                    
                }

            }




            litwUrl.Text = MyCommFun.getWebSite() + "/weixin/yuyue/index.aspx?wid=" + yuyue.wid + "&id=" + id;

        }


        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            int id = MyCommFun.Str2Int(hidid.Value);
            #region  //先判断
            string strErr = "";
            if (this.txttitle.Text.Trim().Length == 0)
            {
                strErr += "活动名称不能为空！ ";
            }

            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }

            #endregion

            #region 赋值
            Model.wx_yy_base yuyue = new Model.wx_yy_base();

            if (id > 0)
            {
                yuyue = yyBll.GetModel(id);
            }

            string facePicc = "";
            if (txtImgUrl.Text.Trim() != "")
            {
                facePicc = txtImgUrl.Text.Trim();
            }
            yuyue.title = txttitle.Text.Trim();
            yuyue.addr = txtaddr.Value.Trim();
            yuyue.phone = txtphone.Text;
            yuyue.content = txtcontent.Value.ToString();
            yuyue.needSMS = rblSMSTXType.SelectedValue=="0"?false:true;
           
          
            yuyue.seq = 0;
            yuyue.picUrl = facePicc;

            #endregion

            

            if (id <= 0)
            {  //新增
                yuyue.wid = weixin.id;
                yuyue.createDate = DateTime.Now;
                //1新增主表
                id = yyBll.Add(yuyue);

                AddControl(id);
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加预约信息，主键为" + id); //记录日志
                JscriptMsg("添加预约信息成功！", "index.aspx", "Success");
            }
            else
            {   //修改
                yyBll.Update(yuyue);
                AddControl(id);
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改预约信息，主键为" + id); //记录日志
                JscriptMsg("修改预约信息成功！", "index.aspx", "Success");
            }

        }

        /// <summary>
        /// 添加表单控件
        /// </summary>
        /// <param name="formid"></param>
        public void AddControl(int formid)
        {
           
            cBll.DeleteYyFormControl(formid);

            DropDownList ddlType;
            TextBox txtName;
            TextBox txtValue;
            CheckBox chkBT;
            TextBox txtSeq;
            Model.wx_yy_control control = new Model.wx_yy_control();
            //系统内置控件的设置
            AddSysControl(formid);
           
            for (int i = 1; i <= 9; i++)
            {
                control = new Model.wx_yy_control();
                ddlType = this.FindControl("ddl" + i + "Type") as DropDownList;
                txtName = this.FindControl("txt" + i + "Name") as TextBox;
                txtValue = this.FindControl("txt" + i + "Value") as TextBox;
                txtSeq = this.FindControl("txt" + i + "Seq") as TextBox;
                chkBT = this.FindControl("chk" + i + "Btx") as CheckBox;

                if (txtName.Text.Trim() != "" && txtName.Text.Trim() != "")
                {
                    control.cType = ddlType.SelectedItem.Value;
                    control.cName = txtName.Text.Trim();
                    control.defaultValue = txtValue.Text.Trim();
                    control.isBiTian = chkBT.Checked;
                    control.seq = MyCommFun.Str2Int(txtSeq.Text);
                    control.formId = formid;
                    cBll.Add(control);
                }
            }
        }

        /// <summary>
        /// 设置系统内置的控件
        /// </summary>
        /// <param name="formid"></param>
        private void AddSysControl(int formid)
        {
            Model.wx_yy_control control = new Model.wx_yy_control();
            //1 手机号的设置
            bool needTel = false;
            if (rblSMSTXType.SelectedValue == "1" || chkTelNeed.Checked)
            {
                needTel = true;
            }
            if (needTel)
            {
                control.cName = txtTelNeedName.Text.Trim();
                control.cType = "0";
                control.defaultValue = txtTelNeedValue.Text.Trim();
                control.isBiTian = chkTelNeedBT.Checked;
                if (rblSMSTXType.SelectedValue == "1")
                {
                    control.isBiTian = true;
                }
                control.seq = MyCommFun.Str2Int(txtTelNeedSortid.Text);
                control.formId = formid;
                control.isSys = true;
                control.sysControlerType = "tel";
                cBll.Add(control);
            }

            //姓名
            if (chkNameNeed.Checked)
            {
                control.cName = txtNameNeedName.Text.Trim();
                control.cType = "0";
                control.defaultValue = txtNameNeedValue.Text.Trim();
                control.isBiTian = chkNameNeedBT.Checked;
                
                control.seq = MyCommFun.Str2Int(txtNameNeedSortid.Text);
                control.formId = formid;
                control.isSys = true;
                control.sysControlerType = "name";
                cBll.Add(control);
            }

            //时间
            if (chkDateNeed.Checked)
            {
                control.cName = txtDateNeedName.Text.Trim();
                control.cType = "0";
                control.defaultValue = txtDateNeedValue.Text.Trim();
                control.isBiTian = chkDateNeedBT.Checked;

                control.seq = MyCommFun.Str2Int(txtDateNeedSortid.Text);
                control.formId = formid;
                control.isSys = true;
                control.sysControlerType = "date";
                cBll.Add(control);
            }


        }

    }
}