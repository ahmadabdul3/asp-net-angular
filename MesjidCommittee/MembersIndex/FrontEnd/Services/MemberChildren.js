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
    function getChildAtIndex(index) {
        return memberChildren[index];
    }
    function clearActivitiesForChild(index) {
        memberChildren[index].CommunityActivities.length = 0;
    }
    function setActivitiesForChild(index, data) {
        for (var i = 0; i < data.length; i++) {
            memberChildren[index].CommunityActivities.push(data[i]);
        }
    }
    function updateChildActivities(index, data) {
        clearActivitiesForChild(index);
        setActivitiesForChild(index, data);
    }

    return {
        getMemberChildren: getMemberChildren,
        setMemberChildren: setMemberChildren,
        addToMemberChildren: addToMemberChildren,
        clearMemberChildren: clearMemberChildren,
        memberChildrenSetAtIndex: memberChildrenSetAtIndex,
        getChildAtIndex: getChildAtIndex,
        updateChildActivities: updateChildActivities
    }
}