using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 360全景图系统设置
	/// </summary>
	[Serializable]
	public partial class wx_pano_sys
	{
		public wx_pano_sys()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _backpic;
		private int? _seriesid;
		private string _seriesname;
		private DateTime? _createdate;
		private int? _seq;
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
		/// 背景图片
		/// </summary>
		public string backPic
		{
			set{ _backpic=value;}
			get{return _backpic;}
		}
		/// <summary>
		/// 系列id
		/// </summary>
		public int? seriesId
		{
			set{ _seriesid=value;}
			get{return _seriesid;}
		}
		/// <summary>
		/// 系列名称
		/// </summary>
		public string seriesName
		{
			set{ _seriesname=value;}
			get{return _seriesname;}
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
		public int? seq
		{
			set{ _seq=value;}
			get{return _seq;}
		}
		#endregion Model

	}
}

