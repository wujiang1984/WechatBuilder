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
    public partial class editPhoto : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        wx_albums_photo pBll = new wx_albums_photo();
        protected int aid;
        protected int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            aid = MyCommFun.RequestInt("aid");
           

            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {
                id = MyCommFun.RequestInt("id");
                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out  id))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!pBll.Exists(id))
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
            Model.wx_albums_photo photo = pBll.GetModel(id);
            hidid.Value = photo.id.ToString();
            txtpName.Text = photo.pName.ToString();
            txtpContent.Value = photo.pContent.ToString();

            txtseq.Text = photo.seq.Value.ToString();
            
            if (photo.isHidden)
            {
                rblisHidden.SelectedValue = "0";
            }
            else
            {
                rblisHidden.SelectedValue = "1";
            }


            //封面图片
            if (photo.photoPic != null && photo.photoPic.Trim() != "/images/noneimg.jpg")
            {
                txtImgUrl.Text = photo.photoPic;
                imgfacePicPic.ImageUrl = photo.photoPic;
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
            if (this.txtpName.Text.Trim().Length == 0)
            {
                strErr += "图片名称不能为空！";
            }
            if (this.txtImgUrl.Text.Trim().Length == 0)
            {
                strErr += "图片不能为空！";
            }

            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }

            #endregion

            #region 赋值
            Model.wx_albums_photo photo = new Model.wx_albums_photo();

            if (id > 0)
            {
                photo = pBll.GetModel(id);
            }

            string facePicc = imgfacePicPic.ImageUrl;
            if (txtImgUrl.Text.Trim() != "")
            {
                facePicc = txtImgUrl.Text.Trim();
            }
            photo.pName = txtpName.Text.Trim();
            photo.pContent = txtpContent.Value.Trim();
            photo.photoPic = facePicc;
            photo.isHidden = rblisHidden.SelectedItem.Value == "0" ? true : false;
            photo.seq = MyCommFun.Str2Int(txtseq.Text.Trim());
          

            #endregion

            if (id <= 0)
            {  //新增
                photo.aId = aid;
                photo.createDate = DateTime.Now;
                //1新增主表
                id = pBll.Add(photo);

                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加相册--图片信息，主键为" + id); //记录日志
                JscriptMsg("添加相册--图片信息成功！", "photolist.aspx?id="+aid, "Success");
            }
            else
            {   //修改

                pBll.Update(photo);

                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改相册--图片信息，主键为" + id); //记录日志
                JscriptMsg("修改相册--图片信息成功！", "photolist.aspx?id="+aid, "Success");
            }

        }
    }
}