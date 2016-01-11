using WechatBuilder.BLL;
using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.admin.diancai
{
    public partial class shop_add : Web.UI.ManagePage
    {
        TextBox description;
        TextBox sortid;
        TextBox picUrl;
        TextBox pictzUrl;
        protected string editetype = "";
        protected static int shopid = 0;
        BLL.wx_diancai_shopinfo hotelBll = new BLL.wx_diancai_shopinfo();
        Model.wx_diancai_shopinfo hotel = new Model.wx_diancai_shopinfo();

        BLL.wx_diancai_shoppic picBll = new BLL.wx_diancai_shoppic();
        Model.wx_diancai_shoppic pic = new Model.wx_diancai_shoppic();
        wx_diancai_shoppic iBll = new wx_diancai_shoppic();

        protected void Page_Load(object sender, EventArgs e)
        {
            shopid = MyCommFun.RequestInt("shopid");

            if (!IsPostBack)
            {
               
                editetype = MyCommFun.QueryString("type");
                
                if (editetype == "edite")
                {
                   list(shopid);
                }


            }
        }

        public void list(int shopid)
        {
            hotel = hotelBll.GetModel(shopid);
            if (hotel != null)
            {
                this.hotelName.Text = hotel.hotelName;
                this.hotelLogo.Text = hotel.hotelLogo;
                this.hoteltimeBegin.Text = hotel.hoteltimeBegin.Value.ToString("HH:mm:ss");
                this.hoteltimeEnd.Text = hotel.hoteltimeEnd.Value.ToString("HH:mm:ss");
                if (hotel.hoteltimeBegin1 != null)
                {
                    this.hoteltimeBegin1.Text = hotel.hoteltimeBegin1.Value.ToString("HH:mm:ss");
                }
                if (hotel.hoteltimeEnd1 != null)
                {
                    this.hoteltimeEnd1.Text = hotel.hoteltimeEnd1.Value.ToString("HH:mm:ss");
                }
                if (hotel.hoteltimeBegin2 != null)
                {
                    this.hoteltimeBegin2.Text = hotel.hoteltimeBegin2.Value.ToString("HH:mm:ss");
                }
                if (hotel.hoteltimeEnd2 != null)
                {
                    this.hoteltimeEnd2.Text = hotel.hoteltimeEnd2.Value.ToString("HH:mm:ss");
                }

                this.limiteOrder.SelectedValue = hotel.limiteOrder.ToString();
                this.rename.Text = hotel.dcRename;
                this.sendPrice.Text = hotel.sendPrice.ToString();
                this.sendCost.Text = hotel.sendCost.ToString();
                this.freeSendcost.Text = hotel.freeSendcost.ToString();
                this.type.Value = hotel.kcType;
                this.miaoshu.InnerText = hotel.miaoshu;
                this.radius.Text = hotel.radius;
                this.sendArea.Text = hotel.sendArea;
                this.tel.Text = hotel.tel;
                this.address.Text = hotel.address;
                this.txtLatXPoint.Text = hotel.xplace.ToString();
                this.txtLngYPoint.Text = hotel.yplace.ToString();
                this.personLimite.Text = hotel.personLimite.ToString();
                this.notice.InnerText = hotel.notice;
                this.hotelintroduction.InnerText = hotel.hotelintroduction;
                this.email.Text = hotel.email;
                this.emailpwd.Text = hotel.emailpwd;
                this.stmp.Text = hotel.stmp;
                this.css.Text = hotel.css;
            }

            IList<Model.wx_diancai_shoppic> itemlist = iBll.GetModelList("shopid=" + shopid + " order by id asc");
            if (itemlist != null && itemlist.Count > 0)
            {
                int count = itemlist.Count;


                Model.wx_diancai_shoppic itemEntity = new Model.wx_diancai_shoppic();
                for (int i = 1; i <= count; i++)
                {
                    itemEntity = itemlist[(i - 1)];
                    description = this.FindControl("description" + i) as TextBox;
                    sortid = this.FindControl("sortid" + i) as TextBox;
                    picUrl = this.FindControl("picUrl" + i) as TextBox;
                    pictzUrl = this.FindControl("pictzUrl" + i) as TextBox;

                    description.Text = itemEntity.description;
                    sortid.Text = itemEntity.sortid.ToString();
                    picUrl.Text = itemEntity.picUrl.ToString();
                    pictzUrl.Text = itemEntity.pictzUrl.ToString();

                }

            }
        }

        protected void save_groupbase_Click(object sender, EventArgs e)
        {
            editetype = MyCommFun.QueryString("type");
            Model.wx_userweixin weixin = GetWeiXinCode();
            int wid = weixin.id;


            if (editetype == "add")
            {
                hotel.wid = wid;
                hotel.hotelName = this.hotelName.Text;
                hotel.hotelLogo = this.hotelLogo.Text;
                hotel.hoteltimeBegin = Convert.ToDateTime("2100-1-1 "+this.hoteltimeBegin.Text);
                hotel.hoteltimeEnd = Convert.ToDateTime("2100-1-1 " + this.hoteltimeEnd.Text);
                if (this.hoteltimeBegin1.Text != "" && this.hoteltimeEnd1.Text != "")
                {
                    hotel.hoteltimeBegin1 = Convert.ToDateTime("2100-1-1 " + this.hoteltimeBegin1.Text);
                    hotel.hoteltimeEnd1 = Convert.ToDateTime("2100-1-1 " + this.hoteltimeEnd1.Text);
                }
                else
                {
                    hotel.hoteltimeBegin2 =null;
                    hotel.hoteltimeEnd2 = null;
                }
                if (this.hoteltimeBegin2.Text != "" && this.hoteltimeEnd2.Text != "")
                {
                    hotel.hoteltimeBegin2 = Convert.ToDateTime("2100-1-1 " + this.hoteltimeBegin2.Text);
                    hotel.hoteltimeEnd2 = Convert.ToDateTime("2100-1-1 " + this.hoteltimeEnd2.Text);
                }
                else
                {
                    hotel.hoteltimeBegin2 =null;
                    hotel.hoteltimeEnd2 = null;
                }


                hotel.limiteOrder = Convert.ToBoolean(this.limiteOrder.SelectedValue);
                
                hotel.dcRename = this.rename.Text;
                hotel.sendPrice = Convert.ToDecimal(this.sendPrice.Text);
                hotel.sendCost = Convert.ToDecimal(this.sendCost.Text);
                hotel.freeSendcost = Convert.ToInt32(this.freeSendcost.Text);
                hotel.radius = this.radius.Text;
                hotel.sendArea = this.sendArea.Text;
                hotel.tel = this.tel.Text;
                hotel.address = this.address.Text;
                hotel.personLimite = Convert.ToInt32(this.personLimite.Text);
                hotel.notice = this.notice.InnerText;
                hotel.hotelintroduction = this.hotelintroduction.InnerText;
                hotel.email = this.email.Text;
                hotel.emailpwd = this.emailpwd.Text;
                hotel.stmp = this.stmp.Text;
                hotel.css = this.css.Text;
                hotel.createDate = DateTime.Now;
                hotel.kcType = this.type.Value;
                hotel.miaoshu = this.miaoshu.InnerText;
                hotel.xplace = Convert.ToDecimal(this.txtLatXPoint.Text);
                hotel.yplace = Convert.ToDecimal(this.txtLngYPoint.Text);

                int id = hotelBll.Add(hotel);


                for (int i = 1; i <= 6; i++)
                {
                    description = this.FindControl("description" + i) as TextBox;
                    sortid = this.FindControl("sortid" + i) as TextBox;
                    picUrl = this.FindControl("picUrl" + i) as TextBox;
                    pictzUrl = this.FindControl("pictzUrl" + i) as TextBox;

                    if (description.Text.Trim() != "" && sortid.Text.Trim() != "")
                    {

                        pic.shopid = id;
                        pic.description = description.Text.ToString();
                        pic.sortid = MyCommFun.Str2Int( sortid.Text.ToString());
                        pic.picUrl = picUrl.Text.ToString();
                        pic.pictzUrl = pictzUrl.Text.ToString();
                        pic.createDate = DateTime.Now;
                        picBll.Add(pic);

                    }
                }
                    AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加商家设置，主键为" + id); //记录日志
                    JscriptMsg("添加成功！","shop_list.aspx", "Success");
               
            }



                if (editetype == "edite")
                {
                    if (shopid==0)
                    {

                        return;
                        //操作失败！
                    }
                    hotel.id = shopid;
                    hotel.wid = wid;
                    hotel.hotelName = this.hotelName.Text;
                    hotel.hotelLogo = this.hotelLogo.Text;
                    hotel.hoteltimeBegin = Convert.ToDateTime("2100-1-1 " + this.hoteltimeBegin.Text);
                    hotel.hoteltimeEnd = Convert.ToDateTime("2100-1-1 " + this.hoteltimeEnd.Text);

                    if (this.hoteltimeBegin1.Text != "" && this.hoteltimeEnd1.Text != "")
                    {
                        hotel.hoteltimeBegin1 = Convert.ToDateTime("2100-1-1 " + this.hoteltimeBegin1.Text);
                        hotel.hoteltimeEnd1 = Convert.ToDateTime("2100-1-1 " + this.hoteltimeEnd1.Text);
                    }
                    else
                    {
                        hotel.hoteltimeBegin2 = null;
                        hotel.hoteltimeEnd2 = null;
                    }
                    if (this.hoteltimeBegin2.Text != "" && this.hoteltimeEnd2.Text != "")
                    {
                        hotel.hoteltimeBegin2 = Convert.ToDateTime("2100-1-1 " + this.hoteltimeBegin2.Text);
                        hotel.hoteltimeEnd2 = Convert.ToDateTime("2100-1-1 " + this.hoteltimeEnd2.Text);
                    }
                    else
                    {
                        hotel.hoteltimeBegin2 = null;
                        hotel.hoteltimeEnd2 = null;
                    }

                    hotel.limiteOrder = Convert.ToBoolean(this.limiteOrder.SelectedValue);
                    hotel.dcRename = this.rename.Text;
                    hotel.sendPrice = Convert.ToDecimal(this.sendPrice.Text);
                    hotel.sendCost = Convert.ToDecimal(this.sendCost.Text);
                    hotel.freeSendcost = Convert.ToInt32(this.freeSendcost.Text);
                    hotel.radius = this.radius.Text;
                    hotel.sendArea = this.sendArea.Text;
                    hotel.tel = this.tel.Text;
                    hotel.address = this.address.Text;
                    hotel.personLimite = Convert.ToInt32(this.personLimite.Text);
                    hotel.notice = this.notice.InnerText;
                    hotel.hotelintroduction = this.hotelintroduction.InnerText;
                    hotel.email = this.email.Text;
                    hotel.emailpwd = this.emailpwd.Text;
                    hotel.stmp = this.stmp.Text;
                    hotel.css = this.css.Text;
            
                    hotel.kcType = this.type.Value;
                    hotel.miaoshu = this.miaoshu.InnerText;
                    hotel.xplace = Convert.ToDecimal(this.txtLatXPoint.Text);
                    hotel.yplace = Convert.ToDecimal(this.txtLngYPoint.Text);
                    hotelBll.Update(hotel);

                    picBll.Delete(shopid);

                    for (int i = 1; i <= 6; i++)
                    {
                        description = this.FindControl("description" + i) as TextBox;
                        sortid = this.FindControl("sortid" + i) as TextBox;
                        picUrl = this.FindControl("picUrl" + i) as TextBox;
                        pictzUrl = this.FindControl("pictzUrl" + i) as TextBox;

                        if (description.Text.Trim() != "" && sortid.Text.Trim() != "")
                        {

                            pic.shopid = shopid;
                            pic.description = description.Text.ToString();
                            pic.sortid =MyCommFun.Str2Int( sortid.Text.ToString());
                            pic.picUrl = picUrl.Text.ToString();
                            pic.pictzUrl = pictzUrl.Text.ToString();
                            pic.createDate = DateTime.Now;
                            picBll.Add(pic);

                        }
                    }
                    AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改商家设置，主键为" + shopid); //记录日志
                    JscriptMsg("修改成功！", "shop_list.aspx", "Success");
                }




            }
        }
    }
