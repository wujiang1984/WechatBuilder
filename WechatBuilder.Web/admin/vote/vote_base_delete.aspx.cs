using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.admin.vote
{
    public partial class vote_base_delete :Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id = Convert.ToInt32( Request.Params["id"]);
                int wid = Convert.ToInt32(Request.Params["wid"]);
                string txtKeywords = "";
                BLL.wx_vote_base gbll = new BLL.wx_vote_base();
                gbll.Delete(id, wid);

                BLL.wx_vote_item itembll = new BLL.wx_vote_item();
                itembll.Delete(id);

            
                AddAdminLog(MXEnums.ActionEnum.Delete.ToString(), "删除投票，id为" + id); //记录日志
                JscriptMsg("删除成功！", Utils.CombUrlTxt("vote_list.aspx", "keywords={0}", txtKeywords), "Success");

            }
        }
    }
}