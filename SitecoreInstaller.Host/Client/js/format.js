var format = {
    getLink: function (url, name, target) {
        if (name === undefined)
            name = url;
        if (target === undefined)
            target = '_blank';
        return "<a href='http://" + url + "/' target='" + target + "'>" + name + "</a>";
    },
    getStatusIcon: function (status) {
        if (status === "NotFound")
            return "<div class='bg-danger'>Not found</div>";
        if (status === "Success")
            return "<div class='bg-success'>OK</div>";
        return status;
    },

    getDeploymentInfosToTable: function (dataTableElement) {
        dataTableElement.on("click", "button.del-deployment", function (e) {

            var depName = this.name;

            $.confirm({
                title: "Delete " + depName,
                content: 'Are you sure you want to delete ' + depName + '?',
                confirm: function () {
                    alert('deleting:' + depName);
                    localDeployments.delete(depName);
                }
            });
        });

        localDeployments.getAll(function (json) {
            $.each(json,
                function (index, info) {
                    dataTableElement.children('tbody').append('<tr><td>' + info.name + '</td><td>' + info.sitecore.replace('Sitecore ', '') + '</td><td><button type="button" class="btn btn-danger del-deployment" name="' + info.name + '">Delete</button></td></tr>');
                });



            console.log('Deployments loaded:' + JSON.stringify(json));
        });
    },
    getConfirm: function (title, text, action) {
        $.confirm({
            title: title,
            content: text,
            confirm: function () {
                alert(title);
            }
        });
    },
    getSitecoresToSelect: function (selectElement) {
        buildLibrary.getSitecores(function (json) {

            format.formatSelect(selectElement,
                json,
                function (sitecore) {
                    return sitecore;
                },
                function (sitecore) {
                    return sitecore;
                }
            );
        });
    },
    getLicensesToSelect: function (selectElement) {
        buildLibrary.getLicenses(function (json) {
            format.formatSelect(selectElement,
                json,
                function (license) {
                    return license.licensee + ' (' + license.id + ')';
                },
                function (license) {
                    return license.name;
                }
            );
        });
    },
    formatSelect: function (selectElement, json, getTextCallback, getValueCallback) {
        //reset select
        $(selectElement).html('');

        $.each(json,
            function (key, element) {
                var text = getTextCallback(element);
                var value = getValueCallback(element);
                var option = '<option value="' + value + '">' + text + '</option>';
                $(selectElement).append(option);
            });
    }
}