using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 可以选择的支付类型
	/// </summary>
	[Serializable]
	public partial class wx_payment_type
	{
		public wx_payment_type()
		{}
		#region Model
		private int _id;
		private string _typecode;
		private string _typename;
		private string _remark;
		private int? _sort_id;
		private string _img_url;
		private string _api_path;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 类型编码
		/// </summary>
		public string typeCode
		{
			set{ _typecode=value;}
			get{return _typecode;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string typeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		/// <summary>
		/// 备注信息
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
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
		/// 图片log
		/// </summary>
		public string img_url
		{
			set{ _img_url=value;}
			get{return _img_url;}
		}
		/// <summary>
		/// api目录
		/// </summary>
		public string api_path
		{
			set{ _api_path=value;}
			get{return _api_path;}
		}
		#endregion Model

	}
}

