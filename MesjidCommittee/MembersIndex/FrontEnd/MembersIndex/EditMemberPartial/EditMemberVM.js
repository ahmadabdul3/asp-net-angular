angular.module("mesjidApp")
    .controller('EditMemberVM', EditMemberVM);

EditMemberVM.$inject = ['HttpService', 'HttpUrls', 'CommunityMemberService', 'ChildService', 'MemberChildrenService',
    'CommunityMembersListService', 'CommunityActivitiesService'];

function EditMemberVM(HttpService, HttpUrls, CommunityMemberService, ChildService, MemberChildrenService,
    CommunityMembersListService, CommunityActivitiesService) {
    var vm = this;

    vm.member = CommunityMemberService.getCommunityMember();
    vm.communityMemberActivities = CommunityActivitiesService.getCommunityActivities();
    vm.child = ChildService.getChild();
    vm.activityName = 'Select';
    vm.memberChildren = MemberChildrenService.getMemberChildren();

    vm.clearMemberData = function (clearChildList) {
        CommunityMemberService.clearCommunityMemberData();
        ChildService.clearAllChildData();
        MemberChildrenService.clearMemberChildren();
    };

    vm.updateMember = function () {
        HttpService.httpWithParams(HttpUrls.updateMemberUrl, HttpService.postMethod, vm.member)
        .then(function (data) {
            if (data.status.indexOf('Error:') > -1) {
                showError(data.message);
            } else {
                CommunityMembersListService.setMemberAtIndex(CommunityMembersListService.getMembersListIndex(), data.data);
                vm.clearMemberData();
                hideModals();
            }
        }, HttpService.handleHttpError);
    };
    vm.addChild = function () {
        HttpService.httpWithParams(HttpUrls.addChildUrl, HttpService.postMethod, vm.child)
            .then(function (data) {
                if (data.status.indexOf('Error:') > -1) {
                    showError(data.message);
                } else {
                    MemberChildrenService.addToMemberChildren(data.data);
                    ChildService.clearChildNameData();
                }
            }, HttpService.handleHttpError);
    };
    vm.addActivityForChild = function (childId, indexInArray) {
        HttpService.httpWithParams(HttpUrls.addActivityUrl, HttpService.postMethod, { Id: childId, ActivityName: vm.activityName })
            .then(function (data) {
                if (data.status.indexOf('Error:') > -1) {
                    showError(data.message);
                } else {
                    MemberChildrenService.memberChildrenSetAtIndex(indexInArray, data.data);
                    vm.resetNewActivityValue();
                }
            }, HttpService.handleHttpError);
    };
    vm.deleteChild = function (id) {
        HttpService.httpWithParams(HttpUrls.deleteChildUrl, HttpService.postMethod, { id: id })
        .then(function (data) {
            if (data.status.indexOf('Error:') > -1) {
                showError(data.message);
            } else {
                MemberChildrenService.clearMemberChildren();
                MemberChildrenService.setMemberChildren(data.data);
            }
        }, HttpService.handleHttpError);
    };
    vm.deleteActivity = function (id, childIndex) {
        HttpService.httpWithParams(HttpUrls.deleteActivityUrl, HttpService.postMethod, { id: id })
        .then(function (data) {
            if (data.status.indexOf('Error:') > -1) {
                showError(data.message);
            } else {
                MemberChildrenService.updateChildActivities(childIndex, data.data);
            }
        }, HttpService.handleHttpError);
    };
    vm.resetNewActivityValue = function () {
        vm.activityName = 'Select';
    };

}