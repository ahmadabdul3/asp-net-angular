using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MesjidCommittee.Models;
using MesjidCommittee.ViewModels;
using MesjidCommittee.DAL;
using MesjidCommittee.Helpers;

namespace MesjidCommittee.Repositories
{
    public class MembersRepo
    {
        private MesjidDbContext db = new MesjidDbContext();

        public ServerResponse<string, string, List<CommunityMemberVm>> getMembersList()
        {
            List<CommunityMemberVm> cmvmList = new List<CommunityMemberVm>();
            try
            {
                var members = db.Member.OrderBy(x => x.FirstName).ToList();
                foreach (var m in members)
                {
                    CommunityMemberVm cmvm = new CommunityMemberVm(m, false);
                    cmvmList.Add(cmvm);
                }

                return new ServerResponse<string, string, List<CommunityMemberVm>>(ErrorMessages.SuccessString, null, cmvmList);
            }
            catch (Exception e)
            {
                return new ServerResponse<string, string, List<CommunityMemberVm>>(ErrorMessages.ErrorString, ErrorMessages.ErrMsg_Generic, null);
            }

        }

        public ServerResponse<string, string, CommunityMemberVm> AddMember(CommunityMember cMemb)
        {
            try
            {
                Add<CommunityMember>(cMemb);
                CommunityMemberVm cmvm = new CommunityMemberVm(cMemb, false);
                return new ServerResponse<string, string, CommunityMemberVm>(ErrorMessages.SuccessString, null, cmvm);
            }
            catch (Exception e)
            {
                return new ServerResponse<string, string, CommunityMemberVm>(ErrorMessages.ErrorString, ErrorMessages.ErrMsg_Generic, null);
            }
        }

        public ServerResponse<string, string, CommunityMemberVm> GetMember(int id)
        {
            try
            {
                CommunityMemberVm cmvm = new CommunityMemberVm(db.Member.Find(id), true);
                return new ServerResponse<string, string, CommunityMemberVm>(ErrorMessages.SuccessString, null, cmvm);
            }
            catch (Exception e)
            {
                return new ServerResponse<string, string, CommunityMemberVm>(ErrorMessages.ErrorString, ErrorMessages.ErrMsg_Generic, null);
            }
        }

        public ServerResponse<string, string, CommunityMemberVm> UpdateMember(CommunityMember model)
        {
                try
                {
                    Update<CommunityMember>(model);
                    CommunityMemberVm cmvm = new CommunityMemberVm(model, false);
                    return new ServerResponse<string, string, CommunityMemberVm>(ErrorMessages.SuccessString, null, cmvm);
                }
                catch (Exception e)
                {
                    return new ServerResponse<string, string, CommunityMemberVm>(ErrorMessages.ErrorString, ErrorMessages.ErrMsg_Generic, null);
                }
        }

        public ServerResponse<string, string, Child> AddChild(Child child)
        {
                try
                {
                    Child c = new Child() { FirstName = child.FirstName, LastName = child.LastName, CommunityMemberId = child.CommunityMemberId };
                    Add<Child>(c);
                    return new ServerResponse<string, string, Child>(ErrorMessages.SuccessString, null, c);
                }
                catch (Exception e)
                {
                    return new ServerResponse<string, string, Child>(ErrorMessages.ErrorString, ErrorMessages.ErrMsg_Generic, null);
                }
        }

        public ServerResponse<string, string, ChildVm> AddActivity(int Id, string ActivityName)
        {
            try
            {
                CommunityActivity activity = new CommunityActivity() { ActivityName = ActivityName, ChildId = Id };
                Add<CommunityActivity>(activity);
                ChildVm cvm = new ChildVm(db.Child.Find(Id), true);
                return new ServerResponse<string, string, ChildVm>(ErrorMessages.SuccessString, null, cvm);
            }
            catch (Exception e)
            {
                return new ServerResponse<string, string, ChildVm>(ErrorMessages.ErrorString, ErrorMessages.ErrMsg_Generic, null);
            }
        }

        public ServerResponse<string, string, string[]> GetCommunityActivitiesList()
        {
            try
            {
                return new ServerResponse<string, string, string[]>(ErrorMessages.SuccessString, null, Global.CommunityActivitiesList);
            }
            catch (Exception e)
            {
                return new ServerResponse<string, string, string[]>(ErrorMessages.ErrorString, ErrorMessages.ErrMsg_Generic, null);
            }
        }

        public void DeleteMember(int id)
        {
            CommunityMember member = db.Member.Find(id);
            if (member != null)
            {
                List<Child> children = db.Child.Where(x => x.CommunityMemberId == id).ToList();
                if (children != null && children.Count() > 0)
                {
                    foreach (var child in children)
                    {
                        List<CommunityActivity> activities = db.Activity.Where(x => x.ChildId == child.ChildId).ToList();
                        if (activities != null && activities.Count() > 0)
                        {
                            foreach (var activity in activities)
                            {
                                Remove<CommunityActivity>(activity);
                            }
                        }
                        Remove<Child>(child);
                    }
                }
                Remove<CommunityMember>(member);
            }
        }

        public void Add<T>(T newItem) where T : class
        {
            db.Set<T>().Add(newItem);
            db.SaveChanges();
        }
        public void Update<T>(T item) where T : class
        {
            db.Set<T>().Attach(item);
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Remove<T>(T newItem) where T : class
        {
            db.Set<T>().Remove(newItem);
            db.SaveChanges();
        }
    }
}