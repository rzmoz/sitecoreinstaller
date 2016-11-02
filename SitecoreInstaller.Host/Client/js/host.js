var host = {
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