var format = {
    deployments: {
        getStatusIcon: function (status, statusText) {
            var statusClass = 'fa-exclamation-triangle';
            if (status === "InProgress")
                statusClass = 'fa-circle-o-notch fa-spin';
            else if (status === "Success")
                statusClass = 'fa-check-square-o';
            return statusText + ': <i class="fa fa-1x fa-fw ' + statusClass + '"></i>';
        },
        getLocalDataTableSet : function (localDeployments) {
            var dataSet = [];
            $.each(localDeployments,
                function (ind, val) {
                    dataSet.push([
                        val.name,
                        val.sitecore,
                        format.deployments.getStatusIcon(val.task.status, val.task.name),
                        "<a href='http://" + val.url + "/' target='_blank'>Frontend</a>",
                        "<a href='http://" + val.url + "/sitecore' target='_blank'>Client</a>",
                        "<button type='button' class='btn btn-block btn-danger del-local-deployment' name='" + val.name + "'>Delete</button>"
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