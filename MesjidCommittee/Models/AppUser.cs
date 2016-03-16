using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MesjidCommittee.Models
{
    public class UserAccount
    {
        public int UserAccountId { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; }

    }
}