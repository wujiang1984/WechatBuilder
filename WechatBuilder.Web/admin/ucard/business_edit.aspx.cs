using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using WechatBuilder.BLL;

namespace WechatBuilder.Web.admin.ucard
{
    public partial class business_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        wx_ucard_store storeBll = new wx_ucard_store();
        wx_requestRule rBll = new wx_requestRule();

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            int id = 0;
            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {

                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out  id))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!storeBll.Exists(id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {

                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(id);
                }
                
            }
        }



        #region 赋值操作=================================
        private void ShowInfo(int id)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            litUrl.Text = MyCommFun.getWebSite() + "/weixin/ucard/index.aspx?wid="+weixin.id+"&id="+id;

            hidid.Value = id.ToString();
            Model.wx_ucard_store store = storeBll.GetModel(id);
          
            Model.wx_requestRule rule = rBll.GetModelList("modelFunctionName='会员卡' and modelFunctionId=" + id)[0];
            txtKW.Text = rule.reqKeywords;

            if (store.hfPic != null && store.hfPic.Trim() != "/weixin/ucard/images/ucard_cover.jpg")
            {
                txtImgUrl.Text = store.hfPic;
                imgbeginPic.ImageUrl = store.hfPic;
            }
            txtstoreName.Text = store.storeName;
            if (store.logo != "")
            {
                txtLogo.Text = store.logo;
            }

            txtcardBrief.Value = store.cardBrief;
            ddlstoreCatagory.SelectedValue = store.storeCatagory;
            txttel.Text = store.tel;
            txtaddr.Text = store.addr;
            txtconsumePwd.Text = store.consumePwd;
            txtLatXPoint.Text = store.xPoint == null ? "" : store.xPoint.ToString();
            txtLngYPoint.Text = store.yPoint == null ? "" : store.yPoint.ToString();
            ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'> $(\"#baiduframe\").attr(\"src\", \"../lbs/MapSelectPoint.aspx?yjindu=" + store.yPoint.Value.ToString() + "&xweidu=" + store.xPoint.Value.ToString() + "\");</script>");
        }

        #endregion



        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();

            Model.wx_requestRuleContent rc = new Model.wx_requestRuleContent();
            int id = MyCommFun.Str2Int(hidid.Value);
            #region  //先判断
            string strErr = "";
            if (this.txtKW.Text.Trim().Length == 0)
            {
                strErr += "关键词不能为空！";
            }
            if (this.txtstoreName.Text.Trim().Length == 0)
            {
                strErr += "商家名称不能为空！";
            }
            
            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }
           
            #endregion

            #region 赋值
            Model.wx_ucard_store store = new Model.wx_ucard_store();
            Model.wx_requestRule rule = new Model.wx_requestRule();

            string hfPic = imgbeginPic.ImageUrl;
            if (txtImgUrl.Text.Trim() != "")
            {
                hfPic = txtImgUrl.Text.Trim();
            }
            

            if (id > 0)
            {
                store = storeBll.GetModel(id);
            }

            store.storeName = txtstoreName.Text.Trim();
            store.logo = txtLogo.Text.Trim();
            store.cardBrief = txtcardBrief.Value.Trim();
            store.storeCatagory = ddlstoreCatagory.SelectedItem.Value;
            store.tel = txttel.Text.Trim();
            store.addr = txtaddr.Text.Trim();
            store.consumePwd = txtconsumePwd.Text.Trim();
            store.hfPic = hfPic;
            store.xPoint = decimal.Parse( txtLatXPoint.Text.Trim());
            store.yPoint = decimal.Parse( txtLngYPoint.Text.Trim());


            #endregion

            if (id <= 0)
            {  //新增
                store.wid = weixin.id;
                store.createDate = DateTime.Now;
                //1新增主表
                id = storeBll.Add(store);

                //2 新增回复规则表
                AddRule(weixin.id, id);
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加会员卡商家，主键为" + id); //记录日志
                JscriptMsg("添加会员卡商家成功！", "business_list.aspx", "Success");
            }
            else
            {   //修改
                //1修改主表
                storeBll.Update(store);
               
                //3 修改回复规则表
                IList<Model.wx_requestRule> rlist = rBll.GetModelList("modelFunctionName = '会员卡' and modelFunctionId=" + id);

                if (rlist != null && rlist.Count > 0)
                {
                    rule = rlist[0];
                    rule.reqKeywords = txtKW.Text.Trim();
                    rBll.Update(rule);
                }
                else
                {
                    AddRule(weixin.id, id);
                }

                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改会员卡商家，主键为" + id); //记录日志
                JscriptMsg("修改会员卡商家成功！", "business_list.aspx", "Success");
            }

        }

        /// <summary>
        /// 添加回复规则
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="modelId"></param>
        private void AddRule(int wid, int modelId)
        {
            rBll.AddModeltxtPicRule(wid, "会员卡", modelId, txtKW.Text.Trim());
        }


        
    }
}