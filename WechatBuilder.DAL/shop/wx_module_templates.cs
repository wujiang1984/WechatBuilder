using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_module_templates
	/// </summary>
	public partial class wx_module_templates
	{
		public wx_module_templates()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_module_templates"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_module_templates");
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
		public int Add(WechatBuilder.Model.wx_module_templates model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_module_templates(");
			strSql.Append("tName,author,moduleName,moduleCode,createDate,version,forWxVersion,typeName,typeId,aboutPic,tFileName,degreeName,degreId,remark)");
			strSql.Append(" values (");
			strSql.Append("@tName,@author,@moduleName,@moduleCode,@createDate,@version,@forWxVersion,@typeName,@typeId,@aboutPic,@tFileName,@degreeName,@degreId,@remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@tName", SqlDbType.VarChar,100),
					new SqlParameter("@author", SqlDbType.VarChar,50),
					new SqlParameter("@moduleName", SqlDbType.VarChar,100),
					new SqlParameter("@moduleCode", SqlDbType.VarChar,20),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@version", SqlDbType.VarChar,50),
					new SqlParameter("@forWxVersion", SqlDbType.VarChar,50),
					new SqlParameter("@typeName", SqlDbType.VarChar,100),
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@aboutPic", SqlDbType.VarChar,800),
					new SqlParameter("@tFileName", SqlDbType.VarChar,50),
					new SqlParameter("@degreeName", SqlDbType.VarChar,100),
					new SqlParameter("@degreId", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,1000)};
			parameters[0].Value = model.tName;
			parameters[1].Value = model.author;
			parameters[2].Value = model.moduleName;
			parameters[3].Value = model.moduleCode;
			parameters[4].Value = model.createDate;
			parameters[5].Value = model.version;
			parameters[6].Value = model.forWxVersion;
			parameters[7].Value = model.typeName;
			parameters[8].Value = model.typeId;
			parameters[9].Value = model.aboutPic;
			parameters[10].Value = model.tFileName;
			parameters[11].Value = model.degreeName;
			parameters[12].Value = model.degreId;
			parameters[13].Value = model.remark;

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
		public bool Update(WechatBuilder.Model.wx_module_templates model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_module_templates set ");
			strSql.Append("tName=@tName,");
			strSql.Append("author=@author,");
			strSql.Append("moduleName=@moduleName,");
			strSql.Append("moduleCode=@moduleCode,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("version=@version,");
			strSql.Append("forWxVersion=@forWxVersion,");
			strSql.Append("typeName=@typeName,");
			strSql.Append("typeId=@typeId,");
			strSql.Append("aboutPic=@aboutPic,");
			strSql.Append("tFileName=@tFileName,");
			strSql.Append("degreeName=@degreeName,");
			strSql.Append("degreId=@degreId,");
			strSql.Append("remark=@remark");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@tName", SqlDbType.VarChar,100),
					new SqlParameter("@author", SqlDbType.VarChar,50),
					new SqlParameter("@moduleName", SqlDbType.VarChar,100),
					new SqlParameter("@moduleCode", SqlDbType.VarChar,20),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@version", SqlDbType.VarChar,50),
					new SqlParameter("@forWxVersion", SqlDbType.VarChar,50),
					new SqlParameter("@typeName", SqlDbType.VarChar,100),
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@aboutPic", SqlDbType.VarChar,800),
					new SqlParameter("@tFileName", SqlDbType.VarChar,50),
					new SqlParameter("@degreeName", SqlDbType.VarChar,100),
					new SqlParameter("@degreId", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,1000),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.tName;
			parameters[1].Value = model.author;
			parameters[2].Value = model.moduleName;
			parameters[3].Value = model.moduleCode;
			parameters[4].Value = model.createDate;
			parameters[5].Value = model.version;
			parameters[6].Value = model.forWxVersion;
			parameters[7].Value = model.typeName;
			parameters[8].Value = model.typeId;
			parameters[9].Value = model.aboutPic;
			parameters[10].Value = model.tFileName;
			parameters[11].Value = model.degreeName;
			parameters[12].Value = model.degreId;
			parameters[13].Value = model.remark;
			parameters[14].Value = model.id;

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
			strSql.Append("delete from wx_module_templates ");
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
			strSql.Append("delete from wx_module_templates ");
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
		public WechatBuilder.Model.wx_module_templates GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,tName,author,moduleName,moduleCode,createDate,version,forWxVersion,typeName,typeId,aboutPic,tFileName,degreeName,degreId,remark from wx_module_templates ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_module_templates model=new WechatBuilder.Model.wx_module_templates();
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
		public WechatBuilder.Model.wx_module_templates DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_module_templates model=new WechatBuilder.Model.wx_module_templates();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["tName"]!=null)
				{
					model.tName=row["tName"].ToString();
				}
				if(row["author"]!=null)
				{
					model.author=row["author"].ToString();
				}
				if(row["moduleName"]!=null)
				{
					model.moduleName=row["moduleName"].ToString();
				}
				if(row["moduleCode"]!=null)
				{
					model.moduleCode=row["moduleCode"].ToString();
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["version"]!=null)
				{
					model.version=row["version"].ToString();
				}
				if(row["forWxVersion"]!=null)
				{
					model.forWxVersion=row["forWxVersion"].ToString();
				}
				if(row["typeName"]!=null)
				{
					model.typeName=row["typeName"].ToString();
				}
				if(row["typeId"]!=null && row["typeId"].ToString()!="")
				{
					model.typeId=int.Parse(row["typeId"].ToString());
				}
				if(row["aboutPic"]!=null)
				{
					model.aboutPic=row["aboutPic"].ToString();
				}
				if(row["tFileName"]!=null)
				{
					model.tFileName=row["tFileName"].ToString();
				}
				if(row["degreeName"]!=null)
				{
					model.degreeName=row["degreeName"].ToString();
				}
				if(row["degreId"]!=null && row["degreId"].ToString()!="")
				{
					model.degreId=int.Parse(row["degreId"].ToString());
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
			strSql.Append("select id,tName,author,moduleName,moduleCode,createDate,version,forWxVersion,typeName,typeId,aboutPic,tFileName,degreeName,degreId,remark ");
			strSql.Append(" FROM wx_module_templates ");
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
			strSql.Append(" id,tName,author,moduleName,moduleCode,createDate,version,forWxVersion,typeName,typeId,aboutPic,tFileName,degreeName,degreId,remark ");
			strSql.Append(" FROM wx_module_templates ");
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
			strSql.Append("select count(1) FROM wx_module_templates ");
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
			strSql.Append(")AS Row, T.*  from wx_module_templates T ");
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
			parameters[0].Value = "wx_module_templates";
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
        /// 通过wid获得微帐号对应的首页模版名称
        /// </summary>
        public string GetTemplatesFileNameByWid(string moduleCode, int wid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,tFileName from wx_module_templates  ");
            strSql.Append(" where moduleCode=@moduleCode and  id=(select tid from wx_module_templates_wcode where wid=@wid)");
            SqlParameter[] parameters = {
                    new SqlParameter("@moduleCode", SqlDbType.VarChar,20),
					new SqlParameter("@wid", SqlDbType.Int,4)
			};
            parameters[0].Value = moduleCode;
            parameters[1].Value = wid;

            SqlDataReader sr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters);
            string ret = "";
            while (sr.Read())
            {
                ret = sr["tFileName"].ToString();
            }
            sr.Close();

            return ret;
        }

		#endregion  ExtensionMethod
	}
}

