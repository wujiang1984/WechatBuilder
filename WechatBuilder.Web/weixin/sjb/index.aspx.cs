using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.weixin.sjb
{
    public partial class index : WeiXinPage
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

                if ( wid == 0 || openid.Trim() == "")
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
                uid = user.id;  
            }

            BLL.wx_sjb_jcDetail dBll = new BLL.wx_sjb_jcDetail();
            
            BLL.wx_sjb_bisai bsBll = new BLL.wx_sjb_bisai();
            DateTime now = DateTime.Now;
            IList<Model.wx_sjb_bisai> bslist = bsBll.GetModelList("jcBeginDate<='" + now.ToString() + "' and jcEndDate>'" + now.ToString() + "' and rcId in (select id from wx_sjb_richeng where wid=" + wid + ") order by beginDate asc");

            if (bslist == null || bslist.Count() <= 0)
            {
                return;
            }
            BLL.wx_sjb_qiudui qdBll = new BLL.wx_sjb_qiudui();
            Model.wx_sjb_qiudui qiudui = new Model.wx_sjb_qiudui();
               Model.wx_sjb_qiudui qiudui2 = new Model.wx_sjb_qiudui();
            Model.wx_sjb_bisai bisai = new Model.wx_sjb_bisai();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bslist.Count; i++)
            {
                bisai = bslist[i];
                if (uid > 0)
                {
                    jcRetType = dBll.GetjcRetType(bisai.id, uid);
                }


                qiudui = qdBll.GetModel(bisai.qd1Id.Value);
                qiudui2 = qdBll.GetModel(bisai.qd2Id.Value);

                sb.Append(" <div class=\"jc_content\">");

                //展示
                sb.Append("    <div class=\"jc_main\">");
           ;
                sb.Append("      <div class=\"jc_qiudui\">");

                sb.Append("      <img  src=\"" + qiudui.qdPic+ "\" />");
                sb.Append("      <div class=\"jc_wenzi\">" + qiudui.qdName+ "</div>");
                sb.Append("    </div>");

                sb.Append("   <div class=\"jc_vs\"> VS </div>");
                sb.Append("   <div class=\"jc_qiudui\">");
                sb.Append("      <img   src=\""+qiudui2.qdPic+"\" />");
                sb.Append("      <div class=\"jc_wenzi\">"+qiudui2.qdName+"</div>");
                sb.Append("   </div>");
                sb.Append("   </div>");//jc_main 
                //end:展示

                sb.Append("  <div class=\"jc_clear\"></div>");

                //form
                sb.Append("<div class=\"jc_form\">");
                sb.Append("<div>");
                if (jcRetType == 1)
                {
                    sb.Append("   <input id=\"radQd_" + bisai.id + "_1\" type=\"radio\" name=\"jingcai" + bisai.id + "\" value=\"1\" checked=\"checkde\" /><label for=\"radQd_" + bisai.id + "_1\">" + qiudui.qdName + "胜</label>");

                }
                else
                {
                    sb.Append("   <input id=\"radQd_" + bisai.id + "_1\" type=\"radio\" name=\"jingcai" + bisai.id + "\" value=\"1\" /><label for=\"radQd_" + bisai.id + "_1\">" + qiudui.qdName + "胜</label>");
                
                }
                sb.Append("</div>");

                sb.Append("<div>");
                if (jcRetType == 3)
                {
                    sb.Append("   <input id=\"radQd_" + bisai.id + "_3\" type=\"radio\" name=\"jingcai" + bisai.id + "\" value=\"3\" checked=\"checkde\" /><label for=\"radQd_" + bisai.id + "_3\">平局</label>");

                }
                else
                {
                    sb.Append("   <input id=\"radQd_" + bisai.id + "_3\" type=\"radio\" name=\"jingcai" + bisai.id + "\" value=\"3\"   /><label for=\"radQd_" + bisai.id + "_3\">平局</label>");
                }
                sb.Append("</div>");

                sb.Append("<div>");
                if (jcRetType == 2)
                {
                    sb.Append("   <input id=\"radQd_" + bisai.id + "_2\" type=\"radio\" name=\"jingcai" + bisai.id + "\" value=\"2\"  checked=\"checkde\"  /><label for=\"radQd_" + bisai.id + "_2\">" + qiudui2.qdName + "胜</label>");
                }
                else {
                    sb.Append("   <input id=\"radQd_" + bisai.id + "_2\" type=\"radio\" name=\"jingcai" + bisai.id + "\" value=\"2\" /><label for=\"radQd_" + bisai.id + "_2\">" + qiudui2.qdName + "胜</label>");
               
                }
                sb.Append("</div>");

                sb.Append("<div class='divbtn'>");
                if (jcRetType <= 0)
                {
                    sb.Append("    <input id=\"btnJS1\" class=\"btnJs\" type=\"button\" value=\"提交\" group=\"jingcai" + bisai.id + "\" bisaiid=\"" + bisai.id + "\" />");
                }
                sb.Append("</div>");
                    sb.Append("</div>");

                //end:form

                sb.Append(" </div>");
                

            }//end:for


            litJcStr.Text = sb.ToString();
            
        
        }
    }
}