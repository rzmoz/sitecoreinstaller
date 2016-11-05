var dashboard = {
    iGetTitle: function () {
        return "Dashboard";
    },
    iLoad: function () {
        dashboard.newLocalDeployment_onClick();
        dashboard.iRefresh(function () {
            dashboard.initDeploymentsTable();
        });
    },
    iRefresh: function (callback) {
        deployments.loadAllInfos(function () {
            dashboard.refreshDeploymentCounts();
            if (callback !== undefined) {
                callback();
            }
        });
        buildLibrary.loadAll(function () { });
    },


    initDeploymentsTable: function () {
        $('#table-deployments').DataTable({
        });
    },

    refreshDeploymentCounts: function () {
        $('#count-local-deployments').html(deployments.localDeployments.length);

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

                            var licJson = buildLibrary.licenseJson;
                            var licOptions = format.getLicenseOptions(licJson);
                            $html.find('#selLicense').html(licOptions);

                            var scJson = buildLibrary.sitecoreJson;
                            var scOptions = format.getSitecoreOptions(scJson);
                            $html.find('#selSitecore').html(scOptions);

                            this.setContent($html);
                        },
                        confirm: function () {

                            var name = $('#new-deployment-name').val();
                            var sitecore = $('#selSitecore').find(":selected").val();
                            var license = $('#selLicense').find(":selected").val();

                            if (name === undefined || name === '') {
                                $.alert('Please enter name of deployment');
                                return false;
                            }

                            //start new local deployment
                            deployments.putLocal(name, sitecore, license, '', function (response) {
                            });
                            return true;
                        }
                    });
                });
    }
}