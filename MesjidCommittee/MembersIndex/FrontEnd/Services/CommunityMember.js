angular.module("mesjidApp")
.service('CommunityMemberService', CommunityMemberService);

function CommunityMemberService() {

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
    return {
        communityMember: communityMember,
        getCommunityMember: getCommunityMember,
        clearCommunityMemberData: clearCommunityMemberData,
        setCommunityMember: setCommunityMember
    }
}