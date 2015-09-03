angular.module("mesjidApp")
    .controller('AddMemberVM', AddMemberVM);

AddMemberVM.$inject = ['HttpService', 'HttpUrls', 'CommunityMemberService', 'CommunityMembersListService'];

function AddMemberVM(HttpService, HttpUrls, CommunityMemberService, CommunityMembersListService) {
    var vm = this;

    vm.member = CommunityMemberService.getCommunityMember();

    vm.clearMemberData = function () {
        CommunityMemberService.clearCommunityMemberData();
    }

    vm.saveMember = function () {
        HttpService.httpWithParams(HttpUrls.addMemberUrl, HttpService.postMethod, vm.member)
        .then(function (data) {
            if (data.status.indexOf('Error:') > -1) {
                showError(data.message);
            } else {
                CommunityMembersListService.addMemberToList(data.data);
                vm.clearMemberData();
                hideModals();
            }
        }, HttpService.handleHttpError);
    };

}