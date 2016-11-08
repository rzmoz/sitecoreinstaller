var deployments = {
    iGetTitle: function () {
        return "Deployments";
    },
    iLoad: function () {
        deployments.newLocalDeployment_onClick();
        //init deployments table
        $('#table-deployments')
            .DataTable({
                paging: false,
                "columnDefs": [{ "className": "dt-center", "targets": "_all" }]
            });

        deployments.iRefresh(function () {
        });
    },
    iRefresh: function (callback) {
        localDeployments.loadAllInfos(function (localDeployments) {
            deployments.refreshDeploymentCounts();

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
        $('#count-local-deployments').html(localDeployments.deployments.length);

    },
    deleteLocalDeployment_onClick: function (depName) {
        $.confirm({
            title: "Deleting " + depName + "!",
            content: 'Are you sure you want to delete ' + depName + '?',
            confirmButton: 'Yes',
            cancelButton: 'No',
            confirm: function () {
                localDeployments.delete(depName);
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
                            localDeployments.put(name, sitecore, license, '', function (response) {
                            });
                            return true;
                        }
                    });
                });
    }
}