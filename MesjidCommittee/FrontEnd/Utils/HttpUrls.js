angular.module("mesjidApp")
.factory('HttpUrls', HttpUrls);

function HttpUrls() {

    var getMembersListUrl = "/Members/getMembersList";
    var getMemberUrl = '/Members/GetMember';
    var getCommunityActivitiesListUrl = "/Members/GetCommunityActivitiesList";
    var addActivityUrl = '/Members/AddActivity';
    var updateMemberUrl = '/Members/UpdateMember';
    var addChildUrl = 'Members/AddChild';
    var addMemberUrl = "/Members/AddMember";
    var deleteMemberUrl = "/Members/DeleteMember";
    var deleteChildUrl = "/Members/DeleteChild";

    return {
        getMembersListUrl: getMembersListUrl,
        getMemberUrl: getMemberUrl,
        getCommunityActivitiesListUrl: getCommunityActivitiesListUrl,
        addActivityUrl: addActivityUrl,
        updateMemberUrl: updateMemberUrl,
        addChildUrl: addChildUrl,
        addMemberUrl: addMemberUrl,
        deleteMemberUrl: deleteMemberUrl,
        deleteChildUrl: deleteChildUrl
    }
}