using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_albums_info
	/// </summary>
	public partial class wx_albums_info
	{
		public wx_albums_info()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "wx_albums_info");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_albums_info");
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
        public int Add(WechatBuilder.Model.wx_albums_info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_albums_info(");
            strSql.Append("wid,aName,facePic,aContent,showContent,isHidden,seq,createDate,createPerson,typeId,music,showType)");
            strSql.Append(" values (");
            strSql.Append("@wid,@aName,@facePic,@aContent,@showContent,@isHidden,@seq,@createDate,@createPerson,@typeId,@music,@showType)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@aName", SqlDbType.VarChar,100),
					new SqlParameter("@facePic", SqlDbType.VarChar,1000),
					new SqlParameter("@aContent", SqlDbType.VarChar,300),
					new SqlParameter("@showContent", SqlDbType.Bit,1),
					new SqlParameter("@isHidden", SqlDbType.Bit,1),
					new SqlParameter("@seq", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createPerson", SqlDbType.VarChar,200),
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@music", SqlDbType.VarChar,800),
					new SqlParameter("@showType", SqlDbType.Int,4)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.aName;
            parameters[2].Value = model.facePic;
            parameters[3].Value = model.aContent;
            parameters[4].Value = model.showContent;
            parameters[5].Value = model.isHidden;
            parameters[6].Value = model.seq;
            parameters[7].Value = model.createDate;
            parameters[8].Value = model.createPerson;
            parameters[9].Value = model.typeId;
            parameters[10].Value = model.music;
            parameters[11].Value = model.showType;

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
        public bool Update(WechatBuilder.Model.wx_albums_info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_albums_info set ");
            strSql.Append("wid=@wid,");
            strSql.Append("aName=@aName,");
            strSql.Append("facePic=@facePic,");
            strSql.Append("aContent=@aContent,");
            strSql.Append("showContent=@showContent,");
            strSql.Append("isHidden=@isHidden,");
            strSql.Append("seq=@seq,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("createPerson=@createPerson,");
            strSql.Append("typeId=@typeId,");
            strSql.Append("music=@music,");
            strSql.Append("showType=@showType");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@aName", SqlDbType.VarChar,100),
					new SqlParameter("@facePic", SqlDbType.VarChar,1000),
					new SqlParameter("@aContent", SqlDbType.VarChar,300),
					new SqlParameter("@showContent", SqlDbType.Bit,1),
					new SqlParameter("@isHidden", SqlDbType.Bit,1),
					new SqlParameter("@seq", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createPerson", SqlDbType.VarChar,200),
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@music", SqlDbType.VarChar,800),
					new SqlParameter("@showType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.aName;
            parameters[2].Value = model.facePic;
            parameters[3].Value = model.aContent;
            parameters[4].Value = model.showContent;
            parameters[5].Value = model.isHidden;
            parameters[6].Value = model.seq;
            parameters[7].Value = model.createDate;
            parameters[8].Value = model.createPerson;
            parameters[9].Value = model.typeId;
            parameters[10].Value = model.music;
            parameters[11].Value = model.showType;
            parameters[12].Value = model.id;

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
            strSql.Append("delete from wx_albums_info ");
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
            strSql.Append("delete from wx_albums_info ");
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
        public WechatBuilder.Model.wx_albums_info GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,wid,aName,facePic,aContent,showContent,isHidden,seq,createDate,createPerson,typeId,music,showType from wx_albums_info ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            WechatBuilder.Model.wx_albums_info model = new WechatBuilder.Model.wx_albums_info();
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
        public WechatBuilder.Model.wx_albums_info DataRowToModel(DataRow row)
        {
            WechatBuilder.Model.wx_albums_info model = new WechatBuilder.Model.wx_albums_info();
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
                if (row["aName"] != null)
                {
                    model.aName = row["aName"].ToString();
                }
                if (row["facePic"] != null)
                {
                    model.facePic = row["facePic"].ToString();
                }
                if (row["aContent"] != null)
                {
                    model.aContent = row["aContent"].ToString();
                }
                if (row["showContent"] != null && row["showContent"].ToString() != "")
                {
                    if ((row["showContent"].ToString() == "1") || (row["showContent"].ToString().ToLower() == "true"))
                    {
                        model.showContent = true;
                    }
                    else
                    {
                        model.showContent = false;
                    }
                }
                if (row["isHidden"] != null && row["isHidden"].ToString() != "")
                {
                    if ((row["isHidden"].ToString() == "1") || (row["isHidden"].ToString().ToLower() == "true"))
                    {
                        model.isHidden = true;
                    }
                    else
                    {
                        model.isHidden = false;
                    }
                }
                if (row["seq"] != null && row["seq"].ToString() != "")
                {
                    model.seq = int.Parse(row["seq"].ToString());
                }
                if (row["createDate"] != null && row["createDate"].ToString() != "")
                {
                    model.createDate = DateTime.Parse(row["createDate"].ToString());
                }
                if (row["createPerson"] != null)
                {
                    model.createPerson = row["createPerson"].ToString();
                }
                if (row["typeId"] != null && row["typeId"].ToString() != "")
                {
                    model.typeId = int.Parse(row["typeId"].ToString());
                }
                if (row["music"] != null)
                {
                    model.music = row["music"].ToString();
                }
                if (row["showType"] != null && row["showType"].ToString() != "")
                {
                    model.showType = int.Parse(row["showType"].ToString());
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
            strSql.Append("select id,wid,aName,facePic,aContent,showContent,isHidden,seq,createDate,createPerson,typeId,music,showType ");
            strSql.Append(" FROM wx_albums_info ");
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
            strSql.Append(" id,wid,aName,facePic,aContent,showContent,isHidden,seq,createDate,createPerson,typeId,music,showType ");
            strSql.Append(" FROM wx_albums_info ");
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
            strSql.Append("select count(1) FROM wx_albums_info ");
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
            strSql.Append(")AS Row, T.*  from wx_albums_info T ");
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
        public DataSet GetList(int pageSize, int pageIndex, int typeId,string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  a.*,(select typeName from wx_albums_type where id=a.typeId) typeName from wx_albums_info a ");
            if (typeId != 0)
            {
                strSql.Append(" where  a.typeId=" + typeId);
                if (strWhere.Trim() != "")
                {
                    strSql.Append("  and  " + strWhere);
                }
            }
            else
            {
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where  " + strWhere);
                }
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteAlbums(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_albums_info  where id=@id;");
            strSql.Append("delete from wx_albums_photo  where aId=@id");

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

		#endregion  ExtensionMethod
	}
}

