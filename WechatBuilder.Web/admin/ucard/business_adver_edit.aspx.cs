using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using WechatBuilder.BLL;

namespace WechatBuilder.Web.admin.ucard
{
    public partial class business_adver_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        wx_ucard_adver avderBll = new wx_ucard_adver();
       

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            int id = 0;
            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {

                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out  id))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!avderBll.Exists(id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {

                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(id);
                }

            }
        }



        #region 赋值操作=================================
        private void ShowInfo(int id)
        {
            hidid.Value = id.ToString();
            Model.wx_ucard_adver adver = avderBll.GetModel(id);

            txtadverName.Text = adver.adverName;
            imgbeginPic.ImageUrl = adver.picUrl;
            txtImgUrl.Text = adver.picUrl;
            txtlinkUrl.Text = adver.linkUrl;
            txtSortId.Text = adver.sort_id.Value.ToString();

        }

        #endregion



        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            int id = MyCommFun.Str2Int(hidid.Value);
            #region  //先判断
            string strErr = "";
            if (this.txtadverName.Text.Trim().Length == 0)
            {
                strErr += "广告位名称不能为空！";
            }
            if (this.txtImgUrl.Text.Trim().Length == 0)
            {
                strErr += "广告图片不能为空！";
            }

            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }

            #endregion

          
            Model.wx_ucard_adver adver = new Model.wx_ucard_adver();

            if (id > 0)
            {
                adver = avderBll.GetModel(id);
            }

            adver.adverName = txtadverName.Text.Trim();
            adver.picUrl = txtImgUrl.Text.Trim();
            adver.linkUrl = txtlinkUrl.Text.Trim();
            adver.sort_id =MyCommFun.Obj2Int(txtSortId.Text.Trim());

            if (id <= 0)
            {  //新增
                adver.wid = weixin.id;
                adver.createDate = DateTime.Now;
                //1新增主表
                id = avderBll.Add(adver);
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加会员卡商城头部广告位，主键为" + id); //记录日志
                JscriptMsg("添加会员卡商城头部广告位成功！", "business_adver_list.aspx", "Success");
            }
            else
            {   //修改
                //1修改主表
                avderBll.Update(adver);
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改会员卡商家，主键为" + id); //记录日志
                JscriptMsg("修改会员卡商城头部广告位成功！", "business_adver_list.aspx", "Success");
            }

        }

       
    }
}