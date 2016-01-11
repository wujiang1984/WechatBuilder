使用说明：
参考Example.cs，使用步骤分为三步:
（1）设置基本的参数如appid，paysignkey等
	wxPayHelper.SetAppId("wxf8b4f85f3a794e77");
	wxPayHelper.SetAppKey("2Wozy2aksie1puXUBpWD8oZxiD1DfQuEaiC7KcRATv1Ino3mdopKaPGQQ7TtkNySuAmCaDCrw4xhPY5qKTBl7Fzm0RgR3c0WaVYIXZARsxzHV2x7iwPPzOz94dnwPWSn");
	wxPayHelper.SetPartnerKey("8934e7d15453e97507ef794cf7b0519d");
	wxPayHelper.SetSignType("sha1");
（2）设置package的参数：订单号、商品价格等
	wxPayHelper.SetParameter("bank_type", "WX");
	wxPayHelper.SetParameter("body", "test");
	wxPayHelper.SetParameter("partner", "1900000109");
	wxPayHelper.SetParameter("out_trade_no", Wxpay.CommonUtil.CreateNoncestr());
	wxPayHelper.SetParameter("total_fee", "1");
	wxPayHelper.SetParameter("fee_type", "1");
	wxPayHelper.SetParameter("notify_url", "htttp://www.baidu.com");
	wxPayHelper.SetParameter("spbill_create_ip", "127.0.0.1");
	wxPayHelper.SetParameter("input_charset", "GBK");
（3）生成对应的支付请求：
	例如: 生成jsapi的请求:
	System.Console.Out.WriteLine(wxPayHelper.CreateBizPackage());
