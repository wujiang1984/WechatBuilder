<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="diancai_shoppingCart.aspx.cs" Inherits="WechatBuilder.Web.weixin.diancai.diancai_shoppingCart" %>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <title><%=hotelName %></title>
    <link href="css/diancai.css?20131223" rel="stylesheet" type="text/css" />
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="js/cookie.js" type="text/javascript"></script>
    <script src="js/alert.js" type="text/javascript"></script>
   
</head>

<body id="mymenu">

    <div id="mcover" onclick="document.getElementById('mcover').style.display='';">

        <div class="textPopup">
            <h2>是否清空菜单？</h2>
            <div>
                <a class="two ok" id="ok" href="javascript:void(0)">确定</a>
                <a class="two" href="javascript:void(0)">取消</a>
            </div>
            <a class="x" onclick="document.getElementById('mcover').style.display='';">X</a>
        </div>
    </div>

    <div class="menu_header">
        <div class="menu_topbar">
            <strong class="head-title">购物车</strong>
            <span class="head_btn_left"><a href="javascript:history.go(-1);"><span>返回</span></a><b></b></span>
            <a class="head_btn_right" href="caidan_shangjia.aspx?aid=<%=aid %>&shopid=<%=shopid %>&openid=<%=openid %>">
                <span><i class="menu_header_home"></i></span><b></b>
            </a>
        </div>
    </div>

    <div class="header">
        <span class="pCount">请叫服务员下单</span>
        <label><i>共计：</i><b id="totalPrice" class="duiqi">0</b><b class="duiqi">元</b></label>
    </div>

    <div class="biaodan">
        <h2>我的订单
                <button id="clearBtn" class="btn_add emptyIt" onclick="clearCache();">清空</button>
            <a href="index.aspx?aid=<%=aid %>&shopid=<%=shopid %>&openid=">
                <button class="btn_add">继续点单外卖</button></a>
        </h2>


        <section class="order">
            <div class="orderlist">
                <ul id="ullist">

                    <%-- <li class="ccbg2" id="notEnoughLi" style="display: none;">必须要满12元才能下单哦</li>
      <li class="ccbg2" id="emptyLi" style="display: none;">购物车为空哦，快去挑选吧！</li>--%>
                </ul>
            </div>
        </section>


    </div>

    <form name="infoForm" id="infoForm" method="post" action="">
        <input type="hidden" name="issubmit" value="0">
        <input type="hidden" name="goodsData"  id="goodsData" value="">

        <input type="hidden" name="formhash" id="formhash" value="52ebc03e" />
        <div class="contact-info">

            <ul>
                <li class="title">联系信息</li>
                <li>
                    <table style="padding: 0; margin: 0; width: 100%;">
                        <tbody>
                            <tr>
                                <td width="80px">
                                    <label for="name" class="ui-input-text">联系人：</label></td>
                                <td>
                                    <div class="ui-input-text">
                                        <input type="text" id="name" name="name" value="<%=name %>" placeholder="" class="ui-input-text">
                                    </div>
                                </td>
                            </tr>
                            <tr id="nameinfo-layout" style="display: none;">
                                <td width="80px"></td>
                                <td colspan="2" id="nameinfo" class="cart-editalertinfo"></td>
                            </tr>
                            <tr>
                                <td width="80px">
                                    <label for="phone" class="ui-input-text">联系电话：</label></td>
                                <td>
                                    <div class="ui-input-text">
                                        <input type="tel" id="phone" name="phone"  value="<%=phone %>" placeholder="" class="ui-input-text">
                                    </div>
                                </td>
                            </tr>
                            <tr id="phoneinfo-layout" style="display: none;">
                                <td width="80px"></td>
                                <td colspan="2" id="phoneinfo" class="cart-editalertinfo"></td>
                            </tr>

                            <tr>
                                <td width="80px">
                                    <label for="address" class="ui-input-text">地址：</label></td>
                                <td>
                                    <textarea id="note" name="address" runat="server" placeholder="" class="ui-input-text"></textarea>
                                </td>
                            </tr>

                            <tr id="addressinfo-layout">
                                <td width="80px"></td>
                                <td colspan="2" id="addressinfo" class="cart-editalertinfo"></td>
                            </tr>
                            <tr>
                                <td width="80px">
                                    <label for="note" class="ui-input-text">备注：</label></td>
                                <td>
                                    <textarea id="Textarea1" name="note" placeholder="" class="ui-input-text"></textarea></td>
                            </tr>
                        </tbody>
                    </table>

                    <table style="display: none" id="paypassword-layout">
                        <tbody>
                            <tr>
                                <td width="80px">
                                    <label for="paypassword" class="ui-input-text">交易密码：</label></td>
                                <td width="80px">
                                    <div class="ui-input-text">
                                        <input type="password" id="paypassword" name="paypassword" class="ui-input-text">
                                    </div>
                                </td>
                                <td></td>
                            </tr>
                            <tr id="paypasswordinfo-layout">
                                <td width="80px"></td>
                                <td colspan="2" id="paypasswordinfo" class="cart-editalertinfo"></td>
                            </tr>
                        </tbody>
                    </table>

                    <table style="display: none" id="captcha-layout" style="word-wrap: break-word; word-break: break-all;">
                        <tbody>
                            <tr>
                                <td width="80px">
                                    <label for="captcha" class="ui-input-text">验证码：</label></td>
                                <td width="80px">
                                    <div class="ui-input-text">
                                        <input type="tel" id="captcha" name="captcha" class="ui-input-text">
                                    </div>
                                </td>
                                <td style="padding-left: 5px;">
                                    <div class="ui-btn">
                                        <span class="ui-btn-inner"><span class="ui-btn-text">发送验证码</span></span>
                                        <button id="getcaptcha" type="button" data-mini="true" onclick="sendCaptcha(80063, 'oXWABj3CUPSffzJj7asG2Ptc0uEY', 19, 7)" class="ui-btn-hidden" data-disabled="false">发送验证码</button>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td width="80px"></td>
                                <td colspan="2" id="cart-captchainfo" class="cart-editalertinfo">第一次下单需要验证手机号码，请点击上面的按钮获取。</td>
                            </tr>
                        </tbody>
                    </table>
                </li>
            </ul>
        </div>



        <div class="footReturn" style="margin-bottom: 70px;">
            <a id="showcard" class="submit" href="javascript:submitOrder();">确定提交</a>
        </div>

    </form>

    <div class="footermenu">
        <ul>
            <li>
                <a href="caidan_guanyu.aspx?aid=<%=aid %>&shopid=<%=shopid %>&openid=<%=openid %>">
                    <img src="images/xxyX63YryG.png">
                    <p>关于</p>
                </a>
            </li>
            <li>
                <a  href="index.aspx?aid=<%=aid %>&shopid=<%=shopid %>&openid=<%=openid %>">
                    <img src="images/Lngjm86JQq.png">
                    <p>点单外卖</p>
                </a>
            </li>
            <li>
                <a class="active" href="diancai_shoppingCart.aspx?aid=<%=aid %>&shopid=<%=shopid %>&openid=<%=openid %>">
                    <span class="num" id="cartN2">0</span>
                    <img src="images/2yFKO6TwKI.png">
                    <p>购物车</p>
                </a>
            </li>
            <li>
                <a href="diancai_oder.aspx?aid=<%=aid %>&shopid=<%=shopid %>&openid=<%=openid %>">
                    <img src="images/s22KaR0Wtc.png">
                    <p>订单</p>
                </a>
            </li>
            <li>
                <a href="diancai_geren.aspx?aid=<%=aid %>&shopid=<%=shopid %>&openid=<%=openid %>">
                    <img src="images/J0uZbXQWvJ.png">
                    <p>我的</p>
                </a>
            </li>
        </ul>
    </div>
     <script>
         var OAK = OAK || {};
         OAK.Dom = {};
         OAK.Shop = {};
         OAK.Util = {};
         OAK.Dom.setAttributes = function (el, prop) {
             for (var i in prop) {
                 el.setAttribute(i, prop[i]);
             }
             return el;
         }
         OAK.Util.setProps = function (s, prop) {
             for (var i in prop) {
                 s[i] = prop[i];
             }
             return s;
         }
         OAK.Util.isEqualInConditions = function (o, conditions) {
             for (var i in conditions) {
                 if (o[i] != conditions[i]) {
                     return false;
                 }
             }
             return true;
         }
         OAK.Util.copy = function (o) {
             var res = new Object();
             for (var i in o) {
                 res[i] = o[i];
             }
             return res;
         }
         OAK.Util.setParam = function (name, value) {
             localStorage.setItem(name, value);
         }
         OAK.Util.getParam = function (name) {
             return localStorage.getItem(name);
         }
         OAK.Shop.Product = function (prop) {
             var prod = {
                 id: 0,
                 name: "",
                 specId: 0,
                 price: 0.00,
                 number: 0,
                 categoryId: 0
             };
             return new OAK.Util.setProps(prod, prop);
         }
         OAK.Shop.Cart = function () {
             if (typeof OAK.Shop.Cart.single_instance === "undefined") {
                 this._totalNumber = 0;
                 this._totalAmount = 0.00;
                 this._products = [];
                 this.onBeforeAdd = null;
                 this.onAfterAdd = null;
                 this.onBeforeUpdate = null;
                 this.onAfterUpdate = null;
                 this.onBeforeDelete = null;
                 this.onAfterDelete = null;
                 OAK.Shop.Cart.single_instance = this;
             }
             return OAK.Shop.Cart.single_instance;
         }
         OAK.Shop.Cart.prototype = {
             specs: { 1: "正辣", 2: "微辣", 3: "不辣" },
             categories: <%=categories%>,
            total: 50,
            saveToCache: function () {
                OAK.Util.setParam("ShoppingdiancaiCart<%=shopid%>", JSON.stringify(this));
            },
            getFromCache: function () {
                var ShoppingdiancaiCart783 = OAK.Util.getParam("ShoppingdiancaiCart<%=shopid%>");
                if (ShoppingdiancaiCart783 != null && ShoppingdiancaiCart783 != "") {
                    //alert(ShoppingdiancaiCart783);
                    OAK.Util.setProps(this, JSON.parse(ShoppingdiancaiCart783));
                }
            },
            clear: function () {
                //localStorage.clear();
                OAK.Util.setParam("ShoppingdiancaiCart<%=shopid%>", null);
                this._totalNumber = 0;
                this._totalAmount = 0.00;
                this._products = [];
            },
            addProduct: function (p, conditions) {
                this.onBeforeAdd !== null && this.onBeforeAdd(this, p, conditions);
                var _conditions = conditions || { id: p.id, specId: p.specId, ref: true };
                var alreadyExistProduct = this.getProduct(_conditions);
                var ret_num = 0;
                //一元鸭翅活动
                if (p.name == "一元鸭翅" && this.existProduct({ name: p.name })) {
                    alert("每单只能购买一盒一元鸭翅");
                    return;
                }
                if (alreadyExistProduct !== null) {
                    alreadyExistProduct.number += p.number;
                }
                else
                    this._products.push(p);
                this._totalNumber += p.number;
                this._totalAmount += p.number * p.price;
                this.onAfterAdd !== null && this.onAfterAdd(this, alreadyExistProduct ? alreadyExistProduct.number : p.number, _conditions);
            },
            getQuantity: function () {
                return { totalNumber: this._totalNumber, totalAmount: this._totalAmount };
            },
            updateNumber: function (num, conditions) {
                this.onBeforeUpdate !== null && this.onBeforeUpdate(this, num, conditions);
                conditions.ref = true;
                var alreadyExistProduct = this.getProduct(conditions);
                if (alreadyExistProduct !== null) {
                    this._totalNumber += (parseInt(num) - parseInt(alreadyExistProduct.number));
                    this._totalAmount += ((parseInt(num) * parseFloat(alreadyExistProduct.price)) - parseInt(alreadyExistProduct.number) * parseFloat(alreadyExistProduct.price));
                    alreadyExistProduct.number = num;
                }
                this.onAfterUpdate !== null && this.onAfterUpdate(this, alreadyExistProduct ? alreadyExistProduct.number : 0, conditions);
            },
            //获取购物车中的所有商品
            getProductList: function () {
                return this._products;
            },
            getProduct: function (conditions) {
                var ref = conditions.ref;
                delete conditions.ref;
                for (var i in this._products) {
                    if (OAK.Util.isEqualInConditions(this._products[i], conditions))
                        return ref ? this._products[i] : OAK.Util.copy(this._products[i]);
                }
                return null;
            },
            getProductNumber: function (conditions) {
                for (var i in this._products) {
                    if (OAK.Util.isEqualInConditions(this._products[i], conditions))
                        return this._products[i].number;
                }
                return null;
            },
            existProduct: function (conditions) {
                for (var i in this._products) {
                    if (OAK.Util.isEqualInConditions(this._products[i], conditions))
                        return true;
                }
                return false;
            },
            deleteProduct: function (conditions) {
                this.onBeforeDelete !== null && this.onBeforeDelete(this, conditions);
                for (var i in this._products) {
                    if (OAK.Util.isEqualInConditions(this._products[i], conditions)) {
                        this._totalNumber -= parseInt(this._products[i].number);
                        this._totalAmount -= parseInt(this._products[i].number) * parseFloat(this._products[i].price);
                        this._products.splice(i, 1);
                        break;
                    }
                }
                this.onAfterDelete !== null && this.onAfterDelete(this, conditions);
            },
            sortAsc: function (a, b) {
                if (a.categoryId > b.categoryId) {
                    return 1;
                } else if (a.categoryId == b.categoryId) {
                    if (a.id > b.id)
                        return 1;
                    else if (a.id == b.id)
                        return a.specId > b.specId ? 1 : -1;
                    return -1;
                }
                return -1;
            }
        }
    </script>
    <script>
        function g(id) {
            return document.getElementById(id);
        }


        function gotoorder() {
            window.location.href = window.location.href;
            //window.location.href='http://www.apiwx.com/?ac=diancaionline-list&c=o99epjjmjWhMPNzoQbo9r6DAEYds&shopid=783&id=33473&g=1';
        }
        var cart = new OAK.Shop.Cart();

        function clearCache() {
            cart.clear();
            cart.showCartInfo();
        }
        function addProduct(productId, specId, name, price, categoryId, addnum) {

            cart.addProduct(OAK.Shop.Product({ id: productId, specId: specId, number: addnum, price: price, name: name, categoryId: categoryId }));
        }
        function reduceProduct(productId, specId, num) {
            var oldnum = cart.getProductNumber({ id: productId, specId: specId });
            if (oldnum !== null) {
                if (oldnum - num > 0) {
                    cart.updateNumber(oldnum - num, { id: productId, specId: specId });
                } else {
                    cart.deleteProduct({ id: productId, specId: specId });
                }
            }
        }
        function showTip() {
            var quant = cart.getQuantity();
            if (quant.totalAmount >= cart.total) {
                g('infoForm').style.display = "";
                g('notEnoughLi').style.display = "none";
                g('emptyLi').style.display = "none";
            } else {
                g('infoForm').style.display = "none";
                if (quant.totalAmount > 0) {
                    g('notEnoughLi').style.display = "";
                    g('emptyLi').style.display = "none";
                }
                else {
                    g('emptyLi').style.display = "";
                    g('notEnoughLi').style.display = "none";
                }
            }
        }
        function getNextElement(node) {
            if (node.nextSibling.nodeType == 1) {    //判断下一个节点类型为1则是"元素"节点
                return node.nextSibling;
            }
            if (node.nextSibling.nodeType == 3) {      //判断下一个节点类型为3则是"文本"节点  ，回调自身函数
                return getNextElement(node.nextSibling);
            }
            return null;
        }
        function getPreviousElement(node) {
            if (node.previousSibling.nodeType == 1) {    //判断下一个节点类型为1则是"元素"节点
                return node.previousSibling;
            }
            if (node.previousSibling.nodeType == 3) {      //判断下一个节点类型为3则是"文本"节点  ，回调自身函数
                return getPreviousElement(node.previousSibling);
            }
            return null;
        }
        cart.showProductNum = function (productId, specId, num) {
            if (num > 0) {
                g("num_" + productId + "_" + specId).innerHTML = parseInt(num);
            } else {
                var curNode = g("li_" + productId + "_" + specId);
                var nextNode = getNextElement(curNode);
                if (!nextNode || nextNode.nodeName != 'LI' || nextNode.id == 'notEnoughLi' || nextNode.id == 'emptyLi') {
                    var previousNode = getPreviousElement(curNode);
                    if (previousNode && previousNode.nodeName == 'DT') {
                        previousNode.parentNode.removeChild(previousNode);
                    }
                }
                curNode.parentNode.removeChild(curNode);
            }
        }
        cart.showTotalNum = function () {
            var quant = cart.getQuantity();
            // g("totalNum").innerHTML = quant.totalNumber;
            SetCookie("diancai<%=shopid%>", quant.totalNumber);
            g("cartN2").innerHTML = quant.totalNumber;
            g("totalPrice").innerHTML = quant.totalAmount.toFixed(2);
            showTip();
        };
        cart.showCartInfo = function () {
            var products = cart.getProductList();
            var orderlist = g("ullist");
            products && products.sort(cart.sortAsc);
            var liststr = "";
            var currentCategory = 0;
            for (var i in products) {
                if (currentCategory != products[i].categoryId) {
                    liststr += "<dt>" + cart.categories[products[i].categoryId] + "</dt>";
                    currentCategory = products[i].categoryId;

                }
                liststr += "<li class=\"ccbg2\" id=\"li_" + products[i].id + "_" + products[i].specId + "\">" +
                "<div class=\"orderdish\"><span class=\"\">" + products[i].name + "</span><p><span class=\"price\" id=\"v_0\">" + products[i].price + "</span><span class=\"price\">元</span></p></div>" +
                    "<div class=\"orderchange\">" +
                        "<a href=\"javascript:addProduct(" + products[i].id + "," + products[i].specId + ",\'" + products[i].name + "\'," + products[i].price + "," + products[i].categoryId + ",1" + ")\" class=\"increase\"><b class=\"ico_increase\">加一份</b></a>" +
                        "<span class=\"count\" id=\"num_" + products[i].id + "_" + products[i].specId + "\">" + products[i].number + "</span>" +
                        "<a href=\"javascript:reduceProduct(" + products[i].id + "," + products[i].specId + ",1)\" class=\"reduce\"><b class=\"ico_reduce\">减一份</b></a>" +
                    "</div>" +
                "</li>";

            }
            liststr += "<li class=\"ccbg2\" id='notEnoughLi' style='display: none;'>必须要满" + cart.total + "元才能下单哦</li>" +
            "<li class=\"ccbg2\" id='emptyLi' style='display: none;'>购物车为空哦，快去挑选吧！</li>";

            orderlist.innerHTML = liststr;
            cart.showTotalNum();
        };
        cart.onAfterAdd = function (obj, num, conditions) {
            cart.showProductNum(conditions.id, conditions.specId, num);
            cart.showTotalNum();
            cart.saveToCache();
        };
        cart.onAfterUpdate = function (obj, num, conditions) {
            cart.showProductNum(conditions.id, conditions.specId, num);
            cart.showTotalNum();
            cart.saveToCache();
        };
        cart.onAfterDelete = function (obj, conditions) {
            cart.showProductNum(conditions.id, conditions.specId, 0);
            cart.showTotalNum();
            cart.saveToCache();
        };
    </script>
    <script>

        function submitOrder() {
          
            vailReSubmit();
           
            if (valiForm()) {
                return;
            }
            
            var goodsData = '';
            
            var goodsList = cart.getProductList();
            goodsList && goodsList.sort(cart.sortAsc);
            for (var i in goodsList) {
                goodsData += goodsList[i].id + ',' + goodsList[i].number + ',' + goodsList[i].price + ';';
            }
            //菜品ID，数量，单价
            g('goodsData').value = goodsData;
            
            
            var submitData = {            
                goodsData:g('goodsData').value,
                myact: "addcaidan"
            };
            $.post('diancai_login.ashx?openid=<%=openid%>&shopid=<%=shopid%>', submitData,
             function (data) {
                
                 if (data.ret == "ok") {
                     alert(data.content);
                     clearCache();
                     } else { alert(data.content); }
                 },
                "json");


           // document.forms[0].submit();

            document.infoForm.issubmit.value = 1;//不能再提交
        }
        function valiForm() {
            var phonePattern = /^((\(\d{3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}$/;
            var mobilePattern = /^1\d{10}$/;
            var flag = false;
            if (g("name").value.length < 1) {
                //  g("name").className = "textinput alertinput";
                alert("联系人不能为空");
                return true;
            }
            if (!(phonePattern.test(g("phone").value) || mobilePattern.test(g("phone").value))) {
                // g("phone").className = "textinput alertinput";
                alert("亲，您的联系电话格式有误！");
                return true;
            }



            return flag;
        }
        function vailReSubmit() {
            if (document.infoForm.issubmit.value == 0) {
                return true;
            }
            else {
                alert(' 按一次就够了，请勿重复提交！请耐心等待！谢谢合作！');
                return false;
            }
        }


        function testInPayArea() {
            if (g("address").value == "") {
                alert("请先填写收货地址");
                //}else if(g("address").value.indexOf("北京")<0 && g("address").value.indexOf("武汉")<0&&g("address").value.indexOf("长沙")<0){
                //   alert("微信支付暂只支持北京、武汉、长沙三个城市");
            } else {
                return true;
            }
            g('wxpay').checked = false;
            g('huodao').checked = true;
            return false;
        }
        window.onload = function () {
            cart.getFromCache();

            cart.total = 12;
            cart.showCartInfo();
        }

    </script>
    <script type="text/javascript">


        document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
            WeixinJSBridge.call('hideToolbar');
        });
    </script>

</body>
</html>
