using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;

namespace WechatBuilder.Web.admin.article
{
    public partial class wx_category_list : Web.UI.ManagePage
    {
        protected int channel_id;
        protected string channel_name = string.Empty; //频道名称

        protected void Page_Load(object sender, EventArgs e)
        {
            this.channel_id = MXRequest.GetQueryInt("channel_id");
            this.channel_name = new BLL.channel().GetChannelName(this.channel_id); //取得频道名称
            if (this.channel_id == 0)
            {
                JscriptMsg("频道参数不正确！", "back", "Error");
                return;
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("fenlei", MXEnums.ActionEnum.View.ToString()); //检查权限
                RptBind();
            }
        }

        //数据绑定
        private void RptBind()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();

            BLL.article_category bll = new BLL.article_category();
            DataTable dt = bll.GetWCodeList(weixin.id, 0, this.channel_id);

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
                        dr["link_url"] = "<span class=\"lianjie_wai\">[外]</span>" + " <a href=\"javascript:;\" title=\"" + dr["link_url"].ToString() + "\">" + Utils.CutString(dr["link_url"].ToString(), 40) + "</a>";
                    }
                    else
                    {
                        dr["link_url"] = "<span class=\"lianjie_ben\">[本]</span>" + " <a href=\"javascript:;\">" + MyCommFun.getWebSite() + "/list.aspx?wid=" + MyCommFun.ObjToStr(dr["wid"]) + "&cid=" + dr["id"] + "</a>";
                    }

                }
                dt.AcceptChanges();
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
            ChkAdminLevel("fenlei", MXEnums.ActionEnum.Edit.ToString()); //检查权限
            BLL.article_category bll = new BLL.article_category();
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
            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "保存" + this.channel_name + "微网站分类排序"); //记录日志
            JscriptMsg("保存排序成功！", Utils.CombUrlTxt("wx_category_list.aspx", "channel_id={0}", this.channel_id.ToString()), "Success");
        }

        //删除类别
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("fenlei", MXEnums.ActionEnum.Delete.ToString()); //检查权限
            BLL.article_category bll = new BLL.article_category();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.Delete(id);
                }
            }
            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "删除" + this.channel_name + "微网站分类数据"); //记录日志
            JscriptMsg("删除数据成功！", Utils.CombUrlTxt("wx_category_list.aspx", "channel_id={0}", this.channel_id.ToString()), "Success");
        }
    }
}