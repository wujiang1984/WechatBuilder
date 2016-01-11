using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 景点基本信息表
	/// </summary>
	[Serializable]
	public partial class wx_pano_jd
	{
		public wx_pano_jd()
		{}
		#region Model
		private int _id;
		private int? _sysid;
		private int? _wid;
		private string _jdname;
		private string _music;
		private string _pic_front;
		private string _pic_right;
		private string _pic_behind;
		private string _pic_left;
		private string _pic_top;
		private string _pic_bottom;
		private string _pic_yulan;
		private string _remark;
		private int? _seq;
		private DateTime? _createdate;
		private string _extstr;
		private string _extstr2;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 系统表id
		/// </summary>
		public int? sysId
		{
			set{ _sysid=value;}
			get{return _sysid;}
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
		/// 景点名称
		/// </summary>
		public string jdName
		{
			set{ _jdname=value;}
			get{return _jdname;}
		}
		/// <summary>
		/// 背景音乐
		/// </summary>
		public string music
		{
			set{ _music=value;}
			get{return _music;}
		}
		/// <summary>
		/// 前方图片
		/// </summary>
		public string pic_front
		{
			set{ _pic_front=value;}
			get{return _pic_front;}
		}
		/// <summary>
		/// 右方图片
		/// </summary>
		public string pic_right
		{
			set{ _pic_right=value;}
			get{return _pic_right;}
		}
		/// <summary>
		/// 后方图片
		/// </summary>
		public string pic_behind
		{
			set{ _pic_behind=value;}
			get{return _pic_behind;}
		}
		/// <summary>
		/// 左方图片
		/// </summary>
		public string pic_left
		{
			set{ _pic_left=value;}
			get{return _pic_left;}
		}
		/// <summary>
		/// 顶部图片
		/// </summary>
		public string pic_top
		{
			set{ _pic_top=value;}
			get{return _pic_top;}
		}
		/// <summary>
		/// 底部图片
		/// </summary>
		public string pic_bottom
		{
			set{ _pic_bottom=value;}
			get{return _pic_bottom;}
		}
		/// <summary>
		/// 预览图片
		/// </summary>
		public string pic_yulan
		{
			set{ _pic_yulan=value;}
			get{return _pic_yulan;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int? seq
		{
			set{ _seq=value;}
			get{return _seq;}
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
		#endregion Model

	}
}

