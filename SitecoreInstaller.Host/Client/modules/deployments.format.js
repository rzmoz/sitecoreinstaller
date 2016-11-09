(function ($) {
    $.fn.newLocalDeployment_onClick = function (options) {
        this.on('click',
                function () {
                    $.confirm({
                        confirmButton: 'Deploy',
                        cancelButton: 'Cancel',
                        title: 'New Local Deployment',
                        content: 'url:/modules/newLocalDeploymentForm.html',
                        contentLoaded: function (data, status, xhr) {
                            var $html = $(data);

                            var licJson = buildLibrary.licenseJson;
                            var licOptions = deploymentsFormat.selects.getLicenseOptions(licJson);
                            $html.find('#selLicense').html(licOptions);

                            var scJson = buildLibrary.sitecoreJson;
                            var scOptions = deploymentsFormat.selects.getSitecoreOptions(scJson);
                            $html.find('#selSitecore').html(scOptions);

                            this.setContent($html);
                        },
                        confirm: function () {
                            var name = $('#new-deployment-name').val();
                            var sitecore = $('#selSitecore').find(":selected").val();
                            var license = $('#selLicense').find(":selected").val();

                            if (name === undefined || name === '') {
                                $.alert('Please enter name of deployment');
                                return false;
                            }
                            if (sitecore === undefined || sitecore === '') {
                                $.alert('Please Sitecore version');
                                return false;
                            }
                            if (license === undefined || license === '') {
                                $.alert('Please select license');
                                return false;
                            }

                            //start new local deployment
                            deployments.putLocal(name, sitecore, license, '', function (response) { });
                            return true;
                        }
                    });
                });
        return this;
    };
}(jQuery));


var deploymentsFormat = {
    selects: {
        getSitecoreOptions: function (sitecoreJson) {
            return deploymentsFormat.selects.getFormattedOptions(sitecoreJson,
                    function (sitecore) {
                        return sitecore;
                    },
                    function (sitecore) {
                        return sitecore;
                    }
                );
        },
        getLicenseOptions: function (licenseJson) {
            return deploymentsFormat.selects.getFormattedOptions(licenseJson,
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
    getDepPanel: function (index, info, dataParent) {
        return deploymentsFormat.infoPanelHtml
            .replace('[[panel-id]]', deploymentsFormat.getDepPanelId(info))
            .replace('[[data-parent]]', dataParent.attr('id'))
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