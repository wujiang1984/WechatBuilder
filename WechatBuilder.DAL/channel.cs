using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;

namespace WechatBuilder.DAL
{
    /// <summary>
    /// 数据访问类:频道
    /// </summary>
    public partial class channel
    {
        private string databaseprefix; //数据库表名前缀
        public channel(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        #region  基本方法=========================================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "channel");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 查询是否存在该记录
        /// </summary>
        public bool Exists(string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "channel");
            strSql.Append(" where name=@name ");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,50)};
            parameters[0].Value = name;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from " + databaseprefix + "channel");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 增加一条数据及其子表
        /// </summary>
        public int Add(Model.channel model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into " + databaseprefix + "channel(");
                        strSql.Append("category_id,name,title,is_albums,is_attach,is_group_price,page_size,sort_id)");
                        strSql.Append(" values (");
                        strSql.Append("@category_id,@name,@title,@is_albums,@is_attach,@is_group_price,@page_size,@sort_id)");
                        strSql.Append(";select @@IDENTITY");
                        SqlParameter[] parameters = {
					            new SqlParameter("@category_id", SqlDbType.Int,4),
					            new SqlParameter("@name", SqlDbType.VarChar,50),
					            new SqlParameter("@title", SqlDbType.VarChar,100),
                                new SqlParameter("@is_albums", SqlDbType.TinyInt,1),
					            new SqlParameter("@is_attach", SqlDbType.TinyInt,1),
					            new SqlParameter("@is_group_price", SqlDbType.TinyInt,1),
					            new SqlParameter("@page_size", SqlDbType.Int,4),
					            new SqlParameter("@sort_id", SqlDbType.Int,4),
                                new SqlParameter("@ReturnValue",SqlDbType.Int)};
                        parameters[0].Value = model.category_id;
                        parameters[1].Value = model.name;
                        parameters[2].Value = model.title;
                        parameters[3].Value = model.is_albums;
                        parameters[4].Value = model.is_attach;
                        parameters[5].Value = model.is_group_price;
                        parameters[6].Value = model.page_size;
                        parameters[7].Value = model.sort_id;
                        object obj = DbHelperSQL.GetSingle(conn, trans, strSql.ToString(), parameters); //带事务
                        model.id = Convert.ToInt32(obj);

                        //扩展字段
                        if (model.channel_fields != null)
                        {
                            StringBuilder strSql2;
                            foreach (Model.channel_field modelt in model.channel_fields)
                            {
                                strSql2 = new StringBuilder();
                                strSql2.Append("insert into " + databaseprefix + "channel_field(");
                                strSql2.Append("channel_id,field_id)");
                                strSql2.Append(" values (");
                                strSql2.Append("@channel_id,@field_id)");
                                SqlParameter[] parameters2 = {
					                    new SqlParameter("@channel_id", SqlDbType.Int,4),
					                    new SqlParameter("@field_id", SqlDbType.Int,4)};
                                parameters2[0].Value = model.id;
                                parameters2[1].Value = modelt.field_id;
                                DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);
                            }
                        }

                        //添加视图
                        StringBuilder strSql3 = new StringBuilder();
                        strSql3.Append("CREATE VIEW view_channel_" + model.name + " as");
                        strSql3.Append(" SELECT " + databaseprefix + "article.*");
                        if (model.channel_fields != null)
                        {
                            foreach (Model.channel_field modelt in model.channel_fields)
                            {
                                Model.article_attribute_field fieldModel = new DAL.article_attribute_field(databaseprefix).GetModel(modelt.field_id);
                                if (fieldModel != null)
                                {
                                    strSql3.Append("," + databaseprefix + "article_attribute_value." + fieldModel.name);
                                }
                            }
                        }
                        strSql3.Append(" FROM " + databaseprefix + "article_attribute_value INNER JOIN");
                        strSql3.Append(" " + databaseprefix + "article ON " + databaseprefix + "article_attribute_value.article_id = " + databaseprefix + "article.id");
                        strSql3.Append(" WHERE " + databaseprefix + "article.channel_id=" + model.id);
                        DbHelperSQL.ExecuteSql(conn, trans, strSql3.ToString());

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return 0;
                    }
                }
            }
            return model.id;
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "channel set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.channel model)
        {
            Model.channel oldModel = GetModel(model.id); //旧的数据
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update " + databaseprefix + "channel set ");
                        strSql.Append("category_id=@category_id,");
                        strSql.Append("name=@name,");
                        strSql.Append("title=@title,");
                        strSql.Append("is_albums=@is_albums,");
                        strSql.Append("is_attach=@is_attach,");
                        strSql.Append("is_group_price=@is_group_price,");
                        strSql.Append("page_size=@page_size,");
                        strSql.Append("sort_id=@sort_id");
                        strSql.Append(" where id=@id ");
                        SqlParameter[] parameters = {
					            new SqlParameter("@category_id", SqlDbType.Int,4),
					            new SqlParameter("@name", SqlDbType.VarChar,50),
					            new SqlParameter("@title", SqlDbType.VarChar,100),
                                new SqlParameter("@is_albums", SqlDbType.TinyInt,1),
					            new SqlParameter("@is_attach", SqlDbType.TinyInt,1),
					            new SqlParameter("@is_group_price", SqlDbType.TinyInt,1),
					            new SqlParameter("@page_size", SqlDbType.Int,4),
					            new SqlParameter("@sort_id", SqlDbType.Int,4),
                                new SqlParameter("@id", SqlDbType.Int,4)};
                        parameters[0].Value = model.category_id;
                        parameters[1].Value = model.name;
                        parameters[2].Value = model.title;
                        parameters[3].Value = model.is_albums;
                        parameters[4].Value = model.is_attach;
                        parameters[5].Value = model.is_group_price;
                        parameters[6].Value = model.page_size;
                        parameters[7].Value = model.sort_id;
                        parameters[8].Value = model.id;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        //删除已移除的扩展字段
                        FieldDelete(conn, trans, model.channel_fields, model.id);
                        //添加扩展字段
                        if (model.channel_fields != null)
                        {
                            StringBuilder strSql2;
                            foreach (Model.channel_field modelt in model.channel_fields)
                            {
                                strSql2 = new StringBuilder();
                                Model.channel_field fieldModel = null;
                                if (oldModel.channel_fields != null)
                                {
                                    fieldModel = oldModel.channel_fields.Find(p => p.field_id == modelt.field_id); //查找是否已经存在
                                }
                                if (fieldModel == null) //如果不存在则添加
                                {
                                    strSql2.Append("insert into " + databaseprefix + "channel_field(");
                                    strSql2.Append("channel_id,field_id)");
                                    strSql2.Append(" values (");
                                    strSql2.Append("@channel_id,@field_id)");
                                    SqlParameter[] parameters2 = {
					                        new SqlParameter("@channel_id", SqlDbType.Int,4),
					                        new SqlParameter("@field_id", SqlDbType.Int,4)};
                                    parameters2[0].Value = modelt.channel_id;
                                    parameters2[1].Value = modelt.field_id;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);
                                }
                            }
                        }
                        //删除旧视图重建新视图
                        RehabChannelViews(conn, trans, model, oldModel.name);

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            //取得将要删除的记录
            Model.channel model = GetModel(id);
            if (model == null)
            {
                return false;
            }
            //取得导航的ID
            int nav_id = new navigation(databaseprefix).GetNavId("channel_" + model.name);

            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        //删除导航主表
                        if (nav_id > 0)
                        {
                            DbHelperSQL.ExecuteSql(conn, trans, "delete from " + databaseprefix + "navigation  where class_list like '%," + nav_id + ",%'");
                        }

                        //删除视图
                        StringBuilder strSql1 = new StringBuilder();
                        strSql1.Append("if exists (select 1 from sysobjects where id = object_id('view_channel_" + model.name + "') and type = 'V')");
                        strSql1.Append("drop view view_channel_" + model.name);
                        DbHelperSQL.ExecuteSql(conn, trans, strSql1.ToString());

                        //删除频道扩展字段表
                        StringBuilder strSql2 = new StringBuilder();
                        strSql2.Append("delete from " + databaseprefix + "channel_field ");
                        strSql2.Append(" where channel_id=@channel_id ");
                        SqlParameter[] parameters2 = {
					            new SqlParameter("@channel_id", SqlDbType.Int,4)};
                        parameters2[0].Value = id;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);

                        //删除频道表
                        StringBuilder strSql3 = new StringBuilder();
                        strSql3.Append("delete from " + databaseprefix + "channel ");
                        strSql3.Append(" where id=@id ");
                        SqlParameter[] parameters3 = {
					            new SqlParameter("@id", SqlDbType.Int,4)};
                        parameters3[0].Value = id;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql3.ToString(), parameters3);

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.channel GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,category_id,name,title,is_albums,is_attach,is_group_price,page_size,sort_id from " + databaseprefix + "channel ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.channel model = new Model.channel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                #region  父表信息
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["category_id"].ToString() != "")
                {
                    model.category_id = int.Parse(ds.Tables[0].Rows[0]["category_id"].ToString());
                }
                model.name = ds.Tables[0].Rows[0]["name"].ToString();
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                if (ds.Tables[0].Rows[0]["is_albums"].ToString() != "")
                {
                    model.is_albums = int.Parse(ds.Tables[0].Rows[0]["is_albums"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_attach"].ToString() != "")
                {
                    model.is_attach = int.Parse(ds.Tables[0].Rows[0]["is_attach"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_group_price"].ToString() != "")
                {
                    model.is_group_price = int.Parse(ds.Tables[0].Rows[0]["is_group_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["page_size"].ToString() != "")
                {
                    model.page_size = int.Parse(ds.Tables[0].Rows[0]["page_size"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
                }
                #endregion  父表信息end

                #region  子表信息
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("select id,channel_id,field_id from " + databaseprefix + "channel_field ");
                strSql2.Append(" where channel_id=@channel_id ");
                SqlParameter[] parameters2 = {
					new SqlParameter("@channel_id", SqlDbType.Int,4)};
                parameters2[0].Value = id;

                DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    int i = ds2.Tables[0].Rows.Count;
                    List<Model.channel_field> models = new List<Model.channel_field>();
                    Model.channel_field modelt;
                    for (int n = 0; n < i; n++)
                    {
                        modelt = new Model.channel_field();
                        if (ds2.Tables[0].Rows[n]["id"].ToString() != "")
                        {
                            modelt.id = int.Parse(ds2.Tables[0].Rows[n]["id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["channel_id"].ToString() != "")
                        {
                            modelt.channel_id = int.Parse(ds2.Tables[0].Rows[n]["channel_id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["field_id"].ToString() != "")
                        {
                            modelt.field_id = int.Parse(ds2.Tables[0].Rows[n]["field_id"].ToString());
                        }
                        models.Add(modelt);
                    }
                    model.channel_fields = models;
                }
                #endregion  子表信息end

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
        public Model.channel GetModel(SqlConnection conn, SqlTransaction trans, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,category_id,name,title,is_albums,is_attach,is_group_price,page_size,sort_id from " + databaseprefix + "channel ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.channel model = new Model.channel();
            DataSet ds = DbHelperSQL.Query(conn, trans, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                #region  父表信息
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["category_id"].ToString() != "")
                {
                    model.category_id = int.Parse(ds.Tables[0].Rows[0]["category_id"].ToString());
                }
                model.name = ds.Tables[0].Rows[0]["name"].ToString();
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                if (ds.Tables[0].Rows[0]["is_albums"].ToString() != "")
                {
                    model.is_albums = int.Parse(ds.Tables[0].Rows[0]["is_albums"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_attach"].ToString() != "")
                {
                    model.is_attach = int.Parse(ds.Tables[0].Rows[0]["is_attach"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_group_price"].ToString() != "")
                {
                    model.is_group_price = int.Parse(ds.Tables[0].Rows[0]["is_group_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["page_size"].ToString() != "")
                {
                    model.page_size = int.Parse(ds.Tables[0].Rows[0]["page_size"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
                }
                #endregion

                #region  子表信息
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("select id,channel_id,field_id from " + databaseprefix + "channel_field ");
                strSql2.Append(" where channel_id=@channel_id ");
                SqlParameter[] parameters2 = {
					new SqlParameter("@channel_id", SqlDbType.Int,4)};
                parameters2[0].Value = id;

                DataSet ds2 = DbHelperSQL.Query(conn, trans, strSql2.ToString(), parameters2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    int i = ds2.Tables[0].Rows.Count;
                    List<Model.channel_field> models = new List<Model.channel_field>();
                    Model.channel_field modelt;
                    for (int n = 0; n < i; n++)
                    {
                        modelt = new Model.channel_field();
                        if (ds2.Tables[0].Rows[n]["id"].ToString() != "")
                        {
                            modelt.id = int.Parse(ds2.Tables[0].Rows[n]["id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["channel_id"].ToString() != "")
                        {
                            modelt.channel_id = int.Parse(ds2.Tables[0].Rows[n]["channel_id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["field_id"].ToString() != "")
                        {
                            modelt.field_id = int.Parse(ds2.Tables[0].Rows[n]["field_id"].ToString());
                        }
                        models.Add(modelt);
                    }
                    model.channel_fields = models;
                }
                #endregion

                return model;
            }
            else
            {
                return null;
            }
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
            strSql.Append(" id,category_id,name,title,is_albums,is_attach,is_group_price,page_size,sort_id ");
            strSql.Append(" FROM " + databaseprefix + "channel ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "channel");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        #endregion

        #region 扩展方法=========================================
        /// <summary>
        /// 根据频道的名称查询ID
        /// </summary>
        public int GetChannelId(string channel_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id FROM " + databaseprefix + "channel");
            strSql.Append(" where name=@name");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50)};
            parameters[0].Value = channel_name;
            string str = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
            return Utils.StrToInt(str, 0);
        }

        /// <summary>
        /// 根据频道的ID查询名称
        /// </summary>
        public string GetChannelName(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 name FROM " + databaseprefix + "channel");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            string name = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
            if (string.IsNullOrEmpty(name))
            {
                return string.Empty;
            }
            return name;
        }

        /// <summary>
        /// 根据频道的名称查询ID
        /// </summary>
        public Model.channel GetModel(string channel_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,category_id,name,title,is_albums,is_attach,is_group_price,page_size,sort_id from " + databaseprefix + "channel ");
            strSql.Append(" where name=@name ");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,250)};
            parameters[0].Value = channel_name;

            Model.channel model = new Model.channel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                #region  父表信息
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["category_id"].ToString() != "")
                {
                    model.category_id = int.Parse(ds.Tables[0].Rows[0]["category_id"].ToString());
                }
                model.name = ds.Tables[0].Rows[0]["name"].ToString();
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                if (ds.Tables[0].Rows[0]["is_albums"].ToString() != "")
                {
                    model.is_albums = int.Parse(ds.Tables[0].Rows[0]["is_albums"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_attach"].ToString() != "")
                {
                    model.is_attach = int.Parse(ds.Tables[0].Rows[0]["is_attach"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_group_price"].ToString() != "")
                {
                    model.is_group_price = int.Parse(ds.Tables[0].Rows[0]["is_group_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["page_size"].ToString() != "")
                {
                    model.page_size = int.Parse(ds.Tables[0].Rows[0]["page_size"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
                }
                #endregion  父表信息end

                #region  子表信息
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("select id,channel_id,field_id from " + databaseprefix + "channel_field ");
                strSql2.Append(" where channel_id=@channel_id ");
                SqlParameter[] parameters2 = {
					new SqlParameter("@channel_id", SqlDbType.Int,4)};
                parameters2[0].Value = model.id;

                DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    int i = ds2.Tables[0].Rows.Count;
                    List<Model.channel_field> models = new List<Model.channel_field>();
                    Model.channel_field modelt;
                    for (int n = 0; n < i; n++)
                    {
                        modelt = new Model.channel_field();
                        if (ds2.Tables[0].Rows[n]["id"].ToString() != "")
                        {
                            modelt.id = int.Parse(ds2.Tables[0].Rows[n]["id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["channel_id"].ToString() != "")
                        {
                            modelt.channel_id = int.Parse(ds2.Tables[0].Rows[n]["channel_id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["field_id"].ToString() != "")
                        {
                            modelt.field_id = int.Parse(ds2.Tables[0].Rows[n]["field_id"].ToString());
                        }
                        models.Add(modelt);
                    }
                    model.channel_fields = models;
                }
                #endregion  子表信息end

                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取分页大小
        /// </summary>
        public int GetPageSize(string channel_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 page_size FROM " + databaseprefix + "channel");
            strSql.Append(" where name=@name");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,50)};
            parameters[0].Value = channel_name;

            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
        }
        /// <summary>
        /// 删除已移除的频道扩展字段
        /// </summary>
        public void FieldDelete(SqlConnection conn, SqlTransaction trans, List<Model.channel_field> models, int channel_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,field_id from " + databaseprefix + "channel_field");
            strSql.Append(" where channel_id=" + channel_id);
            DataSet ds = DbHelperSQL.Query(conn, trans, strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Model.channel_field model = models.Find(p => p.field_id == int.Parse(dr["field_id"].ToString())); //查找对应的字段ID
                if (model == null)
                {
                    DbHelperSQL.ExecuteSql(conn, trans, "delete from " + databaseprefix + "channel_field where channel_id=" + channel_id + " and field_id=" + dr["field_id"].ToString()); //删除该字段
                }
            }
        }
        /// <summary>
        /// 删除及重建该频道视图
        /// </summary>
        public void RehabChannelViews(SqlConnection conn, SqlTransaction trans, Model.channel model, string old_name)
        {
            //删除旧的视图
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("if exists (select 1 from sysobjects where id = object_id('view_channel_" + old_name + "') and type = 'V')");
            strSql1.Append("drop view view_channel_" + old_name);
            DbHelperSQL.ExecuteSql(conn, trans, strSql1.ToString());
            //添加视图
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("CREATE VIEW view_channel_" + model.name + " as");
            strSql2.Append(" SELECT " + databaseprefix + "article.*");
            if (model.channel_fields != null)
            {
                foreach (Model.channel_field modelt in model.channel_fields)
                {
                    Model.article_attribute_field fieldModel = new DAL.article_attribute_field(databaseprefix).GetModel(modelt.field_id);
                    if (fieldModel != null)
                    {
                        strSql2.Append("," + databaseprefix + "article_attribute_value." + fieldModel.name);
                    }
                }
            }
            strSql2.Append(" FROM " + databaseprefix + "article_attribute_value INNER JOIN");
            strSql2.Append(" " + databaseprefix + "article ON " + databaseprefix + "article_attribute_value.article_id = " + databaseprefix + "article.id");
            strSql2.Append(" WHERE " + databaseprefix + "article.channel_id=" + model.id);
            DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString());
        }
        #endregion
    }
}