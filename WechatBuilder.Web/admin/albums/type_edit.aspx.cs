using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using WechatBuilder.BLL;

namespace WechatBuilder.Web.admin.albums
{
    public partial class type_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        wx_albums_type tBll = new wx_albums_type();
       
        protected int id=0;//分类id
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
           
            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {
                id = MyCommFun.RequestInt("id");
                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out  id))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!tBll.Exists(id))
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
            Model.wx_albums_type type = tBll.GetModel(id);
            hidid.Value = type.id.ToString();
            txttName.Text = type.typeName.ToString();

            txttContent.Value = type.tContent.ToString();

            txtseq.Text = type.sort_id.Value.ToString();

            //banner图片
            if (type.bannerPic != null && type.bannerPic.Trim() != "/images/noneimg.jpg")
            {
                txtbannerPic.Text = type.bannerPic;
                imgbannerPic.ImageUrl = type.bannerPic;
            }

            //图标
            if (type.typeIco != null && type.typeIco.Trim() != "/images/noneimg.jpg")
            {
                txttypeIco.Text = type.typeIco;
                imgtypeIco.ImageUrl = type.typeIco;
            }

        }

        #endregion



        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            int id = MyCommFun.Str2Int(hidid.Value);
            #region  //先判断
            string strErr = "";
            if (this.txttName.Text.Trim().Length == 0)
            {
                strErr += "分类名称不能为空！";
            }
            //if (this.txtbannerPic.Text.Trim().Length == 0)
            //{
            //    strErr += "头部图片不能为空！";
            //}
            if (this.txttypeIco.Text.Trim().Length == 0)
            {
                strErr += "图标不能为空！";
            }
            if (this.txtseq.Text.Trim().Length == 0)
            {
                strErr += "排序不能为空！";
            }

            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }

            #endregion

            #region 赋值
            Model.wx_albums_type type = new Model.wx_albums_type();

            if (id > 0)
            {
                type = tBll.GetModel(id);
            }

            //string bannerPic = imgbannerPic.ImageUrl;
            //if (txtbannerPic.Text.Trim() != "")
            //{
            //    bannerPic = txtbannerPic.Text.Trim();
            //}
            string bannerPic = txtbannerPic.Text.Trim();
            string typeIco = imgtypeIco.ImageUrl;
            if (txttypeIco.Text.Trim() != "")
            {
                typeIco = txttypeIco.Text.Trim();
            }



            type.typeName = txttName.Text.Trim();
            type.tContent = txttContent.Value.Trim();
            type.bannerPic = bannerPic;
            type.typeIco = typeIco;
            type.sort_id = MyCommFun.Str2Int(txtseq.Text.Trim());


            #endregion

            if (id <= 0)
            {  //新增
                type.wid = weixin.id;
                type.createDate = DateTime.Now;
                //1新增主表
                id = tBll.Add(type);

                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加相册--分类信息，主键为" + id); //记录日志
                JscriptMsg("添加相册--分类信息成功！", "typelist.aspx", "Success");
            }
            else
            {   //修改

                tBll.Update(type);

                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改相册--分类信息，主键为" + id); //记录日志
                JscriptMsg("修改相册--分类信息成功！", "typelist.aspx", "Success");
            }

        }
    }
}