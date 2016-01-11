using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.weixin.sjb
{
    public partial class user_jcret : WeiXinPage
    {
        public int wid = 0;
        public string openid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnlyWeiXinLook();
                wid = MyCommFun.RequestInt("wid", 0);
                openid = MyCommFun.RequestOpenid();

                if (wid == 0 || openid.Trim() == "")
                {
                    hidStatus.Value = "1";
                    hidErrInfo.Value = "访问参数错误！";
                    return;
                }
                BindData();
            }
        }

        public void BindData()
        {
            //用户的基本信息
            BLL.wx_sjb_users uBll = new BLL.wx_sjb_users();
            Model.wx_sjb_users user = new Model.wx_sjb_users();
            int uid = 0;
            int jcRetType = 0;
            if (!uBll.ExistsByOpenid(openid, wid))
            {
                //不存在
            }
            else
            {
                //存在
                user = uBll.GetModelList("openid='" + openid + "'")[0];
                litRightTimes.Text = user.succTimes.ToString();
                litErrTimes.Text = user.failTimes.ToString();
            }

            


        }


    }
}