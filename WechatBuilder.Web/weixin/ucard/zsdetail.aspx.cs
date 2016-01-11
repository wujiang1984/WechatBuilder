using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.weixin.ucard
{
    public partial class zsdetail : WeiXinPage
    {
        protected string openid = "";
        protected int wid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            OnlyWeiXinLook();
            openid = MyCommFun.RequestOpenid();
            wid = MyCommFun.RequestInt("wid");
            if (openid == "" || wid == 0)
            {
                hidStatus.Value = "-1";
                hidErrInfo.Value = "参数错误";
                return;
            }
            bindData();
        }

        private void bindData()
        {
            //电话
            BLL.wx_ucard_sys sysBll = new BLL.wx_ucard_sys();
            IList<Model.wx_ucard_sys> sys = sysBll.GetModelList(" wid=" + wid);
            if (sys == null || sys.Count <= 0)
            {
            }
            else
            {
                litTel.Text = "<a href=\"tel:" + sys[0].tradeTel + "\"><span>" + sys[0].tradeTel + " 招商热线</span></a>";
                litContent.Text = sys[0].tradeContent;
            }

            //查询会员已经开卡的数量
            BLL.wx_ucard_users userBll = new BLL.wx_ucard_users();
            int num = userBll.GetUserStoreNum(openid);
            lituStoreNum2.Text = num.ToString();
             

        }
    }
}