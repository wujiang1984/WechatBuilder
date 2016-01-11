using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;

namespace WechatBuilder.Web.admin.product
{
    public partial class prouductType_list : Web.UI.ManagePage
    {
        protected string keywords = string.Empty;
        protected int  pid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("producttype", MXEnums.ActionEnum.View.ToString()); //检查权限
                ProductTreeBind();
                RptBind();
            }
        }

        //数据绑定
        private void RptBind()
        {
            BLL.wx_product_type bll = new BLL.wx_product_type();
            Model.wx_userweixin weixin = GetWeiXinCode();
            string keywords = MyCommFun.QueryString("keywords");
            int  pid = MyCommFun.RequestInt("pid");
            string whereStr = "wid="+weixin.id;
            if (keywords.Trim().Length > 0)
            {
                whereStr += " and tName like '%" + keywords.Trim()+ "%'";
            }
            if (pid > 0)
            {
                whereStr += " and store_id="+pid;
            }
            DataSet ds = bll.GetList(whereStr);
            if (ds == null || ds.Tables.Count<=0)
            {
                return;
            }
            DataTable dt = ds.Tables[0];
            if (dt != null)
            {
                DataRow dr;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];
                    if (dr["icoPic"] != null && dr["icoPic"].ToString().Trim() != "")
                    {
                        if (dr["icoPic"].ToString().Contains("."))
                        {
                            dr["icoPic"] = "<img  src=\"" + dr["icoPic"].ToString() + "\" class=\"imgico\" />";
                        }
                        else
                        {
                            dr["icoPic"] = "<span  class=\"" + dr["icoPic"].ToString() + "\" />";
                        }
                    }
                    //链接处理，待做
                    if (dr["tUrl"] != null && dr["tUrl"].ToString().Trim() != "")
                    {
                        dr["tUrl"] = "<span class=\"lianjie_wai\">[外]</span>" + " <a href=\"javascript:;\">" + dr["tUrl"] + "</a>";
                    }
                    else
                    {
                        dr["tUrl"] = "<span class=\"lianjie_ben\">[本]</span>" + " <a href=\"javascript:;\">" + MyCommFun.getWebSite() + "/weixin/product/index.aspx?wid=" + MyCommFun.ObjToStr(dr["wid"]) + "&tid=" + dr["id"] + "</a>";
                    }

                }
            }

            this.rptList.DataSource = dt;
            this.rptList.DataBind();
        }

        #region 绑定产品库=================================
        private void ProductTreeBind()
        {
            BLL.wx_product_sys sbll = new BLL.wx_product_sys();

            Model.wx_userweixin weixin = GetWeiXinCode();

            DataTable dt = sbll.GetWCodeList(weixin.id);

            this.ddlPStore.Items.Clear();
            this.ddlPStore.Items.Add(new ListItem("默认产品库", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();

                string Title = dr["title"].ToString().Trim();

                this.ddlPStore.Items.Add(new ListItem(Title, Id));

            }
        }
        #endregion


        //筛选类别
        protected void ddlPStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            string keyw = txtKeywords.Text;
            Response.Redirect(Utils.CombUrlTxt("prouductType_list.aspx", "pid={0}&keywords={1}",
               ddlPStore.SelectedValue, keyw));
        }
        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string keyw = txtKeywords.Text;
            Response.Redirect(Utils.CombUrlTxt("prouductType_list.aspx", "pid={0}&keywords={1}",
              ddlPStore.SelectedValue, keyw));
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
            ChkAdminLevel("producttype", MXEnums.ActionEnum.Edit.ToString()); //检查权限
            BLL.wx_product_type bll = new BLL.wx_product_type();
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
            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "保存产品库分类排序"); //记录日志
            JscriptMsg("保存排序成功！",  "prouductType_list.aspx", "Success");
        }

        //删除类别
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("producttype", MXEnums.ActionEnum.Delete.ToString()); //检查权限
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
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "删除产品库分类数据"); //记录日志
                JscriptMsg("有"+errNum+"失败，该分类被占用，则无法删掉！", "prouductType_list.aspx", "Success");
            }
            else
            {
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "删除产品库分类数据"); //记录日志
                JscriptMsg("删除数据成功！", "prouductType_list.aspx", "Success");
            }
          
        }
    }
}