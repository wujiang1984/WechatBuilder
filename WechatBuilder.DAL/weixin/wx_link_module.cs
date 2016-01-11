using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_link_module
	/// </summary>
	public partial class wx_link_module
	{
		public wx_link_module()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "wx_link_module");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_link_module");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WechatBuilder.Model.wx_link_module model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_link_module(");
            strSql.Append("lName,moduleName,moduleCode,moduleType,urlRule,urlNeedReplace,tableName,isGlobal,isMore,sortId,remark,idColumn,nameColumn)");
            strSql.Append(" values (");
            strSql.Append("@lName,@moduleName,@moduleCode,@moduleType,@urlRule,@urlNeedReplace,@tableName,@isGlobal,@isMore,@sortId,@remark,@idColumn,@nameColumn)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@lName", SqlDbType.VarChar,100),
					new SqlParameter("@moduleName", SqlDbType.VarChar,100),
					new SqlParameter("@moduleCode", SqlDbType.VarChar,30),
					new SqlParameter("@moduleType", SqlDbType.Int,4),
					new SqlParameter("@urlRule", SqlDbType.VarChar,1200),
					new SqlParameter("@urlNeedReplace", SqlDbType.Bit,1),
					new SqlParameter("@tableName", SqlDbType.VarChar,50),
					new SqlParameter("@isGlobal", SqlDbType.Bit,1),
					new SqlParameter("@isMore", SqlDbType.Bit,1),
					new SqlParameter("@sortId", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,1500),
					new SqlParameter("@idColumn", SqlDbType.VarChar,30),
					new SqlParameter("@nameColumn", SqlDbType.VarChar,30)};
            parameters[0].Value = model.lName;
            parameters[1].Value = model.moduleName;
            parameters[2].Value = model.moduleCode;
            parameters[3].Value = model.moduleType;
            parameters[4].Value = model.urlRule;
            parameters[5].Value = model.urlNeedReplace;
            parameters[6].Value = model.tableName;
            parameters[7].Value = model.isGlobal;
            parameters[8].Value = model.isMore;
            parameters[9].Value = model.sortId;
            parameters[10].Value = model.remark;
            parameters[11].Value = model.idColumn;
            parameters[12].Value = model.nameColumn;

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
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WechatBuilder.Model.wx_link_module model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_link_module set ");
            strSql.Append("lName=@lName,");
            strSql.Append("moduleName=@moduleName,");
            strSql.Append("moduleCode=@moduleCode,");
            strSql.Append("moduleType=@moduleType,");
            strSql.Append("urlRule=@urlRule,");
            strSql.Append("urlNeedReplace=@urlNeedReplace,");
            strSql.Append("tableName=@tableName,");
            strSql.Append("isGlobal=@isGlobal,");
            strSql.Append("isMore=@isMore,");
            strSql.Append("sortId=@sortId,");
            strSql.Append("remark=@remark,");
            strSql.Append("idColumn=@idColumn,");
            strSql.Append("nameColumn=@nameColumn");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@lName", SqlDbType.VarChar,100),
					new SqlParameter("@moduleName", SqlDbType.VarChar,100),
					new SqlParameter("@moduleCode", SqlDbType.VarChar,30),
					new SqlParameter("@moduleType", SqlDbType.Int,4),
					new SqlParameter("@urlRule", SqlDbType.VarChar,1200),
					new SqlParameter("@urlNeedReplace", SqlDbType.Bit,1),
					new SqlParameter("@tableName", SqlDbType.VarChar,50),
					new SqlParameter("@isGlobal", SqlDbType.Bit,1),
					new SqlParameter("@isMore", SqlDbType.Bit,1),
					new SqlParameter("@sortId", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,1500),
					new SqlParameter("@idColumn", SqlDbType.VarChar,30),
					new SqlParameter("@nameColumn", SqlDbType.VarChar,30),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.lName;
            parameters[1].Value = model.moduleName;
            parameters[2].Value = model.moduleCode;
            parameters[3].Value = model.moduleType;
            parameters[4].Value = model.urlRule;
            parameters[5].Value = model.urlNeedReplace;
            parameters[6].Value = model.tableName;
            parameters[7].Value = model.isGlobal;
            parameters[8].Value = model.isMore;
            parameters[9].Value = model.sortId;
            parameters[10].Value = model.remark;
            parameters[11].Value = model.idColumn;
            parameters[12].Value = model.nameColumn;
            parameters[13].Value = model.id;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_link_module ");
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_link_module ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public WechatBuilder.Model.wx_link_module GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,lName,moduleName,moduleCode,moduleType,urlRule,urlNeedReplace,tableName,isGlobal,isMore,sortId,remark,idColumn,nameColumn from wx_link_module ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            WechatBuilder.Model.wx_link_module model = new WechatBuilder.Model.wx_link_module();
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


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WechatBuilder.Model.wx_link_module DataRowToModel(DataRow row)
        {
            WechatBuilder.Model.wx_link_module model = new WechatBuilder.Model.wx_link_module();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["lName"] != null)
                {
                    model.lName = row["lName"].ToString();
                }
                if (row["moduleName"] != null)
                {
                    model.moduleName = row["moduleName"].ToString();
                }
                if (row["moduleCode"] != null)
                {
                    model.moduleCode = row["moduleCode"].ToString();
                }
                if (row["moduleType"] != null && row["moduleType"].ToString() != "")
                {
                    model.moduleType = int.Parse(row["moduleType"].ToString());
                }
                if (row["urlRule"] != null)
                {
                    model.urlRule = row["urlRule"].ToString();
                }
                if (row["urlNeedReplace"] != null && row["urlNeedReplace"].ToString() != "")
                {
                    if ((row["urlNeedReplace"].ToString() == "1") || (row["urlNeedReplace"].ToString().ToLower() == "true"))
                    {
                        model.urlNeedReplace = true;
                    }
                    else
                    {
                        model.urlNeedReplace = false;
                    }
                }
                if (row["tableName"] != null)
                {
                    model.tableName = row["tableName"].ToString();
                }
                if (row["isGlobal"] != null && row["isGlobal"].ToString() != "")
                {
                    if ((row["isGlobal"].ToString() == "1") || (row["isGlobal"].ToString().ToLower() == "true"))
                    {
                        model.isGlobal = true;
                    }
                    else
                    {
                        model.isGlobal = false;
                    }
                }
                if (row["isMore"] != null && row["isMore"].ToString() != "")
                {
                    if ((row["isMore"].ToString() == "1") || (row["isMore"].ToString().ToLower() == "true"))
                    {
                        model.isMore = true;
                    }
                    else
                    {
                        model.isMore = false;
                    }
                }
                if (row["sortId"] != null && row["sortId"].ToString() != "")
                {
                    model.sortId = int.Parse(row["sortId"].ToString());
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["idColumn"] != null)
                {
                    model.idColumn = row["idColumn"].ToString();
                }
                if (row["nameColumn"] != null)
                {
                    model.nameColumn = row["nameColumn"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,lName,moduleName,moduleCode,moduleType,urlRule,urlNeedReplace,tableName,isGlobal,isMore,sortId,remark,idColumn,nameColumn ");
            strSql.Append(" FROM wx_link_module ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,lName,moduleName,moduleCode,moduleType,urlRule,urlNeedReplace,tableName,isGlobal,isMore,sortId,remark,idColumn,nameColumn ");
            strSql.Append(" FROM wx_link_module ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM wx_link_module ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from wx_link_module T ");
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
            parameters[0].Value = "wx_link_module";
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetTableList(string sql)
        {

            return DbHelperSQL.Query(sql);
        }


		#endregion  ExtensionMethod
	}
}

