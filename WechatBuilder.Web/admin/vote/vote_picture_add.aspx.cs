using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.admin.vote
{
    public partial class vote_picture : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            DateTime begin = DateTime.Parse(begindate.Text.Trim());
            DateTime end = DateTime.Parse(enddate.Text.Trim());
            if (begin >= end)
            {
                JscriptMsg("开始时间必须小于结束时间", "back", "Error");
                return;
            }


            //base表
            Model.wx_userweixin weixin = GetWeiXinCode();
            int wid = weixin.id;

            BLL.wx_vote_base votebaseBll = new BLL.wx_vote_base();

            Model.wx_vote_base votebase = new Model.wx_vote_base();
            votebase.wid = wid;//
            votebase.title = this.title.Text.ToString();//投票说明
            votebase.votepic = this.votepic.Text.ToString();//投票图片
            votebase.picdisplay = Convert.ToBoolean(this.picdisplay.SelectedValue);//是否显示在投票页面
            votebase.votecontent = this.txtactContent.InnerText.ToString();//投票说明
            votebase.isRadio = Convert.ToBoolean(this.Radio.SelectedValue);
            if (this.begindate.Text.ToString() != "")
            {
                votebase.beginTime = Convert.ToDateTime(this.begindate.Text.ToString());
            }
            if (this.enddate.Text.ToString() != "")
            {
                votebase.endTime = Convert.ToDateTime(this.enddate.Text.ToString());
            }
            votebase.resultShowtype = Convert.ToInt32(this.resultShowtype.SelectedValue);
            votebase.actUrl = "";
            votebase.voteType = 2;//图片投票
            votebase.creatDate = DateTime.Now;
            votebase.actUrl = MyCommFun.getWebSite() + "/admin/vote/vote_list.aspx?wid=" + wid + "&aid=";
            int baseid = votebaseBll.Add(votebase);


            //item表
            BLL.wx_vote_item voteitemBll = new BLL.wx_vote_item();

            Model.wx_vote_item voteitem = new Model.wx_vote_item();


            int sid = 0;

            TextBox xuanxtitle;
            TextBox Sortid;
            TextBox picur;
            TextBox picjump;
            
            int totJxNum = 0;
            for (int i = 1; i <= 6; i++)
            {
                xuanxtitle = this.FindControl("xuanxtitle" + i) as TextBox;
                Sortid = this.FindControl("Sortid" + i) as TextBox;
                picur = this.FindControl("pic_ur" + i) as TextBox;
                picjump = this.FindControl("pic_jump" + i) as TextBox;

                if (xuanxtitle1.Text.Trim() != "" && Sortid1.Text.Trim() != "" && MyCommFun.isNumber(Sortid1.Text.Trim()))
                {
                    totJxNum++;
                }
            }

            decimal avgDeg = (decimal)360.0 / (totJxNum + 1);

            for (int i = 1; i <= 6; i++)
            {
                xuanxtitle = this.FindControl("xuanxtitle" + i) as TextBox;
                Sortid = this.FindControl("Sortid" + i) as TextBox;
                picur = this.FindControl("pic_ur" + i) as TextBox;
                picjump = this.FindControl("pic_jump" + i) as TextBox;

                if (xuanxtitle.Text.Trim() != "" && Sortid.Text.Trim() != "" && MyCommFun.isNumber(Sortid.Text.Trim()))
                {
                    sid++;
                    voteitem.sid = sid;
                    voteitem.baseid = baseid;
                    voteitem.title = xuanxtitle.Text.ToString();
                    voteitem.sort_id = MyCommFun.Str2Int(this.Sortid1.Text.ToString());
                    voteitem.pic_url = picur.Text.ToString();
                    voteitem.pic_jump = picjump.Text.ToString();
                    voteitem.createDate = DateTime.Now;
                    voteitemBll.Add(voteitem);
                }

            }


            AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "增加图片投票，id为" + baseid); //记录日志
          
            JscriptMsg("添加成功", "vote_list.aspx", "Success");
        }
    }
}