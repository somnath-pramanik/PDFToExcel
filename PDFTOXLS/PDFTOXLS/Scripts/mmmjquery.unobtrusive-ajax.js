﻿/*!
** Unobtrusive Ajax support library for jQuery
** Copyright (C) Microsoft Corporation. All rights reserved.
*/

/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, newcap: true, immed: true, strict: false */
/*global window: false, jQuery: false */

(function ($) {

    var data_click = "unobtrusiveAjaxClick",
        data_validation = "unobtrusiveValidation";

    function getFunction(code, argNames) {
        var fn = window, parts = (code || "").split(".");
        while (fn && parts.length) {
            fn = fn[parts.shift()];
        }
        if (typeof (fn) === "function") {
            return fn;
        }
        argNames.push(code);
        return Function.constructor.apply(null, argNames);
    }

    function isMethodProxySafe(method) {
        return method === "GET" || method === "POST";
    }

    function asyncOnBeforeSend(xhr, method) {
        
        if (!isMethodProxySafe(method)) {
            xhr.setRequestHeader("X-HTTP-Method-Override", method);
        }
    }

    function asyncOnSuccess(element, data, contentType) {
        var mode;

        if (contentType.indexOf("application/x-javascript") !== -1) {  // jQuery already executes JavaScript for us
            return;
        }

        mode = (element.getAttribute("data-ajax-mode") || "").toUpperCase();
        $(element.getAttribute("data-ajax-update")).each(function (i, update) {
            var top;

            switch (mode) {
            case "BEFORE":
                top = update.firstChild;
                $("<div />").html(data).contents().each(function () {
                    update.insertBefore(this, top);
                });
                break;
            case "AFTER":
                $("<div />").html(data).contents().each(function () {
                    update.appendChild(this);
                });
                break;
            default:
                $(update).html(data);
                break;
            }
        });
    }

    function asyncRequest(element, options) {
        var confirm, loading, method, duration;

        confirm = element.getAttribute("data-ajax-confirm");
        if (confirm && !window.confirm(confirm)) {
            return;
        }

        
        loading = $(element.getAttribute("data-ajax-loading"));
        duration = element.getAttribute("data-ajax-loading-duration") || 0;

        $.extend(options, {
            type: element.getAttribute("data-ajax-method") || undefined,
            url: element.getAttribute("data-ajax-url") || undefined,
            beforeSend: function (xhr) {
                var result;
                asyncOnBeforeSend(xhr, method);
                result = getFunction(element.getAttribute("data-ajax-begin"), ["xhr"]).apply(this, arguments);
                if (result !== false) {
                    loading.show(duration);
                }
                return result;
            },
            complete: function () {
                loading.hide(duration);
                getFunction(element.getAttribute("data-ajax-complete"), ["xhr", "status"]).apply(this, arguments);
            },
            success: function (data, status, xhr) {
                asyncOnSuccess(element, data, xhr.getResponseHeader("Content-Type") || "text/html");
                getFunction(element.getAttribute("data-ajax-success"), ["data", "status", "xhr"]).apply(this, arguments);
            },
            error: getFunction(element.getAttribute("data-ajax-failure"), ["xhr", "status", "error"])
        });

        //options.data.push({ name: "X-Requested-With", value: "XMLHttpRequest" });

        //method = options.type.toUpperCase();
        //if (!isMethodProxySafe(method)) {
        //    options.type = "POST";
        //    options.data.push({ name: "X-HTTP-Method-Override", value: method });
        //}


        method = options.type.toUpperCase();
        if (options.data instanceof FormData) {
            alert("kk");
            options.processData = false;
            options.contentType = false;
            options.data.append("X-Requested-With", "XMLHttpRequest");

            if (!isMethodProxySafe(method)) {
               
                options.type = "POST";
                options.data.append("X-HTTP-Method-Override", method);
            }
        } else {
            options.data.push({ name: "X-Requested-With", value: "XMLHttpRequest" });
          
            if (!isMethodProxySafe(method)) {
               
                options.type = "POST";
                options.data.push({ name: "X-HTTP-Method-Override", value: method });
            }
        }

        $.ajax(options);
    }

    function validate(form) {
        alert($(form).attr('id'));
        var validationInfo = $(form).data(data_validation);
        alert(validationInfo);
        return !validationInfo || !validationInfo.validate || validationInfo.validate();
    }

    //$("a[data-ajax=true]").off("click");
    //$("form[data-ajax=true] input[type=image]").off("click");
    //$("form[data-ajax=true] :submit").off("click");
    //$("form[data-ajax=true]").off("submit");

    $("a[data-ajax=true]").on("click", function (evt) {
        evt.preventDefault();
        asyncRequest(this, {
            url: this.href,
            type: "GET",
            data: []
        });
    });

    $("form[data-ajax=true] input[type=image]").on("click", function (evt) {
        var name = evt.target.name,
            $target = $(evt.target),
            form = $target.parents("form")[0],
            offset = $target.offset();

        $(form).data(data_click, [
            { name: name + ".x", value: Math.round(evt.pageX - offset.left) },
            { name: name + ".y", value: Math.round(evt.pageY - offset.top) }
        ]);

        setTimeout(function () {
            $(form).removeData(data_click);
        }, 0);
    });

    $("form[data-ajax=true] :submit").on("click", function (evt) {
        var name = evt.target.name,
            form = $(evt.target).parents("form")[0];

        $(form).data(data_click, name ? [{ name: name, value: evt.target.value }] : []);

        setTimeout(function () {
            $(form).removeData(data_click);
        }, 0);
    });

    $("form[data-ajax=true]").on("submit", function (evt) {
        //var clickInfo = $(this).data(data_click) || [];
        //evt.preventDefault();
        //if (!validate(this)) {
        //    return;
        //}
        //asyncRequest(this, {
        //    url: this.action,
        //    type: this.method || "GET",
        //    data: clickInfo.concat($(this).serializeArray())
        //});
        var clickInfo = $(this).data(data_click) || [];
          //  clickTarget = $(this).data(data_target);
            //isCancel = clickTarget && clickTarget.hasClass("cancel");
        evt.preventDefault();
        alert("New");
        
        if (validate(this)) {
            alert("few");
            return;
        }
        var formData;
        if (this.enctype && this.enctype === "multipart/form-data") {
            formData = new FormData(this);
        } else {
            formData = clickInfo.concat($(this).serializeArray());
        }

        asyncRequest(this, {
            url: this.action,
            type: this.method || "GET",
            data: formData
        });
    });
}(jQuery));