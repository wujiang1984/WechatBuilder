using WechatBuilder.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatBuilder.BLL
{
   public   class wsiteBll
    {
       templatesDal dal = new templatesDal();

       public  Model.wxcodeconfig GetModelByWid(int wid, string templateskin)
       {
          return  dal.GetModelByWid(wid, templateskin);
       }
    }
}
