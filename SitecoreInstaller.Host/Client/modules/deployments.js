(function ($) {
    $.fn.deploymentsList = function () {

        var currentDeployments = [];
        var list = this;

        host.triggerAndAutoRefresh(function () {
            var updatedDeployments = deployments.localDeployments;

            $.each(currentDeployments, function (index, curDep) {
                var curDepId = deploymentsFormat.getDepPanelId(curDep);

                var shouldBeDeleted = updatedDeployments.find(ud => deploymentsFormat.getDepPanelId(ud) === curDepId) === undefined;

                if (shouldBeDeleted) {
                    console.log(curDepId + ' removed');
                    $('#' + curDepId).remove();
                }
            });

            //add new
            $.each(updatedDeployments, function (index, upDep) {
                var upDepId = deploymentsFormat.getDepPanelId(upDep);
                var shouldBeAdded = currentDeployments.find(cd=> deploymentsFormat.getDepPanelId(cd) === upDepId) === undefined;
                if (shouldBeAdded) {
                    var existingPanels = list.children('div.dep-info-panel');

                    var lastId = existingPanels.last().attr('id');

                    //if list is empty or if new dep is last in list
                    if (existingPanels.length === 0 || lastId.localeCompare(upDepId) < 0) {
                        list.append(deploymentsFormat.getDepPanel(index, upDep, list));
                        console.log(upDepId + ' was appended');
                    } else {
                        $.each(existingPanels,
                                function (ind, pnl) {
                                    var pnlId = $(pnl).attr('id');
                                    if (upDepId.localeCompare(pnlId) > 0)
                                        return true;
                                    console.log('adding ' + upDep + ' before ' + pnlId);
                                    $(pnl).before(deploymentsFormat.getDepPanel(index, upDep, list));
                                    return false;

                                });
                    }
                }
            });

            currentDeployments = updatedDeployments;

        }, 2000);
        return this;
    };
}(jQuery));

(function ($) {
    $.fn.localDeploymentsCount = function (interval) {
        var $this = this;
        host.triggerAndAutoRefresh(function () {
            $this.html(deployments.localDeployments.length);
        }, interval);
        return this;
    };
}(jQuery));

var deployments = {
    localDeployments: [],
    init: function (callback) {
        deployments.getAllLocal(callback);
        host.triggerAndAutoRefresh(deployments.getAllLocal);
    },
    getAllLocal: function (callback) {
        var uri = "/api/local/deployments";
        $.getJSON(uri,
            function (json) {
                deployments.localDeployments = json;
                if (callback !== undefined)
                    callback();
            });
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
