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
                        title: 'New Local IIS Deployment',
                        content: 'url:/content/newLocalDeploymentForm.html',
                        contentLoaded: function (data, status, xhr) {
                            var self = this;

                            buildLibrary.getSitecores(function (scJson) {
                                buildLibrary.getLicenses(function (licJson) {
                                    var scOptions = format.getSitecoreOptions(scJson);
                                    var licOptions = format.getLicenseOptions(licJson);
                                    console.log('sitecore options:' + scOptions);
                                    console.log('license options:' + licOptions);

                                    $(self.content).find('#selSitecore').html(scOptions);
                                    $(self.content).find('#selLicense').html(licOptions);

                                    console.log('updated content:' + self.content);
                                    self.setContent($(self.content).parent().html());
                                });
                            });
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
                        }
                    });
                });
    }
}