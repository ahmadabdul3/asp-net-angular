namespace MesjidCommitteeOld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcommunityactivitieslists : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommunityActivity",
                c => new
                    {
                        CommunityActivityId = c.Int(nullable: false, identity: true),
                        ActivityName = c.String(),
                        CommunityMemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommunityActivityId)
                .ForeignKey("dbo.CommunityMember", t => t.CommunityMemberId, cascadeDelete: true)
                .Index(t => t.CommunityMemberId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.CommunityActivity", new[] { "CommunityMemberId" });
            DropForeignKey("dbo.CommunityActivity", "CommunityMemberId", "dbo.CommunityMember");
            DropTable("dbo.CommunityActivity");
        }
    }
}
