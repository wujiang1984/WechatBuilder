using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 喜帖相册
	/// </summary>
	[Serializable]
	public partial class wx_xt_photo
	{
		public wx_xt_photo()
		{}
		#region Model
		private int _id;
		private int? _bid;
		private string _pname;
		private string _purl;
		private string _remark;
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
		/// 基本表主键Id
		/// </summary>
		public int? bId
		{
			set{ _bid=value;}
			get{return _bid;}
		}
		/// <summary>
		/// 图片名称
		/// </summary>
		public string pName
		{
			set{ _pname=value;}
			get{return _pname;}
		}
		/// <summary>
		/// 图片地址
		/// </summary>
		public string pUrl
		{
			set{ _purl=value;}
			get{return _purl;}
		}
		/// <summary>
		/// 图片说明
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
		#endregion Model

	}
}

