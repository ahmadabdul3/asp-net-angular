angular.module("mesjidApp")
.factory('HttpUrls', HttpUrls);

function HttpUrls() {

    return {
        getMembersListUrl: "/Members/getMembersList",
        getMemberUrl: '/Members/GetMember',
        getCommunityActivitiesListUrl: "/Members/GetCommunityActivitiesList",
        addActivityUrl: '/Members/AddActivity',
        deleteActivityUrl: '/Members/DeleteActivity',
        updateMemberUrl: '/Members/UpdateMember',
        addChildUrl: 'Members/AddChild',
        addMemberUrl: "/Members/AddMember",
        deleteMemberUrl: "/Members/DeleteMember",
        deleteChildUrl: "/Members/DeleteChild"
    }
}