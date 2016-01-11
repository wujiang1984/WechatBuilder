using System;
using System.Data;
using System.Collections.Generic;
using WechatBuilder.Common;
using WechatBuilder.Model;
namespace WechatBuilder.BLL
{
	/// <summary>
	/// 数据表2
	/// </summary>
	public partial class wx_purchase_customer
	{
		private readonly WechatBuilder.DAL.wx_purchase_customer dal=new WechatBuilder.DAL.wx_purchase_customer();
		public wx_purchase_customer()
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
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(WechatBuilder.Model.wx_purchase_customer model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WechatBuilder.Model.wx_purchase_customer model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			return dal.Delete(Id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			return dal.DeleteList(Idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public WechatBuilder.Model.wx_purchase_customer GetModellist(int Id)
		{

            return dal.GetModellist(Id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		

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
		public List<WechatBuilder.Model.wx_purchase_customer> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WechatBuilder.Model.wx_purchase_customer> DataTableToList(DataTable dt)
		{
			List<WechatBuilder.Model.wx_purchase_customer> modelList = new List<WechatBuilder.Model.wx_purchase_customer>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WechatBuilder.Model.wx_purchase_customer model;
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
		public int GetRecordCount(string strWhere,int id)
		{
			return dal.GetRecordCount(strWhere,id);
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
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        public bool Deletebaseid(int Id)
        {

            return dal.Deletebaseid(Id);
        }

        public bool Exists(string openid)
        {
            return dal.Exists(openid);
        }


        public WechatBuilder.Model.wx_purchase_customer GetModelSN(int Id)
        {

            return dal.GetModelSN(Id);
        }

        public WechatBuilder.Model.wx_purchase_customer GetModelopenid(string openid)
        {

            return dal.GetModelopenid(openid);
        }

        public WechatBuilder.Model.wx_purchase_customer GetModelSN(string openId)
        {

            return dal.GetModelSN(openId);
        }

        public int GetRecordCount(int id)
        {
            return dal.GetRecordCount(id);
        }


        public int GetRecordAmount(int id)
        {
            return dal.GetRecordAmount(id);
        }

        public int GetRecordyg(string openid,int id)
        {
            return dal.GetRecordyg(openid, id);
        }

        public int GetRecord(int id)
        {
            return dal.GetRecord(id);
        }

		#endregion  ExtensionMethod
	}
}

