var buildlibrary = {
    sitecores: [],
    licenses: [],
    modules: [],
    init: function () {
        server.poll(buildlibrary.refresh);
    },
    refresh: function (callback) {
        $.getJSON('/api/buildlibrary',
            function (data) {
                buildlibrary.sitecores = data.sitecores;
                buildlibrary.licenses = data.licenses;
                buildlibrary.modules = data.modules;

                if (callback !== undefined)
                    callback();

                serviceBus.publish('get/api/buildlibrary', data);
            });
    }
}