using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_product_sys
	/// </summary>
	public partial class wx_product_sys
	{
		public wx_product_sys()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "wx_product_sys");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_product_sys");
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
        public int Add(WechatBuilder.Model.wx_product_sys model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_product_sys(");
            strSql.Append("wid,title,banner,extStr,extStr2,extStr3,remark,createDate,sort_id,link_url)");
            strSql.Append(" values (");
            strSql.Append("@wid,@title,@banner,@extStr,@extStr2,@extStr3,@remark,@createDate,@sort_id,@link_url)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,100),
					new SqlParameter("@banner", SqlDbType.VarChar,800),
					new SqlParameter("@extStr", SqlDbType.VarChar,500),
					new SqlParameter("@extStr2", SqlDbType.VarChar,800),
					new SqlParameter("@extStr3", SqlDbType.VarChar,2000),
					new SqlParameter("@remark", SqlDbType.VarChar,1000),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@link_url", SqlDbType.VarChar,800)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.title;
            parameters[2].Value = model.banner;
            parameters[3].Value = model.extStr;
            parameters[4].Value = model.extStr2;
            parameters[5].Value = model.extStr3;
            parameters[6].Value = model.remark;
            parameters[7].Value = model.createDate;
            parameters[8].Value = model.sort_id;
            parameters[9].Value = model.link_url;

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
        public bool Update(WechatBuilder.Model.wx_product_sys model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_product_sys set ");
            strSql.Append("wid=@wid,");
            strSql.Append("title=@title,");
            strSql.Append("banner=@banner,");
            strSql.Append("extStr=@extStr,");
            strSql.Append("extStr2=@extStr2,");
            strSql.Append("extStr3=@extStr3,");
            strSql.Append("remark=@remark,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("sort_id=@sort_id,");
            strSql.Append("link_url=@link_url");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,100),
					new SqlParameter("@banner", SqlDbType.VarChar,800),
					new SqlParameter("@extStr", SqlDbType.VarChar,500),
					new SqlParameter("@extStr2", SqlDbType.VarChar,800),
					new SqlParameter("@extStr3", SqlDbType.VarChar,2000),
					new SqlParameter("@remark", SqlDbType.VarChar,1000),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@link_url", SqlDbType.VarChar,800),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.title;
            parameters[2].Value = model.banner;
            parameters[3].Value = model.extStr;
            parameters[4].Value = model.extStr2;
            parameters[5].Value = model.extStr3;
            parameters[6].Value = model.remark;
            parameters[7].Value = model.createDate;
            parameters[8].Value = model.sort_id;
            parameters[9].Value = model.link_url;
            parameters[10].Value = model.id;

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
            strSql.Append("delete from wx_product_sys ");
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
        public WechatBuilder.Model.wx_product_sys GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,wid,title,banner,extStr,extStr2,extStr3,remark,createDate,sort_id,link_url from wx_product_sys ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            WechatBuilder.Model.wx_product_sys model = new WechatBuilder.Model.wx_product_sys();
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
        public WechatBuilder.Model.wx_product_sys DataRowToModel(DataRow row)
        {
            WechatBuilder.Model.wx_product_sys model = new WechatBuilder.Model.wx_product_sys();
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
                if (row["title"] != null)
                {
                    model.title = row["title"].ToString();
                }
                if (row["banner"] != null)
                {
                    model.banner = row["banner"].ToString();
                }
                if (row["extStr"] != null)
                {
                    model.extStr = row["extStr"].ToString();
                }
                if (row["extStr2"] != null)
                {
                    model.extStr2 = row["extStr2"].ToString();
                }
                if (row["extStr3"] != null)
                {
                    model.extStr3 = row["extStr3"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["createDate"] != null && row["createDate"].ToString() != "")
                {
                    model.createDate = DateTime.Parse(row["createDate"].ToString());
                }
                if (row["sort_id"] != null && row["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(row["sort_id"].ToString());
                }
                if (row["link_url"] != null)
                {
                    model.link_url = row["link_url"].ToString();
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
            strSql.Append("select id,wid,title,banner,extStr,extStr2,extStr3,remark,createDate,sort_id,link_url ");
            strSql.Append(" FROM wx_product_sys ");
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
            strSql.Append(" id,wid,title,banner,extStr,extStr2,extStr3,remark,createDate,sort_id,link_url ");
            strSql.Append(" FROM wx_product_sys ");
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
            strSql.Append("select count(1) FROM wx_product_sys ");
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
            strSql.Append(")AS Row, T.*  from wx_product_sys T ");
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
        /// 取得该微帐号的所有类别列表
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        public DataTable GetWCodeList(int wid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,wid,title,banner,extStr,extStr2,extStr3,remark,createDate,sort_id,link_url from wx_product_sys ");
            strSql.Append(" where  wid=" + wid + "  order by sort_id asc,id desc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            DataTable oldData = ds.Tables[0] as DataTable;
            if (oldData == null)
            {
                return null;
            }
            return oldData;
          
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_product_sys set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_product_sys ");
            strSql.Append(" where id=@id and id not in(select store_id from wx_product_type)");
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

