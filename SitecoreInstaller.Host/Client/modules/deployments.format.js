(function ($) {
    $.fn.initNewLocalDeploymentDialog = function () {
        var newLocalDepModal = $('#newLocalDeploymentModal');
        host.triggerAndAutoRefresh(function () {
            newLocalDepModal.find('#selLicense').licenseOptions();
            newLocalDepModal.find('#selSitecore').sitecoreOptions();
        });

        this.unbind();
        this.on('click', function () {
            newLocalDepModal.modal();
        });
        $('#new-local-deployment-form')
            .submit(function (e) {

                var name = $('#new-deployment-name').val();
                var sitecore = $('#selSitecore').find(":selected").val();
                var license = $('#selLicense').find(":selected").val();
                deployments.putLocal(name, sitecore, license, '');
                newLocalDepModal.modal('toggle');
                e.preventDefault();
            });


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
    getDepPanelId: function (dep) {
        return 'dep-info-pnl-' + dep.name;
    },
    refreshInfoPanel: function (info) {
        var panel = $('#' + deploymentsFormat.getDepPanelId(info));
        panel.find('.btn-delete-deployment').setDisabled(() => { return info.task.status === "InProgress"; });
        panel.find('.info-status-icon').replaceWith(deploymentsFormat.getStatusIconHtml(info.task.status));

    },
    getDepPanelHtml: function (index, info, dataParent) {
        if (info === null || info === undefined)
            return '';
        return deploymentsFormat.infoPanelHtml
            .replace('[[panel-id]]', deploymentsFormat.getDepPanelId(info))
            .replace('[[data-parent]]', dataParent.attr('id'))
            .replace(/\[\[collapse-id\]\]/g, 'collapse-' + index)
            .replace(/\[\[info-name\]\]/g, info.name)
            .replace(/\[\[info-sitecore\]\]/g, info.sitecore)
            .replace(/\[\[info-status\]\]/g, deploymentsFormat.getStatusIconHtml(info.task.status));
    },

    getStatusIconHtml: function (status) {
        var statusClass;
        if (status === "InProgress")
            statusClass = 'fa-circle-o-notch fa-spin';
        else if (status === "Success") {
            statusClass = 'fa-check-square-o';
        }
        else
            statusClass = 'fa-exclamation-triangle';
        return '<i class="fa fa-1x fa-fw info-status-icon ' + statusClass + '"></i>';
    }
}