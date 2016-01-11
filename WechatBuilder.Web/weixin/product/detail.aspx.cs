using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.weixin.product
{
    public partial class detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null || Request.QueryString["id"].ToString().Trim() == "")
                {
                    return;
                }
                int id = int.Parse(Request.QueryString["id"].ToString());
                BindData(id);
            }
        }

        public void BindData(int id)
        {
            BLL.wx_product hdBll = new BLL.wx_product();
            Model.wx_product huodong = hdBll.GetModel(id);
            Page.Title = huodong.hdName;
            litTheme.Text = huodong.pSubject;

            litCreateDate.Text = huodong.createDate == null ? "" : huodong.createDate.Value.ToString("yyyy-MM-dd");
            if (huodong.extStr2 == null || huodong.extStr2.ToString().Trim() == "")
            {
                imgPic.Style.Add("display", "none");
            }
            else
            {
                imgPic.ImageUrl = huodong.extStr2;
            }
            StringBuilder detailSB = new StringBuilder();

            if (isNotNullFun(huodong.beginDate))
            {
                detailSB.Append(" <li class=\"newsmore\"><div class=\"olditem\">");
                detailSB.Append("时间 ：" + huodong.beginDate.Value.ToShortDateString() + " ~ ");
                if (isNotNullFun(huodong.endDate))
                {
                    detailSB.Append(huodong.endDate.Value.ToShortDateString());
                }
                detailSB.Append(" </div></li>\r\n");

            }
            if (isNotNullFun(huodong.addr))
            {
                detailSB.Append(" <li class=\"newsmore\"><div class=\"olditem\">");
                detailSB.Append("地点 ：" + huodong.addr);
                detailSB.Append(" </div></li>\r\n");
            }

            if (isNotNullFun(huodong.pContent))
            {
                //detailSB.Append(" <li class=\"newsmore\"><div class=\"olditem\">");
                //detailSB.Append("活动内容 ：");
                //detailSB.Append(" </div></li>\r\n");
                //detailSB.Append(" <li class=\"newsmore\"><div class=\"olditem\">");
                //detailSB.Append("  " + huodong.hdContent);
                //detailSB.Append(" </div></li>\r\n");
                litContent.Text = huodong.pContent;
            }

            litDetail.Text = detailSB.ToString();

            //底部菜单设置
            int wid = MyCommFun.RequestInt("wid");
            string openid = MyCommFun.RequestOpenid();
            BLL.wx_product_type hdtypeBll = new BLL.wx_product_type();
            Model.wx_product_type type = hdtypeBll.GetModel(huodong.typeId.Value);
            StringBuilder bottomMenu = new StringBuilder("");
            int num_dh = 0;
            if (isNotNullFun(type.tel))
            {
                num_dh++;
                bottomMenu.Append("  <li> <a href=\"tel:"+type.tel+"\">");
                bottomMenu.Append("  <img src=\"/images/templates/bottommenu/181.png\"><label>联系电话</label></a></li>");
            }

            if (isNotNullFun(type.daohangurl))
            {
                num_dh++;
                bottomMenu.Append(" <li> <a href=\""+type.daohangurl+"\">");
                bottomMenu.Append(" <img src=\"/images/templates/bottommenu/131.png\"><label>一键导航</label></a>  </li>");  
            }
            if (isNotNullFun(type.showDefault) && type.showDefault)
            {
                bottomMenu.Append(" <li class=\"home\"><a href=\"/index.aspx?wid=" + wid + "&openid=" + openid + "\"></a></li>");
            }
           
            num_dh++;
            if (isNotNullFun(huodong.url))
            {
                num_dh++;
                string yudingName = "在线预定";
                if (isNotNullFun(huodong.btnName))
                {
                    yudingName = huodong.btnName;
                }
                bottomMenu.Append(" <li> <a href=\"" + huodong.url+ "\">");
                bottomMenu.Append(" <img src=\"/images/templates/bottommenu/127.png\"><label>" + yudingName + "</label></a>  </li>");
            }
            if (num_dh == 4)
            {
                bottomMenu.Append("<li> <a href=\"http://m.baidu.com\">");
                bottomMenu.Append("<img src=\"/images/templates/bottommenu/43.png\"><label>百度搜索</label></a>  </li>");
            }

            litdaohang.Text = bottomMenu.ToString();
            
        }

        private bool isNotNullFun(object o)
        {
            if (o == null)
            {
                return false;
            }
            if (o.ToString().Trim() == "")
            {
                return false;
            }
            return true;
        }

        private string DateStr(object t)
        {
            if (t == null)
            {
                return "";
            }
            DateTime tmp = new DateTime();
            if (DateTime.TryParse(t.ToString(), out tmp))
            {
                return tmp.ToShortDateString();
            }
            else
            {
               return "";
            }

        }
    }
}