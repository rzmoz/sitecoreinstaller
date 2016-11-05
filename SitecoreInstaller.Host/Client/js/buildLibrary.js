var buildLibrary = {
    sitecoreJson: [],
    licenseJson: [],
    moduleJson: [],

    loadAll: function (callback) {
        $.getJSON(buildLibrary.sitecoresUri, function (scJson) {
            $.getJSON(buildLibrary.licensesUri, function (licJson) {
                $.getJSON(buildLibrary.modulesUri, function (modJson) {
                    buildLibrary.sitecoreJson = scJson;
                    buildLibrary.licenseJson = licJson;
                    buildLibrary.moduleJson = modJson;
                    if (callback !== undefined) {
                        callback();
                    }
                });
            });
        });
    },

    licensesUri: "/api/buildlibrary/licenses",
    modulesUri: "/api/buildlibrary/modules",
    sitecoresUri: "/api/buildlibrary/sitecores"
}