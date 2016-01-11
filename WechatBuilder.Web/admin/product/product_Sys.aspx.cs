using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using WechatBuilder.BLL;

namespace WechatBuilder.Web.admin.product
{
    public partial class product_Sys : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("productsys", MXEnums.ActionEnum.View.ToString()); //检查权限
                RptBind();
            }
        }

        //数据绑定
        private void RptBind()
        {
            BLL.wx_product_sys bll = new BLL.wx_product_sys();
            Model.wx_userweixin weixin = GetWeiXinCode();
            DataTable dt = bll.GetWCodeList(weixin.id);

            if (dt != null)
            {
                DataRow dr;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];
                    if (dr["banner"] != null && dr["banner"].ToString().Trim() != "")
                    {
                        if (dr["banner"].ToString().Contains("."))
                        {
                            dr["banner"] = "<img  src=\"" + dr["banner"].ToString() + "\" class=\"imgico\" />";
                        }
                        else
                        {
                            dr["banner"] = "<span  class=\"" + dr["banner"].ToString() + "\" />";
                        }
                    }
                    //链接处理，待做
                    if (dr["link_url"] != null && dr["link_url"].ToString().Trim() != "")
                    {
                        dr["link_url"] = "<span class=\"lianjie_wai\">[外]</span>" + " <a href=\"javascript:;\">" + dr["link_url"] + "</a>";
                    }
                    else
                    {
                        dr["link_url"] = "<span class=\"lianjie_ben\">[本]</span>" + " <a href=\"javascript:;\">" + MyCommFun.getWebSite() + "/weixin/product/all.aspx?wid=" + MyCommFun.ObjToStr(dr["wid"]) + "&pid=" + dr["id"] + "</a>";
                    }

                }
            }

            this.rptList.DataSource = dt;
            this.rptList.DataBind();
        }

        //美化列表
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            //{
            //    Literal LitFirst = (Literal)e.Item.FindControl("LitFirst");
            //    HiddenField hidLayer = (HiddenField)e.Item.FindControl("hidLayer");
            //    string LitStyle = "<span style=\"display:inline-block;width:{0}px;\"></span>{1}{2}";
            //    string LitImg1 = "<span class=\"folder-open\"></span>";
            //    string LitImg2 = "<span class=\"folder-line\"></span>";

            //    int classLayer = Convert.ToInt32(hidLayer.Value);
            //    if (classLayer == 1)
            //    {
            //        LitFirst.Text = LitImg1;
            //    }
            //    else
            //    {
            //        LitFirst.Text = string.Format(LitStyle, (classLayer - 2) * 24, LitImg2, LitImg1);
            //    }
            //}
        }

        //保存排序
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("productsys", MXEnums.ActionEnum.Edit.ToString()); //检查权限
            BLL.wx_product_sys bll = new BLL.wx_product_sys();
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
            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "保存产品库排序"); //记录日志
            JscriptMsg("保存排序成功！", "product_Sys.aspx", "Success");
        }

        //删除类别
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("productsys", MXEnums.ActionEnum.Delete.ToString()); //检查权限
            BLL.wx_product_type bll = new BLL.wx_product_type();
            int errNum = 0;
            int succNum = 0;
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        succNum++;
                    }
                    else
                    {
                        errNum++;
                    }
                }
            }
            if (errNum > 0)
            {
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "删除产品库数据"); //记录日志
                JscriptMsg("有" + errNum + "失败，该产品库被占用，则无法删掉！", "product_Sys.aspx", "Success");
            }
            else
            {
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "删除产品库数据"); //记录日志
                JscriptMsg("删除数据成功！", "product_Sys.aspx", "Success");
            }

        }
      
    }
}