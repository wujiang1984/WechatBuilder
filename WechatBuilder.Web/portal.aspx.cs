using WechatBuilder.Common;
using WechatBuilder.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web
{
    public partial class portal : PortalBasePage
    {
        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (errInitTemplates != "")
            {
                Response.Write(errInitTemplates);
                return;
            }


            tPath = MyCommFun.GetRootPath() + "/templates_portal/index.html";
            PortalTemplate template = new PortalTemplate(tPath);
            template.tType = TemplateType.Index;
           
            template.OutPutHtml(templateIndexFileName);
        }
    }
}