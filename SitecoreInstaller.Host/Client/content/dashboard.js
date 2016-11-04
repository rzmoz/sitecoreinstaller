var dashboard = {
    iGetTitle: function () {
        return "Local IIS Deployments";
    },
    iLoad: function (doneCallback) {
        var deploymentsTable = $('#table-local-deployments');
        localDeployments.loadAllInfos(deploymentsTable);

        doneCallback();
    }
}