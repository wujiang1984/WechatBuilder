using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_ucard_cardinfo
	/// </summary>
	public partial class wx_ucard_cardinfo
	{
		public wx_ucard_cardinfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_ucard_cardinfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_ucard_cardinfo");
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
		public int Add(WechatBuilder.Model.wx_ucard_cardinfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_ucard_cardinfo(");
			strSql.Append("wid,cardName,cardNameColor,logo,isLogoShow,bgTypeId,bgUrl,cardNoColor,indexTip,noticePic,privilegesPic,qiandaoPic,shopingPic,perinfoPic,instructionsPic,contactusPic,createDate,sId,bgTypeUrl)");
			strSql.Append(" values (");
			strSql.Append("@wid,@cardName,@cardNameColor,@logo,@isLogoShow,@bgTypeId,@bgUrl,@cardNoColor,@indexTip,@noticePic,@privilegesPic,@qiandaoPic,@shopingPic,@perinfoPic,@instructionsPic,@contactusPic,@createDate,@sId,@bgTypeUrl)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@cardName", SqlDbType.VarChar,100),
					new SqlParameter("@cardNameColor", SqlDbType.VarChar,20),
					new SqlParameter("@logo", SqlDbType.VarChar,800),
					new SqlParameter("@isLogoShow", SqlDbType.Bit,1),
					new SqlParameter("@bgTypeId", SqlDbType.Int,4),
					new SqlParameter("@bgUrl", SqlDbType.VarChar,800),
					new SqlParameter("@cardNoColor", SqlDbType.VarChar,20),
					new SqlParameter("@indexTip", SqlDbType.VarChar,40),
					new SqlParameter("@noticePic", SqlDbType.VarChar,500),
					new SqlParameter("@privilegesPic", SqlDbType.VarChar,500),
					new SqlParameter("@qiandaoPic", SqlDbType.VarChar,500),
					new SqlParameter("@shopingPic", SqlDbType.VarChar,500),
					new SqlParameter("@perinfoPic", SqlDbType.VarChar,500),
					new SqlParameter("@instructionsPic", SqlDbType.VarChar,500),
					new SqlParameter("@contactusPic", SqlDbType.VarChar,500),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@sId", SqlDbType.Int,4),
					new SqlParameter("@bgTypeUrl", SqlDbType.VarChar,300)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.cardName;
			parameters[2].Value = model.cardNameColor;
			parameters[3].Value = model.logo;
			parameters[4].Value = model.isLogoShow;
			parameters[5].Value = model.bgTypeId;
			parameters[6].Value = model.bgUrl;
			parameters[7].Value = model.cardNoColor;
			parameters[8].Value = model.indexTip;
			parameters[9].Value = model.noticePic;
			parameters[10].Value = model.privilegesPic;
			parameters[11].Value = model.qiandaoPic;
			parameters[12].Value = model.shopingPic;
			parameters[13].Value = model.perinfoPic;
			parameters[14].Value = model.instructionsPic;
			parameters[15].Value = model.contactusPic;
			parameters[16].Value = model.createDate;
			parameters[17].Value = model.sId;
			parameters[18].Value = model.bgTypeUrl;

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
		public bool Update(WechatBuilder.Model.wx_ucard_cardinfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_ucard_cardinfo set ");
			strSql.Append("wid=@wid,");
			strSql.Append("cardName=@cardName,");
			strSql.Append("cardNameColor=@cardNameColor,");
			strSql.Append("logo=@logo,");
			strSql.Append("isLogoShow=@isLogoShow,");
			strSql.Append("bgTypeId=@bgTypeId,");
			strSql.Append("bgUrl=@bgUrl,");
			strSql.Append("cardNoColor=@cardNoColor,");
			strSql.Append("indexTip=@indexTip,");
			strSql.Append("noticePic=@noticePic,");
			strSql.Append("privilegesPic=@privilegesPic,");
			strSql.Append("qiandaoPic=@qiandaoPic,");
			strSql.Append("shopingPic=@shopingPic,");
			strSql.Append("perinfoPic=@perinfoPic,");
			strSql.Append("instructionsPic=@instructionsPic,");
			strSql.Append("contactusPic=@contactusPic,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("sId=@sId,");
			strSql.Append("bgTypeUrl=@bgTypeUrl");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@cardName", SqlDbType.VarChar,100),
					new SqlParameter("@cardNameColor", SqlDbType.VarChar,20),
					new SqlParameter("@logo", SqlDbType.VarChar,800),
					new SqlParameter("@isLogoShow", SqlDbType.Bit,1),
					new SqlParameter("@bgTypeId", SqlDbType.Int,4),
					new SqlParameter("@bgUrl", SqlDbType.VarChar,800),
					new SqlParameter("@cardNoColor", SqlDbType.VarChar,20),
					new SqlParameter("@indexTip", SqlDbType.VarChar,40),
					new SqlParameter("@noticePic", SqlDbType.VarChar,500),
					new SqlParameter("@privilegesPic", SqlDbType.VarChar,500),
					new SqlParameter("@qiandaoPic", SqlDbType.VarChar,500),
					new SqlParameter("@shopingPic", SqlDbType.VarChar,500),
					new SqlParameter("@perinfoPic", SqlDbType.VarChar,500),
					new SqlParameter("@instructionsPic", SqlDbType.VarChar,500),
					new SqlParameter("@contactusPic", SqlDbType.VarChar,500),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@sId", SqlDbType.Int,4),
					new SqlParameter("@bgTypeUrl", SqlDbType.VarChar,300),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.cardName;
			parameters[2].Value = model.cardNameColor;
			parameters[3].Value = model.logo;
			parameters[4].Value = model.isLogoShow;
			parameters[5].Value = model.bgTypeId;
			parameters[6].Value = model.bgUrl;
			parameters[7].Value = model.cardNoColor;
			parameters[8].Value = model.indexTip;
			parameters[9].Value = model.noticePic;
			parameters[10].Value = model.privilegesPic;
			parameters[11].Value = model.qiandaoPic;
			parameters[12].Value = model.shopingPic;
			parameters[13].Value = model.perinfoPic;
			parameters[14].Value = model.instructionsPic;
			parameters[15].Value = model.contactusPic;
			parameters[16].Value = model.createDate;
			parameters[17].Value = model.sId;
			parameters[18].Value = model.bgTypeUrl;
			parameters[19].Value = model.id;

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
			strSql.Append("delete from wx_ucard_cardinfo ");
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
			strSql.Append("delete from wx_ucard_cardinfo ");
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
		public WechatBuilder.Model.wx_ucard_cardinfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,wid,cardName,cardNameColor,logo,isLogoShow,bgTypeId,bgUrl,cardNoColor,indexTip,noticePic,privilegesPic,qiandaoPic,shopingPic,perinfoPic,instructionsPic,contactusPic,createDate,sId,bgTypeUrl from wx_ucard_cardinfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_ucard_cardinfo model=new WechatBuilder.Model.wx_ucard_cardinfo();
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
		public WechatBuilder.Model.wx_ucard_cardinfo DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_ucard_cardinfo model=new WechatBuilder.Model.wx_ucard_cardinfo();
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
				if(row["cardName"]!=null)
				{
					model.cardName=row["cardName"].ToString();
				}
				if(row["cardNameColor"]!=null)
				{
					model.cardNameColor=row["cardNameColor"].ToString();
				}
				if(row["logo"]!=null)
				{
					model.logo=row["logo"].ToString();
				}
				if(row["isLogoShow"]!=null && row["isLogoShow"].ToString()!="")
				{
					if((row["isLogoShow"].ToString()=="1")||(row["isLogoShow"].ToString().ToLower()=="true"))
					{
						model.isLogoShow=true;
					}
					else
					{
						model.isLogoShow=false;
					}
				}
				if(row["bgTypeId"]!=null && row["bgTypeId"].ToString()!="")
				{
					model.bgTypeId=int.Parse(row["bgTypeId"].ToString());
				}
				if(row["bgUrl"]!=null)
				{
					model.bgUrl=row["bgUrl"].ToString();
				}
				if(row["cardNoColor"]!=null)
				{
					model.cardNoColor=row["cardNoColor"].ToString();
				}
				if(row["indexTip"]!=null)
				{
					model.indexTip=row["indexTip"].ToString();
				}
				if(row["noticePic"]!=null)
				{
					model.noticePic=row["noticePic"].ToString();
				}
				if(row["privilegesPic"]!=null)
				{
					model.privilegesPic=row["privilegesPic"].ToString();
				}
				if(row["qiandaoPic"]!=null)
				{
					model.qiandaoPic=row["qiandaoPic"].ToString();
				}
				if(row["shopingPic"]!=null)
				{
					model.shopingPic=row["shopingPic"].ToString();
				}
				if(row["perinfoPic"]!=null)
				{
					model.perinfoPic=row["perinfoPic"].ToString();
				}
				if(row["instructionsPic"]!=null)
				{
					model.instructionsPic=row["instructionsPic"].ToString();
				}
				if(row["contactusPic"]!=null)
				{
					model.contactusPic=row["contactusPic"].ToString();
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["sId"]!=null && row["sId"].ToString()!="")
				{
					model.sId=int.Parse(row["sId"].ToString());
				}
				if(row["bgTypeUrl"]!=null)
				{
					model.bgTypeUrl=row["bgTypeUrl"].ToString();
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
			strSql.Append("select id,wid,cardName,cardNameColor,logo,isLogoShow,bgTypeId,bgUrl,cardNoColor,indexTip,noticePic,privilegesPic,qiandaoPic,shopingPic,perinfoPic,instructionsPic,contactusPic,createDate,sId,bgTypeUrl ");
			strSql.Append(" FROM wx_ucard_cardinfo ");
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
			strSql.Append(" id,wid,cardName,cardNameColor,logo,isLogoShow,bgTypeId,bgUrl,cardNoColor,indexTip,noticePic,privilegesPic,qiandaoPic,shopingPic,perinfoPic,instructionsPic,contactusPic,createDate,sId,bgTypeUrl ");
			strSql.Append(" FROM wx_ucard_cardinfo ");
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
			strSql.Append("select count(1) FROM wx_ucard_cardinfo ");
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
			strSql.Append(")AS Row, T.*  from wx_ucard_cardinfo T ");
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
        /// 取该店铺的会员卡版面设计信息
       /// </summary>
       /// <param name="sId">店铺id</param>
       /// <returns></returns>
        public WechatBuilder.Model.wx_ucard_cardinfo GetModelBySid(int sId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,wid,cardName,cardNameColor,logo,isLogoShow,bgTypeId,bgUrl,cardNoColor,indexTip,noticePic,privilegesPic,qiandaoPic,shopingPic,perinfoPic,instructionsPic,contactusPic,createDate,sId,bgTypeUrl from wx_ucard_cardinfo ");
            strSql.Append(" where sId=@sId");
            SqlParameter[] parameters = {
					new SqlParameter("@sId", SqlDbType.Int,4)
			};
            parameters[0].Value = sId;

            WechatBuilder.Model.wx_ucard_cardinfo model = new WechatBuilder.Model.wx_ucard_cardinfo();
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


		#endregion  ExtensionMethod
	}
}

