(function ($) {
    $.fn.loadSectionTitle = function (sectionName) {
        var title = eval(sectionName + '.iGetTitle()');
        this.html(title);
        return this;
    };
}(jQuery));

(function ($) {
    $.fn.loadSectionContent = function (sectionName, callback) {
        this.load(host.getSectionPath(sectionName, 'html'), callback);
        return this;
    };
}(jQuery));

(function ($) {
    $.fn.loadModuleContent = function (moduleName, callback) {
        this.load(host.getModulesPath(moduleName, 'html'),
            function () {
                eval(moduleName + '_htmlModule.init()');
                if (callback !== undefined)
                    callback();
            });
        return this;
    };
}(jQuery));

var host = {
    toggleDisabled: function (element, disabledPredicate) {
        if (disabledPredicate())
            element.addClass('disabled');
        else
            element.removeClass('disabled');
    },
    getQueryStringAsJson: function () {
        var qs = window.location.search.replace('?', '');
        qs = '{"' + qs.replace(/&/g, '","').replace(/=/g, '":"') + '"}';
        if (qs === '{""}')
            return qs;
        return $.parseJSON(qs);
    },
    loadSection: function (name, loadedCallback) {
        console.log(name + ' section loading...');
        $.get(host.getSectionPath(name, 'html'),
            function (html) {
                console.log(name + ' html loaded');
                console.log(name + ' section loaded');
                loadedCallback(name, html);
            });

    },
    getSectionPath: function (name, type) {
        return '/sections/' + name + '.' + type;
    },
    getModulesPath: function (name, type) {
        return '/modules/' + name + '.' + type;
    },
    loadModule: function (name) {
        $('head').append($('<link rel="stylesheet" type="text/css" />').attr('href', host.getSectionPath(name, 'css')));
    }
}


jQuery.each(["put", "delete"], function (i, method) {
    jQuery[method] = function (url, data, callback) {

        console.log('ajax called:' + method);
        console.log('url:' + url);
        console.log('data:' + JSON.stringify(data));
        return jQuery.ajax({
            async: false,
            url: url,
            type: method,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            data: JSON.stringify(data),
            error: callback,
            success: callback
        });
    };
});