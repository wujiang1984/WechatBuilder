using WechatBuilder.BLL;
using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.admin.albums
{
    public partial class albumsSys : Web.UI.ManagePage
    {
        wx_albums_sys rBll = new wx_albums_sys();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int wid = MyCommFun.RequestInt("wid");
                this.hidwid.Value = wid.ToString();
                if (wid > 0)
                {
                    BindData(wid);
                }

            }
        }
        /// <summary>
        /// 编辑状态：赋值页面上的值
        /// </summary>
        /// <param name="id"></param>
        private void BindData(int wid)
        {
            Model.wx_albums_sys al_Sys = rBll.GetModelByWid(wid);
            if (al_Sys != null)
            {
                hidid.Value = al_Sys.id.ToString();
                //封面图片
                if (al_Sys.bannerPic != null && al_Sys.bannerPic.Trim() != "/images/noneimg.jpg")
                {
                    txtImgUrl.Text = al_Sys.bannerPic;
                    imgfacePicPic.ImageUrl = al_Sys.bannerPic;
                }
            }

        }


        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                string strErr = "";
                if (this.txtImgUrl.Text.Trim().Length == 0)
                {
                    strErr += "图片不能为空！";
                }

                if (strErr != "")
                {
                    JscriptMsg(strErr, "back", "Error");
                    return;
                }

                string facePicc = imgfacePicPic.ImageUrl;
                if (txtImgUrl.Text.Trim() != "")
                {
                    facePicc = txtImgUrl.Text.Trim();
                }
                Model.wx_albums_sys al_Sys = new Model.wx_albums_sys();
                int wid =MyCommFun.Str2Int(hidwid.Value);
                int id = MyCommFun.Str2Int(hidid.Value);
                if (id > 0)
                {
                    //修改
                    al_Sys = rBll.GetModel(id);
                    al_Sys.bannerPic = facePicc;
                    rBll.Update(al_Sys);
                    AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改相册的头部图片，主键为" + id); //记录日志
                }
                else
                {
                    al_Sys.bannerPic = facePicc;
                    al_Sys.wid = wid;
                 int red=   rBll.Add(al_Sys);
                    AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "新增相册的头部图片，主键为"+red); //记录日志
                }
              
               
                MessageBox.ResponseScript(this, " api.close(); ");
            }
            catch
            {
                JscriptMsg("编辑回复规则有问题！", "", "Error");
            }



        }

    }
}