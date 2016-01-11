using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_albums_type
	/// </summary>
	public partial class wx_albums_type
	{
		public wx_albums_type()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "wx_albums_type");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_albums_type");
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
        public int Add(WechatBuilder.Model.wx_albums_type model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_albums_type(");
            strSql.Append("wid,typeName,bannerPic,typeIco,typePic,tContent,remark,music,showType,createDate,sort_id)");
            strSql.Append(" values (");
            strSql.Append("@wid,@typeName,@bannerPic,@typeIco,@typePic,@tContent,@remark,@music,@showType,@createDate,@sort_id)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@typeName", SqlDbType.VarChar,100),
					new SqlParameter("@bannerPic", SqlDbType.VarChar,800),
					new SqlParameter("@typeIco", SqlDbType.VarChar,800),
					new SqlParameter("@typePic", SqlDbType.VarChar,800),
					new SqlParameter("@tContent", SqlDbType.VarChar,2000),
					new SqlParameter("@remark", SqlDbType.VarChar,1000),
					new SqlParameter("@music", SqlDbType.VarChar,800),
					new SqlParameter("@showType", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@sort_id", SqlDbType.Int,4)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.typeName;
            parameters[2].Value = model.bannerPic;
            parameters[3].Value = model.typeIco;
            parameters[4].Value = model.typePic;
            parameters[5].Value = model.tContent;
            parameters[6].Value = model.remark;
            parameters[7].Value = model.music;
            parameters[8].Value = model.showType;
            parameters[9].Value = model.createDate;
            parameters[10].Value = model.sort_id;

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
        public bool Update(WechatBuilder.Model.wx_albums_type model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_albums_type set ");
            strSql.Append("wid=@wid,");
            strSql.Append("typeName=@typeName,");
            strSql.Append("bannerPic=@bannerPic,");
            strSql.Append("typeIco=@typeIco,");
            strSql.Append("typePic=@typePic,");
            strSql.Append("tContent=@tContent,");
            strSql.Append("remark=@remark,");
            strSql.Append("music=@music,");
            strSql.Append("showType=@showType,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("sort_id=@sort_id");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@typeName", SqlDbType.VarChar,100),
					new SqlParameter("@bannerPic", SqlDbType.VarChar,800),
					new SqlParameter("@typeIco", SqlDbType.VarChar,800),
					new SqlParameter("@typePic", SqlDbType.VarChar,800),
					new SqlParameter("@tContent", SqlDbType.VarChar,2000),
					new SqlParameter("@remark", SqlDbType.VarChar,1000),
					new SqlParameter("@music", SqlDbType.VarChar,800),
					new SqlParameter("@showType", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.typeName;
            parameters[2].Value = model.bannerPic;
            parameters[3].Value = model.typeIco;
            parameters[4].Value = model.typePic;
            parameters[5].Value = model.tContent;
            parameters[6].Value = model.remark;
            parameters[7].Value = model.music;
            parameters[8].Value = model.showType;
            parameters[9].Value = model.createDate;
            parameters[10].Value = model.sort_id;
            parameters[11].Value = model.id;

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
            strSql.Append("delete from wx_albums_type ");
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
            strSql.Append("delete from wx_albums_type ");
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
        public WechatBuilder.Model.wx_albums_type GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,wid,typeName,bannerPic,typeIco,typePic,tContent,remark,music,showType,createDate,sort_id from wx_albums_type ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            WechatBuilder.Model.wx_albums_type model = new WechatBuilder.Model.wx_albums_type();
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
        public WechatBuilder.Model.wx_albums_type DataRowToModel(DataRow row)
        {
            WechatBuilder.Model.wx_albums_type model = new WechatBuilder.Model.wx_albums_type();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["wid"] != null && row["wid"].ToString() != "")
                {
                    model.wid = int.Parse(row["wid"].ToString());
                }
                if (row["typeName"] != null)
                {
                    model.typeName = row["typeName"].ToString();
                }
                if (row["bannerPic"] != null)
                {
                    model.bannerPic = row["bannerPic"].ToString();
                }
                if (row["typeIco"] != null)
                {
                    model.typeIco = row["typeIco"].ToString();
                }
                if (row["typePic"] != null)
                {
                    model.typePic = row["typePic"].ToString();
                }
                if (row["tContent"] != null)
                {
                    model.tContent = row["tContent"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["music"] != null)
                {
                    model.music = row["music"].ToString();
                }
                if (row["showType"] != null && row["showType"].ToString() != "")
                {
                    model.showType = int.Parse(row["showType"].ToString());
                }
                if (row["createDate"] != null && row["createDate"].ToString() != "")
                {
                    model.createDate = DateTime.Parse(row["createDate"].ToString());
                }
                if (row["sort_id"] != null && row["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(row["sort_id"].ToString());
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
            strSql.Append("select id,wid,typeName,bannerPic,typeIco,typePic,tContent,remark,music,showType,createDate,sort_id ");
            strSql.Append(" FROM wx_albums_type ");
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
            strSql.Append(" id,wid,typeName,bannerPic,typeIco,typePic,tContent,remark,music,showType,createDate,sort_id ");
            strSql.Append(" FROM wx_albums_type ");
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
            strSql.Append("select count(1) FROM wx_albums_type ");
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
            strSql.Append(")AS Row, T.*  from wx_albums_type T ");
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
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  '' as url,* from wx_albums_type ");
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

