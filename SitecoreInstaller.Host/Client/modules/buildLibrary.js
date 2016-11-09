(function ($) {
    $.fn.sitecoreOptions = function () {
        var scJson = buildLibrary.sitecoreJson;
        var optionsHtml = buildLibrary.format.sitecoreOptions(scJson);
        this.html(optionsHtml);
        return this;
    };
}(jQuery));
(function ($) {
    $.fn.licenseOptions = function () {
        var licJson = buildLibrary.licenseJson;
        var optionsHtml = buildLibrary.format.licenseOptions(licJson);
        this.html(optionsHtml);
        return this;
    };
}(jQuery));


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
    sitecoresUri: "/api/buildlibrary/sitecores",

    format: {
        sitecoreOptions: function (sitecoreJson) {
            return buildLibrary.format.getFormattedOptions(sitecoreJson,
                    function (sitecore) {
                        return sitecore;
                    },
                    function (sitecore) {
                        return sitecore;
                    }
                );
        },
        licenseOptions: function (licenseJson) {
            return buildLibrary.format.getFormattedOptions(licenseJson,
                    function (license) {
                        return license.licensee + ' (' + license.id + ')';
                    },
                    function (license) {
                        return license.name;
                    }
                );
        },
        getFormattedOptions: function (json, getTextCallback, getValueCallback) {
            var options = '';
            $.each(json,
                function (key, element) {
                    var text = getTextCallback(element);
                    var value = getValueCallback(element);
                    var option = '<option value="' + value + '">' + text + '</option>';
                    options += option;

                });
            return options;
        }
    },
}