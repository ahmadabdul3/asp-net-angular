using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MesjidCommittee.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MesjidCommittee.DAL
{

   
    public class MesjidDbContext : DbContext
    {
        public MesjidDbContext()
            : base("MesjidDbContext5")
        {
        }
        public DbSet<CommunityMember> Member { get; set; }
        public DbSet<CommunityActivity> Activity { get; set; }
        public DbSet<Child> Child { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}