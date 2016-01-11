using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using WechatBuilder.BLL;

namespace WechatBuilder.Web.admin.hunqing
{
    public partial class editXitie : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        wx_xt_base sstBll = new wx_xt_base();

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
                    txtstatedate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
        }



        #region 赋值操作=================================
        private void ShowInfo(int id)
        {
              Model.wx_userweixin weixin = GetWeiXinCode();
              litwUrl.Text = MyCommFun.getWebSite() + "/weixin/xitie/index.aspx?wid=" + weixin.id + "&xid=" + id;
            hidid.Value = id.ToString();
            Model.wx_xt_base xitie = sstBll.GetModel(id);

            Model.wx_requestRule rule = rBll.GetModelList("modelFunctionName='喜帖' and modelFunctionId=" + id)[0];
            txtKW.Text = rule.reqKeywords;

            //图片
            txtImgUrl.Text = xitie.fengmian;
            imgbeginPic.ImageUrl = xitie.fengmian;

            txtKcdh.Text = xitie.donghua;
            imgKcdh.ImageUrl = xitie.donghua;

            txtdonghuaSlt.Text = xitie.donghuaSlt;
            imgdonghuaSlt.ImageUrl = xitie.donghuaSlt;


            txtwxTitle.Text = xitie.wxTitle;
            txtmanName.Text = xitie.manName;
            txtfelmanName.Text = xitie.felmanName;
            radNameSeq.SelectedValue = xitie.nameSeq.Value.ToString();
            txttel.Text = xitie.tel;
            txtstatedate.Text = xitie.statedate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            txtaddr.Text = xitie.addr;
            txtvideo.Text = xitie.video;
            txtMusic.Text = xitie.music;
            txtword.Value = xitie.word;
            txtsqrurl.Text = xitie.sqrurl;
            txtcopyrite.Value = xitie.copyrite;
            txtPwd.Text = xitie.pwd;

            txtLatXPoint.Text = xitie.lngX.Value.ToString();
            txtLngYPoint.Text = xitie.latY.Value.ToString();
            ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'> $(\"#baiduframe\").attr(\"src\", \"../lbs/MapSelectPoint.aspx?yjindu=" + xitie.latY.Value.ToString() + "&xweidu=" + xitie.lngX.Value.ToString() + "\");</script>");


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
            if (this.txtwxTitle.Text.Trim().Length == 0)
            {
                strErr += "喜帖名称不能为空！";
            }
            if (txtmanName.Text.Trim().Length == 0 || txtmanName.Text.Trim().Length == 0)
            {
                strErr += "新郎和新娘名称不能为空！";
            }
            if (this.txtstatedate.Text.Trim().Length == 0 || !MyCommFun.isDateTime(txtstatedate.Text))
            {
                strErr += "婚宴时间不能为空！";
            }
            if (this.txtaddr.Text.Trim().Length == 0)
            {
                strErr += "宴席地点不能为空！";
            }
            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }
            #endregion

            #region 赋值
            Model.wx_xt_base xitie = new Model.wx_xt_base();
            Model.wx_requestRule rule = new Model.wx_requestRule();

            string beginPic = txtImgUrl.Text.Trim();
            string kcdh = txtKcdh.Text.Trim();
           
            string kcdh_slt =  txtdonghuaSlt.Text.Trim();
            

            if (id > 0)
            {
                xitie = sstBll.GetModel(id);
            }

            xitie.wxTitle = txtwxTitle.Text.Trim();
            xitie.manName = txtmanName.Text.Trim();
            xitie.felmanName = txtfelmanName.Text.Trim();
            xitie.nameSeq = int.Parse(radNameSeq.SelectedItem.Value);
            xitie.tel = txttel.Text;
            xitie.statedate = MyCommFun.Obj2DateTime(txtstatedate.Text);
            xitie.addr = txtaddr.Text.Trim();

            xitie.video = txtvideo.Text.Trim();
            xitie.music = txtMusic.Text.Trim();
            xitie.word = txtword.Value.Trim();
            xitie.sqrurl = txtsqrurl.Text.Trim();
            xitie.copyrite = txtcopyrite.Value.Trim();
            xitie.pwd = txtPwd.Text.Trim();
            //图片
            xitie.fengmian = beginPic;
            xitie.donghua = kcdh;
            xitie.donghuaSlt = kcdh_slt;

            //坐标
            decimal xPoint = (decimal)MyCommFun.Str2Float(this.txtLatXPoint.Text);
            decimal yPoint = (decimal)MyCommFun.Str2Float(this.txtLngYPoint.Text);
            xitie.lngX = xPoint;
            xitie.latY = yPoint;

            #endregion

            if (id <= 0)
            {  //新增
                xitie.wid = weixin.id;
                xitie.createDate = DateTime.Now;
                //1新增主表
                id = sstBll.Add(xitie);


                //2 新增回复规则表
                rBll.AddModeltxtPicRule(weixin.id, "喜帖", id, txtKW.Text.Trim());
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加喜帖，主键为" + id); //记录日志
                JscriptMsg("添加帖成功！", "xitielist.aspx", "Success");
            }
            else
            {   //修改
                //1修改主表
                sstBll.Update(xitie);

                //2 修改回复规则表
                IList<Model.wx_requestRule> rlist = rBll.GetModelList("modelFunctionName = '喜帖' and modelFunctionId=" + id);

                if (rlist != null && rlist.Count > 0)
                {
                    rule = rlist[0];
                    rule.reqKeywords = txtKW.Text.Trim();
                    rBll.Update(rule);
                }
                else
                {
                    rBll.AddModeltxtPicRule(weixin.id, "喜帖", id, txtKW.Text.Trim());
                }

                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改喜帖，主键为" + id); //记录日志
                JscriptMsg("修改喜帖成功！", "xitielist.aspx", "Success");
            }

        }
    }
}