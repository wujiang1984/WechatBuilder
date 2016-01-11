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
    public partial class gift_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        wx_ucard_gift gBll = new wx_ucard_gift();
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
                if (!gBll.Exists(id))
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
            Model.wx_ucard_gift gift = gBll.GetModel(id);
            txtgName.Text = gift.gName;
            txtuseContent.Value = gift.useContent;
            txtbeginDate.Text = gift.beginDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            txtendDate.Text = gift.endDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            txtscore.Text = gift.score == null ? "" : gift.score.Value.ToString();
              
        }

        #endregion



        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int id = MyCommFun.Str2Int(hidid.Value);
            #region  //先判断
            string strErr = "";
            if (this.txtgName.Text.Trim().Length == 0)
            {
                strErr += "名称不能为空！";
            }
            if (this.txtscore.Text.Trim().Length == 0)
            {
                strErr += "积分不能为空，并且为整数！";
            }

            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }

            
            #endregion
            Model.wx_ucard_gift gift = new Model.wx_ucard_gift();

            if (id > 0)
            {
                gift = gBll.GetModel(id);
            }

            gift.gName = txtgName.Text.Trim();
            gift.useContent = txtuseContent.Value.Trim();
            gift.sId = sid;
            gift.beginDate = MyCommFun.Obj2DateTime(txtbeginDate.Text);
            gift.endDate = MyCommFun.Obj2DateTime(txtendDate.Text);
            gift.score = MyCommFun.Str2Int(txtscore.Text.Trim());
            if (id <= 0)
            {  //新增

                //1新增主表
                id = gBll.Add(gift);
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加会员商家礼品券，主键为" + id); //记录日志
                JscriptMsg("添加会员商家礼品券成功！", "gift_list.aspx?id=" + sid, "Success");
            }
            else
            {   //修改
                //1修改主表
                gBll.Update(gift);
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改会员商家礼品券，主键为" + id); //记录日志
                JscriptMsg("修改会员商家礼品券成功！", "gift_list.aspx?id=" + sid, "Success");
            }

        }

    }
}