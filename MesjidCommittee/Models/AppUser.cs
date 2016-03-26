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
        [Required]
        public string Username { get; set; }
        [Required]
        public string UserPassword { get; set; }
        
        public string ReturnUrl { get; set; }

    }
}