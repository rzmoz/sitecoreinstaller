var deployments = {
    localDeployments: [],
    azureDeployments: [],

    loadAllInfos:function(callback) {
        deployments.getAllLocal(function (json) {
            deployments.localDeployments = json;
            //console.log('Deployments loaded:' + JSON.stringify(deployments.localDeployments));
            callback(deployments.localDeployments, deployments.azureDeployments);
        });
    },
    
    getAllLocal: function (callback) {
        var uri = "/api/local/deployments";
        $.getJSON(uri, callback);
    },
    deleteLocal: function (name, responseCallback) {
        $.delete('/api/local/deployments/' + name, '', responseCallback);
    },
    putLocal: function (name, sitecore, license, modules, responseCallback) {
        var body = {
            name: name,
            sitecore: sitecore,
            license: license,
            modules: []
        };
        $.put('/api/local/deployments', body, responseCallback);
    }
}
