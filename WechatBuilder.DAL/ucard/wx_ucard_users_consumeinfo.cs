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
    /// 数据访问类:wx_ucard_users_consumeinfo
    /// </summary>
    public partial class wx_ucard_users_consumeinfo
    {
        public wx_ucard_users_consumeinfo()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "wx_ucard_users_consumeinfo");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_ucard_users_consumeinfo");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WechatBuilder.Model.wx_ucard_users_consumeinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_ucard_users_consumeinfo set ");
            strSql.Append("sId=@sId,");
            strSql.Append("uid=@uid,");
            strSql.Append("moduleType=@moduleType,");
            strSql.Append("moduleTypeId=@moduleTypeId,");
            strSql.Append("moduleActionName=@moduleActionName,");
            strSql.Append("moduleActionId=@moduleActionId,");
            strSql.Append("cScoreType=@cScoreType,");
            strSql.Append("score=@score,");
            strSql.Append("cMoneyType=@cMoneyType,");
            strSql.Append("consumeMoney=@consumeMoney,");
            strSql.Append("cContent=@cContent,");
            strSql.Append("remark=@remark,");
            strSql.Append("addTime=@addTime,");
            strSql.Append("sort_id=@sort_id,");
            strSql.Append("sn=@sn,");
            strSql.Append("operName=@operName,");
            strSql.Append("pwd=@pwd");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@sId", SqlDbType.Int,4),
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@moduleType", SqlDbType.VarChar,80),
					new SqlParameter("@moduleTypeId", SqlDbType.Int,4),
					new SqlParameter("@moduleActionName", SqlDbType.VarChar,200),
					new SqlParameter("@moduleActionId", SqlDbType.Int,4),
					new SqlParameter("@cScoreType", SqlDbType.Int,4),
					new SqlParameter("@score", SqlDbType.Int,4),
					new SqlParameter("@cMoneyType", SqlDbType.Int,4),
					new SqlParameter("@consumeMoney", SqlDbType.Float,8),
					new SqlParameter("@cContent", SqlDbType.VarChar,800),
					new SqlParameter("@remark", SqlDbType.VarChar,300),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@sn", SqlDbType.VarChar,50),
					new SqlParameter("@operName", SqlDbType.VarChar,50),
					new SqlParameter("@pwd", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.sId;
            parameters[1].Value = model.uid;
            parameters[2].Value = model.moduleType;
            parameters[3].Value = model.moduleTypeId;
            parameters[4].Value = model.moduleActionName;
            parameters[5].Value = model.moduleActionId;
            parameters[6].Value = model.cScoreType;
            parameters[7].Value = model.score;
            parameters[8].Value = model.cMoneyType;
            parameters[9].Value = model.consumeMoney;
            parameters[10].Value = model.cContent;
            parameters[11].Value = model.remark;
            parameters[12].Value = model.addTime;
            parameters[13].Value = model.sort_id;
            parameters[14].Value = model.sn;
            parameters[15].Value = model.operName;
            parameters[16].Value = model.pwd;
            parameters[17].Value = model.id;

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
            strSql.Append("delete from wx_ucard_users_consumeinfo ");
            strSql.Append(" where id=@id");
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_ucard_users_consumeinfo ");
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
        public WechatBuilder.Model.wx_ucard_users_consumeinfo GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sId,uid,moduleType,moduleTypeId,moduleActionName,moduleActionId,cScoreType,score,cMoneyType,consumeMoney,cContent,remark,addTime,sort_id,sn,operName,pwd from wx_ucard_users_consumeinfo ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            WechatBuilder.Model.wx_ucard_users_consumeinfo model = new WechatBuilder.Model.wx_ucard_users_consumeinfo();
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
        public WechatBuilder.Model.wx_ucard_users_consumeinfo DataRowToModel(DataRow row)
        {
            WechatBuilder.Model.wx_ucard_users_consumeinfo model = new WechatBuilder.Model.wx_ucard_users_consumeinfo();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["sId"] != null && row["sId"].ToString() != "")
                {
                    model.sId = int.Parse(row["sId"].ToString());
                }
                if (row["uid"] != null && row["uid"].ToString() != "")
                {
                    model.uid = int.Parse(row["uid"].ToString());
                }
                if (row["moduleType"] != null)
                {
                    model.moduleType = row["moduleType"].ToString();
                }
                if (row["moduleTypeId"] != null && row["moduleTypeId"].ToString() != "")
                {
                    model.moduleTypeId = int.Parse(row["moduleTypeId"].ToString());
                }
                if (row["moduleActionName"] != null)
                {
                    model.moduleActionName = row["moduleActionName"].ToString();
                }
                if (row["moduleActionId"] != null && row["moduleActionId"].ToString() != "")
                {
                    model.moduleActionId = int.Parse(row["moduleActionId"].ToString());
                }
                if (row["cScoreType"] != null && row["cScoreType"].ToString() != "")
                {
                    model.cScoreType = int.Parse(row["cScoreType"].ToString());
                }
                if (row["score"] != null && row["score"].ToString() != "")
                {
                    model.score = int.Parse(row["score"].ToString());
                }
                if (row["cMoneyType"] != null && row["cMoneyType"].ToString() != "")
                {
                    model.cMoneyType = int.Parse(row["cMoneyType"].ToString());
                }
                if (row["consumeMoney"] != null && row["consumeMoney"].ToString() != "")
                {
                    model.consumeMoney = decimal.Parse(row["consumeMoney"].ToString());
                }
                if (row["cContent"] != null)
                {
                    model.cContent = row["cContent"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["addTime"] != null && row["addTime"].ToString() != "")
                {
                    model.addTime = DateTime.Parse(row["addTime"].ToString());
                }
                if (row["sort_id"] != null && row["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(row["sort_id"].ToString());
                }
                if (row["sn"] != null)
                {
                    model.sn = row["sn"].ToString();
                }
                if (row["operName"] != null)
                {
                    model.operName = row["operName"].ToString();
                }
                if (row["pwd"] != null)
                {
                    model.pwd = row["pwd"].ToString();
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
            strSql.Append("select id,sId,uid,moduleType,moduleTypeId,moduleActionName,moduleActionId,cScoreType,score,cMoneyType,consumeMoney,cContent,remark,addTime,sort_id,sn,operName,pwd ");
            strSql.Append(" FROM wx_ucard_users_consumeinfo ");
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
            strSql.Append(" id,sId,uid,moduleType,moduleTypeId,moduleActionName,moduleActionId,cScoreType,score,cMoneyType,consumeMoney,cContent,remark,addTime,sort_id,sn,operName,pwd ");
            strSql.Append(" FROM wx_ucard_users_consumeinfo ");
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
            strSql.Append("select count(1) FROM wx_ucard_users_consumeinfo ");
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
            strSql.Append(")AS Row, T.*  from wx_ucard_users_consumeinfo T ");
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
            strSql.Append(" select c.*,u.cardno,u.realName from wx_ucard_users_consumeinfo c left join  wx_ucard_users u on c.uid=u.id   "); //c.moduleType='特权' and c.sid=1
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 这个日期是否签到了
        /// </summary>
        public bool hasDayQD(int sId, int uid, DateTime time)
        {
            StringBuilder strSql = new StringBuilder();
            DateTime beginDay = DateTime.Parse(time.ToShortDateString());
            DateTime EndDay = beginDay.AddDays(1);
            strSql.Append("select count(1) from wx_ucard_users_consumeinfo");
            strSql.Append(" where sId=@sId and uid=@uid   and moduleType='签到' and addTime>='" + beginDay.ToString() + "' and addTime<'" + EndDay.ToString() + "'");
            SqlParameter[] parameters = {
					new SqlParameter("@sId", SqlDbType.Int,4),
                    new SqlParameter("@uid", SqlDbType.Int,4)
			};
            parameters[0].Value = sId;
            parameters[1].Value = uid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 新增积分记录，比如签到
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isEW">额外的奖励,1为连续6天签到</param>
        /// <returns></returns>
        public int AddJiFen(Model.wx_ucard_users_consumeinfo model, int isEW)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_ucard_users_consumeinfo(");
            strSql.Append("sId,uid,moduleType,moduleTypeId,moduleActionName,moduleActionId,cScoreType,score,cMoneyType,consumeMoney,cContent,remark,addTime,sort_id)");
            strSql.Append(" values (");
            strSql.Append("@sId,@uid,@moduleType,@moduleTypeId,@moduleActionName,@moduleActionId,@cScoreType,@score,@cMoneyType,@consumeMoney,@cContent,@remark,@addTime,@sort_id)");
            strSql.Append(";set @ReturnValue= @@IDENTITY ");
            SqlParameter[] parameters = {
					new SqlParameter("@sId", SqlDbType.Int,4),
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@moduleType", SqlDbType.VarChar,80),
					new SqlParameter("@moduleTypeId", SqlDbType.Int,4),
					new SqlParameter("@moduleActionName", SqlDbType.VarChar,200),
					new SqlParameter("@moduleActionId", SqlDbType.Int,4),
					new SqlParameter("@cScoreType", SqlDbType.Int,4),
					new SqlParameter("@score", SqlDbType.Int,4),
					new SqlParameter("@cMoneyType", SqlDbType.Int,4),
					new SqlParameter("@consumeMoney", SqlDbType.Float,8),
					new SqlParameter("@cContent", SqlDbType.VarChar,800),
					new SqlParameter("@remark", SqlDbType.VarChar,300),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
                    new SqlParameter("@ReturnValue",SqlDbType.Int)};
            parameters[0].Value = model.sId;
            parameters[1].Value = model.uid;
            parameters[2].Value = model.moduleType;
            parameters[3].Value = 1;
            if (isEW == 1)
            {
                parameters[4].Value = "连续6天签到奖励";
            }
            else
            {
                parameters[4].Value = model.moduleActionName;
            }

            parameters[5].Value = 0;
            parameters[6].Value = 1;
            parameters[7].Value = model.score;
            parameters[8].Value = model.cMoneyType;
            parameters[9].Value = model.consumeMoney;
            parameters[10].Value = "";
            parameters[11].Value = "";
            parameters[12].Value = DateTime.Now;
            parameters[13].Value = 0;
            parameters[14].Direction = ParameterDirection.Output;
            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("update wx_ucard_users set qdScore=qdScore+@score,ttScore=ttScore+@score where id=@id");
            SqlParameter[] parameters2 = {
					new SqlParameter("@score", SqlDbType.Int,4),
                    new SqlParameter("@id", SqlDbType.Int,4),
                                         };
            parameters2[0].Value = model.score;
            parameters2[1].Value = model.uid;
            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            DbHelperSQL.ExecuteSqlTranWithIndentity(sqllist);
            return (int)parameters[14].Value;
        }


       
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isXiaoFei">是否为消费积分</param>
        /// <returns></returns>
        public int Add(WechatBuilder.Model.wx_ucard_users_consumeinfo model,bool isXiaoFei)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_ucard_users_consumeinfo(");
            strSql.Append("sId,uid,moduleType,moduleTypeId,moduleActionName,moduleActionId,cScoreType,score,cMoneyType,consumeMoney,cContent,remark,addTime,sort_id,sn,operName,pwd)");
            strSql.Append(" values (");
            strSql.Append("@sId,@uid,@moduleType,@moduleTypeId,@moduleActionName,@moduleActionId,@cScoreType,@score,@cMoneyType,@consumeMoney,@cContent,@remark,@addTime,@sort_id,@sn,@operName,@pwd)");
            strSql.Append(";set @ReturnValue= @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@sId", SqlDbType.Int,4),
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@moduleType", SqlDbType.VarChar,80),
					new SqlParameter("@moduleTypeId", SqlDbType.Int,4),
					new SqlParameter("@moduleActionName", SqlDbType.VarChar,200),
					new SqlParameter("@moduleActionId", SqlDbType.Int,4),
					new SqlParameter("@cScoreType", SqlDbType.Int,4),
					new SqlParameter("@score", SqlDbType.Int,4),
					new SqlParameter("@cMoneyType", SqlDbType.Int,4),
					new SqlParameter("@consumeMoney", SqlDbType.Float,8),
					new SqlParameter("@cContent", SqlDbType.VarChar,800),
					new SqlParameter("@remark", SqlDbType.VarChar,300),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@sn", SqlDbType.VarChar,50),
					new SqlParameter("@operName", SqlDbType.VarChar,50),
					new SqlParameter("@pwd", SqlDbType.VarChar,50),
                    new SqlParameter("@ReturnValue",SqlDbType.Int)};
            parameters[0].Value = model.sId;
            parameters[1].Value = model.uid;
            parameters[2].Value = model.moduleType;
            parameters[3].Value = model.moduleTypeId;
            parameters[4].Value = model.moduleActionName;
            parameters[5].Value = model.moduleActionId;
            parameters[6].Value = model.cScoreType;
            parameters[7].Value = model.score;
            parameters[8].Value = model.cMoneyType;
            parameters[9].Value = model.consumeMoney;
            parameters[10].Value = model.cContent;
            parameters[11].Value = model.remark;
            parameters[12].Value = model.addTime;
            parameters[13].Value = model.sort_id;
            parameters[14].Value = model.sn;
            parameters[15].Value = model.operName;
            parameters[16].Value = model.pwd;
            parameters[17].Direction = ParameterDirection.Output;

            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            StringBuilder strSql2 = new StringBuilder();
            string xfStr = "";
            if (isXiaoFei)
            {
                xfStr = ",consumeScore=consumeScore+" + (model.score == null ? 0 : model.score.Value);
            }
            strSql2.Append("update wx_ucard_users set ttScore=ttScore+@newscore , consumeMoney=consumeMoney+@newMoney" + xfStr + " where id=@uid");
            SqlParameter[] parameters2 = {
					new SqlParameter("@newscore", SqlDbType.Int,4),
                    new SqlParameter("@newMoney", SqlDbType.Decimal,4),
					new SqlParameter("@uid", SqlDbType.Int,4)};
            parameters2[0].Value = MyCommFun.Obj2Int(model.score);
            parameters2[1].Value = MyCommFun.Obj2Decimal(model.consumeMoney, 0);
            parameters2[2].Value = model.uid;

            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            DbHelperSQL.ExecuteSqlTranWithIndentity(sqllist);
            return (int)parameters[17].Value;
        }



        /// <summary>
        /// 更新一条记录，并且将用户的总积分随之变动
        /// </summary>
        /// <param name="model"></param>
        /// <param name="oldMoney"></param>
        /// <param name="oldScore"></param>
        /// <returns></returns>
        public bool UpdateInfoAndUserTT(WechatBuilder.Model.wx_ucard_users_consumeinfo model, decimal oldMoney, int oldScore)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update wx_ucard_users_consumeinfo set ");
                        strSql.Append("sId=@sId,");
                        strSql.Append("uid=@uid,");
                        strSql.Append("moduleType=@moduleType,");
                        strSql.Append("moduleTypeId=@moduleTypeId,");
                        strSql.Append("moduleActionName=@moduleActionName,");
                        strSql.Append("moduleActionId=@moduleActionId,");
                        strSql.Append("cScoreType=@cScoreType,");
                        strSql.Append("score=@score,");
                        strSql.Append("cMoneyType=@cMoneyType,");
                        strSql.Append("consumeMoney=@consumeMoney,");
                        strSql.Append("cContent=@cContent,");
                        strSql.Append("remark=@remark,");
                        strSql.Append("addTime=@addTime,");
                        strSql.Append("sort_id=@sort_id,");
                        strSql.Append("sn=@sn,");
                        strSql.Append("operName=@operName,");
                        strSql.Append("pwd=@pwd");
                        strSql.Append(" where id=@id");
                        SqlParameter[] parameters = {
					new SqlParameter("@sId", SqlDbType.Int,4),
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@moduleType", SqlDbType.VarChar,80),
					new SqlParameter("@moduleTypeId", SqlDbType.Int,4),
					new SqlParameter("@moduleActionName", SqlDbType.VarChar,200),
					new SqlParameter("@moduleActionId", SqlDbType.Int,4),
					new SqlParameter("@cScoreType", SqlDbType.Int,4),
					new SqlParameter("@score", SqlDbType.Int,4),
					new SqlParameter("@cMoneyType", SqlDbType.Int,4),
					new SqlParameter("@consumeMoney", SqlDbType.Float,8),
					new SqlParameter("@cContent", SqlDbType.VarChar,800),
					new SqlParameter("@remark", SqlDbType.VarChar,300),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@sn", SqlDbType.VarChar,50),
					new SqlParameter("@operName", SqlDbType.VarChar,50),
					new SqlParameter("@pwd", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
                        parameters[0].Value = model.sId;
                        parameters[1].Value = model.uid;
                        parameters[2].Value = model.moduleType;
                        parameters[3].Value = model.moduleTypeId;
                        parameters[4].Value = model.moduleActionName;
                        parameters[5].Value = model.moduleActionId;
                        parameters[6].Value = model.cScoreType;
                        parameters[7].Value = model.score;
                        parameters[8].Value = model.cMoneyType;
                        parameters[9].Value = model.consumeMoney;
                        parameters[10].Value = model.cContent;
                        parameters[11].Value = model.remark;
                        parameters[12].Value = model.addTime;
                        parameters[13].Value = model.sort_id;
                        parameters[14].Value = model.sn;
                        parameters[15].Value = model.operName;
                        parameters[16].Value = model.pwd;
                        parameters[17].Value = model.id;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);


                        StringBuilder strSql2 = new StringBuilder();
                        strSql2.Append("update wx_ucard_users set ttScore=ttScore-@oldscore+@newscore, consumeMoney=consumeMoney-@oldMoney+@newMoney where id=@uid");
                        SqlParameter[] parameters2 = {
                    new SqlParameter("@oldscore", SqlDbType.Int,4),
					new SqlParameter("@newscore", SqlDbType.Int,4),
                    new SqlParameter("@oldMoney", SqlDbType.Decimal,4),
                    new SqlParameter("@newMoney", SqlDbType.Decimal,4),
					new SqlParameter("@uid", SqlDbType.Int,4)};
                        parameters2[0].Value = oldScore;
                        parameters2[1].Value = MyCommFun.Obj2Int(model.score);
                        parameters2[2].Value = oldMoney;
                        parameters2[3].Value = MyCommFun.Obj2Decimal(model.consumeMoney, 0);
                        parameters2[4].Value = model.uid;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);

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
        /// 查询消费信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="sid">店铺id</param>
        /// <param name="moduleType">功能模块名称</param>
        /// <returns></returns>
        public DataSet GetConsumeInfoList(string strWhere,int sid,string moduleType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select c.*,u.cardno,u.realName from wx_ucard_users_consumeinfo c left join  wx_ucard_users u on c.uid=u.id where c.moduleType='" + moduleType + "' and c.sid=" + sid);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and  " + strWhere);
            }

            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  ExtensionMethod
    }
}

