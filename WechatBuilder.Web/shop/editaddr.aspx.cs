using WechatBuilder.Templates;
using System;
using System.Collections.Generic;
using WechatBuilder.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.shop
{
    public partial class editaddr : ShopBasePage
    {
        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (errInitTemplates != "")
            {
                Response.Write(errInitTemplates);
                return;
            }

            //1获得模版基本信息
            BLL.wx_module_templates tBll = new BLL.wx_module_templates();
            templateFileName = tBll.GetTemplatesFileNameByWid("shop", wid);
            if (templateFileName == null || templateFileName.Trim() == "")
            {
                errInitTemplates = "不存在该帐号或者该帐号尚未设置模版！";
                Response.Write(errInitTemplates);
                Response.End();
                return;
            }
            string _action = MyCommFun.QueryString("myact");
            if (_action == "editAddr")
            {
                EditAddr();
            }
            serverPath = MyCommFun.GetRootPath() + "/shop/templates/" + templateFileName + "/editaddr.html";
            ShopTemplateMgr template = new ShopTemplateMgr("/shop/templates/" + templateFileName, serverPath, wid);
            template.tType = TemplateType.editaddr;
            template.openid = MyCommFun.RequestOpenid();
            template.OutPutHtml(wid);
        }

        private void EditAddr()
        {

            string openid = MyCommFun.RequestOpenid();  //得到微信用户的openid
            string name = MyCommFun.QueryString("name");
            int wid = MyCommFun.RequestInt("wid");
            string sprovince = MyCommFun.QueryString("pvid");
            string scity = MyCommFun.QueryString("ctid");
            string regionId = MyCommFun.QueryString("regionId");
            string address = MyCommFun.QueryString("address");
            string mobile = MyCommFun.QueryString("mobile");
            BLL.wx_shop_user_addr addrBll = new BLL.wx_shop_user_addr();
            List<WechatBuilder.Model.wx_shop_user_addr> addrlist = addrBll.GetOpenidAddr(openid, wid);
            WechatBuilder.Model.wx_shop_user_addr addr = new Model.wx_shop_user_addr();
            bool isAdd = true;
            if (addrlist == null || addrlist.Count <= 0)
            {
                //添加
                isAdd = true;
            }
            else
            {
                //修改
                addr = addrlist[0];
                isAdd = false;
            }

            addr.addrDetail = address;
            addr.wid = wid;
            addr.openid = openid;
            addr.province = sprovince;
            addr.city = scity;
            addr.area = regionId;
            addr.tel = mobile;
            addr.contractPerson = name;
            addr.createDate = DateTime.Now;

            if (isAdd)
            {
                addrBll.Add(addr);
            }
            else
            {
                addrBll.Update(addr);
            }
            string frompage = MyCommFun.QueryString("frompage");
            if (frompage != "")
            {
                Response.Redirect(frompage + "?wid=" + wid + "&openid=" + openid);
            }
            else
            {
                Response.Redirect("editaddr.aspx?wid=" + wid + "&openid=" + openid);
            }
        }
    }
}