using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_product
	/// </summary>
	public partial class wx_product
	{
		public wx_product()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_product"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_product");
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
		public int Add(WechatBuilder.Model.wx_product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_product(");
            strSql.Append("wid,hdName,pSubject,typeId,beginDate,endDate,addr,pContent,minPersonNum,maxPersonNum,personContent,isOpen,createPerson,createDate,url,urlName,btnName,price,showPrice,showYuDing,showDate,extInt,extStr,extStr2,extStr3,tel,daohangurl)");
			strSql.Append(" values (");
            strSql.Append("@wid,@hdName,@pSubject,@typeId,@beginDate,@endDate,@addr,@pContent,@minPersonNum,@maxPersonNum,@personContent,@isOpen,@createPerson,@createDate,@url,@urlName,@btnName,@price,@showPrice,@showYuDing,@showDate,@extInt,@extStr,@extStr2,@extStr3,@tel,@daohangurl)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@hdName", SqlDbType.VarChar,200),
					new SqlParameter("@pSubject", SqlDbType.VarChar,500),
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@beginDate", SqlDbType.DateTime),
					new SqlParameter("@endDate", SqlDbType.DateTime),
					new SqlParameter("@addr", SqlDbType.VarChar,500),
					new SqlParameter("@pContent", SqlDbType.NText),
					new SqlParameter("@minPersonNum", SqlDbType.Int,4),
					new SqlParameter("@maxPersonNum", SqlDbType.Int,4),
					new SqlParameter("@personContent", SqlDbType.VarChar,500),
					new SqlParameter("@isOpen", SqlDbType.Bit,1),
					new SqlParameter("@createPerson", SqlDbType.VarChar,200),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@url", SqlDbType.VarChar,500),
					new SqlParameter("@urlName", SqlDbType.VarChar,100),
					new SqlParameter("@btnName", SqlDbType.VarChar,100),
					new SqlParameter("@price", SqlDbType.Float,8),
					new SqlParameter("@showPrice", SqlDbType.Bit,1),
					new SqlParameter("@showYuDing", SqlDbType.Bit,1),
					new SqlParameter("@showDate", SqlDbType.Bit,1),
					new SqlParameter("@extInt", SqlDbType.Int,4),
					new SqlParameter("@extStr", SqlDbType.VarChar,500),
					new SqlParameter("@extStr2", SqlDbType.VarChar,200),
					new SqlParameter("@extStr3", SqlDbType.VarChar,500),
					new SqlParameter("@tel", SqlDbType.VarChar,100),
					new SqlParameter("@daohangurl", SqlDbType.VarChar,800)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.hdName;
			parameters[2].Value = model.pSubject;
			parameters[3].Value = model.typeId;
			parameters[4].Value = model.beginDate;
			parameters[5].Value = model.endDate;
			parameters[6].Value = model.addr;
			parameters[7].Value = model.pContent;
			parameters[8].Value = model.minPersonNum;
			parameters[9].Value = model.maxPersonNum;
			parameters[10].Value = model.personContent;
			parameters[11].Value = model.isOpen;
			parameters[12].Value = model.createPerson;
			parameters[13].Value = model.createDate;
			parameters[14].Value = model.url;
			parameters[15].Value = model.urlName;
			parameters[16].Value = model.btnName;
			parameters[17].Value = model.price;
			parameters[18].Value = model.showPrice;
			parameters[19].Value = model.showYuDing;
			parameters[20].Value = model.showDate;
			parameters[21].Value = model.extInt;
			parameters[22].Value = model.extStr;
			parameters[23].Value = model.extStr2;
			parameters[24].Value = model.extStr3;
            parameters[25].Value = model.tel;
            parameters[26].Value = model.daohangurl;

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
		public bool Update(WechatBuilder.Model.wx_product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_product set ");
			strSql.Append("wid=@wid,");
			strSql.Append("hdName=@hdName,");
			strSql.Append("pSubject=@pSubject,");
			strSql.Append("typeId=@typeId,");
			strSql.Append("beginDate=@beginDate,");
			strSql.Append("endDate=@endDate,");
			strSql.Append("addr=@addr,");
			strSql.Append("pContent=@pContent,");
			strSql.Append("minPersonNum=@minPersonNum,");
			strSql.Append("maxPersonNum=@maxPersonNum,");
			strSql.Append("personContent=@personContent,");
			strSql.Append("isOpen=@isOpen,");
			strSql.Append("createPerson=@createPerson,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("url=@url,");
			strSql.Append("urlName=@urlName,");
			strSql.Append("btnName=@btnName,");
			strSql.Append("price=@price,");
			strSql.Append("showPrice=@showPrice,");
			strSql.Append("showYuDing=@showYuDing,");
			strSql.Append("showDate=@showDate,");
			strSql.Append("extInt=@extInt,");
			strSql.Append("extStr=@extStr,");
			strSql.Append("extStr2=@extStr2,");
			strSql.Append("extStr3=@extStr3,");
            strSql.Append("tel=@tel,");
            strSql.Append("daohangurl=@daohangurl");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@hdName", SqlDbType.VarChar,200),
					new SqlParameter("@pSubject", SqlDbType.VarChar,500),
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@beginDate", SqlDbType.DateTime),
					new SqlParameter("@endDate", SqlDbType.DateTime),
					new SqlParameter("@addr", SqlDbType.VarChar,500),
					new SqlParameter("@pContent", SqlDbType.NText),
					new SqlParameter("@minPersonNum", SqlDbType.Int,4),
					new SqlParameter("@maxPersonNum", SqlDbType.Int,4),
					new SqlParameter("@personContent", SqlDbType.VarChar,500),
					new SqlParameter("@isOpen", SqlDbType.Bit,1),
					new SqlParameter("@createPerson", SqlDbType.VarChar,200),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@url", SqlDbType.VarChar,500),
					new SqlParameter("@urlName", SqlDbType.VarChar,100),
					new SqlParameter("@btnName", SqlDbType.VarChar,100),
					new SqlParameter("@price", SqlDbType.Float,8),
					new SqlParameter("@showPrice", SqlDbType.Bit,1),
					new SqlParameter("@showYuDing", SqlDbType.Bit,1),
					new SqlParameter("@showDate", SqlDbType.Bit,1),
					new SqlParameter("@extInt", SqlDbType.Int,4),
					new SqlParameter("@extStr", SqlDbType.VarChar,500),
					new SqlParameter("@extStr2", SqlDbType.VarChar,200),
					new SqlParameter("@extStr3", SqlDbType.VarChar,500),
                    new SqlParameter("@tel", SqlDbType.VarChar,100),
					new SqlParameter("@daohangurl", SqlDbType.VarChar,800),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.hdName;
			parameters[2].Value = model.pSubject;
			parameters[3].Value = model.typeId;
			parameters[4].Value = model.beginDate;
			parameters[5].Value = model.endDate;
			parameters[6].Value = model.addr;
			parameters[7].Value = model.pContent;
			parameters[8].Value = model.minPersonNum;
			parameters[9].Value = model.maxPersonNum;
			parameters[10].Value = model.personContent;
			parameters[11].Value = model.isOpen;
			parameters[12].Value = model.createPerson;
			parameters[13].Value = model.createDate;
			parameters[14].Value = model.url;
			parameters[15].Value = model.urlName;
			parameters[16].Value = model.btnName;
			parameters[17].Value = model.price;
			parameters[18].Value = model.showPrice;
			parameters[19].Value = model.showYuDing;
			parameters[20].Value = model.showDate;
			parameters[21].Value = model.extInt;
			parameters[22].Value = model.extStr;
			parameters[23].Value = model.extStr2;
			parameters[24].Value = model.extStr3;
            parameters[25].Value = model.tel;
            parameters[26].Value = model.daohangurl;
            parameters[27].Value = model.id;

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
			strSql.Append("delete from wx_product ");
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
			strSql.Append("delete from wx_product ");
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
		public WechatBuilder.Model.wx_product GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,wid,hdName,pSubject,typeId,beginDate,endDate,addr,pContent,minPersonNum,maxPersonNum,personContent,isOpen,createPerson,createDate,url,urlName,btnName,price,showPrice,showYuDing,showDate,extInt,extStr,extStr2,extStr3,tel,daohangurl from wx_product ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_product model=new WechatBuilder.Model.wx_product();
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
		public WechatBuilder.Model.wx_product DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_product model=new WechatBuilder.Model.wx_product();
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
				if(row["hdName"]!=null)
				{
					model.hdName=row["hdName"].ToString();
				}
				if(row["pSubject"]!=null)
				{
					model.pSubject=row["pSubject"].ToString();
				}
				if(row["typeId"]!=null && row["typeId"].ToString()!="")
				{
					model.typeId=int.Parse(row["typeId"].ToString());
				}
				if(row["beginDate"]!=null && row["beginDate"].ToString()!="")
				{
					model.beginDate=DateTime.Parse(row["beginDate"].ToString());
				}
				if(row["endDate"]!=null && row["endDate"].ToString()!="")
				{
					model.endDate=DateTime.Parse(row["endDate"].ToString());
				}
				if(row["addr"]!=null)
				{
					model.addr=row["addr"].ToString();
				}
				if(row["pContent"]!=null)
				{
					model.pContent=row["pContent"].ToString();
				}
				if(row["minPersonNum"]!=null && row["minPersonNum"].ToString()!="")
				{
					model.minPersonNum=int.Parse(row["minPersonNum"].ToString());
				}
				if(row["maxPersonNum"]!=null && row["maxPersonNum"].ToString()!="")
				{
					model.maxPersonNum=int.Parse(row["maxPersonNum"].ToString());
				}
				if(row["personContent"]!=null)
				{
					model.personContent=row["personContent"].ToString();
				}
				if(row["isOpen"]!=null && row["isOpen"].ToString()!="")
				{
					if((row["isOpen"].ToString()=="1")||(row["isOpen"].ToString().ToLower()=="true"))
					{
						model.isOpen=true;
					}
					else
					{
						model.isOpen=false;
					}
				}
				if(row["createPerson"]!=null)
				{
					model.createPerson=row["createPerson"].ToString();
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["url"]!=null)
				{
					model.url=row["url"].ToString();
				}
				if(row["urlName"]!=null)
				{
					model.urlName=row["urlName"].ToString();
				}
				if(row["btnName"]!=null)
				{
					model.btnName=row["btnName"].ToString();
				}
				if(row["price"]!=null && row["price"].ToString()!="")
				{
					model.price=decimal.Parse(row["price"].ToString());
				}
				if(row["showPrice"]!=null && row["showPrice"].ToString()!="")
				{
					if((row["showPrice"].ToString()=="1")||(row["showPrice"].ToString().ToLower()=="true"))
					{
						model.showPrice=true;
					}
					else
					{
						model.showPrice=false;
					}
				}
				if(row["showYuDing"]!=null && row["showYuDing"].ToString()!="")
				{
					if((row["showYuDing"].ToString()=="1")||(row["showYuDing"].ToString().ToLower()=="true"))
					{
						model.showYuDing=true;
					}
					else
					{
						model.showYuDing=false;
					}
				}
				if(row["showDate"]!=null && row["showDate"].ToString()!="")
				{
					if((row["showDate"].ToString()=="1")||(row["showDate"].ToString().ToLower()=="true"))
					{
						model.showDate=true;
					}
					else
					{
						model.showDate=false;
					}
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
				if(row["extStr3"]!=null)
				{
					model.extStr3=row["extStr3"].ToString();
				}
                if (row["tel"] != null)
                {
                    model.tel = row["tel"].ToString();
                }
                if (row["daohangurl"] != null)
                {
                    model.daohangurl = row["daohangurl"].ToString();
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
            strSql.Append("select id,wid,hdName,pSubject,typeId,beginDate,endDate,addr,pContent,minPersonNum,maxPersonNum,personContent,isOpen,createPerson,createDate,url,urlName,btnName,price,showPrice,showYuDing,showDate,extInt,extStr,extStr2,extStr3,tel,daohangurl ");
			strSql.Append(" FROM wx_product ");
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
            strSql.Append(" id,wid,hdName,pSubject,typeId,beginDate,endDate,addr,pContent,minPersonNum,maxPersonNum,personContent,isOpen,createPerson,createDate,url,urlName,btnName,price,showPrice,showYuDing,showDate,extInt,extStr,extStr2,extStr3,tel,daohangurl ");
			strSql.Append(" FROM wx_product ");
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
			strSql.Append("select count(1) FROM wx_product ");
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
			strSql.Append(")AS Row, T.*  from wx_product T ");
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
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_product set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 【微帐号】获得查询分页数据
        /// </summary>
        public DataSet GetWCodeList(int wid,  int category_id, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM  wx_product");
            strSql.Append(" where  wid=" + wid);
            
            if (category_id > 0)
            {
                strSql.Append(" and typeId=" + category_id );
            }
            if (strWhere.Trim() != "")
            {
                 strSql.Append(" and  " + strWhere);
                 
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetPageList(string strWhere, int pageSize, int pageIndex, out int RecordCount, string seq)
        {

            string strSql = @"select ROW_NUMBER() OVER (ORDER BY  " + seq + @") as xuhao,'' as showInfo, *  from   wx_product  ";
            if (strWhere != "")
            {
                strSql += " where " + strWhere;
            }

            RecordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(RecordCount, pageSize, pageIndex, strSql.ToString(), seq));
        }

		#endregion  ExtensionMethod
	}
}

