using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_product_type
	/// </summary>
	public partial class wx_product_type
	{
		public wx_product_type()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_product_type"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_product_type");
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
		public int Add(WechatBuilder.Model.wx_product_type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_product_type(");
            strSql.Append("wid,parentId,tCode,tName,tUrl,class_layer,remark,icoPic,sort_id,creatDate,extStr,extStr2,store_id,tel,daohangurl,showDefault)");
			strSql.Append(" values (");
            strSql.Append("@wid,@parentId,@tCode,@tName,@tUrl,@class_layer,@remark,@icoPic,@sort_id,@creatDate,@extStr,@extStr2,@store_id,@tel,@daohangurl,@showDefault)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@parentId", SqlDbType.Int,4),
					new SqlParameter("@tCode", SqlDbType.VarChar,50),
					new SqlParameter("@tName", SqlDbType.VarChar,100),
					new SqlParameter("@tUrl", SqlDbType.VarChar,800),
					new SqlParameter("@class_layer", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,2000),
					new SqlParameter("@icoPic", SqlDbType.VarChar,800),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@creatDate", SqlDbType.DateTime),
					new SqlParameter("@extStr", SqlDbType.VarChar,800),
					new SqlParameter("@extStr2", SqlDbType.VarChar,2000),
					new SqlParameter("@store_id", SqlDbType.Int,4),
					new SqlParameter("@tel", SqlDbType.VarChar,100),
					new SqlParameter("@daohangurl", SqlDbType.VarChar,800),
					new SqlParameter("@showDefault", SqlDbType.Bit,1)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.parentId;
			parameters[2].Value = model.tCode;
			parameters[3].Value = model.tName;
			parameters[4].Value = model.tUrl;
			parameters[5].Value = model.class_layer;
			parameters[6].Value = model.remark;
			parameters[7].Value = model.icoPic;
			parameters[8].Value = model.sort_id;
			parameters[9].Value = model.creatDate;
			parameters[10].Value = model.extStr;
			parameters[11].Value = model.extStr2;
            parameters[12].Value = model.store_id;
            parameters[13].Value = model.tel;
            parameters[14].Value = model.daohangurl;
            parameters[15].Value = model.showDefault;

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
		public bool Update(WechatBuilder.Model.wx_product_type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_product_type set ");
			strSql.Append("wid=@wid,");
			strSql.Append("parentId=@parentId,");
			strSql.Append("tCode=@tCode,");
			strSql.Append("tName=@tName,");
			strSql.Append("tUrl=@tUrl,");
			strSql.Append("class_layer=@class_layer,");
			strSql.Append("remark=@remark,");
			strSql.Append("icoPic=@icoPic,");
			strSql.Append("sort_id=@sort_id,");
			strSql.Append("creatDate=@creatDate,");
			strSql.Append("extStr=@extStr,");
			strSql.Append("extStr2=@extStr2,");
            strSql.Append("store_id=@store_id,");
            strSql.Append("tel=@tel,");
            strSql.Append("daohangurl=@daohangurl,");
            strSql.Append("showDefault=@showDefault");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@parentId", SqlDbType.Int,4),
					new SqlParameter("@tCode", SqlDbType.VarChar,50),
					new SqlParameter("@tName", SqlDbType.VarChar,100),
					new SqlParameter("@tUrl", SqlDbType.VarChar,800),
					new SqlParameter("@class_layer", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,2000),
					new SqlParameter("@icoPic", SqlDbType.VarChar,800),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@creatDate", SqlDbType.DateTime),
					new SqlParameter("@extStr", SqlDbType.VarChar,800),
					new SqlParameter("@extStr2", SqlDbType.VarChar,2000),
                    new SqlParameter("@store_id", SqlDbType.Int,4),
                    new SqlParameter("@tel", SqlDbType.VarChar,100),
					new SqlParameter("@daohangurl", SqlDbType.VarChar,800),
                    new SqlParameter("@showDefault", SqlDbType.Bit,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.parentId;
			parameters[2].Value = model.tCode;
			parameters[3].Value = model.tName;
			parameters[4].Value = model.tUrl;
			parameters[5].Value = model.class_layer;
			parameters[6].Value = model.remark;
			parameters[7].Value = model.icoPic;
			parameters[8].Value = model.sort_id;
			parameters[9].Value = model.creatDate;
			parameters[10].Value = model.extStr;
			parameters[11].Value = model.extStr2;
            parameters[12].Value = model.store_id;
            parameters[13].Value = model.tel;
            parameters[14].Value = model.daohangurl;
            parameters[15].Value = model.showDefault;
            parameters[16].Value = model.id;

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
			strSql.Append("delete from wx_product_type ");
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
		public WechatBuilder.Model.wx_product_type GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,wid,parentId,tCode,tName,tUrl,class_layer,remark,icoPic,sort_id,creatDate,extStr,extStr2,store_id,tel,daohangurl,showDefault from wx_product_type ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_product_type model=new WechatBuilder.Model.wx_product_type();
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
		public WechatBuilder.Model.wx_product_type DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_product_type model=new WechatBuilder.Model.wx_product_type();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["wid"]!=null && row["wid"].ToString()!="")
				{
					model.wid=int.Parse(row["wid"].ToString());
				}
				if(row["parentId"]!=null && row["parentId"].ToString()!="")
				{
					model.parentId=int.Parse(row["parentId"].ToString());
				}
				if(row["tCode"]!=null)
				{
					model.tCode=row["tCode"].ToString();
				}
				if(row["tName"]!=null)
				{
					model.tName=row["tName"].ToString();
				}
				if(row["tUrl"]!=null)
				{
					model.tUrl=row["tUrl"].ToString();
				}
				if(row["class_layer"]!=null && row["class_layer"].ToString()!="")
				{
					model.class_layer=int.Parse(row["class_layer"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["icoPic"]!=null)
				{
					model.icoPic=row["icoPic"].ToString();
				}
				if(row["sort_id"]!=null && row["sort_id"].ToString()!="")
				{
					model.sort_id=int.Parse(row["sort_id"].ToString());
				}
				if(row["creatDate"]!=null && row["creatDate"].ToString()!="")
				{
					model.creatDate=DateTime.Parse(row["creatDate"].ToString());
				}
				if(row["extStr"]!=null)
				{
					model.extStr=row["extStr"].ToString();
				}
				if(row["extStr2"]!=null)
				{
					model.extStr2=row["extStr2"].ToString();
				}
                if (row["store_id"] != null && row["store_id"].ToString() != "")
                {
                    model.store_id = int.Parse(row["store_id"].ToString());
                }
                if (row["tel"] != null)
                {
                    model.tel = row["tel"].ToString();
                }
                if (row["daohangurl"] != null)
                {
                    model.daohangurl = row["daohangurl"].ToString();
                }
                if (row["showDefault"] != null && row["showDefault"].ToString() != "")
                {
                    if ((row["showDefault"].ToString() == "1") || (row["showDefault"].ToString().ToLower() == "true"))
                    {
                        model.showDefault = true;
                    }
                    else
                    {
                        model.showDefault = false;
                    }
                }

			}
			return model;
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
            strSql.Append(" id,wid,parentId,tCode,tName,tUrl,class_layer,remark,icoPic,sort_id,creatDate,extStr,extStr2,store_id,tel,daohangurl,showDefault  ");
			strSql.Append(" FROM wx_product_type ");
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
			strSql.Append("select count(1) FROM wx_product_type ");
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
			strSql.Append(")AS Row, T.*  from wx_product_type T ");
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,wid,parentId,tCode,tName,tUrl,class_layer,remark,icoPic,sort_id,creatDate,extStr,extStr2,store_id,tel,daohangurl,showDefault,(select title from wx_product_sys s where t.store_id=s.id) as storeName    ");
            strSql.Append(" FROM wx_product_type  t");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        
       /// <summary>
        /// 取得该微帐号的所有类别列表
       /// </summary>
       /// <param name="wid"></param>
       /// <returns></returns>
        public DataTable GetWCodeList(int wid, int parent_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,wid,parentId,tCode,tName,tUrl,class_layer,remark,icoPic,sort_id,creatDate,extStr,extStr2,store_id,tel,daohangurl,showDefault,(select title from wx_product_sys s where t.store_id=s.id) as storeName   from wx_product_type t ");
            strSql.Append(" where  wid=" + wid + "  order by sort_id asc,id desc");
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
        /// 从内存中取得所有下级类别列表（自身迭代）
        /// </summary>
        private void GetChilds(DataTable oldData, DataTable newData, int parent_id)
        {
            DataRow[] dr = oldData.Select("parentId=" + parent_id);
            for (int i = 0; i < dr.Length; i++)
            {
                //添加一行数据
                DataRow row = newData.NewRow();
                row["id"] = int.Parse(dr[i]["id"].ToString());
                row["tName"] = dr[i]["tName"].ToString();
                row["parentId"] = int.Parse(dr[i]["parentId"].ToString());
                row["tCode"] = dr[i]["tCode"].ToString();
                row["class_layer"] = int.Parse(dr[i]["class_layer"].ToString());
                row["sort_id"] = int.Parse(dr[i]["sort_id"].ToString());
                row["tUrl"] = dr[i]["tUrl"].ToString();
                row["icoPic"] = dr[i]["icoPic"].ToString();
                row["remark"] = dr[i]["remark"].ToString();
                row["wid"] = dr[i]["wid"].ToString();
                row["store_id"] =MyCommFun.Obj2Int( dr[i]["store_id"]);
                row["storeName"] = dr[i]["storeName"].ToString();

                row["tel"] = dr[i]["tel"].ToString();

                row["daohangurl"] = dr[i]["daohangurl"].ToString();
                row["showDefault"] = dr[i]["showDefault"] == null ? "0" : dr[i]["showDefault"];


                newData.Rows.Add(row);
                //调用自身迭代
                this.GetChilds(oldData, newData, int.Parse(dr[i]["id"].ToString()));
            }
        }


        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_product_type set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 返回类别名称
        /// </summary>
        public string GetTitle(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 tName from wx_product_type");
            strSql.Append(" where id=" + id);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_product_type ");
            strSql.Append(" where id=@id and id not in(select typeId from wx_product)");
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

