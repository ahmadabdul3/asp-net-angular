namespace MesjidCommittee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedphonenumbertodouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CommunityMember", "PhoneNumber", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CommunityMember", "PhoneNumber", c => c.Int(nullable: false));
        }
    }
}
