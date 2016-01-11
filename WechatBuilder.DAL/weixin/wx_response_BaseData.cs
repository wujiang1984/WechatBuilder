using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_response_BaseData
	/// </summary>
	public partial class wx_response_BaseData
	{
		public wx_response_BaseData()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_response_BaseData"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_response_BaseData");
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
		public int Add(WechatBuilder.Model.wx_response_BaseData model)
		{
			StringBuilder strSql=new StringBuilder();
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
		public bool Update(WechatBuilder.Model.wx_response_BaseData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_response_BaseData set ");
			strSql.Append("wid=@wid,");
			strSql.Append("wx_openid=@wx_openid,");
			strSql.Append("requestType=@requestType,");
			strSql.Append("requestContent=@requestContent,");
			strSql.Append("responseType=@responseType,");
			strSql.Append("reponseContent=@reponseContent,");
			strSql.Append("createTime=@createTime,");
			strSql.Append("wx_xmlContent=@wx_xmlContent,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("flag=@flag,");
			strSql.Append("rType=@rType,");
			strSql.Append("remark=@remark,");
			strSql.Append("extInt=@extInt,");
			strSql.Append("extStr=@extStr,");
			strSql.Append("extStr2=@extStr2,");
			strSql.Append("extStr3=@extStr3");
			strSql.Append(" where id=@id");
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
					new SqlParameter("@extStr3", SqlDbType.VarChar,2000),
					new SqlParameter("@id", SqlDbType.Int,4)};
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
			parameters[16].Value = model.id;

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
			strSql.Append("delete from wx_response_BaseData ");
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
			strSql.Append("delete from wx_response_BaseData ");
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
		public WechatBuilder.Model.wx_response_BaseData GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,wid,wx_openid,requestType,requestContent,responseType,reponseContent,createTime,wx_xmlContent,createDate,flag,rType,remark,extInt,extStr,extStr2,extStr3 from wx_response_BaseData ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_response_BaseData model=new WechatBuilder.Model.wx_response_BaseData();
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
		public WechatBuilder.Model.wx_response_BaseData DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_response_BaseData model=new WechatBuilder.Model.wx_response_BaseData();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["wid"]!=null && row["wid"].ToString()!="")
				{
					model.wid=int.Parse(row["wid"].ToString());
				}
				if(row["wx_openid"]!=null)
				{
					model.wx_openid=row["wx_openid"].ToString();
				}
				if(row["requestType"]!=null)
				{
					model.requestType=row["requestType"].ToString();
				}
				if(row["requestContent"]!=null)
				{
					model.requestContent=row["requestContent"].ToString();
				}
				if(row["responseType"]!=null)
				{
					model.responseType=row["responseType"].ToString();
				}
				if(row["reponseContent"]!=null)
				{
					model.reponseContent=row["reponseContent"].ToString();
				}
				if(row["createTime"]!=null)
				{
					model.createTime=row["createTime"].ToString();
				}
				if(row["wx_xmlContent"]!=null)
				{
					model.wx_xmlContent=row["wx_xmlContent"].ToString();
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["flag"]!=null && row["flag"].ToString()!="")
				{
					model.flag=int.Parse(row["flag"].ToString());
				}
				if(row["rType"]!=null)
				{
					model.rType=row["rType"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["extInt"]!=null && row["extInt"].ToString()!="")
				{
					model.extInt=int.Parse(row["extInt"].ToString());
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,wid,wx_openid,requestType,requestContent,responseType,reponseContent,createTime,wx_xmlContent,createDate,flag,rType,remark,extInt,extStr,extStr2,extStr3 ");
			strSql.Append(" FROM wx_response_BaseData ");
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
			strSql.Append(" id,wid,wx_openid,requestType,requestContent,responseType,reponseContent,createTime,wx_xmlContent,createDate,flag,rType,remark,extInt,extStr,extStr2,extStr3 ");
			strSql.Append(" FROM wx_response_BaseData ");
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
			strSql.Append("select count(1) FROM wx_response_BaseData ");
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
			strSql.Append(")AS Row, T.*  from wx_response_BaseData T ");
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
			parameters[0].Value = "wx_response_BaseData";
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
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from  wx_response_BaseData ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }


		#endregion  ExtensionMethod
	}
}

