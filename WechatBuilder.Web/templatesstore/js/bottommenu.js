 
function displayit(n) {
    var clickUl = $("#" + n);
    if (clickUl.is(":hidden")) {
        $(".menuUl").hide();
        clickUl.show();

    }
    else {
        clickUl.hide();
    }
       
    }
    function closeall() {
        var count = document.getElementById("top_menu").getElementsByTagName("ul").length;
        for (i = 0; i < count; i++) {
            document.getElementById("top_menu").getElementsByTagName("ul").item(i).style.display = 'none';
        }
        document.getElementById("plug-wrap").style.display = 'none';
    }
    document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
        WeixinJSBridge.call('hideToolbar');
    });
 