using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_sysConfig
	/// </summary>
	public partial class wx_sysConfig
	{
		public wx_sysConfig()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_sysConfig"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_sysConfig");
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
		public int Add(WechatBuilder.Model.wx_sysConfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_sysConfig(");
			strSql.Append("sysCode,sysName,sysValue,sysTypeId,sysTypeName,createDate,parentId,remark,sort_id)");
			strSql.Append(" values (");
			strSql.Append("@sysCode,@sysName,@sysValue,@sysTypeId,@sysTypeName,@createDate,@parentId,@remark,@sort_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@sysCode", SqlDbType.VarChar,50),
					new SqlParameter("@sysName", SqlDbType.VarChar,100),
					new SqlParameter("@sysValue", SqlDbType.VarChar,500),
					new SqlParameter("@sysTypeId", SqlDbType.Int,4),
					new SqlParameter("@sysTypeName", SqlDbType.VarChar,50),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@parentId", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,500),
					new SqlParameter("@sort_id", SqlDbType.Int,4)};
			parameters[0].Value = model.sysCode;
			parameters[1].Value = model.sysName;
			parameters[2].Value = model.sysValue;
			parameters[3].Value = model.sysTypeId;
			parameters[4].Value = model.sysTypeName;
			parameters[5].Value = model.createDate;
			parameters[6].Value = model.parentId;
			parameters[7].Value = model.remark;
			parameters[8].Value = model.sort_id;

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
		public bool Update(WechatBuilder.Model.wx_sysConfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_sysConfig set ");
			strSql.Append("sysCode=@sysCode,");
			strSql.Append("sysName=@sysName,");
			strSql.Append("sysValue=@sysValue,");
			strSql.Append("sysTypeId=@sysTypeId,");
			strSql.Append("sysTypeName=@sysTypeName,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("parentId=@parentId,");
			strSql.Append("remark=@remark,");
			strSql.Append("sort_id=@sort_id");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@sysCode", SqlDbType.VarChar,50),
					new SqlParameter("@sysName", SqlDbType.VarChar,100),
					new SqlParameter("@sysValue", SqlDbType.VarChar,500),
					new SqlParameter("@sysTypeId", SqlDbType.Int,4),
					new SqlParameter("@sysTypeName", SqlDbType.VarChar,50),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@parentId", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,500),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.sysCode;
			parameters[1].Value = model.sysName;
			parameters[2].Value = model.sysValue;
			parameters[3].Value = model.sysTypeId;
			parameters[4].Value = model.sysTypeName;
			parameters[5].Value = model.createDate;
			parameters[6].Value = model.parentId;
			parameters[7].Value = model.remark;
			parameters[8].Value = model.sort_id;
			parameters[9].Value = model.id;

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
			strSql.Append("delete from wx_sysConfig ");
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
			strSql.Append("delete from wx_sysConfig ");
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
		public WechatBuilder.Model.wx_sysConfig GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sysCode,sysName,sysValue,sysTypeId,sysTypeName,createDate,parentId,remark,sort_id from wx_sysConfig ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_sysConfig model=new WechatBuilder.Model.wx_sysConfig();
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
		public WechatBuilder.Model.wx_sysConfig DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_sysConfig model=new WechatBuilder.Model.wx_sysConfig();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["sysCode"]!=null)
				{
					model.sysCode=row["sysCode"].ToString();
				}
				if(row["sysName"]!=null)
				{
					model.sysName=row["sysName"].ToString();
				}
				if(row["sysValue"]!=null)
				{
					model.sysValue=row["sysValue"].ToString();
				}
				if(row["sysTypeId"]!=null && row["sysTypeId"].ToString()!="")
				{
					model.sysTypeId=int.Parse(row["sysTypeId"].ToString());
				}
				if(row["sysTypeName"]!=null)
				{
					model.sysTypeName=row["sysTypeName"].ToString();
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["parentId"]!=null && row["parentId"].ToString()!="")
				{
					model.parentId=int.Parse(row["parentId"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["sort_id"]!=null && row["sort_id"].ToString()!="")
				{
					model.sort_id=int.Parse(row["sort_id"].ToString());
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
			strSql.Append("select id,sysCode,sysName,sysValue,sysTypeId,sysTypeName,createDate,parentId,remark,sort_id ");
			strSql.Append(" FROM wx_sysConfig ");
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
			strSql.Append(" id,sysCode,sysName,sysValue,sysTypeId,sysTypeName,createDate,parentId,remark,sort_id ");
			strSql.Append(" FROM wx_sysConfig ");
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
			strSql.Append("select count(1) FROM wx_sysConfig ");
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
			strSql.Append(")AS Row, T.*  from wx_sysConfig T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		#endregion  BasicMethod
		#region  ExtensionMethod

        /// <summary>
        /// 通过配置节点编码找对应的值
        /// </summary>
        public static  string GetConfigValue(string sysCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 sysValue from  wx_sysConfig where sysCode=@sysCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@sysCode", SqlDbType.VarChar,50)
			};
            parameters[0].Value = sysCode;

            SqlDataReader sr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters);
            string ret = "";
            while (sr.Read())
            {
                ret = sr["sysValue"].ToString();
            }
            sr.Close();

            return ret;
        }

        /// <summary>
        /// 修改值
        /// </summary>
        /// <param name="sysCode"></param>
        /// <param name="sysValue"></param>
        /// <returns></returns>
        public static bool EditSysValue(string sysCode,string sysValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_sysConfig set  sysValue=@sysValue where sysCode=@sysCode");
            SqlParameter[] parameters = {
					new SqlParameter("@sysValue", SqlDbType.VarChar,500),
                    new SqlParameter("@sysCode", SqlDbType.VarChar,50)};

            parameters[0].Value = sysValue;
            parameters[1].Value = sysCode;

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

		#endregion  ExtensionMethod
	}
}

