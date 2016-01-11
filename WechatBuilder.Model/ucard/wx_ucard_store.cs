using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 会员卡店铺信息
	/// </summary>
	[Serializable]
	public partial class wx_ucard_store
	{
		public wx_ucard_store()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _storename;
		private string _logo;
		private string _storecatagory;
		private string _cardbrief;
		private string _consumepwd;
		private string _tel;
		private string _addr;
		private decimal? _xpoint;
		private decimal? _ypoint;
		private DateTime? _createdate;
		private int? _sort_id;
		private bool _isrecommend;
		private string _hfpic;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 微帐号id
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 店铺名称
		/// </summary>
		public string storeName
		{
			set{ _storename=value;}
			get{return _storename;}
		}
		/// <summary>
		/// logo图片地址
		/// </summary>
		public string logo
		{
			set{ _logo=value;}
			get{return _logo;}
		}
		/// <summary>
		/// 店铺分类
		/// </summary>
		public string storeCatagory
		{
			set{ _storecatagory=value;}
			get{return _storecatagory;}
		}
		/// <summary>
		/// 简介
		/// </summary>
		public string cardBrief
		{
			set{ _cardbrief=value;}
			get{return _cardbrief;}
		}
		/// <summary>
		/// 消费密码
		/// </summary>
		public string consumePwd
		{
			set{ _consumepwd=value;}
			get{return _consumepwd;}
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
		/// 地址
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
		/// 创建时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
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
		/// 是否推荐
		/// </summary>
		public bool isRecommend
		{
			set{ _isrecommend=value;}
			get{return _isrecommend;}
		}
		/// <summary>
		/// 关键词回复的图片
		/// </summary>
		public string hfPic
		{
			set{ _hfpic=value;}
			get{return _hfpic;}
		}
		#endregion Model

	}
}

