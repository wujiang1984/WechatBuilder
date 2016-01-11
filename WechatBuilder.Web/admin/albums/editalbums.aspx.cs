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
    public partial class editalbums : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        wx_albums_info alBll = new wx_albums_info();
       
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
                if (!alBll.Exists(id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                TypeBind();
                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(id);
                }
                
            }
        }
      
        /// <summary>
        /// 绑定类别
        /// </summary>
        private void TypeBind()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();

            BLL.wx_albums_type bll = new BLL.wx_albums_type();
            IList<Model.wx_albums_type> dt = bll.GetModelList("wid="+weixin.id+" order by sort_id asc");
          
             this.ddlCategoryId.DataTextField = "typeName";
             this.ddlCategoryId.DataValueField = "id";
             this.ddlCategoryId.DataSource = dt;
             this.ddlCategoryId.DataBind();

        }


       
        private void ShowInfo(int id)
        {
            hidid.Value = id.ToString();
            Model.wx_albums_info albums = alBll.GetModel(id);
            hidid.Value = albums.id.ToString();
            txtaName.Text = albums.aName.ToString();
            txtaContent.Value = albums.aContent;
            txtseq.Text = albums.seq.Value.ToString();
            if (albums.showContent)
            {
                rblshowContent.SelectedValue = "1";
            }
            else
            {
                rblshowContent.SelectedValue = "0";
            }

            if (albums.isHidden)
            {
                rblisHidden.SelectedValue = "1";
            }
            else
            {
                rblisHidden.SelectedValue = "0";
            }


            //封面图片
            if (albums.facePic != null && albums.facePic.Trim() != "/images/noneimg.jpg")
            {
                txtImgUrl.Text = albums.facePic;
                imgfacePicPic.ImageUrl = albums.facePic;
            }
            txtMusic.Text = albums.music;
            radshowType.SelectedValue = albums.showType==null?"1":albums.showType.ToString();
        }

        



        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            int id = MyCommFun.Str2Int(hidid.Value);
            #region  //先判断
            string strErr = "";
            if (this.txtaName.Text.Trim().Length == 0)
            {
                strErr += "相册名称不能为空！";
            }
            
            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }
             
            #endregion

            #region 赋值
            Model.wx_albums_info albums = new Model.wx_albums_info();
          
            if (id > 0)
            {
                albums = alBll.GetModel(id);
            }

            string facePicc = imgfacePicPic.ImageUrl;
            if (txtImgUrl.Text.Trim() != "")
            {
                facePicc = txtImgUrl.Text.Trim();
            }
            albums.aName = txtaName.Text.Trim();
            albums.aContent = txtaContent.Value.Trim();
            albums.showContent = rblshowContent.SelectedItem.Value == "1" ? true : false;
            albums.isHidden = rblisHidden.SelectedItem.Value == "1" ? true : false;
            albums.seq = MyCommFun.Str2Int(txtseq.Text.Trim());
            albums.facePic = facePicc;
            albums.typeId = MyCommFun.Str2Int(ddlCategoryId.SelectedItem.Value);
            albums.music = txtMusic.Text;
            albums.showType =MyCommFun.Str2Int( radshowType.SelectedItem.Value);
            #endregion

            if (id <= 0)
            {  //新增
                albums.wid = weixin.id;
                albums.createDate = DateTime.Now;
                //1新增主表
                id = alBll.Add(albums);

              
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加相册信息，主键为" + id); //记录日志
                JscriptMsg("添加相册信息成功！", "index.aspx", "Success");
            }
            else
            {   //修改
               
                alBll.Update(albums);

                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改相册信息，主键为" + id); //记录日志
                JscriptMsg("修改相册信息成功！", "index.aspx", "Success");
            }

        }


       

    }
}