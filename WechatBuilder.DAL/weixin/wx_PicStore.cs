using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using WechatBuilder.DBUtility;

namespace WechatBuilder.DAL
{
    /// <summary>
    /// 数据访问类:wx_PicStore
    /// </summary>
    public partial class wx_PicStore
    {
        public wx_PicStore()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "wx_PicStore");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_PicStore");
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
        public int Add(WechatBuilder.Model.wx_PicStore model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_PicStore(");
            strSql.Append("picName,picUri,picTemplates,picType,picUsedType,picValue,picCreatePerson,createDate)");
            strSql.Append(" values (");
            strSql.Append("@picName,@picUri,@picTemplates,@picType,@picUsedType,@picValue,@picCreatePerson,@createDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@picName", SqlDbType.VarChar,200),
					new SqlParameter("@picUri", SqlDbType.VarChar,1000),
					new SqlParameter("@picTemplates", SqlDbType.VarChar,300),
					new SqlParameter("@picType", SqlDbType.Int,4),
					new SqlParameter("@picUsedType", SqlDbType.NVarChar,50),
					new SqlParameter("@picValue", SqlDbType.VarChar,300),
					new SqlParameter("@picCreatePerson", SqlDbType.VarChar,200),
					new SqlParameter("@createDate", SqlDbType.DateTime)};
            parameters[0].Value = model.picName;
            parameters[1].Value = model.picUri;
            parameters[2].Value = model.picTemplates;
            parameters[3].Value = model.picType;
            parameters[4].Value = model.picUsedType;
            parameters[5].Value = model.picValue;
            parameters[6].Value = model.picCreatePerson;
            parameters[7].Value = model.createDate;

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
        public bool Update(WechatBuilder.Model.wx_PicStore model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_PicStore set ");
            strSql.Append("picName=@picName,");
            strSql.Append("picUri=@picUri,");
            strSql.Append("picTemplates=@picTemplates,");
            strSql.Append("picType=@picType,");
            strSql.Append("picUsedType=@picUsedType,");
            strSql.Append("picValue=@picValue,");
            strSql.Append("picCreatePerson=@picCreatePerson,");
            strSql.Append("createDate=@createDate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@picName", SqlDbType.VarChar,200),
					new SqlParameter("@picUri", SqlDbType.VarChar,1000),
					new SqlParameter("@picTemplates", SqlDbType.VarChar,300),
					new SqlParameter("@picType", SqlDbType.Int,4),
					new SqlParameter("@picUsedType", SqlDbType.NVarChar,50),
					new SqlParameter("@picValue", SqlDbType.VarChar,300),
					new SqlParameter("@picCreatePerson", SqlDbType.VarChar,200),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.picName;
            parameters[1].Value = model.picUri;
            parameters[2].Value = model.picTemplates;
            parameters[3].Value = model.picType;
            parameters[4].Value = model.picUsedType;
            parameters[5].Value = model.picValue;
            parameters[6].Value = model.picCreatePerson;
            parameters[7].Value = model.createDate;
            parameters[8].Value = model.id;

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
            strSql.Append("delete from wx_PicStore ");
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
            strSql.Append("delete from wx_PicStore ");
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
        public WechatBuilder.Model.wx_PicStore GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,picName,picUri,picTemplates,picType,picUsedType,picValue,picCreatePerson,createDate from wx_PicStore ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            WechatBuilder.Model.wx_PicStore model = new WechatBuilder.Model.wx_PicStore();
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
        public WechatBuilder.Model.wx_PicStore DataRowToModel(DataRow row)
        {
            WechatBuilder.Model.wx_PicStore model = new WechatBuilder.Model.wx_PicStore();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["picName"] != null)
                {
                    model.picName = row["picName"].ToString();
                }
                if (row["picUri"] != null)
                {
                    model.picUri = row["picUri"].ToString();
                }
                if (row["picTemplates"] != null)
                {
                    model.picTemplates = row["picTemplates"].ToString();
                }
                if (row["picType"] != null && row["picType"].ToString() != "")
                {
                    model.picType = int.Parse(row["picType"].ToString());
                }
                if (row["picUsedType"] != null)
                {
                    model.picUsedType = row["picUsedType"].ToString();
                }
                if (row["picValue"] != null)
                {
                    model.picValue = row["picValue"].ToString();
                }
                if (row["picCreatePerson"] != null)
                {
                    model.picCreatePerson = row["picCreatePerson"].ToString();
                }
                if (row["createDate"] != null && row["createDate"].ToString() != "")
                {
                    model.createDate = DateTime.Parse(row["createDate"].ToString());
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
            strSql.Append("select id,picName,picUri,picTemplates,picType,picUsedType,picValue,picCreatePerson,createDate ");
            strSql.Append(" FROM wx_PicStore ");
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
            strSql.Append(" id,picName,picUri,picTemplates,picType,picUsedType,picValue,picCreatePerson,createDate ");
            strSql.Append(" FROM wx_PicStore ");
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
            strSql.Append("select count(1) FROM wx_PicStore ");
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
            strSql.Append(")AS Row, T.*  from wx_PicStore T ");
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
            parameters[0].Value = "wx_PicStore";
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
        /// 获得模版类型
        /// </summary>
        /// <returns></returns>
        public DataSet GetTemplatesList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct pictemplates from wx_picstore");

            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  ExtensionMethod
    }
}
