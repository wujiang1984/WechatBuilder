using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using WechatBuilder.BLL;


namespace WechatBuilder.Web.admin.settings
{
    public partial class wSiteSetting : Web.UI.ManagePage
    {
        WechatBuilder.BLL.wx_wsite_setting bll = new WechatBuilder.BLL.wx_wsite_setting();
        wx_requestRule rBll = new wx_requestRule();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                 ShowInfo();
            }
        }

        #region 赋值操作=================================
        private void ShowInfo()
        {
             Model.wx_userweixin weixin = GetWeiXinCode();
             lblWSiteUrl.Text = MyCommFun.getWebSite() + "/index.aspx?wid=" + weixin.id;

            IList<WechatBuilder.Model.wx_wsite_setting> modellist = bll.GetModelList("wId="+weixin.id);
            if (modellist == null || modellist.Count <= 0)
            {
                return;
            }
            WechatBuilder.Model.wx_wsite_setting model = modellist[0];
            this.lblsiteId.Text = model.id.ToString();
            this.txtwName.Text = model.wName;
            this.txtcompanyName.Text = model.companyName;
            this.txtbgMusic.Text = model.bgMusic;
            this.txtbgPic.Text = model.bgPic;
            this.txtbgDongHuaId.Text = model.bgDongHuaId.ToString();
            this.txtwCopyright.Text = model.wCopyright;
            this.txtwBrief.Text = model.wBrief;
          
            this.txtphone.Text = model.phone;
            this.txtaddr.Text = model.addr;
            this.txtaddrUrl.Text = model.addrUrl;
          
            this.txtseo_title.Text = model.seo_title;
            this.txtseo_keywords.Text = model.seo_keywords;
            this.txtseo_desc.Text = model.seo_desc;

            //微信回复信息
            DataSet ds = rBll.GetRuleContent(1, " modelFunctionName='微网站' and wId=" + weixin.id);
            if (ds == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0)
            {
                return;
            }
            DataRow dr=ds.Tables[0].Rows[0];
            lblrId.Text = MyCommFun.ObjToStr(dr["id"],"0");
            lblrcId.Text =MyCommFun.ObjToStr(dr["cid"],"0");
            txtreqKeywords.Text =MyCommFun.ObjToStr(dr["reqKeywords"]);
            if (MyCommFun.ObjToStr(dr["isLikeSearch"]) != "")
            {
                if (dr["isLikeSearch"].ToString().ToLower() == "false")
                {
                    this.rblisLikeSearch.SelectedValue = "0";
                }
                else
                {
                    this.rblisLikeSearch.SelectedValue = "1";
                }
            }
            txtTitle.Value = MyCommFun.ObjToStr(dr["rContent"]);
            txtImgUrl.Text =MyCommFun.ObjToStr(dr["picUrl"]);
            txtContent.InnerText =MyCommFun.ObjToStr(dr["rContent2"]);
            //lblWSiteUrl.Text = MyCommFun.ObjToStr(dr[""], lblWSiteUrl.Text);

        }
        #endregion

        

        /// <summary>
        /// 保存配置信息
        /// </summary>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            WechatBuilder.Model.wx_wsite_setting model = new WechatBuilder.Model.wx_wsite_setting();
            
            try
            {
                Model.wx_userweixin weixin = GetWeiXinCode();
                int wId = weixin.id;
                string wName = this.txtwName.Text;
                string companyName = this.txtcompanyName.Text;
                string bgMusic = this.txtbgMusic.Text;
                string bgPic = this.txtbgPic.Text;
                int bgDongHuaId = int.Parse(this.txtbgDongHuaId.Text);
                string wCopyright = this.txtwCopyright.Text;
                string wBrief = this.txtwBrief.Text;
             
                string phone = this.txtphone.Text;
                string addr = this.txtaddr.Text;
                string addrUrl = this.txtaddrUrl.Text;
       
                string seo_title = this.txtseo_title.Text;
                string seo_keywords = this.txtseo_keywords.Text;
                string seo_desc = this.txtseo_desc.Text;
                DateTime createDate = DateTime.Now;
                int id = int.Parse(lblsiteId.Text.Trim());
                if (id != 0)
                {
                    //修改
                    model = bll.GetModel(id);
                }
                else {
                    //添加
                    model.wId = wId;
                    model.createDate = createDate;
                }
              
                model.wName = wName;
                model.companyName = companyName;
                model.bgMusic = bgMusic;
                model.bgPic = bgPic;
                model.bgDongHuaId = bgDongHuaId;
                model.wCopyright = wCopyright;
                model.wBrief = wBrief;
                model.remark = "";
                model.phone = phone;
                model.addr = addr;
                model.addrUrl = addrUrl;
                model.email = "";
                model.seo_title = seo_title;
                model.seo_keywords = seo_keywords;
                model.seo_desc = seo_desc;

                if (id != 0)
                {
                    bll.Update(model);
                }
                else
                {
                   id= bll.Add(model);
                }
                //编辑关键词回复
                EditWXResponseKW(id, wId);
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改微网站设置"); //记录日志
                JscriptMsg("微网站设置成功！", "wSiteSetting.aspx", "Success");
            }
            catch
            {
                JscriptMsg("微网站设置失败！", "", "Error");
            }
        }

        /// <summary>
        /// 设置微信回复的关键词
        /// </summary>
        /// <param name="siteId">该微帐号</param>
        /// <param name="wid"></param>
        private void EditWXResponseKW(int siteId,int wid)
        {
            string strErr = "";
            string moduleName = "微网站";
            if (this.txtreqKeywords.Text.Trim().Length == 0)
            {
                strErr += "关键词不能为空！";
            }
            if (strErr != "")
            {
                //JscriptMsg(strErr, "back", "Error");
                return;
            }

            Model.manager manager = GetAdminInfo();
            int rId =MyCommFun.Str2Int(lblrId.Text.Trim());

            #region  //关键词设置
          
            Model.wx_requestRule rule = new Model.wx_requestRule();
            if (rId == 0)
            {
                rule.uId = manager.id;
                rule.wId = wid;
                rule.ruleName = "图文回复";
                rule.isDefault = false;
                rule.reqestType = 1;//关键词回复
                rule.createDate = DateTime.Now;
                rule.modelFunctionName = moduleName;
               // rule.modelFunctionId = siteId;
                rule.responseType = 2;//回复的类型:文本1，图文2，语音3，视频4,第三方接口5
            }
            else
            {
                rule = rBll.GetModel(rId);
            }

            string radoValue = rblisLikeSearch.SelectedItem.Value;
            if (radoValue == "0")
            {
                rule.isLikeSearch = false;
            }
            else
            {
                rule.isLikeSearch = true;
            }
            rule.reqKeywords = txtreqKeywords.Text.Trim();

            if (rId == 0)
            {
              rId= rBll.Add(rule);
            }
            else
            {
                rBll.Update(rule);
            }
            #endregion

            #region  关键词对应的内容设置
            Model.wx_requestRuleContent rc = new Model.wx_requestRuleContent();
            wx_requestRuleContent rcBll = new wx_requestRuleContent();
            int rcId = MyCommFun.Str2Int(lblrcId.Text.Trim());
            if (rcId != 0)
            {
                rc = rcBll.GetModel(rcId);
            }
            if (rcId == 0)
            {
                rc.rId = rId;
                rc.uId = manager.id;
                rc.createDate = DateTime.Now;
            }
            rc.rContent = txtTitle.Value.Trim();
            rc.picUrl = txtImgUrl.Text;
            rc.rContent2 = txtContent.Value.Trim();
            rc.detailUrl = MyCommFun.getWebSite() + "/index.aspx?wid="+wid;
            rc.seq = 0;
            if (rcId == 0)
            {
                int ret = rcBll.Add(rc);
                if (ret > 0)
                {
                   // JscriptMsg("修改图文回复内容信息【微网站】成功！", "wSiteSetting.aspx", "Success");
                }
                else
                {
                  //  JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
            }
            else
            {
                bool ret = rcBll.Update(rc);
                if (ret)
                {
                    // JscriptMsg("添加图文回复内容信息【微网站】成功！", "wSiteSetting.aspx?rid=", "Success");
                }
                else
                {
                   // JscriptMsg("保存过程中发生错误！", "", "Error");
                    //return;
                }
            }

            #endregion


        }

        #region 获取短信数量=================================
        private string GetSmsCount()
        {
            string code = string.Empty;
            int count = new BLL.sms_message().GetAccountQuantity(out code);
            if (code == "115")
            {
                return "查询出错：请完善账户信息";
            }
            else if (code != "100")
            {
                return "错误代码：" + code;
            }
            return count + " 条";
        }
        #endregion

    }
}