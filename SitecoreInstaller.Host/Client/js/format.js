var format = {
    deployments: {
        getStatusIcon: function (status, statusText) {
            var statusClass;
            if (deployments.isInProgress(status))
                statusClass = 'fa-circle-o-notch fa-spin';
            else if (status === "Success")
                statusClass = 'fa-check-square-o';
            else {
                statusClass = 'fa-exclamation-triangle';
            }
            return statusText + ': <i class="fa fa-1x fa-fw ' + statusClass + '"></i>';
        },
        getLocalDataTableSet: function (localDeployments) {
            var dataSet = [];
            $.each(localDeployments,
                function (ind, val) {

                    var inProgress = '';
                    if (deployments.isInProgress(val.task.status)) {
                        inProgress = ' disabled';
                    }

                    dataSet.push([
                        val.name,
                        val.sitecore,
                        format.deployments.getStatusIcon(val.task.status, val.task.name),
                        '<a href="http://' + val.url + '/" class="btn btn-block btn-default ' + inProgress + '"  target="_blank">Open Frontend <i class="fa fa-external-link"></i></a>',
                        '<a href="http://' + val.url + '/sitecore" class="btn btn-block btn-default' + inProgress + '" target="_blank">Open Client <i class="fa fa-external-link-square"></i></a>',
                        "<button type='button' class='btn btn-block btn-danger del-local-deployment " + inProgress + "' name='" + val.name + "'>Delete <i class='fa fa-exclamation-triangle'></i></button>"
                    ]);
                });
            return dataSet;
        }
    },
    selects: {
        getSitecoreOptions: function (sitecoreJson) {
            return format.selects.getFormattedOptions(sitecoreJson,
                    function (sitecore) {
                        return sitecore;
                    },
                    function (sitecore) {
                        return sitecore;
                    }
                );
        },
        getLicenseOptions: function (licenseJson) {
            return format.selects.getFormattedOptions(licenseJson,
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
    }

}