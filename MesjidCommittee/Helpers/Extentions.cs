using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using MesjidCommittee.Models;
using MesjidCommittee.ViewModels;
using MesjidCommittee.BaseRepo;

namespace MesjidCommittee.Helpers
{
    public class Extentions
    {
        public DateTime getDobFromAge(int age)
        {
            return new DateTime(DateTime.Now.Year - age, 1, 1);
        }

    }
    public class CsvReader
    {
        public List<MainObjectFromCsvFileInfo> readCsvFile()
        {
            StreamReader reader = new StreamReader(File.OpenRead("C:/Users/Abdo/Desktop/mesjidRegistrationFile.csv"));
            List<MainObjectFromCsvFileInfo> listA = new List<MainObjectFromCsvFileInfo>();
            var ind = 0;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                
                if (ind > 1)
                {
                    //int i = -1;
                    var values = line.Split(',');
                    MainObjectFromCsvFileInfo mObject = new MainObjectFromCsvFileInfo(
                        values[0],
                        values[1],
                        string.IsNullOrWhiteSpace(values[2])? 0000000 : double.Parse(values[2]),
                        values[3],
                        values[4],
                        string.IsNullOrWhiteSpace(values[5])? 0000000 : double.Parse(values[5])
                        );
                    for (int i = 6; i < 16; i += 3)
                    {
                        int index = i - 1;
                        if (!string.IsNullOrWhiteSpace(values[i]))
                        {
                            mObject.Children.Add(new ChildObjectFromCsvFileInfo(
                                values[++index], 
                                string.IsNullOrWhiteSpace(values[index + 1]) ? 0 : int.Parse(values[++index]), 
                                values[++index]));
                        }
                    }
                    listA.Add(mObject);
                }
                ind++;
            }
            reader.Close();
            return listA;
        }

        public CommunityMember convertMainObjectToCommunityMember(MainObjectFromCsvFileInfo mainObject)
        {
            CommunityMember communityMemberVm = new CommunityMember();
            
            if(string.IsNullOrWhiteSpace(mainObject.FatherFirstName) && string.IsNullOrWhiteSpace(mainObject.FatherLastName)) {
                communityMemberVm.FirstName = string.IsNullOrWhiteSpace(mainObject.MotherFirstName) ? "N/A" : mainObject.MotherFirstName;
                communityMemberVm.LastName = string.IsNullOrWhiteSpace(mainObject.MotherLastName) ? "N/A" : mainObject.MotherLastName;
            } else {
                communityMemberVm.FirstName = string.IsNullOrWhiteSpace(mainObject.FatherFirstName)? "N/A" : mainObject.FatherFirstName;
                communityMemberVm.LastName = string.IsNullOrWhiteSpace(mainObject.FatherLastName)? "N/A" : mainObject.FatherLastName;
                communityMemberVm.SpouseFirstName = string.IsNullOrWhiteSpace(mainObject.MotherFirstName)? "N/A" : mainObject.MotherFirstName;
                communityMemberVm.SpouseLastName = string.IsNullOrWhiteSpace(mainObject.MotherLastName)? "N/A" : mainObject.MotherLastName;
            }
            communityMemberVm.PhoneNumber = mainObject.FatherPhone;
            communityMemberVm.SpousePhoneNumber = mainObject.MotherPhone;
            communityMemberVm.Email = "noEmail@example.com";

            if (mainObject.Children != null && mainObject.Children.Count() > 0)
            {
                communityMemberVm.Children = new List<Child>();
                for (int i = 0; i < mainObject.Children.Count(); i++)
                {
                    var mainObjectChild = mainObject.Children[i];
                    Child child = new Child();
                    child.FirstName = mainObjectChild.ChildFirstName;
                    child.LastName = string.IsNullOrWhiteSpace(communityMemberVm.LastName) ? "" : communityMemberVm.LastName;
                    child.Gender = mainObjectChild.Gender;
                    child.DateOfBirth = new Extentions().getDobFromAge(mainObjectChild.Age);
                    communityMemberVm.Children.Add(child);

                }
            }

            return communityMemberVm;
        }

        public void loadCsvDataIntoDb()
        {
            List<MainObjectFromCsvFileInfo> csvDataList = readCsvFile();
            var baseRepo = new BaseRepository();
            foreach (var mainObject in csvDataList)
            {
                var communityMemberObject = convertMainObjectToCommunityMember(mainObject);
                var children = communityMemberObject.Children;
                communityMemberObject.Children = null;
                baseRepo.Add<CommunityMember>(communityMemberObject);
                if (children != null && children.Count() > 0)
                {
                    foreach (var child in children)
                    {
                        child.CommunityMemberId = communityMemberObject.CommunityMemberId;
                        baseRepo.Add<Child>(child);
                    }
                }
            }
        }
    }
    
    public class MainObjectFromCsvFileInfo
    {
        public MainObjectFromCsvFileInfo(string FFirst, string FLast, double FPhone, string MFirst, string MLast, double MPhone)
        {
            Children = new List<ChildObjectFromCsvFileInfo>();
            FatherFirstName = FFirst;
            FatherLastName = FLast;
            FatherPhone = FPhone;
            MotherFirstName = MFirst;
            MotherLastName = MLast;
            MotherPhone = MPhone;
        }
        public string FatherFirstName { get; set; }
        public string FatherLastName { get; set; }
        public double FatherPhone { get; set; }
        public string MotherFirstName { get; set; }
        public string MotherLastName { get; set; }
        public double MotherPhone { get; set; }
        public List<ChildObjectFromCsvFileInfo> Children { get; set; }
    }
    public class ChildObjectFromCsvFileInfo
    {
        public ChildObjectFromCsvFileInfo(string CFirst, int Age, string Gender)
        {
            ChildFirstName = CFirst;
            this.Age = Age;
            this.Gender = Gender;
        }
        public string ChildFirstName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
    public class Gender
    {
        public static readonly string Male = "Male";
        public static readonly string Female = "Female";
    }
}