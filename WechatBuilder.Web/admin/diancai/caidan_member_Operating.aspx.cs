using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.admin.diancai
{
    public partial class caidan_member_Operating : Web.UI.ManagePage
    {
        BLL.wx_diancai_blacklist blaqckbll = new BLL.wx_diancai_blacklist();
        Model.wx_diancai_blacklist blaqck = new Model.wx_diancai_blacklist();
        public static  string openid = "";
        public static int id = 0;
        public static int status = 0;
        public static string blackName = "";
        public static int shopid = 0; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                openid = MyCommFun.QueryString("openid");
                id = MyCommFun.RequestInt("id");
                status = MyCommFun.RequestInt("status");
                blackName = MyCommFun.QueryString("blackName");
                shopid = MyCommFun.RequestInt("shopid");

            }
        }

        protected void save_status_Click(object sender, EventArgs e)
        {

            blaqckbll.UpdateStatus(id, status);


            if (this.type.Value=="0")
            {
                blaqck.blackName = blackName;
                blaqck.openid = openid;
                blaqck.shopid = shopid;
                blaqck.blackDate = DateTime.Now;
                blaqck.createDate = DateTime.Now;
                blaqckbll.Add(blaqck);

            }
            if (this.type.Value == "1")
            {
                blaqckbll.Delete(openid);
            }


            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "编辑黑名单状态，id为："+id); //记录日志
            JscriptMsg("操作成功", Utils.CombUrlTxt("caidan_member_manage.aspx", "keywords={0}", ""), "Success");

        }
    }
}