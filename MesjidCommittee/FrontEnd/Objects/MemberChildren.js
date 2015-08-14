angular.module("mesjidApp")
.service('MemberChildrenService', MemberChildrenService);

function MemberChildrenService() {

    var memberChildren = [];

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
        getMemberChildren: getMemberChildren,
        setMemberChildren: setMemberChildren,
        addToMemberChildren: addToMemberChildren,
        clearMemberChildren: clearMemberChildren,
        memberChildrenSetAtIndex: memberChildrenSetAtIndex
    }
}