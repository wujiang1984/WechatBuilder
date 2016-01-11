using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 微投票基本表
	/// </summary>
	[Serializable]
	public partial class wx_vote_base
	{
		public wx_vote_base()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _title;
		private string _votepic;
		private bool _picdisplay;
		private string _votecontent;
		private bool _isradio;
		private DateTime? _begintime;
		private DateTime? _endtime;
		private int? _resultshowtype;
		private string _acturl;
		private int? _votetype;
		private int? _sort_id;
		private DateTime? _creatdate;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 微帐号
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 标题
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 投票图片
		/// </summary>
		public string votepic
		{
			set{ _votepic=value;}
			get{return _votepic;}
		}
		/// <summary>
		/// 图片显示
		/// </summary>
		public bool picdisplay
		{
			set{ _picdisplay=value;}
			get{return _picdisplay;}
		}
		/// <summary>
		/// 投票说明
		/// </summary>
		public string votecontent
		{
			set{ _votecontent=value;}
			get{return _votecontent;}
		}
		/// <summary>
		/// 是否单选
		/// </summary>
		public bool isRadio
		{
			set{ _isradio=value;}
			get{return _isradio;}
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime? beginTime
		{
			set{ _begintime=value;}
			get{return _begintime;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime? endTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 投票结果
		/// </summary>
		public int? resultShowtype
		{
			set{ _resultshowtype=value;}
			get{return _resultshowtype;}
		}
		/// <summary>
		/// 投票后参加的活动
		/// </summary>
		public string actUrl
		{
			set{ _acturl=value;}
			get{return _acturl;}
		}
		/// <summary>
		/// 投票类型
		/// </summary>
		public int? voteType
		{
			set{ _votetype=value;}
			get{return _votetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? creatDate
		{
			set{ _creatdate=value;}
			get{return _creatdate;}
		}
		#endregion Model

	}
}

