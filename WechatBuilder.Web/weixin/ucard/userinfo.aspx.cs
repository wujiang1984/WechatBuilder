using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using System.Text;


namespace WechatBuilder.Web.weixin.ucard
{
    public partial class userinfo : WeiXinPage
    {
        protected string openid = "";
        protected int wid = 0;
        protected int sid = 0;//店铺的主键id
        protected int degreeNum = 0;
        protected int uid = 0;
        protected string uName = "";
        protected string tel = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            OnlyWeiXinLook();
            openid = MyCommFun.RequestOpenid();
            wid = MyCommFun.RequestInt("wid");
            sid = MyCommFun.RequestInt("sid");
            if (openid == "" || wid == 0 || sid == 0)
            {
                hidStatus.Value = "-1";
                hidErrInfo.Value = "参数错误";
                return;
            }
            bindData();
        }


        private void bindData()
        {
            BLL.wx_ucard_cardinfo cardBll = new BLL.wx_ucard_cardinfo();
            Model.wx_ucard_cardinfo cardinfo = cardBll.GetModelBySid(sid);
            if (cardinfo != null)
            {
                imgTopPic.ImageUrl = cardinfo.perinfoPic;
            }

            BLL.wx_ucard_users userBll = new BLL.wx_ucard_users();
            Model.wx_ucard_users user = userBll.GetStoreUserInfo(openid, sid);

            uName = user.realName;
            tel = user.mobile;



        }
    }
}