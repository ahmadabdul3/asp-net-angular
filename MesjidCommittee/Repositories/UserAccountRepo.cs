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
using System.Security.Claims;

namespace MesjidCommittee.Repositories
{
    public class UserAccountRepo
    {
        private BaseRepository baseRepo = new BaseRepository(new MesjidDbContext());

        public ServerResponse<string, string, string> validateLogin(UserAccount userAccount, HttpRequestBase request)
        {
            UserAccount existingAccount = null;
            ServerResponse<string, string, string> response =
                new ServerResponse<string, string, string>(ErrorMessages.SuccessString, "", "");
     
            var userAccounts = baseRepo.getDb().UserAccount.Where(x => x.Username == userAccount.Username);

            if (userAccounts != null && userAccounts.Count() > 0)
            {
                existingAccount = userAccounts.First();
                if (existingAccount.UserPassword != userAccount.UserPassword)
                {
                    response.status = ErrorMessages.ErrorString;
                    response.message = "Incorrect Password. Please confirm you spelled your Password correctly";
                } else
                {
                    createOwinIdentity(userAccount, request);
                }
            }
            else
            {
                response.status = ErrorMessages.ErrorString;
                response.message = "Username does not exist.";
            }
            return response;
        }

        public ServerResponse<string, string, string> validateRegister(UserAccount userAccount, HttpRequestBase request)
        {
            ServerResponse<string, string, string> response = 
                new ServerResponse<string, string, string>(ErrorMessages.SuccessString, "", "");
            var userAccounts = baseRepo.getDb().UserAccount.Where(x => x.Username == userAccount.Username);

            if (userAccounts != null && userAccounts.Count() > 0)
            {
                response.status = ErrorMessages.ErrorString;
                response.message = "A user account with that name already exists. Please choose a different Username.";
            }
            else
            {
                try
                {
                    baseRepo.Add<UserAccount>(userAccount);
                    createOwinIdentity(userAccount, request);
                }
                catch (Exception e)
                {
                    response.status = ErrorMessages.ErrorString;
                    response.message = "There was an error with your account creation. Please try again.";
                }
            }
            return response;
        }

        public void createOwinIdentity(UserAccount user, HttpRequestBase request)
        {
            var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, user.Username),
            },
            "ApplicationCookie");

            var ctx = request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignIn(identity);
        }
    }
}
