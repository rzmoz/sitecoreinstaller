(function ($) {
    $.fn.initDeploymentsList = function () {
        deploymentsList.refresh(this);
        return this;
    };
}(jQuery));

(function ($) {
    $.fn.localDeploymentsCount = function (interval) {
        var $this = this;
        host.triggerAndAutoRefresh(function () {
            $this.html(deployments.localDeployments.length);
        }, interval);
        return this;
    };
}(jQuery));

var deployments = {
    baseUrl: '/api/local/deployments/',
    localDeployments: [],
    init: function (callback) {
        deployments.getAllLocal(callback);
        host.triggerAndAutoRefresh(deployments.getAllLocal);
    },
    getLocal: function (name, callback) {
        $.getJSON(deployments.baseUrl + name + '/status', callback);
    },
    getAllLocal: function (callback) {

        $.getJSON(deployments.baseUrl,
            function (json) {
                deployments.localDeployments = json;
                if (callback !== undefined)
                    callback();
            });
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
