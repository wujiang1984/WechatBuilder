using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 所有用户请求的信息
	/// </summary>
	[Serializable]
	public partial class wx_requst_BaseData
	{
		public wx_requst_BaseData()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _wx_openid;
		private string _wx_msgtype;
		private string _wx_datacontent;
		private string _wx_eventkey;
		private string _wx_createtime;
		private string _wx_url;
		private string _wx_url2;
		private string _wx_xmlcontent;
		private DateTime? _createdate;
		private int? _flag;
		private string _rtype;
		private string _remark;
		private int? _extint;
		private string _extstr;
		private string _extstr2;
		private string _extstr3;
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
		/// 用户的微信id
		/// </summary>
		public string wx_openid
		{
			set{ _wx_openid=value;}
			get{return _wx_openid;}
		}
		/// <summary>
		/// 数据类型 文本消息：text 图片消息:image 地理位置消息:location 链接消息:link 事件推送:event
		/// </summary>
		public string wx_msgType
		{
			set{ _wx_msgtype=value;}
			get{return _wx_msgtype;}
		}
		/// <summary>
		/// 数据内容
		/// </summary>
		public string wx_dataContent
		{
			set{ _wx_datacontent=value;}
			get{return _wx_datacontent;}
		}
		/// <summary>
		/// 事件KEY值
		/// </summary>
		public string wx_eventKey
		{
			set{ _wx_eventkey=value;}
			get{return _wx_eventkey;}
		}
		/// <summary>
		/// 消息创建时间
		/// </summary>
		public string wx_createTime
		{
			set{ _wx_createtime=value;}
			get{return _wx_createtime;}
		}
		/// <summary>
		/// url路径
		/// </summary>
		public string wx_url
		{
			set{ _wx_url=value;}
			get{return _wx_url;}
		}
		/// <summary>
		/// 链接地址2
		/// </summary>
		public string wx_url2
		{
			set{ _wx_url2=value;}
			get{return _wx_url2;}
		}
		/// <summary>
		/// xml原始内容
		/// </summary>
		public string wx_xmlContent
		{
			set{ _wx_xmlcontent=value;}
			get{return _wx_xmlcontent;}
		}
		/// <summary>
		/// 录入系统的时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int? flag
		{
			set{ _flag=value;}
			get{return _flag;}
		}
		/// <summary>
		/// 自定义类型
		/// </summary>
		public string rType
		{
			set{ _rtype=value;}
			get{return _rtype;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 扩展Int字段
		/// </summary>
		public int? extInt
		{
			set{ _extint=value;}
			get{return _extint;}
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
		/// 扩展str3
		/// </summary>
		public string extStr3
		{
			set{ _extstr3=value;}
			get{return _extstr3;}
		}
		#endregion Model

	}
}

