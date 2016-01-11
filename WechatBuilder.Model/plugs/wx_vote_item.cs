using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 微投票选项表
	/// </summary>
	[Serializable]
	public partial class wx_vote_item
	{
		public wx_vote_item()
		{}
		#region Model
		private int _id;
		private string _title;
		private int? _sort_id;
		private string _pic_url;
		private string _pic_jump;
		private int? _sid;
		private DateTime? _createdate;
		private int? _baseid;
		private int? _tptimes;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 选项标题
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		/// <summary>
		/// 图片外链地址
		/// </summary>
		public string pic_url
		{
			set{ _pic_url=value;}
			get{return _pic_url;}
		}
		/// <summary>
		/// 图片跳转地址以http://开头
		/// </summary>
		public string pic_jump
		{
			set{ _pic_jump=value;}
			get{return _pic_jump;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sid
		{
			set{ _sid=value;}
			get{return _sid;}
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
		/// 基本表主键
		/// </summary>
		public int? baseid
		{
			set{ _baseid=value;}
			get{return _baseid;}
		}
		/// <summary>
		/// 投票数
		/// </summary>
		public int? tpTimes
		{
			set{ _tptimes=value;}
			get{return _tptimes;}
		}
		#endregion Model

	}
}

