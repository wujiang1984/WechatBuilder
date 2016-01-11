using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 数据表2
	/// </summary>
	[Serializable]
	public partial class wx_purchase_customer
	{
		public wx_purchase_customer()
		{}
		#region Model
		private int _id;
		private int? _baseid;
		private string _sn;
		private string _customername;
		private int? _customernum;
		private string _address;
		private string _tel;
		private int? _status;
		private DateTime? _datejoin;
		private DateTime? _dateuse;
		private DateTime? _craetetime;
		private string _openid;
		private string _remark;
		/// <summary>
		/// 编号
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 活动基本表主键
		/// </summary>
		public int? baseid
		{
			set{ _baseid=value;}
			get{return _baseid;}
		}
		/// <summary>
		/// SN码
		/// </summary>
		public string sn
		{
			set{ _sn=value;}
			get{return _sn;}
		}
		/// <summary>
		/// 参团用户
		/// </summary>
		public string customerName
		{
			set{ _customername=value;}
			get{return _customername;}
		}
		/// <summary>
		/// 用户数量
		/// </summary>
		public int? customerNum
		{
			set{ _customernum=value;}
			get{return _customernum;}
		}
		/// <summary>
		/// 地址
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 消费状态
		/// </summary>
        public int? status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 参团时间
		/// </summary>
		public DateTime? dateJoin
		{
			set{ _datejoin=value;}
			get{return _datejoin;}
		}
		/// <summary>
		/// 使用时间
		/// </summary>
		public DateTime? dateUse
		{
			set{ _dateuse=value;}
			get{return _dateuse;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? craeteTime
		{
			set{ _craetetime=value;}
			get{return _craetetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

