var format = {
    getLink: function (url, name, target) {
        if (name === undefined)
            name = url;
        if (target === undefined)
            target = '_blank';
        return "<a href='http://" + url + "/' target='" + target + "'>" + name + "</a>";
    },
    getStatusIcon: function (status) {
        if (status === "Unknown")
            return "<div class='bg-danger'>Not found</div>";
        if (status === "Success")
            return "<div class='bg-success'>OK</div>";
        return status;
    },

    getDeploymentsDataSet: function (localDeployments) {
        var dataSet = [];
        $.each(localDeployments,
            function (ind, val) {
                dataSet.push([
                    val.name,
                    val.sitecore,
                    val.task.name + ' ' + val.task.status,
                    "<button type='button' class='btn btn-danger del-local-deployment' name='" + val.name + "'>Delete</button>"
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