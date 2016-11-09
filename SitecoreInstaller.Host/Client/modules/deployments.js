(function ($) {
    $.fn.deploymentsList = function (options) {
        var settings = $.extend({
            deployments: []
        }, options);
        var list = this;
        $.each(settings.deployments, function (index, dep) { list.append(deploymentsFormat.getInfoPanels(index,dep,list)); });
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
    delete_onClick: function (depName) {
        $.confirm({
            title: "Deleting " + depName + "!",
            content: 'Are you sure you want to delete ' + depName + '?',
            confirmButton: 'Yes',
            cancelButton: 'No',
            confirm: function () {
                deployments.deleteLocal(depName);
            }
        });

    },
    getInfoPanels: function (index, info, dataParent) {
        return deploymentsFormat.infoPanelHtml
            .replace(/\[\[data-parent\]\]/g, dataParent.attr('id'))
            .replace(/\[\[collapse-id\]\]/g, index)
            .replace(/\[\[info-name\]\]/g, info.name)
            .replace(/\[\[info-sitecore\]\]/g, info.sitecore)
            .replace(/\[\[info-status\]\]/g, deploymentsFormat.getStatusIcon(info.task.status, info.task.name));
    },

    getStatusIcon: function (status, statusText) {
        var statusClass;
        if (status === "InProgress")
            statusClass = 'fa-circle-o-notch fa-spin';
        else if (status === "Success") {
            statusClass = 'fa-check-square-o';
            statusText = statusText.replace('ing', '');
        }
        else
            statusClass = 'fa-exclamation-triangle';
        return '<i class="fa fa-1x fa-fw ' + statusClass + '"></i>';
        return statusText + ': ';
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
    deleteLocal: function (name, responseCallback) {
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
