namespace MesjidCommitteeOld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedrequiredtophoneandemail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CommunityMember", "PhoneNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.CommunityMember", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CommunityMember", "Email", c => c.String());
            AlterColumn("dbo.CommunityMember", "PhoneNumber", c => c.Int());
        }
    }
}
