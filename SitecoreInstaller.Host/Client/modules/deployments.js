(function ($) {
    $.fn.initDeploymentsList = function (options) {
        var settings = $.extend({
            deployments: [],
            group: true
        }, options);

        if (settings.group)
            this.addClass('panel-group');
        else
            this.removeClass('panel-group');

        var $this = this;

        this.load(host.getModulesPath('deploymentsInfoPanel', 'html'), function () {
            deploymentsInfoPanel_htmlModule.initDeploymentList($this, options.deployments);
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

var deployments = {
    dataDeploymentNameKey: 'data-deployment-name',
    baseUrl: '/api/local/deployments/',
    localDeployments: [],
    
    init: function () {
        
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
