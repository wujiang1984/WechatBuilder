using WechatBuilder.BLL;
using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.admin.grouppurchase
{
    public partial class group_base_add : Web.UI.ManagePage
    {
        protected   int id = 0;
        BLL.wx_purchase_base basebll = new BLL.wx_purchase_base();

        protected void Page_Load(object sender, EventArgs e)
        {
            id = MyCommFun.RequestInt("id");
            if (!IsPostBack)
            {
                if (id != 0)
                {
                    Model.wx_purchase_base model = basebll.GetModel(id);

                    //团购活动开始内容
                    this.activityName.Text = model.activityName;
                    this.activitySummary.InnerText = model.activitySummary;
                    this.activityTimebegin.Text = model.activityTimebegin.ToString();
                    this.activityTimeend.Text = model.activityTimeend.ToString();
                    this.email.Text = model.email;
                    this.emailPwd.Text = model.emailPwd;
                    this.smtp.Text = model.smtp;
                    this.shopsPwd.Text = model.shopsPwd;
                    this.activeDescription.InnerText = model.activeDescription;
                    this.specialRemind.InnerText = model.specialRemind;

                    if (model.imageUrl != "" && model.imageUrl != "/weixin/groupbuy/images/Groupbuying-Start.jpg")
                    {
                        this.imageUrl.Text = model.imageUrl;
                        imgbeginPic.ImageUrl = model.imageUrl; 
                    }
                    else
                    {
                        this.imageUrl.Text = this.imgbeginPic.ImageUrl;
                    }

                    if (model.imageUrlend != "" && model.imageUrlend != "/weixin/groupbuy/images/activity-coupon-end.jpg")
                    {
                        this.imageUrlend.Text = model.imageUrlend;
                        imgendPic.ImageUrl = model.imageUrlend;
                    }
                    else
                    {
                        this.imageUrlend.Text = this.imgendPic.ImageUrl;
                    }

                    //团购活动结束内容
                    this.activityEndtitle.Text = model.activityEndtitle;
                    this.endExplanation.InnerText = model.endExplanation;


                    //商家信息设置

                    this.shopstel.Text = model.shopstel;
                    this.address.Text = model.address;
                    this.introduction.InnerText = model.introduction;
                    this.txtLatXPoint.Text = model.txtLatXPoint.ToString();
                    this.txtLngYPoint.Text = model.txtLngYPoint.ToString();

                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'> $(\"#baiduframe\").attr(\"src\", \"../lbs/MapSelectPoint.aspx?yjindu=" + model.txtLngYPoint.Value.ToString() + "&xweidu=" + model.txtLatXPoint.Value.ToString() + "\");</script>");


                    //团购设置

                    this.goodName.Text = model.goodName;
                    this.costPrice.Text = model.costPrice.ToString();
                    this.limitCount.Text = model.limitCount.ToString();
                    this.groupPrice.Text = model.groupPrice.ToString();
                    this.totalCount.Text = model.totalCount.ToString();
                    this.groupPerson.Text = model.groupPerson.ToString();
                    this.virtualPerson.Text = model.virtualPerson.ToString();
                    this.copyrightSetup.InnerText = model.copyrightSetup;

                }

            }
        }

        protected void save_groupbase_Click(object sender, EventArgs e)
        {
            DateTime begin = DateTime.Parse(activityTimebegin.Text.Trim());
            DateTime end = DateTime.Parse(activityTimeend.Text.Trim());
            if (begin >= end)
            {
                JscriptMsg("开始时间必须小于结束时间", "back", "Error");
                return;
            }

            if (id != 0)
            {

                Model.wx_userweixin weixin = GetWeiXinCode();
                int wid = weixin.id;



                Model.wx_purchase_base purchasebase = new Model.wx_purchase_base();


                purchasebase.wid = wid;//
                purchasebase.Id = id;
                //团购活动开始内容
                purchasebase.activityName = this.activityName.Text.ToString();
                purchasebase.activitySummary = this.activitySummary.InnerText.ToString();
                purchasebase.activityTimebegin = Convert.ToDateTime(this.activityTimebegin.Text.ToString());
                purchasebase.activityTimeend = Convert.ToDateTime(this.activityTimeend.Text.ToString());
                purchasebase.email = this.email.Text.ToString();
                purchasebase.emailPwd = this.emailPwd.Text.ToString();
                purchasebase.smtp = this.smtp.Text.ToString();
                purchasebase.shopsPwd = this.shopsPwd.Text.ToString();
                purchasebase.activeDescription = this.activeDescription.InnerText.ToString();
                purchasebase.specialRemind = this.specialRemind.InnerText.ToString();

                if (this.imageUrl.Text != "" && this.imageUrl.Text != this.imgbeginPic.ImageUrl)
                {
                    purchasebase.imageUrl = this.imageUrl.Text;
                }
                else
                {
                    purchasebase.imageUrl = this.imgbeginPic.ImageUrl;
                }

                if (this.imageUrlend.Text != "" && this.imageUrlend.Text != this.imgendPic.ImageUrl)
                {
                    purchasebase.imageUrlend = this.imageUrlend.Text;
                }
                else
                {
                    purchasebase.imageUrlend = this.imgendPic.ImageUrl;
                }


                //团购活动结束内容

                purchasebase.activityEndtitle = this.activityEndtitle.Text.ToString();
                purchasebase.endExplanation = this.endExplanation.InnerText.ToString();

                //商家信息设置

                purchasebase.shopstel = this.shopstel.Text.ToString();
                purchasebase.address = this.address.Text.ToString();
                purchasebase.introduction = this.introduction.InnerText.ToString();
                purchasebase.txtLatXPoint = Convert.ToDecimal(this.txtLatXPoint.Text);
                purchasebase.txtLngYPoint = Convert.ToDecimal(this.txtLngYPoint.Text);

                //团购设置

                purchasebase.goodName = this.goodName.Text.ToString();
                purchasebase.costPrice = Convert.ToInt32(this.costPrice.Text.ToString());
                purchasebase.limitCount = Convert.ToInt32(this.limitCount.Text.ToString());
                purchasebase.groupPrice = Convert.ToDecimal(this.groupPrice.Text.ToString());
                purchasebase.totalCount = Convert.ToInt32(this.totalCount.Text.ToString());
                purchasebase.groupPerson = Convert.ToInt32(this.groupPerson.Text.ToString());
                purchasebase.virtualPerson = Convert.ToInt32(this.virtualPerson.Text.ToString());
                purchasebase.copyrightSetup = this.copyrightSetup.InnerText.ToString();


                purchasebase.createtime = DateTime.Now;




                basebll.Update(purchasebase);

                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "修改活动设置id为:" + id); //记录日志

                JscriptMsg("修改成功！", Utils.CombUrlTxt("group_list.aspx", "keywords={0}", ""), "Success");
            }
            else
            {



                Model.wx_userweixin weixin = GetWeiXinCode();
                int wid = weixin.id;


                Model.wx_purchase_base purchasebase = new Model.wx_purchase_base();


                purchasebase.wid = wid;//

                //团购活动开始内容
                purchasebase.activityName = this.activityName.Text.ToString();
                purchasebase.activitySummary = this.activitySummary.InnerText.ToString();
                purchasebase.activityTimebegin = Convert.ToDateTime(this.activityTimebegin.Text.ToString());
                purchasebase.activityTimeend = Convert.ToDateTime(this.activityTimeend.Text.ToString());
                purchasebase.email = this.email.Text.ToString();
                purchasebase.emailPwd = this.emailPwd.Text.ToString();
                purchasebase.smtp = this.smtp.Text.ToString();
                purchasebase.shopsPwd = this.shopsPwd.Text.ToString();
                purchasebase.activeDescription = this.activeDescription.InnerText.ToString();
                purchasebase.specialRemind = this.specialRemind.InnerText.ToString();

                if (this.imageUrl.Text != "" && this.imageUrl.Text != this.imgbeginPic.ImageUrl)
                {
                    purchasebase.imageUrl = this.imageUrl.Text;
                }
                else
                {
                    purchasebase.imageUrl = this.imgbeginPic.ImageUrl;
                }

                if (this.imageUrlend.Text != "" && this.imageUrlend.Text != this.imgendPic.ImageUrl)
                {
                    purchasebase.imageUrlend = this.imageUrlend.Text;
                }
                else
                {
                    purchasebase.imageUrlend = this.imgendPic.ImageUrl;
                }
                //团购活动结束内容

                purchasebase.activityEndtitle = this.activityEndtitle.Text.ToString();
                purchasebase.endExplanation = this.endExplanation.InnerText.ToString();

                //商家信息设置

                purchasebase.shopstel = this.shopstel.Text.ToString();
                purchasebase.address = this.address.Text.ToString();
                purchasebase.introduction = this.introduction.InnerText.ToString();
                purchasebase.txtLatXPoint = Convert.ToDecimal(this.txtLatXPoint.Text.ToString());
                purchasebase.txtLngYPoint = Convert.ToDecimal(this.txtLngYPoint.Text.ToString());

                //团购设置

                purchasebase.goodName = this.goodName.Text.ToString();
                purchasebase.costPrice = Convert.ToInt32(this.costPrice.Text.ToString());
                purchasebase.limitCount = Convert.ToInt32(this.limitCount.Text.ToString());
                purchasebase.groupPrice = Convert.ToDecimal(this.groupPrice.Text.ToString());
                purchasebase.totalCount = Convert.ToInt32(this.totalCount.Text.ToString());
                purchasebase.groupPerson = Convert.ToInt32(this.groupPerson.Text.ToString());
                purchasebase.virtualPerson = Convert.ToInt32(this.virtualPerson.Text.ToString());
                purchasebase.copyrightSetup = this.copyrightSetup.InnerText.ToString();


                purchasebase.createtime = DateTime.Now;




                int shopid = basebll.Add(purchasebase);

                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "增加活动设置" + shopid); //记录日志

                JscriptMsg("添加成功！", Utils.CombUrlTxt("group_list.aspx", "keywords={0}", ""), "Success");
            }




        }


        public bool delete(int id)
        {
            return basebll.Delete(id);
        }
    }
}