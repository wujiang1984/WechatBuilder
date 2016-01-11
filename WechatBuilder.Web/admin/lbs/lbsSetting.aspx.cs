using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using WechatBuilder.BLL;

namespace WechatBuilder.Web.admin.lbs
{
    public partial class lbsSetting : Web.UI.ManagePage
    {
        wx_lbs_setting sBll = new wx_lbs_setting();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ShowInfo();
            }
        }
    
        private void ShowInfo()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            if (sBll.ExistsWid(weixin.id))
           { 
                //存在
               Model.wx_lbs_setting model = sBll.GetModelList("wid=" + weixin.id)[0];
               txtsearchRadius.Text = model.searchRadius.Value.ToString();
               txtImgUrl.Text = model.bannerPicUrl;
               if (model.bannerPicUrl != null && model.bannerPicUrl.Trim().Length > 0)
               {
                   imgImgUrl.ImageUrl = model.bannerPicUrl;
               }
               hidid.ID = model.id.ToString();
            }
        }

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            #region 判断
            string strErr = "";
            if (this.txtsearchRadius.Text.Trim().Length == 0)
            {
                strErr += "默认查询范围不能为空！";
            }
            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");

                return;
            }
            #endregion

            int id =MyCommFun.Str2Int( hidid.Value);
            decimal searchRadius =MyCommFun.Str2Decimal( txtsearchRadius.Text);
            string imgpic = txtImgUrl.Text;
            Model.wx_lbs_setting setting = new Model.wx_lbs_setting();
            if (id>0) //修改
            {
                setting = sBll.GetModel(id);
                setting.searchRadius = searchRadius;
                setting.bannerPicUrl = imgpic;
                bool ret=  sBll.Update(setting);

                if (!ret)
                {
                    AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改lbs配置，主键为:" + setting.id); //记录日志
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改lbs基本配置成功！", "lbslist.aspx", "Success");
            }
            else //添加
            {
                Model.wx_userweixin weixin = GetWeiXinCode();
                setting.wid = weixin.id;
                setting.searchRadius = searchRadius;
                setting.bannerPicUrl = imgpic;
               int lengint= sBll.Add(setting);
               if (lengint<=0)
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
               AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加lbs基本配置成功，主键为:" + lengint); //记录日志
               JscriptMsg("添加lbs基本配置成功！", "lbslist.aspx", "Success");
            }
        }
    }
}