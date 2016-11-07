var format = {
    getLink: function (url, name, target) {
        if (name === undefined)
            name = url;
        if (target === undefined)
            target = '_blank';
        return "<a href='http://" + url + "/' target='" + target + "'>" + name + "</a>";
    },
    getStatusIcon: function (status, statusText) {
        var statusClass = 'fa-exclamation-triangle';
        if (status === "InProgress")
            statusClass = 'fa-circle-o-notch fa-spin';
        else if (status === "Success")
            statusClass = 'fa-check-square-o';

        var statusIcon = statusText + ': <i class="fa fa-1x fa-fw ' + statusClass + '"></i>';

        var statusBox = '<div class="alert alert-info">' + statusIcon + '</div>';

        return statusIcon;
    },

    getLocalDeploymentsDataSet: function (localDeployments) {
        var dataSet = [];
        $.each(localDeployments,
            function (ind, val) {
                dataSet.push([
                    val.name,
                    val.sitecore,
                    format.getStatusIcon(val.task.status, val.task.name),
                    "<a href='http://" + val.url + "/' target='_blank'>Frontend</a>",
                    "<a href='http://" + val.url + "/sitecore' target='_blank'>Client</a>",
                    "<button type='button' class='btn btn-block btn-danger del-local-deployment' name='" + val.name + "'>Delete</button>"
                ]);
            });
        return dataSet;
    },


    getSitecoreOptions: function (sitecoreJson) {
        return format.getFormattedOptions(sitecoreJson,
                function (sitecore) {
                    return sitecore;
                },
                function (sitecore) {
                    return sitecore;
                }
            );
    },
    getLicenseOptions: function (licenseJson) {
        return format.getFormattedOptions(licenseJson,
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