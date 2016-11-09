(function ($) {
    $.fn.deploymentsList = function (options) {
        var settings = $.extend({
            deployments: []
        }, options);
        var list = this;
        $.each(settings.deployments, function (index, dep) { list.append(deploymentsFormat.getInfoPanels(dep)); });
        return this;
    };

}(jQuery));
var deploymentsFormat = {
    infoPanelHtml: '',
    init: function (callback) {
        var uri = "/modules/deploymentsInfoPanel.html";
        $.get(uri, function (html) {
            deploymentsFormat.infoPanelHtml = html;
            callback();
        });
    },
    getInfoPanels: function (info) {
        var id = 'depInfo-' + info.name;
        var title = info.name;
        var content = info.sitecore;
        return deploymentsFormat.infoPanelHtml
            .replace('[[panel-id]]', id)
            .replace('[[panel-title]]', title)
            .replace('[[panel-body]]', content);
    },
    infoPanelCollapseClick: function (element) {
        
        var $this = $(element);
        if (!$this.hasClass('panel-collapsed')) {
            $this.parents('.panel').find('.panel-body').slideUp();
            $this.addClass('panel-collapsed');
            $this.find('i').removeClass('glyphicon-chevron-up').addClass('glyphicon-chevron-down');
        } else {
            $this.parents('.panel').find('.panel-body').slideDown();
            $this.removeClass('panel-collapsed');
            $this.find('i').removeClass('glyphicon-chevron-down').addClass('glyphicon-chevron-up');
        }
    }
}

var deployments = {
    localDeployments: [],
    refresh: function (callback) {
        var uri = "/api/local/deployments";
        $.getJSON(uri, function (json) {
            deployments.localDeployments = json;
            callback(deployments.localDeployments);
        });
    },
    isInProgress: function (status) {
        if (status === undefined) {
            return false;
        }
        return status === "InProgress";
    },
    delete: function (name, responseCallback) {
        $.delete('/api/local/deployments/' + name, '', responseCallback);
    },
    put: function (name, sitecore, license, modules, responseCallback) {
        var body = {
            name: name,
            sitecore: sitecore,
            license: license,
            modules: []
        };
        $.put('/api/local/deployments', body, responseCallback);
    }
}
