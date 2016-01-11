using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.admin.diancai
{
    public partial class desk_number_add : Web.UI.ManagePage
    {
        protected static int shopid = 0;
        public static int ids = 0;
        public static string type = "";
        BLL.wx_diancai_desknum deskbll = new BLL.wx_diancai_desknum();
        Model.wx_diancai_desknum desk = new Model.wx_diancai_desknum();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                shopid = MyCommFun.RequestInt("shopid");
                ids = MyCommFun.RequestInt("id");
                type = MyCommFun.QueryString("type");
                if (type=="edite")
                {
                    desk = deskbll.GetModel(ids);
                    this.sortid.Text = desk.sortid.ToString() ;
                    this.deskName.Text = desk.deskName;
                    this.isStart.SelectedValue = desk.isStart.ToString();
                }

            }
        }

        protected void save_caidan_Click(object sender, EventArgs e)
        {     
            if(type=="add")
            {
        
            desk.shopid = shopid;
            desk.sortid = MyCommFun.Str2Int( this.sortid.Text);
            desk.deskName = this.deskName.Text;
            desk.isStart = Convert.ToBoolean(this.isStart.SelectedValue);
            desk.createDate = DateTime.Now;
            int id = deskbll.Add(desk);
            AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加桌号，主键为" + id); //记录日志
            JscriptMsg("增加成功！", Utils.CombUrlTxt("desk_number.aspx?shopid='" + shopid + "'&manage=managetype", "keywords={0}", ""), "Success");
            }

            if (type == "edite")
            {
                shopid = MyCommFun.RequestInt("shopid");
                desk.id = ids;
                desk.shopid = shopid;
                desk.sortid = MyCommFun.Str2Int(this.sortid.Text);
                desk.deskName = this.deskName.Text;
                desk.isStart = Convert.ToBoolean(this.isStart.SelectedValue);
                desk.createDate = DateTime.Now;
                deskbll.Update(desk);
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改桌号，主键为" + ids); //记录日志
                JscriptMsg("修改成功！", Utils.CombUrlTxt("desk_number.aspx?shopid='" + shopid + "'&manage=managetype", "keywords={0}", ""), "Success");
            }
        }
    }
}