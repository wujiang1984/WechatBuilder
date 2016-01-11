using WechatBuilder.BLL;
using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.admin.wxRule
{
    public partial class addNews : Web.UI.ManagePage
    {
        wx_requestRule rBll = new wx_requestRule();
        wx_requestRuleContent rcBll = new wx_requestRuleContent();
       
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var rid = MyCommFun.QueryString("rid");
                this.hidrId.Value = rid;
                var id = MyCommFun.QueryString("id");
                this.hidId.Value = id;
                this.hidAction.Value = MyCommFun.QueryString("option");
              

                if (MyCommFun.QueryString("option") == "edit")
                {
                    BindData(int.Parse(id));
                }

            }
        }
        /// <summary>
        /// 编辑状态：赋值页面上的值
        /// </summary>
        /// <param name="id"></param>
        private void BindData(int id)
        {
            Model.wx_requestRuleContent rc = rcBll.GetModel(id);
            txtTitle.Value = rc.rContent;
            txtImgUrl.Text = rc.picUrl;

            txtContent.Value = rc.rContent2;
            txtUrl.Value = rc.detailUrl;
            txtSortId.Text =rc.seq.Value.ToString(); 
        }


        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string act = MyCommFun.QueryString("act");

            string ruleName = "";
            if (act == "subscribe")
            {

                ruleName = "关注时的触发内容";
            }
            else if (act == "default")
            {

                ruleName = "默认回复内容";
            }
            else if (act == "canel")
            {

                ruleName = "取消关注时的触发内容";
            }


            try
            {
               


                if (this.txtTitle.Value.Trim().Length == 0)
                {
                    JscriptMsg("标题不能为空", "back", "Error");
                    return;
                }
                Model.manager manager = GetAdminInfo();
                Model.wx_userweixin weixin = GetWeiXinCode();
            
                int  rid =int.Parse( hidrId.Value);//规则id
                Model.wx_requestRule rule = new Model.wx_requestRule();
                Model.wx_requestRuleContent rc = new Model.wx_requestRuleContent();
                if (rid == 0)
                { //说明没有添加过微信关注的回复内容
                    int NewRId = AddRule();
                    //内容
                    EditRuleContent(NewRId, 0);
                }
                else
                {
                    rule = rBll.GetModel(rid);
                    if (rule.responseType != 2)
                    {
                        //如果此前非图文内容，则删除原来的数据
                        rBll.DeleteRule(rid);

                        int NewRId = AddRule();
                        //内容
                        EditRuleContent(NewRId, 0);

                    }
                    else if (this.hidAction.Value.Trim().ToLower() == "add")
                    {
                        EditRuleContent(rid, 0);
                    }
                    else
                    {
                        int id = int.Parse(hidId.Value);
                        EditRuleContent(rid, id);
                    }


                }

              

                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "编辑" + ruleName); //记录日志
                MessageBox.ResponseScript(this, " api.close(); ");
            }
            catch
            {
                JscriptMsg("编辑" + ruleName + "有问题！", "", "Error");
            }


          
        }

        /// <summary>
        /// 添加规则
        /// </summary>
        /// <returns></returns>
        private int AddRule()
        {

            string act = MyCommFun.QueryString("act");
            int requestType = 6;
            string ruleName = "";
            if (act == "subscribe")
            {
                requestType = 6; //关注时
                ruleName = "关注时的触发内容";
            }
            else if (act == "default")
            {
                requestType = 0; //默认回复
                ruleName = "默认回复内容";
            }
            else if (act == "canel")
            {
                requestType = 7; //取消关注时
                ruleName = "取消关注时的触发内容";
            }



           
            Model.manager manager = GetAdminInfo();
            Model.wx_userweixin weixin = GetWeiXinCode();
            Model.wx_requestRule rule = new Model.wx_requestRule();

            rule.uId = manager.id;
            rule.wId = weixin.id;
            rule.ruleName = ruleName;
            rule.reqestType = requestType;// 
            rule.isDefault = false;
            rule.createDate = DateTime.Now;
            rule.responseType = 2;//回复的类型:文本1，图文2，语音3，视频4,第三方接口5
            int NewRId = rBll.Add(rule);
            return NewRId;
        }

        /// <summary>
        /// 编辑规则内容
        /// </summary>
        /// <param name="rid">规则主键id</param>
        /// <param name="id">规则内容主键id,如果是添加，则id=0</param>
        private void EditRuleContent(int rid,int id)
        {
            Model.manager manager = GetAdminInfo();

            Model.wx_requestRuleContent rc = new Model.wx_requestRuleContent();
            if (id != 0)
            {
                rc = rcBll.GetModel(id);
            }
            if (id == 0)
            {
                rc.rId = rid;
                rc.uId = manager.id;
                rc.createDate = DateTime.Now;
            }
            rc.rContent = txtTitle.Value.Trim();
            rc.picUrl = txtImgUrl.Text;
            rc.rContent2 = txtContent.Value.Trim();
            rc.detailUrl = txtUrl.Value.Trim();
            rc.seq = int.Parse(txtSortId.Text.Trim());
            if (id == 0)
            {
                rcBll.Add(rc);
            }
            else
            {
                rcBll.Update(rc);
            }
        }

    }
}