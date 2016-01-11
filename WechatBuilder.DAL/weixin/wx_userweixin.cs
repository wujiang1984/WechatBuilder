using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_userweixin
	/// </summary>
	public partial class wx_userweixin
	{
		public wx_userweixin()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_userweixin"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_userweixin");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(WechatBuilder.Model.wx_userweixin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_userweixin(");
			strSql.Append("uId,wxName,wxId,yixinId,weixinCode,wxPwd,headerpic,apiurl,wxToken,wxProvince,wxCity,AppId,AppSecret,Access_Token,openIdStr,createDate,endDate,wenziMaxNum,tuwenMaxNum,yuyinMaxNum,wenziDefineNum,tuwenDefineNum,yuyinDefineNum,requestTTNum,requestUsedNum,smsTTNum,smsUsedNum,isDelete,deleteDate,wxType,remark,seq,extStr,extStr2,extStr3,extInt,extInt2)");
			strSql.Append(" values (");
			strSql.Append("@uId,@wxName,@wxId,@yixinId,@weixinCode,@wxPwd,@headerpic,@apiurl,@wxToken,@wxProvince,@wxCity,@AppId,@AppSecret,@Access_Token,@openIdStr,@createDate,@endDate,@wenziMaxNum,@tuwenMaxNum,@yuyinMaxNum,@wenziDefineNum,@tuwenDefineNum,@yuyinDefineNum,@requestTTNum,@requestUsedNum,@smsTTNum,@smsUsedNum,@isDelete,@deleteDate,@wxType,@remark,@seq,@extStr,@extStr2,@extStr3,@extInt,@extInt2)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@uId", SqlDbType.Int,4),
					new SqlParameter("@wxName", SqlDbType.VarChar,200),
					new SqlParameter("@wxId", SqlDbType.VarChar,100),
					new SqlParameter("@yixinId", SqlDbType.VarChar,100),
					new SqlParameter("@weixinCode", SqlDbType.VarChar,100),
					new SqlParameter("@wxPwd", SqlDbType.VarChar,200),
					new SqlParameter("@headerpic", SqlDbType.VarChar,1000),
					new SqlParameter("@apiurl", SqlDbType.VarChar,1000),
					new SqlParameter("@wxToken", SqlDbType.VarChar,300),
					new SqlParameter("@wxProvince", SqlDbType.VarChar,200),
					new SqlParameter("@wxCity", SqlDbType.VarChar,200),
					new SqlParameter("@AppId", SqlDbType.VarChar,200),
					new SqlParameter("@AppSecret", SqlDbType.VarChar,200),
					new SqlParameter("@Access_Token", SqlDbType.VarChar,200),
					new SqlParameter("@openIdStr", SqlDbType.Text),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@endDate", SqlDbType.DateTime),
					new SqlParameter("@wenziMaxNum", SqlDbType.Int,4),
					new SqlParameter("@tuwenMaxNum", SqlDbType.Int,4),
					new SqlParameter("@yuyinMaxNum", SqlDbType.Int,4),
					new SqlParameter("@wenziDefineNum", SqlDbType.Int,4),
					new SqlParameter("@tuwenDefineNum", SqlDbType.Int,4),
					new SqlParameter("@yuyinDefineNum", SqlDbType.Int,4),
					new SqlParameter("@requestTTNum", SqlDbType.Int,4),
					new SqlParameter("@requestUsedNum", SqlDbType.Int,4),
					new SqlParameter("@smsTTNum", SqlDbType.Int,4),
					new SqlParameter("@smsUsedNum", SqlDbType.Int,4),
					new SqlParameter("@isDelete", SqlDbType.Bit,1),
					new SqlParameter("@deleteDate", SqlDbType.DateTime),
					new SqlParameter("@wxType", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@seq", SqlDbType.Int,4),
					new SqlParameter("@extStr", SqlDbType.VarChar,1000),
					new SqlParameter("@extStr2", SqlDbType.VarChar,1500),
					new SqlParameter("@extStr3", SqlDbType.VarChar,1000),
					new SqlParameter("@extInt", SqlDbType.Int,4),
					new SqlParameter("@extInt2", SqlDbType.Int,4)};
			parameters[0].Value = model.uId;
			parameters[1].Value = model.wxName;
			parameters[2].Value = model.wxId;
			parameters[3].Value = model.yixinId;
			parameters[4].Value = model.weixinCode;
			parameters[5].Value = model.wxPwd;
			parameters[6].Value = model.headerpic;
			parameters[7].Value = model.apiurl;
			parameters[8].Value = model.wxToken;
			parameters[9].Value = model.wxProvince;
			parameters[10].Value = model.wxCity;
			parameters[11].Value = model.AppId;
			parameters[12].Value = model.AppSecret;
			parameters[13].Value = model.Access_Token;
			parameters[14].Value = model.openIdStr;
			parameters[15].Value = model.createDate;
			parameters[16].Value = model.endDate;
			parameters[17].Value = model.wenziMaxNum;
			parameters[18].Value = model.tuwenMaxNum;
			parameters[19].Value = model.yuyinMaxNum;
			parameters[20].Value = model.wenziDefineNum;
			parameters[21].Value = model.tuwenDefineNum;
			parameters[22].Value = model.yuyinDefineNum;
			parameters[23].Value = model.requestTTNum;
			parameters[24].Value = model.requestUsedNum;
			parameters[25].Value = model.smsTTNum;
			parameters[26].Value = model.smsUsedNum;
			parameters[27].Value = model.isDelete;
			parameters[28].Value = model.deleteDate;
			parameters[29].Value = model.wxType;
			parameters[30].Value = model.remark;
			parameters[31].Value = model.seq;
			parameters[32].Value = model.extStr;
			parameters[33].Value = model.extStr2;
			parameters[34].Value = model.extStr3;
			parameters[35].Value = model.extInt;
			parameters[36].Value = model.extInt2;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WechatBuilder.Model.wx_userweixin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_userweixin set ");
			strSql.Append("uId=@uId,");
			strSql.Append("wxName=@wxName,");
			strSql.Append("wxId=@wxId,");
			strSql.Append("yixinId=@yixinId,");
			strSql.Append("weixinCode=@weixinCode,");
			strSql.Append("wxPwd=@wxPwd,");
			strSql.Append("headerpic=@headerpic,");
			strSql.Append("apiurl=@apiurl,");
			strSql.Append("wxToken=@wxToken,");
			strSql.Append("wxProvince=@wxProvince,");
			strSql.Append("wxCity=@wxCity,");
			strSql.Append("AppId=@AppId,");
			strSql.Append("AppSecret=@AppSecret,");
			strSql.Append("Access_Token=@Access_Token,");
			strSql.Append("openIdStr=@openIdStr,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("endDate=@endDate,");
			strSql.Append("wenziMaxNum=@wenziMaxNum,");
			strSql.Append("tuwenMaxNum=@tuwenMaxNum,");
			strSql.Append("yuyinMaxNum=@yuyinMaxNum,");
			strSql.Append("wenziDefineNum=@wenziDefineNum,");
			strSql.Append("tuwenDefineNum=@tuwenDefineNum,");
			strSql.Append("yuyinDefineNum=@yuyinDefineNum,");
			strSql.Append("requestTTNum=@requestTTNum,");
			strSql.Append("requestUsedNum=@requestUsedNum,");
			strSql.Append("smsTTNum=@smsTTNum,");
			strSql.Append("smsUsedNum=@smsUsedNum,");
			strSql.Append("isDelete=@isDelete,");
			strSql.Append("deleteDate=@deleteDate,");
			strSql.Append("wxType=@wxType,");
			strSql.Append("remark=@remark,");
			strSql.Append("seq=@seq,");
			strSql.Append("extStr=@extStr,");
			strSql.Append("extStr2=@extStr2,");
			strSql.Append("extStr3=@extStr3,");
			strSql.Append("extInt=@extInt,");
			strSql.Append("extInt2=@extInt2");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@uId", SqlDbType.Int,4),
					new SqlParameter("@wxName", SqlDbType.VarChar,200),
					new SqlParameter("@wxId", SqlDbType.VarChar,100),
					new SqlParameter("@yixinId", SqlDbType.VarChar,100),
					new SqlParameter("@weixinCode", SqlDbType.VarChar,100),
					new SqlParameter("@wxPwd", SqlDbType.VarChar,200),
					new SqlParameter("@headerpic", SqlDbType.VarChar,1000),
					new SqlParameter("@apiurl", SqlDbType.VarChar,1000),
					new SqlParameter("@wxToken", SqlDbType.VarChar,300),
					new SqlParameter("@wxProvince", SqlDbType.VarChar,200),
					new SqlParameter("@wxCity", SqlDbType.VarChar,200),
					new SqlParameter("@AppId", SqlDbType.VarChar,200),
					new SqlParameter("@AppSecret", SqlDbType.VarChar,200),
					new SqlParameter("@Access_Token", SqlDbType.VarChar,200),
					new SqlParameter("@openIdStr", SqlDbType.Text),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@endDate", SqlDbType.DateTime),
					new SqlParameter("@wenziMaxNum", SqlDbType.Int,4),
					new SqlParameter("@tuwenMaxNum", SqlDbType.Int,4),
					new SqlParameter("@yuyinMaxNum", SqlDbType.Int,4),
					new SqlParameter("@wenziDefineNum", SqlDbType.Int,4),
					new SqlParameter("@tuwenDefineNum", SqlDbType.Int,4),
					new SqlParameter("@yuyinDefineNum", SqlDbType.Int,4),
					new SqlParameter("@requestTTNum", SqlDbType.Int,4),
					new SqlParameter("@requestUsedNum", SqlDbType.Int,4),
					new SqlParameter("@smsTTNum", SqlDbType.Int,4),
					new SqlParameter("@smsUsedNum", SqlDbType.Int,4),
					new SqlParameter("@isDelete", SqlDbType.Bit,1),
					new SqlParameter("@deleteDate", SqlDbType.DateTime),
					new SqlParameter("@wxType", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@seq", SqlDbType.Int,4),
					new SqlParameter("@extStr", SqlDbType.VarChar,1000),
					new SqlParameter("@extStr2", SqlDbType.VarChar,1500),
					new SqlParameter("@extStr3", SqlDbType.VarChar,1000),
					new SqlParameter("@extInt", SqlDbType.Int,4),
					new SqlParameter("@extInt2", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.uId;
			parameters[1].Value = model.wxName;
			parameters[2].Value = model.wxId;
			parameters[3].Value = model.yixinId;
			parameters[4].Value = model.weixinCode;
			parameters[5].Value = model.wxPwd;
			parameters[6].Value = model.headerpic;
			parameters[7].Value = model.apiurl;
			parameters[8].Value = model.wxToken;
			parameters[9].Value = model.wxProvince;
			parameters[10].Value = model.wxCity;
			parameters[11].Value = model.AppId;
			parameters[12].Value = model.AppSecret;
			parameters[13].Value = model.Access_Token;
			parameters[14].Value = model.openIdStr;
			parameters[15].Value = model.createDate;
			parameters[16].Value = model.endDate;
			parameters[17].Value = model.wenziMaxNum;
			parameters[18].Value = model.tuwenMaxNum;
			parameters[19].Value = model.yuyinMaxNum;
			parameters[20].Value = model.wenziDefineNum;
			parameters[21].Value = model.tuwenDefineNum;
			parameters[22].Value = model.yuyinDefineNum;
			parameters[23].Value = model.requestTTNum;
			parameters[24].Value = model.requestUsedNum;
			parameters[25].Value = model.smsTTNum;
			parameters[26].Value = model.smsUsedNum;
			parameters[27].Value = model.isDelete;
			parameters[28].Value = model.deleteDate;
			parameters[29].Value = model.wxType;
			parameters[30].Value = model.remark;
			parameters[31].Value = model.seq;
			parameters[32].Value = model.extStr;
			parameters[33].Value = model.extStr2;
			parameters[34].Value = model.extStr3;
			parameters[35].Value = model.extInt;
			parameters[36].Value = model.extInt2;
			parameters[37].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wx_userweixin ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wx_userweixin ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WechatBuilder.Model.wx_userweixin GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,uId,wxName,wxId,yixinId,weixinCode,wxPwd,headerpic,apiurl,wxToken,wxProvince,wxCity,AppId,AppSecret,Access_Token,openIdStr,createDate,endDate,wenziMaxNum,tuwenMaxNum,yuyinMaxNum,wenziDefineNum,tuwenDefineNum,yuyinDefineNum,requestTTNum,requestUsedNum,smsTTNum,smsUsedNum,isDelete,deleteDate,wxType,remark,seq,extStr,extStr2,extStr3,extInt,extInt2 from wx_userweixin ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_userweixin model=new WechatBuilder.Model.wx_userweixin();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WechatBuilder.Model.wx_userweixin DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_userweixin model=new WechatBuilder.Model.wx_userweixin();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["uId"]!=null && row["uId"].ToString()!="")
				{
					model.uId=int.Parse(row["uId"].ToString());
				}
				if(row["wxName"]!=null)
				{
					model.wxName=row["wxName"].ToString();
				}
				if(row["wxId"]!=null)
				{
					model.wxId=row["wxId"].ToString();
				}
				if(row["yixinId"]!=null)
				{
					model.yixinId=row["yixinId"].ToString();
				}
				if(row["weixinCode"]!=null)
				{
					model.weixinCode=row["weixinCode"].ToString();
				}
				if(row["wxPwd"]!=null)
				{
					model.wxPwd=row["wxPwd"].ToString();
				}
				if(row["headerpic"]!=null)
				{
					model.headerpic=row["headerpic"].ToString();
				}
				if(row["apiurl"]!=null)
				{
					model.apiurl=row["apiurl"].ToString();
				}
				if(row["wxToken"]!=null)
				{
					model.wxToken=row["wxToken"].ToString();
				}
				if(row["wxProvince"]!=null)
				{
					model.wxProvince=row["wxProvince"].ToString();
				}
				if(row["wxCity"]!=null)
				{
					model.wxCity=row["wxCity"].ToString();
				}
				if(row["AppId"]!=null)
				{
					model.AppId=row["AppId"].ToString();
				}
				if(row["AppSecret"]!=null)
				{
					model.AppSecret=row["AppSecret"].ToString();
				}
				if(row["Access_Token"]!=null)
				{
					model.Access_Token=row["Access_Token"].ToString();
				}
				if(row["openIdStr"]!=null)
				{
					model.openIdStr=row["openIdStr"].ToString();
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["endDate"]!=null && row["endDate"].ToString()!="")
				{
					model.endDate=DateTime.Parse(row["endDate"].ToString());
				}
				if(row["wenziMaxNum"]!=null && row["wenziMaxNum"].ToString()!="")
				{
					model.wenziMaxNum=int.Parse(row["wenziMaxNum"].ToString());
				}
				if(row["tuwenMaxNum"]!=null && row["tuwenMaxNum"].ToString()!="")
				{
					model.tuwenMaxNum=int.Parse(row["tuwenMaxNum"].ToString());
				}
				if(row["yuyinMaxNum"]!=null && row["yuyinMaxNum"].ToString()!="")
				{
					model.yuyinMaxNum=int.Parse(row["yuyinMaxNum"].ToString());
				}
				if(row["wenziDefineNum"]!=null && row["wenziDefineNum"].ToString()!="")
				{
					model.wenziDefineNum=int.Parse(row["wenziDefineNum"].ToString());
				}
				if(row["tuwenDefineNum"]!=null && row["tuwenDefineNum"].ToString()!="")
				{
					model.tuwenDefineNum=int.Parse(row["tuwenDefineNum"].ToString());
				}
				if(row["yuyinDefineNum"]!=null && row["yuyinDefineNum"].ToString()!="")
				{
					model.yuyinDefineNum=int.Parse(row["yuyinDefineNum"].ToString());
				}
				if(row["requestTTNum"]!=null && row["requestTTNum"].ToString()!="")
				{
					model.requestTTNum=int.Parse(row["requestTTNum"].ToString());
				}
				if(row["requestUsedNum"]!=null && row["requestUsedNum"].ToString()!="")
				{
					model.requestUsedNum=int.Parse(row["requestUsedNum"].ToString());
				}
				if(row["smsTTNum"]!=null && row["smsTTNum"].ToString()!="")
				{
					model.smsTTNum=int.Parse(row["smsTTNum"].ToString());
				}
				if(row["smsUsedNum"]!=null && row["smsUsedNum"].ToString()!="")
				{
					model.smsUsedNum=int.Parse(row["smsUsedNum"].ToString());
				}
				if(row["isDelete"]!=null && row["isDelete"].ToString()!="")
				{
					if((row["isDelete"].ToString()=="1")||(row["isDelete"].ToString().ToLower()=="true"))
					{
						model.isDelete=true;
					}
					else
					{
						model.isDelete=false;
					}
				}
				if(row["deleteDate"]!=null && row["deleteDate"].ToString()!="")
				{
					model.deleteDate=DateTime.Parse(row["deleteDate"].ToString());
				}
				if(row["wxType"]!=null && row["wxType"].ToString()!="")
				{
					model.wxType=int.Parse(row["wxType"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["seq"]!=null && row["seq"].ToString()!="")
				{
					model.seq=int.Parse(row["seq"].ToString());
				}
				if(row["extStr"]!=null)
				{
					model.extStr=row["extStr"].ToString();
				}
				if(row["extStr2"]!=null)
				{
					model.extStr2=row["extStr2"].ToString();
				}
				if(row["extStr3"]!=null)
				{
					model.extStr3=row["extStr3"].ToString();
				}
				if(row["extInt"]!=null && row["extInt"].ToString()!="")
				{
					model.extInt=int.Parse(row["extInt"].ToString());
				}
				if(row["extInt2"]!=null && row["extInt2"].ToString()!="")
				{
					model.extInt2=int.Parse(row["extInt2"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,uId,wxName,wxId,yixinId,weixinCode,wxPwd,headerpic,apiurl,wxToken,wxProvince,wxCity,AppId,AppSecret,Access_Token,openIdStr,createDate,endDate,wenziMaxNum,tuwenMaxNum,yuyinMaxNum,wenziDefineNum,tuwenDefineNum,yuyinDefineNum,requestTTNum,requestUsedNum,smsTTNum,smsUsedNum,isDelete,deleteDate,wxType,remark,seq,extStr,extStr2,extStr3,extInt,extInt2 ");
			strSql.Append(" FROM wx_userweixin ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,uId,wxName,wxId,yixinId,weixinCode,wxPwd,headerpic,apiurl,wxToken,wxProvince,wxCity,AppId,AppSecret,Access_Token,openIdStr,createDate,endDate,wenziMaxNum,tuwenMaxNum,yuyinMaxNum,wenziDefineNum,tuwenDefineNum,yuyinDefineNum,requestTTNum,requestUsedNum,smsTTNum,smsUsedNum,isDelete,deleteDate,wxType,remark,seq,extStr,extStr2,extStr3,extInt,extInt2 ");
			strSql.Append(" FROM wx_userweixin ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM wx_userweixin ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from wx_userweixin T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "wx_userweixin";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

        /// <summary>
        /// 删除一条数据，假删除
        /// </summary>
        public bool DeleteWeixin(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update    wx_userweixin set  isDelete=1 ,deleteDate='" + DateTime.Now + "'");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM  wx_userweixin");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }


        /// <summary>
        /// 获得用户的微信帐号信息【查询分页数据】
        /// </summary>
        public DataSet GetUserWeiXinList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select w.id,w.uId,w.wxName,w.wxId,w.weixinCode,w.headerpic,w.createDate,w.endDate,w.isDelete,w.deleteDate,w.seq,m.role_id,
m.user_name,m.real_name,m.is_lock from wx_userweixin w left join dt_manager m on w.uId=m.id where w.isDelete=0  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
           
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public string GetWeiXinToken(int id)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select  top 1 wxToken  from wx_userweixin ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj!=null)
            {
                return obj.ToString();
            }
            else
            {
                return "";
            }

           
        }

        /// <summary>
        /// 取该用户已经有的微信个数
        /// </summary>
        public int GetUserWxNumCount(int uId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM wx_userweixin where uId=" + uId + " and isDelete=0");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }


        /// <summary>
        /// 判断该微帐号与原始Id号是否一致，如果不一致，则返回false，如果一致则返回true
        /// </summary>
        public bool ExistsWidAndWxId(int id,string wxId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_userweixin");
            strSql.Append(" where id=@id and wxId=@wxId");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@wxId", SqlDbType.VarChar,100)
			};
            parameters[0].Value = id;
            parameters[1].Value = wxId;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


		#endregion  ExtensionMethod
	}
}

