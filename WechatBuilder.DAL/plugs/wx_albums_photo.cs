using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_albums_photo
	/// </summary>
	public partial class wx_albums_photo
	{
		public wx_albums_photo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_albums_photo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_albums_photo");
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
		public int Add(WechatBuilder.Model.wx_albums_photo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_albums_photo(");
			strSql.Append("aId,pName,photoPic,pContent,seq,isHidden,createDate,createPerson)");
			strSql.Append(" values (");
			strSql.Append("@aId,@pName,@photoPic,@pContent,@seq,@isHidden,@createDate,@createPerson)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@aId", SqlDbType.Int,4),
					new SqlParameter("@pName", SqlDbType.VarChar,200),
					new SqlParameter("@photoPic", SqlDbType.VarChar,1000),
					new SqlParameter("@pContent", SqlDbType.VarChar,500),
					new SqlParameter("@seq", SqlDbType.Int,4),
					new SqlParameter("@isHidden", SqlDbType.Bit,1),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createPerson", SqlDbType.VarChar,200)};
			parameters[0].Value = model.aId;
			parameters[1].Value = model.pName;
			parameters[2].Value = model.photoPic;
			parameters[3].Value = model.pContent;
			parameters[4].Value = model.seq;
			parameters[5].Value = model.isHidden;
			parameters[6].Value = model.createDate;
			parameters[7].Value = model.createPerson;

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
		public bool Update(WechatBuilder.Model.wx_albums_photo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_albums_photo set ");
			strSql.Append("aId=@aId,");
			strSql.Append("pName=@pName,");
			strSql.Append("photoPic=@photoPic,");
			strSql.Append("pContent=@pContent,");
			strSql.Append("seq=@seq,");
			strSql.Append("isHidden=@isHidden,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("createPerson=@createPerson");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@aId", SqlDbType.Int,4),
					new SqlParameter("@pName", SqlDbType.VarChar,200),
					new SqlParameter("@photoPic", SqlDbType.VarChar,1000),
					new SqlParameter("@pContent", SqlDbType.VarChar,500),
					new SqlParameter("@seq", SqlDbType.Int,4),
					new SqlParameter("@isHidden", SqlDbType.Bit,1),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createPerson", SqlDbType.VarChar,200),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.aId;
			parameters[1].Value = model.pName;
			parameters[2].Value = model.photoPic;
			parameters[3].Value = model.pContent;
			parameters[4].Value = model.seq;
			parameters[5].Value = model.isHidden;
			parameters[6].Value = model.createDate;
			parameters[7].Value = model.createPerson;
			parameters[8].Value = model.id;

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
			strSql.Append("delete from wx_albums_photo ");
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
			strSql.Append("delete from wx_albums_photo ");
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
		public WechatBuilder.Model.wx_albums_photo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,aId,pName,photoPic,pContent,seq,isHidden,createDate,createPerson from wx_albums_photo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_albums_photo model=new WechatBuilder.Model.wx_albums_photo();
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
		public WechatBuilder.Model.wx_albums_photo DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_albums_photo model=new WechatBuilder.Model.wx_albums_photo();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["aId"]!=null && row["aId"].ToString()!="")
				{
					model.aId=int.Parse(row["aId"].ToString());
				}
				if(row["pName"]!=null)
				{
					model.pName=row["pName"].ToString();
				}
				if(row["photoPic"]!=null)
				{
					model.photoPic=row["photoPic"].ToString();
				}
				if(row["pContent"]!=null)
				{
					model.pContent=row["pContent"].ToString();
				}
				if(row["seq"]!=null && row["seq"].ToString()!="")
				{
					model.seq=int.Parse(row["seq"].ToString());
				}
				if(row["isHidden"]!=null && row["isHidden"].ToString()!="")
				{
					if((row["isHidden"].ToString()=="1")||(row["isHidden"].ToString().ToLower()=="true"))
					{
						model.isHidden=true;
					}
					else
					{
						model.isHidden=false;
					}
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["createPerson"]!=null)
				{
					model.createPerson=row["createPerson"].ToString();
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
			strSql.Append("select id,aId,pName,photoPic,pContent,seq,isHidden,createDate,createPerson ");
			strSql.Append(" FROM wx_albums_photo ");
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
			strSql.Append(" id,aId,pName,photoPic,pContent,seq,isHidden,createDate,createPerson ");
			strSql.Append(" FROM wx_albums_photo ");
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
			strSql.Append("select count(1) FROM wx_albums_photo ");
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
			strSql.Append(")AS Row, T.*  from wx_albums_photo T ");
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
			parameters[0].Value = "wx_albums_photo";
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
            strSql.Append(" select  * from wx_albums_photo ");
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

