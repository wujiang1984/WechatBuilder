using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 分店
	/// </summary>
	[Serializable]
	public partial class wx_ucard_store_fendian
	{
		public wx_ucard_store_fendian()
		{}
		#region Model
		private int _id;
		private int? _sid;
		private string _area;
		private string _addr;
		private decimal? _xpoint;
		private decimal? _ypoint;
		private string _tel;
		private int? _sort_id;
		private DateTime? _createdate;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 店铺id
		/// </summary>
		public int? sId
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 区域
		/// </summary>
		public string area
		{
			set{ _area=value;}
			get{return _area;}
		}
		/// <summary>
		/// 详细地址
		/// </summary>
		public string addr
		{
			set{ _addr=value;}
			get{return _addr;}
		}
		/// <summary>
		/// x坐标
		/// </summary>
		public decimal? xPoint
		{
			set{ _xpoint=value;}
			get{return _xpoint;}
		}
		/// <summary>
		/// y坐标
		/// </summary>
		public decimal? yPoint
		{
			set{ _ypoint=value;}
			get{return _ypoint;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 排序号
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

