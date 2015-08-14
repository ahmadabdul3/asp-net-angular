namespace MesjidCommitteeOld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfullnamefieldtomembermodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CommunityMember", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CommunityMember", "FullName");
        }
    }
}
