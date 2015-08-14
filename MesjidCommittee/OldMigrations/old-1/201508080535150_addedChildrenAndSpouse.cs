namespace MesjidCommitteeOld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedChildrenAndSpouse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Child",
                c => new
                    {
                        ChildId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CommunityMember_CommunityMemberID = c.Int(),
                    })
                .PrimaryKey(t => t.ChildId)
                .ForeignKey("dbo.CommunityMember", t => t.CommunityMember_CommunityMemberID)
                .Index(t => t.CommunityMember_CommunityMemberID);
            
            AddColumn("dbo.CommunityMember", "SpouseFirstName", c => c.String());
            AddColumn("dbo.CommunityMember", "SpouseLastName", c => c.String());
            AddColumn("dbo.CommunityActivity", "Child_ChildId", c => c.Int());
            AddForeignKey("dbo.CommunityActivity", "Child_ChildId", "dbo.Child", "ChildId");
            CreateIndex("dbo.CommunityActivity", "Child_ChildId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CommunityActivity", new[] { "Child_ChildId" });
            DropIndex("dbo.Child", new[] { "CommunityMember_CommunityMemberID" });
            DropForeignKey("dbo.CommunityActivity", "Child_ChildId", "dbo.Child");
            DropForeignKey("dbo.Child", "CommunityMember_CommunityMemberID", "dbo.CommunityMember");
            DropColumn("dbo.CommunityActivity", "Child_ChildId");
            DropColumn("dbo.CommunityMember", "SpouseLastName");
            DropColumn("dbo.CommunityMember", "SpouseFirstName");
            DropTable("dbo.Child");
        }
    }
}
