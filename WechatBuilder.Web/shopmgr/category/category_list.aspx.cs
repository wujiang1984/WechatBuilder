using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using System.Text;
using System.Data;

namespace WechatBuilder.Web.shopmgr.category
{
    public partial class category_list : Web.UI.ManagePage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!Page.IsPostBack)
            {
               
                RptBind();
            }
        }

        //数据绑定
        private void RptBind()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();

            BLL.wx_shop_category bll = new BLL.wx_shop_category();
            DataTable dt = bll.GetWCodeList(weixin.id, 0);

            if (dt != null)
            {
                DataRow dr;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];
                    if (dr["ico_url"] != null && dr["ico_url"].ToString().Trim() != "")
                    {
                        if (dr["ico_url"].ToString().Contains("."))
                        {
                            dr["ico_url"] = "<img  src=\"" + dr["ico_url"].ToString() + "\" class=\"imgico\" />";
                        }
                        else
                        {
                            dr["ico_url"] = "<span  class=\"" + dr["ico_url"].ToString() + "\" />";
                        }
                    }
                    //链接处理，待做
                    if (dr["link_url"] != null && dr["link_url"].ToString().Trim() != "")
                    {

                    }
                    else
                    {

                    }

                }
            }

            this.rptList.DataSource = dt;
            this.rptList.DataBind();
        }

        //美化列表
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Literal LitFirst = (Literal)e.Item.FindControl("LitFirst");
                HiddenField hidLayer = (HiddenField)e.Item.FindControl("hidLayer");
                string LitStyle = "<span style=\"display:inline-block;width:{0}px;\"></span>{1}{2}";
                string LitImg1 = "<span class=\"folder-open\"></span>";
                string LitImg2 = "<span class=\"folder-line\"></span>";

                int classLayer = Convert.ToInt32(hidLayer.Value);
                if (classLayer == 1)
                {
                    LitFirst.Text = LitImg1;
                }
                else
                {
                    LitFirst.Text = string.Format(LitStyle, (classLayer - 2) * 24, LitImg2, LitImg1);
                }
            }
        }

        //保存排序
        protected void btnSave_Click(object sender, EventArgs e)
        {

            BLL.wx_shop_category bll = new BLL.wx_shop_category();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
                {
                    sortId = 99;
                }
                bll.UpdateField(id, "sort_id=" + sortId.ToString());
            }
            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "保存商品分类排序"); //记录日志
            JscriptMsg("保存排序成功！", Utils.CombUrlTxt("category_bottomMenu_list.aspx", "channel_id={0}"), "Success");
        }

        //删除类别
        protected void btnDelete_Click(object sender, EventArgs e)
        {
           // ChkAdminLevel("channel_" + this.channel_name + "_category", MXEnums.ActionEnum.Delete.ToString()); //检查权限
            BLL.wx_shop_category bll = new BLL.wx_shop_category();
            int sucCount = 0;
            int errorCount = 0;
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                   

                    if (bll.DeleteCategory(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }

                }
            }
            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "删除商品分类数据"); //记录日志

            if (errorCount > 0)
            {
                JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！ 分类被商品使用，则无法删除！", Utils.CombUrlTxt("category_list.aspx", ""), "Error");

            }
            else
            {
                JscriptMsg("删除成功" + sucCount + "条！", Utils.CombUrlTxt("category_list.aspx", ""), "Success");
            }
        }
    }
}