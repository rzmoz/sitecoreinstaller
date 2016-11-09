var deploymentsList = {
    refresh: function (list) {
        var currentDeployments = [];
        var triggers = [];
        host.triggerAndAutoRefresh(function () {
            var updatedDeployments = deployments.localDeployments;

            $.each(currentDeployments, function (index, curDep) {
                var curDepId = deploymentsFormat.getDepPanelId(curDep);

                var shouldBeDeleted = updatedDeployments.find(ud => deploymentsFormat.getDepPanelId(ud) === curDepId) === undefined;

                if (shouldBeDeleted) {
                    var triggerIndex = triggers.map(t=>t.name).indexOf(curDep.name);
                    var triggerId = triggers[triggerIndex].id;
                    window.clearInterval(triggerId);
                    $('#' + curDepId).remove();
                    console.log(curDepId + ' removed');
                }
            });

            //add new
            $.each(updatedDeployments, function (index, upDep) {
                var upDepId = deploymentsFormat.getDepPanelId(upDep);
                var shouldBeAdded = currentDeployments.find(cd=> deploymentsFormat.getDepPanelId(cd) === upDepId) === undefined;
                if (shouldBeAdded) {
                    var existingPanels = list.children('div.dep-info-panel');
                    var panelHtml = deploymentsFormat.getDepPanelHtml(index, upDep, list);

                    var lastId = existingPanels.last().attr('id');

                    //if list is empty or if new dep is last in list
                    if (existingPanels.length === 0 || lastId.localeCompare(upDepId) < 0) {
                        list.append(panelHtml);
                        console.log(upDepId + ' was appended');
                    } else {
                        $.each(existingPanels,
                            function (ind, pnl) {
                                var pnlId = $(pnl).attr('id');
                                if (upDepId.localeCompare(pnlId) > 0)
                                    return true;
                                console.log('adding ' + upDep + ' before ' + pnlId);
                                $(pnl).before(panelHtml);
                                return false;
                            });
                    }
                    triggers.push({
                        name: upDep.name,
                        id: host.triggerAndAutoRefresh(function () {
                            deployments.getLocal(upDep.name,
                            (info) => deploymentsFormat.refreshInfoPanel(info));
                        })
                    });
                }
            });
            currentDeployments = updatedDeployments;
        }, 2000);
    }
};