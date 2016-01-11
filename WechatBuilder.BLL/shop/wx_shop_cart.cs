using System;
using System.Data;
using System.Collections.Generic;
using WechatBuilder.Common;
using WechatBuilder.Model;
namespace WechatBuilder.BLL
{
	/// <summary>
	/// 购物车
	/// </summary>
	public partial class wx_shop_cart
	{
		private readonly WechatBuilder.DAL.wx_shop_cart dal=new WechatBuilder.DAL.wx_shop_cart();
		public wx_shop_cart()
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
		public int  Add(WechatBuilder.Model.wx_shop_cart model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WechatBuilder.Model.wx_shop_cart model)
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
		public WechatBuilder.Model.wx_shop_cart GetModel(int id)
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
		public List<WechatBuilder.Model.wx_shop_cart> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WechatBuilder.Model.wx_shop_cart> DataTableToList(DataTable dt)
		{
			List<WechatBuilder.Model.wx_shop_cart> modelList = new List<WechatBuilder.Model.wx_shop_cart>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WechatBuilder.Model.wx_shop_cart model;
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
        /// 移除购物车里的商品
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="openid"></param>
        /// <returns></returns>
        public bool RemoveCartInfo(int wid, string openid)
        {
          return   dal.RemoveCartInfo(  wid,  openid);
        }

        /// <summary>
        /// 取购物车里的商品信息
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="wid"></param>
        /// <returns></returns>
        public List<Model.cartProduct> GetCartList(string openid, int wid)
        {
            DataSet ds = dal.GetCartList(openid, wid);
            List<Model.cartProduct> cartlist = new List<cartProduct>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                int count = ds.Tables[0].Rows.Count;
                Model.cartProduct  cproduct = new cartProduct();
                DataRow dr;
                for (int i = 0; i < count; i++)
                {
                    dr=ds.Tables[0].Rows[i];
                    cproduct = new cartProduct();
                    cproduct.id = MyCommFun.Obj2Int(dr["id"]);
                    cproduct.openid=MyCommFun.ObjToStr(dr["openid"]);
                    cproduct.productId = MyCommFun.Obj2Int(dr["productId"]);
                    cproduct.productName = MyCommFun.ObjToStr(dr["productName"]);
                    cproduct.productNum = MyCommFun.Obj2Int(dr["productNum"]);
                    cproduct.productPic = MyCommFun.ObjToStr(dr["pic"]);
                    cproduct.skuId = MyCommFun.Obj2Int(dr["skuId"]);
                    cproduct.skuInfo = MyCommFun.ObjToStr(dr["skuInfo"]);
                    cproduct.totPrice = MyCommFun.Str2Decimal(dr["totPrice"].ToString());
                    cproduct.totPrice100 = cproduct.totPrice * 100;
                    cproduct.avgPrice=MyCommFun.decimalF2( cproduct.totPrice/( cproduct.productNum==0?1:cproduct.productNum));
                    cproduct.avgPrice100 = cproduct.avgPrice * 100;
                    cproduct.createDate=MyCommFun.Obj2DateTime(dr["createDate"]);
                    cproduct.wid = MyCommFun.Obj2Int(dr["wid"]);
                    cproduct.stock = MyCommFun.Obj2Int(dr["stock"]);
                    cproduct.productUrl = "/shop/detail.aspx?wid=" + cproduct.wid + "&pid=" + cproduct.productId + "&openid=" + cproduct.openid;
                    cproduct.seq = i;
                    cartlist.Add(cproduct);
                }
            }

            return cartlist;
        }


        /// <summary>
        /// 更新购物车商品数量
        /// </summary>
        public bool UpdateNum(int cartid,int newNum)
        {
            return dal.UpdateNum(cartid, newNum);
        }

		#endregion  ExtensionMethod
	}
}

