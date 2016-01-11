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
    public partial class score_mgr : Web.UI.ManagePage
    {

        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        wx_ucard_score scoreBll = new wx_ucard_score();
        wx_ucard_udegree degreeBll = new wx_ucard_udegree();
        protected int sid = 0;//店铺主键id
        protected void Page_Load(object sender, EventArgs e)
        {
            sid = MyCommFun.RequestInt("id");
            if (sid == 0)
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }

            if (!Page.IsPostBack)
            {
                ShowInfo();
            }
        }
        #region 赋值操作=================================
        private void ShowInfo()
        {
          
            IList<Model.wx_ucard_score> syslist = scoreBll.GetModelList("sId=" + sid);
            if (syslist == null || syslist.Count <= 0)
            {
                return;
            }
            Model.wx_ucard_score score = syslist[0];
            hidid.Value = score.id.ToString();
            txtuserdContent.Value = score.userdContent;
            txtscoreRegular.Value = score.scoreRegular;
            txtqiandaoScore.Text =MyCommFun.ObjToStr(score.qiandaoScore.Value );
            txtqiandao6Score.Text = MyCommFun.ObjToStr(score.qiandao6Score.Value );
            txtconsumeMoney.Text = MyCommFun.ObjToStr(score.consumeMoney.Value );
            txtconsumeMoneyScore.Text = MyCommFun.ObjToStr(score.consumeMoneyScore.Value );


            //绑定等级
            BLL.wx_ucard_udegree dBll = new wx_ucard_udegree();
            IList<Model.wx_ucard_udegree> itemlist = dBll.GetModelList("sId="+sid+" order by degreeNum asc");
            if (itemlist != null && itemlist.Count > 0)
            {
                int count = itemlist.Count;
                TextBox txtLevelName;
                TextBox txtLevelMin;
                TextBox txtLevelMax;
                Model.wx_ucard_udegree itemEntity = new Model.wx_ucard_udegree();
                for (int i = 1; i <= count; i++)
                {
                    itemEntity = itemlist[(i - 1)];

                    txtLevelName = this.FindControl("txtLevel" + i + "Name") as TextBox;
                    txtLevelMin = this.FindControl("txtLevel" + i + "Min") as TextBox;
                    txtLevelMax = this.FindControl("txtLevel" + i + "Max") as TextBox;

                    txtLevelName.Text = itemEntity.callName;
                    txtLevelMin.Text = itemEntity.score_min.Value.ToString();
                    txtLevelMax.Text = itemEntity.score_max.Value.ToString();
                   
                }

            }

        }

        #endregion



        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
 
            int id = MyCommFun.Str2Int(hidid.Value);
 
            #region 赋值
            Model.wx_ucard_score score = new Model.wx_ucard_score();
            if (id > 0)
            {
                score = scoreBll.GetModel(id);
            }
            score.sId = sid;
            score.userdContent = txtuserdContent.Value.Trim();
            score.scoreRegular = txtscoreRegular.Value.Trim();
            score.qiandaoScore =MyCommFun.Str2Int(txtqiandaoScore.Text);
            score.qiandao6Score = MyCommFun.Str2Int(txtqiandao6Score.Text);
            score.consumeMoney = MyCommFun.Str2Int(txtconsumeMoney.Text);
            score.consumeMoneyScore = MyCommFun.Str2Int(txtconsumeMoneyScore.Text);

            #endregion
            SetDegree();
            if (id <= 0)
            {  //新增
                id = scoreBll.Add(score);
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "会员卡积分设置，主键为" + id); //记录日志
                JscriptMsg("会员卡积分设置成功！", "business_list.aspx", "Success");
            }
            else
            {   //修改
                //1修改主表
                scoreBll.Update(score);
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "会员卡积分设置，主键为" + id); //记录日志
                JscriptMsg("会员卡积分设置成功！", "business_list.aspx", "Success");
            }

        }

        protected void SetDegree()
        {
            BLL.wx_ucard_udegree dBll = new wx_ucard_udegree();
            Model.wx_ucard_udegree model= new Model.wx_ucard_udegree();
            dBll.DeleteStoreDegree(sid);
            TextBox txtLevelName;
            TextBox txtLevelMin;
            TextBox txtLevelMax;
            int dNum = 1;
            for (int i = 1; i <= 8; i++)
            {
                txtLevelName = this.FindControl("txtLevel" + i + "Name") as TextBox;
                txtLevelMin = this.FindControl("txtLevel" + i + "Min") as TextBox;
                txtLevelMax = this.FindControl("txtLevel" + i + "Max") as TextBox;
                if (isNullOrEmoty(txtLevelName) && txtNumRight(txtLevelMin) && txtNumRight(txtLevelMax))
                {
                    model.sId = sid;
                    model.degreeNum = dNum;
                    model.callName = txtLevelName.Text.Trim();
                    model.score_min = int.Parse(txtLevelMin.Text);
                    model.score_max = int.Parse(txtLevelMax.Text);
                    dBll.Add(model);
                    dNum++;
                }
            }
        }

        private bool isNullOrEmoty(TextBox txt)
        {
            if (txt.Text == null || txt.Text.Trim() == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool txtNumRight(TextBox txt)
        {
           
            if (txt.Text == null|| txt.Text.Trim() == "")
            {
                return false;
            }
            if (MyCommFun.Str2Int(txt.Text) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }

          
        }
    }
}