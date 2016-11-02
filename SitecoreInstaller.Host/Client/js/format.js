var format = {
    addSitecoresToSelect: function(selectElement) {
        host.getSitecores(function(json) {
            //reset select
            $(selectElement).html('');

            $.each(json,
                function (key, sitecore) {
                    var option = '<option value="' + sitecore.name + '">' + sitecore.name + '</option>';
                    $(selectElement).append(option);
                });

        });
    },
    addLicensesToSelect: function (selectElement) {
        host.getLicenses(function (json) {

            //reset select
            $(selectElement).html('');

            $.each(json,
                function (key, license) {

                    var text = license.licensee + ' (' + license.id + ')';
                    var option = '<option value="' + license.name + '">' + text + '</option>';
                    $(selectElement).append(option);
                });
        });
    }
}