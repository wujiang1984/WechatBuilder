using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_yy_base
	/// </summary>
	public partial class wx_yy_base
	{
		public wx_yy_base()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_yy_base"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_yy_base");
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
		public int Add(WechatBuilder.Model.wx_yy_base model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_yy_base(");
            strSql.Append("wid,title,addr,phone,kfName,content,picUrl,beginDate,endDate,remark,extInt,extStr,extStr2,createDate,seq,needSMS)");
			strSql.Append(" values (");
            strSql.Append("@wid,@title,@addr,@phone,@kfName,@content,@picUrl,@beginDate,@endDate,@remark,@extInt,@extStr,@extStr2,@createDate,@seq,@needSMS)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@addr", SqlDbType.VarChar,700),
					new SqlParameter("@phone", SqlDbType.VarChar,50),
					new SqlParameter("@kfName", SqlDbType.VarChar,50),
					new SqlParameter("@content", SqlDbType.VarChar,1000),
					new SqlParameter("@picUrl", SqlDbType.VarChar,1000),
					new SqlParameter("@beginDate", SqlDbType.DateTime),
					new SqlParameter("@endDate", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.VarChar,2000),
					new SqlParameter("@extInt", SqlDbType.Int,4),
					new SqlParameter("@extStr", SqlDbType.VarChar,500),
					new SqlParameter("@extStr2", SqlDbType.VarChar,800),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@seq", SqlDbType.Int,4),
					new SqlParameter("@needSMS", SqlDbType.Bit,1)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.title;
			parameters[2].Value = model.addr;
			parameters[3].Value = model.phone;
			parameters[4].Value = model.kfName;
			parameters[5].Value = model.content;
			parameters[6].Value = model.picUrl;
			parameters[7].Value = model.beginDate;
			parameters[8].Value = model.endDate;
			parameters[9].Value = model.remark;
			parameters[10].Value = model.extInt;
			parameters[11].Value = model.extStr;
			parameters[12].Value = model.extStr2;
			parameters[13].Value = model.createDate;
			parameters[14].Value = model.seq;
            parameters[15].Value = model.needSMS;

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
		public bool Update(WechatBuilder.Model.wx_yy_base model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_yy_base set ");
			strSql.Append("wid=@wid,");
			strSql.Append("title=@title,");
			strSql.Append("addr=@addr,");
			strSql.Append("phone=@phone,");
			strSql.Append("kfName=@kfName,");
			strSql.Append("content=@content,");
			strSql.Append("picUrl=@picUrl,");
			strSql.Append("beginDate=@beginDate,");
			strSql.Append("endDate=@endDate,");
			strSql.Append("remark=@remark,");
			strSql.Append("extInt=@extInt,");
			strSql.Append("extStr=@extStr,");
			strSql.Append("extStr2=@extStr2,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("seq=@seq,");
            strSql.Append("needSMS=@needSMS");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@addr", SqlDbType.VarChar,700),
					new SqlParameter("@phone", SqlDbType.VarChar,50),
					new SqlParameter("@kfName", SqlDbType.VarChar,50),
					new SqlParameter("@content", SqlDbType.VarChar,1000),
					new SqlParameter("@picUrl", SqlDbType.VarChar,1000),
					new SqlParameter("@beginDate", SqlDbType.DateTime),
					new SqlParameter("@endDate", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.VarChar,2000),
					new SqlParameter("@extInt", SqlDbType.Int,4),
					new SqlParameter("@extStr", SqlDbType.VarChar,500),
					new SqlParameter("@extStr2", SqlDbType.VarChar,800),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@seq", SqlDbType.Int,4),
                    new SqlParameter("@needSMS", SqlDbType.Bit,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.title;
			parameters[2].Value = model.addr;
			parameters[3].Value = model.phone;
			parameters[4].Value = model.kfName;
			parameters[5].Value = model.content;
			parameters[6].Value = model.picUrl;
			parameters[7].Value = model.beginDate;
			parameters[8].Value = model.endDate;
			parameters[9].Value = model.remark;
			parameters[10].Value = model.extInt;
			parameters[11].Value = model.extStr;
			parameters[12].Value = model.extStr2;
			parameters[13].Value = model.createDate;
			parameters[14].Value = model.seq;
            parameters[15].Value = model.needSMS;
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wx_yy_base ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

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
			strSql.Append("delete from wx_yy_base ");
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
		public WechatBuilder.Model.wx_yy_base GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,wid,title,addr,phone,kfName,content,picUrl,beginDate,endDate,remark,extInt,extStr,extStr2,createDate,seq,needSMS from wx_yy_base ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_yy_base model=new WechatBuilder.Model.wx_yy_base();
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
		public WechatBuilder.Model.wx_yy_base DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_yy_base model=new WechatBuilder.Model.wx_yy_base();
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
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["addr"]!=null)
				{
					model.addr=row["addr"].ToString();
				}
				if(row["phone"]!=null)
				{
					model.phone=row["phone"].ToString();
				}
				if(row["kfName"]!=null)
				{
					model.kfName=row["kfName"].ToString();
				}
				if(row["content"]!=null)
				{
					model.content=row["content"].ToString();
				}
				if(row["picUrl"]!=null)
				{
					model.picUrl=row["picUrl"].ToString();
				}
				if(row["beginDate"]!=null && row["beginDate"].ToString()!="")
				{
					model.beginDate=DateTime.Parse(row["beginDate"].ToString());
				}
				if(row["endDate"]!=null && row["endDate"].ToString()!="")
				{
					model.endDate=DateTime.Parse(row["endDate"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["extInt"]!=null && row["extInt"].ToString()!="")
				{
					model.extInt=int.Parse(row["extInt"].ToString());
				}
				if(row["extStr"]!=null)
				{
					model.extStr=row["extStr"].ToString();
				}
				if(row["extStr2"]!=null)
				{
					model.extStr2=row["extStr2"].ToString();
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["seq"]!=null && row["seq"].ToString()!="")
				{
					model.seq=int.Parse(row["seq"].ToString());
				}
                if (row["needSMS"] != null && row["needSMS"].ToString() != "")
                {
                    if ((row["needSMS"].ToString() == "1") || (row["needSMS"].ToString().ToLower() == "true"))
                    {
                        model.needSMS = true;
                    }
                    else
                    {
                        model.needSMS = false;
                    }
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
            strSql.Append("select id,wid,title,addr,phone,kfName,content,picUrl,beginDate,endDate,remark,extInt,extStr,extStr2,createDate,seq,needSMS ");
			strSql.Append(" FROM wx_yy_base ");
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
            strSql.Append(" id,wid,title,addr,phone,kfName,content,picUrl,beginDate,endDate,remark,extInt,extStr,extStr2,createDate,seq,needSMS ");
			strSql.Append(" FROM wx_yy_base ");
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
			strSql.Append("select count(1) FROM wx_yy_base ");
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
			strSql.Append(")AS Row, T.*  from wx_yy_base T ");
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
            strSql.Append(" select  * from wx_yy_base ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 删除一条预约数据【主表，字段表，用户提交的结果表】
        /// </summary>
        public bool DeleteYuYue(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_yy_base where id=@id;");
            strSql.Append("delete from wx_yy_control where formId=@id;");
            strSql.Append("delete from wx_yy_result where formId=@id;");
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

