namespace MesjidCommitteeOld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class childTableNowHasActivities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Child", "CommunityMember_CommunityMemberID", "dbo.CommunityMember");
            DropForeignKey("dbo.CommunityActivity", "CommunityMemberId", "dbo.CommunityMember");
            DropForeignKey("dbo.CommunityActivity", "Child_ChildId", "dbo.Child");
            DropIndex("dbo.Child", new[] { "CommunityMember_CommunityMemberID" });
            DropIndex("dbo.CommunityActivity", new[] { "CommunityMemberId" });
            DropIndex("dbo.CommunityActivity", new[] { "Child_ChildId" });
            AddColumn("dbo.Child", "CommunityMemberId", c => c.Int(nullable: false));
            AddColumn("dbo.CommunityActivity", "ChildId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Child", "CommunityMemberId", "dbo.CommunityMember", "CommunityMemberID", cascadeDelete: true);
            AddForeignKey("dbo.CommunityActivity", "ChildId", "dbo.Child", "ChildId", cascadeDelete: true);
            CreateIndex("dbo.Child", "CommunityMemberId");
            CreateIndex("dbo.CommunityActivity", "ChildId");
            DropColumn("dbo.Child", "CommunityMember_CommunityMemberID");
            DropColumn("dbo.CommunityActivity", "CommunityMemberId");
            DropColumn("dbo.CommunityActivity", "Child_ChildId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CommunityActivity", "Child_ChildId", c => c.Int());
            AddColumn("dbo.CommunityActivity", "CommunityMemberId", c => c.Int(nullable: false));
            AddColumn("dbo.Child", "CommunityMember_CommunityMemberID", c => c.Int());
            DropIndex("dbo.CommunityActivity", new[] { "ChildId" });
            DropIndex("dbo.Child", new[] { "CommunityMemberId" });
            DropForeignKey("dbo.CommunityActivity", "ChildId", "dbo.Child");
            DropForeignKey("dbo.Child", "CommunityMemberId", "dbo.CommunityMember");
            DropColumn("dbo.CommunityActivity", "ChildId");
            DropColumn("dbo.Child", "CommunityMemberId");
            CreateIndex("dbo.CommunityActivity", "Child_ChildId");
            CreateIndex("dbo.CommunityActivity", "CommunityMemberId");
            CreateIndex("dbo.Child", "CommunityMember_CommunityMemberID");
            AddForeignKey("dbo.CommunityActivity", "Child_ChildId", "dbo.Child", "ChildId");
            AddForeignKey("dbo.CommunityActivity", "CommunityMemberId", "dbo.CommunityMember", "CommunityMemberID", cascadeDelete: true);
            AddForeignKey("dbo.Child", "CommunityMember_CommunityMemberID", "dbo.CommunityMember", "CommunityMemberID");
        }
    }
}
