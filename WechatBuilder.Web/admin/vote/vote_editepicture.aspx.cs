using WechatBuilder.BLL;
using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.admin.vote
{
    public partial class vote_editepicture : Web.UI.ManagePage
    {
        wx_vote_item iBll = new wx_vote_item();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32( Request.Params["id"]);
                BLL.wx_vote_base basebll = new BLL.wx_vote_base();
                DataSet dr = basebll.GetListByid(id);
                if (dr.Tables[0].Rows.Count > 0)
                {
                    this.title.Text = dr.Tables[0].Rows[0]["title"].ToString();
                    this.votepic.Text = dr.Tables[0].Rows[0]["votepic"].ToString();
                    this.picdisplay.SelectedValue = dr.Tables[0].Rows[0]["picdisplay"].ToString();
                    this.txtactContent.InnerText = dr.Tables[0].Rows[0]["votecontent"].ToString();

                    this.Radio.SelectedValue = dr.Tables[0].Rows[0]["isRadio"].ToString();
                    this.begindate.Text = dr.Tables[0].Rows[0]["beginTime"].ToString();
                    this.enddate.Text = dr.Tables[0].Rows[0]["endTime"].ToString();
                    this.resultShowtype.SelectedValue = dr.Tables[0].Rows[0]["resultShowtype"].ToString();
                    this.actUrl.Text = dr.Tables[0].Rows[0]["actUrl"].ToString();
                }


                BLL.wx_vote_item itembll = new BLL.wx_vote_item();
                DataSet dritem = itembll.GetListByid(id);

                IList<Model.wx_vote_item> itemlist = iBll.GetModelList("baseid=" + id + " order by sid asc");
                if (itemlist != null && itemlist.Count > 0)
                {
                    int count = itemlist.Count;
                    TextBox xuanxtitle;
                    TextBox Sortid;
                    TextBox pic_ur;
                    TextBox pic_jump;
                    HiddenField toupiaoTimes;
                    Model.wx_vote_item itemEntity = new Model.wx_vote_item();
                    for (int i = 1; i <= count; i++)
                    {
                        itemEntity = itemlist[(i - 1)];
                        xuanxtitle = this.FindControl("xuanxtitle" + i) as TextBox;
                        Sortid = this.FindControl("Sortid" + i) as TextBox;
                        pic_ur = this.FindControl("pic_ur" + i) as TextBox;
                        pic_jump = this.FindControl("pic_jump" + i) as TextBox;
                        toupiaoTimes = this.FindControl("toupiaoTimes" + i) as HiddenField;

                        xuanxtitle.Text = itemEntity.title.ToString();
                        Sortid.Text = itemEntity.sort_id.ToString();
                        pic_ur.Text = itemEntity.pic_url.ToString();
                        pic_jump.Text = itemEntity.pic_jump.ToString();
                        toupiaoTimes.Value = itemEntity.tpTimes == null ? "0" : itemEntity.tpTimes.Value.ToString();

                    }

                }

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


            int id = Convert.ToInt32(Request.Params["id"]);
            BLL.wx_vote_base basebll = new BLL.wx_vote_base();
            Model.wx_vote_base votebase = new Model.wx_vote_base();
            votebase.id = id;
            votebase.title = this.title.Text.ToString();
            votebase.votepic = this.votepic.Text.ToString();
            votebase.picdisplay = Convert.ToBoolean(this.picdisplay.SelectedValue);
            votebase.votecontent = this.txtactContent.InnerText;
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
            votebase.voteType = 2;

            basebll.Update(votebase);


           

            BLL.wx_vote_item voteitemBll = new BLL.wx_vote_item();

            Model.wx_vote_item voteitem = new Model.wx_vote_item();

            voteitemBll.Delete(id);//删除
            int sid = 0;

            TextBox xuanxtitle;
            TextBox Sortid;
            TextBox picur;
            TextBox picjump;
            HiddenField toupiaoTimes;

            for (int i = 1; i <= 6; i++)
            {
                xuanxtitle = this.FindControl("xuanxtitle" + i) as TextBox;
                Sortid = this.FindControl("Sortid" + i) as TextBox;
                picur = this.FindControl("pic_ur" + i) as TextBox;
                picjump = this.FindControl("pic_jump" + i) as TextBox;
                toupiaoTimes = this.FindControl("toupiaoTimes" + i) as HiddenField;

                if (xuanxtitle.Text.Trim() != "" && Sortid.Text.Trim() != "" && MyCommFun.isNumber(Sortid.Text.Trim()))
                {
                    sid++;
                    voteitem.sid = sid;
                    voteitem.baseid = id;
                    voteitem.title = xuanxtitle.Text.ToString();
                    voteitem.sort_id = MyCommFun.Str2Int(this.Sortid1.Text.ToString());
                    voteitem.pic_url = picur.Text.ToString();
                    voteitem.pic_jump = picjump.Text.ToString();
                    voteitem.createDate = DateTime.Now;
                    voteitem.tpTimes = MyCommFun.Str2Int(toupiaoTimes.Value);
                    voteitemBll.Add(voteitem);
                }

            }

            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改图片投票，id为" + id); //记录日志
            JscriptMsg("修改成功！", Utils.CombUrlTxt("vote_list.aspx", "keywords={0}", ""), "Success");


        }
    }
}