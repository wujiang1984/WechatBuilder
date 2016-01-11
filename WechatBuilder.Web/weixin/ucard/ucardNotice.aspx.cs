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
    public partial class ucardNotice : WeiXinPage
    {
        protected string openid = "";
        protected int wid = 0;
        protected int sid = 0;//店铺的主键id
        protected int degreeNum = 0;
        protected int uid = 0;
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
                imgTopPic.ImageUrl = cardinfo.noticePic;
            }
            BLL.wx_ucard_users userBll = new BLL.wx_ucard_users();
            Model.wx_ucard_users user = userBll.GetStoreUserInfo(openid, sid);
            if (user == null)
            {
                return;
            }
            int degreeNum = 0;
            BLL.wx_ucard_fun.userDegree(sid, MyCommFun.Obj2Int(user.ttScore), "", out degreeNum);
            BLL.wx_ucard_notice nBll = new BLL.wx_ucard_notice();

            IList<Model.wx_ucard_notice> nlist = nBll.GetModelList(" sid=" + sid + " and ( userDegree ='0' or userDegree like '%," + degreeNum + ",%' ) order by createDate desc");
            StringBuilder noticeStr = new StringBuilder();
            if (nlist != null && nlist.Count > 0)
            {
                Model.wx_ucard_notice notice=new Model.wx_ucard_notice();
                for (int i = 0; i < nlist.Count; i++)
                {
                    notice=nlist[i];
                    if (i == 0)
                    {
                        //第一条数据
                        noticeStr.Append("<div id=\"test0-header\" class=\"accordion_headings  header_highlight \">");
                        noticeStr.Append(" <div class=\"tab  new \">");
                        noticeStr.Append(" <span class=\"title\">" + notice.nName+ "<p>"+notice.createDate.Value.ToString("yyyy年MM月dd日")+"</p>");
                        noticeStr.Append("  </span></div>");
                        noticeStr.Append(" <div id=\"test0-content\" style=\"display: block; overflow: hidden; opacity: 1;\"> ");
                        noticeStr.Append("<div class=\"accordion_child\"><p class=\"xiangqing\">");
                        noticeStr.Append(notice.nContent);
                        noticeStr.Append(" </p></div></div></div>");
                    }
                    else
                    {
                        noticeStr.Append("<div id=\"test"+i+"-header\" class=\"accordion_headings \">");
                        noticeStr.Append("<div class=\"tab \">");
                        noticeStr.Append("<span class=\"title\">" + notice.nName + "<p>" + notice.createDate.Value.ToString("yyyy年MM月dd日") + "</p></span>");
                        noticeStr.Append("</div>");
                        noticeStr.Append(" <div id=\"test"+i+"-content\" style=\"display: none; overflow: hidden;\">");
                        noticeStr.Append("<div class=\"accordion_child\">");
                        noticeStr.Append("<p class=\"xiangqing\">"+notice.nContent+"</p>");
                        noticeStr.Append("</div> </div> </div>");
                    }
                }
            
            }
            litNoticeList.Text = noticeStr.ToString();

        }
    }
}