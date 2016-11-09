var format = {
    deployments: {
        getStatusIcon: function (status, statusText) {
            var statusClass;

            if (localDeployments.isInProgress(status))
                statusClass = 'fa-circle-o-notch fa-spin';
            else if (status === "Success") {
                statusClass = 'fa-check-square-o';
                statusText = statusText.replace('ing', '');
            }
            else
                statusClass = 'fa-exclamation-triangle';

            return statusText + ': <i class="fa fa-1x fa-fw ' + statusClass + '"></i>';
        },
        getLocalDataTableSet: function (deps) {
            var dataSet = [];
            $.each(deps,
                function (ind, val) {
                    var panel = '<div class="panel panel-primary"><div class="panel-heading"><h3 class="panel-title">' +
                        val.name +
                        '</h3><span class="pull-right clickable"><i class="glyphicon glyphicon-chevron-up"></i></span></div><div class="panel-body" style="display: block;">' +
                        val.sitecore +
                        '</div></div>';

                    dataSet.push([panel]);
                    /*
                    var inProgress = '';
                    if (localDeployments.isInProgress(val.task.status)) {
                        inProgress = ' disabled';
                    }

                    dataSet.push([
                        val.name,
                        val.sitecore,
                        format.deployments.getStatusIcon(val.task.status, val.task.name),
                        '<a href="http://' + val.url + '/" class="btn btn-default ' + inProgress + '"  target="_blank"><i class="fa fa-external-link"></i></a>',
                        '<a href="http://' + val.url + '/sitecore" class="btn btn-default ' + inProgress + '" target="_blank"><i class="fa fa-external-link-square"></i></a>',
                        '<a href="#" class="btn btn-danger ' + inProgress + '" onclick="javascript:dashboard.deleteLocalDeployment_onClick(\'' + val.name + '\');return false;" target="_blank"><i class="fa fa-trash-o"></i></a>'
                    ]);*/
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