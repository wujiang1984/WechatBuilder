using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 喜帖基本信息表
	/// </summary>
	[Serializable]
	public partial class wx_xt_base
	{
		public wx_xt_base()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _wxtitle;
		private string _keywords;
		private string _fengmian;
		private string _donghua;
		private string _donghuaslt;
		private string _manname;
		private string _felmanname;
		private int? _nameseq;
		private string _tel;
		private DateTime? _statedate;
		private string _addr;
		private decimal? _lngx;
		private decimal? _laty;
		private string _video;
		private string _video2;
		private string _music;
		private string _word;
		private string _sqrurl;
		private string _copyrite;
		private DateTime? _createdate;
		private int? _templateid;
		private string _templatename;
		private string _pwd;
		private string _extstr;
		private string _extstr2;
		private int? _extint;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 微帐号主键id
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 喜帖标题
		/// </summary>
		public string wxTitle
		{
			set{ _wxtitle=value;}
			get{return _wxtitle;}
		}
		/// <summary>
		/// 关键词
		/// </summary>
		public string keywords
		{
			set{ _keywords=value;}
			get{return _keywords;}
		}
		/// <summary>
		/// 封面url
		/// </summary>
		public string fengmian
		{
			set{ _fengmian=value;}
			get{return _fengmian;}
		}
		/// <summary>
		/// 动画url
		/// </summary>
		public string donghua
		{
			set{ _donghua=value;}
			get{return _donghua;}
		}
		/// <summary>
		/// 动画缩略图
		/// </summary>
		public string donghuaSlt
		{
			set{ _donghuaslt=value;}
			get{return _donghuaslt;}
		}
		/// <summary>
		/// 新郎名称
		/// </summary>
		public string manName
		{
			set{ _manname=value;}
			get{return _manname;}
		}
		/// <summary>
		/// 新娘名称
		/// </summary>
		public string felmanName
		{
			set{ _felmanname=value;}
			get{return _felmanname;}
		}
		/// <summary>
		/// 姓名排序：1新郎在前，2新娘在前
		/// </summary>
		public int? nameSeq
		{
			set{ _nameseq=value;}
			get{return _nameseq;}
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
		/// 婚宴时间
		/// </summary>
		public DateTime? statedate
		{
			set{ _statedate=value;}
			get{return _statedate;}
		}
		/// <summary>
		/// 宴席地点
		/// </summary>
		public string addr
		{
			set{ _addr=value;}
			get{return _addr;}
		}
		/// <summary>
		/// x轴坐标（经度）
		/// </summary>
		public decimal? lngX
		{
			set{ _lngx=value;}
			get{return _lngx;}
		}
		/// <summary>
		/// y轴左边（纬度）
		/// </summary>
		public decimal? latY
		{
			set{ _laty=value;}
			get{return _laty;}
		}
		/// <summary>
		/// 喜帖视频url
		/// </summary>
		public string video
		{
			set{ _video=value;}
			get{return _video;}
		}
		/// <summary>
		/// 视频2
		/// </summary>
		public string video2
		{
			set{ _video2=value;}
			get{return _video2;}
		}
		/// <summary>
		/// 音乐url
		/// </summary>
		public string music
		{
			set{ _music=value;}
			get{return _music;}
		}
		/// <summary>
		/// 想要给朋友说的话：
		/// </summary>
		public string word
		{
			set{ _word=value;}
			get{return _word;}
		}
		/// <summary>
		/// 二维码地址
		/// </summary>
		public string sqrurl
		{
			set{ _sqrurl=value;}
			get{return _sqrurl;}
		}
		/// <summary>
		/// 版权
		/// </summary>
		public string copyrite
		{
			set{ _copyrite=value;}
			get{return _copyrite;}
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
		/// 模版表Id
		/// </summary>
		public int? templateId
		{
			set{ _templateid=value;}
			get{return _templateid;}
		}
		/// <summary>
		/// 模版名称
		/// </summary>
		public string templateName
		{
			set{ _templatename=value;}
			get{return _templatename;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string pwd
		{
			set{ _pwd=value;}
			get{return _pwd;}
		}
		/// <summary>
		/// 扩展str
		/// </summary>
		public string extStr
		{
			set{ _extstr=value;}
			get{return _extstr;}
		}
		/// <summary>
		/// 扩展str2
		/// </summary>
		public string extStr2
		{
			set{ _extstr2=value;}
			get{return _extstr2;}
		}
		/// <summary>
		/// 扩展int
		/// </summary>
		public int? extInt
		{
			set{ _extint=value;}
			get{return _extint;}
		}
		#endregion Model

	}
}

