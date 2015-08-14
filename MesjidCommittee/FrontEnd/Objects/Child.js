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
    var memberChildren = [];

    function clearChildData() {
        child.FirstName = '';
        child.LastName = '';
        child.CommunityMemberId = 0;
    }
    function setChild(child) {
        child = child;
    }
    function getChild() {
        return child;
    }
    function setMemberChildren(children) {
        for (var i = 0; i < children.length; i++) {
            memberChildren.push(children[i]);
        }
    }
    function getMemberChildren() {
        return memberChildren;
    }
    function addToMemberChildren(child) {
        memberChildren.push(child);
    }
    function clearMemberChildren() {
        memberChildren.length = 0;
    }
    function memberChildrenSetAtIndex(index, data) {
        memberChildren[index] = data;
    }

    return {
        child: child,
        getChild: getChild,
        clearChildData: clearChildData,
        setChild: setChild,
        memberChildren: memberChildren,
        getMemberChildren: getMemberChildren,
        setMemberChildren: setMemberChildren,
        addToMemberChildren: addToMemberChildren,
        clearMemberChildren: clearMemberChildren,
        memberChildrenSetAtIndex: memberChildrenSetAtIndex
    }
}