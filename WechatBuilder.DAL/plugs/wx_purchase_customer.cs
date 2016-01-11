using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_purchase_customer
	/// </summary>
	public partial class wx_purchase_customer
	{
		public wx_purchase_customer()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "wx_purchase_customer");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_purchase_customer");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WechatBuilder.Model.wx_purchase_customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_purchase_customer(");
            strSql.Append("baseid,sn,customerName,customerNum,address,tel,STATUS,dateJoin,dateUse,craeteTime,openid,Remark)");
            strSql.Append(" values (");
            strSql.Append("@baseid,@sn,@customerName,@customerNum,@address,@tel,@STATUS,@dateJoin,@dateUse,@craeteTime,@openid,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@baseid", SqlDbType.Int,4),
					new SqlParameter("@sn", SqlDbType.VarChar,100),
					new SqlParameter("@customerName", SqlDbType.VarChar,100),
					new SqlParameter("@customerNum", SqlDbType.Int,4),
					new SqlParameter("@address", SqlDbType.VarChar,200),
					new SqlParameter("@tel", SqlDbType.VarChar,100),
					new SqlParameter("@STATUS", SqlDbType.Int,4),
					new SqlParameter("@dateJoin", SqlDbType.DateTime),
					new SqlParameter("@dateUse", SqlDbType.DateTime),
					new SqlParameter("@craeteTime", SqlDbType.DateTime),
					new SqlParameter("@openid", SqlDbType.VarChar,300),
					new SqlParameter("@Remark", SqlDbType.NVarChar,1000)};
            parameters[0].Value = model.baseid;
            parameters[1].Value = model.sn;
            parameters[2].Value = model.customerName;
            parameters[3].Value = model.customerNum;
            parameters[4].Value = model.address;
            parameters[5].Value = model.tel;
            parameters[6].Value = model.status;
            parameters[7].Value = model.dateJoin;
            parameters[8].Value = model.dateUse;
            parameters[9].Value = model.craeteTime;
            parameters[10].Value = model.openid;
            parameters[11].Value = model.Remark;

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
        public bool Update(WechatBuilder.Model.wx_purchase_customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_purchase_customer set ");
            strSql.Append("baseid=@baseid,");
           // strSql.Append("sn=@sn,");
           // strSql.Append("customerName=@customerName,");
           // strSql.Append("customerNum=@customerNum,");
           // strSql.Append("address=@address,");
           // strSql.Append("tel=@tel,");
            strSql.Append("status=@status,");
           // strSql.Append("dateJoin=@dateJoin,");
            strSql.Append("dateUse=@dateUse");
           // strSql.Append("craeteTime=@craeteTime,");
           // strSql.Append("openid=@openid");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@baseid", SqlDbType.Int,4),
					//new SqlParameter("@sn", SqlDbType.VarChar,100),
					//new SqlParameter("@customerName", SqlDbType.VarChar,100),
					//new SqlParameter("@customerNum", SqlDbType.Int,4),
					//new SqlParameter("@address", SqlDbType.VarChar,200),
					//new SqlParameter("@tel", SqlDbType.VarChar,100),
					new SqlParameter("@status", SqlDbType.Int,4),
					//new SqlParameter("@dateJoin", SqlDbType.DateTime),
					new SqlParameter("@dateUse", SqlDbType.DateTime),
					//new SqlParameter("@craeteTime", SqlDbType.DateTime),
					//new SqlParameter("@openid", SqlDbType.VarChar,300),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.baseid;
         //   parameters[1].Value = model.sn;
          //  parameters[2].Value = model.customerName;
          //  parameters[3].Value = model.customerNum;
          //  parameters[4].Value = model.address;
          //  parameters[5].Value = model.tel;
            parameters[1].Value = model.status;
           // parameters[7].Value = model.dateJoin;
            parameters[2].Value = model.dateUse;
           // parameters[9].Value = model.craeteTime;
          //  parameters[10].Value = model.openid;
            parameters[3].Value = model.Id;

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
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_purchase_customer ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

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
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_purchase_customer ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
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
        public WechatBuilder.Model.wx_purchase_customer GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,baseid,sn,customerName,customerNum,address,tel,STATUS,dateJoin,dateUse,craeteTime,openid,Remark from wx_purchase_customer ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            WechatBuilder.Model.wx_purchase_customer model = new WechatBuilder.Model.wx_purchase_customer();
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
        public WechatBuilder.Model.wx_purchase_customer DataRowToModel(DataRow row)
        {
            WechatBuilder.Model.wx_purchase_customer model = new WechatBuilder.Model.wx_purchase_customer();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["baseid"] != null && row["baseid"].ToString() != "")
                {
                    model.baseid = int.Parse(row["baseid"].ToString());
                }
                if (row["sn"] != null)
                {
                    model.sn = row["sn"].ToString();
                }
                if (row["customerName"] != null)
                {
                    model.customerName = row["customerName"].ToString();
                }
                if (row["customerNum"] != null && row["customerNum"].ToString() != "")
                {
                    model.customerNum = int.Parse(row["customerNum"].ToString());
                }
                if (row["address"] != null)
                {
                    model.address = row["address"].ToString();
                }
                if (row["tel"] != null)
                {
                    model.tel = row["tel"].ToString();
                }
                if (row["STATUS"] != null && row["STATUS"].ToString() != "")
                {
                    model.status = int.Parse(row["STATUS"].ToString());
                }
                if (row["dateJoin"] != null && row["dateJoin"].ToString() != "")
                {
                    model.dateJoin = DateTime.Parse(row["dateJoin"].ToString());
                }
                if (row["dateUse"] != null && row["dateUse"].ToString() != "")
                {
                    model.dateUse = DateTime.Parse(row["dateUse"].ToString());
                }
                if (row["craeteTime"] != null && row["craeteTime"].ToString() != "")
                {
                    model.craeteTime = DateTime.Parse(row["craeteTime"].ToString());
                }
                if (row["openid"] != null)
                {
                    model.openid = row["openid"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
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
            strSql.Append("select Id,baseid,sn,customerName,customerNum,address,tel,STATUS,dateJoin,dateUse,craeteTime,openid,Remark ");
            strSql.Append(" FROM wx_purchase_customer ");
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
            strSql.Append(" Id,baseid,sn,customerName,customerNum,address,tel,STATUS,dateJoin,dateUse,craeteTime,openid,Remark ");
            strSql.Append(" FROM wx_purchase_customer ");
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
        public int GetRecordCount(string openid,int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(customerNum) FROM wx_purchase_customer ");
            if (openid.Trim() != "")
            {
                strSql.Append(" where openid='"+openid+"'");
            }
            if (id!=0)
            {
                strSql.Append(" and  baseid='" + id + "'  ");
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
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from wx_purchase_customer T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "wx_purchase_customer";
            parameters[1].Value = "Id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
		#region  ExtensionMethod


        public bool Deletebaseid(int baseid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_purchase_customer ");
            strSql.Append(" where baseid=@baseid");
            SqlParameter[] parameters = {
					new SqlParameter("@baseid", SqlDbType.Int,4)
			};
            parameters[0].Value = baseid;

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

        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,baseid,sn,customerName,customerNum,address,tel,status,dateJoin,dateUse,craeteTime,Remark,openid  ");
            strSql.Append(" FROM wx_purchase_customer ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));

		}

        public bool Exists(string openid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_purchase_customer");
            strSql.Append(" where openid=@openid");
            SqlParameter[] parameters = {
					new SqlParameter("@openid", SqlDbType.NVarChar,300)
			};
            parameters[0].Value = openid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        public WechatBuilder.Model.wx_purchase_customer GetModelSN(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,baseid,sn,customerName,customerNum,address,tel,status,dateJoin,dateUse,craeteTime,openid,Remark  from wx_purchase_customer ");
            strSql.Append(" where baseid=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            WechatBuilder.Model.wx_purchase_customer model = new WechatBuilder.Model.wx_purchase_customer();
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





        public WechatBuilder.Model.wx_purchase_customer GetModelSN(string openId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,baseid,sn,customerName,customerNum,address,tel,status,dateJoin,dateUse,craeteTime,openid,Remark from wx_purchase_customer ");
            strSql.Append(" where openid=@openId  order by craeteTime desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@openId", SqlDbType.NVarChar,300)
			};
            parameters[0].Value = openId;

            WechatBuilder.Model.wx_purchase_customer model = new WechatBuilder.Model.wx_purchase_customer();
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



        public WechatBuilder.Model.wx_purchase_customer GetModellist(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,baseid,sn,customerName,customerNum,address,tel,status,dateJoin,dateUse,craeteTime,openid,Remark from wx_purchase_customer ");
            strSql.Append(" where baseid=@Id  order by craeteTime desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            WechatBuilder.Model.wx_purchase_customer model = new WechatBuilder.Model.wx_purchase_customer();
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


        public WechatBuilder.Model.wx_purchase_customer GetModelopenid(string  openid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,baseid,sn,customerName,customerNum,address,tel,status,dateJoin,dateUse,craeteTime,openid,Remark from wx_purchase_customer ");
            strSql.Append(" where openid=@openid  order by craeteTime desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@openid", SqlDbType.NVarChar,300)
			};
            parameters[0].Value = openid;

            WechatBuilder.Model.wx_purchase_customer model = new WechatBuilder.Model.wx_purchase_customer();
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




        public int GetRecordCount(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct openid   FROM wx_purchase_customer where status='2' and baseid='"+id+"' ");

            DataSet obj = DbHelperSQL.Query(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj.Tables[0].Rows.Count);
            }
        }


        public int GetRecordAmount(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(customerNum)  FROM wx_purchase_customer  where  baseid='" + id + "' ");

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


        public int GetRecordyg(string openid,int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(customerNum)  FROM wx_purchase_customer  where  baseid='" + id + "' and openid='" + openid + "' ");

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

        public int GetRecord(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct openid   FROM wx_purchase_customer where baseid='" + id + "' ");

            DataSet obj = DbHelperSQL.Query(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj.Tables[0].Rows.Count);
            }
        }

        

		#endregion  ExtensionMethod
	}
}

