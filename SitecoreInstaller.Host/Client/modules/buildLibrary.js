var buildLibrary = {
    sitecores: [],
    licenses: [],
    modules: [],
    init: function () {
        console.log('Initializing Buildlibrary ');

        host.siHub.client.updateSitecores = function (scJson) {
            buildLibrary.sitecores = scJson;
        }
        host.siHub.client.updateLicenses = function (licJson) {
            buildLibrary.licenses = licJson;
        }
        host.siHub.client.updateModules = function (modJson) {
            buildLibrary.modules = modJson;
        }
        console.log('Buildlibrary initialized');
    }
}