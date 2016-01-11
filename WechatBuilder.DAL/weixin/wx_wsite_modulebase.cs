using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_wsite_modulebase
	/// </summary>
	public partial class wx_wsite_modulebase
	{
		public wx_wsite_modulebase()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_wsite_modulebase"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_wsite_modulebase");
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
		public int Add(WechatBuilder.Model.wx_wsite_modulebase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_wsite_modulebase(");
			strSql.Append("mName,mCode,mValueInt,mValue,mType,mTypeName,picUrl,remark,seq,createDate)");
			strSql.Append(" values (");
			strSql.Append("@mName,@mCode,@mValueInt,@mValue,@mType,@mTypeName,@picUrl,@remark,@seq,@createDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@mName", SqlDbType.VarChar,1000),
					new SqlParameter("@mCode", SqlDbType.VarChar,100),
					new SqlParameter("@mValueInt", SqlDbType.Int,4),
					new SqlParameter("@mValue", SqlDbType.VarChar,2000),
					new SqlParameter("@mType", SqlDbType.VarChar,100),
					new SqlParameter("@mTypeName", SqlDbType.VarChar,150),
					new SqlParameter("@picUrl", SqlDbType.NVarChar,1000),
					new SqlParameter("@remark", SqlDbType.VarChar,1000),
					new SqlParameter("@seq", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime)};
			parameters[0].Value = model.mName;
			parameters[1].Value = model.mCode;
			parameters[2].Value = model.mValueInt;
			parameters[3].Value = model.mValue;
			parameters[4].Value = model.mType;
			parameters[5].Value = model.mTypeName;
			parameters[6].Value = model.picUrl;
			parameters[7].Value = model.remark;
			parameters[8].Value = model.seq;
			parameters[9].Value = model.createDate;

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
		public bool Update(WechatBuilder.Model.wx_wsite_modulebase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_wsite_modulebase set ");
			strSql.Append("mName=@mName,");
			strSql.Append("mCode=@mCode,");
			strSql.Append("mValueInt=@mValueInt,");
			strSql.Append("mValue=@mValue,");
			strSql.Append("mType=@mType,");
			strSql.Append("mTypeName=@mTypeName,");
			strSql.Append("picUrl=@picUrl,");
			strSql.Append("remark=@remark,");
			strSql.Append("seq=@seq,");
			strSql.Append("createDate=@createDate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@mName", SqlDbType.VarChar,1000),
					new SqlParameter("@mCode", SqlDbType.VarChar,100),
					new SqlParameter("@mValueInt", SqlDbType.Int,4),
					new SqlParameter("@mValue", SqlDbType.VarChar,2000),
					new SqlParameter("@mType", SqlDbType.VarChar,100),
					new SqlParameter("@mTypeName", SqlDbType.VarChar,150),
					new SqlParameter("@picUrl", SqlDbType.NVarChar,1000),
					new SqlParameter("@remark", SqlDbType.VarChar,1000),
					new SqlParameter("@seq", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.mName;
			parameters[1].Value = model.mCode;
			parameters[2].Value = model.mValueInt;
			parameters[3].Value = model.mValue;
			parameters[4].Value = model.mType;
			parameters[5].Value = model.mTypeName;
			parameters[6].Value = model.picUrl;
			parameters[7].Value = model.remark;
			parameters[8].Value = model.seq;
			parameters[9].Value = model.createDate;
			parameters[10].Value = model.id;

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
			strSql.Append("delete from wx_wsite_modulebase ");
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
			strSql.Append("delete from wx_wsite_modulebase ");
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
		public WechatBuilder.Model.wx_wsite_modulebase GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,mName,mCode,mValueInt,mValue,mType,mTypeName,picUrl,remark,seq,createDate from wx_wsite_modulebase ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_wsite_modulebase model=new WechatBuilder.Model.wx_wsite_modulebase();
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
		public WechatBuilder.Model.wx_wsite_modulebase DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_wsite_modulebase model=new WechatBuilder.Model.wx_wsite_modulebase();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["mName"]!=null)
				{
					model.mName=row["mName"].ToString();
				}
				if(row["mCode"]!=null)
				{
					model.mCode=row["mCode"].ToString();
				}
				if(row["mValueInt"]!=null && row["mValueInt"].ToString()!="")
				{
					model.mValueInt=int.Parse(row["mValueInt"].ToString());
				}
				if(row["mValue"]!=null)
				{
					model.mValue=row["mValue"].ToString();
				}
				if(row["mType"]!=null)
				{
					model.mType=row["mType"].ToString();
				}
				if(row["mTypeName"]!=null)
				{
					model.mTypeName=row["mTypeName"].ToString();
				}
				if(row["picUrl"]!=null)
				{
					model.picUrl=row["picUrl"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["seq"]!=null && row["seq"].ToString()!="")
				{
					model.seq=int.Parse(row["seq"].ToString());
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
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
			strSql.Append("select id,mName,mCode,mValueInt,mValue,mType,mTypeName,picUrl,remark,seq,createDate ");
			strSql.Append(" FROM wx_wsite_modulebase ");
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
			strSql.Append(" id,mName,mCode,mValueInt,mValue,mType,mTypeName,picUrl,remark,seq,createDate ");
			strSql.Append(" FROM wx_wsite_modulebase ");
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
			strSql.Append("select count(1) FROM wx_wsite_modulebase ");
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
			strSql.Append(")AS Row, T.*  from wx_wsite_modulebase T ");
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
			parameters[0].Value = "wx_wsite_modulebase";
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
        /// 通过主键id获得mValue的值
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string getValuestr(int id)
        {
            string ret="";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select mValue   ");
            strSql.Append(" FROM wx_wsite_modulebase where id=@id");
            SqlParameter[] parameters = {
                         new SqlParameter("@id", SqlDbType.Int)
                                        };
            parameters[0].Value = id;

            SqlDataReader sr = DbHelperSQL.ExecuteReader(strSql.ToString(),parameters);

            while (sr.Read())
            {
                ret = sr["mValue"].ToString();
            }
            sr.Close();


            return ret;
        }

		#endregion  ExtensionMethod
	}
}

