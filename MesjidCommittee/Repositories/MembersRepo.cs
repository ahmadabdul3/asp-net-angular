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
using MesjidCommittee.Helpers.ServerResponse;
using MesjidCommittee.BaseRepo;

namespace MesjidCommittee.Repositories
{
    public class MembersRepo
    {
        private BaseRepository baseRepo = new BaseRepository(new MesjidDbContext());

        public ServerResponse<string, string, List<CommunityMemberVm>> getMembersList()
        {
            List<CommunityMemberVm> cmvmList = new List<CommunityMemberVm>();
           try
           {
                var members = baseRepo.getDb().Member.OrderBy(x => x.FirstName);
                if (members != null && members.Count() > 0)
                {
                    foreach (var m in members)
                    {
                        CommunityMemberVm cmvm = new CommunityMemberVm(m, false);
                        cmvmList.Add(cmvm);
                    }
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
                baseRepo.Add<CommunityMember>(cMemb);
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
                CommunityMemberVm cmvm = new CommunityMemberVm(baseRepo.getDb().Member.Find(id), true);
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
                    baseRepo.Update<CommunityMember>(model);
                    CommunityMemberVm cmvm = new CommunityMemberVm(model, false);
                    return new ServerResponse<string, string, CommunityMemberVm>(ErrorMessages.SuccessString, null, cmvm);
                }
                catch (Exception e)
                {
                    return new ServerResponse<string, string, CommunityMemberVm>(ErrorMessages.ErrorString, ErrorMessages.ErrMsg_Generic, null);
                }
        }

        public ServerResponse<string, string, ChildVm> AddChild(Child child)
        {
                try
                {
                    Child c = new Child() { FirstName = child.FirstName, LastName = child.LastName, 
                        DateOfBirth = child.DateOfBirth, CommunityMemberId = child.CommunityMemberId };
                    baseRepo.Add<Child>(c);
                    return new ServerResponse<string, string, ChildVm>(ErrorMessages.SuccessString, null, new ChildVm(c, true));
                }
                catch (Exception e)
                {
                    return new ServerResponse<string, string, ChildVm>(ErrorMessages.ErrorString, ErrorMessages.ErrMsg_Generic, null);
                }
        }

        public ServerResponse<string, string, ChildVm> AddActivity(int Id, string ActivityName)
        {
            try
            {
                CommunityActivity activity = new CommunityActivity() { ActivityName = ActivityName, ChildId = Id };
                baseRepo.Add<CommunityActivity>(activity);
                ChildVm cvm = new ChildVm(baseRepo.getDb().Child.Find(Id), true);
                return new ServerResponse<string, string, ChildVm>(ErrorMessages.SuccessString, null, cvm);
            }
            catch (Exception e)
            {
                return new ServerResponse<string, string, ChildVm>(ErrorMessages.ErrorString, ErrorMessages.ErrMsg_Generic, null);
            }
        }
        public ServerResponse<string, string, List<ChildVm>> getChildrenList(int id)
        {
            try
            {
                var childrenList = baseRepo.getDb().Child.Where(x => x.CommunityMemberId == id);
                List<ChildVm> childrenVmList = new List<ChildVm>();
                if (childrenList != null && childrenList.Count() > 0)
                {
                    foreach (var child in childrenList)
                    {
                        childrenVmList.Add(new ChildVm(child, true));
                    }
                }
                return new ServerResponse<string, string, List<ChildVm>>(ErrorMessages.SuccessString, "", childrenVmList);
            }
            catch (Exception e)
            {
                return new ServerResponse<string, string, List<ChildVm>>(ErrorMessages.ErrorString, ErrorMessages.ErrMsg_Generic, null);
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

        public ServerResponse<string, string, List<CommunityMemberVm>> DeleteMember(int id)
        {
            try
            {
                CommunityMember member = baseRepo.getDb().Member.Find(id);
                if (member != null)
                {
                    List<Child> children = baseRepo.getDb().Child.Where(x => x.CommunityMemberId == id).ToList();
                    if (children != null && children.Count() > 0)
                    {
                        foreach (var child in children)
                        {
                            List<CommunityActivity> activities = baseRepo.getDb().Activity.Where(x => x.ChildId == child.ChildId).ToList();
                            if (activities != null && activities.Count() > 0)
                            {
                                foreach (var activity in activities)
                                {
                                    baseRepo.Remove<CommunityActivity>(activity);
                                }
                            }
                            baseRepo.Remove<Child>(child);
                        }
                    }
                    baseRepo.Remove<CommunityMember>(member);
                }
                return getMembersList();
            }
            catch (Exception e)
            {
                return new ServerResponse<string, string, List<CommunityMemberVm>>(ErrorMessages.ErrorString, ErrorMessages.ErrMsg_Generic, null);
            }
        }

        public ServerResponse<string, string, List<CommunityActivityVm>> DeleteActivity(int id)
        {
            try
            {
                int childId = baseRepo.getDb().Activity.Find(id).ChildId;
                baseRepo.Remove<CommunityActivity>(baseRepo.getDb().Activity.Find(id));
                return getChildActivityList(childId);
            }
            catch (Exception e)
            {
                return new ServerResponse<string, string, List<CommunityActivityVm>>(ErrorMessages.ErrorString, ErrorMessages.ErrMsg_Generic, null);
            }
        }
        public ServerResponse<string, string, List<CommunityActivityVm>> getChildActivityList(int id)
        {
            try
            {
                var childActivityList = baseRepo.getDb().Activity.Where(x => x.ChildId == id);
                List<CommunityActivityVm> comActList = new List<CommunityActivityVm>();
                if (childActivityList != null && childActivityList.Count() > 0)
                {
                    foreach (var activity in childActivityList)
                    {
                        comActList.Add(new CommunityActivityVm(activity));
                    }
                }
                return new ServerResponse<string,string,List<CommunityActivityVm>>(ErrorMessages.SuccessString, "", comActList);
            } 
            catch (Exception e) 
            {
                return new ServerResponse<string, string, List<CommunityActivityVm>>(ErrorMessages.ErrorString, ErrorMessages.ErrMsg_Generic, null);
            }
        }
        public ServerResponse<string, string, List<ChildVm>> DeleteChild(int id)
        {
            try
            {
                Child child = baseRepo.getDb().Child.Find(id);
                var childMemberId = child.CommunityMemberId;
                if (child != null)
                {
                    List<CommunityActivity> activities = baseRepo.getDb().Activity.Where(x => x.ChildId == child.ChildId).ToList();
                    if (activities != null && activities.Count() > 0)
                    {
                        foreach (var activity in activities)
                        {
                            baseRepo.Remove<CommunityActivity>(activity);
                        }
                    }
                    baseRepo.Remove<Child>(child);
                }
                return getChildrenList(childMemberId);
            }
            catch (Exception e)
            {
                return new ServerResponse<string, string, List<ChildVm>>(ErrorMessages.ErrorString, ErrorMessages.ErrMsg_Generic, null);
            }
        }

    }
}