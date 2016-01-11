using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.weixin.cards
{
    public partial class index : WeiXinPage
    {
        protected string characters = "";
        protected string name = "";
        protected string createDate = "";
        protected string copyRight = "";
        protected int zfCount = 0;
        protected int id = 0;
        protected string url = "";
        protected string title = "";
        protected int dhId = 0;
        protected string myact = "";
        protected string imageback = "";
        protected string openid = "";
        protected int wid = 0;
        protected string music = "";
        protected string buttonCharacter = "";
 
        protected void Page_Load(object sender, EventArgs e)
        {
            if(! IsPostBack)
            {
                BLL.wx_cards gbll = new BLL.wx_cards();
                Model.wx_cards cards = new Model.wx_cards();

                BLL.wx_cards_gl countgbll = new BLL.wx_cards_gl();
                Model.wx_cards_gl cardscountg = new Model.wx_cards_gl();

                id = MyCommFun.RequestInt("aid");
                openid = MyCommFun.RequestOpenid();
                wid = MyCommFun.RequestInt("wid");
                this.hkid.Value = id.ToString();
                cards = gbll.GetModel(id);

                characters = cards.characters;
                //name = cards.name;
                createDate = cards.createDate.ToString();
                copyRight = cards.copyRight;
                zfCount = Convert.ToInt32(cards.zfCount);
                url = cards.backPic;
                title = cards.title;
                this.backimage.Value = cards.backPic;
                buttonCharacter = cards.buttonCharacter;

                imageback =   cards.backPic;
                music = cards.backMusic;

                if (MyCommFun.RequestInt("dh") != 0)
                {
                    dhId = MyCommFun.RequestInt("dh");
                }
                else
                {
                    dhId = MyCommFun.Obj2Int(cards.backCartoon);
                }

                if (MyCommFun.QueryString("name") != "")
                {
                    name = MyCommFun.QueryString("name");
                }
                else
                {
                    name = cards.name;
                }

                if (MyCommFun.QueryString("characters") != "")
                {
                    characters = MyCommFun.QueryString("characters");
                }
                else
                {
                    characters = cards.characters;
                }

                
              //查看次数
              gbll.updateck(id);
                
            }
        }
    }
}