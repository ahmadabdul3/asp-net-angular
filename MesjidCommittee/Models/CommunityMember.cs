using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MesjidCommittee.Models

{
    public class CommunityEntity
    {

    }
    public class CommunityMember
    {

        public int CommunityMemberId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Required")]
        public string LastName { get; set; }
        public string SpouseFirstName { get; set; }
        public string SpouseLastName { get; set; }
        [Required(ErrorMessage = "Required")]
        public int? PhoneNumber {get; set;}
        [Required(ErrorMessage = "Required")]
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? ZipCode { get; set; }
        public int? Age { get; set; }
        public int? NumberOfIndividualsInFamily { get; set; }
        public int? NumberOfChildren { get; set; }
        public virtual ICollection<Child> Children { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
            set
            {

            }
        }

    }
    public class CommunityActivity
    {
        public int CommunityActivityId { get; set; }
        public string ActivityName { get; set; }

        public int ChildId { get; set; }
        [ForeignKey("ChildId")]
        public Child Child { get; set; }
    }
    public class Child
    {
        public int ChildId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<CommunityActivity> CommunityActivities { get; set; }

        public int CommunityMemberId { get; set; }
        [ForeignKey("CommunityMemberId")]
        public CommunityMember CommunityMember { get; set; }
    }
}