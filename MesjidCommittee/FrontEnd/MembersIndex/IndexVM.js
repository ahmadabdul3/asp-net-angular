angular.module("mesjidApp", [])
    .controller('mesjidIndexVM', mesjidIndexVM);

mesjidIndexVM.$inject = ['HttpService', 'HttpUrls', 'ChildService', 'CommunityMemberService', 'MemberChildrenService',
    'CommunityActivitiesService', 'CommunityMembersListService'];

function mesjidIndexVM(HttpService, HttpUrls, ChildService, CommunityMemberService, MemberChildrenService,
    CommunityActivitiesService, CommunityMembersListService) {

    var vm = this;
    vm.searchText = '';
    vm.membersList = CommunityMembersListService.getCommunityMembersList();
    vm.activityName = '';

    vm.getMembersList = function () {
        HttpService.basicGet(HttpUrls.getMembersListUrl).then(function (data) {
            if (data.status.indexOf('Error:') > -1) {
                showError(data.message);
            } else {
                CommunityMembersListService.setCommunityMembersList(data.data);
                CommunityActivitiesService.updateCommunityActivities();
            }
        }, HttpService.handleHttpError);
    };
    
    vm.prepareMemberForEdit = function (memberId, indexInArray) {
        HttpService.httpWithParams(HttpUrls.getMemberUrl, HttpService.getMethod, {id: memberId})
        .then(function (data) {
            if (data.status.indexOf('Error:') > -1) {
                showError(data.message);
            } else {
                CommunityMembersListService.setMembersListIndex(indexInArray);
                CommunityMemberService.setCommunityMember(data.data);
                MemberChildrenService.setMemberChildren(data.data.Children);
                ChildService.child.setCommunityMemberId(memberId);
                showEditMemberPartial();
            }
        }, HttpService.handleHttpError);
    }

    vm.deleteMember = function (memberId) {
        HttpService.httpWithParams(HttpUrls.deleteMemberUrl, HttpService.postMethod, { id: memberId })
        .then(function (data) {
            if (data.status.indexOf('Error:') > -1) {
                showError(data.message);
            } else {
                CommunityMembersListService.clearCommunityMembersList();
                CommunityMembersListService.setCommunityMembersList(data.data);
            }
        }, HttpService.handleHttpError);
    }

    vm.showAddMemberPartial = function () {
        showAddModal();
        showModalBg();
    };
    function showEditMemberPartial() {
        showEditModal();
        showModalBg();
    }
    function log(message) {
        console.log(message);
    }

}