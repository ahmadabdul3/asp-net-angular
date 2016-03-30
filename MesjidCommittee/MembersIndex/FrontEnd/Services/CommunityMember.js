angular.module("mesjidApp")
.service('CommunityMemberService', CommunityMemberService);

CommunityMemberService.$inject = ['HttpService', 'HttpUrls', 'MemberChildrenService', 'ChildService']
function CommunityMemberService(HttpService, HttpUrls, MemberChildrenService, ChildService) {

    var communityMember =  {
        CommunityMemberId : 0,
        FirstName : '',
        LastName : '',
        SpouseFirstName : '',
        SpouseLastName : '',
        PhoneNumber : '',
        Email : '',
        Gender : '',
        DateOfBirth : '',
        Street1 : '',
        Street2 : '',
        city : '',
        State : '',
        ZipCode : '',
        Age : ''
    };

    function clearCommunityMemberData() {
        communityMember.CommunityMemberId = 0;
        communityMember.FirstName = null;
        communityMember.LastName = null;
        communityMember.SpouseFirstName = null;
        communityMember.SpouseLastName = null;
        communityMember.PhoneNumber = null;
        communityMember.Email = null;
        communityMember.Gender = null;
        communityMember.DateOfBirth = null;
        communityMember.Street1 = null;
        communityMember.Street2 = null;
        communityMember.City = null;
        communityMember.State = null;
        communityMember.ZipCode = null;
        communityMember.Age = null;
    };

    function setCommunityMember(member) {
        communityMember.CommunityMemberId = member.CommunityMemberId;
        communityMember.FirstName = member.FirstName;
        communityMember.LastName = member.LastName;
        communityMember.SpouseFirstName = member.SpouseFirstName;
        communityMember.SpouseLastName = member.SpouseLastName;
        communityMember.PhoneNumber = member.PhoneNumber;
        communityMember.Email = member.Email;
        communityMember.Gender = member.Gender;
        communityMember.DateOfBirth = member.DateOfBirth;
        communityMember.Street1 = member.Street1;
        communityMember.Street2 = member.Street2;
        communityMember.City = member.City;
        communityMember.State = member.State;
        communityMember.ZipCode = member.ZipCode;
        communityMember.Age = member.Age;
    }
    function getCommunityMember() {
        return communityMember;
    }
    function getCommunityMemberById(id) {
        HttpService.httpWithParams(HttpUrls.getMemberUrl, HttpService.getMethod, { id: id })
        .then(function (data) {
            if (data.status.indexOf('Error:') > -1) {
                return data.message;
            } else {
                setCommunityMember(data.data);
                MemberChildrenService.setMemberChildren(data.data.Children);
                ChildService.child.setCommunityMemberId(id);
            }
        }, HttpService.handleHttpError);
    }
    return {
        communityMember: communityMember,
        getCommunityMember: getCommunityMember,
        clearCommunityMemberData: clearCommunityMemberData,
        setCommunityMember: setCommunityMember,
        getCommunityMemberById: getCommunityMemberById
    }
}