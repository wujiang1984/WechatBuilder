using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using WechatBuilder.BLL;
namespace WechatBuilder.Web.admin.youhuiquan
{
    public partial class simple_editTicket : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        wx_sTicket sstBll = new wx_sTicket();
        wx_sttAwardItem iBll = new wx_sttAwardItem();
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
                if (!sstBll.Exists(id))
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
                else
                {
                    txtbeginDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    txtendDate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
        }



        #region 赋值操作=================================
        private void ShowInfo(int id)
        {
            hidid.Value = id.ToString();
            Model.wx_sTicket sstAction = sstBll.GetModel(id);
            IList<Model.wx_sttAwardItem> aItemlist = iBll.GetModelList("actId=" + id);
            Model.wx_requestRule rule = rBll.GetModelList("modelFunctionName='优惠券简单版' and modelFunctionId=" + id)[0];
            txtKW.Text = rule.reqKeywords;

            if (sstAction.beginPic != null && sstAction.beginPic.Trim() != "/weixin/sticket/images/start.jpg")
            {
                txtImgUrl.Text = sstAction.beginPic;
                imgbeginPic.ImageUrl = sstAction.beginPic;
            }
            //banner
            if (sstAction.bannerPic != null && sstAction.bannerPic.Trim() != "/weixin/sticket/images/banner.jpg")
            {
                txtBanner.Text = sstAction.bannerPic;
                imgBanner.ImageUrl = sstAction.bannerPic;
            }


            txtactName.Text = sstAction.actionName;
            txtsuccTip.Text = sstAction.succTip;
            txtbrief.Value = sstAction.brief;
            txtbeginDate.Text = sstAction.beginDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            txtendDate.Text = sstAction.endDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            txtactContent.Value = sstAction.aContent;
            txtusedRemark.Value = sstAction.usedRemark;
            this.txtdjPwd.Text = sstAction.pwd;
            //结束
            if (sstAction.endPic != null && sstAction.endPic.Trim() != "/weixin/sticket/images/end.jpg")
            {
                txtEndPic.Text = sstAction.endPic;
                imgEndPic.ImageUrl = sstAction.endPic;
            }
            txtendNotice.Text = sstAction.endNotice;
            txtendContent.Text = sstAction.endContent;

            //绑定奖项信息
            IList<Model.wx_sttAwardItem> itemlist = iBll.GetModelList("actId=" + id + " order by sort_id asc");
            if (itemlist != null && itemlist.Count > 0)
            {
                int count = itemlist.Count;
               
                TextBox txtJPName;
               
                TextBox txtRealNum;
                Model.wx_sttAwardItem itemEntity = new Model.wx_sttAwardItem();
                for (int i = 1; i <= count; i++)
                {
                    itemEntity = itemlist[(i - 1)];
                    txtJPName = this.FindControl("txt" + i + "JPName") as TextBox;
                    txtRealNum = this.FindControl("txt" + i + "RealNum") as TextBox;
                    txtJPName.Text = itemEntity.jpName;
                    txtRealNum.Text = itemEntity.jpRealNum == null ? "0" : itemEntity.jpRealNum.Value.ToString();
                }

            }

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
            if (this.txtactName.Text.Trim().Length == 0)
            {
                strErr += "活动名称不能为空！";
            }
            if (this.txtbeginDate.Text.Trim().Length == 0 || !MyCommFun.isDateTime(txtbeginDate.Text))
            {
                strErr += "开始时间不能为空！";
            }
            if (this.txtendDate.Text.Trim().Length == 0 || !MyCommFun.isDateTime(txtendDate.Text))
            {
                strErr += "结束时间不能为空！";
            }
            if (txt1JPName.Text.Trim().Length == 0 || txt1RealNum.Text.Trim().Length == 0)
            {
                strErr += "第一个优惠券不能为空！";
            }
            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }
            DateTime begin = DateTime.Parse(txtbeginDate.Text.Trim());
            DateTime end = DateTime.Parse(txtendDate.Text.Trim());
            if (begin >= end)
            {
                JscriptMsg("开始时间必须小于结束时间", "back", "Error");
                return;
            }
            #endregion

            #region 赋值
            Model.wx_sTicket sst = new Model.wx_sTicket();
            Model.wx_requestRule rule = new Model.wx_requestRule();

            string beginPic = imgbeginPic.ImageUrl;
            if (txtImgUrl.Text.Trim() != "")
            {
                beginPic = txtImgUrl.Text.Trim();
            }
             string bannerPic = imgBanner.ImageUrl;
            if (txtBanner.Text.Trim() != "")
            {
                bannerPic = txtBanner.Text.Trim();
            }


            string endPic = imgEndPic.ImageUrl;
            if (txtEndPic.Text.Trim() != "")
            {
                endPic = txtEndPic.Text.Trim();
            }

            if (id > 0)
            {
                sst = sstBll.GetModel(id);
            }

            sst.actionName = txtactName.Text.Trim();
            sst.succTip = txtsuccTip.Text.Trim();
            sst.brief = txtbrief.Value.Trim();
            sst.beginDate = begin;
            sst.endDate = end;
            sst.aContent = txtactContent.Value.Trim();
            sst.usedRemark = txtusedRemark.Value;
            sst.endNotice = txtendNotice.Text.Trim();
            sst.endContent = txtendContent.Text.Trim();
            sst.pwd = txtdjPwd.Text.Trim();

            sst.beginPic = beginPic;
            sst.endPic = endPic;
            sst.bannerPic = bannerPic;

            #endregion

            if (id <= 0)
            {  //新增
                sst.wid = weixin.id;
                sst.createDate = DateTime.Now;
                //1新增主表
                id = sstBll.Add(sst);

                //2新增奖项表
                EditAwardItem(id);
                //3 新增回复规则表
                rBll.AddModeltxtPicRule(weixin.id, "优惠券简单版", id, txtKW.Text.Trim());
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加优惠券活动，主键为" + id); //记录日志
                JscriptMsg("添加优惠券活动成功！", "simpleTList.aspx", "Success");
            }
            else
            {   //修改
                //1修改主表
                sstBll.Update(sst);
                //2删除，且新增奖项表
                EditAwardItem(id);
                //3 修改回复规则表
                IList<Model.wx_requestRule> rlist = rBll.GetModelList("modelFunctionName = '优惠券简单版' and modelFunctionId=" + id);

                if (rlist != null && rlist.Count > 0)
                {
                    rule = rlist[0];
                    rule.reqKeywords = txtKW.Text.Trim();
                    rBll.Update(rule);
                }
                else
                {
                    rBll.AddModeltxtPicRule(weixin.id, "优惠券简单版", id, txtKW.Text.Trim());
                }

                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改优惠券活动，主键为" + id); //记录日志
                JscriptMsg("修改优惠券活动成功！", "simpleTList.aspx", "Success");
            }

        }

       
        /// <summary>
        /// 添加奖品项目
        /// </summary>
        private void EditAwardItem(int sstId)
        {
            //1删除原来的，2新增
            iBll.DeleteByActId(sstId);
            Model.wx_sttAwardItem item = new Model.wx_sttAwardItem();
            
            TextBox txtJPName;
            TextBox txtRealNum;
            int sort_id = 0;

            for (int i = 1; i <= 6; i++)
            {
              
                txtJPName = this.FindControl("txt" + i + "JPName") as TextBox;
              
                txtRealNum = this.FindControl("txt" + i + "RealNum") as TextBox;

                if ( txtJPName.Text.Trim() != ""   && txtRealNum.Text.Trim() != "" &&  MyCommFun.isNumber(txtRealNum.Text))
                {
                    sort_id++;
                    //那么添加奖品信息 
                  
                    item.sort_id = sort_id;
                    item.jpName = txtJPName.Text.Trim();
                  
                    item.jpRealNum = MyCommFun.Str2Int(txtRealNum.Text.Trim());
                    item.actId = sstId;
                    item.createDate = DateTime.Now;
                  
                    iBll.Add(item);
                }

            }

        }

        
    }
}