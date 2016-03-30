angular.module("mesjidApp")
.service('CommunityMembersListService', CommunityMembersListService);

CommunityMembersListService.$inject = ['HttpService', 'HttpUrls'];
function CommunityMembersListService(HttpService, HttpUrls) {

    var communityMembersList = [];
    var membersListIndex = [];

    function getMembersFromServer() {
        HttpService.basicGet(HttpUrls.getMembersListUrl).then(function (data) {
            if (data.status.indexOf('Error:') > -1) {
                return data.message;
            } else {
                clearMembersList();
                setCommunityMembersList1(data.data);
                //CommunityActivitiesService.updateCommunityActivities();
            }
        }, HttpService.handleHttpError);
    }
    function addMemberToList(member) {
        communityMembersList.push(member);
    }
    function setMemberAtIndex(index, member) {
        communityMembersList[index] = member;
    }
    var getCommunityMembersList = function () {
        getMembersFromServer();
        return communityMembersList;
    };
    function setCommunityMembersList1(commMemsList) {
        for (var i = 0; i < commMemsList.length; i++) {
            communityMembersList.push(commMemsList[i]);
        }
    }
    function clearMembersList() {
        communityMembersList.length = 0;
    }
    function getMembersListIndex() {
        return membersListIndex;
    }
    function setMembersListIndex(index) {
        membersListIndex = index;
    }
    
    return {
        communityMembersList: communityMembersList,
        getCommunityMembersList: getCommunityMembersList,
        setCommunityMembersList: setCommunityMembersList1,
        addMemberToList: addMemberToList,
        setMemberAtIndex: setMemberAtIndex,
        clearCommunityMembersList: clearMembersList,
        getMembersListIndex: getMembersListIndex,
        setMembersListIndex: setMembersListIndex
    }
}