using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.admin.picmgr
{
    public partial class picSelect : System.Web.UI.Page
    {
        WechatBuilder.BLL.wx_PicStore bll = new WechatBuilder.BLL.wx_PicStore();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDdl();
            }
        }

        private void BindDdl()
        {
            DataSet ds = bll.GetTemplatesList();
            ddlTemplates.DataTextField = "pictemplates";
            ddlTemplates.DataValueField = "pictemplates";
            ddlTemplates.DataSource = ds;
            ddlTemplates.DataBind();
            ddlTemplates.Items.Insert(0, new ListItem("用户上传图片", "0"));


        }
        /// <summary>
        /// 选择完模版后绑定图片信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            string templatesName = ddlTemplates.SelectedItem.Value;
            if (templatesName != "0")
            {
                div_userupload.Style.Add("display", "none");
            }
            else
            {
                div_userupload.Style.Add("display", "");
            }
            BindPic(templatesName);
        }

        private void BindPic(string templates)
        {
            if (templates == "0")
            {
                litPicStr.Text = "";
                return;
            }
            StringBuilder sb = new StringBuilder("");
            IList<WechatBuilder.Model.wx_PicStore> plist = bll.GetModelList("pictemplates='" + templates + "'");
            if (plist == null || plist.Count <= 0)
            {
                litPicStr.Text = "";
                return;
            }
            WechatBuilder.Model.wx_PicStore p = new WechatBuilder.Model.wx_PicStore();
            for (int i = 0; i < plist.Count; i++)
            {
                sb.Append("<li>");
                p = plist[i];
                //if (p.picType == 1)
                //{
                    //图片
                sb.Append("<label for=\"rad" + p.id + "\" class=\"picLabel\" > <table class=\"picTable\"><tr><td class=\"picTd\"><img src=\"" + p.picUri + "\"  disabled  /></td></tr><tr><td class=\"chkTd\"><input id=\"rad" + p.id + "\" class=\"radPic\" name=\"radPic\" value=\"" + p.picUri + "\" type=\"radio\" /><label >" + p.picName + "</label></td></tr></table></label>");
               // }
                //else if (p.picType == 2)
                //{
                //    //css3 
                //    sb.Append("<label for=\"rad" + p.id + "\" class=\"picLabel\"  > <table ><tr><td><span class=\"" + p.picUri + "\"     /></td></tr><tr><td><input id=\"rad" + p.id + "\" class=\"radPic\" name=\"radPic\" value=\"" + p.picUri + "\" type=\"radio\" /><label >" + p.picName + "</label></td></tr></table></label>");

                //}
                sb.Append("</li>");
            }


            litPicStr.Text = sb.ToString();

        }
    }
}