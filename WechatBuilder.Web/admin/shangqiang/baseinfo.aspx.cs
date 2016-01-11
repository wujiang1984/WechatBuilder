using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using WechatBuilder.Common;

namespace WechatBuilder.Web.admin.shangqiang
{
    public partial class baseinfo : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("weixin_sq", MXEnums.ActionEnum.View.ToString()); //检查权限
                RptBind();
            }
        }

        //数据绑定
        private void RptBind()
        {
            BLL.wx_sq_act bll = new BLL.wx_sq_act();
            Model.wx_userweixin weixin = GetWeiXinCode();
            DataSet actlist = bll.GetList("wid="+weixin.id);
            if (actlist != null && actlist.Tables.Count > 0 && actlist.Tables[0] != null && actlist.Tables[0].Rows.Count > 0)
            {
                DataRow dr;
                int count = actlist.Tables[0].Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    dr = actlist.Tables[0].Rows[i];
                    dr["link_url"] = MyCommFun.getWebSite() + "/weixin/shangqiang/index.aspx?wid="+weixin.id+"&aid="+dr["id"].ToString();
                
                }
            }
            this.rptList.DataSource = actlist;
            this.rptList.DataBind();
        }

        //美化列表
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
           
        }

        //保存排序
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("weixin_sq", MXEnums.ActionEnum.Edit.ToString()); //检查权限
            BLL.wx_sq_act bll = new BLL.wx_sq_act();
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
            JscriptMsg("保存排序成功！", "baseinfo.aspx", "Success");
        }

        //删除类别
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("weixin_sq", MXEnums.ActionEnum.Delete.ToString()); //检查权限
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
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "删除活动数据"); //记录日志
                JscriptMsg("有" + errNum + "失败，该活动被占用，则无法删掉！", "baseinfo.aspx", "Success");
            }
            else
            {
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "删除活动数据"); //记录日志
                JscriptMsg("删除数据成功！", "baseinfo.aspx", "Success");
            }

        }
      
    }
}