using System;
using System.Data;
using System.Collections.Generic;
using WechatBuilder.Common;
using WechatBuilder.Model;
namespace WechatBuilder.BLL
{
	/// <summary>
	/// 优惠券
	/// </summary>
	public partial class wx_ucard_ticket
	{
		private readonly WechatBuilder.DAL.wx_ucard_ticket dal=new WechatBuilder.DAL.wx_ucard_ticket();
		public wx_ucard_ticket()
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
		public int  Add(WechatBuilder.Model.wx_ucard_ticket model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WechatBuilder.Model.wx_ucard_ticket model)
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
		public WechatBuilder.Model.wx_ucard_ticket GetModel(int id)
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
		public List<WechatBuilder.Model.wx_ucard_ticket> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WechatBuilder.Model.wx_ucard_ticket> DataTableToList(DataTable dt)
		{
			List<WechatBuilder.Model.wx_ucard_ticket> modelList = new List<WechatBuilder.Model.wx_ucard_ticket>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WechatBuilder.Model.wx_ucard_ticket model;
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
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

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
        /// 通过存储过程获得用户的优惠券id
        /// </summary>
        /// <param name="sid">店铺主键id</param>
        /// <param name="uid">用户主键id</param>
        /// <param name="degreeNum">用户级别</param>
        /// <param name="ttcMoney">用户总的消费金额</param>
        /// <returns>返回优惠券id主键字符串，使用英文逗号(,)隔开   </returns>
        public string getUserTicketStr(int sid, int uid, int degreeNum, decimal ttcMoney)
        {
            return dal.getUserTicketStr(sid, uid, degreeNum, ttcMoney);
        }

        /// <summary>
        /// 函数-查询会员对该优惠券使用的剩余次数
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="ticketId"></param>
        /// <returns></returns>
        public int getsyTimesByTicket(int uid, int ticketId)
        {
            return dal.getsyTimesByTicket(  uid,   ticketId);
        }
		#endregion  ExtensionMethod
	}
}

