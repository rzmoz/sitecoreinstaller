(function ($) {
    $.fn.initDeploymentsList = function (options) {
        var settings = $.extend({
            group: true
        }, options);

        if (settings.group)
            this.addClass('panel-group');
        else
            this.removeClass('panel-group');

        var $this = this;

        this.load(host.getModulesPath('deploymentsInfoPanel', 'html'), function () {
            deployments_HtmlModule.init();
            deploymentsInfoPanel_HtmlModule.initDeploymentList($this);
        });
        return this;
    };
}(jQuery));

(function ($) {
    $.fn.initNewLocalDeploymentDialog = function () {
        var newLocalDepModal = $('#newLocalDeploymentModal');
        this.unbind();
        this.on('click', function () {
            newLocalDepModal.modal();
        });
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
