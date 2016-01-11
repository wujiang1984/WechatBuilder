using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 产品库评论
	/// </summary>
	[Serializable]
	public partial class wx_product_comment
	{
		public wx_product_comment()
		{}
		#region Model
		private int _id;
		private int? _hdid;
		private string _openid;
		private string _commentcontent;
		private int? _commenttype;
		private string _commentremark;
		private DateTime? _createdate;
		private int? _replystatus;
		private string _replyperson;
		private string _replycontent;
		private DateTime? _replydate;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 微活动主表id
		/// </summary>
		public int? hdId
		{
			set{ _hdid=value;}
			get{return _hdid;}
		}
		/// <summary>
		/// 评论者微信唯一号
		/// </summary>
		public string openId
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 评论内容
		/// </summary>
		public string commentContent
		{
			set{ _commentcontent=value;}
			get{return _commentcontent;}
		}
		/// <summary>
		/// 评论结果类型
		/// </summary>
		public int? commentType
		{
			set{ _commenttype=value;}
			get{return _commenttype;}
		}
		/// <summary>
		/// 评论备注
		/// </summary>
		public string commentRemark
		{
			set{ _commentremark=value;}
			get{return _commentremark;}
		}
		/// <summary>
		/// 评论时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 回复状态
		/// </summary>
		public int? replyStatus
		{
			set{ _replystatus=value;}
			get{return _replystatus;}
		}
		/// <summary>
		/// 回复者
		/// </summary>
		public string replyPerson
		{
			set{ _replyperson=value;}
			get{return _replyperson;}
		}
		/// <summary>
		/// 回复内容
		/// </summary>
		public string replyContent
		{
			set{ _replycontent=value;}
			get{return _replycontent;}
		}
		/// <summary>
		/// 回复时间
		/// </summary>
		public DateTime? replyDate
		{
			set{ _replydate=value;}
			get{return _replydate;}
		}
		#endregion Model

	}
}

