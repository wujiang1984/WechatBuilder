using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatBuilder.BLL
{
   public class wx_ucard_fun
    {
        /// <summary>
        ///  获取用户的等级名称
        /// </summary>
        /// <param name="score"></param>
        /// <param name="defaultDegree"></param>
        /// <returns>若没有取到等级，则返回defaultDegree值</returns>
       public  static string userDegree(int sid, int score, string defaultDegree, out int degreeNum)
        {
            degreeNum = 0;
            string jibie = "";
            BLL.wx_ucard_udegree degreeBll = new BLL.wx_ucard_udegree();
            IList<Model.wx_ucard_udegree> degreelist = degreeBll.GetModelList("sid=" + sid);

            IList<Model.wx_ucard_udegree> tmpDegree = (from d in degreelist where d.score_min <= score && d.score_max > score orderby d.degreeNum ascending select d).ToArray<Model.wx_ucard_udegree>();
            if (tmpDegree != null && tmpDegree.Count > 0)
            {
                jibie = tmpDegree[0].callName;
                degreeNum = MyCommFun.Obj2Int(tmpDegree[0].degreeNum);
            }
            if (jibie == "")
            {
                jibie = defaultDegree;
            }
            return jibie;
        }
    }
}
