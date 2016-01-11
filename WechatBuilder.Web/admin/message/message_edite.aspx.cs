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
    public partial class message_edite : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string txtKeywords = "";
                string openid = Request.Params["openId"];
                BLL.wx_message_list gbll = new BLL.wx_message_list();
                gbll.Deleteopenid(openid);


                BLL.wx_message_blacklist gbllblack = new BLL.wx_message_blacklist();
                Model.wx_userweixin weixin = GetWeiXinCode();
                int wid = weixin.id;
                DateTime datetime = DateTime.Now;

                //拉黑记录
                BLL.wx_message_blacklist settingBll = new BLL.wx_message_blacklist();
                Model.wx_message_blacklist setting = new Model.wx_message_blacklist();
                setting.wid = wid;
                setting.openid = openid;
                setting.blacktime = datetime;
                settingBll.Add(setting);

               // AddAdminLog(MXEnums.ActionEnum.Delete.ToString(), ""); //记录日志
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "增加黑名单，openid为" + openid); //记录日志
                JscriptMsg("拉黑成功！", Utils.CombUrlTxt("message_list.aspx", "keywords={0}", txtKeywords), "Success");
            }
            
        }

       
    }
}