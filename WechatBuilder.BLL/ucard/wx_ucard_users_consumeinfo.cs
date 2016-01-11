using System;
using System.Data;
using System.Collections.Generic;
using WechatBuilder.Common;
using WechatBuilder.Model;
namespace WechatBuilder.BLL
{
	/// <summary>
	/// 会员积分明细
	/// </summary>
	public partial class wx_ucard_users_consumeinfo
	{
		private readonly WechatBuilder.DAL.wx_ucard_users_consumeinfo dal=new WechatBuilder.DAL.wx_ucard_users_consumeinfo();
		public wx_ucard_users_consumeinfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isXiaoFei">是否为消费积分</param>
        /// <returns></returns>
		public int  Add(WechatBuilder.Model.wx_ucard_users_consumeinfo model,bool isXiaoFei)
		{
            return dal.Add(model, isXiaoFei);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WechatBuilder.Model.wx_ucard_users_consumeinfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WechatBuilder.Model.wx_ucard_users_consumeinfo GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		 

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WechatBuilder.Model.wx_ucard_users_consumeinfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WechatBuilder.Model.wx_ucard_users_consumeinfo> DataTableToList(DataTable dt)
		{
			List<WechatBuilder.Model.wx_ucard_users_consumeinfo> modelList = new List<WechatBuilder.Model.wx_ucard_users_consumeinfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WechatBuilder.Model.wx_ucard_users_consumeinfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

           /// <summary>
        /// 这个日期是否签到了
        /// </summary>
        public bool hasDayQD(int sId, int uid, DateTime time)
        {
            return dal.hasDayQD(sId, uid, time);
        }


        /// <summary>
        /// 新增积分记录，比如签到
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isEW">额外的奖励,1为连续6天签到</param>
        /// <returns></returns>
        public int AddJiFen(Model.wx_ucard_users_consumeinfo model, int isEW)
        {
            return dal.AddJiFen(model, isEW);
        }

      
        /// <summary>
        /// 更新一条记录，并且将用户的总积分随之变动
        /// </summary>
        /// <param name="model"></param>
        /// <param name="oldMoney">活动原来的钱（需要减去）</param>
        /// <param name="oldScore">活动原来的积分（需要减去）</param>
        /// <returns></returns>
        public bool UpdateInfoAndUserTT(WechatBuilder.Model.wx_ucard_users_consumeinfo model, decimal oldMoney, int oldScore)
        {
            return dal.UpdateInfoAndUserTT(model, oldMoney, oldScore);
        }

        /// <summary>
        /// 查询消费信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="sid">店铺id</param>
        /// <param name="moduleType">功能模块名称</param>
        /// <returns></returns>
        public DataSet GetConsumeInfoList(string strWhere, int sid, string moduleType)
        {
            return dal.GetConsumeInfoList(strWhere, sid, moduleType);
        }
		#endregion  ExtensionMethod
	}
}

