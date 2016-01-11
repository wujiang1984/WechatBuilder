using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using WechatBuilder.BLL;

namespace WechatBuilder.Web.admin.lbs
{
    /// <summary>
    /// 编辑lbs数据
    /// </summary>
    public partial class lbsedit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        wx_lbs_shopInfo lbsBll = new wx_lbs_shopInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {
                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!lbsBll.Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }



        #region 赋值操作=================================
        private void ShowInfo(int id)
        {
            Model.wx_lbs_shopInfo lbsModel = lbsBll.GetModel(id);
            txtshopName.Text = lbsModel.shopName;
            txtTelphone.Text = lbsModel.telphone;
            txtBrief.Text = lbsModel.brief;
            txtImgUrl.Text = lbsModel.shopLogo;
            txtAddr.Text = lbsModel.detailAddr;
            txtLatXPoint.Text = lbsModel.xPoint.Value.ToString();
            txtLngYPoint.Text = lbsModel.yPoint.Value.ToString();
            txtwUrl.Text = lbsModel.wUrl;
            ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'> $(\"#baiduframe\").attr(\"src\", \"MapSelectPoint.aspx?yjindu=" + lbsModel.yPoint.Value.ToString() + "&xweidu=" + lbsModel.xPoint.Value.ToString() + "\");</script>");

           
        }

        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {

            #region 判断
            string strErr = "";
            if (this.txtshopName.Text.Trim().Length == 0)
            {
                strErr += "名称不能为空！";
            }
            if (this.txtLatXPoint.Text.Trim().Length == 0)
            {
                strErr += "经纬度不能为空！";
            }

            if (this.txtLngYPoint.Text.Trim().Length == 0)
            {
                strErr += "经纬度不能为空！";
            }
            if (this.txtTelphone.Text.Trim().Length == 0)
            {
                strErr += "电话不能为空！";
            }

            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");

                return false;
            }
    #endregion


            string shopName = this.txtshopName.Text;
            string telphone = this.txtTelphone.Text;
            string brief = this.txtBrief.Text;
            string shopLogo = this.txtImgUrl.Text;
            string detailAddr = this.txtAddr.Text;
            decimal xPoint = (decimal)MyCommFun.Str2Float(this.txtLatXPoint.Text);
            decimal yPoint = (decimal)MyCommFun.Str2Float(this.txtLngYPoint.Text);
            string wUrl = this.txtwUrl.Text;
            int seq = MyCommFun.Str2Int(txtSortId.Text);


            Model.wx_userweixin weixin = GetWeiXinCode();
            Model.wx_lbs_shopInfo model = new  Model.wx_lbs_shopInfo();
            model.wid = weixin.id;
            model.shopName = shopName;
            model.telphone = telphone;
            model.brief = brief;
            model.shopContent = "";
            model.shopLogo = shopLogo;

            model.detailAddr = detailAddr;
            model.xPoint = xPoint;
            model.yPoint = yPoint;
            model.wUrl = wUrl;
            model.seq = seq;
            model.createDate = DateTime.Now;
            int mid = lbsBll.Add(model);
            this.id = mid;
            if (mid > 0)
            {
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加lbs数据信息成功，主键为:" + model.id ); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            #region 判断
            string strErr = "";
            if (this.txtshopName.Text.Trim().Length == 0)
            {
                strErr += "名称不能为空！";
            }
            if (this.txtLatXPoint.Text.Trim().Length == 0)
            {
                strErr += "经纬度不能为空！";
            }

            if (this.txtLngYPoint.Text.Trim().Length == 0)
            {
                strErr += "经纬度不能为空！";
            }
            if (this.txtTelphone.Text.Trim().Length == 0)
            {
                strErr += "电话不能为空！";
            }

            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");

                return false;
            }
            #endregion

            string shopName = this.txtshopName.Text;
            string telphone = this.txtTelphone.Text;
            string brief = this.txtBrief.Text;
            string shopLogo = this.txtImgUrl.Text;
            string detailAddr = this.txtAddr.Text;
            decimal xPoint = (decimal)MyCommFun.Str2Float(this.txtLatXPoint.Text);
            decimal yPoint = (decimal)MyCommFun.Str2Float(this.txtLngYPoint.Text);
            string wUrl = this.txtwUrl.Text;
            int seq = MyCommFun.Str2Int(txtSortId.Text);

            Model.wx_lbs_shopInfo model = lbsBll.GetModel(_id);
            model.shopName = shopName;
            model.telphone = telphone;
            model.brief = brief;
            model.shopContent = "";
            model.shopLogo = shopLogo;

            model.detailAddr = detailAddr;
            model.xPoint = xPoint;
            model.yPoint = yPoint;
            model.wUrl = wUrl;
            model.seq = seq;
            bool ret = lbsBll.Update(model);

            if (ret)
            {
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改lbs数据信息，主键为:" + model.id); //记录日志
                
                return true;
            }
            return false;
        }
        #endregion




        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
               
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改lbs数据成功！", "lbslist.aspx", "Success");
            }
            else //添加
            {
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }

                JscriptMsg("添加lbs数据成功！", "lbslist.aspx", "Success");
            }
        }
    }
}