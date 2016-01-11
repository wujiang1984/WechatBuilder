using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 订单管理
	/// </summary>
	[Serializable]
	public partial class wx_diancai_dingdan_manage
	{
		public wx_diancai_dingdan_manage()
		{}
		#region Model
		private int _id;
		private int? _shopinfoid;
		private string _openid;
		private int? _wid;
		private string _ordernumber;
		private string _desknumber;
		private string _customername;
		private string _customertel;
		private string _address;
		private DateTime? _odertime;
		private string _oderremark;
		private decimal? _payamount;
		private int? _paystatus;
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
		/// 商家id
		/// </summary>
		public int? shopinfoid
		{
			set{ _shopinfoid=value;}
			get{return _shopinfoid;}
		}
		/// <summary>
		/// 用户openid
		/// </summary>
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 订单号
		/// </summary>
		public string orderNumber
		{
			set{ _ordernumber=value;}
			get{return _ordernumber;}
		}
		/// <summary>
		/// 桌号
		/// </summary>
		public string deskNumber
		{
			set{ _desknumber=value;}
			get{return _desknumber;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string customerName
		{
			set{ _customername=value;}
			get{return _customername;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string customerTel
		{
			set{ _customertel=value;}
			get{return _customertel;}
		}
		/// <summary>
		/// 配送地址
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 下单时间
		/// </summary>
		public DateTime? oderTime
		{
			set{ _odertime=value;}
			get{return _odertime;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string oderRemark
		{
			set{ _oderremark=value;}
			get{return _oderremark;}
		}
		/// <summary>
		/// 总价
		/// </summary>
		public decimal? payAmount
		{
			set{ _payamount=value;}
			get{return _payamount;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int? payStatus
		{
			set{ _paystatus=value;}
			get{return _paystatus;}
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

