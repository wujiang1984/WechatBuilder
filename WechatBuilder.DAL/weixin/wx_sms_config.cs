using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_sms_config
	/// </summary>
	public partial class wx_sms_config
	{
		public wx_sms_config()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_sms_config"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_sms_config");
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
		public int Add(WechatBuilder.Model.wx_sms_config model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_sms_config(");
			strSql.Append("wid,uName,ucode,pwd,qianming,createDate,remark,sortId)");
			strSql.Append(" values (");
			strSql.Append("@wid,@uName,@ucode,@pwd,@qianming,@createDate,@remark,@sortId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@uName", SqlDbType.VarChar,50),
					new SqlParameter("@ucode", SqlDbType.VarChar,100),
					new SqlParameter("@pwd", SqlDbType.VarChar,50),
					new SqlParameter("@qianming", SqlDbType.VarChar,100),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.VarChar,1000),
					new SqlParameter("@sortId", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.uName;
			parameters[2].Value = model.ucode;
			parameters[3].Value = model.pwd;
			parameters[4].Value = model.qianming;
			parameters[5].Value = model.createDate;
			parameters[6].Value = model.remark;
			parameters[7].Value = model.sortId;

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
		public bool Update(WechatBuilder.Model.wx_sms_config model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_sms_config set ");
			strSql.Append("wid=@wid,");
			strSql.Append("uName=@uName,");
			strSql.Append("ucode=@ucode,");
			strSql.Append("pwd=@pwd,");
			strSql.Append("qianming=@qianming,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("remark=@remark,");
			strSql.Append("sortId=@sortId");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@uName", SqlDbType.VarChar,50),
					new SqlParameter("@ucode", SqlDbType.VarChar,100),
					new SqlParameter("@pwd", SqlDbType.VarChar,50),
					new SqlParameter("@qianming", SqlDbType.VarChar,100),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.VarChar,1000),
					new SqlParameter("@sortId", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.uName;
			parameters[2].Value = model.ucode;
			parameters[3].Value = model.pwd;
			parameters[4].Value = model.qianming;
			parameters[5].Value = model.createDate;
			parameters[6].Value = model.remark;
			parameters[7].Value = model.sortId;
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
			strSql.Append("delete from wx_sms_config ");
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
			strSql.Append("delete from wx_sms_config ");
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
		public WechatBuilder.Model.wx_sms_config GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,wid,uName,ucode,pwd,qianming,createDate,remark,sortId from wx_sms_config ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_sms_config model=new WechatBuilder.Model.wx_sms_config();
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
		public WechatBuilder.Model.wx_sms_config DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_sms_config model=new WechatBuilder.Model.wx_sms_config();
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
				if(row["uName"]!=null)
				{
					model.uName=row["uName"].ToString();
				}
				if(row["ucode"]!=null)
				{
					model.ucode=row["ucode"].ToString();
				}
				if(row["pwd"]!=null)
				{
					model.pwd=row["pwd"].ToString();
				}
				if(row["qianming"]!=null)
				{
					model.qianming=row["qianming"].ToString();
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["sortId"]!=null && row["sortId"].ToString()!="")
				{
					model.sortId=int.Parse(row["sortId"].ToString());
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
			strSql.Append("select id,wid,uName,ucode,pwd,qianming,createDate,remark,sortId ");
			strSql.Append(" FROM wx_sms_config ");
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
			strSql.Append(" id,wid,uName,ucode,pwd,qianming,createDate,remark,sortId ");
			strSql.Append(" FROM wx_sms_config ");
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
			strSql.Append("select count(1) FROM wx_sms_config ");
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
			strSql.Append(")AS Row, T.*  from wx_sms_config T ");
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
        /// 得到一个对象实体
        /// </summary>
        public WechatBuilder.Model.wx_sms_config GetWidModel(int wid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,wid,uName,ucode,pwd,qianming,createDate,remark,sortId from wx_sms_config ");
            strSql.Append(" where wid=@wid");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4)
			};
            parameters[0].Value = wid;

            WechatBuilder.Model.wx_sms_config model = new WechatBuilder.Model.wx_sms_config();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

		#endregion  ExtensionMethod
	}
}

