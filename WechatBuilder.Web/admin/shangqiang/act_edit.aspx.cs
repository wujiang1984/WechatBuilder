using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using WechatBuilder.Common;

namespace WechatBuilder.Web.admin.shangqiang
{
    public partial class act_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        private int id = 0;
        BLL.wx_sq_act actBll = new BLL.wx_sq_act();
        //页面加载事件
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
                if (!actBll.Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("weixin_sq", MXEnums.ActionEnum.View.ToString()); //检查权限


                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }



        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            Model.wx_sq_act model = actBll.GetModel(_id);
            this.lblid.Text = model.id.ToString();
            rblisOpen.SelectedValue = model.isOpen==true?"1":"0";
            rblisShenghe.SelectedValue = model.shenghe==true ? "1" : "0";
            this.txtactName.Text = model.actName;
            txtImgUrl.Text = model.bannerPic.ToString();

            this.txtnoshengheTip.Text = model.noshengheTip;
            this.txtshengheTip.Text = model.shengheTip;

            this.txtendDate.Text = model.endDate.ToString();
            this.txtbeginDate.Text = model.beginDate.ToString();
            txtContent.InnerText = model.brief;
            this.txtSortId.Text = model.sort_id.ToString();


        }
        #endregion


        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();

            bool result = false;
            Model.wx_sq_act model = new Model.wx_sq_act();

            bool isOpen = this.rblisOpen.SelectedItem.Value == "1" ? true : false;
            string actName = this.txtactName.Text;
            string brief = this.txtContent.Value;
            bool shenghe = this.rblisShenghe.SelectedItem.Value == "1" ? true : false;
            string noshengheTip = this.txtnoshengheTip.Text;
            string shengheTip = this.txtshengheTip.Text;
            string bannerPic = this.txtImgUrl.Text;
            DateTime endDate = DateTime.Parse(this.txtendDate.Text);
            DateTime beginDate = DateTime.Parse(this.txtbeginDate.Text);

            int sort_id = MyCommFun.Str2Int(this.txtSortId.Text);

            model.id = id;
            model.wid = weixin.id;
            model.isOpen = isOpen;
            model.actName = actName;
            model.brief = brief;
            model.shenghe = shenghe;
            model.noshengheTip = noshengheTip;
            model.shengheTip = shengheTip;
            model.bannerPic = bannerPic;
            model.endDate = endDate;
            model.beginDate = beginDate;

            model.sort_id = sort_id;
            model.createDate = DateTime.Now;

            if (txtbeginDate.Text.Trim() != "")
            {
                if (MyCommFun.isDateTime(txtbeginDate.Text))
                {
                    model.beginDate = DateTime.Parse(txtbeginDate.Text);
                }
            }

            if (txtendDate.Text.Trim() != "")
            {
                if (MyCommFun.isDateTime(txtendDate.Text))
                {
                    model.endDate = DateTime.Parse(txtendDate.Text);
                }
            }
            if (actBll.Add(model) > 0)
            {
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加微信上墙活动信息:" + model.actName); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();

            bool result = false;
            Model.wx_sq_act model = actBll.GetModel(_id);

            bool isOpen = this.rblisOpen.SelectedItem.Value == "1" ? true : false;
            string actName = this.txtactName.Text;
            string brief = this.txtContent.Value;
            bool shenghe = this.rblisShenghe.SelectedItem.Value == "1" ? true : false;
            string noshengheTip = this.txtnoshengheTip.Text;
            string shengheTip = this.txtshengheTip.Text;
            string bannerPic = this.txtImgUrl.Text;
            int sort_id = MyCommFun.Str2Int(this.txtSortId.Text);

            model.id = id;
            model.wid = weixin.id;
            model.isOpen = isOpen;
            model.actName = actName;
            model.brief = brief;
            model.shenghe = shenghe;
            model.noshengheTip = noshengheTip;
            model.shengheTip = shengheTip;
            model.bannerPic = bannerPic;

            model.sort_id = sort_id;

            if (MyCommFun.isDateTime(txtbeginDate.Text))
            {
                model.beginDate = DateTime.Parse(txtbeginDate.Text);
            }

            if (MyCommFun.isDateTime(txtendDate.Text))
            {
                model.endDate = DateTime.Parse(txtendDate.Text);
            }


            if (actBll.Update(model))
            {

                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改微信上墙活动id:" + model.id); //记录日志
                result = true;
            }
            return result;
        }
        #endregion


        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txtactName.Text.Trim().Length == 0)
            {
                strErr += "名称不能为空！";
            }
            if (this.txtImgUrl.Text.Trim().Length == 0)
            {
                strErr += "图片不能为空！";
            }
            if (this.txtbeginDate.Text.Trim().Length == 0)
            {
                strErr += "开始时间不能为空！";
            }
            if (this.txtendDate.Text.Trim().Length == 0)
            {
                strErr += "结束时间不能为空！";
            }

            if (txtbeginDate.Text.Trim() != "")
            {
                if (MyCommFun.isDateTime(txtbeginDate.Text))
                {

                }
                else
                {
                    strErr += "开始时间格式错误！";
                }
            }

            if (txtendDate.Text.Trim() != "")
            {
                if (MyCommFun.isDateTime(txtendDate.Text))
                {

                }
                else
                {
                    strErr += "结束时间格式错误！";
                }
            }
            if (strErr != "")
            {
                JscriptMsg(strErr, "", "Error");
                return;
            }

            DateTime beginDate = DateTime.Parse(txtbeginDate.Text);
            DateTime endDate = DateTime.Parse(txtendDate.Text);
            if (beginDate >= endDate)
            {
                JscriptMsg("开始时间不能大于结束时间", "", "Error");
                return; 
            }
            if (this.rblisOpen.SelectedItem.Value == "1")
            {
                //验证这个时间段是否被占用了
                Model.wx_userweixin weixin = GetWeiXinCode();
                bool hasYZ = actBll.hasZYDateSet(this.id,weixin.id, beginDate, endDate);
                if (hasYZ)
                {
                    JscriptMsg("这个时间段被占用了", "", "Error");
                    return;
                }
            }



            if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("weixin_sq", MXEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("修改信息成功！", "baseinfo.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("weixin_sq", MXEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加信息成功！", "baseinfo.aspx", "Success");
            }
        }
    }
}