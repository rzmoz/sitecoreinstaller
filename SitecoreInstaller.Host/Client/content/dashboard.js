var dashboard = {
    iGetTitle: function () {
        return "Dashboard";
    },
    iLoad: function () {
        dashboard.newLocalDeployment_onClick();
        //init deployments table
        $('#table-deployments')
            .DataTable({
                paging: false
            });
        dashboard.iRefresh(function () {
        });
    },
    iRefresh: function (callback) {
        deployments.loadAllInfos(function (localDeployments) {
            dashboard.refreshDeploymentCounts();

            var dataSet = format.deployments.getLocalDataTableSet(localDeployments);
            var dataTable = $('#table-deployments').DataTable();
            dataTable.clear();
            dataTable.rows.add(dataSet).draw();

            if (callback !== undefined) {
                callback();
            }
        });
        buildLibrary.loadAll(function () { });
    },

    refreshDeploymentCounts: function () {
        $('#count-local-deployments').html(deployments.localDeployments.length);

    },
    deleteLocalDeployment_onClick: function (depName) {
        $.confirm({
            title: "Deleting " + depName + "!",
            content: 'Are you sure you want to delete ' + depName + '?',
            confirmButton: 'Yes',
            cancelButton: 'No',
            confirm: function () {
                deployments.deleteLocal(depName);
            }
        });

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
                            var licOptions = format.selects.getLicenseOptions(licJson);
                            $html.find('#selLicense').html(licOptions);

                            var scJson = buildLibrary.sitecoreJson;
                            var scOptions = format.selects.getSitecoreOptions(scJson);
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