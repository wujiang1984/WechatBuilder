using WechatBuilder.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WechatBuilder.DAL
{
   public  class wxRequestBaseMgr
    {

        ///// <summary>
        ///// 增加一条数据
        ///// </summary>
        //public static int Add(int wid,string msgType, string openid, string createTime, string content, string xmlContent)
        //{
        //    try
        //    {
        //        WechatBuilder.Model.wx_requst_BaseData baseData = new Model.wx_requst_BaseData();
        //        baseData.wid = wid;
        //        baseData.wx_msgType = msgType;
        //        baseData.wx_openid = openid;
        //        baseData.wx_createTime = createTime;
        //        baseData.wx_dataContent = content;
        //        baseData.wx_xmlContent = xmlContent;
        //        baseData.createDate = DateTime.Now;
        //        return wxRequestBaseMgr.Add(baseData);
        //    }
        //    catch (Exception ex)
        //    {
        //        return -1;
        //    }
        //}


        ///// <summary>
        ///// 增加一条数据
        ///// </summary>
        //public static int Add(int wid,string msgType, string openid, string createTime, string content, string url, string eventKey, string xmlContent)
        //{
        //    WechatBuilder.Model.wx_requst_BaseData baseData = new Model.wx_requst_BaseData();
        //    baseData.wid = wid;
        //    baseData.wx_msgType = msgType;
        //    baseData.wx_openid = openid;
        //    baseData.wx_createTime = createTime;
        //    baseData.wx_dataContent = content;
        //    baseData.wx_url = url;
        //    baseData.wx_eventKey = eventKey;
        //    baseData.wx_xmlContent = xmlContent;
        //    baseData.createDate = DateTime.Now;
        //    return wxRequestBaseMgr.Add(baseData);
        //}




        ///// <summary>
        ///// 增加一条数据
        ///// </summary>
        //public static int Add(WechatBuilder.Model.wx_requst_BaseData model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("insert into wx_requst_BaseData(");
        //    strSql.Append("wid,wx_openid,wx_msgType,wx_dataContent,wx_eventKey,wx_createTime,wx_url,wx_url2,wx_xmlContent,createDate,flag,rType,remark,extInt,extStr,extStr2,extStr3)");
        //    strSql.Append(" values (");
        //    strSql.Append("@wid,@wx_openid,@wx_msgType,@wx_dataContent,@wx_eventKey,@wx_createTime,@wx_url,@wx_url2,@wx_xmlContent,@createDate,@flag,@rType,@remark,@extInt,@extStr,@extStr2,@extStr3)");
        //    strSql.Append(";select @@IDENTITY");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@wid", SqlDbType.Int,4),
        //            new SqlParameter("@wx_openid", SqlDbType.VarChar,100),
        //            new SqlParameter("@wx_msgType", SqlDbType.VarChar,100),
        //            new SqlParameter("@wx_dataContent", SqlDbType.VarChar,2000),
        //            new SqlParameter("@wx_eventKey", SqlDbType.VarChar,500),
        //            new SqlParameter("@wx_createTime", SqlDbType.VarChar,40),
        //            new SqlParameter("@wx_url", SqlDbType.VarChar,500),
        //            new SqlParameter("@wx_url2", SqlDbType.VarChar,500),
        //            new SqlParameter("@wx_xmlContent", SqlDbType.VarChar,2000),
        //            new SqlParameter("@createDate", SqlDbType.DateTime),
        //            new SqlParameter("@flag", SqlDbType.Int,4),
        //            new SqlParameter("@rType", SqlDbType.VarChar,70),
        //            new SqlParameter("@remark", SqlDbType.VarChar,500),
        //            new SqlParameter("@extInt", SqlDbType.Int,4),
        //            new SqlParameter("@extStr", SqlDbType.VarChar,200),
        //            new SqlParameter("@extStr2", SqlDbType.VarChar,700),
        //            new SqlParameter("@extStr3", SqlDbType.VarChar,2000)};
        //    parameters[0].Value = model.wid;
        //    parameters[1].Value = model.wx_openid;
        //    parameters[2].Value = model.wx_msgType;
        //    parameters[3].Value = model.wx_dataContent;
        //    parameters[4].Value = model.wx_eventKey;
        //    parameters[5].Value = model.wx_createTime;
        //    parameters[6].Value = model.wx_url;
        //    parameters[7].Value = model.wx_url2;
        //    parameters[8].Value = model.wx_xmlContent;
        //    parameters[9].Value = model.createDate;
        //    parameters[10].Value = model.flag;
        //    parameters[11].Value = model.rType;
        //    parameters[12].Value = model.remark;
        //    parameters[13].Value = model.extInt;
        //    parameters[14].Value = model.extStr;
        //    parameters[15].Value = model.extStr2;
        //    parameters[16].Value = model.extStr3;

        //    object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
        //    if (obj == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return Convert.ToInt32(obj);
        //    }
        //}
    }
}
