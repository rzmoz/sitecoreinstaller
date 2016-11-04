var host = {
    getQueryStringAsJson: function () {
        var qs = window.location.search.replace('?', '');
        qs = '{"' + qs.replace(/&/g, '","').replace(/=/g, '":"') + '"}';
        if (qs === '{""}')
            return qs;
        return $.parseJSON(qs);
    }
}

var localDeployments = {
    loadAllInfos: function (dataTableElement) {
        dataTableElement.on("click", "button.del-deployment", function (e) {

            var depName = this.name;

            $.confirm({
                title: "Delete " + depName,
                content: 'Are you sure you want to delete ' + depName + '?',
                confirm: function () {
                    alert('deleting:' + depName);
                    localDeployments.delete(depName);
                }
            });
        });

        localDeployments.getAll(function (json) {
            $.each(json,
                function (index, info) {
                    dataTableElement.children('tbody').append('<tr><td>' + info.name + '</td><td>' + info.sitecore.replace('Sitecore ', '') + '</td><td><button type="button" class="btn btn-danger del-deployment" name="' + info.name + '">Delete</button></td></tr>');
                });



            console.log('Deployments loaded:' + JSON.stringify(json));
        });
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


jQuery.each(["put", "delete"], function (i, method) {
    jQuery[method] = function (url, data, callback) {

        console.log('ajax called:' + method);
        console.log('url:' + url);
        console.log('data:' + JSON.stringify(data));
        return jQuery.ajax({
            url: url,
            type: method,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            data: JSON.stringify(data),
            error: callback,
            success: callback
        });
    };
});