 
var VsmWebConfig = function() {
    var a = {
        getScroll: function() {
            return self.pageYOffset ? {
                scrollTop: self.pageYOffset,
                scrollLeft: self.pageXOffset
            }: document.documentElement && document.documentElement.scrollTop ? {
                scrollTop: document.documentElement.scrollTop,
                scrollLeft: document.documentElement.scrollLeft
            }: document.body ? {
                scrollTop: document.body.scrollTop,
                scrollLeft: document.body.scrollLeft
            }: void 0
        }
    };
    return {
        scroll: a.getScroll
    }
} (),
VsmScroll = function() {
    var a = {
        elemId: function(a) {
            return document.getElementById(a)
        }
    },
    b = function(a) {
        if (a) {
            this.element = a,
            this.child = this.element.children[0],
            this.dom = {
                elem: $(this.child),
                height: $(this.element).prev().innerHeight()
            },
            this.addEvent()
        }
    };
    return b.prototype = {
        addEvent: function() {
            this.element.addEventListener && (this.element.addEventListener("touchstart", this, !1), this.element.addEventListener("touchmove", this, !1), this.element.addEventListener("touchend", this, !1))
        },
        removeEvent: function() {
            this.element.addEventListener && (this.element.removeEventListener("touchstart", this, !1), this.element.removeEventListener("touchmove", this, !1), this.element.removeEventListener("touchend", this, !1))
        },
        handleEvent: function(a) {
            switch (a.type) {
            case "touchstart":
                this.onTouchStart(a);
                break;
            case "touchmove":
                this.onTouchMove(a);
                break;
            case "touchend":
                this.onTouchEnd(a)
            }
        },
        onTouchStart: function(a) {
            this.start = {
                pageX: a.touches[0].pageX,
                pageY: a.touches[0].pageY,
                time: Number(new Date)
            },
            this.isScrolling = void 0,
            this.deltaX = 0,
            this.deltaY = 0,
            a.stopPropagation()
        },
        onTouchMove: function(a) {
            return a.touches.length > 1 || a.scale && 1 !== a.scale ? void 0 : (this.move = {
                deltaX: a.touches[0].pageX - this.start.pageX,
                deltaY: a.touches[0].pageY - this.start.pageY
            },
            this.move.deltaY < -5 ? void this.dom.elem.css({
                position: "static"
            }).next().removeAttr("style") : this.move.deltaY > 5 ? void this.dom.elem.css({
                position: "fixed",
                width: "100%",
                top: this.dom.height,
                "z-index": "1000",
                left: "0"
            }).next().css("marginTop", this.dom.elem.innerHeight()) : void 0)
        },
        onTouchEnd: function(a) {
            return this.end = {
                deltaX: a.changedTouches[0].pageX - this.start.pageX,
                deltaY: a.changedTouches[0].pageY - this.start.pageY
            },
            this.end.deltaY < -5 ? void this.dom.elem.css({
                position: "static"
            }).next().removeAttr("style") : this.end.deltaY > 5 ? void this.dom.elem.css({
                position: "fixed",
                width: "100%",
                top: this.dom.height,
                "z-index": "1000",
                left: "0"
            }).next().css("marginTop", this.dom.elem.innerHeight()) : void a.stopPropagation()
        }
    },
    {
        Swipes: b,
        elemId: a.elemId
    }
} (),
VsmwebEffect = function() {
    var a = $('[data-GetBrand="more"]'),
    b = $('[data-client="down"]'),
    c = $('[data-GetDetail="more"]'),
    d = $('[data-thumbcate="list"]'),
    e = $(".drop_cate"),
    f = $("#B_cateWrap"),
    g = $("#B_listWrap"),
    h = $('[data-jump="true"]'),
    i = $('[data-collapse="true"]'),
    j = new VsmScroll.Swipes(VsmScroll.elemId("w_container")),
    k = {
        getBrandData: function(a) {
            a.elem.hide().before('<div class="loading"><img src="view/touch/images/common/loading-big.gif" alt="loading" />加载中</div>'),
            $.ajax({
                url: "ajaxapi-brands.html?s=" + (new Date).getTime(),
                data: {
                    index: a.total,
                    channel: a.channel
                },
                dataType: "json",
                type: "GET",
                success: function(b) {
                    a.elem.show().prev().fadeOut(function() {
                        $(this).remove(),
                        null != b && void 0 != b && b && b.length > 0 ? ($.each(b,
                        function(c) {
                            var d = b[c];
                            if (0 == d.brand_id) {
                                {
                                    var e = $("<div />", {
                                        "class": "shop_tit clearfix"
                                    }).html("/");
                                    $("<h1 />").html(d.brand_name).appendTo(e),
                                    $("<span />").html(d.detailurl).appendTo(e)
                                }
                                e.appendTo(a.insertObj)
                            } else {
                                var f = $("<div />", {
                                    "class": "shop_list"
                                }),
                                g = $("<div />", {
                                    "class": "pic"
                                }),
                                h = $("<a />", {
                                    "class": "itemList",
                                    href: "" + d.detailurl
                                }).html('<img class="' + a.cName + '" width="302" height="129" data-original="' + d.index_image2 + '" data-brandid="108921" data-onerror="' + d.index_image + '" src="view/touch/images/common/loading_l_brand.gif">'),
                                i = $("<div />", {
                                    "class": "re_time time_brand"
                                }).html("<span></span>" + d.leave_time),
                                j = $("<div />", {
                                    "class": "shop_info clearfix"
                                }),
                                k = $("<p />", {
                                    "class": "fl s_brand_name"
                                }).html(d.brand_name),
                                l = $("<div />", {
                                    "class": "fr discout"
                                }).html(d.agio);
                                if (h.appendTo(g), i.appendTo(g), "" != d.pms_activetips && null != d.pms_activetips) {
                                    $("<div />", {
                                        "class": "suppliers_send sup_brand"
                                    }).html("<span></span>" + d.pms_activetips).appendTo(g)
                                }
                                g.appendTo(f),
                                k.appendTo(j),
                                l.appendTo(j),
                                j.appendTo(f),
                                f.appendTo(a.insertObj)
                            }
                        }), VsmCart.imgNewEffect(a)) : 0 == b.length ? (a.elem.before('<div class="loading">^_^，亲，没有更多了 </div>'), a.elem.hide().remove()) : VsmCart.VsmDialog("获取品牌列表失败", {
                            title: "唯品会提醒您",
                            overClose: !1
                        })
                    })
                },
                error: function() {
                    VsmCart.VsmDialog("网络延时，加载品牌列表失败，请刷新页面重试...", {
                        title: "唯品会提醒您"
                    }),
                    a.elem.prev().fadeOut("fast",
                    function() {
                        $(this).remove(),
                        a.elem.fadeIn(function() {
                            $(this).off("click.asyn.loading")
                        }).css({
                            color: "#999",
                            "text-shadow": "0 -1px 0 rgba(255,255,255,1)"
                        }).html("网络延时,请刷新页面")
                    })
                }
            })
        },
        getBrandinit: function() {
            var a = $(this),
            b = {
                elem: a,
                channel: a.data("channel"),
                insertObj: a.prev(),
                total: parseInt(a.prev().children().filter(".shop_list").length, 10),
                cName: a.prev().children().find("[data-original]").attr("class")
            }; ! isNaN(b.total) && b.total >= 0 && k.getBrandData(b)
        },
        tiggerDetailinit: function() {
            var a = $(this),
            b = {
                elem: a,
                pid: a.prev().find('input[name="product_id"]').length ? a.prev().find('input[name="product_id"]').val() : null,
                child: a.next().children().filter(".loading"),
                check: a.data("merchandise").toString(),
                type: null
            };
            b.type = "" != b.check && "string" == typeof b.check && "normal" == b.check ? !0 : !1,
            null != b.pid && (b.elem.hide(), b.child.show(), k.tiggerDetailData(b))
        },
        tiggerDetailData: function(a) {
            if (a.type) var b = {
                url: "ajaxapi-getproductdetail.html?" + (new Date).getTime(),
                data: {
                    productid: a.pid
                },
                type: "GET"
            };
            else var b = {
                url: "ajaxapi-getbeautydetail.html?" + (new Date).getTime(),
                data: {
                    productid: a.pid
                },
                type: "GET"
            };
            b.error = function() {
                a.child.fadeOut(function() {
                    VsmwebForm.erDialog("网络延时，请刷新页面重试！")
                })
            },
            b.success = function(b) {
                b && null != b && void 0 != b ? b.length > 0 && "" != b && null != b && a.child.fadeOut(function() {
                    $(this).prev().css({
                        style: "display:none"
                    }).html(b).fadeIn()
                }) : (a.elem.fadeIn(), a.child.fadeOut(function() {
                    VsmwebForm.erDialog("网络延时，请刷新页面重试！")
                }))
            },
            $.ajax(b)
        },
        tiggerAccordion: function(a) {
            a.preventDefault();
            var b = $(this),
            c = {
                elem: b,
                next: b.next(),
                child: b.children().filter("em")
            };
            c.elem.hasClass("off") && c.child.hasClass("down_w_s") && c.next.length && c.next.is(":hidden") ? (c.child.addClass("up_w_s").removeClass("down_w_s"), c.elem.addClass("on").next().slideDown()) : (c.child.addClass("down_w_s").removeClass("up_w_s"), c.elem.removeClass("on").addClass("off").next().slideUp())
        }
    },
    l = {
        slidePageDown: function() {
            if (this.elem.next().fadeIn("fast").parent().addClass("active"), this.elem.parent().next().hasClass("active")) {
                var a = this.elem.parent().next().children().filter("a"),
                b = {
                    elem: a,
                    direction: a.attr("data-dropmen"),
                    child: a.next().children().find("h2")
                };
                l.slidePageRight.call(b)
            }
        },
        slidePageUp: function() {
            this.elem.next().fadeOut("fast").parent().removeClass("active")
        },
        slidePageLeft: function() {
            var a = this.elem.next().outerWidth(!0),
            b = (parseInt(this.elem.next().css("top"), 10), {});
            if (!this.elem.next().is(":visible")) {
                switch (this.direction) {
                case "left":
                    this.elem.next().css({
                        left:
                        "auto",
                        right: "-" + a + "px",
                        height: $(document).outerHeight()
                    }),
                    b.right = "+=" + a;
                    break;
                default:
                    this.elem.next().css({
                        left:
                        "-" + a + "px",
                        right: "auto"
                    }),
                    b.left = "+=" + a
                }
                if (this.elem.next().show().animate(b, "fast").parent().addClass("active"), this.elem.parent().prev().hasClass("active")) {
                    var c = this.elem.parent().prev().children().filter("a"),
                    d = {
                        elem: c,
                        direction: c.attr("data-dropmen"),
                        child: c.next().children().find("h2")
                    };
                    l.slidePageUp.call(d)
                }
                this.elem.next().undelegate('[data-dropClose="true"]', "click.drop.close").delegate('[data-dropClose="true"]', "click.drop.close", l.slidePageBottom),
                document.addEventListener("touchmove", l.touchEvent, !1)
            }
        },
        slidePageRight: function() {
            var a = this.elem.next().outerWidth(!0),
            b = {};
            if (!this.elem.next().is(":hidden")) {
                switch (this.direction) {
                case "left":
                    b.right = "-=" + a;
                    break;
                default:
                    b.left = "-=" + a
                }
                this.elem.next().animate(b, "fast",
                function() {
                    $(this).hide()
                }).parent().removeClass("active"),
                document.removeEventListener("touchmove", l.touchEvent, !1)
            }
        },
        touchEvent: function(a) {
            a.preventDefault()
        },
        slideCateinit: function() {
            var a = $(this),
            b = {
                elem: a,
                direction: a.attr("data-dropmen"),
                child: a.next().children().find("h2")
            };
            b.direction && "down" == b.direction ? b.elem.next().is(":visible") ? (j.addEvent(), l.slidePageUp.call(b)) : (j.removeEvent(), l.slidePageDown.call(b)) : b.elem.next().is(":visible") ? (j.addEvent(), l.slidePageRight.call(b)) : (j.removeEvent(), l.slidePageLeft.call(b))
        },
        slidePageBottom: function() {
            var a = $(this),
            b = {
                elem: a.parents(".trasp").prev(),
                direction: "left"
            };
            b.elem.next().is(":visible") && l.slidePageRight.call(b)
        },
        slideMenuinit: function() {
            var a = $(this),
            b = {
                elem: a,
                child: a.children("h2"),
                cartid: a.attr("data-cateid"),
                next: a.parents(".drop_cate").next().children().find(".category")
            };
            b.child.hasClass("active") || b.next.filter('[data-listid="' + b.cartid + '"]').is(":visible") || b.child.addClass("active").parent().siblings("li").children("h2").removeClass("active").parents(".drop_cate").next().children().children().children().filter('[data-listid="' + b.cartid + '"]').show("fast").siblings(".category").hide("fast")
        }
    },
    m = {
        bindwindowCategory: function() {
            var a = {
                wH: $(window).innerHeight(),
                hH: $(".header").innerHeight(),
                tH: $(".thumb-mode").innerHeight(),
                lE: $(".gridItem").children().filter("dl").length
            };
            0 == window.orientation || 180 == window.orientation ? a.lE ? m.categoryStyle(a, .76) : m.categoryStyle(a, .5) : 90 == window.orientation || -90 == window.orientation ? m.categoryStyle(a, 1) : a.lE ? m.categoryStyle(a, .76) : m.categoryStyle(a, .5)
        },
        categoryStyle: function(a, b) {
            return f.css({
                height: (a.wH - a.hH - a.tH) * b + "px"
            }),
            g.css({
                height: (a.wH - a.hH - a.tH) * b + "px"
            }),
            $(".drop_bottom").add($(".drop_bottom").children("a")).css({
                top: (a.wH - a.hH - a.tH) * b,
                height: a.wH - a.hH - a.tH - (a.wH - a.hH - a.tH) * b
            }),
            !1
        },
        categoryEvent: function() {
            var a = new iScroll("B_cateWrap", {
                checkDOMChanges: !0,
                onScrollStart: function() {
                    a.refresh()
                }
            }),
            b = new iScroll("B_listWrap", {
                checkDOMChanges: !0,
                onScrollStart: function() {
                    b.refresh()
                }
            })
        },
        cateInit: function() {
            f.length > 0 && m.categoryEvent()
        }
    },
    n = {
        tiggerDowninit: function() {
            var a = Cookie.Get("WAP[clientClose]");
            a ? "": (b.show(), b.undelegate('[data-dismiss="down"]', "click.dismiss.down").delegate('[data-dismiss="down"]', "click.dismiss.down", n.tiggerClienHide))
        },
        tiggerClienHide: function() {
            var a = $(this),
            b = {
                elem: a,
                pars: a.parent()
            };
            b.pars.is(":visible") && b.pars.fadeOut(),
            b.pars.fadeOut(),
            Cookie.Set("WAP[clientClose]", 1, "", "", "/")
        }
    },
    o = {
        tiggerJumpLinks: function() {
            var a = $(this);
            dom = {
                elem: a,
                links: a.data("jumplink").toString()
            },
            "" != dom.links && isNaN(dom.links) && VsmCart.VsmDialog("绑定钱包资金更安全，您确定放弃绑定吗？", {
                title: "唯品会友情提醒您",
                overClose: !1,
                buttons: !0,
                type: "question",
                onDoComplete: function(a, b) {
                    b.oncomplete(!1),
                    self.location.href = dom.links
                }
            })
        }
    },
    p = {
        bindEvents: function() {
            a.off("click.asyn.loading").on("click.asyn.loading", k.getBrandinit),
            c.off("click.detail.loading").on("click.detail.loading", k.tiggerDetailinit),
            d.children().children().filter("a").off("click.made.classify").on("click.asyn.classify", l.slideCateinit),
            e.children().find("li").off("click.drop.menu").on("click.drop.menu", l.slideMenuinit),
            h.off("click.jump.link").on("click.jump.link", o.tiggerJumpLinks),
            i.children().filter("h3").off("click.accordion.down").on("click.accordion.down", k.tiggerAccordion)
        },
        init: function() {
            p.bindEvents(),
            f.length > 0 && m.bindwindowCategory(),
            b.length > 0 && n.tiggerDowninit()
        }
    };
    return {
        init: p.init,
        cateInit: m.cateInit
    }
} ();
$(function() {
    VsmwebEffect.init()
});
var VsmCart = function() {
    var a, b = {
        addZero: function(a, b) {
            return a ? 10 > b ? b = "0" + b: b: b
        },
        tiggerCartTime: function(c) {
            var d, f = {
                interval: 1e3,
                minDigit: !0,
                timeUnitCls: {
                    day: "",
                    hour: "",
                    min: "",
                    sec: ""
                },
                showMsg: null,
                showMin: !0,
                timeStamp: !0,
                block: $("<span></span>"),
                action: "reload",
                jump: !1,
                timeTag: null,
                endTips: "",
                stopTips: "",
                onEndCallBack: !1,
                onEndComplete: null
            },
            h = $.extend(!0, {},
            f, c),
            i = {},
            j = c.elem;
            "string" == typeof h.time && (h.time = parseInt(h.time, 10)),
            !isNaN(h.time) && h.time > 0 && (i.startTime = h.time, i.nowTime = Math.round((new Date).getTime() / 1e3), i.endTime = i.nowTime + i.startTime,
            function k() {
                var c = {};
                if (null != h.timeTag) var f = j.find(h.timeTag);
                else var f = j;
                if (f.html(""), sec = i.nowTime < i.endTime ? i.endTime - i.nowTime: 0, null != h.showMsg && (c.msg = h.showMsg), h.showMin && (c.min = b.addZero(h.minDigit, Math.floor(sec / 60 % 60))), c.sec = b.addZero(h.minDigit, Math.floor(sec % 60)), !(i.endTime > i.nowTime)) {
                    if (h.stopTips) d = h.stopTips,
                    f.html(d);
                    else switch (h.action) {
                    case "hide":
                        break;
                    case "remove":
                        break;
                    case "remain":
                        h.onEndCallBack && "function" == typeof h.onEndComplete && h.onEndComplete.call(j),
                        !$('[data-getvercode="code"]').length && g("您的商品已超时被清空，继续抢购吧", {
                            title: "唯品会友情提醒您",
                            buttons: !0
                        });
                        break;
                    case "reload":
                        if (h.jump) {
                            for (var l in c) c[l] = "00",
                            h.block.clone().addClass(h.timeUnitCls[l]).text(c[l]).appendTo(f),
                            h.timeStamp && h.block.clone().text(h.timeUnitCls[l]).appendTo(f);
                            setTimeout(e.refreshAppCart, h.interval)
                        }
                    }
                    return clearTimeout(a),
                    !1
                }
                h.endTips && (d = h.endTips);
                for (var l in c) h.block.clone().addClass(h.timeUnitCls[l]).text(c[l]).appendTo(f),
                h.timeStamp && h.block.clone().text(h.timeUnitCls[l]).appendTo(f);
                i.nowTime = i.nowTime + h.interval / 1e3,
                a = setTimeout(k, h.interval),
                300 === sec && !$('[data-OrderFrom="true"]').length && g('您的购物车只剩 <span class="fontred">5分钟</span> 时间，立即结算？', {
                    title: "唯品会友情提醒您",
                    buttons: !0,
                    type: "confirm",
                    onCloseComplete: function() {
                        self.location.href = "cart.html"
                    }
                })
            } ())
        },
        CartTimereset: function() {
            void 0 == a ? "": clearTimeout(a)
        }
    },
    c = {
        tiggerDelBonus: function() {
            g("<p>确认取消使用礼券或抵用券吗？</p>", {
                title: "删除礼券或抵用券",
                overClose: !1,
                buttons: !0,
                type: "confirm",
                onCloseCallBack: !0,
                onCloseComplete: function() {
                    c.tiggerDelBonusDo()
                }
            })
        },
        tiggerDelBonusDo: function() {
            $.get("index.php?m=flow&act=bonus&step=del",
            function(a) {
                1 == a.code && e.refreshAppCart()
            },
            "json")
        }
    },
    d = {
        min: 1,
        max: 12,
        NumshowMsg: function(a, b) {
            g(a, {
                width: "100%",
                position: [{
                    top: "0"
                },
                {
                    left: "0"
                }],
                overShow: !1,
                autoClose: b
            })
        },
        regNum: function(a) {
            return new RegExp("^[0-9]\\d*$").test(a)
        },
        Amount: function(a, b) {
            var c = parseInt(a.text.text(), 10);
            return this.regNum(c) ? b ? c++:c--:(d.erDialog("请输入数字"), a.text.text(1)),
            c
        },
        numReduce: function(a) {
            var b = $(a);
            dom = {
                elem: b,
                text: b.parent().children(".J_num_cart_txt"),
                brother: b.parent().children(".J_num_cart_add"),
                cart_id: parseInt(b.parent().data("product"))
            };
            var c = d.Amount(dom, !1);
            return dom.cart_id < 0 || "undefined" == dom.cart_id ? !1 : c >= d.min ? void $.ajax({
                url: "index.php?s=" + (new Date).getTime(),
                data: {
                    m: "flow",
                    act: "cart",
                    step: "modify",
                    cart_id: dom.cart_id,
                    num: c
                },
                dataType: "json",
                type: "POST",
                success: function(a) {
                    return null == a ? (d.reduceerDialog("未知错误，请刷新页面重试", dom), !1) : 1 != a.code ? -1 == a.code ? !1 : (d.reduceerDialog(a.msg, dom), !1) : (dom.text.text(c), dom.brother.removeClass("good_data_num_r_act"), e.refreshAppCart(), void 0)
                },
                error: function() {
                    d.reduceerDialog("网络加载延时，请刷新页面重试", dom)
                }
            }) : (d.reduceerDialog("最少购买数量为：" + d.min + "件", dom), !1)
        },
        reduceerDialog: function(a, b) {
            d.erDialog(a),
            b.elem.removeClass("good_data_num_l_act"),
            b.elem.removeAttr("onClick")
        },
        numAdd: function(a) {
            var b = $(a),
            c = {
                elem: b,
                text: b.parent().children(".J_num_cart_txt"),
                brother: b.parent().children(".J_num_cart_reduce"),
                cart_id: parseInt(b.parent().data("product"))
            };
            if (c.cart_id < 0 || "undefined" == c.cart_id) return ! 1;
            var f = d.Amount(c, !0);
            $.ajax({
                url: "index.php?s=" + (new Date).getTime(),
                data: {
                    m: "flow",
                    act: "cart",
                    step: "modify",
                    cart_id: c.cart_id,
                    num: f
                },
                dataType: "json",
                type: "POST",
                success: function(a) {
                    return null == a || "undefined" == a ? (d.adderDialog("未知错误，请刷新页面重试", c), !1) : 1 != a.code ? -1 == a.code ? !1 : (d.adderDialog(a.msg, c), !1) : (c.text.text(f), c.brother.addClass("good_data_num_l_act"), e.refreshAppCart(), void 0)
                },
                error: function() {
                    return d.adderDialog("网络加载延时，请刷新页面重试", c),
                    !1
                }
            })
        },
        adderDialog: function(a, b) {
            d.erDialog(a),
            b.elem.addClass("good_data_num_r_act"),
            b.elem.removeAttr("onClick")
        },
        erDialog: function(a) {
            VsmCart.VsmDialog(a, {
                setClass: "ui-error",
                position: [{
                    top: 0
                },
                {
                    left: 0
                }],
                overClose: !1,
                overShow: !1,
                width: "100%",
                autoClose: 3e3
            })
        },
        tiggerDelGoods: function(a) {
            var b = arguments[1] ? parseInt(arguments[1]) : 0,
            c = "确定从购物车中删除该商品吗？";
            b > 0 && (c = "删除或修改商品后，可能会导致已使用的红包，不满足条件而被自动取消使用，是否继续操作？"),
            0 > a && !isNaN(a) ? "": g(c, {
                title: "删除商品",
                overClose: !1,
                buttons: !0,
                type: "confirm",
                onCloseCallBack: !0,
                onCloseComplete: function() {
                    d.tiggerDelGoodsDo(a)
                }
            })
        },
        tiggerDelGoodsDo: function(a) {
            $.post("index.php?m=flow&act=cart&step=del", {
                cart_id: a
            },
            function(a) {
                1 == a.code && e.refreshAppCart()
            },
            "json")
        }
    },
    e = {
        refreshAppCart: function() {
            f.close(),
            g({
                overClose: !1,
                closeBtn: !1,
                width: 100,
                height: 60
            }),
            $.ajax({
                url: "index.php?",
                data: {
                    m: "flow",
                    act: "cart"
                },
                dataType: "json",
                type: "POST",
                success: function(a) {
                    if (f.close(), a && null != a && void 0 != a) {
                        if (a.out) return $("#cart_list").html(a.out),
                        h.imgBrandEffect(),
                        b.CartTimereset(),
                        void i.cartTimeCensor();
                        g("网络加载异常，请刷新页面重试!", {
                            title: "友情提示",
                            overClose: !1,
                            closeBtn: !1
                        })
                    } else g("网络加载异常，请刷新页面重试!", {
                        title: "友情提示",
                        overClose: !1,
                        closeBtn: !1
                    })
                },
                error: function() {
                    f.close(),
                    g("网络加载异常，请刷新页面重试!", {
                        title: "友情提示",
                        overClose: !1,
                        closeBtn: !1
                    })
                }
            })
        }
    },
    f = {
        getButtons: function(a) {
            if (a.buttons !== !0 && !$.isArray(a.buttons)) return ! 1;
            if (a.buttons === !0) switch (a.type) {
            case "question":
                a.buttons = ["取消", "确定"];
                break;
            case "confirm":
                a.buttons = ["取消", "确定"];
                break;
            case "submit":
                a.buttons = ["取消", "提交"];
                break;
            case "ordersubmit":
                a.buttons = ["取消", "确定"];
                break;
            default:
                a.buttons = ["确定"]
            }
            return a.buttons.reverse()
        },
        getType: function(a) {
            switch (a.type) {
            case "confirm":
            case "error":
            case "info":
            case "question":
            case "warning":
            case "submit":
            case "ordersubmit":
                return a.type.charAt(0).toUpperCase() + a.type.slice(1).toLowerCase();
            default:
                return ! 1
            }
        },
        tiggerhideOverload: function() {
            $("body,html").find(".modal-backdrop").fadeOut("fast",
            function() {
                $(this).remove()
            })
        },
        close: function() {
            $("body,html").find(".modal").fadeOut("fast",
            function() {
                $(this).remove(),
                f.tiggerhideOverload()
            })
        },
        init: function() {
            var a, b = {
                modal: null,
                modalHide: !1,
                width: 300,
                top: 43,
                animate_speed: "fast",
                effect: "fadeIn",
                autoClose: !1,
                setClass: !1,
                closeBtn: !0,
                buttons: !1,
                position: "center",
                setPosition: 100,
                isCenter: !0,
                onCloseCallBack: !1,
                onCloseComplete: null,
                onCancleComplete: null,
                centerMessage: !0,
                message: "",
                loading: '<img src="view/touch/images/common/loading-big.gif" alt="loading" />',
                type: null,
                title: null,
                source: !1,
                overAnimate: !0,
                overShow: !0,
                overClose: !0,
                overOpacity: .6
            },
            c = this,
            d = {};
            "string" == typeof arguments[0] && (d.message = arguments[0]),
            ("object" == typeof arguments[0] || "object" == typeof arguments[1]) && (d = $.extend(d, "object" == typeof arguments[0] ? arguments[0] : arguments[1]));
            var e = $.extend(!0, {},
            b, d);
            c.Init = function() {
                var b, d = isNaN(d) ? e.width: parseInt(e.width, 10);
                if (e.overShow && (c.overlayer = $("<div>", {
                    "class": "modal-backdrop fade"
                }).css({
                    top: 0,
                    left: 0
                }), e.overClose && c.overlayer.on("click.overlayer.close",
                function() {
                    c.close()
                }), c.overlayer.appendTo(document.body), e.overAnimate ? c.overlayer.animate({
                    opacity: e.overOpacity
                }) : c.overlayer.addClass("in")), null == e.modal) {
                    if (c.modal = $("<div>", {
                        "class": "modal hide" + (e.setClass ? " " + e.setClass: "")
                    }), d == e.width && d.toString() == e.width.toString() && c.modal.css({
                        width: e.width
                    }), !e.buttons && e.autoClose && c.modal.attr("data-modalindex", Math.floor(999999 * Math.random())), e.title && (b = $("<div>", {
                        "class": "modal-header"
                    }).html("<h3>" + e.title + "</h3>").appendTo(c.modal)), c.container = $("<div>", {
                        "class": "modal-body" + (e.title ? "": " modal-body-noTitle") + (f.getButtons(e) ? "": " modal-body-noBotton")
                    }).appendTo(c.modal), c.message = $("<div>", {
                        "class": "modal-message" + ("" != f.getType(e) ? " modal-Icon modal-" + f.getType(e) : "")
                    }), "" != e.message ? e.centerMessage ? $("<div>").html(e.message).appendTo(c.message) : c.message.html(e.message) : e.centerMessage ? $("<div>", {
                        style: "text-align:center"
                    }).html(e.loading).appendTo(c.message) : c.message.html(e.loading), e.source && "object" == typeof e.source) {
                        var h = e.centerMessage ? $("div:first", c.message) : c.message;
                        for (var i in e.source) switch (i) {
                        case "ajax":
                            var j = "string" == typeof e.source[i] ? {
                                url: e.source[i]
                            }: e.source[i],
                            k = $("<div>", {
                                "class": "modal-Preloader progress-striped active"
                            }).html('<div class="bar"></div>').appendTo(h);
                            j.success = function(a) {
                                k.fadeOut(function() {
                                    h.append(a)
                                }),
                                g(!1)
                            },
                            $.ajax(j);
                            break;
                        case "iframe":
                            var l = {
                                width: "100%",
                                height: "100%",
                                marginheight: "0",
                                marginwidth: "0",
                                frameborder: "0"
                            },
                            m = $.extend(!0, {},
                            l, "string" == typeof e.source[i] ? {
                                src: e.source[i]
                            }: e.source[i]);
                            h.append($("<iframe>").attr(m));
                            break;
                        case "inline":
                            console.log(e.source[i]),
                            h.append(e.source[i])
                        }
                    }
                    var n = f.getButtons(e);
                    if (n && (c.footer = $("<div>", {
                        "class": "modal-footer"
                    }).appendTo(c.modal), "question" == e.type ? $.each(n,
                    function(a, b) {
                        var d = $("<a>", {
                            href: "javascript:void(0)",
                            "class": "btn",
                            "data-dismiss": "modal"
                        }).html(b);
                        "确定" === d.html() ? d.off("click.modal.close").on("click.modal.close",
                        function() {
                            e.onDoComplete && "function" == typeof e.onDoComplete && e.onDoComplete($(this), {
                                oncomplete: function(a) {
                                    a ? c.close(void 0 !== b.caption ? b.caption: b, a) : c.close()
                                }
                            })
                        }) : d.off("click.modal.close").on("click.modal.close",
                        function() {
                            c.close()
                        }),
                        d.appendTo(c.footer)
                    }) : "confirm" == e.type ? $.each(n,
                    function(a, b) {
                        var d = $("<a>", {
                            href: "javascript:void(0)",
                            "class": "btn",
                            "data-dismiss": "modal"
                        }).html(b);
                        "确定" === d.html() ? (d.attr("data-ConfirmForm", "true"), d.off("click.modal.close").on("click.modal.close",
                        function() {
                            var a = $(this),
                            d = {
                                elem: a,
                                Confirm: a.attr("data-ConfirmForm")
                            };
                            void 0 === d.Confirm ? c.close() : c.close(void 0 !== b.caption ? b.caption: b, d.Confirm)
                        })) : d.off("click.modal.close").on("click.modal.close",
                        function() {
                            c.close()
                        }),
                        d.appendTo(c.footer)
                    }) : "submit" == e.type ? $.each(n,
                    function(a, b) {
                        var d = $("<a>", {
                            href: "javascript:void(0)",
                            "class": "btn",
                            "data-dismiss": "modal"
                        }).html(b);
                        "提交" === d.html() ? (d.attr("data-submitForm", "true"), d.off("click.modal.close").on("click.modal.close",
                        function() {
                            {
                                var a = $(this); ({
                                    elem: a,
                                    Submit: a.attr("data-submitForm")
                                })
                            }
                            e.onCloseComplete && "function" == typeof e.onCloseComplete && e.onCloseComplete(b, $(this))
                        })) : d.off("click.modal.close").on("click.modal.close",
                        function() {
                            c.close()
                        }),
                        d.appendTo(c.footer)
                    }) : "ordersubmit" == e.type ? $.each(n,
                    function(a, b) {
                        var d = $("<a>", {
                            href: "javascript:void(0)",
                            "class": "btn",
                            "data-dismiss": "modal"
                        }).html(b);
                        "确定" === d.html() ? (d.attr("data-submitOrder", "true"), d.off("click.modal.close").on("click.modal.close",
                        function() {
                            {
                                var a = $(this); ({
                                    elem: a,
                                    Submit: a.attr("data-submitForm")
                                })
                            }
                            e.onCloseCallBack && e.onCloseComplete && "function" == typeof e.onCloseComplete && e.onCloseComplete(b, $(this))
                        })) : (d.attr("data-modalCancle", "true"), d.off("click.modal.close").on("click.modal.close",
                        function() {
                            {
                                var a = $(this); ({
                                    elem: a,
                                    Cancle: a.attr("data-modalCancle")
                                })
                            }
                            e.onCloseCallBack && e.onCancleComplete && "function" == typeof e.onCancleComplete ? e.onCancleComplete(b, $(this)) : c.close()
                        })),
                        d.appendTo(c.footer)
                    }) : $.each(n,
                    function(a, b) {
                        var d = $("<a>", {
                            href: "javascript:void(0)",
                            "class": "btn",
                            "data-dismiss": "modal"
                        }).html(b);
                        d.off("click.modal.close").on("click.modal.close",
                        function() {
                            c.close()
                        }),
                        d.appendTo(c.footer)
                    }), c.footer.appendTo(c.modal)), e.closeBtn) {
                        $('<a href="javascript:void(0)" class="closeBtn">×</a>').on("click.modal.closeBtn",
                        function(a) {
                            a.preventDefault(),
                            c.close()
                        }).prependTo(b ? b: c.message)
                    }
                    c.message.appendTo(c.container),
                    c.modal.appendTo(document.body),
                    $(window).on("resize.modal",
                    function() {
                        clearTimeout(a),
                        a = setTimeout(function() {
                            g()
                        },
                        100)
                    })
                } else {
                    c.modal = $(e.modal);
                    var b = c.modal.children().filter(".modal-header");
                    if (d == e.width && d.toString() == e.width.toString() && c.modal.css({
                        width: e.width
                    }).addClass(e.setClass), e.closeBtn && !c.modal.find('[data-dismiss="closeModal"]').length) {
                        $('<a href="javascript:void(0)" class="closeBtn" data-dismiss="closeModal" mars_sead="home_province_close_btn">×</a>').off("click.modal.closeBtn").on("click.modal.closeBtn",
                        function(a) {
                            a.preventDefault(),
                            c.close()
                        }).prependTo(b)
                    } else c.modal.find('[data-dismiss="closeModal"]').off("click.modal.closeBtn").on("click.modal.closeBtn",
                    function(a) {
                        a.preventDefault(),
                        c.close()
                    });
                    c.modal.undelegate("click.dismiss.modal").delegate('[data-dismiss="modal"]', "click.dismiss.modal",
                    function() {
                        e.onDoComplete && "function" == typeof e.onDoComplete && e.onDoComplete($(this), {
                            oncomplete: function() {
                                c.close()
                            }
                        })
                    }),
                    $(window).on("resize.modal",
                    function() {
                        clearTimeout(a),
                        a = setTimeout(function() {
                            g(!1)
                        },
                        100)
                    })
                }
                e.autoClose !== !1 && (c.modal.bind("click",
                function() {
                    clearTimeout(c.setTimes),
                    c.close()
                }), c.setTimes = setTimeout(c.close, e.autoClose)),
                g(!1)
            },
            c.close = function(a) {
                var b;
                $(window).off("resize.modal"),
                $(document).off("resize.modal"),
                b = arguments[1] ? arguments[1] : void 0,
                c.overlayer && c.overlayer.fadeOut(e.animate_speed,
                function() {
                    $(this).remove()
                }),
                "fadeIn" === e.effect ? c.modal.fadeOut(e.animate_speed,
                function() {
                    e.modalHide ? $(this).hide() : $(this).remove(),
                    e.onCloseComplete && "function" == typeof e.onCloseComplete && b && "string" == typeof b && e.onCloseComplete(void 0 !== a ? a: "")
                }) : "animate" === e.effect && c.modal.animate({
                    top: 0,
                    opacity: 0
                },
                e.animate_speed,
                function() {
                    e.modalHide ? $(this).hide() : $(this).remove(),
                    e.onCloseComplete && "function" == typeof e.onCloseComplete && b && "string" == typeof b && e.onCloseComplete(void 0 !== a ? a: "")
                })
            };
            var g = function() {
                var a = $(window).width(),
                b = $(window).height(),
                d = c.modal.outerWidth(),
                f = c.modal.outerHeight(),
                g = {
                    left: 0,
                    top: 0,
                    right: a - d,
                    bottom: b - f,
                    center: (a - d) / 2,
                    middle: (b - f) / 2
                };
                c[0] = void 0,
                c[1] = void 0,
                $.isArray(e.position) && 2 == e.position.length && "object" == typeof e.position && $.each(e.position,
                function(a, b) {
                    $.each(b,
                    function(b, d) {
                        c[a] = d + "px",
                        c.modal.css(b, c[a]).fadeIn(e.animate_speed)
                    })
                }),
                (void 0 === c[0] || void 0 === c[1]) && (c[0] = g.center, c[1] = g.middle, "boolean" == typeof arguments[0] && arguments[0] === !1 || 0 === e.setPosition ? e.isCenter ? "fadeIn" === e.effect ? c.modal.css({
                    left: c[0],
                    top: c[1],
                    visibility: "visible"
                }).fadeIn(e.animate_speed) : "animate" === e.effect && c.modal.css({
                    left: c[0],
                    top: "-25%",
                    visibility: "visible",
                    opacity: 0
                }).show().animate({
                    left: c[0],
                    top: c[1],
                    opacity: 1
                },
                e.animate_speed) : c.modal.css({
                    left: c[0],
                    top: e.top,
                    visibility: "visible"
                }).fadeIn(e.animate_speed) : (c.modal.stop(!0), c.modal.css({
                    left: c[0],
                    visibility: "visible"
                }).animate({
                    left: c[0],
                    top: c[1]
                },
                e.setPosition)))
            };
            return c.Init()
        }
    },
    g = function(a, b, c) {
        return new f.init(a, b, c)
    },
    h = {
        imgLoadEffect: function() {
            $("img.pro").smartlazyload({
                effect: "fadeIn",
                effect_speed: 100,
                load: function() {
                    h.CheckLazyimage($(this), {
                        oncomplete: function(a, b, c) {
                            this.width == this.height && 1 == this.width || this.width == this.height && 0 == this.width ? (a.hide(), a.attr("src", c).fadeIn("fast")) : a.attr("src", b).fadeIn("fast")
                        }
                    })
                }
            }),
            $("img.BrandMer_star").smartlazyload({
                effect: "fadeIn",
                effect_speed: 100,
                load: function() {
                    h.CheckLazyimage($(this), {
                        oncomplete: function(a, b, c) {
                            this.width == this.height && 1 == this.width || this.width == this.height && 0 == this.width ? (a.hide(), a.attr("src", c).fadeIn("fast")) : a.attr("src", b).fadeIn("fast")
                        }
                    })
                }
            })
        },
        imgBrandEffect: function() {
            $("[data-brandlazy]").smartlazyload({
                effect: "fadeIn",
                effect_speed: 100,
                load: function() {
                    h.CheckLazyimage($(this), {
                        oncomplete: function(a, b, c) {
                            this.width == this.height && 1 == this.width || this.width == this.height && 0 == this.width ? (a.hide(), a.attr("src", c).fadeIn("fast")) : a.attr("src", b).fadeIn("fast")
                        }
                    })
                }
            }),
            window.scroll(0, 1),
            setTimeout(function() {
                window.scroll(0, 0)
            },
            1e3)
        },
        imgNewEffect: function(a) {
            a.elem.prev().children().find("img." + a.cName).filter(":gt(" + (a.total - 1) + ")").smartlazyload({
                effect: "fadeIn",
                effect_speed: 100,
                load: function() {
                    h.CheckLazyimage($(this), {
                        oncomplete: function(a, b, c) {
                            this.width == this.height && 1 == this.width || this.width == this.height && 0 == this.width ? (a.hide(), a.attr("src", c).fadeIn("fast")) : a.attr("src", b).fadeIn("fast")
                        }
                    })
                }
            })
        },
        CheckLazyimage: function(a, b) {
            var c = new Image,
            d = a.data("original"),
            e = a.data("onerror"),
            f = b.oncomplete;
            c.src = "string" == typeof d ? d: e,
            c.onload = c.onerror = c.onreadystatechange = function() {
                return c && c.readyState && "loaded" != c.readyState && "complete" != c.readyState ? !1 : void f.call({
                    width: c.width,
                    height: c.height
                },
                a, d, e)
            }
        }
    },
    i = {
        cartTimeCensor: function() {
            var a = $('[data-countTime="true"]'),
            c = {
                elem: a,
                time: parseInt(a.attr("data-cartTime")),
                jump: !0,
                timeTag: "span.num_cunt",
                endTips: "00:00",
                timeUnitCls: {
                    day: "",
                    hour: "",
                    min: ":",
                    sec: ""
                }
            }; ! isNaN(c.time) && c.time > 0 && b.tiggerCartTime(c)
        },
        OrderTimeCensor: function() {
            var a = $('[data-countOrder="true"]'),
            c = {
                elem: a,
                time: parseInt(a.attr("data-orderTime")),
                showMin: !0,
                action: "remain",
                timeTag: "span.num_cunt",
                timeUnitCls: {
                    day: "",
                    hour: "",
                    min: ":",
                    sec: ""
                },
                onEndCallBack: !0,
                onEndComplete: function() {
                    self.location.href = self.location.href
                }
            }; ! isNaN(c.time) && c.time > 0 && b.tiggerCartTime(c)
        },
        PBcartTimeCensor: function() {
            var a = $('[data-cTime="true"]'),
            c = {
                elem: a,
                time: parseInt(a.attr("data-cartTime")),
                timeUnitCls: {
                    day: "",
                    hour: "",
                    min: ":",
                    sec: ""
                },
                showMin: !0,
                action: "remain",
                onEndCallBack: !0,
                onEndComplete: function() {
                    this.add(this.prev().prev()).fadeOut(function() {
                        $(this).html("").prev().prev().html("")
                    })
                }
            }; ! isNaN(c.time) && c.time > 0 && b.tiggerCartTime(c)
        }
    },
    j = {
        init: function() {
            i.cartTimeCensor(),
            i.OrderTimeCensor(),
            i.PBcartTimeCensor(),
            h.imgLoadEffect(),
            $("[data-brandlazy]").length && h.imgBrandEffect()
        }
    };
    return {
        init: j.init,
        refreshAppCart: e.refreshAppCart,
        delGoods: d.tiggerDelGoods,
        delBonus: c.tiggerDelBonus,
        addNum: d.numAdd,
        reduceNum: d.numReduce,
        VsmDialog: g,
        VsmDClose: f.close,
        imgNewEffect: h.imgNewEffect,
        countdown: b.tiggerCartTime,
        countclose: b.CartTimereset,
        countReset: b.CartTimereset,
        imgcheck: h.CheckLazyimage
    }
} ();
$(function() {
    VsmCart.init()
});
var VmPageEffect = function() {
    var a, b = $("#scroller_lBer"),
    c = $("#scroller_lIcon"),
    d = $("#goods_images li"),
    e = $("img.Touch_mer_smallImg"),
    f = $("#pro_pagination"),
    g = $("img.Touch_mer_biglImg"),
    h = $("#accordion-category"),
    i = $('[data-clientdl="check"]'),
    j = $('[data-depot="true"]'),
    k = {
        startIndex: 0,
        autoSpeed: 5e3,
        animationSpeed: "fast",
        speed: 600,
        URL: "index.php"
    },
    l = {
        tiggerDLlink: function() {
            var a = Cookie.Browser();
            a.isIPhone ? $('[data-clientdl="iphone"]').show().siblings(".down_iphone").hide() : a.isAndroid ? $('[data-clientdl="android"]').show().siblings(".down_iphone").hide() : $('[data-clientdl="check"]').show().siblings(".down_iphone").hide()
        }
    },
    m = {
        tiggerDepotSet: function(a, b) {
            $.ajax({
                url: "index.php?",
                data: {
                    m: "ajax",
                    act: "select_warehouse",
                    wh: a.posi,
                    p_area: a.area
                },
                type: "POST",
                success: function(a) {
                    location.href = a && null != a && void 0 != a ? a: a,
                    b.oncomplete(!0)
                },
                error: function() {
                    VsmCart.VsmDialog("网络延时，请刷新页面重试！", {
                        setClass: "ui-error",
                        position: [{
                            top: 0
                        },
                        {
                            left: 0
                        }],
                        overClose: !1,
                        overShow: !1,
                        width: "100%",
                        autoClose: 3e3
                    }),
                    b.oncomplete(!0)
                }
            })
        },
        tiggerDepotDo: function(a, b) {
            var c = a,
            d = {
                elem: c,
                area: encodeURI($.trim(c.text().toString())),
                posi: c.attr("data-positions").toString(),
                hascart: parseInt(c.parents("[data-hascart]").data("hascart")),
                Gcookie: Cookie.Get("WAP[p_wh]")
            };
            d.hascart && d.Gcookie && d.Gcookie !== d.posi ? VsmCart.VsmDialog("更换收货地址后，购物车将会被清空，是否确认需要更换？", {
                title: "唯品会友情提醒您",
                overClose: !1,
                buttons: !0,
                type: "question",
                onDoComplete: function(a, c) {
                    d.posi && m.tiggerDepotSet(d, b),
                    c.oncomplete(!1)
                }
            }) : d.posi && m.tiggerDepotSet(d, b)
        },
        tiggerDepotInit: function(a) {
            var b = arguments[1] ? arguments[1] : {},
            c = VsmWebConfig.scroll();
            b.closeBtn ? b.closeBtn: b.closeBtn = !1,
            b.modalHide ? b.modalHide: b.modalHide = !1,
            VsmCart.VsmDialog({
                modal: a,
                setClass: "ui-modal-fade",
                overClose: !1,
                width: "90%",
                isCenter: !1,
                top: 90,
                closeBtn: b.closeBtn,
                modalHide: b.modalHide,
                onDoComplete: function(a, b) {
                    m.tiggerDepotDo(a, b)
                }
            }),
            $(a).css({
                top: c.scrollTop + 90
            })
        },
        tiggerDepotBtn: function() {
            var a = $(this),
            b = {
                elem: a,
                obj: "#" + $("body,html").find("[data-moadl]").attr("id"),
                closeBtn: !0,
                modalHide: !0
            };
            m.tiggerDepotInit(b.obj, b)
        }
    },
    n = {
        triggerBoxStyle: function() {
            this.openObj.css({
                opacity: 0,
                position: "fixed",
                "z-index": 999,
                top: "0px",
                left: " 0px",
                height: "100%",
                width: "100%",
                background: "#000"
            }).show().addClass("open")
        },
        triggerboxclose: function() {
            var a = this.openObj.children().children().filter("a.layer_close"),
            b = this.openObj;
            a.off("click.openboxclose").on("click.openboxclose",
            function() {
                $(this).remove(),
                b.fadeOut("fast")
            })
        },
        triggerBoxOpen: function(a) {
            a.openObj.children().append(a.closeHtml),
            a.openObj.fadeTo(1e3, 1),
            window.Touch_bigImgReview = new Swipe(document.getElementById("bid_goods"), {
                startSlide: a.index,
                callback: function(b, c) {
                    index = c,
                    g.eq(index).hasClass("active") || VsmCart.imgcheck(g.eq(index), {
                        oncomplete: function(a, b, c) {
                            this.width == this.height && 1 == this.width || this.width == this.height && 0 == this.width ? a.attr("src", c).fadeIn(1e3).addClass("active") : a.attr("src", b).fadeIn(1e3).addClass("active")
                        }
                    }),
                    a.openObj.children().find("em").filter(":eq(" + index + ")").addClass("on").siblings().removeClass("on")
                }
            }),
            g.each(function() {
                VsmCart.imgcheck(g.filter(":eq(" + a.index + ")"), {
                    oncomplete: function(a, b, c) {
                        this.width == this.height && 1 == this.width || this.width == this.height && 0 == this.width ? a.attr("src", c).fadeIn(1e3).addClass("active") : a.attr("src", b).fadeIn(1e3).addClass("active")
                    }
                }),
                $(this).bind("error",
                function() {
                    var a = g.index(this);
                    s.checkNote.call($(this), a)
                })
            }),
            a.openObj.children().find("em").filter(":eq(" + a.index + ")").addClass("on").siblings().removeClass("on"),
            n.triggerboxclose.call(a)
        },
        triggeropenbox: function() {
            var a = $(this),
            b = {
                elem: a,
                index: d.index(this),
                openObj: $("#wapModalbbox"),
                closeHtml: '<a href="javascript:;" class="layer_close"><span><i></i></span></a>'
            }; ! b.openObj.hasClass("open") && n.triggerBoxStyle.call(b),
            n.triggerBoxOpen(b)
        },
        FlickerNote: function(a, b, c, d, e) {
            var f = arguments[5] ? arguments[5] : !1,
            g = 0,
            h = !1,
            i = a.attr("class") || "",
            j = "",
            e = e || 2;
            a.hasClass(b) && a.removeClass(b),
            c ? a = a: a.children().filter(":eq(" + d + ")"),
            f && $("body,html").animate({
                scrollTop: a.offset().top - f
            },
            200),
            h || (h = setInterval(function() {
                g++,
                j = g % 2 ? i + " " + b: i,
                a.attr("class", j),
                g == 2 * e && (clearInterval(h), a.attr("class", i))
            },
            200))
        }
    },
    o = {
        sliderMerchandise: function() {
            e.hide(); {
                var a = document.getElementById("goods_images");
                f.children()
            }
            Touch_ImgReview = new Swipe(a, {
                callback: function(a, b) {
                    e.eq(b).hasClass("active") || e.eq(b).is(":visible") || VsmCart.imgcheck(e.eq(b), {
                        oncomplete: function(a, b, c) {
                            this.width == this.height && 1 == this.width || this.width == this.height && 0 == this.width ? a.attr("src", c).fadeIn(1e3).addClass("active") : a.attr("src", b).fadeIn(1e3).addClass("active")
                        }
                    }),
                    f.children().eq(b).addClass("on").siblings().removeClass("on")
                }
            }),
            f.children().eq(0).addClass("on"),
            e.each(function() {
                VsmCart.imgcheck(e.filter(":eq(0)"), {
                    oncomplete: function(a, b, c) {
                        this.width == this.height && 1 == this.width || this.width == this.height && 0 == this.width ? a.attr("src", c).fadeIn(1e3).addClass("active") : a.attr("src", b).fadeIn(1e3).addClass("active")
                    }
                }),
                $(this).bind("error",
                function() {
                    var a = e.index(this);
                    s.checkNote.call($(this), a)
                })
            })
        },
        checkNote: function(a) {
            $merLimg.children().eq(a).remove(),
            this.parent().remove(),
            ImgReview.setup()
        }
    },
    p = {
        buildOverlay: function() {
            $box_overlay.css({
                opacity: 0,
                "z-index": 1e4,
                width: $(window).innerWidth(),
                height: $(document).height(),
                background: "#000"
            })
        },
        getScroll: function() {
            return self.pageYOffset ? {
                scrollTop: self.pageYOffset,
                scrollLeft: self.pageXOffset
            }: document.documentElement && document.documentElement.scrollTop ? {
                scrollTop: document.documentElement.scrollTop,
                scrollLeft: document.documentElement.scrollLeft
            }: document.body ? {
                scrollTop: document.body.scrollTop,
                scrollLeft: document.body.scrollLeft
            }: void 0
        },
        boxBuild: function(a, b) {
            a.markup = a.markup.replace("{vmsTxt}", b.txt),
            a.markup = a.markup.replace("{vmsBtn}", b.btn),
            $("body").append(a.markup),
            $box_holder = $("div.ui-center-overlay"),
            $box_overlay = $("div.overlayer"),
            $box_holder.css({
                marginTop: -($box_holder.innerHeight() / 2),
                marginLeft: -($box_holder.innerWidth() / 2)
            }),
            p.buildOverlay()
        },
        boxShowContent: function(a) {
            $box_overlay.show().fadeTo(a.animation, a.opacity),
            $box_holder.fadeIn(a.animation,
            function() {})
        },
        boxInit: function(a) {
            var b = {
                autoplay: !0,
                allow_open: !0,
                modal: !1,
                opacity: .5,
                animation: "fast",
                markup: '<div id="ui-vsmbox"><div class="overlayer"></div><div class="ui-center-overlay" style="display:none;"><div class="ui-container">{vmsTxt}{vmsBtn}</div></div></div>'
            },
            c = $.extend(!0, {},
            b, a);
            p.boxBuild(c, a),
            p.boxShowContent(c)
        }
    },
    q = {
        advertSlide: function() {
            var a = document.getElementById("scroller_lBer"),
            d = document.getElementById("scroller_lIcon"),
            e = $.extend(!0, {},
            k);
            if (a && null != a && void 0 != a) {
                {
                    var f = $("#wb_position > em");
                    new Swipe(a, {
                        startSlide: e.startIndex,
                        auto: e.autoSpeed,
                        callback: function(a, c) {
                            b.children().find("li").eq(c).children().find("img").hasClass("active") || b.children().find("li").eq(c).children().find("img").is(":visible") || b.children().find("li").eq(c).children().find("img").attr("src", b.children().find("li").eq(c).children().find("img").attr("data-img")).fadeIn(e.animationSpeed),
                            f.eq(c).addClass("on").siblings().removeClass("on")
                        }
                    })
                }
                f.eq(e.startIndex).addClass("on").siblings().removeClass("on"),
                b.children().find("li").eq(e.startIndex).children().find("img").attr("src", b.children().find("li").eq(e.startIndex).children().find("img").attr("data-img")).fadeIn(e.animationSpeed).addClass("active")
            }
            if (d && null != d && void 0 != d) {
                {
                    var g = $("#ic_position").children().filter("em");
                    new Swipe(d, {
                        startSlide: e.startIndex,
                        callback: function(a, b) {
                            g.eq(b).addClass("on").siblings().removeClass("on"),
                            c.children().children("li").eq(b).children().find("img.q_icon").each(function() {
                                $(this).attr("src", $(this).attr("data-srcimg")).fadeIn(e.animationSpeed)
                            })
                        }
                    })
                }
                g.eq(e.startIndex).addClass("on").siblings().removeClass("on"),
                c.children().children("li").eq(e.startIndex).children().find("img.q_icon").each(function() {
                    $(this).attr("src", $(this).attr("data-srcimg"))
                })
            }
        }
    },
    r = {
        triggerAccOpen: function() {
            1 === this.id ? (this.elem.addClass("open").next().slideDown().siblings().filter(".classified_cont").slideUp(), this.elem.siblings().removeClass("open")) : 2 === this.id && this.elem.addClass("open").next().slideToggle()
        },
        triggerAccClose: function() {
            1 === this.id ? this.elem.removeClass("open").next().slideUp().siblings().filter(".classified_cont").slideUp() : 2 === this.id && this.elem.removeClass("open").next().slideToggle()
        },
        triggerAccordion: function() {
            var a = $(this),
            b = {
                elem: a,
                next: a.next(),
                id: parseInt(a.parent().data("collapsed"), 10)
            };
            b.elem.hasClass("open") ? r.triggerAccClose.call(b) : r.triggerAccOpen.call(b)
        }
    },
    t = {
        ProsizeEvent: function() {
            a = new iScroll("Size_wrapper", {
                checkDOMChanges: !0,
                onScrollStart: function() {
                    a.refresh()
                }
            })
        },
        ProductGetData: function(b) {
            $.each(b,
            function(c) {
                b[c];
                b[c].content.length > 0 && "array" == b[c].type ? ($("#wap_Size_data").html($("#wap_sizeTemplate")), $("#wap_sizeTemplate").show(), $_tableStr = "", $.each(b[c].content,
                function(a, b) {
                    $_tableStr += "<tr>",
                    $.each(b,
                    function(a, b) {
                        $_tableStr += "" == b ? "<td>/</td>": "<td>" + b + "</td>"
                    }),
                    $_tableStr += "</tr>"
                }), $("#J_tableBody").prepend($_tableStr), b[c].tips.length > 0 && $("#J_size_tips").append(b[c].tips).removeClass("hidden")) : b[c].content.length > 0 && "html" == b[c].type ? ($("#wap_Size_data").html(b[c].content), $("#wap_Size_data").children().find("table").removeClass("table").addClass("wap_size_tab")) : ("error" == b[c].type || 0 == b[c].content) && $("#wap_Size_data").html('<p class="font14">此商品没有尺码</>');
                var d = $(".wap_size_tab").width();
                d > 500 && ($("#Size_scroller").removeClass("SizeScroller").addClass("SizeScroller_l"), a.refresh())
            })
        },
        getMerSize: function() {
            var a = VsmwebForm.sizeDefault();
            $.ajax({
                url: a.wapDom.userUrl + "s=" + (new Date).getTime(),
                data: {
                    act: a.wapDom.act,
                    productid: a.wapDom.product_id,
                    brandid: a.wapDom.brand_id
                },
                dataType: "json",
                success: function(a) {
                    t.ProductGetData(a)
                }
            })
        },
        cateInit: function() {
            $("#wap_Size_data").length && t.ProsizeEvent()
        }
    },
    u = {
        resolveLocalHref: function(a) {
            var b = document.createElement("a");
            return b.href = a,
            {
                num: parseInt(/[0-4]{1}/g.exec(b.pathname), 10),
                source: a,
                file: (b.pathname.match(/\/([^\/?#]+)$/i) || [, ""])[1],
                query: b.search,
                params: function() {
                    for (var a, c = {},
                    d = b.search.replace(/^\?/, "").split("&"), e = d.length, f = 0; e > f; f++) d[f] && (a = d[f].split("="), c[a[0]] = a[1]);
                    return c
                } ()
            }
        },
        channelCount: function(a) {
            $.ajax({
                url: "index.php?s=" + (new Date).getTime(),
                type: "GET",
                data: {
                    v: ui,
                    f: a,
                    m: "ajexqd"
                },
                dataType: "json",
                success: function() {}
            })
        },
        channelLoad: function(a) {
            var b, c = {
                Channel: 0,
                url: null
            },
            d = $.extend(!0, {},
            c, a);
            d.Channel && null != d.url && (b = u.resolveLocalHref(d.url), b.params.f && u.channelCount(b.params.f))
        }
    },
    v = {
        BindEvents: function() {
            d.off("click.openImages").on("click.openImages", n.triggeropenbox),
            h.children().filter(".class_tit").off("click.dropAccordion").on("click.dropAccordion", r.triggerAccordion),
            j.off("click.select.depot").on("click.select.depot", m.tiggerDepotBtn)
        },
        BindBrowserEvents: function() {
            var a = Cookie.Browser(),
            b = $("<div />", {
                "class": "ui-top-note"
            });
           // (void 0 == Cookie.Get("warehouse") || "undefined" == Cookie.Get("warehouse") || "" == Cookie.Get("warehouse")) && (0 != a.isSafari && "" != a.isSafari ? $(b).text("浏览器cookie被禁用，为了不影响您购物，请去设置中开启cookie！11").prependTo("body") : $(b).text("浏览器cookie被禁用，为了不影响您购物，请去浏览器设置中开启cookie！22").prependTo("body"))
        }
    },
    w = {
        NeedtoCensor: function() {
            d.length && o.sliderMerchandise(),
            $("#CartCountdown").length && oP.cartTimerRun(),
            i.length && l.tiggerDLlink()
        }
    },
    x = {
        init: function() {
            v.BindEvents(),
            v.BindBrowserEvents(),
            w.NeedtoCensor(),
            q.advertSlide()
        }
    };
    return {
        init: x.init,
        depot: m.tiggerDepotInit,
        iscroll: t.cateInit,
        sizePro: t.getMerSize,
        sharkError: n.FlickerNote,
        localUrl: u.resolveLocalHref,
        ChannelCount: u.channelCount,
        ChannelLoad: u.channelLoad,
        boxShow: p.boxInit
    }
} ();
$(function() {
    VmPageEffect.init()
}),
function(a, b) {
    var c = a(b);
    a.fn.smartlazyload = function(d) {
        function e() {
            var b = 0;
            g.each(function() {
                var c = a(this);
                if (!h.skip_invisible || c.is(":visible")) if (a.abovethetop(this, h) || a.leftofbegin(this, h));
                else if (a.belowthefold(this, h) || a.rightoffold(this, h)) {
                    if (++b > h.failure_limit) return ! 1
                } else c.trigger("appear"),
                h.ajax_getdata && "pad" == h.data_Version && "" != h.data_productid ? c.trigger("ajaxsize") : h.ajax_getdata && "touch" == h.data_Version && "" != h.data_productid ? c.trigger("touch_ajaxsize") : h.ajax_getdata && "Get_Merstar" == h.data_Type && "" == h.data_productid && c.trigger(h.data_Version + "_" + h.data_Type)
            })
        }
        var f, g = this,
        h = {
            threshold: 0,
            failure_limit: 0,
            event: "scroll",
            effect: "show",
            container: b,
            data_attribute: "original",
            error_attribute: "data-onerror",
            ajax_getdata: !1,
            data_Version: "pad",
            data_Type: "",
            data_productid: "",
            data_brandid: "",
            skip_invisible: !0,
            appear: null,
            load: null
        };
        return d && (void 0 !== d.failurelimit && (d.failure_limit = d.failurelimit, delete d.failurelimit), void 0 !== d.effectspeed && (d.effect_speed = d.effectspeed, delete d.effectspeed), a.extend(h, d)),
        f = void 0 === h.container || h.container === b ? c: a(h.container),
        0 === h.event.indexOf("scroll") && f.bind(h.event,
        function() {
            return e()
        }),
        this.each(function() {
            var b = this,
            c = a(b);
            b.loaded = !1,
            c.one("appear",
            function() {
                if (!this.loaded) {
                    if (h.appear) {
                        var d = g.length;
                        h.appear.call(b, d, h)
                    }
                    a("<img />").bind("load",
                    function() {
                        a(this).addClass("dasdas"),
                        c.hide().attr("src", c.data(h.data_attribute))[h.effect](h.effect_speed),
                        b.loaded = !0;
                        var d = a.grep(g,
                        function(a) {
                            return ! a.loaded
                        });
                        if (g = a(d), h.load) {
                            var e = g.length;
                            h.load.call(b, e, h)
                        }
                    }).attr("src", c.data(h.data_attribute)),
                    "" != h.error_attribute && a("<img />").bind("error",
                    function() {
                        c.hide().attr("src", c.attr(h.error_attribute))[h.effect](h.effect_speed),
                        b.loaded = !0;
                        a.grep(g,
                        function(a) {
                            return ! a.loaded
                        })
                    }).attr("src", c.data(h.data_attribute))
                }
            }),
            c.one("ajaxsize",
            function() {
                VmPageEffect.Profastsize(b, h)
            }),
            c.one("touch_ajaxsize",
            function() {
                TouchajaxGetdataSN(b, h)
            }),
            c.one(h.data_Version + "_" + h.data_Type,
            function() {
                VmPageEffect.star(b, h)
            }),
            0 !== h.event.indexOf("scroll") && c.bind(h.event,
            function() {
                b.loaded || c.trigger("appear")
            })
        }),
        c.bind("resize",
        function() {
            e()
        }),
        e(),
        this
    },
    a.belowthefold = function(d, e) {
        var f;
        return f = void 0 === e.container || e.container === b ? c.height() + c.scrollTop() : a(e.container).offset().top + a(e.container).height(),
        f <= a(d).offset().top - e.threshold
    },
    a.rightoffold = function(d, e) {
        var f;
        return f = void 0 === e.container || e.container === b ? c.width() + c.scrollLeft() : a(e.container).offset().left + a(e.container).width(),
        f <= a(d).offset().left - e.threshold
    },
    a.abovethetop = function(d, e) {
        var f;
        return f = void 0 === e.container || e.container === b ? c.scrollTop() : a(e.container).offset().top,
        f >= a(d).offset().top + e.threshold + a(d).height()
    },
    a.leftofbegin = function(d, e) {
        var f;
        return f = void 0 === e.container || e.container === b ? c.scrollLeft() : a(e.container).offset().left,
        f >= a(d).offset().left + e.threshold + a(d).width()
    },
    a.inviewport = function(b, c) {
        return ! (a.rightofscreen(b, c) || a.leftofscreen(b, c) || a.belowthefold(b, c) || a.abovethetop(b, c))
    },
    a.extend(a.expr[":"], {
        "below-the-fold": function(b) {
            return a.belowthefold(b, {
                threshold: 0
            })
        },
        "above-the-top": function(b) {
            return ! a.belowthefold(b, {
                threshold: 0
            })
        },
        "right-of-screen": function(b) {
            return a.rightoffold(b, {
                threshold: 0
            })
        },
        "left-of-screen": function(b) {
            return ! a.rightoffold(b, {
                threshold: 0
            })
        },
        "in-viewport": function(b) {
            return ! a.inviewport(b, {
                threshold: 0
            })
        },
        "above-the-fold": function(b) {
            return ! a.belowthefold(b, {
                threshold: 0
            })
        },
        "right-of-fold": function(b) {
            return a.rightoffold(b, {
                threshold: 0
            })
        },
        "left-of-fold": function(b) {
            return ! a.rightoffold(b, {
                threshold: 0
            })
        }
    })
} (jQuery, window),
document.addEventListener("DOMContentLoaded",
function() {
    VsmwebEffect.cateInit()
},
!1);