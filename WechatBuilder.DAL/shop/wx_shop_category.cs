using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;
using System.Collections.Generic;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_shop_category
	/// </summary>
	public partial class wx_shop_category
	{
		public wx_shop_category()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_shop_category"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_shop_category");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
	 
		
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wx_shop_category ");
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
		public WechatBuilder.Model.wx_shop_category GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,title,code,parent_id,class_list,class_layer,sort_id,link_url,img_url,class_content,remark,seo_title,seo_keywords,seo_description,wid,ico_url from wx_shop_category ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_shop_category model=new WechatBuilder.Model.wx_shop_category();
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
		public WechatBuilder.Model.wx_shop_category DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_shop_category model=new WechatBuilder.Model.wx_shop_category();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["code"]!=null)
				{
					model.code=row["code"].ToString();
				}
				if(row["parent_id"]!=null && row["parent_id"].ToString()!="")
				{
					model.parent_id=int.Parse(row["parent_id"].ToString());
				}
				if(row["class_list"]!=null)
				{
					model.class_list=row["class_list"].ToString();
				}
				if(row["class_layer"]!=null && row["class_layer"].ToString()!="")
				{
					model.class_layer=int.Parse(row["class_layer"].ToString());
				}
				if(row["sort_id"]!=null && row["sort_id"].ToString()!="")
				{
					model.sort_id=int.Parse(row["sort_id"].ToString());
				}
				if(row["link_url"]!=null)
				{
					model.link_url=row["link_url"].ToString();
				}
				if(row["img_url"]!=null)
				{
					model.img_url=row["img_url"].ToString();
				}
				if(row["class_content"]!=null)
				{
					model.class_content=row["class_content"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["seo_title"]!=null)
				{
					model.seo_title=row["seo_title"].ToString();
				}
				if(row["seo_keywords"]!=null)
				{
					model.seo_keywords=row["seo_keywords"].ToString();
				}
				if(row["seo_description"]!=null)
				{
					model.seo_description=row["seo_description"].ToString();
				}
				if(row["wid"]!=null && row["wid"].ToString()!="")
				{
					model.wid=int.Parse(row["wid"].ToString());
				}
				if(row["ico_url"]!=null)
				{
					model.ico_url=row["ico_url"].ToString();
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
			strSql.Append("select id,title,code,parent_id,class_list,class_layer,sort_id,link_url,img_url,class_content,remark,seo_title,seo_keywords,seo_description,wid,ico_url ");
			strSql.Append(" FROM wx_shop_category ");
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
			strSql.Append(" id,title,code,parent_id,class_list,class_layer,sort_id,link_url,img_url,class_content,remark,seo_title,seo_keywords,seo_description,wid,ico_url ");
			strSql.Append(" FROM wx_shop_category ");
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
			strSql.Append("select count(1) FROM wx_shop_category ");
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
			strSql.Append(")AS Row, T.*  from wx_shop_category T ");
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
        /// 修改子节点的ID列表及深度（自身迭代）
        /// </summary>
        /// <param name="parent_id"></param>
        private void UpdateChilds(SqlConnection conn, SqlTransaction trans, int parent_id)
        {
            //查找父节点信息
            Model.wx_shop_category model = GetModel(conn, trans, parent_id);
            if (model != null)
            {
                //查找子节点
                string strSql = "select id from wx_shop_category where parent_id=" + parent_id;
                DataSet ds = DbHelperSQL.Query(conn, trans, strSql); //带事务
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //修改子节点的ID列表及深度
                    int id = int.Parse(dr["id"].ToString());
                    string class_list = model.class_list + id + ",";
                    int class_layer = model.class_layer.Value + 1;
                    DbHelperSQL.ExecuteSql(conn, trans, "update wx_shop_category set class_list='" + class_list + "', class_layer=" + class_layer + " where id=" + id); //带事务

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
            strSql.Append("select count(1) from  wx_shop_category ");
            strSql.Append(" where class_list like '%," + id + ",%' and id=" + parent_id);
            return DbHelperSQL.Exists(strSql.ToString());
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.wx_shop_category model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into wx_shop_category(");
                        strSql.Append("title,parent_id,class_list,class_layer,sort_id,link_url,img_url,class_content,seo_title,seo_keywords,seo_description,wid,ico_url)");
                        strSql.Append(" values (");
                        strSql.Append("@title,@parent_id,@class_list,@class_layer,@sort_id,@link_url,@img_url,@class_content,@seo_title,@seo_keywords,@seo_description,@wid,@ico_url)");
                        strSql.Append(";select @@IDENTITY");
                        SqlParameter[] parameters = { 
					            new SqlParameter("@title", SqlDbType.NVarChar,100),
					            new SqlParameter("@parent_id", SqlDbType.Int,4),
					            new SqlParameter("@class_list", SqlDbType.NVarChar,500),
					            new SqlParameter("@class_layer", SqlDbType.Int,4),
					            new SqlParameter("@sort_id", SqlDbType.Int,4),
					            new SqlParameter("@link_url", SqlDbType.NVarChar,255),
					            new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					            new SqlParameter("@class_content", SqlDbType.NText),
					            new SqlParameter("@seo_title", SqlDbType.NVarChar,255),
					            new SqlParameter("@seo_keywords", SqlDbType.NVarChar,255),
					            new SqlParameter("@seo_description", SqlDbType.NVarChar,255),
                                new SqlParameter("@wid", SqlDbType.Int,4),
                                new SqlParameter("@ico_url", SqlDbType.NVarChar,500)};
                        parameters[0].Value = model.title;
                        parameters[1].Value = model.parent_id;
                        parameters[2].Value = model.class_list;
                        parameters[3].Value = model.class_layer;
                        parameters[4].Value = model.sort_id;
                        parameters[5].Value = model.link_url;
                        parameters[6].Value = model.img_url;
                        parameters[7].Value = model.class_content;
                        parameters[8].Value = model.seo_title;
                        parameters[9].Value = model.seo_keywords;
                        parameters[10].Value = model.seo_description;
                        parameters[11].Value = model.wid;
                        parameters[12].Value = model.ico_url;
                        object obj = DbHelperSQL.GetSingle(conn, trans, strSql.ToString(), parameters); //带事务
                        model.id = Convert.ToInt32(obj);

                        if (model.parent_id > 0)
                        {
                            Model.wx_shop_category model2 = GetModel(conn, trans, model.parent_id.Value); //带事务
                            model.class_list = model2.class_list + model.id + ",";
                            model.class_layer = model2.class_layer + 1;
                        }
                        else
                        {
                            model.class_list = "," + model.id + ",";
                            model.class_layer = 1;
                        }
                        //修改节点列表和深度
                        DbHelperSQL.ExecuteSql(conn, trans, "update wx_shop_category set class_list='" + model.class_list + "', class_layer=" + model.class_layer + " where id=" + model.id); //带事务
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
        /// 得到一个对象实体(重载，带事务)
        /// </summary>
        public Model.wx_shop_category GetModel(SqlConnection conn, SqlTransaction trans, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  id,title,code,parent_id,class_list,class_layer,sort_id,link_url,img_url,class_content,remark,seo_title,seo_keywords,seo_description,wid,ico_url from wx_shop_category  ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.wx_shop_category model = new Model.wx_shop_category();
            DataSet ds = DbHelperSQL.Query(conn, trans, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                 
                if (ds.Tables[0].Rows[0]["title"] != null && ds.Tables[0].Rows[0]["title"].ToString() != "")
                {
                    model.title = ds.Tables[0].Rows[0]["title"].ToString();
                }
                
                if (ds.Tables[0].Rows[0]["parent_id"] != null && ds.Tables[0].Rows[0]["parent_id"].ToString() != "")
                {
                    model.parent_id = int.Parse(ds.Tables[0].Rows[0]["parent_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["class_list"] != null && ds.Tables[0].Rows[0]["class_list"].ToString() != "")
                {
                    model.class_list = ds.Tables[0].Rows[0]["class_list"].ToString();
                }
                if (ds.Tables[0].Rows[0]["class_layer"] != null && ds.Tables[0].Rows[0]["class_layer"].ToString() != "")
                {
                    model.class_layer = int.Parse(ds.Tables[0].Rows[0]["class_layer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sort_id"] != null && ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["link_url"] != null && ds.Tables[0].Rows[0]["link_url"].ToString() != "")
                {
                    model.link_url = ds.Tables[0].Rows[0]["link_url"].ToString();
                }
                if (ds.Tables[0].Rows[0]["img_url"] != null && ds.Tables[0].Rows[0]["img_url"].ToString() != "")
                {
                    model.img_url = ds.Tables[0].Rows[0]["img_url"].ToString();
                }
                if (ds.Tables[0].Rows[0]["class_content"] != null && ds.Tables[0].Rows[0]["class_content"].ToString() != "")
                {
                    model.class_content = ds.Tables[0].Rows[0]["class_content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["seo_title"] != null && ds.Tables[0].Rows[0]["seo_title"].ToString() != "")
                {
                    model.seo_title = ds.Tables[0].Rows[0]["seo_title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["seo_keywords"] != null && ds.Tables[0].Rows[0]["seo_keywords"].ToString() != "")
                {
                    model.seo_keywords = ds.Tables[0].Rows[0]["seo_keywords"].ToString();
                }
                if (ds.Tables[0].Rows[0]["seo_description"] != null && ds.Tables[0].Rows[0]["seo_description"].ToString() != "")
                {
                    model.seo_description = ds.Tables[0].Rows[0]["seo_description"].ToString();
                }

                if (ds.Tables[0].Rows[0]["ico_url"] != null && ds.Tables[0].Rows[0]["ico_url"].ToString() != "")
                {
                    model.ico_url = ds.Tables[0].Rows[0]["ico_url"].ToString();
                }

                if (ds.Tables[0].Rows[0]["wid"] != null && ds.Tables[0].Rows[0]["wid"].ToString() != "")
                {
                    model.wid = int.Parse(ds.Tables[0].Rows[0]["wid"].ToString());
                }


                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.wx_shop_category model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        //先判断选中的父节点是否被包含
                        if (IsContainNode(model.id, model.parent_id.Value))
                        {
                            //查找旧数据
                            Model.wx_shop_category oldModel = GetModel(model.id);
                            //查找旧父节点数据
                            string class_list = "," + model.parent_id + ",";
                            int class_layer = 1;
                            if (oldModel.parent_id > 0)
                            {
                                Model.wx_shop_category oldParentModel = GetModel(conn, trans, oldModel.parent_id.Value); //带事务
                                class_list = oldParentModel.class_list + model.parent_id + ",";
                                class_layer = oldParentModel.class_layer.Value + 1;
                            }
                            //先提升选中的父节点
                            DbHelperSQL.ExecuteSql(conn, trans, "update wx_shop_category set parent_id=" + oldModel.parent_id + ",class_list='" + class_list + "', class_layer=" + class_layer + " where id=" + model.parent_id); //带事务
                            UpdateChilds(conn, trans, model.parent_id.Value); //带事务
                        }
                        //更新子节点
                        if (model.parent_id > 0)
                        {
                            Model.wx_shop_category model2 = GetModel(conn, trans, model.parent_id.Value); //带事务
                            model.class_list = model2.class_list + model.id + ",";
                            model.class_layer = model2.class_layer + 1;
                        }
                        else
                        {
                            model.class_list = "," + model.id + ",";
                            model.class_layer = 1;
                        }

                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update wx_shop_category set ");
                        strSql.Append("title=@title,");                    
                        strSql.Append("parent_id=@parent_id,");
                        strSql.Append("class_list=@class_list,");
                        strSql.Append("class_layer=@class_layer,");
                        strSql.Append("sort_id=@sort_id,");
                        strSql.Append("link_url=@link_url,");
                        strSql.Append("img_url=@img_url,");
                        strSql.Append("class_content=@class_content,");
                        strSql.Append("seo_title=@seo_title,");
                        strSql.Append("seo_keywords=@seo_keywords,");
                        strSql.Append("seo_description=@seo_description,");
                        strSql.Append("wid=@wid,");
                        strSql.Append("ico_url=@ico_url");
                        strSql.Append(" where id=@id");
                        SqlParameter[] parameters = {
					            new SqlParameter("@title", SqlDbType.NVarChar,100),
					            new SqlParameter("@parent_id", SqlDbType.Int,4),
					            new SqlParameter("@class_list", SqlDbType.NVarChar,500),
					            new SqlParameter("@class_layer", SqlDbType.Int,4),
					            new SqlParameter("@sort_id", SqlDbType.Int,4),
					            new SqlParameter("@link_url", SqlDbType.NVarChar,255),
					            new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					            new SqlParameter("@class_content", SqlDbType.NText),
					            new SqlParameter("@seo_title", SqlDbType.NVarChar,255),
					            new SqlParameter("@seo_keywords", SqlDbType.NVarChar,255),
					            new SqlParameter("@seo_description", SqlDbType.NVarChar,255),
                                new SqlParameter("@wid", SqlDbType.Int,4),
                                new SqlParameter("@ico_url", SqlDbType.NVarChar,500),
					            new SqlParameter("@id", SqlDbType.Int,4)};
                        parameters[0].Value = model.title;                   
                        parameters[1].Value = model.parent_id;
                        parameters[2].Value = model.class_list;
                        parameters[3].Value = model.class_layer;
                        parameters[4].Value = model.sort_id;
                        parameters[5].Value = model.link_url;
                        parameters[6].Value = model.img_url;
                        parameters[7].Value = model.class_content;
                        parameters[8].Value = model.seo_title;
                        parameters[9].Value = model.seo_keywords;
                        parameters[10].Value = model.seo_description;
                        parameters[11].Value = model.wid;
                        parameters[12].Value = model.ico_url;
                        parameters[13].Value = model.id;

                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        //更新子节点
                        UpdateChilds(conn, trans, model.id);
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }


        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_shop_category set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


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
                row["title"] = dr[i]["title"].ToString();
                 row["remark"] = dr[i]["remark"].ToString();
                row["parent_id"] = int.Parse(dr[i]["parent_id"].ToString());
                row["class_list"] = dr[i]["class_list"].ToString();
                row["class_layer"] = int.Parse(dr[i]["class_layer"].ToString());
                row["sort_id"] = int.Parse(dr[i]["sort_id"].ToString());
                row["link_url"] = dr[i]["link_url"].ToString();
                row["img_url"] = dr[i]["img_url"].ToString();
                row["class_content"] = dr[i]["class_content"].ToString();
                row["seo_title"] = dr[i]["seo_title"].ToString();
                row["seo_keywords"] = dr[i]["seo_keywords"].ToString();
                row["seo_description"] = dr[i]["seo_description"].ToString();
                row["ico_url"] = dr[i]["ico_url"].ToString();
                row["wid"] = dr[i]["wid"].ToString();

                newData.Rows.Add(row);
                //调用自身迭代
                this.GetChilds(oldData, newData, int.Parse(dr[i]["id"].ToString()));
            }
        }


        /// <summary>
        /// 取得所有类别列表
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="channel_id">频道ID</param>
        /// <returns></returns>
        public DataTable GetWCodeList(int wid, int parent_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   id,title,code,parent_id,class_list,class_layer,sort_id,link_url,img_url,class_content,remark,seo_title,seo_keywords,seo_description,wid,ico_url from wx_shop_category ");
            strSql.Append(" where   wid=" + wid + "  order by sort_id asc,id desc");
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


        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  * from wx_shop_category ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }


      

		#endregion  ExtensionMethod

        #region 前台使用的方法，需要高效率

        /// <summary>
        /// 获得微帐号的分类信息
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="topNum">取前几条数据；若为-1，则不作筛选条件</param>
        /// <param name="parentId">若为-1，则不作筛选条件</param>
        /// <returns></returns>
        public IList<Model.wx_shop_category> GetCategoryListByWid(int wid, int topNum, int parentId, int class_layer)
        {
            IList<Model.wx_shop_category> categoryList = new List<Model.wx_shop_category>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (topNum >= 0)
            {
                strSql.Append(" top " + topNum + " ");
            }
            strSql.Append(" id,title,code,parent_id,class_list,class_layer,sort_id,link_url,img_url,class_content,remark,seo_title,seo_keywords,seo_description,wid,ico_url from wx_shop_category   where 1=1 ");
            if (parentId != -1)
            {
                strSql.Append(" and parent_id=" + parentId);
            }
            if (class_layer != -1)
            {
                strSql.Append(" and class_layer=" + class_layer);
            }

            strSql.Append(" and wid=@wid order by sort_id asc");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4)
			};
            parameters[0].Value = wid;
            SqlDataReader sr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters);
            Model.wx_shop_category category = new Model.wx_shop_category();
            while (sr.Read())
            {
                category = new Model.wx_shop_category();
                category.id = MyCommFun.Obj2Int(sr["id"]);
                category.title = MyCommFun.ObjToStr(sr["title"]);
                category.parent_id = MyCommFun.Obj2Int(sr["parent_id"]);
                category.class_layer = MyCommFun.Obj2Int(sr["class_layer"]);
                category.link_url = MyCommFun.ObjToStr(sr["link_url"]);
                category.img_url = MyCommFun.ObjToStr(sr["img_url"]);
                category.class_content = MyCommFun.ObjToStr(sr["class_content"]);
                category.ico_url = MyCommFun.ObjToStr(sr["ico_url"]);
                category.seo_title = MyCommFun.ObjToStr(sr["seo_title"]);
                category.seo_keywords = MyCommFun.ObjToStr(sr["seo_keywords"]);
                category.seo_description = MyCommFun.ObjToStr(sr["seo_description"]);
                categoryList.Add(category);
            }
            sr.Close();



            return categoryList;
        }

        /// <summary>
        /// 获得该分类信息，使用wid仅仅作为限制条件
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.wx_shop_category GetCategoryByWid(int wid, int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1");
            strSql.Append(" id,title,code,parent_id,class_list,class_layer,sort_id,link_url,img_url,class_content,remark,seo_title,seo_keywords,seo_description,wid,ico_url  ");
            strSql.Append(" from wx_shop_category  where   id=@id  and wid=@wid");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@wid", SqlDbType.Int,4)
			};
            parameters[0].Value = id;
            parameters[1].Value = wid;
            SqlDataReader sr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters);
            Model.wx_shop_category category = new Model.wx_shop_category();
            while (sr.Read())
            {
                category = new Model.wx_shop_category();
                category.id = MyCommFun.Obj2Int(sr["id"]);
                category.title = MyCommFun.ObjToStr(sr["title"]);
                category.parent_id = MyCommFun.Obj2Int(sr["parent_id"]);
                category.class_layer = MyCommFun.Obj2Int(sr["class_layer"]);
                category.link_url = MyCommFun.ObjToStr(sr["link_url"]);
                category.img_url = MyCommFun.ObjToStr(sr["img_url"]);
                category.class_content = MyCommFun.ObjToStr(sr["class_content"]);
                category.ico_url = MyCommFun.ObjToStr(sr["ico_url"]);
                category.seo_title = MyCommFun.ObjToStr(sr["seo_title"]);
                category.seo_keywords = MyCommFun.ObjToStr(sr["seo_keywords"]);
                category.seo_description = MyCommFun.ObjToStr(sr["seo_description"]);
            }
            sr.Close();
            return category;
        }

        /// <summary>
        /// 删除一条数据,并且不用商品占用
        /// </summary>
        public bool DeleteCategory(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_shop_category ");
            strSql.Append(" where id=@id and   id not in(select categoryId  from wx_shop_product) ");
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

        #endregion
    }
}

