var buildLibrary = {
    iGetTitle: function () {
        return "Build library";
    },
    iLoad: function (doneCallback) {
        doneCallback();
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