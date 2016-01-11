using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;

namespace WechatBuilder.DAL
{
    /// <summary>
    /// 数据访问类:用户
    /// </summary>
    public partial class users
    {
        private string databaseprefix; //数据库表名前缀
        public users(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        #region 基本方法===========================================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "users");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        public bool Exists(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "users");
            strSql.Append(" where user_name=@user_name ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检查同一IP注册间隔(小时)内是否存在
        /// </summary>
        public bool Exists(string reg_ip, int regctrl)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "users");
            strSql.Append(" where reg_ip=@reg_ip and DATEDIFF(hh,reg_time,getdate())<@regctrl ");
            SqlParameter[] parameters = {
					new SqlParameter("@reg_ip", SqlDbType.NVarChar,30),
                    new SqlParameter("@regctrl", SqlDbType.Int,4)};
            parameters[0].Value = reg_ip;
            parameters[1].Value = regctrl;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检查Email是否存在
        /// </summary>
        public bool ExistsEmail(string email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "users");
            strSql.Append(" where email=@email ");
            SqlParameter[] parameters = {
					new SqlParameter("@email", SqlDbType.NVarChar,100)};
            parameters[0].Value = email;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检查手机号码是否存在
        /// </summary>
        public bool ExistsMobile(string mobile)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "users");
            strSql.Append(" where mobile=@mobile ");
            SqlParameter[] parameters = {
					new SqlParameter("@mobile", SqlDbType.NVarChar,20)};
            parameters[0].Value = mobile;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据用户名取得Salt
        /// </summary>
        public string GetSalt(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 salt from " + databaseprefix + "users");
            strSql.Append(" where user_name=@user_name");
            SqlParameter[] parameters = {
                    new SqlParameter("@user_name", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;
            string salt = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
            if (string.IsNullOrEmpty(salt))
            {
                return "";
            }
            return salt;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "users(");
            strSql.Append("group_id,user_name,password,salt,email,nick_name,avatar,sex,birthday,telphone,mobile,qq,address,safe_question,safe_answer,amount,point,exp,status,reg_time,reg_ip,isweixin,wid,wxOpenId,wxName)");
            strSql.Append(" values (");
            strSql.Append("@group_id,@user_name,@password,@salt,@email,@nick_name,@avatar,@sex,@birthday,@telphone,@mobile,@qq,@address,@safe_question,@safe_answer,@amount,@point,@exp,@status,@reg_time,@reg_ip,@isweixin,@wid,@wxOpenId,@wxName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@group_id", SqlDbType.Int,4),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@password", SqlDbType.NVarChar,100),
					new SqlParameter("@salt", SqlDbType.NVarChar,20),
					new SqlParameter("@email", SqlDbType.NVarChar,50),
					new SqlParameter("@nick_name", SqlDbType.NVarChar,100),
					new SqlParameter("@avatar", SqlDbType.NVarChar,255),
					new SqlParameter("@sex", SqlDbType.NVarChar,20),
					new SqlParameter("@birthday", SqlDbType.DateTime),
					new SqlParameter("@telphone", SqlDbType.NVarChar,50),
					new SqlParameter("@mobile", SqlDbType.NVarChar,20),
					new SqlParameter("@qq", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,255),
					new SqlParameter("@safe_question", SqlDbType.NVarChar,255),
					new SqlParameter("@safe_answer", SqlDbType.NVarChar,255),
					new SqlParameter("@amount", SqlDbType.Decimal,5),
					new SqlParameter("@point", SqlDbType.Int,4),
					new SqlParameter("@exp", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.TinyInt,1),
					new SqlParameter("@reg_time", SqlDbType.DateTime),
					new SqlParameter("@reg_ip", SqlDbType.NVarChar,30),
					new SqlParameter("@isweixin", SqlDbType.TinyInt,1),
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@wxOpenId", SqlDbType.NVarChar,100),
					new SqlParameter("@wxName", SqlDbType.NVarChar,150)};
            parameters[0].Value = model.group_id;
            parameters[1].Value = model.user_name;
            parameters[2].Value = model.password;
            parameters[3].Value = model.salt;
            parameters[4].Value = model.email;
            parameters[5].Value = model.nick_name;
            parameters[6].Value = model.avatar;
            parameters[7].Value = model.sex;
            parameters[8].Value = model.birthday;
            parameters[9].Value = model.telphone;
            parameters[10].Value = model.mobile;
            parameters[11].Value = model.qq;
            parameters[12].Value = model.address;
            parameters[13].Value = model.safe_question;
            parameters[14].Value = model.safe_answer;
            parameters[15].Value = model.amount;
            parameters[16].Value = model.point;
            parameters[17].Value = model.exp;
            parameters[18].Value = model.status;
            parameters[19].Value = model.reg_time;
            parameters[20].Value = model.reg_ip;
            parameters[21].Value = model.isweixin;
            parameters[22].Value = model.wid;
            parameters[23].Value = model.wxOpenId;
            parameters[24].Value = model.wxName;
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
        /// 修改一列数据
        /// </summary>
        public int UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "users set " + strValue);
            strSql.Append(" where id=" + id);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "users set ");
            strSql.Append("group_id=@group_id,");
            strSql.Append("user_name=@user_name,");
            strSql.Append("password=@password,");
            strSql.Append("salt=@salt,");
            strSql.Append("email=@email,");
            strSql.Append("nick_name=@nick_name,");
            strSql.Append("avatar=@avatar,");
            strSql.Append("sex=@sex,");
            strSql.Append("birthday=@birthday,");
            strSql.Append("telphone=@telphone,");
            strSql.Append("mobile=@mobile,");
            strSql.Append("qq=@qq,");
            strSql.Append("address=@address,");
            strSql.Append("safe_question=@safe_question,");
            strSql.Append("safe_answer=@safe_answer,");
            strSql.Append("amount=@amount,");
            strSql.Append("point=@point,");
            strSql.Append("exp=@exp,");
            strSql.Append("status=@status,");
            strSql.Append("reg_time=@reg_time,");
            strSql.Append("reg_ip=@reg_ip,");
            strSql.Append("isweixin=@isweixin,");
            strSql.Append("wid=@wid,");
            strSql.Append("wxOpenId=@wxOpenId,");
            strSql.Append("wxName=@wxName");

            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@group_id", SqlDbType.Int,4),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@password", SqlDbType.NVarChar,100),
					new SqlParameter("@salt", SqlDbType.NVarChar,20),
					new SqlParameter("@email", SqlDbType.NVarChar,50),
					new SqlParameter("@nick_name", SqlDbType.NVarChar,100),
					new SqlParameter("@avatar", SqlDbType.NVarChar,255),
					new SqlParameter("@sex", SqlDbType.NVarChar,20),
					new SqlParameter("@birthday", SqlDbType.DateTime),
					new SqlParameter("@telphone", SqlDbType.NVarChar,50),
					new SqlParameter("@mobile", SqlDbType.NVarChar,20),
					new SqlParameter("@qq", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,255),
					new SqlParameter("@safe_question", SqlDbType.NVarChar,255),
					new SqlParameter("@safe_answer", SqlDbType.NVarChar,255),
					new SqlParameter("@amount", SqlDbType.Decimal,5),
					new SqlParameter("@point", SqlDbType.Int,4),
					new SqlParameter("@exp", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.TinyInt,1),
					new SqlParameter("@reg_time", SqlDbType.DateTime),
					new SqlParameter("@reg_ip", SqlDbType.NVarChar,30),
                    new SqlParameter("@isweixin", SqlDbType.TinyInt,1),
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@wxOpenId", SqlDbType.NVarChar,100),
					new SqlParameter("@wxName", SqlDbType.NVarChar,150)
        };
            parameters[0].Value = model.id;
            parameters[1].Value = model.group_id;
            parameters[2].Value = model.user_name;
            parameters[3].Value = model.password;
            parameters[4].Value = model.salt;
            parameters[5].Value = model.email;
            parameters[6].Value = model.nick_name;
            parameters[7].Value = model.avatar;
            parameters[8].Value = model.sex;
            parameters[9].Value = model.birthday;
            parameters[10].Value = model.telphone;
            parameters[11].Value = model.mobile;
            parameters[12].Value = model.qq;
            parameters[13].Value = model.address;
            parameters[14].Value = model.safe_question;
            parameters[15].Value = model.safe_answer;
            parameters[16].Value = model.amount;
            parameters[17].Value = model.point;
            parameters[18].Value = model.exp;
            parameters[19].Value = model.status;
            parameters[20].Value = model.reg_time;
            parameters[21].Value = model.reg_ip;
            parameters[22].Value = model.isweixin;
            parameters[23].Value = model.wid;
            parameters[24].Value = model.wxOpenId;
            parameters[25].Value = model.wxName;
           
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
            //获取用户旧数据
            Model.users model = GetModel(id);
            if (model == null)
            {
                return false;
            }

            List<CommandInfo> sqllist = new List<CommandInfo>();
            //删除积分记录
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("delete from " + databaseprefix + "user_point_log ");
            strSql1.Append(" where user_id=@id");
            SqlParameter[] parameters1 = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters1[0].Value = id;
            CommandInfo cmd = new CommandInfo(strSql1.ToString(), parameters1);
            sqllist.Add(cmd);

            //删除金额记录
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete from " + databaseprefix + "user_amount_log ");
            strSql2.Append(" where user_id=@id");
            SqlParameter[] parameters2 = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters2[0].Value = id;
            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            //删除短消息
            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("delete from " + databaseprefix + "user_message ");
            strSql3.Append(" where post_user_name=@post_user_name or accept_user_name=@accept_user_name");
            SqlParameter[] parameters3 = {
					new SqlParameter("@post_user_name", SqlDbType.NVarChar,100),
                    new SqlParameter("@accept_user_name", SqlDbType.NVarChar,100)};
            parameters3[0].Value = model.user_name;
            parameters3[1].Value = model.user_name;
            cmd = new CommandInfo(strSql3.ToString(), parameters3);
            sqllist.Add(cmd);

            //删除申请码
            StringBuilder strSql4 = new StringBuilder();
            strSql4.Append("delete from " + databaseprefix + "user_code ");
            strSql4.Append(" where user_id=@id");
            SqlParameter[] parameters4 = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters4[0].Value = id;
            cmd = new CommandInfo(strSql4.ToString(), parameters4);
            sqllist.Add(cmd);

            //删除登录日志
            StringBuilder strSql5 = new StringBuilder();
            strSql5.Append("delete from " + databaseprefix + "user_login_log ");
            strSql5.Append(" where user_id=@id");
            SqlParameter[] parameters5 = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters5[0].Value = id;
            cmd = new CommandInfo(strSql5.ToString(), parameters5);
            sqllist.Add(cmd);

            //删除用户记录
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "users ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            int rowsAffected = DbHelperSQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
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
        public Model.users GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,group_id,user_name,password,salt,email,nick_name,avatar,sex,birthday,telphone,mobile,qq,address,safe_question,safe_answer,amount,point,exp,status,reg_time,reg_ip,isweixin,wid,wxOpenId,wxName from " + databaseprefix + "users ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.users model = new Model.users();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["group_id"].ToString() != "")
                {
                    model.group_id = int.Parse(ds.Tables[0].Rows[0]["group_id"].ToString());
                }
                model.user_name = ds.Tables[0].Rows[0]["user_name"].ToString();
                model.password = ds.Tables[0].Rows[0]["password"].ToString();
                model.salt = ds.Tables[0].Rows[0]["salt"].ToString();
                model.email = ds.Tables[0].Rows[0]["email"].ToString();
                model.nick_name = ds.Tables[0].Rows[0]["nick_name"].ToString();
                model.avatar = ds.Tables[0].Rows[0]["avatar"].ToString();
                model.sex = ds.Tables[0].Rows[0]["sex"].ToString();
                if (ds.Tables[0].Rows[0]["birthday"].ToString() != "")
                {
                    model.birthday = DateTime.Parse(ds.Tables[0].Rows[0]["birthday"].ToString());
                }
                model.telphone = ds.Tables[0].Rows[0]["telphone"].ToString();
                model.mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
                model.qq = ds.Tables[0].Rows[0]["qq"].ToString();
                model.address = ds.Tables[0].Rows[0]["address"].ToString();
                model.safe_question = ds.Tables[0].Rows[0]["safe_question"].ToString();
                model.safe_answer = ds.Tables[0].Rows[0]["safe_answer"].ToString();
                if (ds.Tables[0].Rows[0]["amount"].ToString() != "")
                {
                    model.amount = decimal.Parse(ds.Tables[0].Rows[0]["amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["point"].ToString() != "")
                {
                    model.point = int.Parse(ds.Tables[0].Rows[0]["point"].ToString());
                }
                if (ds.Tables[0].Rows[0]["exp"].ToString() != "")
                {
                    model.exp = int.Parse(ds.Tables[0].Rows[0]["exp"].ToString());
                }
                if (ds.Tables[0].Rows[0]["status"].ToString() != "")
                {
                    model.status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["reg_time"].ToString() != "")
                {
                    model.reg_time = DateTime.Parse(ds.Tables[0].Rows[0]["reg_time"].ToString());
                }
                model.reg_ip = ds.Tables[0].Rows[0]["reg_ip"].ToString();

                if (ds.Tables[0].Rows[0]["isweixin"] != null && ds.Tables[0].Rows[0]["isweixin"].ToString() != "")
                {
                    model.isweixin = int.Parse(ds.Tables[0].Rows[0]["isweixin"].ToString());
                }
                if (ds.Tables[0].Rows[0]["wid"] != null && ds.Tables[0].Rows[0]["wid"].ToString() != "")
                {
                    model.wid = int.Parse(ds.Tables[0].Rows[0]["wid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["wxOpenId"] != null)
                {
                    model.wxOpenId = ds.Tables[0].Rows[0]["wxOpenId"].ToString();
                }
                if (ds.Tables[0].Rows[0]["wxName"] != null)
                {
                    model.wxName = ds.Tables[0].Rows[0]["wxName"].ToString();
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据用户名密码返回一个实体
        /// </summary>
        public Model.users GetModel(string user_name, string password, int emaillogin, int mobilelogin)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id from " + databaseprefix + "users");
            strSql.Append(" where (user_name=@user_name");
            if (emaillogin == 1)
            {
                strSql.Append(" or email=@user_name");
            }
            if (mobilelogin == 1)
            {
                strSql.Append(" or mobile=@user_name");
            }
            strSql.Append(") and password=@password and status<3");

            SqlParameter[] parameters = {
					    new SqlParameter("@user_name", SqlDbType.NVarChar,100),
                        new SqlParameter("@password", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;
            parameters[1].Value = password;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return GetModel(Convert.ToInt32(obj));
            }

            return null;
        }

        /// <summary>
        /// 根据用户名返回一个实体
        /// </summary>
        public Model.users GetModel(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id from " + databaseprefix + "users");
            strSql.Append(" where user_name=@user_name and status<3");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return GetModel(Convert.ToInt32(obj));
            }
            return null;
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
            strSql.Append(" id,group_id,user_name,password,salt,email,nick_name,avatar,sex,birthday,telphone,mobile,qq,address,safe_question,safe_answer,amount,point,exp,status,reg_time,reg_ip,isweixin,wid,wxOpenId,wxName ");
            strSql.Append(" FROM " + databaseprefix + "users ");
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
            strSql.Append("select * FROM " + databaseprefix + "users");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        #endregion

        #region 微信会员卡


        /// <summary>
        /// 检查openid是否存在
        /// </summary>
        public bool ExistsOpenid(int wid,string openid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dt_users");
            strSql.Append(" where wxOpenId=@wxOpenId and wid=@wid");
            SqlParameter[] parameters = {
					new SqlParameter("@wxOpenId", SqlDbType.NVarChar,100),new SqlParameter("@wid", SqlDbType.Int)};
            parameters[0].Value = openid;
            parameters[1].Value = wid;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 通过微信用户微信唯一编码，获得用户信息
        /// </summary>
        /// <param name="uOpenId"></param>
        /// <returns></returns>
        public DataSet getWxUserByOpenId(int wid,string uOpenId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1");
            strSql.Append(" id,user_name,birthday,wxCard,telphone,sex FROM dt_users where wxOpenId='" + uOpenId + "' and wid="+wid+" order by id desc");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 通过微信用户微信唯一编码，获得会员卡号
        /// </summary>
        /// <param name="uOpenId"></param>
        /// <returns></returns>
        public string getCardnoByOpenId(int wid,string uOpenId)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select top 1");
                strSql.Append(" id,nick_name,wxCard FROM dt_users where wxOpenId='" + uOpenId + "'and wid="+wid+" and wxCard is not null");
                DataSet ds = DbHelperSQL.Query(strSql.ToString());
                if (ds == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0)
                {
                    return "";
                }
                else
                {
                    return ds.Tables[0].Rows[0]["wxCard"].ToString();
                }
            }
            catch (Exception ex)
            {
                return "";
            }

        }


        /// <summary>
        /// 通过微信端注册的用户
        /// 第一个用户，是设定是初始值加1
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="tel"></param>
        /// <param name="username"></param>
        /// <param name="sex"></param>
        /// <returns></returns>
        public int InsertUserByWX(int wid,string openId, string tel, string username, string sex, out decimal cardno)
        {
            //计算会员卡的最大号
            decimal MaxCard = 0;
            string sqlStr = "select top 1 wxCard from dt_users where wid="+wid+" and  wxCard is not null order by wxCard desc";
            DataSet ds = DbHelperSQL.Query(sqlStr);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["wxCard"].ToString().Trim() != "0" && ds.Tables[0].Rows[0]["wxCard"].ToString().Trim() != "")
            {
                MaxCard = decimal.Parse(ds.Tables[0].Rows[0]["wxCard"].ToString()) + 1;
            }
            else
            {
                //如果还没有
                //暂时注释掉 ----------2014-2-8 start-----------
                //BLL.wx_UCard_Sys ucardSysBll = new wx_UCard_Sys();
                //IList<Model.wx_UCard_Sys> ucardSys = ucardSysBll.GetModelList("1=1 order by id desc");
                //if (ucardSys != null)
                //{
                //    MaxCard = ucardSys[0].minCardNum.Value + 1;
                //}
                //else
                //{
                //    cardno = 0;
                //    return 0;
                //}
                //暂时注释掉 ----------2014-2-8 end-----------
            }
            cardno = MaxCard;
            Model.users user = new Model.users();
            user.isweixin = 1;
            user.group_id = 3;
            user.reg_ip = "127.0.0.1";
            user.user_name = username;
            user.telphone = tel;
            user.email = "test@weixin.com";
            user.password = tel;
            user.wxOpenId = openId;
            user.sex = sex;
            user.wxCard = MaxCard;

            if (ExistsOpenid(wid,openId))
            {
                this.Update(user);
                return 1;
            }
            else
            {
                return this.Add(user);
            }
        }



        /// <summary>
        /// 修改微信用户信息
        /// </summary>
        /// <param name="id">该条用户的dt_users表主键</param>
        /// <param name="tel"></param>
        /// <param name="username"></param>
        /// <param name="sex"></param>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public bool EidtUserByWX(string id, string tel, string username, string sex, DateTime birthday)
        {

            Model.users user = GetModel(int.Parse(id));
            user.user_name = username;
            user.telphone = tel;
            user.email = "test@weixin.com";
            user.birthday = birthday;
            user.password = tel;
            user.sex = sex;
            return  Update(user);
        }

        #endregion

    }
}