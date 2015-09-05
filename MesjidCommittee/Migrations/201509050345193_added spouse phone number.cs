namespace MesjidCommittee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedspousephonenumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CommunityMember", "SpousePhoneNumber", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CommunityMember", "SpousePhoneNumber");
        }
    }
}
