using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.admin.diancai
{
    public partial class dianyuan_add : Web.UI.ManagePage
    {
        protected static int shopid = 0;
        protected static int ids = 0;
        protected static string type = "";
        BLL.wx_diancai_dianyuan dianyuanbll = new BLL.wx_diancai_dianyuan();
        Model.wx_diancai_dianyuan dianyuan = new Model.wx_diancai_dianyuan();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                shopid = MyCommFun.RequestInt("shopid");
                ids = MyCommFun.RequestInt("id");
                type = MyCommFun.QueryString("type");
                if (type=="edite")
                {
                    dianyuan = dianyuanbll.GetModel(ids);
                    this.dianyuanName.Text = dianyuan.dianyuanName;
                    this.userName.Text = dianyuan.userName;
                    this.pwd.Text = dianyuan.pwd;
                    this.beginTime.Text = dianyuan.beginTime.ToString();
                    this.userStatus.Value = Convert.ToString( dianyuan.userStatus);
                    this.remark.Text = dianyuan.remark;
                    this.dianyuanTel.Text = dianyuan.dianyuanTel;
                    this.endTime.Text = dianyuan.endTime.ToString();


                }
            }
        }

        protected void save_dianyuan_Click(object sender, EventArgs e)
        {
           if(type=="add")
          {
            dianyuan.shopid = shopid;
            dianyuan.dianyuanName = this.dianyuanName.Text;
            dianyuan.userName = this.userName.Text;
            dianyuan.pwd = this.pwd.Text;
            dianyuan.beginTime = Convert.ToDateTime( this.beginTime.Text);
            dianyuan.userStatus = Convert.ToInt32( this.userStatus.Value);
            dianyuan.remark = this.remark.Text;
            dianyuan.dianyuanTel = this.dianyuanTel.Text;
            if (this.endTime.Text!="")
            {
            dianyuan.endTime = Convert.ToDateTime( this.endTime.Text);
            }
            dianyuan.createDate = DateTime.Now;
            int id = dianyuanbll.Add(dianyuan);
            AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加店员，主键为" + id); //记录日志
            JscriptMsg("增加成功！", Utils.CombUrlTxt("dianyuan_manage.aspx?shopid='" + shopid + "'&manage=managetype", "keywords={0}", ""), "Success");
            }

            if(type=="edite")
            {
                dianyuan.id = ids;
                dianyuan.shopid = shopid;
                dianyuan.dianyuanName = this.dianyuanName.Text;
                dianyuan.userName = this.userName.Text;
                dianyuan.pwd = this.pwd.Text;
                dianyuan.beginTime = Convert.ToDateTime(this.beginTime.Text);
                dianyuan.userStatus = Convert.ToInt32(this.userStatus.Value);
                dianyuan.remark = this.remark.Text;
                dianyuan.dianyuanTel = this.dianyuanTel.Text;
                if (this.endTime.Text != "")
                {
                    dianyuan.endTime = Convert.ToDateTime(this.endTime.Text);
                }
                dianyuan.createDate = DateTime.Now;
                dianyuanbll.Update(dianyuan);
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改店员信息，主键为" + ids); //记录日志
                JscriptMsg("增加成功！", Utils.CombUrlTxt("dianyuan_manage.aspx?shopid='" + shopid + "'&manage=managetype", "keywords={0}", ""), "Success");

            }
        }
    }
}