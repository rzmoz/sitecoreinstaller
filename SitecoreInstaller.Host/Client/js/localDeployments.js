var localDeployments = {
    deployments: [],
    loadAllInfos:function(callback) {
        localDeployments.getAll(function (json) {
            localDeployments.deployments = json;
            callback(localDeployments.deployments);
        });
    },
    isInProgress:function(status) {
        if (status === undefined) {
            return false;
        }
        return status === "InProgress";
    },
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
