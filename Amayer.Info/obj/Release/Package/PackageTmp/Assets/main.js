
//设置导航条
; (function ($, win, undefined) {
    $.fn.xq_navbar = function (_option) {
        var defaults = {
            "bgcolor": "#009688",		//导航条颜色
            "type": "line",	//定义导航类型    下划线 underline 上划线overline 双划线line 块级背景block 
            "liwidth": "avg",		//设置导航项的宽度类型 auto：自动  ， avg：评分， 30：指定具体宽度 
            "hcolor": ["blue", "rgb(10,100,100)", "red", "pink", "green", "rgba(23,234,22,1)", "rgb(230,230,230)"]//指定每一个导航项的颜色。不指定或指定不够默认 #ccc；统一颜色可直接传入颜色值
        }
        var _self = $(this);
        var xq_li = _self.find(".xq_navli");
        this.navbar = _self.find(".xq_navbar");
        this.num = _self.find(".xq_navli").length;
        this.width = this.navbar.width();
        this.height = this.navbar.height();
        $.extend(defaults, _option ? _option : {});
        this.init = function () {


            this.bindmouseover(defaults.type);
        }
        this.bindmouseover = function () {
            var move = $("<div/>", { "class": "xq_move" }).css({ "height": "5px", "left": "-100px", "width": "100px", "bottom": "0px", "margin-left": "15px" }).appendTo(_self);


            var width;
            var movelist = _self.find(".xq_move");
            xq_li.on('mouseover', function () {
                width = $(this).width();

                var left = $(this).offset().left - _self.offset().left;
                var index = $(this).index();
                var color = $.isArray(defaults.hcolor) ? (defaults.hcolor[index] ? defaults.hcolor[index] : "#ccc") : $.trim(defaults.hcolor);
                $(this).css({ "color": color });
                movelist.css({ "background": color, "left": left, "width": width + "px" });
            });
            this.navbar.on('mouseout', function () {
                xq_li.css({ "color": "#fff" });
                movelist.css({ "left": "-150px", "width": "100px" });
            });
        }
        this.init();
    }
})(jQuery, window)

function AjaxHelper() {
    this.ajax = function (url, type, dataType, data, callback) {
        $.ajax({
            url: url,
            type: type,
            dataType: dataType,
            data: data,
            success: callback,
            error: function (xhr, errorType, error) {
                alert('Ajax request error, errorType: ' + errorType + ', error: ' + error)
            }
        })
    }
}
AjaxHelper.prototype.get = function (url, data, callback) {
    this.ajax(url, 'GET', 'json', data, callback)
}
AjaxHelper.prototype.post = function (url, data, callback) {
    this.ajax(url, 'POST', 'json', data, callback)
}

AjaxHelper.prototype.put = function (url, data, callback) {
    this.ajax(url, 'PUT', 'json', data, callback)
}

AjaxHelper.prototype.delete = function (url, data, callback) {
    this.ajax(url, 'DELETE', 'json', data, callback)
}

AjaxHelper.prototype.jsonp = function (url, data, callback) {
    this.ajax(url, 'GET', 'jsonp', data, callback)
}

AjaxHelper.prototype.constructor = AjaxHelper