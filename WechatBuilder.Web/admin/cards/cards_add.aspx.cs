using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.admin.cards
{
    public partial class cards_add : Web.UI.ManagePage
    {
        protected  string type = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                type = MyCommFun.QueryString("type");

                int id = MyCommFun.RequestInt("id");
                BLL.wx_cards wx_cardsBll = new BLL.wx_cards();
                Model.wx_cards cards = new Model.wx_cards();
                cards = wx_cardsBll.GetModel(id);

                if (type == "delete")
                {

                    wx_cardsBll.Delete(id);
                    AddAdminLog(MXEnums.ActionEnum.Delete.ToString(), "删除贺卡，主键为" + id); //记录日志
                    JscriptMsg("删除成功", "cards_list.aspx", "Success");
                    return;
                }
                
     
                if (cards!=null)
                 {
                     this.title.Text = cards.title;
                     this.imgPic.ImageUrl = cards.backPic;
                     this.backPic.Text = cards.backPic;
                     this.backMusic.Text = cards.backMusic;
                     this.backCartoon.Value = cards.backCartoon;
                     this.characters.InnerText = cards.characters;
                     this.copyRight.InnerText = cards.copyRight;
                     this.buttonCharacter.Text = cards.buttonCharacter;
                     this.display.SelectedValue = cards.display.ToString();
                     this.name.Text = cards.name;
                     this.url.Text = cards.url;
                 }


     
               
            }
        }

        protected void Savecards_Click(object sender, EventArgs e)
        {
            type = MyCommFun.QueryString("type");
            Model.wx_userweixin weixin = GetWeiXinCode();
            int wid = weixin.id;
            BLL.wx_cards wx_cardsBll = new BLL.wx_cards();
            Model.wx_cards cards = new Model.wx_cards();
            int id = MyCommFun.RequestInt("id");
            if (type == "add")
            {
                
                cards.wid = wid;
                cards.title = this.title.Text.ToString();
                cards.backPic = this.backPic.Text.ToString();
                this.imgPic.ImageUrl = this.backPic.Text.ToString();
                cards.backMusic = this.backMusic.Text.ToString();
                cards.backCartoon = this.backCartoon.Value.ToString();
                cards.characters = this.characters.InnerText.ToString();
                cards.copyRight = this.copyRight.InnerText.ToString();
                cards.buttonCharacter = this.buttonCharacter.Text.ToString();
                cards.display = Convert.ToBoolean( this.display.SelectedValue);
                cards.name = this.name.Text.ToString();
                cards.url = this.url.Text.ToString();
                cards.createDate = DateTime.Now;

                int iid = wx_cardsBll.Add(cards);

                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加贺卡基本设置，主键为" + iid); //记录日志
                JscriptMsg("添加成功", "cards_list.aspx", "Success");
            }
            if (type == "edite")
            {
                cards.id = id;
                cards.wid = wid;
                cards.title = this.title.Text.ToString();
                cards.backPic = this.backPic.Text.ToString();
                cards.backMusic = this.backMusic.Text.ToString();
                cards.backCartoon = this.backCartoon.Value.ToString();
                cards.characters = this.characters.InnerText.ToString();
                cards.copyRight = this.copyRight.InnerText.ToString();
                cards.buttonCharacter = this.buttonCharacter.Text.ToString();
                cards.display = Convert.ToBoolean(this.display.SelectedValue);
                cards.name = this.name.Text.ToString();
                cards.url = this.url.Text.ToString();
           
                 wx_cardsBll.Update(cards);

                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改贺卡基本设置，主键为" + id); //记录日志
                JscriptMsg("修改成功", "cards_list.aspx", "Success");


            }
     


        }
    }
}