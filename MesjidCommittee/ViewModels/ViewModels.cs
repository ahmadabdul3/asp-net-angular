using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MesjidCommittee.Models;


namespace MesjidCommittee.ViewModels
{
    public class ViewModels
    {
    }
    public class CommunityMemberVm
    {
        public CommunityMemberVm() {

        }
        public CommunityMemberVm(CommunityMember cm, bool getNestedListData)
        {
            CommunityMemberId = cm.CommunityMemberId;
            FirstName = cm.FirstName;
            LastName = cm.LastName;
            SpouseFirstName = cm.SpouseFirstName;
            SpouseLastName = cm.SpouseLastName;
            PhoneNumber = cm.PhoneNumber;
            Email = cm.Email;
            Gender = cm.Gender;
            DateOfBirth = cm.DateOfBirth;
            Street1 = cm.Street1;
            Street2 = cm.Street2;
            City = cm.City;
            State = cm.State;
            ZipCode = cm.ZipCode;
            Age = cm.Age;
            NumberOfIndividualsInFamily = cm.NumberOfIndividualsInFamily;
            NumberOfChildren = cm.NumberOfChildren;
            FullName = cm.FullName;
            if (getNestedListData)
            {
                this.Children = new List<ChildVm>();
                foreach (var child in cm.Children)
                {
                    ChildVm cvm = new ChildVm(child, true);
                    this.Children.Add(cvm);
                }
            }
        }
        public int CommunityMemberId { get; set; }
        [Display(Name = "First")]
        [Required(ErrorMessage = "Required")]
        public string FirstName { get; set; }
        [Display(Name = "Last")]
        [Required(ErrorMessage = "Required")]
        public string LastName { get; set; }

        public string SpouseFirstName { get; set; }
        public string SpouseLastName { get; set; }
        [Display(Name = "Phone")]
        public int? PhoneNumber { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string Gender { get; set; }
        [Display(Name = "Date of birth")]
        public DateTime? DateOfBirth { get; set; }
        [Display(Name = "Street 1")]
        public string Street1 { get; set; }
        [Display(Name = "Street 2")]
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zip")]
        public int? ZipCode { get; set; }
        public int? Age { get; set; }
        public int? NumberOfIndividualsInFamily { get; set; }
        public int? NumberOfChildren { get; set; }
        public List<ChildVm> Children { get; set; }
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
        public string SpouseFullName
        {
            get
            {
                return SpouseFirstName + " " + SpouseLastName;
            }
            set { }
        }

    }
    public class CommunityActivityVm
    {
        public CommunityActivityVm(CommunityActivity ca)
        {
            this.CommunityActivityId = ca.CommunityActivityId;
            this.ActivityName = ca.ActivityName;
            this.ChildId = ca.ChildId;
        }
        public int CommunityActivityId { get; set; }
        public string ActivityName { get; set; }
        public int ChildId { get; set; }
    }
    public class ChildVm
    {
        public ChildVm(Child child, bool getNestedListData)
        {
            this.ChildId = child.ChildId;
            this.FirstName = child.FirstName;
            this.LastName = child.LastName;
            CommunityActivities = new List<CommunityActivityVm>();
            if (getNestedListData)
            {
                foreach (var activity in child.CommunityActivities)
                {
                    CommunityActivityVm cavm = new CommunityActivityVm(activity);
                    CommunityActivities.Add(cavm);
                }
            }
        }
        public int ChildId { get; set; }

        public int CoumminityMemberId { get; set; }

        [Display(Name = "First")]
        public string FirstName { get; set; }

        [Display(Name = "Last")]
        public string LastName { get; set; }

        public List<CommunityActivityVm> CommunityActivities { get; set; }
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
}