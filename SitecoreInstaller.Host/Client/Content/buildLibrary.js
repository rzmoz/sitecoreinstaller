var buildLibrary = {
    iGetTitle: function () {
        return "Build library";
    },
    iLoad: function () {

    },
    iRefresh: function () {
        
    },
    licensesUri: "/api/buildlibrary/licenses",
    modulesUri: "/api/buildlibrary/modules",
    sitecoresUri: "/api/buildlibrary/sitecores",
    getJson: function (uri) {
        var jsonOut;
        $.ajax({
            url: uri,
            async: false,
            dataType: 'json',
            success: function (json) {
                jsonOut = json;
            }
        });
        return jsonOut;
    }
}