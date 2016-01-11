using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.admin.diancai
{
    public partial class dingdan_deal : Web.UI.ManagePage
    {
        BLL.wx_diancai_dingdan_manage managebll = new BLL.wx_diancai_dingdan_manage();
        Model.wx_diancai_dingdan_manage manage = new Model.wx_diancai_dingdan_manage();

        public string Dingdanlist = "";
        public string dingdanren = "";
        BLL.wx_diancai_shopinfo shopinfo = new BLL.wx_diancai_shopinfo();
        Model.wx_diancai_shopinfo sjopmodel = new Model.wx_diancai_shopinfo();
        public string id = "";
        public int ids = 0;
        public int shopid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            ids = MyCommFun.RequestInt("id");
            id = MyCommFun.QueryString("id");
            shopid = MyCommFun.RequestInt("shopid");
            if(!IsPostBack)
            {
              
                if (ids != 0)
                {
                    List(ids);
                }
            }
            
        }

        protected void save_groupbase_Click(object sender, EventArgs e)
        {
            id = MyCommFun.QueryString("id");
            shopid = MyCommFun.RequestInt("shopid");
            string status =ddlStatusType.SelectedItem.Value;

            managebll.Updatestatus(id, status);

            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改支付状态，主键为" + id); //记录日志
            JscriptMsg("修改成功！", "dingdan_manage.aspx?shopid=" + shopid + "", "Success");


        }


        public void List(int ids)
        {

            //订单

            Dingdanlist = "";
            dingdanren = "";

            DataSet dr = managebll.Getcaopin(id);
            if (dr.Tables[0].Rows.Count > 0)
            {
                decimal amount = 0;



                Dingdanlist += "<tr><th>菜品名称</th><th class=\"cc\">单价</th><th class=\"cc\">购买份数</th><th class=\"rr\">价格</th> </tr>";
                for (int i = 0; i < dr.Tables[0].Rows.Count; i++)
                {
                    Dingdanlist += " <tr><td>" + dr.Tables[0].Rows[i]["cpName"] + "</td>";
                    Dingdanlist += "<td class=\"cc\">" + dr.Tables[0].Rows[i]["price"] + "</td>";
                    Dingdanlist += "<td class=\"cc\">" + dr.Tables[0].Rows[i]["num"] + "</td>";
                    Dingdanlist += "<td class=\"rr\">￥" + dr.Tables[0].Rows[i]["totpric"] + "</td></tr>";
                    amount += Convert.ToDecimal(dr.Tables[0].Rows[i]["totpric"]);
                }

                sjopmodel = shopinfo.GetModel(shopid);//配送费
                decimal zongji = amount + Convert.ToDecimal(sjopmodel.sendCost);
                if (sjopmodel != null)
                {
                    Dingdanlist += "<tr><td>商品总费</td><td class=\"cc\">￥" + amount + "</td>  <td class=\"cc\" >配送费</td><td class=\"rr\" >￥" + sjopmodel.sendCost + "</td></tr>";
                }
                else
                {
                    Dingdanlist += "<tr><td>商品总费</td><td class=\"cc\">￥" + amount + "</td>  <td class=\"cc\" >配送费</td><td class=\"rr\" >￥" + 0 + "</td></tr>";
                }
                Dingdanlist += "<tr><td>总计：</td><td ></td><td ></td><td class=\"rr\">￥" + zongji + "</td></tr>";

            }


            manage = managebll.GetModeldingdan(id);
            //订单信息
            if (manage != null)
            {
                dingdanren += "<tr><td width=\"70\">订单编号： " + manage.orderNumber + "</td></tr>";
                dingdanren += "<tr> <td>下单时间：" + manage.oderTime + "</td></tr>";
                dingdanren += "<tr><td>联系人：" + manage.customerName + "</td></tr>";
                dingdanren += "<tr><td>联系电话：" + manage.customerTel + "</td></tr>";
                dingdanren += "<tr><td>地址：" + manage.address + "</td></tr>";
                dingdanren += "<tr><td>备注 ：" + manage.oderRemark + "</td></tr>";
                if (manage.payStatus == 1)
                {
                    dingdanren += "<tr><td>订单状态：<em  style='width:70px;' class='ok'>已处理</em></td></tr>";
                }
                else
                {
                    dingdanren += "<tr><td>订单状态：<em  style='width:70px;' class='no'>未处理</em></td></tr>";
                }
            }
            else
            {
                dingdanren += "<tr><td width=\"70\">订单编号：</td></tr>";
                dingdanren += "<tr> <td>下单时间：</td></tr>";
                dingdanren += "<tr><td>联系人：</td></tr>";
                dingdanren += "<tr><td>联系电话：</td></tr>";
                dingdanren += "<tr><td>地址：</td></tr>";
                dingdanren += "<tr><td>备注 ：</td></tr>";


                dingdanren += "<tr><td>订单状态：<em  style='width:70px;' class='no'>未处理</em></td></tr>";

            }


            dingdanren += "<tr><td>商家留言：</td></tr> <tr> <td></td></tr>";
        }
    }
}