(function ($) {
    $.fn.subscribeRaw = function (topic) {
        var $this = this;
        serviceBus.subscribe(topic,
            function (info) {
                $this.html(JSON.stringify(info));
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

            topics[topic].push(listener);
            console.log('@@ service bus listener subscribing to ' + topic);
        },
        publish: function (topic, info) {
            if (!hOP.call(topics, topic))
                return;

            console.log('@@ service bus message to ' + topic + ':' + JSON.stringify(info));

            topics[topic].forEach(function (item) {
                item(info != undefined ? info : {});
            });
        }
    };
})();

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