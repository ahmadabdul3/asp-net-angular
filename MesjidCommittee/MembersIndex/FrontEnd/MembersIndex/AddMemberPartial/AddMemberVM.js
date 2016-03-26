angular.module("mesjidApp")
    .controller('AddMemberVM', AddMemberVM);

AddMemberVM.$inject = ['HttpService', 'HttpUrls', 'CommunityMemberService', 'CommunityMembersListService'];

function AddMemberVM(HttpService, HttpUrls, CommunityMemberService, CommunityMembersListService) {
    var vm = this;
    vm.formPristineStatus = true;
    vm.member = CommunityMemberService.getCommunityMember();

    vm.clearMemberData = function () {
        vm.formPristineStatus = true;
        CommunityMemberService.clearCommunityMemberData();
    }

    vm.saveMember = function () {
        HttpService.httpWithParams(HttpUrls.addMemberUrl, HttpService.postMethod, vm.member)
        .then(function (data) {
            if (data.status.indexOf('Error:') > -1) {
                showError(data.message);
                vm.formPristineStatus = false;
            } else {
                vm.formPristineStatus = true;
                CommunityMembersListService.addMemberToList(data.data);
                vm.clearMemberData();
                hideModals();
            }
        }, HttpService.handleHttpError);
    };

}