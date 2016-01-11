using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using WechatBuilder.BLL;

namespace WechatBuilder.Web.admin.hunqing
{
    public partial class xitiePhoto : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        wx_xt_photo pBll = new wx_xt_photo();

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            int id = 0;
            
            if (!Page.IsPostBack)
            {
                id = MyCommFun.RequestInt("id");
 
                    ShowInfo(id);
                
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int id)
        {
            hidid.Value = id.ToString();
            IList<Model.wx_xt_photo> plist = pBll.GetModelList("bId="+id);
            rptAlbumList.DataSource = plist;
            rptAlbumList.DataBind();
        }

        #endregion



        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int bid = MyCommFun.Str2Int(hidid.Value);

            string[] albumArr = Request.Form.GetValues("hid_photo_name");
            string[] remarkArr = Request.Form.GetValues("hid_photo_remark");
            pBll.DeleteByBid(bid);
            if (albumArr != null && albumArr.Length > 0)
            {
                if (albumArr.Length > 50)
                {
                    JscriptMsg("不能上传超过50张相片！", "back", "Error");
                    return;
                }
                Model.wx_xt_photo photo = new Model.wx_xt_photo();
                for (int i = 0; i < albumArr.Length; i++)
                {
                    photo = new Model.wx_xt_photo();

                    string[] imgArr = albumArr[i].Split('|');
                    if (imgArr.Length ==3)
                    {
                     
                        photo.bId = bid;
                        photo.pUrl = imgArr[1];
                        photo.remark = remarkArr[i] == null ? "" : remarkArr[i];
                        pBll.Add(photo);
                        
                    }
                }
                
            }

            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "编辑喜帖的相册，喜帖主键为" + bid); //记录日志
            JscriptMsg("编辑喜帖的相册成功！", "xitiePhoto.aspx?id="+bid, "Success");

        }
    }
}