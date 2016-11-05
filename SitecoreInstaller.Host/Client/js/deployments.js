var deployments = {
    localDeployments: [],

    loadAllLocalInfo:function() {
        deployments.getAll(function (json) {
            deployments.localDeployments = json;
            console.log('Deployments loaded:' + JSON.stringify(deployments.localDeployments));
        });
    },
    /*


    loadAllInfos: function (dataTableElement) {
        dataTableElement.on("click", "button.del-deployment", function (e) {

            var depName = this.name;

            $.confirm({
                title: "Delete " + depName,
                content: 'Are you sure you want to delete ' + depName + '?',
                confirmButton: 'Yes',
                cancelButton: 'No',
                confirm: function () {
                    localDeployments.delete(depName);
                }
            });
        });

        
    },*/


    getAll: function (callback) {
        var uri = "/api/local/deployments";
        $.getJSON(uri, callback);
    },
    delete: function (name, responseCallback) {
        $.delete('/api/local/deployments/' + name, '', responseCallback);
    },
    put: function (name, sitecore, license, modules, responseCallback) {
        var body = {
            name: name,
            sitecore: sitecore,
            license: license,
            modules: []
        };
        $.put('/api/local/deployments', body, responseCallback);
    }
}
