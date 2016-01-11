using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 上墙活动表
	/// </summary>
	[Serializable]
	public partial class wx_sq_act
	{
		public wx_sq_act()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private bool _isopen;
		private string _actname;
		private string _brief;
		private bool _shenghe;
		private string _noshenghetip;
		private string _shenghetip;
		private string _bannerpic;
		private DateTime? _enddate;
		private DateTime? _begindate;
		private DateTime? _createdate;
		private int? _sort_id;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 微帐号主键Id
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 开启
		/// </summary>
		public bool isOpen
		{
			set{ _isopen=value;}
			get{return _isopen;}
		}
		/// <summary>
		/// 活动名称
		/// </summary>
		public string actName
		{
			set{ _actname=value;}
			get{return _actname;}
		}
		/// <summary>
		/// 简介
		/// </summary>
		public string brief
		{
			set{ _brief=value;}
			get{return _brief;}
		}
		/// <summary>
		/// 是否需要审核
		/// </summary>
		public bool shenghe
		{
			set{ _shenghe=value;}
			get{return _shenghe;}
		}
		/// <summary>
		/// 没有审核的提示语句
		/// </summary>
		public string noshengheTip
		{
			set{ _noshenghetip=value;}
			get{return _noshenghetip;}
		}
		/// <summary>
		/// 审核的提示语句
		/// </summary>
		public string shengheTip
		{
			set{ _shenghetip=value;}
			get{return _shenghetip;}
		}
		/// <summary>
		/// 头部图片
		/// </summary>
		public string bannerPic
		{
			set{ _bannerpic=value;}
			get{return _bannerpic;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime? endDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime? beginDate
		{
			set{ _begindate=value;}
			get{return _begindate;}
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
		/// 排序
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		#endregion Model

	}
}

