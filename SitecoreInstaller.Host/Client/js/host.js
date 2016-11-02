var host = {
    putNewDeployment: function (name, sitecore, license, modules, responseCallback) {
        var body = {
            name: name,
            sitecore: sitecore,
            license: license,
            modules:[]
        };
        $.put('/api/deployments', body, responseCallback);
    },
    getQueryStringAsJson: function () {
        var qs = window.location.search.replace('?', '');
        qs = '{"' + qs.replace(/&/g, '","').replace(/=/g, '":"') + '"}';
        if (qs === '{""}')
            return qs;
        return $.parseJSON(qs);
    },
    getLicenses: function (callback) {
        var uri = "/api/buildlibrary/licenses";
        $.getJSON(uri, callback);
    },
    getModules: function (callback) {
        var uri = "/api/buildlibrary/modules";
        $.getJSON(uri, callback);
    },
    getSitecores: function (callback) {
        var uri = "/api/buildlibrary/sitecores";
        $.getJSON(uri, callback);
    }
}


jQuery.each(["put", "delete"], function (i, method) {
    jQuery[method] = function (url, data, callback) {

        console.log('ajax called:' + method);
        console.log('url:' + url);
        console.log('data:' + JSON.stringify(data));
        return jQuery.ajax({
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