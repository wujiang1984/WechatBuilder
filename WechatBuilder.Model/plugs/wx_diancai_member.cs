using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 会员表
	/// </summary>
	[Serializable]
	public partial class wx_diancai_member
	{
		public wx_diancai_member()
		{}
		#region Model
		private int _id;
		private int? _shopid;
		private string _name;
		private string _openid;
		private DateTime? _createdate;
		private string _weixinname;
		private string _membername;
		private string _menbertel;
		private string _memberaddress;
		private int? _successdingdan;
		private int? _faildingdan;
		private int? _canceldingdan;
		private int? _status;
		private int? _zongjifen;
		private decimal? _zongcje;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 商家ID
		/// </summary>
		public int? shopid
		{
			set{ _shopid=value;}
			get{return _shopid;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
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
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 微信号
		/// </summary>
		public string weixinName
		{
			set{ _weixinname=value;}
			get{return _weixinname;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string memberName
		{
			set{ _membername=value;}
			get{return _membername;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string menberTel
		{
			set{ _menbertel=value;}
			get{return _menbertel;}
		}
		/// <summary>
		/// 地址
		/// </summary>
		public string memberAddress
		{
			set{ _memberaddress=value;}
			get{return _memberaddress;}
		}
		/// <summary>
		/// 成功订单数
		/// </summary>
		public int? successDingdan
		{
			set{ _successdingdan=value;}
			get{return _successdingdan;}
		}
		/// <summary>
		/// 失败订单数
		/// </summary>
		public int? failDingdan
		{
			set{ _faildingdan=value;}
			get{return _faildingdan;}
		}
		/// <summary>
		/// 取消订单数
		/// </summary>
		public int? cancelDingdan
		{
			set{ _canceldingdan=value;}
			get{return _canceldingdan;}
		}
		/// <summary>
		/// 状态
		/// </summary>
        public int? status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 总积分
		/// </summary>
		public int? zongjifen
		{
			set{ _zongjifen=value;}
			get{return _zongjifen;}
		}
		/// <summary>
		/// 总成交额
		/// </summary>
		public decimal? zongcje
		{
			set{ _zongcje=value;}
			get{return _zongcje;}
		}
		#endregion Model

	}
}

