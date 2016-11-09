var dashboard = {
    iGetTitle: function () {
        return "Dashboard";
    },
    init: function () {
        buildLibrary.init(function () {
            deployments.init(function () {
                $('#count-local-deployments').localDeploymentsCount();
                $('#deployments-list').deploymentsList();

                $('#new-local-deployment').newLocalDeployment_onClick();
            });
        });
    }
}