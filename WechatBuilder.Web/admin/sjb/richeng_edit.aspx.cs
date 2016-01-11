using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.admin.sjb
{
    public partial class richeng_edit : Web.UI.ManagePage
    {
        protected int wid = 0;
        public string type = "";
        public int richengid = 0;
        BLL.wx_sjb_richeng richengbll = new BLL.wx_sjb_richeng();
        Model.wx_sjb_richeng richeng = new Model.wx_sjb_richeng();


        protected void Page_Load(object sender, EventArgs e)
        {
            type = MyCommFun.QueryString("type");
            richengid = MyCommFun.RequestInt("id");
            if(!IsPostBack)
            {
                if (type=="edite")
               {
               eidtelist(richengid);
               }
            }
        }

        public void eidtelist(int richengid)
        {
            richeng = richengbll.GetModel(richengid);
            if (richeng!=null)
            {
            this.rcName.Text = richeng.rcName;
            this.beginDate.Text = richeng.beginDate.ToString();
            this.endDate.Text = richeng.endDate.ToString();
            this.rcPic.Text = richeng.rcPic.ToString();
            this.remark.InnerText = richeng.remark;
            this.sort_id.Text = richeng.sort_id.ToString();
            }
        }

        protected void save_richeng_Click(object sender, EventArgs e)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            wid = weixin.id;

            if (type=="add")
            {
                richeng.wid = wid;
                richeng.rcName = this.rcName.Text;
                richeng.beginDate = Convert.ToDateTime( this.beginDate.Text);
                richeng.endDate =  Convert.ToDateTime( this.endDate.Text);
                richeng.rcPic = this.rcPic.Text;
                richeng.remark = this.remark.InnerText;
                richeng.sort_id = Convert.ToInt32( this.sort_id.Text);
                richeng.createDate = DateTime.Now;

                int id= richengbll.Add(richeng);

                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "修改球队设置，主键为" + id); //记录日志
                JscriptMsg("增加成功！", "richeng_list.aspx", "Success");

            }

            if (type == "edite")
            {
                richeng.id = richengid;
                richeng.wid = wid;
                richeng.rcName = this.rcName.Text;
                richeng.beginDate = Convert.ToDateTime(this.beginDate.Text);
                richeng.endDate = Convert.ToDateTime(this.endDate.Text);
                richeng.rcPic = this.rcPic.Text;
                richeng.remark = this.remark.InnerText;
                richeng.sort_id = Convert.ToInt32(this.sort_id.Text);

                richengbll.Update(richeng);

                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改日程设置，主键为" + richengid); //记录日志
                JscriptMsg("增加成功！", "richeng_list.aspx", "Success");

            }
              
        }
    }
}