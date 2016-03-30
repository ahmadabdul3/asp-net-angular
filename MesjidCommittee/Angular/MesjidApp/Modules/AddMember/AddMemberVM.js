angular.module("mesjidApp")
    .controller('AddMemberVM', AddMemberVM);

AddMemberVM.$inject = ['HttpService', 'HttpUrls', 'CommunityMemberService'];

function AddMemberVM(HttpService, HttpUrls, CommunityMemberService) {
    var vm = this;
    vm.member = CommunityMemberService.getCommunityMember();

    vm.clearMemberData = function () {
        CommunityMemberService.clearCommunityMemberData();
        location.href = '#/Members';
    }

    vm.saveMember = function () {
        HttpService.httpWithParams(HttpUrls.addMemberUrl, HttpService.postMethod, vm.member)
        .then(function (data) {
            if (data.status.indexOf('Error:') > -1) {
                alert(data.message);
            } else {
                vm.clearMemberData();
            }
        }, HttpService.handleHttpError);
    };

}