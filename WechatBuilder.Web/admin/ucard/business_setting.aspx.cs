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
    public partial class business_setting : Web.UI.ManagePage
    {

        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        wx_ucard_sys storesysBll = new wx_ucard_sys();
       
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!Page.IsPostBack)
            {
                  ShowInfo();
            }
        }



        #region 赋值操作=================================
        private void ShowInfo()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            Model.wx_ucard_sys sys = new Model.wx_ucard_sys();
           IList<Model.wx_ucard_sys> syslist = storesysBll.GetModelList("wid="+weixin.id);
           if (syslist == null || syslist.Count <= 0)
           {
               return;
           }
           sys = syslist[0];
            hidid.Value =sys.id.ToString();

            txttradeContent.Value = sys.tradeContent;
            txttel.Text = sys.tradeTel;
             
        }

        #endregion



        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();

            
            int id = MyCommFun.Str2Int(hidid.Value);
            #region  //先判断
            string strErr = "";
            if (this.txttradeContent.Value.Trim().Length == 0)
            {
                strErr += "招商说明不能为空！";
            }
            if (this.txttel.Text.Trim().Length == 0)
            {
                strErr += "电话不能为空！";
            }

            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }

            #endregion

            #region 赋值
            Model.wx_ucard_sys storesys = new Model.wx_ucard_sys();
          
 
            if (id > 0)
            {
                storesys = storesysBll.GetModel(id);
            }

            storesys.tradeContent = txttradeContent.Value.Trim();
            storesys.tradeTel = txttel.Text.Trim();

            #endregion

            if (id <= 0)
            {  //新增
                storesys.wid = weixin.id;
                storesys.createDate = DateTime.Now;
                //1新增主表
                id = storesysBll.Add(storesys);


                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "会员卡商城设置，主键为" + id); //记录日志
                JscriptMsg("会员卡商城设置成功！", "business_list.aspx", "Success");
            }
            else
            {   //修改
                //1修改主表
                storesysBll.Update(storesys);

               

                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改会员卡商家，主键为" + id); //记录日志
                JscriptMsg("会员卡商城设置成功！", "business_list.aspx", "Success");
            }

        }

       

    }
}