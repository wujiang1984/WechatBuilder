using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_ucard_ticket
	/// </summary>
	public partial class wx_ucard_ticket
	{
		public wx_ucard_ticket()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "wx_ucard_ticket");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_ucard_ticket");
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
        public int Add(WechatBuilder.Model.wx_ucard_ticket model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_ucard_ticket(");
            strSql.Append("wid,tName,beginDate,endDate,typeId,usedContent,usedTimes,userDegree,userType,consumeMoney,sId,dyMoney,createDate,sort_id)");
            strSql.Append(" values (");
            strSql.Append("@wid,@tName,@beginDate,@endDate,@typeId,@usedContent,@usedTimes,@userDegree,@userType,@consumeMoney,@sId,@dyMoney,@createDate,@sort_id)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@tName", SqlDbType.VarChar,100),
					new SqlParameter("@beginDate", SqlDbType.DateTime),
					new SqlParameter("@endDate", SqlDbType.DateTime),
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@usedContent", SqlDbType.VarChar,1500),
					new SqlParameter("@usedTimes", SqlDbType.Int,4),
					new SqlParameter("@userDegree", SqlDbType.VarChar,500),
					new SqlParameter("@userType", SqlDbType.Int,4),
					new SqlParameter("@consumeMoney", SqlDbType.Int,4),
					new SqlParameter("@sId", SqlDbType.Int,4),
					new SqlParameter("@dyMoney", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@sort_id", SqlDbType.Int,4)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.tName;
            parameters[2].Value = model.beginDate;
            parameters[3].Value = model.endDate;
            parameters[4].Value = model.typeId;
            parameters[5].Value = model.usedContent;
            parameters[6].Value = model.usedTimes;
            parameters[7].Value = model.userDegree;
            parameters[8].Value = model.userType;
            parameters[9].Value = model.consumeMoney;
            parameters[10].Value = model.sId;
            parameters[11].Value = model.dyMoney;
            parameters[12].Value = model.createDate;
            parameters[13].Value = model.sort_id;

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
        public bool Update(WechatBuilder.Model.wx_ucard_ticket model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_ucard_ticket set ");
            strSql.Append("wid=@wid,");
            strSql.Append("tName=@tName,");
            strSql.Append("beginDate=@beginDate,");
            strSql.Append("endDate=@endDate,");
            strSql.Append("typeId=@typeId,");
            strSql.Append("usedContent=@usedContent,");
            strSql.Append("usedTimes=@usedTimes,");
            strSql.Append("userDegree=@userDegree,");
            strSql.Append("userType=@userType,");
            strSql.Append("consumeMoney=@consumeMoney,");
            strSql.Append("sId=@sId,");
            strSql.Append("dyMoney=@dyMoney,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("sort_id=@sort_id");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@tName", SqlDbType.VarChar,100),
					new SqlParameter("@beginDate", SqlDbType.DateTime),
					new SqlParameter("@endDate", SqlDbType.DateTime),
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@usedContent", SqlDbType.VarChar,1500),
					new SqlParameter("@usedTimes", SqlDbType.Int,4),
					new SqlParameter("@userDegree", SqlDbType.VarChar,500),
					new SqlParameter("@userType", SqlDbType.Int,4),
					new SqlParameter("@consumeMoney", SqlDbType.Int,4),
					new SqlParameter("@sId", SqlDbType.Int,4),
					new SqlParameter("@dyMoney", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.tName;
            parameters[2].Value = model.beginDate;
            parameters[3].Value = model.endDate;
            parameters[4].Value = model.typeId;
            parameters[5].Value = model.usedContent;
            parameters[6].Value = model.usedTimes;
            parameters[7].Value = model.userDegree;
            parameters[8].Value = model.userType;
            parameters[9].Value = model.consumeMoney;
            parameters[10].Value = model.sId;
            parameters[11].Value = model.dyMoney;
            parameters[12].Value = model.createDate;
            parameters[13].Value = model.sort_id;
            parameters[14].Value = model.id;

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
            strSql.Append("delete from wx_ucard_ticket ");
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
        public WechatBuilder.Model.wx_ucard_ticket GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,wid,tName,beginDate,endDate,typeId,usedContent,usedTimes,userDegree,userType,consumeMoney,sId,dyMoney,createDate,sort_id from wx_ucard_ticket ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            WechatBuilder.Model.wx_ucard_ticket model = new WechatBuilder.Model.wx_ucard_ticket();
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
        public WechatBuilder.Model.wx_ucard_ticket DataRowToModel(DataRow row)
        {
            WechatBuilder.Model.wx_ucard_ticket model = new WechatBuilder.Model.wx_ucard_ticket();
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
                if (row["tName"] != null)
                {
                    model.tName = row["tName"].ToString();
                }
                if (row["beginDate"] != null && row["beginDate"].ToString() != "")
                {
                    model.beginDate = DateTime.Parse(row["beginDate"].ToString());
                }
                if (row["endDate"] != null && row["endDate"].ToString() != "")
                {
                    model.endDate = DateTime.Parse(row["endDate"].ToString());
                }
                if (row["typeId"] != null && row["typeId"].ToString() != "")
                {
                    model.typeId = int.Parse(row["typeId"].ToString());
                }
                if (row["usedContent"] != null)
                {
                    model.usedContent = row["usedContent"].ToString();
                }
                if (row["usedTimes"] != null && row["usedTimes"].ToString() != "")
                {
                    model.usedTimes = int.Parse(row["usedTimes"].ToString());
                }
                if (row["userDegree"] != null)
                {
                    model.userDegree = row["userDegree"].ToString();
                }
                if (row["userType"] != null && row["userType"].ToString() != "")
                {
                    model.userType = int.Parse(row["userType"].ToString());
                }
                if (row["consumeMoney"] != null && row["consumeMoney"].ToString() != "")
                {
                    model.consumeMoney = int.Parse(row["consumeMoney"].ToString());
                }
                if (row["sId"] != null && row["sId"].ToString() != "")
                {
                    model.sId = int.Parse(row["sId"].ToString());
                }
                if (row["dyMoney"] != null && row["dyMoney"].ToString() != "")
                {
                    model.dyMoney = int.Parse(row["dyMoney"].ToString());
                }
                if (row["createDate"] != null && row["createDate"].ToString() != "")
                {
                    model.createDate = DateTime.Parse(row["createDate"].ToString());
                }
                if (row["sort_id"] != null && row["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(row["sort_id"].ToString());
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
            strSql.Append("select id,wid,tName,beginDate,endDate,typeId,usedContent,usedTimes,userDegree,userType,consumeMoney,sId,dyMoney,createDate,sort_id ");
            strSql.Append(" FROM wx_ucard_ticket ");
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
            strSql.Append(" id,wid,tName,beginDate,endDate,typeId,usedContent,usedTimes,userDegree,userType,consumeMoney,sId,dyMoney,createDate,sort_id ");
            strSql.Append(" FROM wx_ucard_ticket ");
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
            strSql.Append("select count(1) FROM wx_ucard_ticket ");
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
            strSql.Append(")AS Row, T.*  from wx_ucard_ticket T ");
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
            strSql.Append(" select  * from wx_ucard_ticket ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_ucard_ticket where id=@id");
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
        /// 通过存储过程获得用户的优惠券id
        /// </summary>
        /// <param name="sid">店铺主键id</param>
        /// <param name="uid">用户主键id</param>
        /// <param name="degreeNum">用户级别</param>
        /// <param name="ttcMoney">用户总的消费金额</param>
        /// <returns>返回优惠券id主键字符串，使用英文逗号(,)隔开   </returns>
        public string getUserTicketStr(int sid, int uid, int degreeNum, decimal ttcMoney)
        {
            string ticketidStr = "";
            int ret = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4),
                    new SqlParameter("@uid",SqlDbType.Int,4),
                    new SqlParameter("@degreeNum",SqlDbType.Int,4),
                    new SqlParameter("@ttcMoney",SqlDbType.Decimal),
                    new SqlParameter("@ticketidStr",SqlDbType.VarChar,100)
			};
            parameters[0].Value = sid;
            parameters[1].Value = uid;
            parameters[2].Value = degreeNum;

            parameters[3].Value = ttcMoney;
            
            parameters[4].Value = "";
            parameters[4].Direction = ParameterDirection.Output;

            SqlDataReader sr = DbHelperSQL.RunProcedure("p_ticket", parameters);
            
            sr.Close();
            ret = MyCommFun.Obj2Int(parameters[2].Value);
            ticketidStr = MyCommFun.ObjToStr(parameters[4].Value);
            
            return ticketidStr;
        
        }


        /// <summary>
        /// 函数-查询会员对该优惠券使用的剩余次数
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="ticketId"></param>
        /// <returns></returns>
        public int getsyTimesByTicket(int uid, int ticketId)
        {
            int syTimes = 0;
            string sql = "select dbo.ufn_syTimesByTicket(@uid,@ticketId)  as times";
            SqlParameter[] parameters = {
                    new SqlParameter("@uid",SqlDbType.Int,4),
					new SqlParameter("@ticketId", SqlDbType.Int,4)
			};
            parameters[0].Value = uid;
            parameters[1].Value = ticketId;

            SqlDataReader sr = DbHelperSQL.ExecuteReader(sql,parameters);

            while (sr.Read())
            {
                syTimes = int.Parse(sr["times"].ToString());
            }
            return syTimes;
        }
		#endregion  ExtensionMethod
	}
}

