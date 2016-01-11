using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WechatBuilder.Common;
using System.Text;

namespace WechatBuilder.Web.shop
{
    /// <summary>
    /// shopmgr 的摘要说明
    /// </summary>
    public class shopmgr : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            BLL.wx_shop_cart cartBll = new BLL.wx_shop_cart();
            string _action = MyCommFun.QueryString("myact");
            string openid = MyCommFun.RequestOpenid();  //得到微信用户的openid
            Dictionary<string, string> jsonDict = new Dictionary<string, string>();
            if (_action == "addCart")
            {
                #region 添加购物车
                try
                {
                    int wid = MyCommFun.RequestInt("wid");
                    int productId = MyCommFun.RequestInt("productid");
                    int skuId = MyCommFun.RequestInt("mid");
                    string skuInfo = MyCommFun.QueryString("attr");
                    int productNum = MyCommFun.RequestInt("bc");
                    decimal totalPrice = (decimal)MyCommFun.RequestFloat("totprice", 0);

                    Model.wx_shop_cart cart = new Model.wx_shop_cart();

                    IList<Model.wx_shop_cart> cartList = cartBll.GetModelList("productId=" + productId + " and openid='" + openid + "' and skuId=" + skuId);
                    bool isAdd = true;
                    if (cartList != null && cartList.Count > 0)
                    {
                        isAdd = false;
                        cart = cartList[0];
                    }
                    if (isAdd)
                    {
                        cart.createDate = DateTime.Now;
                        cart.openid = openid;
                        cart.productId = productId;
                        cart.productNum = productNum;
                        cart.skuId = skuId;
                        cart.skuInfo = skuInfo;
                        cart.totPrice = totalPrice * productNum;
                        cart.wid = wid;
                        int ret = cartBll.Add(cart);
                        if (ret > 0)
                        {
                            jsonDict.Add("errCode", "false");
                        }
                        else
                        {
                            jsonDict.Add("errCode", "true");
                        }
                    }
                    else
                    {

                        cart.openid = openid;

                        cart.productNum += productNum;
                        cart.skuId = skuId;
                        cart.skuInfo = skuInfo;
                        cart.totPrice += totalPrice * productNum;
                        cart.wid = wid;
                        bool ret = cartBll.Update(cart);
                        if (ret)
                        {
                            jsonDict.Add("errCode", "false");
                        }
                        else
                        {
                            jsonDict.Add("errCode", "true");
                        }
                    }

                }
                catch (Exception ex)
                {
                    jsonDict.Add("errCode", "true");
                }
                finally
                {
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));

                }
                #endregion
            }
            else if (_action == "pcount")
            {
                #region 购物车商品数量
                jsonDict = new Dictionary<string, string>();
                int wid = MyCommFun.RequestInt("wid");
                int count = cartBll.GetRecordCount("wid=" + wid + " and openid='" + openid + "'");
                jsonDict.Add("data", count.ToString());
                context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                #endregion

            }
            else if (_action == "remove")
            {
                #region 移除购物车商品
                jsonDict = new Dictionary<string, string>();
                int cartId = MyCommFun.RequestInt("id");
                cartBll.Delete(cartId);
                jsonDict.Add("errCode", "false");
                context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                #endregion
            }
            else if (_action == "modifyNum")
            {
                #region 修改购物车商品数量
                jsonDict = new Dictionary<string, string>();
                int cartId = MyCommFun.RequestInt("ic");
                int newNum = MyCommFun.RequestInt("bc");
                cartBll.UpdateNum(cartId, newNum);
                jsonDict.Add("errCode", "false");
                context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                #endregion

            }
            else if (_action == "getCity")
            {
                #region 选择省份，改变城市列表
                int privice = MyCommFun.RequestInt("pvid");
                BLL.pre_common_district areaBll = new BLL.pre_common_district();
                IList<Model.pre_common_district> disList = areaBll.GetModelList("upid=" + privice + " and level=2");
                Model.pre_common_district dis;
                StringBuilder jsonStr = new StringBuilder("{\"errCode\":0,\"retCode\":0,\"msgType\":0,\"errMsg\":\"\",\"data\":[");
                for (int i = 0; i < disList.Count; i++)
                {
                    dis = new Model.pre_common_district();
                    if (i != disList.Count - 1)
                    {
                        jsonStr.Append("{\"id\":" + disList[i].id + ",\"name\":\"" + disList[i].name + "\"},");
                    }
                    else
                    {
                        jsonStr.Append("{\"id\":" + disList[i].id + ",\"name\":\"" + disList[i].name + "\"}");
                    }
                }
                jsonStr.Append("]}");
                context.Response.Write(jsonStr);
                #endregion

            }
            else if (_action == "getArea")
            {
                #region 选择城市，改变区域列表
                int ctid = MyCommFun.RequestInt("ctid");
                BLL.pre_common_district areaBll = new BLL.pre_common_district();
                IList<Model.pre_common_district> disList = areaBll.GetModelList("upid=" + ctid + " and level=3");
                Model.pre_common_district dis;
                StringBuilder jsonStr = new StringBuilder("{\"errCode\":0,\"retCode\":0,\"msgType\":0,\"errMsg\":\"\",\"data\":[");
                for (int i = 0; i < disList.Count; i++)
                {
                    dis = new Model.pre_common_district();
                    if (i != disList.Count - 1)
                    {
                        jsonStr.Append("{\"id\":" + disList[i].id + ",\"name\":\"" + disList[i].name + "\"},");
                    }
                    else
                    {
                        jsonStr.Append("{\"id\":" + disList[i].id + ",\"name\":\"" + disList[i].name + "\"}");
                    }
                }
                jsonStr.Append("]}");
                context.Response.Write(jsonStr);
                #endregion

            }
            else if (_action == "order_save")
            {
                #region 保存订单信息
                //获得传参信息
                int wid = MyCommFun.RequestInt("wid");

                int payment_id = MyCommFun.RequestInt("pc");//支付方式：1货到付款；3微支付
                int express_id = MyCommFun.RequestInt("mtype");//物流方式
                // string orderStrList = MyCommFun.QueryString("orderStrList");

                //检查物流方式
                if (express_id == 0)
                {
                    context.Response.Write("{\"errCode\":3, \"msg\":\"对不起，请选择配送方式！\"}");
                    return;
                }
                BLL.wx_shop_user_addr uAddrBll = new BLL.wx_shop_user_addr();
                IList<Model.wx_shop_user_addr> uaddrList = uAddrBll.GetOpenidAddrName(openid, wid);
                if (uaddrList == null || uaddrList.Count <= 0 || uaddrList[0].id <= 0)
                {
                    context.Response.Write("{\"errCode\":3, \"msg\":\"收货地址不存在，无法结算！\"}");
                    return;
                }


                //检查购物车商品
                IList<Model.cartProduct> cartList = cartBll.GetCartList(openid, wid);
                if (cartList == null)
                {
                    context.Response.Write("{\"errCode\":3, \"msg\":\"对不起，购物车为空，无法结算！\"}");
                    return;
                }
                //统计购物车
                decimal payable_amount = cartList.Sum(c => c.totPrice);
                //物流费用
                BLL.express expressBll = new BLL.express();
                Model.express expModel = expressBll.GetModel(express_id);
                //支付方式
                BLL.payment pbll = new BLL.payment();
                Model.payment payModel = pbll.GetModelBypTypeId(payment_id);
                //保存订单=======================================================================
                Model.orders model = new Model.orders();
                model.order_no = "b" + Utils.GetOrderNumber(); //订单号B开头为商品订单

                model.wid = wid;
                model.openid = openid;
                model.modelName = "微商城";
                model.modelCode = "shop";
                model.modelActionName = "";
                model.modelActionId = 0;
                model.user_id = 0;
                model.user_name = "";
                model.payment_id = payment_id;
                model.express_id = express_id;
                model.accept_name = uaddrList[0].contractPerson;
                model.post_code = "";
                model.telphone = uaddrList[0].tel;
                model.mobile = uaddrList[0].tel;
                model.area = uaddrList[0].province;
                model.city = uaddrList[0].city;
                model.district = uaddrList[0].area;
                model.address = uaddrList[0].province + " " + uaddrList[0].city + " " + uaddrList[0].area + " " + uaddrList[0].addrDetail;
                model.message = "";
                model.payable_amount = payable_amount;//应付商品总金额
                model.real_amount = payable_amount;//实际商品总金额，
                model.status = 1;
                model.express_status = 1;
                model.express_fee = expModel.express_fee; //物流费用

                if (payment_id == 1)
                {  //货到付款，需要确认订单
                    model.payment_status = 0; //标记未付款
                }
                else
                {//先款后货
                    model.payment_status = 1; //标记未付款
                }
                bool quicklyFH = false;
                //如果是先款后货的话
                if (payment_id == 3)
                {

                    if (payModel.poundage_type == 1) //百分比
                    {
                        model.payment_fee = model.real_amount * payModel.poundage_amount / 100;
                    }
                    else //固定金额
                    {
                        model.payment_fee = payModel.poundage_amount;
                    }
                    BLL.wx_payment_wxpay wxBll = new BLL.wx_payment_wxpay();
                    Model.wx_payment_wxpay wxpay = wxBll.GetModelByWid(wid);
                    quicklyFH = wxpay.quicklyFH;

                }
                if (quicklyFH)
                {
                    model.express_status = 0;
                }
                //订单总金额=实付商品金额+运费+支付手续费
                model.order_amount = model.real_amount + model.express_fee + model.payment_fee;
                //购物积分,可为负数
                model.point = 0;
                model.add_time = DateTime.Now;
                //商品详细列表
                List<Model.order_goods> gls = new List<Model.order_goods>();
                foreach (Model.cartProduct item in cartList)
                {
                    gls.Add(new Model.order_goods { goods_id = item.productId, goods_title = item.productName, goods_price = item.totPrice, real_price = item.totPrice, quantity = item.productNum, point = 0 });
                }
                model.order_goods = gls;
                int result = new BLL.orders().Add(model);
                if (result < 1)
                {
                    context.Response.Write("{\"errCode\":3, \"msg\":\"订单保存过程中发生错误，请重新提交！\"}");
                    return;
                }

                //清空购物车
                cartBll.RemoveCartInfo(wid, openid);
                //提交成功，返回URL  order_no
                context.Response.Write("{\"errCode\":true, \"payType\":\"" + payment_id + "\", \"order_no\":\"" + model.order_no + "\",\"orderid\":\"" + result + "\",\"wid\":\"" + wid + "\",\"openid\":\"" + openid + "\",\"payable_amount\":\"" + payable_amount + "\", \"msg\":\"恭喜您，订单已成功提交！\"}");
                return;
                #endregion
            }
            else if (_action == "order_canel")
            {
                #region  //取消订单
                int orderid = MyCommFun.RequestInt("order_id");
                BLL.orders oBll = new BLL.orders();
                oBll.UpdateField(orderid, "status=4");
                context.Response.Write("{\"errCode\":true, \"msg\":\"订单已取消！\"}");
                #endregion

            }
            else if (_action == "shouhuo")
            {
                #region  //确认收货
                int orderid = MyCommFun.RequestInt("order_id");
                BLL.orders oBll = new BLL.orders();
                Model.orders order = oBll.GetModel(orderid);
                if (order.payment_id == 1)
                {
                    //货到付款
                    oBll.UpdateField(orderid, "express_status=2,payment_status=2 , status=3");
                }
                else
                {
                    //在线支付
                    oBll.UpdateField(orderid, "express_status=2,payment_status=2 , status=3");
                }

                context.Response.Write("{\"errCode\":true, \"msg\":\"确人收货！\"}");
                #endregion

            }




        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}