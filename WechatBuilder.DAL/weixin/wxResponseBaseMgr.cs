using WechatBuilder.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WechatBuilder.DAL
{
   public   class wxResponseBaseMgr
    {

       /// <summary>
       /// 将用户请求的数据和系统回复的数据保存到数据库，数据落地
       /// </summary>
       /// <param name="wid">微帐号主键Id，apiid</param>
       /// <param name="openid">请求的用户openid</param>
        /// <param name="requestType">用户请求的类型：文本消息：text 图片消息:image 地理位置消息:location 链接消息:link 事件:event</param>
        /// <param name="requestContent">用户请求的数据内容</param>
        /// <param name="responseType"> 系统回复的类型：文本消息：text ,图文消息:txtpic ,语音music, 地理位置消息:location 链接消息:link,未取到数据none</param>
        /// <param name="responseContent">系统回复的内容</param>
        /// <param name="ToUserName">由于取不到xml内容，我们将toUserName存入</param>
       /// <returns></returns>
       public static int Add(int wid, string openid, string requestType, string requestContent, string responseType, string responseContent, string ToUserName)
       {
           int ret = 0;
           try
           {
               WechatBuilder.Model.wx_response_BaseData model = new Model.wx_response_BaseData();
               model.wid = wid;
               model.wx_openid = openid;
               model.requestType = requestType;
               model.requestContent = requestContent;
               model.responseType = responseType;
               model.reponseContent = responseContent;
               model.wx_xmlContent = ToUserName;
               model.createDate = DateTime.Now;
               ret = Add(model);

           }
           catch (Exception ex)
           {
               ret = 0;
           }
          
          
           return ret;
       }

       

       /// <summary>
       /// 增加一条数据
       /// </summary>
       public static  int Add(WechatBuilder.Model.wx_response_BaseData model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into wx_response_BaseData(");
           strSql.Append("wid,wx_openid,requestType,requestContent,responseType,reponseContent,createTime,wx_xmlContent,createDate,flag,rType,remark,extInt,extStr,extStr2,extStr3)");
           strSql.Append(" values (");
           strSql.Append("@wid,@wx_openid,@requestType,@requestContent,@responseType,@reponseContent,@createTime,@wx_xmlContent,@createDate,@flag,@rType,@remark,@extInt,@extStr,@extStr2,@extStr3)");
           strSql.Append(";select @@IDENTITY");
           SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@wx_openid", SqlDbType.VarChar,100),
					new SqlParameter("@requestType", SqlDbType.VarChar,50),
					new SqlParameter("@requestContent", SqlDbType.VarChar,2000),
					new SqlParameter("@responseType", SqlDbType.VarChar,50),
					new SqlParameter("@reponseContent", SqlDbType.VarChar,2000),
					new SqlParameter("@createTime", SqlDbType.VarChar,40),
					new SqlParameter("@wx_xmlContent", SqlDbType.VarChar,2000),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@flag", SqlDbType.Int,4),
					new SqlParameter("@rType", SqlDbType.VarChar,70),
					new SqlParameter("@remark", SqlDbType.VarChar,500),
					new SqlParameter("@extInt", SqlDbType.Int,4),
					new SqlParameter("@extStr", SqlDbType.VarChar,200),
					new SqlParameter("@extStr2", SqlDbType.VarChar,700),
					new SqlParameter("@extStr3", SqlDbType.VarChar,2000)};
           parameters[0].Value = model.wid;
           parameters[1].Value = model.wx_openid;
           parameters[2].Value = model.requestType;
           parameters[3].Value = model.requestContent;
           parameters[4].Value = model.responseType;
           parameters[5].Value = model.reponseContent;
           parameters[6].Value = model.createTime;
           parameters[7].Value = model.wx_xmlContent;
           parameters[8].Value = model.createDate;
           parameters[9].Value = model.flag;
           parameters[10].Value = model.rType;
           parameters[11].Value = model.remark;
           parameters[12].Value = model.extInt;
           parameters[13].Value = model.extStr;
           parameters[14].Value = model.extStr2;
           parameters[15].Value = model.extStr3;

           object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
           if (obj == null)
           {
               return 0;
           }
           else
           {
               return Convert.ToInt32(obj);
           }
       }


    }
}
