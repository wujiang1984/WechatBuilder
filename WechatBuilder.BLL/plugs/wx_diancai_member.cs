using System;
using System.Data;
using System.Collections.Generic;
using WechatBuilder.Common;
using WechatBuilder.Model;
namespace WechatBuilder.BLL
{
	/// <summary>
	/// 会员表
	/// </summary>
	public partial class wx_diancai_member
	{
		private readonly WechatBuilder.DAL.wx_diancai_member dal=new WechatBuilder.DAL.wx_diancai_member();
		public wx_diancai_member()
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
		public int  Add(WechatBuilder.Model.wx_diancai_member model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WechatBuilder.Model.wx_diancai_member model)
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
		public WechatBuilder.Model.wx_diancai_member GetModel(int id)
		{
			
			return dal.GetModel(id);
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
		public List<WechatBuilder.Model.wx_diancai_member> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WechatBuilder.Model.wx_diancai_member> DataTableToList(DataTable dt)
		{
			List<WechatBuilder.Model.wx_diancai_member> modelList = new List<WechatBuilder.Model.wx_diancai_member>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WechatBuilder.Model.wx_diancai_member model;
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

        public int dingdantoday(int shopid)
		{
            return dal.dingdantoday(shopid);
		}
        public int dingdanzuotian(int shopid)
		{
            return dal.dingdanzuotian(shopid);
		}

        public int dingdanbenyue(int shopid)
		{
            return dal.dingdanbenyue(shopid);
		}
        public int dingdanshangyue(int shopid)
		{
            return dal.dingdanshangyue(shopid);
		}

        public float yyetoday(int shopid)
		{
            return dal.yyetoday(shopid);
		}
        public float yyezuotian(int shopid)
		{
            return dal.yyezuotian(shopid);
		}
        public float yyebenyue(int shopid)
		{
            return dal.yyebenyue(shopid);
		}
        public float yyeshangyue(int shopid)
		{
            return dal.yyeshangyue(shopid);
		}


        public int khtoday(int shopid)
		{
            return dal.khtoday(shopid);
		}

        public int khzuotian(int shopid)
		{
            return dal.khzuotian(shopid);
		}

        public int khbenyue(int shopid)
		{
            return dal.khbenyue(shopid);
		}

        public int khshangyue(int shopid)
		{
            return dal.khshangyue(shopid);
		}


        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        
		#endregion  ExtensionMethod
	}
}

