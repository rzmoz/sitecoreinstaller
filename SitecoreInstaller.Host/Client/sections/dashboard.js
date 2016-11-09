var dashboard = {
    iGetTitle: function () {
        return "Dashboard";
    },
    init: function (callback) {
        buildLibrary.init(function () {
            deployments.init(function () {
                $('#count-local-deployments').localDeploymentsCount();
                $('#deployments-list').deploymentsList();
                $('#new-local-deployment').initNewLocalDeploymentDialog();
                if (callback !== undefined)
                    callback();
            });
        });
    }
}