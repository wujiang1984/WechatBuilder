using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.weixin.diancai
{
    public partial class caidan_manage_indexdetail : WeiXinPage
    {
        public string id = "";
        public int shopid = 0;
        public string Dingdanlist="";
        public string dingdandatail="";
        BLL.wx_diancai_dingdan_manage manage = new BLL.wx_diancai_dingdan_manage();
        Model.wx_diancai_dingdan_manage managemodel = new Model.wx_diancai_dingdan_manage();
        BLL.wx_diancai_shopinfo shopinfo = new BLL.wx_diancai_shopinfo();
        Model.wx_diancai_shopinfo sjopmodel = new Model.wx_diancai_shopinfo();
        public string hotelName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                id = MyCommFun.QueryString("id");
                shopid = MyCommFun.RequestInt("shopid");
                sjopmodel = shopinfo.GetModel(shopid);
                hotelName = sjopmodel.hotelName;

                if (id != "")
                {
                    List(id);
                }

            }
        }

        public void List(string id)
        {
            DataSet dr = manage.Getcaopin(id);
            if(dr.Tables[0].Rows.Count>0)
            {
                 decimal amount = 0;

                  
   
                Dingdanlist+="<tr><th>菜品名称</th><th class=\"cc\">单价</th><th class=\"cc\">购买份数</th><th class=\"rr\">价格</th> </tr>";
                for (int i=0;i<dr.Tables[0].Rows.Count;i++)
                {
                Dingdanlist+=" <tr><td>"+dr.Tables[0].Rows[i]["cpName"]+"</td>";
                Dingdanlist+="<td class=\"cc\">"+dr.Tables[0].Rows[i]["price"]+"</td>";
                Dingdanlist+="<td class=\"cc\">"+dr.Tables[0].Rows[i]["num"]+"</td>";
                Dingdanlist+="<td class=\"rr\">￥"+dr.Tables[0].Rows[i]["totpric"]+"</td></tr>";
                amount += Convert.ToDecimal( dr.Tables[0].Rows[i]["totpric"]);
                }
                decimal zongji = amount + Convert.ToDecimal( sjopmodel.sendCost);
                Dingdanlist += "<tr><td>总计：</td><td ></td><td ></td><td class=\"rr\">￥" + zongji + "</td></tr>";
            }

             managemodel = manage.GetModeldingdan(id);
            //订单信息
            if (managemodel != null)
            {
                //05月22日 14时01分
                dingdandatail+="<li class=\"title\"><span class=\"none\">"+managemodel.oderTime+"订单详情";
                if(managemodel.payStatus.ToString()=="1")
                {
                dingdandatail+="<em  style='width:70px;' class='ok'>成功</em></span></li>";
                }
                else
                {
                dingdandatail+="<em  style='width:70px;' class='no'>未处理</em></span></li>";
                }
                dingdandatail+="<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"cpbiaoge\">";

                dingdandatail += " <tr> <td>联系人 : " + managemodel.customerName+ "</td></tr>";
                dingdandatail += " <tr> <td>联系电话 : " + managemodel.customerTel+ "</td></tr>";
                dingdandatail += " <tr> <td>地址 : " + managemodel.address+ "</td></tr>";
                dingdandatail += "<tr><td>备注 : " + managemodel .oderRemark+ "</td></tr>";
                dingdandatail += "<td>预订时间：" + managemodel .oderTime+ "</td></tr>";//2014年05月22日 14时01分
                dingdandatail += "<tr><td valign=\"top\">备注信息：" + managemodel .oderRemark+ "</td></tr>";
                dingdandatail+="  </table>";
                

            }


        }
    }
}