using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using WechatBuilder.BLL;

namespace WechatBuilder.Web.admin.wxRule
{
    public partial class subscribe : Web.UI.ManagePage
    {
        wx_requestRule rBll = new wx_requestRule();
        wx_requestRuleContent rcBll = new wx_requestRuleContent();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // ChkAdminLevel("site_config", MXEnums.ActionEnum.View.ToString()); //检查权限
                 
                string act = MyCommFun.QueryString("act");
                lblact.Text = act;
                if (act == "subscribe")
                {
                    lblreqestType.Text = "6"; //关注时
                    litNowPosition.Text = "关注时回复";
                    litNowPosition2.Text = "关注时回复";
                }
                else if (act == "default")
                {
                    lblreqestType.Text = "0"; //默认回复
                    litNowPosition.Text = "默认回复";
                    litNowPosition2.Text = "默认回复";
                }
                else if (act == "canel")
                {
                    lblreqestType.Text = "7"; //取消关注时
                    litNowPosition.Text = "取消关注时回复";
                    litNowPosition2.Text = "取消关注时回复";
                }
                ShowInfo();

            }
        }

        #region 赋值操作=================================
        private void ShowInfo()
        {
            Model.manager manager = GetAdminInfo();
            Model.wx_userweixin weixin = GetWeiXinCode();

            IList<Model.wx_requestRule> ruleList = rBll.GetModelList("wId=" + weixin.id + " and reqestType=" + lblreqestType.Text);
            if (ruleList != null && ruleList.Count > 0 && ruleList[0] != null)
            {
                hidId.Value = ruleList[0].id.ToString();
                Model.wx_requestRuleContent rc = new Model.wx_requestRuleContent();
                switch (ruleList[0].responseType)
                {
                    case 1:
                        //纯文本
                        rc = rcBll.GetModelList("rId=" + ruleList[0].id)[0];
                        txtContent.Text = rc.rContent;
                        rblResponseType.SelectedValue = "0";
                        MessageBox.ResponseScript(this, "$(\".wenben\").show();");
                        break;
                    case 2:
                        //图文
                        rblResponseType.SelectedValue = "1";
                        IList<Model.wx_requestRuleContent> rclist = rcBll.GetModelList("rId=" + ruleList[0].id+" order by seq");
                        rpnewsList.DataSource = rclist;
                        rpnewsList.DataBind();
                        MessageBox.ResponseScript(this, "$(\".picnews\").show(); $(\"#div_gongju\").hide();");
                        break;
                    case 3:
                        //语音
                        rc = rcBll.GetModelList("rId=" + ruleList[0].id)[0];
                        txtMusicFile.Text = rc.mediaUrl;
                        txtMusicTitle.Text = rc.rContent;
                        txtMusicRemark.Text = rc.remark;

                        rblResponseType.SelectedValue = "2";
                        MessageBox.ResponseScript(this, "$(\".music\").show();");
                        break;
                    default:
                         rblResponseType.SelectedValue = "0";
                        MessageBox.ResponseScript(this, "$(\".wenben\").show();");
                        break;

                }

            }
            else
            {
                rblResponseType.SelectedValue = "0";
                MessageBox.ResponseScript(this, "$(\".wenben\").show();");
            }


        }
        #endregion



        /// <summary>
        /// 保存配置信息
        /// </summary>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //ChkAdminLevel("site_config", MXEnums.ActionEnum.Edit.ToString()); //检查权限
            string ruleName = "";
            try
            {
                //保存之前，删除以前的数据
                int requestType = int.Parse(lblreqestType.Text);//请求的类别
              
                if (requestType == 6)
                {
                    ruleName = "关注时的触发内容";
                }
                else if (requestType == 0)
                {
                    ruleName = "默认回复内容";
                }
                else if(requestType == 7)
                {
                    ruleName = "取消关注时的触发内容";
                }
                Model.manager manager = GetAdminInfo();
                Model.wx_userweixin weixin = GetWeiXinCode();
                //添加前删除原来的数据
                rBll.DeleteRule(int.Parse(hidId.Value));
                Model.wx_requestRule rule = new Model.wx_requestRule();
                rule.uId = manager.id;
                rule.wId = weixin.id;
                rule.ruleName = ruleName;
                rule.reqestType = requestType; 
                rule.isDefault = false;
                rule.createDate = DateTime.Now;

                Model.wx_requestRuleContent rc = new Model.wx_requestRuleContent();
                if (rblResponseType.SelectedItem.Value == "0")
                {  //纯文本
                    //规则
                    if (this.txtContent.Text.Trim().Length == 0)
                    {
                        JscriptMsg("内容不能为空", "back", "Error");
                        return;
                    }

                    rule.responseType = 1;//回复的类型:文本1，图文2，语音3，视频4,第三方接口5
                    int rId = rBll.Add(rule);
                    //内容
                    rc.rId = rId;
                    rc.uId = manager.id;
                    rc.rContent = txtContent.Text.Trim();
                    rc.createDate = DateTime.Now;
                    rcBll.Add(rc);

                }
                else if (rblResponseType.SelectedItem.Value == "1")
                { //图文
                    rule.responseType = 2;//回复的类型:文本1，图文2，语音3，视频4,第三方接口5
                    int rId = rBll.Add(rule);
                }
                else if (rblResponseType.SelectedItem.Value == "2")
                {  //语音

                    if (this.txtMusicTitle.Text.Trim().Length == 0)
                    {
                        JscriptMsg("音乐不能为空", "back", "Error");
                        return;
                    }
                    if (this.txtMusicFile.Text.Trim().Length == 0)
                    {
                        JscriptMsg("音乐链接不能为空", "back", "Error");
                        return;
                    }


                    //规则
                    rule.responseType = 3;//回复的类型:文本1，图文2，语音3，视频4,第三方接口5
                    int rId = rBll.Add(rule);

                    //内容
                    rc.rId = rId;
                    rc.uId = manager.id;
                    rc.createDate = DateTime.Now;
                    rc.mediaUrl = txtMusicFile.Text;
                    rc.rContent = txtMusicTitle.Text;
                    rc.remark = txtMusicRemark.Text;
                    rcBll.Add(rc);

                }
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "编辑" + ruleName); //记录日志
                JscriptMsg("编辑" + ruleName + "成功！", "subscribe.aspx?act=" + MyCommFun.QueryString("act"), "Success");
            }
            catch
            {
                JscriptMsg("编辑" + ruleName + "有问题！", "subscribe.aspx?act=" + MyCommFun.QueryString("act"), "Error");
            }
        }

        /// <summary>
        /// 命令
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "delete":
                    {
                        int id = int.Parse(e.CommandArgument.ToString());
                        rcBll.Delete(id);
                        Response.Write("<script>location.href=location.href;</script>");
                    }
                    break;
            }
        }

    }
}