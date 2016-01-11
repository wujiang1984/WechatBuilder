using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.admin.message
{
    public partial class AddMessage : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
            Model.wx_userweixin weixin = GetWeiXinCode();
            int wid = weixin.id;
            BLL.wx_message_setting gbll = new BLL.wx_message_setting();
            DataSet dr=  gbll.GetList(wid);
            if (dr.Tables[0].Rows.Count > 0)
              {
                  this.title.Text = dr.Tables[0].Rows[0]["title"].ToString();
                 // this.adminOpenid.Text = dr.Tables[0].Rows[0]["adminOpenid"].ToString();
                  this.picurl.Text = dr.Tables[0].Rows[0]["picUrl"].ToString();
                  this.needSH.SelectedValue = dr.Tables[0].Rows[0]["needSH"].ToString();
                  hidId.Value = dr.Tables[0].Rows[0]["id"].ToString();
              }
            
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            int wid = weixin.id;
            BLL.wx_message_setting settingBll = new BLL.wx_message_setting();
            int id = MyCommFun.Obj2Int(hidId.Value);
            //DataSet dr = gbll.GetList(wid);

            string title = this.title.Text.ToString();
            string adminOpenid = "";
            string picurl = this.picurl.Text.ToString();
            bool needSH = Convert.ToBoolean(this.needSH.SelectedValue);
               

            if (id > 0)
            {
                //update
              
                Model.wx_message_setting setting = settingBll.GetModel(id);

                setting.wid = wid;
                setting.title = title;
                setting.adminOpenid = adminOpenid;
                setting.picUrl = picurl;
                setting.needSH = needSH;
                settingBll.Update(setting);
         
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改留言板基本设置，主键为" + id); //记录日志
                JscriptMsg("修改成功", "AddMessage.aspx" , "Success");
            }
            else
            {
                
                Model.wx_message_setting setting = new Model.wx_message_setting();
                setting.wid = wid;
                setting.title = title;
                setting.adminOpenid = adminOpenid;
                setting.picUrl = picurl;
                setting.needSH = needSH;
               int iid= settingBll.Add(setting);

               AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加留言板基本设置，主键为" + iid); //记录日志
               JscriptMsg("添加成功",  "AddMessage.aspx", "Success");
            }
        
     

        }
    }
}