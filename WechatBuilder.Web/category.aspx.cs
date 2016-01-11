using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using WechatBuilder.Templates;

namespace WechatBuilder.Web
{
    public partial class category : TBasePage
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
            BLL.wx_templates tBll = new BLL.wx_templates();
          string   templateErJiFileName = tBll.GetErJiTemplatesFileNameByWid(wid);
          if (templateErJiFileName == null || templateErJiFileName.Trim() == "")
          {
              tPath = MyCommFun.GetRootPath() + "/templates/category/albums/category.html";
          }
          else
          {
              tPath = MyCommFun.GetRootPath() + "/templates/category/" + templateErJiFileName + "/category.html";
          }


           
            TemplateMgr template = new TemplateMgr(tPath, wid);
            template.tType = TemplateType.Channel;
            template.openid = MyCommFun.RequestOpenid();
            template.OutPutHtml(templateErJiFileName, wid);

        }
    }
}