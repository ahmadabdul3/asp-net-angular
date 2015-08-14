angular.module("mesjidApp")
.service('CommunityActivitiesService', CommunityActivitiesService);

CommunityActivitiesService.$inject = ['HttpService', 'HttpUrls'];
function CommunityActivitiesService(HttpService, HttpUrls) {

    var commActivities = [];

    function getCommunityActivities() {
        return commActivities;
    }
    function updateCommunityActivities() {
        HttpService.basicGet(HttpUrls.getCommunityActivitiesListUrl).then(function (data) {
            if (data.status.indexOf('Error:') > -1) {
                showError(data.message);
            } else {
                for (var i = 0; i < data.data.length; i++) {
                    commActivities.push(data.data[i]);
                }
            }
        }, HttpService.handleHttpError);
    }
    return {
        communityActivities: commActivities,
        getCommunityActivities: getCommunityActivities,
        updateCommunityActivities: updateCommunityActivities
    }
}