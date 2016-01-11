using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;

namespace WechatBuilder.DAL
{
    /// <summary>
    /// 数据访问类:支付方式
    /// </summary>
    public partial class payment
    {
        private string databaseprefix; //数据库表名前缀
        public payment(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        #region 基本方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "payment");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回标题名称
        /// </summary>
        public string GetTitle(int wid, int ptypeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 title from " + databaseprefix + "payment");
            strSql.Append(" where wid=@wid and pTypeId=@pTypeId");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
                    new SqlParameter("@pTypeId", SqlDbType.Int,4)
                                        };
            parameters[0].Value = wid;
            parameters[1].Value = ptypeId;
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
            if (string.IsNullOrEmpty(title))
            {
                return "-";
            }
            return title;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.payment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "payment(");
            strSql.Append("title,img_url,remark,type,poundage_type,poundage_amount,sort_id,is_lock,api_path,wid,pTypeId)");
            strSql.Append(" values (");
            strSql.Append("@title,@img_url,@remark,@type,@poundage_type,@poundage_amount,@sort_id,@is_lock,@api_path,@wid,@pTypeId)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@type", SqlDbType.TinyInt,1),
					new SqlParameter("@poundage_type", SqlDbType.TinyInt,1),
					new SqlParameter("@poundage_amount", SqlDbType.Decimal,5),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
					new SqlParameter("@api_path", SqlDbType.NVarChar,100),
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@pTypeId", SqlDbType.Int,4)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.img_url;
            parameters[2].Value = model.remark;
            parameters[3].Value = model.type;
            parameters[4].Value = model.poundage_type;
            parameters[5].Value = model.poundage_amount;
            parameters[6].Value = model.sort_id;
            parameters[7].Value = model.is_lock;
            parameters[8].Value = model.api_path;
            parameters[9].Value = model.wid;
			parameters[10].Value = model.pTypeId;

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
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "payment set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.payment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "payment set ");
            strSql.Append("title=@title,");
            strSql.Append("img_url=@img_url,");
            strSql.Append("remark=@remark,");
            strSql.Append("type=@type,");
            strSql.Append("poundage_type=@poundage_type,");
            strSql.Append("poundage_amount=@poundage_amount,");
            strSql.Append("sort_id=@sort_id,");
            strSql.Append("is_lock=@is_lock,");
            strSql.Append("api_path=@api_path,");
            strSql.Append("wid=@wid,");
            strSql.Append("pTypeId=@pTypeId");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@type", SqlDbType.TinyInt,1),
					new SqlParameter("@poundage_type", SqlDbType.TinyInt,1),
					new SqlParameter("@poundage_amount", SqlDbType.Decimal,5),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
					new SqlParameter("@api_path", SqlDbType.NVarChar,100),
                    new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@pTypeId", SqlDbType.Int,4),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.img_url;
            parameters[2].Value = model.remark;
            parameters[3].Value = model.type;
            parameters[4].Value = model.poundage_type;
            parameters[5].Value = model.poundage_amount;
            parameters[6].Value = model.sort_id;
            parameters[7].Value = model.is_lock;
            parameters[8].Value = model.api_path;
            parameters[9].Value = model.wid;
            parameters[10].Value = model.pTypeId;
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
            strSql.Append("delete from " + databaseprefix + "payment ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
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
        /// 得到一个对象实体
        /// </summary>
        public Model.payment GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,title,img_url,remark,type,poundage_type,poundage_amount,sort_id,is_lock,api_path,wid,pTypeId from " + databaseprefix + "payment ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.payment model = new Model.payment();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.img_url = ds.Tables[0].Rows[0]["img_url"].ToString();
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                if (ds.Tables[0].Rows[0]["type"].ToString() != "")
                {
                    model.type = int.Parse(ds.Tables[0].Rows[0]["type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["poundage_type"].ToString() != "")
                {
                    model.poundage_type = int.Parse(ds.Tables[0].Rows[0]["poundage_type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["poundage_amount"].ToString() != "")
                {
                    model.poundage_amount = decimal.Parse(ds.Tables[0].Rows[0]["poundage_amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_lock"].ToString() != "")
                {
                    model.is_lock = int.Parse(ds.Tables[0].Rows[0]["is_lock"].ToString());
                }
                model.api_path = ds.Tables[0].Rows[0]["api_path"].ToString();

                if (ds.Tables[0].Rows[0]["wid"] != null && ds.Tables[0].Rows[0]["wid"].ToString() != "")
                {
                    model.wid = int.Parse(ds.Tables[0].Rows[0]["wid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pTypeId"] != null && ds.Tables[0].Rows[0]["pTypeId"].ToString() != "")
                {
                    model.pTypeId = int.Parse(ds.Tables[0].Rows[0]["pTypeId"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.payment GetModelBypTypeId(int pTypeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,title,img_url,remark,type,poundage_type,poundage_amount,sort_id,is_lock,api_path,wid,pTypeId from " + databaseprefix + "payment ");
            strSql.Append(" where pTypeId=@pTypeId");
            SqlParameter[] parameters = {
					new SqlParameter("@pTypeId", SqlDbType.Int,4)};
            parameters[0].Value = pTypeId;

            Model.payment model = new Model.payment();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.img_url = ds.Tables[0].Rows[0]["img_url"].ToString();
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                if (ds.Tables[0].Rows[0]["type"].ToString() != "")
                {
                    model.type = int.Parse(ds.Tables[0].Rows[0]["type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["poundage_type"].ToString() != "")
                {
                    model.poundage_type = int.Parse(ds.Tables[0].Rows[0]["poundage_type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["poundage_amount"].ToString() != "")
                {
                    model.poundage_amount = decimal.Parse(ds.Tables[0].Rows[0]["poundage_amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_lock"].ToString() != "")
                {
                    model.is_lock = int.Parse(ds.Tables[0].Rows[0]["is_lock"].ToString());
                }
                model.api_path = ds.Tables[0].Rows[0]["api_path"].ToString();

                if (ds.Tables[0].Rows[0]["wid"] != null && ds.Tables[0].Rows[0]["wid"].ToString() != "")
                {
                    model.wid = int.Parse(ds.Tables[0].Rows[0]["wid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pTypeId"] != null && ds.Tables[0].Rows[0]["pTypeId"].ToString() != "")
                {
                    model.pTypeId = int.Parse(ds.Tables[0].Rows[0]["pTypeId"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,title,img_url,remark,type,poundage_type,poundage_amount,sort_id,is_lock,api_path,wid,pTypeId ");
            strSql.Append(" FROM " + databaseprefix + "payment ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by sort_id asc,id desc");
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
            strSql.Append(" id,title,img_url,remark,type,poundage_type,poundage_amount,sort_id,is_lock,api_path,wid,pTypeId ");
            strSql.Append(" FROM " + databaseprefix + "payment ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  Method
    }
}