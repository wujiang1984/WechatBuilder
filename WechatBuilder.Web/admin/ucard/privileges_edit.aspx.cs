using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using WechatBuilder.BLL;

namespace WechatBuilder.Web.admin.ucard
{
    public partial class privileges_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        wx_ucard_privileges pBll = new wx_ucard_privileges();
        protected int sid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            sid = MyCommFun.RequestInt("sid");
            if (sid == 0)
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }
            int id = 0;
            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {

                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out  id))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!pBll.Exists(id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                BindUserDegree(sid);
                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(id);
                }

            }
        }

        private void BindUserDegree(int sid)
        {
            BLL.wx_ucard_udegree degreeBll = new wx_ucard_udegree();
            IList<Model.wx_ucard_udegree> degreelist = degreeBll.GetModelList("sid=" + sid);
            cbluserDegree.DataValueField = "degreeNum";
            cbluserDegree.DataTextField = "callName";
            cbluserDegree.DataSource = degreelist;
            cbluserDegree.DataBind();
            cbluserDegree.Items.Insert(0, new ListItem("全部会员", "0"));
        }


        #region 赋值操作=================================
        private void ShowInfo(int id)
        {
            hidid.Value = id.ToString();
            Model.wx_ucard_privileges notice = pBll.GetModel(id);
            txtnName.Text = notice.pName;
            txtusedContent.Value = notice.usedContent;
            txtbeginDate.Text = notice.beginDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            txtendDate.Text = notice.endDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            //赋值操作权限类型
            if (notice.userDegree != null && notice.userDegree.Trim() != "")
            {
                string[] actionTypeArr = notice.userDegree.Split(',');
                for (int i = 0; i < cbluserDegree.Items.Count; i++)
                {
                    for (int n = 0; n < actionTypeArr.Length; n++)
                    {
                        if (actionTypeArr[n].ToLower() == cbluserDegree.Items[i].Value.ToLower())
                        {
                            cbluserDegree.Items[i].Selected = true;
                        }
                    }
                }
            }

        }

        #endregion



        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            int id = MyCommFun.Str2Int(hidid.Value);
            #region  //先判断
            string strErr = "";
            if (this.txtnName.Text.Trim().Length == 0)
            {
                strErr += "特权名称不能为空！";
            }
            if (this.txtusedContent.Value.Trim().Length == 0)
            {
                strErr += "使用说明的内容不能为空！";
            }

            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }

            #endregion
            Model.wx_ucard_privileges privileges = new Model.wx_ucard_privileges();

            if (id > 0)
            {
                privileges = pBll.GetModel(id);
            }

            privileges.pName = txtnName.Text.Trim();
            privileges.usedContent = txtusedContent.Value.Trim();
            privileges.sId = sid;
            privileges.beginDate = MyCommFun.Obj2DateTime(txtbeginDate.Text);
            privileges.endDate = MyCommFun.Obj2DateTime(txtendDate.Text);

            string action_type_str = string.Empty;
            if (cbluserDegree.Items[0].Selected)
            {
                privileges.userDegree = cbluserDegree.Items[0].Value;
            }
            else
            {
                action_type_str = ",";
                for (int i = 0; i < cbluserDegree.Items.Count; i++)
                {
                    if (cbluserDegree.Items[i].Selected)
                    {
                        action_type_str += cbluserDegree.Items[i].Value + ",";
                    }
                }
                privileges.userDegree =action_type_str;
            }
            if (id <= 0)
            {  //新增

                //1新增主表
                id = pBll.Add(privileges);
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加会员特权，主键为" + id); //记录日志
                JscriptMsg("添加会员特权成功！", "privileges_list.aspx?id=" + sid, "Success");
            }
            else
            {   //修改
                //1修改主表
                pBll.Update(privileges);
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改会员通知，主键为" + id); //记录日志
                JscriptMsg("修改会员特权成功！", "privileges_list.aspx?id=" + sid, "Success");
            }

        }

    }
}