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
    /// 数据访问类:系统导航菜单
    /// </summary>
    public partial class navigation
    {
        private string databaseprefix; //数据库表名前缀
        public navigation(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        #region 基本方法========================================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "navigation");
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
            strSql.Append("select count(1) from " + databaseprefix + "navigation");
            strSql.Append(" where name=@name ");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,50)};
            parameters[0].Value = name;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 快捷添加系统默认导航
        /// </summary>
        public int Add(int parent_id, string nav_name, string title, string link_url, int sort_id, int channel_id, string action_type)
        {
            if (parent_id < 1)
            {
                return 0;
            }
            //开始赋值
            Model.navigation model = new Model.navigation();
            model.nav_type = MXEnums.NavigationEnum.System.ToString();
            model.name = nav_name;
            model.title = title;
            model.link_url = link_url;
            if (sort_id > 0)
            {
                model.sort_id = sort_id;
            }
            model.parent_id = parent_id;
            if (channel_id > 0)
            {
                model.channel_id = channel_id;
            }
            model.action_type = action_type;
            model.is_sys = 1;
            return Add(model);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.navigation model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into " + databaseprefix + "navigation(");
                        strSql.Append("nav_type,name,title,sub_title,link_url,sort_id,is_lock,remark,parent_id,class_list,class_layer,channel_id,action_type,is_sys)");
                        strSql.Append(" values (");
                        strSql.Append("@nav_type,@name,@title,@sub_title,@link_url,@sort_id,@is_lock,@remark,@parent_id,@class_list,@class_layer,@channel_id,@action_type,@is_sys)");
                        strSql.Append(";select @@IDENTITY");
                        SqlParameter[] parameters = {
					            new SqlParameter("@nav_type", SqlDbType.NVarChar,50),
					            new SqlParameter("@name", SqlDbType.NVarChar,50),
					            new SqlParameter("@title", SqlDbType.NVarChar,100),
					            new SqlParameter("@sub_title", SqlDbType.NVarChar,100),
					            new SqlParameter("@link_url", SqlDbType.NVarChar,255),
					            new SqlParameter("@sort_id", SqlDbType.Int,4),
					            new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
					            new SqlParameter("@remark", SqlDbType.NVarChar,500),
					            new SqlParameter("@parent_id", SqlDbType.Int,4),
					            new SqlParameter("@class_list", SqlDbType.NVarChar,500),
					            new SqlParameter("@class_layer", SqlDbType.Int,4),
                                new SqlParameter("@channel_id", SqlDbType.Int,4),
                                new SqlParameter("@action_type", SqlDbType.NVarChar,500),
                                new SqlParameter("@is_sys", SqlDbType.TinyInt,1)};
                        parameters[0].Value = model.nav_type;
                        parameters[1].Value = model.name;
                        parameters[2].Value = model.title;
                        parameters[3].Value = model.sub_title;
                        parameters[4].Value = model.link_url;
                        parameters[5].Value = model.sort_id;
                        parameters[6].Value = model.is_lock;
                        parameters[7].Value = model.remark;
                        parameters[8].Value = model.parent_id;
                        parameters[9].Value = model.class_list;
                        parameters[10].Value = model.class_layer;
                        parameters[11].Value = model.channel_id;
                        parameters[12].Value = model.action_type;
                        parameters[13].Value = model.is_sys;
                        object obj = DbHelperSQL.GetSingle(conn, trans, strSql.ToString(), parameters); //带事务

                        model.id = Convert.ToInt32(obj); //得到刚插入的新ID
                        if (model.parent_id > 0)
                        {
                            Model.navigation model2 = GetModel(conn, trans, model.parent_id); //带事务
                            model.class_list = model2.class_list + model.id + ",";
                            model.class_layer = model2.class_layer + 1;
                        }
                        else
                        {
                            model.class_list = "," + model.id + ",";
                            model.class_layer = 1;
                        }
                        //修改节点列表和深度
                        DbHelperSQL.ExecuteSql(conn, trans, "update " + databaseprefix + "navigation set class_list='" + model.class_list + "', class_layer=" + model.class_layer + " where id=" + model.id); //带事务
                        //如无异常则提交事务
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
        public bool UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "navigation set " + strValue);
            strSql.Append(" where id=" + id);
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
        /// 修改一列数据
        /// </summary>
        public bool UpdateField(string name, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "navigation set " + strValue);
            strSql.Append(" where name='" + name + "'");
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
        /// 修改导航名称和标题
        /// </summary>
        public bool Update(string old_name, string new_name, string title)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "navigation set ");
            strSql.Append("name=@new_name,");
            strSql.Append("title=@title");
            strSql.Append(" where name=@old_name");
            SqlParameter[] parameters = {
					new SqlParameter("@new_name", SqlDbType.NVarChar,50),
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@old_name", SqlDbType.NVarChar,50)};
            parameters[0].Value = new_name;
            parameters[1].Value = title;
            parameters[2].Value = old_name;
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
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.navigation model)
        {
            Model.navigation oldModel = GetModel(model.id); //旧的数据
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        //先判断选中的父节点是否被包含
                        if (IsContainNode(model.id, model.parent_id))
                        {
                            //查找旧父节点数据
                            string class_list = "," + model.parent_id + ",";
                            int class_layer = 1;
                            if (oldModel.parent_id > 0)
                            {
                                Model.navigation oldParentModel = GetModel(conn, trans, oldModel.parent_id); //带事务
                                class_list = oldParentModel.class_list + model.parent_id + ",";
                                class_layer = oldParentModel.class_layer + 1;
                            }
                            //先提升选中的父节点
                            DbHelperSQL.ExecuteSql(conn, trans, "update " + databaseprefix + "navigation set parent_id=" + oldModel.parent_id + ",class_list='" + class_list + "', class_layer=" + class_layer + " where id=" + model.parent_id); //带事务
                            UpdateChilds(conn, trans, model.parent_id); //带事务
                        }
                        //更新子节点
                        if (model.parent_id > 0)
                        {
                            Model.navigation model2 = GetModel(conn, trans, model.parent_id); //带事务
                            model.class_list = model2.class_list + model.id + ",";
                            model.class_layer = model2.class_layer + 1;
                        }
                        else
                        {
                            model.class_list = "," + model.id + ",";
                            model.class_layer = 1;
                        }
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update " + databaseprefix + "navigation set ");
                        strSql.Append("nav_type=@nav_type,");
                        strSql.Append("name=@name,");
                        strSql.Append("title=@title,");
                        strSql.Append("sub_title=@sub_title,");
                        strSql.Append("link_url=@link_url,");
                        strSql.Append("sort_id=@sort_id,");
                        strSql.Append("is_lock=@is_lock,");
                        strSql.Append("remark=@remark,");
                        strSql.Append("parent_id=@parent_id,");
                        strSql.Append("class_list=@class_list,");
                        strSql.Append("class_layer=@class_layer,");
                        strSql.Append("channel_id=@channel_id,");
                        strSql.Append("action_type=@action_type,");
                        strSql.Append("is_sys=@is_sys");
                        strSql.Append(" where id=@id");
                        SqlParameter[] parameters = {
					            new SqlParameter("@nav_type", SqlDbType.NVarChar,50),
					            new SqlParameter("@name", SqlDbType.NVarChar,50),
					            new SqlParameter("@title", SqlDbType.NVarChar,100),
					            new SqlParameter("@sub_title", SqlDbType.NVarChar,100),
					            new SqlParameter("@link_url", SqlDbType.NVarChar,255),
					            new SqlParameter("@sort_id", SqlDbType.Int,4),
					            new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
					            new SqlParameter("@remark", SqlDbType.NVarChar,500),
					            new SqlParameter("@parent_id", SqlDbType.Int,4),
					            new SqlParameter("@class_list", SqlDbType.NVarChar,500),
					            new SqlParameter("@class_layer", SqlDbType.Int,4),
                                new SqlParameter("@channel_id", SqlDbType.Int,4),
                                new SqlParameter("@action_type", SqlDbType.NVarChar,500),
                                new SqlParameter("@is_sys", SqlDbType.TinyInt,1),
                                new SqlParameter("@id", SqlDbType.Int,4)};
                        parameters[0].Value = model.nav_type;
                        parameters[1].Value = model.name;
                        parameters[2].Value = model.title;
                        parameters[3].Value = model.sub_title;
                        parameters[4].Value = model.link_url;
                        parameters[5].Value = model.sort_id;
                        parameters[6].Value = model.is_lock;
                        parameters[7].Value = model.remark;
                        parameters[8].Value = model.parent_id;
                        parameters[9].Value = model.class_list;
                        parameters[10].Value = model.class_layer;
                        parameters[11].Value = model.channel_id;
                        parameters[12].Value = model.action_type;
                        parameters[13].Value = model.is_sys;
                        parameters[14].Value = model.id;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);
                        //更新子节点
                        UpdateChilds(conn, trans, model.id);
                        //如无发生错误则提交事务
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "navigation ");
            strSql.Append(" where class_list like '%," + id + ",%' ");
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
        public Model.navigation GetModel(string nav_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,nav_type,name,title,sub_title,link_url,sort_id,is_lock,remark,parent_id,class_list,class_layer,channel_id,action_type,is_sys");
            strSql.Append(" from " + databaseprefix + "navigation ");
            strSql.Append(" where name=@nav_name");
            SqlParameter[] parameters = {
					new SqlParameter("@nav_name", SqlDbType.NVarChar,50)};
            parameters[0].Value = nav_name;

            Model.navigation model = new Model.navigation();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.nav_type = ds.Tables[0].Rows[0]["nav_type"].ToString();
                model.name = ds.Tables[0].Rows[0]["name"].ToString();
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.sub_title = ds.Tables[0].Rows[0]["sub_title"].ToString();
                model.link_url = ds.Tables[0].Rows[0]["link_url"].ToString();
                if (ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_lock"].ToString() != "")
                {
                    model.is_lock = int.Parse(ds.Tables[0].Rows[0]["is_lock"].ToString());
                }
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                if (ds.Tables[0].Rows[0]["parent_id"].ToString() != "")
                {
                    model.parent_id = int.Parse(ds.Tables[0].Rows[0]["parent_id"].ToString());
                }
                model.class_list = ds.Tables[0].Rows[0]["class_list"].ToString();
                if (ds.Tables[0].Rows[0]["class_layer"].ToString() != "")
                {
                    model.class_layer = int.Parse(ds.Tables[0].Rows[0]["class_layer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["channel_id"].ToString() != "")
                {
                    model.channel_id = int.Parse(ds.Tables[0].Rows[0]["channel_id"].ToString());
                }
                model.action_type = ds.Tables[0].Rows[0]["action_type"].ToString();
                if (ds.Tables[0].Rows[0]["is_sys"].ToString() != "")
                {
                    model.is_sys = int.Parse(ds.Tables[0].Rows[0]["is_sys"].ToString());
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
        public Model.navigation GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,nav_type,name,title,sub_title,link_url,sort_id,is_lock,remark,parent_id,class_list,class_layer,channel_id,action_type,is_sys");
            strSql.Append(" from " + databaseprefix + "navigation ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.navigation model = new Model.navigation();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.nav_type = ds.Tables[0].Rows[0]["nav_type"].ToString();
                model.name = ds.Tables[0].Rows[0]["name"].ToString();
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.sub_title = ds.Tables[0].Rows[0]["sub_title"].ToString();
                model.link_url = ds.Tables[0].Rows[0]["link_url"].ToString();
                if (ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_lock"].ToString() != "")
                {
                    model.is_lock = int.Parse(ds.Tables[0].Rows[0]["is_lock"].ToString());
                }
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                if (ds.Tables[0].Rows[0]["parent_id"].ToString() != "")
                {
                    model.parent_id = int.Parse(ds.Tables[0].Rows[0]["parent_id"].ToString());
                }
                model.class_list = ds.Tables[0].Rows[0]["class_list"].ToString();
                if (ds.Tables[0].Rows[0]["class_layer"].ToString() != "")
                {
                    model.class_layer = int.Parse(ds.Tables[0].Rows[0]["class_layer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["channel_id"].ToString() != "")
                {
                    model.channel_id = int.Parse(ds.Tables[0].Rows[0]["channel_id"].ToString());
                }
                model.action_type = ds.Tables[0].Rows[0]["action_type"].ToString();
                if (ds.Tables[0].Rows[0]["is_sys"].ToString() != "")
                {
                    model.is_sys = int.Parse(ds.Tables[0].Rows[0]["is_sys"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体(重载，带事务)
        /// </summary>
        public Model.navigation GetModel(SqlConnection conn, SqlTransaction trans, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,nav_type,name,title,sub_title,link_url,sort_id,is_lock,remark,parent_id,class_list,class_layer,channel_id,action_type,is_sys");
            strSql.Append(" from " + databaseprefix + "navigation ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.navigation model = new Model.navigation();
            DataSet ds = DbHelperSQL.Query(conn, trans, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.nav_type = ds.Tables[0].Rows[0]["nav_type"].ToString();
                model.name = ds.Tables[0].Rows[0]["name"].ToString();
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.sub_title = ds.Tables[0].Rows[0]["sub_title"].ToString();
                model.link_url = ds.Tables[0].Rows[0]["link_url"].ToString();
                if (ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_lock"].ToString() != "")
                {
                    model.is_lock = int.Parse(ds.Tables[0].Rows[0]["is_lock"].ToString());
                }
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                if (ds.Tables[0].Rows[0]["parent_id"].ToString() != "")
                {
                    model.parent_id = int.Parse(ds.Tables[0].Rows[0]["parent_id"].ToString());
                }
                model.class_list = ds.Tables[0].Rows[0]["class_list"].ToString();
                if (ds.Tables[0].Rows[0]["class_layer"].ToString() != "")
                {
                    model.class_layer = int.Parse(ds.Tables[0].Rows[0]["class_layer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["channel_id"].ToString() != "")
                {
                    model.channel_id = int.Parse(ds.Tables[0].Rows[0]["channel_id"].ToString());
                }
                model.action_type = ds.Tables[0].Rows[0]["action_type"].ToString();
                if (ds.Tables[0].Rows[0]["is_sys"].ToString() != "")
                {
                    model.is_sys = int.Parse(ds.Tables[0].Rows[0]["is_sys"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 取得指定类别下的列表
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="nav_type">导航类别</param>
        /// <returns>DataTable</returns>
        public DataTable GetChildList(int parent_id, string nav_type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,nav_type,name,title,sub_title,link_url,sort_id,is_lock,remark,parent_id,class_list,class_layer,channel_id,action_type,is_sys");
            strSql.Append(" from " + databaseprefix + "navigation");
            strSql.Append(" where nav_type='" + nav_type + "' and parent_id=" + parent_id + " order by sort_id asc,id asc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds.Tables[0];
        }

        /// <summary>
        /// 取得所有类别列表(没有排序好，只有数据)
        /// </summary>
        /// <param name="parent_id">父ID，0为所有类别</param>
        /// <param name="nav_type">导航类别</param>
        /// <returns>DataTable</returns>
        public DataTable GetDataList(int parent_id, string nav_type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,nav_type,name,title,sub_title,link_url,sort_id,is_lock,remark,parent_id,class_list,class_layer,channel_id,action_type,is_sys");
            strSql.Append(" FROM " + databaseprefix + "navigation");
            strSql.Append(" where nav_type='" + nav_type + "' order by sort_id asc,id asc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds.Tables[0];
        }

        /// <summary>
        /// 取得所有类别列表(已经排序好)
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="nav_type">导航类别</param>
        /// <returns>DataTable</returns>
        public DataTable GetList(int parent_id, string nav_type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,nav_type,name,title,sub_title,link_url,sort_id,is_lock,remark,parent_id,class_list,class_layer,channel_id,action_type,is_sys");
            strSql.Append(" FROM " + databaseprefix + "navigation");
            strSql.Append(" where nav_type='" + nav_type + "' order by sort_id asc,id asc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            DataTable oldData = ds.Tables[0] as DataTable;
            if (oldData == null)
            {
                return null;
            }
            //复制结构
            DataTable newData = oldData.Clone();
            //调用迭代组合成DAGATABLE
            GetChilds(oldData, newData, parent_id);
            return newData;
        }

        #endregion

        #region 扩展方法================================
        /// <summary>
        /// 根据导航的名称查询其ID
        /// </summary>
        public int GetNavId(string nav_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id from " + databaseprefix + "navigation");
            strSql.Append(" where name=@nav_name");
            SqlParameter[] parameters = {
					new SqlParameter("@nav_name", SqlDbType.NVarChar,50)};
            parameters[0].Value = nav_name;
            string str = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
            return Utils.StrToInt(str, 0);
        }
        #endregion

        #region 私有方法================================
        /// <summary>
        /// 从内存中取得所有下级类别列表（自身迭代）
        /// </summary>
        private void GetChilds(DataTable oldData, DataTable newData, int parent_id)
        {
            DataRow[] dr = oldData.Select("parent_id=" + parent_id);
            for (int i = 0; i < dr.Length; i++)
            {
                //添加一行数据
                DataRow row = newData.NewRow();
                row["id"] = int.Parse(dr[i]["id"].ToString());
                row["nav_type"] = dr[i]["nav_type"].ToString();
                row["name"] = dr[i]["name"].ToString();
                row["title"] = dr[i]["title"].ToString();
                row["sub_title"] = dr[i]["sub_title"].ToString();
                row["link_url"] = dr[i]["link_url"].ToString();
                row["sort_id"] = int.Parse(dr[i]["sort_id"].ToString());
                row["is_lock"] = int.Parse(dr[i]["is_lock"].ToString());
                row["remark"] = dr[i]["remark"].ToString();
                row["parent_id"] = int.Parse(dr[i]["parent_id"].ToString());
                row["class_list"] = dr[i]["class_list"].ToString();
                row["class_layer"] = int.Parse(dr[i]["class_layer"].ToString());
                row["channel_id"] = int.Parse(dr[i]["channel_id"].ToString());
                row["action_type"] = dr[i]["action_type"].ToString();
                row["is_sys"] = int.Parse(dr[i]["is_sys"].ToString());
                newData.Rows.Add(row);
                //调用自身迭代
                this.GetChilds(oldData, newData, int.Parse(dr[i]["id"].ToString()));
            }
        }

        /// <summary>
        /// 修改子节点的ID列表及深度（自身迭代）
        /// </summary>
        /// <param name="parent_id"></param>
        private void UpdateChilds(SqlConnection conn, SqlTransaction trans, int parent_id)
        {
            //查找父节点信息
            Model.navigation model = GetModel(conn, trans, parent_id);
            if (model != null)
            {
                //查找子节点
                string strSql = "select id from " + databaseprefix + "navigation where parent_id=" + parent_id;
                DataSet ds = DbHelperSQL.Query(conn, trans, strSql); //带事务
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //修改子节点的ID列表及深度
                    int id = int.Parse(dr["id"].ToString());
                    string class_list = model.class_list + id + ",";
                    int class_layer = model.class_layer + 1;
                    DbHelperSQL.ExecuteSql(conn, trans, "update " + databaseprefix + "navigation set class_list='" + class_list + "', class_layer=" + class_layer + " where id=" + id); //带事务

                    //调用自身迭代
                    this.UpdateChilds(conn, trans, id); //带事务
                }
            }
        }

        /// <summary>
        /// 验证节点是否被包含
        /// </summary>
        /// <param name="id">待查询的节点</param>
        /// <param name="parent_id">父节点</param>
        /// <returns></returns>
        private bool IsContainNode(int id, int parent_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "navigation ");
            strSql.Append(" where class_list like '%," + id + ",%' and id=" + parent_id);
            return DbHelperSQL.Exists(strSql.ToString());
        }

        #endregion
    }
}