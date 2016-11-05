var dashboard = {
    iGetTitle: function () {
        return "Dashboard";
    },
    iLoad: function (doneCallback) {
        var deploymentsTable = $('#table-local-deployments');
        localDeployments.loadAllInfos(deploymentsTable);
        dashboard.newLocalDeployment_onClick();

        doneCallback();
    },
    newLocalDeployment_onClick: function () {
        $('#new-local-deployment')
            .on('click',
                function () {
                    $.confirm({
                        confirmButton: 'Deploy',
                        cancelButton: 'Cancel',
                        title: 'New Local Deployment',
                        content: 'url:/content/newLocalDeploymentForm.html',
                        contentLoaded: function (data, status, xhr) {
                            var $html = $(data);

                            var licJson = buildLibrary.getJson(buildLibrary.licensesUri);
                            console.log('license json:' + JSON.stringify(licJson));
                            var licOptions = format.getLicenseOptions(licJson);
                            $html.find('#selLicense').html(licOptions);

                            var scJson = buildLibrary.getJson(buildLibrary.sitecoresUri);
                            console.log('sitecore json:' + JSON.stringify(scJson));
                            var scOptions = format.getSitecoreOptions(scJson);
                            $html.find('#selSitecore').html(scOptions);

                            this.setContent($html);
                        },
                        confirm: function () {

                            var name = $('#new-deployment-name').val();
                            var sitecore = $('#selSitecore').find(":selected").val();
                            var license = $('#selLicense').find(":selected").val();
                            console.log('name:' + name);
                            console.log('sitecore:' + sitecore);
                            console.log('license:' + license);

                            if (name === undefined || name === '') {
                                $.alert('Please enter name of deployment');
                                return false;
                            }

                            //start new local deployment
                            localDeployments.put(name, sitecore, license, '', function (response) {
                            });
                            return true;
                        }
                    });
                });
    }
}