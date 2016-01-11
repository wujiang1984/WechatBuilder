using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_ucard_users
	/// </summary>
	public partial class wx_ucard_users
	{
		public wx_ucard_users()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_ucard_users"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_ucard_users");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WechatBuilder.Model.wx_ucard_users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_ucard_users set ");
			strSql.Append("wid=@wid,");
			strSql.Append("sid=@sid,");
			strSql.Append("openid=@openid,");
			strSql.Append("cardNo=@cardNo,");
			strSql.Append("pwd=@pwd,");
			strSql.Append("degreeId=@degreeId,");
			strSql.Append("sex=@sex,");
			strSql.Append("birthday=@birthday,");
			strSql.Append("wxName=@wxName,");
			strSql.Append("realName=@realName,");
			strSql.Append("age=@age,");
			strSql.Append("qq=@qq,");
			strSql.Append("regTime=@regTime,");
			strSql.Append("regIp=@regIp,");
			strSql.Append("telphone=@telphone,");
			strSql.Append("mobile=@mobile,");
			strSql.Append("email=@email,");
			strSql.Append("addr=@addr,");
			strSql.Append("endDate=@endDate,");
			strSql.Append("ttScore=@ttScore,");
			strSql.Append("qdScore=@qdScore,");
			strSql.Append("consumeScore=@consumeScore,");
			strSql.Append("consumeMoney=@consumeMoney");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@sid", SqlDbType.Int,4),
					new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@cardNo", SqlDbType.VarChar,50),
					new SqlParameter("@pwd", SqlDbType.VarChar,100),
					new SqlParameter("@degreeId", SqlDbType.Int,4),
					new SqlParameter("@sex", SqlDbType.Int,4),
					new SqlParameter("@birthday", SqlDbType.DateTime),
					new SqlParameter("@wxName", SqlDbType.VarChar,100),
					new SqlParameter("@realName", SqlDbType.VarChar,50),
					new SqlParameter("@age", SqlDbType.Int,4),
					new SqlParameter("@qq", SqlDbType.VarChar,20),
					new SqlParameter("@regTime", SqlDbType.DateTime),
					new SqlParameter("@regIp", SqlDbType.VarChar,20),
					new SqlParameter("@telphone", SqlDbType.VarChar,50),
					new SqlParameter("@mobile", SqlDbType.VarChar,20),
					new SqlParameter("@email", SqlDbType.VarChar,100),
					new SqlParameter("@addr", SqlDbType.VarChar,300),
					new SqlParameter("@endDate", SqlDbType.DateTime),
					new SqlParameter("@ttScore", SqlDbType.Int,4),
					new SqlParameter("@qdScore", SqlDbType.Int,4),
					new SqlParameter("@consumeScore", SqlDbType.Int,4),
					new SqlParameter("@consumeMoney", SqlDbType.Float,8),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.sid;
			parameters[2].Value = model.openid;
			parameters[3].Value = model.cardNo;
			parameters[4].Value = model.pwd;
			parameters[5].Value = model.degreeId;
			parameters[6].Value = model.sex;
			parameters[7].Value = model.birthday;
			parameters[8].Value = model.wxName;
			parameters[9].Value = model.realName;
			parameters[10].Value = model.age;
			parameters[11].Value = model.qq;
			parameters[12].Value = model.regTime;
			parameters[13].Value = model.regIp;
			parameters[14].Value = model.telphone;
			parameters[15].Value = model.mobile;
			parameters[16].Value = model.email;
			parameters[17].Value = model.addr;
			parameters[18].Value = model.endDate;
            
			parameters[19].Value = model.ttScore;
			parameters[20].Value = model.qdScore;
			parameters[21].Value = model.consumeScore;
			parameters[22].Value = model.consumeMoney;
			parameters[23].Value = model.id;

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
			strSql.Append("delete from wx_ucard_users ");
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
			strSql.Append("delete from wx_ucard_users ");
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
		public WechatBuilder.Model.wx_ucard_users GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,wid,sid,openid,cardNo,pwd,degreeId,sex,birthday,wxName,realName,age,qq,regTime,regIp,telphone,mobile,email,addr,endDate,ttScore,qdScore,consumeScore,consumeMoney from wx_ucard_users ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_ucard_users model=new WechatBuilder.Model.wx_ucard_users();
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
		public WechatBuilder.Model.wx_ucard_users DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_ucard_users model=new WechatBuilder.Model.wx_ucard_users();
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
				if(row["sid"]!=null && row["sid"].ToString()!="")
				{
					model.sid=int.Parse(row["sid"].ToString());
				}
				if(row["openid"]!=null)
				{
					model.openid=row["openid"].ToString();
				}
				if(row["cardNo"]!=null)
				{
					model.cardNo=row["cardNo"].ToString();
				}
				if(row["pwd"]!=null)
				{
					model.pwd=row["pwd"].ToString();
				}
				if(row["degreeId"]!=null && row["degreeId"].ToString()!="")
				{
					model.degreeId=int.Parse(row["degreeId"].ToString());
				}
				if(row["sex"]!=null && row["sex"].ToString()!="")
				{
					model.sex=int.Parse(row["sex"].ToString());
				}
				if(row["birthday"]!=null && row["birthday"].ToString()!="")
				{
					model.birthday=DateTime.Parse(row["birthday"].ToString());
				}
				if(row["wxName"]!=null)
				{
					model.wxName=row["wxName"].ToString();
				}
				if(row["realName"]!=null)
				{
					model.realName=row["realName"].ToString();
				}
				if(row["age"]!=null && row["age"].ToString()!="")
				{
					model.age=int.Parse(row["age"].ToString());
				}
				if(row["qq"]!=null)
				{
					model.qq=row["qq"].ToString();
				}
				if(row["regTime"]!=null && row["regTime"].ToString()!="")
				{
					model.regTime=DateTime.Parse(row["regTime"].ToString());
				}
				if(row["regIp"]!=null)
				{
					model.regIp=row["regIp"].ToString();
				}
				if(row["telphone"]!=null)
				{
					model.telphone=row["telphone"].ToString();
				}
				if(row["mobile"]!=null)
				{
					model.mobile=row["mobile"].ToString();
				}
				if(row["email"]!=null)
				{
					model.email=row["email"].ToString();
				}
				if(row["addr"]!=null)
				{
					model.addr=row["addr"].ToString();
				}
				if(row["endDate"]!=null && row["endDate"].ToString()!="")
				{
					model.endDate=DateTime.Parse(row["endDate"].ToString());
				}
				if(row["ttScore"]!=null && row["ttScore"].ToString()!="")
				{
					model.ttScore=int.Parse(row["ttScore"].ToString());
				}
				if(row["qdScore"]!=null && row["qdScore"].ToString()!="")
				{
					model.qdScore=int.Parse(row["qdScore"].ToString());
				}
				if(row["consumeScore"]!=null && row["consumeScore"].ToString()!="")
				{
					model.consumeScore=int.Parse(row["consumeScore"].ToString());
				}
				if(row["consumeMoney"]!=null && row["consumeMoney"].ToString()!="")
				{
					model.consumeMoney=decimal.Parse(row["consumeMoney"].ToString());
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
			strSql.Append("select id,wid,sid,openid,cardNo,pwd,degreeId,sex,birthday,wxName,realName,age,qq,regTime,regIp,telphone,mobile,email,addr,endDate,ttScore,qdScore,consumeScore,consumeMoney ");
			strSql.Append(" FROM wx_ucard_users ");
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
			strSql.Append(" id,wid,sid,openid,cardNo,pwd,degreeId,sex,birthday,wxName,realName,age,qq,regTime,regIp,telphone,mobile,email,addr,endDate,ttScore,qdScore,consumeScore,consumeMoney ");
			strSql.Append(" FROM wx_ucard_users ");
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
			strSql.Append("select count(1) FROM wx_ucard_users ");
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
			strSql.Append(")AS Row, T.*  from wx_ucard_users T ");
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
            strSql.Append(" select  jibie='',* from wx_ucard_users ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WechatBuilder.Model.wx_ucard_users GetStoreUserInfo(string oepnid, int sid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,wid,sid,openid,cardNo,pwd,degreeId,sex,birthday,wxName,realName,age,qq,regTime,regIp,telphone,mobile,email,addr,endDate,ttScore,qdScore,consumeScore,consumeMoney from wx_ucard_users ");
            strSql.Append(" where sid=@sid and openid=@openid");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4),
                    new SqlParameter("@openid", SqlDbType.VarChar,100)
			};
            parameters[0].Value = sid;
            parameters[1].Value = oepnid;
            WechatBuilder.Model.wx_ucard_users model = new WechatBuilder.Model.wx_ucard_users();
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
        /// 增加一条数据
        /// </summary>
        public int Add(WechatBuilder.Model.wx_ucard_users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_ucard_users(");
            strSql.Append("wid,sid,openid,cardNo,pwd,degreeId,sex,birthday,wxName,realName,age,qq,regTime,regIp,telphone,mobile,email,addr,endDate,ttScore,qdScore,consumeScore,consumeMoney)");
            strSql.Append(" values (");
            strSql.Append("@wid,@sid,@openid,dbo.ufn_ucard_maxCardNo(),@pwd,@degreeId,@sex,@birthday,@wxName,@realName,@age,@qq,@regTime,@regIp,@telphone,@mobile,@email,@addr,@endDate,@ttScore,@qdScore,@consumeScore,@consumeMoney)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@sid", SqlDbType.Int,4),
					new SqlParameter("@openid", SqlDbType.VarChar,100),
					//new SqlParameter("@cardNo", SqlDbType.VarChar,50),
					new SqlParameter("@pwd", SqlDbType.VarChar,100),
					new SqlParameter("@degreeId", SqlDbType.Int,4),
					new SqlParameter("@sex", SqlDbType.Int,4),
					new SqlParameter("@birthday", SqlDbType.DateTime),
					new SqlParameter("@wxName", SqlDbType.VarChar,100),
					new SqlParameter("@realName", SqlDbType.VarChar,50),
					new SqlParameter("@age", SqlDbType.Int,4),
					new SqlParameter("@qq", SqlDbType.VarChar,20),
					new SqlParameter("@regTime", SqlDbType.DateTime),
					new SqlParameter("@regIp", SqlDbType.VarChar,20),
					new SqlParameter("@telphone", SqlDbType.VarChar,50),
					new SqlParameter("@mobile", SqlDbType.VarChar,20),
					new SqlParameter("@email", SqlDbType.VarChar,100),
					new SqlParameter("@addr", SqlDbType.VarChar,300),
					new SqlParameter("@endDate", SqlDbType.DateTime),
					new SqlParameter("@ttScore", SqlDbType.Int,4),
					new SqlParameter("@qdScore", SqlDbType.Int,4),
					new SqlParameter("@consumeScore", SqlDbType.Int,4),
					new SqlParameter("@consumeMoney", SqlDbType.Float,8)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.sid;
            parameters[2].Value = model.openid;
           // parameters[3].Value = model.cardNo;
            parameters[3].Value = model.pwd;
            parameters[4].Value = model.degreeId;
            parameters[5].Value = model.sex;
            parameters[6].Value = model.birthday;
            parameters[7].Value = model.wxName;
            parameters[8].Value = model.realName;
            parameters[9].Value = model.age;
            parameters[10].Value = model.qq;
            parameters[11].Value = model.regTime;
            parameters[12].Value = model.regIp;
            parameters[13].Value = model.telphone;
            parameters[14].Value = model.mobile;
            parameters[15].Value = model.email;
            parameters[16].Value = model.addr;
            parameters[17].Value = model.endDate;
            parameters[18].Value = model.ttScore;
            parameters[19].Value = model.qdScore;
            parameters[20].Value = model.consumeScore;
            parameters[21].Value = model.consumeMoney;

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
        /// 是否存在该店铺以及该会员
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>返回店铺id</returns>
        public int  ExistsStoreAndUser(int id)
        {
            int sid = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id from wx_ucard_store where id=(select sid  from wx_ucard_users where id=@id)");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            SqlDataReader sr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters);

            while (sr.Read())
            {
                sid = MyCommFun.Obj2Int(sr["id"]);
            }
            sr.Close();
            return sid;
        }

        /// <summary>
        /// 获取会员的总积分
        /// </summary>
        public int GetUserJiFen(int uid)
        {
            int ret = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ttScore FROM wx_ucard_users where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = uid;

            SqlDataReader  sr = DbHelperSQL.ExecuteReader(strSql.ToString(),parameters);

          while (sr.Read())
            {
                ret = MyCommFun.Obj2Int(sr["ttScore"]);
            }
            sr.Close();

            return ret;
        }

        /// <summary>
        /// 查询会员已经开卡的数量
        /// </summary>
        public int GetUserStoreNum(string openid)
        {
            int ret = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) as num FROM wx_ucard_users where openid=@openid ");
            SqlParameter[] parameters = {
					new SqlParameter("@openid", SqlDbType.VarChar,100)
			};
            parameters[0].Value = openid;

            SqlDataReader sr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters);

            while (sr.Read())
            {
                ret = MyCommFun.Obj2Int(sr["num"]);
            }
            sr.Close();

            return ret;
        }


		#endregion  ExtensionMethod
	}
}

