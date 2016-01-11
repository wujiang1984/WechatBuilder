using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 比赛基本表
	/// </summary>
	[Serializable]
	public partial class wx_sjb_bisai
	{
		public wx_sjb_bisai()
		{}
		#region Model
		private int _id;
		private string _bspic;
		private string _bsremark;
		private int? _rcid;
		private int? _qd1id;
		private int? _qd2id;
		private DateTime? _begindate;
		private DateTime? _enddate;
		private DateTime? _jcbegindate;
		private DateTime? _jcenddate;
		private int? _resulttype;
		private int? _rtype1times;
		private int? _rtype2times;
		private int? _rtype3times;
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
		/// 比赛图片
		/// </summary>
		public string bsPic
		{
			set{ _bspic=value;}
			get{return _bspic;}
		}
		/// <summary>
		/// 比赛详情
		/// </summary>
		public string bsRemark
		{
			set{ _bsremark=value;}
			get{return _bsremark;}
		}
		/// <summary>
		/// 日程id
		/// </summary>
		public int? rcId
		{
			set{ _rcid=value;}
			get{return _rcid;}
		}
		/// <summary>
		/// 球队1
		/// </summary>
		public int? qd1Id
		{
			set{ _qd1id=value;}
			get{return _qd1id;}
		}
		/// <summary>
		/// 球队2
		/// </summary>
		public int? qd2Id
		{
			set{ _qd2id=value;}
			get{return _qd2id;}
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
		/// 结束时间
		/// </summary>
		public DateTime? endDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 竞猜开始时间
		/// </summary>
		public DateTime? jcBeginDate
		{
			set{ _jcbegindate=value;}
			get{return _jcbegindate;}
		}
		/// <summary>
		/// 竞猜结束时间
		/// </summary>
		public DateTime? jcEndDate
		{
			set{ _jcenddate=value;}
			get{return _jcenddate;}
		}
		/// <summary>
		/// 结果：1：球队1胜利，2：球队2胜利，3平局
		/// </summary>
		public int? resultType
		{
			set{ _resulttype=value;}
			get{return _resulttype;}
		}
		/// <summary>
		/// 结果1的竞猜次数
		/// </summary>
		public int? rType1Times
		{
			set{ _rtype1times=value;}
			get{return _rtype1times;}
		}
		/// <summary>
		/// 结果2的竞猜次数
		/// </summary>
		public int? rType2Times
		{
			set{ _rtype2times=value;}
			get{return _rtype2times;}
		}
		/// <summary>
		/// 结果3的竞猜次数
		/// </summary>
		public int? rType3Times
		{
			set{ _rtype3times=value;}
			get{return _rtype3times;}
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

