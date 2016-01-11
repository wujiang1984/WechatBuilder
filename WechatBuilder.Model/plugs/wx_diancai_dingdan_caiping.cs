using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 订单对应的菜品表
	/// </summary>
	[Serializable]
	public partial class wx_diancai_dingdan_caiping
	{
		public wx_diancai_dingdan_caiping()
		{}
		#region Model
		private int _id;
		private int? _dingid;
		private int? _caiid;
		private int? _num;
		private decimal? _price;
		private decimal? _totpric;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 订单id
		/// </summary>
		public int? dingId
		{
			set{ _dingid=value;}
			get{return _dingid;}
		}
		/// <summary>
		/// 菜品主键id
		/// </summary>
		public int? caiId
		{
			set{ _caiid=value;}
			get{return _caiid;}
		}
		/// <summary>
		/// 购买份数
		/// </summary>
		public int? num
		{
			set{ _num=value;}
			get{return _num;}
		}
		/// <summary>
		/// 单价
		/// </summary>
		public decimal? price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 总价格
		/// </summary>
		public decimal? totpric
		{
			set{ _totpric=value;}
			get{return _totpric;}
		}
		#endregion Model

	}
}

