var buildLibrary = {
    sitecoreJson: [],
    licenseJson: [],
    moduleJson: [],

    init: function (callback) {
        $.getJSON(buildLibrary.sitecoresUri, function (scJson) {
            $.getJSON(buildLibrary.licensesUri, function (licJson) {
                $.getJSON(buildLibrary.modulesUri, function (modJson) {
                    buildLibrary.sitecoreJson = scJson;
                    buildLibrary.licenseJson = licJson;
                    buildLibrary.moduleJson = modJson;

                    console.log('Build Library loaded' +
                        '\r\nSitecores:' + JSON.stringify(buildLibrary.sitecoreJson) +
                        '\r\nLicenses:' + JSON.stringify(buildLibrary.licenseJson) +
                        '\r\nModules:' + JSON.stringify(buildLibrary.moduleJson));

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