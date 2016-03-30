angular.module("mesjidApp")
    .controller('mesjidIndexVM', mesjidIndexVM);
/*
validate against phone number
child date of birth
*/
mesjidIndexVM.$inject = ['HttpService', 'HttpUrls', 'ChildService', 'CommunityMemberService', 'MemberChildrenService',
    'CommunityActivitiesService', 'CommunityMembersListService'];

function mesjidIndexVM(HttpService, HttpUrls, ChildService, CommunityMemberService, MemberChildrenService,
    CommunityActivitiesService, CommunityMembersListService) {

    var vm = this;
    vm.searchText = '';
    vm.membersList = CommunityMembersListService.getCommunityMembersList();
    vm.activityName = '';

    //vm.loadDataFromCsv = function () {
    //    HttpService.httpWithParams("/Members/loadCsvData", HttpService.postMethod, null).then(function (data) {
    //        if (data.status.indexOf('Error:') > -1) {
    //            showError(data.message);
    //        } else {
    //            log(data.message);
    //        }
    //    }, HttpService.handleHttpError);
    //};

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