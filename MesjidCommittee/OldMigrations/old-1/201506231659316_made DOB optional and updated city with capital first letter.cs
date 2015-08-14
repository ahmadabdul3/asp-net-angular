namespace MesjidCommitteeOld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madeDOBoptionalandupdatedcitywithcapitalfirstletter : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CommunityMember", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.CommunityMember", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.CommunityMember", "DateOfBirth", c => c.DateTime());
            AlterColumn("dbo.CommunityMember", "City", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CommunityMember", "city", c => c.String());
            AlterColumn("dbo.CommunityMember", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CommunityMember", "LastName", c => c.String());
            AlterColumn("dbo.CommunityMember", "FirstName", c => c.String());
        }
    }
}
