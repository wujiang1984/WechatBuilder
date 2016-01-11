using System;
using System.Xml;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;

namespace WechatBuilder.Web.shopmgr.setting
{
    public partial class payment_add : Web.UI.ManagePage
    {
        private int id = 0;
        protected Model.wx_payment_type model = new Model.wx_payment_type();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = MXRequest.GetQueryInt("id");
            if (this.id == 0)
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }
            if (!new BLL.wx_payment_type().Exists(this.id))
            {
                JscriptMsg("支付方式不存在或已删除！", "back", "Error");
                return;
            }
            if (!Page.IsPostBack)
            {
              
                ShowInfo(this.id);
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.wx_payment_type bll = new BLL.wx_payment_type();
            model = bll.GetModel(_id);
            txtTitle.Text = model.typeName;
         
            txtSortId.Text = model.sort_id.ToString();
          
            txtImgUrl.Text = model.img_url;
            txtRemark.Text = model.remark;
            hidApi_path.Value = model.api_path;
            if (model.id==2)
            {
                //支付宝
               
            }
            else if (model.id==3)
            {
                //微支付
                
            }
             
        }
        #endregion

        #region 添加操作=================================
        private bool DoAdd(int _id)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();

            bool result = false;
            BLL.payment bll = new BLL.payment();
            Model.payment model = new Model.payment();

            model.title = txtTitle.Text.Trim();
            if (cbIsLock.Checked == true)
            {
                model.is_lock = 0;
            }
            else
            {
                model.is_lock = 1;
            }
            model.sort_id = int.Parse(txtSortId.Text.Trim());
            model.poundage_type = int.Parse(rblPoundageType.SelectedValue);
            model.poundage_amount = decimal.Parse(txtPoundageAmount.Text.Trim());
            model.img_url = txtImgUrl.Text.Trim();
            model.remark = txtRemark.Text;
            model.pTypeId = _id;
            model.wid = weixin.id;
            model.api_path = hidApi_path.Value;
            if (_id==2)
            {
                //支付宝
                BLL.wx_payment_alipay aliBll = new BLL.wx_payment_alipay();
                Model.wx_payment_alipay alipay = new Model.wx_payment_alipay();
                alipay.ownerName = txtAlipaySellerEmail.Text.Trim();
                alipay.partner = txtAlipayPartner.Text.Trim();
                alipay.e_key = txtAlipayKey.Text.Trim();
                alipay.private_key = txtprivate_key.Text.Trim();
                alipay.public_key = txtpublic_key.Text.Trim();
                alipay.sign_type = "MD5";
                alipay.wid = weixin.id;
                alipay.createDate = DateTime.Now;
                aliBll.Add(alipay);
            }
            else if (_id==3)
            {
                //微支付
                BLL.wx_payment_wxpay wxpayBll = new BLL.wx_payment_wxpay();
                Model.wx_payment_wxpay wxpay = new Model.wx_payment_wxpay();
                wxpay.wid = weixin.id;

                //财付通--相关信息
                wxpay.partnerId = txtpartnerId.Text.Trim();
                wxpay.partnerKey = txtpartnerKey.Text.Trim();
                wxpay.CertInfoPath = txtCertInfoPath.Text.Trim();
                wxpay.partnerPwd = txtPartnerPwd.Text.Trim();

                //微信--相关配置
                wxpay.paySignKey = txtpaySignKey.Text.Trim();
                wxpay.appId = txtAppId.Text.Trim();
                wxpay.quicklyFH = rblQuicklyFH.SelectedItem.Value == "1" ? true : false;
                wxpay.createDate = DateTime.Now;
                wxpayBll.Add(wxpay);
            }
            

            if (bll.Add(model)>0)
            {
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "添加支付方式:" + model.title); //记录日志
                result = true;
            }

            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("order_payment", MXEnums.ActionEnum.Add.ToString()); //检查权限
            if (!DoAdd(this.id))
            {
                JscriptMsg("保存过程中发生错误！", "", "Error");
                return;
            }
            JscriptMsg("修改配置成功！", "payment_list.aspx", "Success");
        }
    }
}