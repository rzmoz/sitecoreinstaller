﻿(function ($) {
    $.fn.initDeploymentsList = function (callback) {
        var $this = this;

        this.load(host.getModulesPath('deploymentsInfoPanel', 'html'), function () {
            deploymentsInfoPanel_htmlModule.init($this);
            if (callback !== undefined)
                callback();
        });
        return this;
    };
}(jQuery));

(function ($) {
    $.fn.initNewLocalDeploymentDialog = function () {
        this.unbind();
        this.on('click', function () {
            deployments.refreshNewDepSelections();
            $('#new-local-deployment-name').val('');
            $('#newLocalDeploymentModal').modal();
        });
        return this;
    };
}(jQuery));

var deployments = {
    dataDeploymentNameKey: 'data-deployment-name',
    baseUrl: '/api/local/deployments/',

    refreshNewDepSelections: function () {
        $('#selLicense').html('');
        var licenses = buildLibrary.licenses;
        $.each(licenses, function (i, license) {
            $('#selLicense').append($(new Option(license.licensee + ' (' + license.id + ')', license.name)));
        });

        $('#selSitecore').html('');
        var sitecores = buildLibrary.sitecores;
        $.each(sitecores, function (i, sitecore) {
            $('#selSitecore').append($(new Option(sitecore, sitecore)));
        });
    },

    getLocal: function (name, callback) {
        $.getJSON(deployments.baseUrl + name + '/status', callback);
    },
    deleteLocal: function (name, responseCallback) {
        $.delete(deployments.baseUrl + name, '', responseCallback);
    },
    putLocal: function (name, sitecore, license, modules, responseCallback) {
        var body = {
            name: name,
            sitecore: sitecore,
            license: license,
            modules: []
        };
        $.put(deployments.baseUrl, body, responseCallback);
    }
}
