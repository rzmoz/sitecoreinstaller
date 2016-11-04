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