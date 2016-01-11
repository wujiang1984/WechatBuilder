using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_diancai_dianyuan
	/// </summary>
	public partial class wx_diancai_dianyuan
	{
		public wx_diancai_dianyuan()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_diancai_dianyuan"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_diancai_dianyuan");
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
		public int Add(WechatBuilder.Model.wx_diancai_dianyuan model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_diancai_dianyuan(");
			strSql.Append("shopid,createDate,bianhao,dianyuanName,dianyuanTel,userName,pwd,userStatus,fendian,beginTime,endTime,remark)");
			strSql.Append(" values (");
			strSql.Append("@shopid,@createDate,@bianhao,@dianyuanName,@dianyuanTel,@userName,@pwd,@userStatus,@fendian,@beginTime,@endTime,@remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@shopid", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@bianhao", SqlDbType.VarChar,100),
					new SqlParameter("@dianyuanName", SqlDbType.VarChar,100),
					new SqlParameter("@dianyuanTel", SqlDbType.VarChar,100),
					new SqlParameter("@userName", SqlDbType.VarChar,100),
					new SqlParameter("@pwd", SqlDbType.VarChar,100),
					new SqlParameter("@userStatus", SqlDbType.Int,4),
					new SqlParameter("@fendian", SqlDbType.VarChar,100),
					new SqlParameter("@beginTime", SqlDbType.DateTime),
					new SqlParameter("@endTime", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.shopid;
			parameters[1].Value = model.createDate;
			parameters[2].Value = model.bianhao;
			parameters[3].Value = model.dianyuanName;
			parameters[4].Value = model.dianyuanTel;
			parameters[5].Value = model.userName;
			parameters[6].Value = model.pwd;
			parameters[7].Value = model.userStatus;
			parameters[8].Value = model.fendian;
			parameters[9].Value = model.beginTime;
			parameters[10].Value = model.endTime;
			parameters[11].Value = model.remark;

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
		public bool Update(WechatBuilder.Model.wx_diancai_dianyuan model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_diancai_dianyuan set ");
			strSql.Append("shopid=@shopid,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("bianhao=@bianhao,");
			strSql.Append("dianyuanName=@dianyuanName,");
			strSql.Append("dianyuanTel=@dianyuanTel,");
			strSql.Append("userName=@userName,");
			strSql.Append("pwd=@pwd,");
			strSql.Append("userStatus=@userStatus,");
			strSql.Append("fendian=@fendian,");
			strSql.Append("beginTime=@beginTime,");
			strSql.Append("endTime=@endTime,");
			strSql.Append("remark=@remark");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@shopid", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@bianhao", SqlDbType.VarChar,100),
					new SqlParameter("@dianyuanName", SqlDbType.VarChar,100),
					new SqlParameter("@dianyuanTel", SqlDbType.VarChar,100),
					new SqlParameter("@userName", SqlDbType.VarChar,100),
					new SqlParameter("@pwd", SqlDbType.VarChar,100),
					new SqlParameter("@userStatus", SqlDbType.Int,4),
					new SqlParameter("@fendian", SqlDbType.VarChar,100),
					new SqlParameter("@beginTime", SqlDbType.DateTime),
					new SqlParameter("@endTime", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.NVarChar,100),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.shopid;
			parameters[1].Value = model.createDate;
			parameters[2].Value = model.bianhao;
			parameters[3].Value = model.dianyuanName;
			parameters[4].Value = model.dianyuanTel;
			parameters[5].Value = model.userName;
			parameters[6].Value = model.pwd;
			parameters[7].Value = model.userStatus;
			parameters[8].Value = model.fendian;
			parameters[9].Value = model.beginTime;
			parameters[10].Value = model.endTime;
			parameters[11].Value = model.remark;
			parameters[12].Value = model.id;

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
			strSql.Append("delete from wx_diancai_dianyuan ");
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
			strSql.Append("delete from wx_diancai_dianyuan ");
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
		public WechatBuilder.Model.wx_diancai_dianyuan GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,shopid,createDate,bianhao,dianyuanName,dianyuanTel,userName,pwd,userStatus,fendian,beginTime,endTime,remark from wx_diancai_dianyuan ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_diancai_dianyuan model=new WechatBuilder.Model.wx_diancai_dianyuan();
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
		public WechatBuilder.Model.wx_diancai_dianyuan DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_diancai_dianyuan model=new WechatBuilder.Model.wx_diancai_dianyuan();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["shopid"]!=null && row["shopid"].ToString()!="")
				{
					model.shopid=int.Parse(row["shopid"].ToString());
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["bianhao"]!=null)
				{
					model.bianhao=row["bianhao"].ToString();
				}
				if(row["dianyuanName"]!=null)
				{
					model.dianyuanName=row["dianyuanName"].ToString();
				}
				if(row["dianyuanTel"]!=null)
				{
					model.dianyuanTel=row["dianyuanTel"].ToString();
				}
				if(row["userName"]!=null)
				{
					model.userName=row["userName"].ToString();
				}
				if(row["pwd"]!=null)
				{
					model.pwd=row["pwd"].ToString();
				}
				if(row["userStatus"]!=null && row["userStatus"].ToString()!="")
				{
					model.userStatus=int.Parse(row["userStatus"].ToString());
				}
				if(row["fendian"]!=null)
				{
					model.fendian=row["fendian"].ToString();
				}
				if(row["beginTime"]!=null && row["beginTime"].ToString()!="")
				{
					model.beginTime=DateTime.Parse(row["beginTime"].ToString());
				}
				if(row["endTime"]!=null && row["endTime"].ToString()!="")
				{
					model.endTime=DateTime.Parse(row["endTime"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
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
			strSql.Append("select id,shopid,createDate,bianhao,dianyuanName,dianyuanTel,userName,pwd,userStatus,fendian,beginTime,endTime,remark ");
			strSql.Append(" FROM wx_diancai_dianyuan ");
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
			strSql.Append(" id,shopid,createDate,bianhao,dianyuanName,dianyuanTel,userName,pwd,userStatus,fendian,beginTime,endTime,remark ");
			strSql.Append(" FROM wx_diancai_dianyuan ");
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
			strSql.Append("select count(1) FROM wx_diancai_dianyuan ");
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
			strSql.Append(")AS Row, T.*  from wx_diancai_dianyuan T ");
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
			parameters[0].Value = "wx_diancai_dianyuan";
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
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,shopid,createDate,bianhao,dianyuanName,dianyuanTel,userName,pwd,userStatus,fendian,beginTime,endTime,remark ");
            strSql.Append(" FROM wx_diancai_dianyuan ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        public bool Exists(string  username,string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_diancai_dianyuan");
            strSql.Append(" where userName='" + username + "' and pwd='" + pwd + "' ");
           

            return DbHelperSQL.Exists(strSql.ToString());
        }
		#endregion  ExtensionMethod
	}
}

