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
    public partial class store_fendian_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        wx_ucard_store_fendian fdBll = new wx_ucard_store_fendian();
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
                if (!fdBll.Exists(id))
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
            Model.wx_ucard_store_fendian fendian = fdBll.GetModel(id);

            txtarea.Text = fendian.area;
            txtaddr.Text = fendian.addr;
            txttel.Text = fendian.tel;
            txtLatXPoint.Text = fendian.xPoint.ToString();
            txtLngYPoint.Text = fendian.yPoint.ToString();
            txtSortId.Text = fendian.sort_id.Value.ToString();
            ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'> $(\"#baiduframe\").attr(\"src\", \"../lbs/MapSelectPoint.aspx?yjindu=" + fendian.yPoint.Value.ToString() + "&xweidu=" + fendian.xPoint.Value.ToString() + "\");</script>");

        }

        #endregion



        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            int id = MyCommFun.Str2Int(hidid.Value);
            #region  //先判断
            string strErr = "";
            if (this.txtarea.Text.Trim().Length == 0)
            {
                strErr += "区域不能为空！";
            }
             
            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }

            #endregion
            Model.wx_ucard_store_fendian fendian = new Model.wx_ucard_store_fendian();

            if (id > 0)
            {
                fendian = fdBll.GetModel(id);
            }

            fendian.area = txtarea.Text.Trim();
            fendian.addr = txtaddr.Text.Trim();
            fendian.xPoint = MyCommFun.Str2Decimal(txtLatXPoint.Text);
            fendian.yPoint = MyCommFun.Str2Decimal(txtLngYPoint.Text);
            fendian.sort_id = MyCommFun.Obj2Int(txtSortId.Text.Trim());
            fendian.tel = txttel.Text.Trim();
            fendian.sId = sid;
            if (id <= 0)
            {  //新增
                 
                fendian.createDate = DateTime.Now;
                //1新增主表
                id = fdBll.Add(fendian);
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加会员卡分店，主键为" + id); //记录日志
                JscriptMsg("添加会员卡分店成功！", "store_fendian.aspx?id=" + sid, "Success");
            }
            else
            {   //修改
                //1修改主表
                fdBll.Update(fendian);
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改会员卡分店，主键为" + id); //记录日志
                JscriptMsg("修改会员卡分店成功！", "store_fendian.aspx?id="+sid, "Success");
            }

        }

    }
}