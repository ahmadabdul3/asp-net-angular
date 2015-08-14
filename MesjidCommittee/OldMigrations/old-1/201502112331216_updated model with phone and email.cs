namespace MesjidCommitteeOld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodelwithphoneandemail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CommunityMember", "PhoneNumber", c => c.Int());
            AddColumn("dbo.CommunityMember", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CommunityMember", "Email");
            DropColumn("dbo.CommunityMember", "PhoneNumber");
        }
    }
}
