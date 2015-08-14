angular.module("mesjidApp")
.service('ChildService', ChildService);

function ChildService() {

    var child = {
        CommunityMemberId : 0,
        FirstName : '',
        LastName: '',
        setCommunityMemberId: function (id) {
            this.CommunityMemberId = id;
        }
    };

    function clearChildData() {
        child.FirstName = '';
        child.LastName = '';
        child.CommunityMemberId = 0;
    }
    function setChild(childIn) {
        child.FirstName = childIn.FirstName;
        child.LastName = childIn.LastName;
        child.CommunityMemberId = childIn.CommunityMemberId;
    }
    function getChild() {
        return child;
    }

    return {
        getChild: getChild,
        clearChildData: clearChildData,
        setChild: setChild
    }
}