var deployments = {
    dataDeploymentNameKey: 'data-deployment-name',
    baseUrl: '/api/local/deployments/',

    load: function (parent, callback) {
        var phInfo = $('<div/>');
        phInfo.load(host.getModulesPath('deployments_infoPanel', 'html'), function () {
            phInfo.appendTo($(parent));
        });

        var phDelete = $('<div/>');
        phDelete.load(host.getModulesPath('deployments_deleteLocalDeploymentDialog', 'html'), function () {
            phDelete.appendTo($(parent));
        });

        var phPut = $('<div/>');
        parent.load(host.getModulesPath('deployments_putLocalDeploymentDialog', 'html'), function () {
            phPut.appendTo($(parent));
        });

        callback();
    },

    init: function () {
        host.siHub.client.updateLocalDeploymentsCount = function (count) {
            serviceBus.publish('get/deployments/local/count', count);
        }
        /*
        serviceBus.subscribe('delete/deployments/local', function (name) {
            deployments.deleteLocal(name, () => { });
        });
        serviceBus.subscribe('put/deployments/local', function (args) {
            deployments.putLocal(args.name, args.sitecore, args.license, '', () => { });
        });
        
        host.siHub.client.updateDeployments = function (deployments) {
            serviceBus.publish('get/deployments/local', deployments);
        }*/
    },

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
