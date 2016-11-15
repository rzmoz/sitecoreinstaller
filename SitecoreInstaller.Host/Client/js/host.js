(function ($) {
    $.fn.loadSection = function (sectionName, callback) {
        this.load(host.getSectionPath(sectionName, 'html'),
            function () {
                eval(sectionName + '.init(()=>allSystemsReady())');
                if (callback !== undefined)
                    callback();
            });
        return this;
    };
}(jQuery));

//https://davidwalsh.name/pubsub-javascript
var serviceBus = (function () {
    var topics = {};
    var hOP = topics.hasOwnProperty;

    return {
        subscribe: function (topic, listener) {
            if (!hOP.call(topics, topic))
                topics[topic] = [];

            var index = topics[topic].push(listener) - 1;
            console.log('service bus listener subscribing to ' + topic);
            return { remove: function () { delete topics[topic][index]; } };
        },
        publish: function (topic, info) {
            if (!hOP.call(topics, topic))
                return;

            console.log('service bus message to ' + topic + ':' + JSON.stringify(info));

            topics[topic].forEach(function (item) {
                item(info != undefined ? info : {});
            });
        }
    };
})();

var host = {
    siHub: $.connection.siHub,
    loadModule: function (name, callback) {
        $('#modules-content').load(host.getModulesPath(name, 'html'), callback);
    },
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