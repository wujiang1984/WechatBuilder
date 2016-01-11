using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.admin.diancai
{
    public partial class caipin_manage_add : Web.UI.ManagePage
    {
        BLL.wx_diancai_caipin_manage managebll = new BLL.wx_diancai_caipin_manage();
        Model.wx_diancai_caipin_manage manage = new Model.wx_diancai_caipin_manage();
        protected static int shopid = 0;
        public static string type = "";
        public static int ids = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                type = MyCommFun.QueryString("type");
                shopid = MyCommFun.RequestInt("shopid");
                ids = MyCommFun.RequestInt("id");
                //categoryName绑定
                BindCaiPingType();
                if (type=="edite")
                {
                    manage = managebll.GetModel(ids);
                    this.cpName.Text = manage.cpName;
                    this.dllCategoryName.SelectedItem.Text = manage.categoryName;
                    this.cpPrice.Text = manage.cpPrice.ToString();
                    this.zkPrice.Text = manage.zkPrice.ToString();
                    this.priceUnite.Text = manage.priceUnite;
                    this.cpPic.Text = manage.cpPic;
                    this.picUrl.Text = manage.picUrl;
                    this.detailContent.InnerText = manage.detailContent;
                }

                
            }
        }

        protected void BindCaiPingType()
        {
            BLL.wx_diancai_caipin_category cBll = new BLL.wx_diancai_caipin_category();
            IList<Model.wx_diancai_caipin_category> cateList = cBll.GetModelList("shopid=" + shopid);
            dllCategoryName.DataValueField = "id";
            dllCategoryName.DataTextField = "categoryName";
            dllCategoryName.DataSource = cateList;
            dllCategoryName.DataBind();
            dllCategoryName.Items.Insert(0, new ListItem("请选择", ""));
        
        }

        protected void save_caidanmanage_Click(object sender, EventArgs e)
        {

            if (type=="add")
            {
            manage.shopid = shopid;
            manage.categoryid = Convert.ToInt32(this.dllCategoryName.SelectedItem.Value);
            manage.categoryName = this.dllCategoryName.SelectedItem.Text;
            manage.cpName = this.cpName.Text;
            manage.cpPrice = Convert.ToDecimal( this.cpPrice.Text);
            manage.zkPrice =Convert.ToDecimal( this.zkPrice.Text);
            manage.priceUnite = this.priceUnite.Text;
            manage.cpPic = this.cpPic.Text;
            manage.picUrl = this.picUrl.Text;
            manage.detailContent = this.detailContent.InnerText;
            manage.createDate = DateTime.Now;

            int id = managebll.Add(manage);
            AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加菜品管理，主键为" + id); //记录日志
            JscriptMsg("增加成功！", Utils.CombUrlTxt("caipin_manage.aspx?shopid=" + shopid + "&manage=managetype", "keywords={0}", ""), "Success");

            }

            if (type == "edite")
            {
                shopid = MyCommFun.RequestInt("shopid");
                manage.id = ids;
                manage.shopid = shopid;
                manage.categoryid = Convert.ToInt32(this.dllCategoryName.SelectedItem.Value);
                manage.cpName = this.cpName.Text;
                manage.cpPrice = Convert.ToDecimal(this.cpPrice.Text);
                manage.zkPrice = Convert.ToDecimal(this.zkPrice.Text);
                manage.priceUnite = this.priceUnite.Text;
                manage.cpPic = this.cpPic.Text;
                manage.picUrl = this.picUrl.Text;
                manage.detailContent = this.detailContent.InnerText;
                manage.createDate = DateTime.Now;
                managebll.Update(manage);

                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改菜品管理，主键为" + ids); //记录日志
                JscriptMsg("修改成功！", Utils.CombUrlTxt("caipin_manage.aspx?shopid=" + shopid + "&manage=managetype", "keywords={0}", ""), "Success");


            }
        }
    }
}