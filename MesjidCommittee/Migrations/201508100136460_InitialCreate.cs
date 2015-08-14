namespace MesjidCommittee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommunityMember",
                c => new
                    {
                        CommunityMemberId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        SpouseFirstName = c.String(),
                        SpouseLastName = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Gender = c.String(),
                        DateOfBirth = c.DateTime(),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(),
                        Age = c.Int(),
                        NumberOfIndividualsInFamily = c.Int(),
                        NumberOfChildren = c.Int(),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.CommunityMemberId);
            
            CreateTable(
                "dbo.Child",
                c => new
                    {
                        ChildId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CommunityMemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChildId)
                .ForeignKey("dbo.CommunityMember", t => t.CommunityMemberId, cascadeDelete: true)
                .Index(t => t.CommunityMemberId);
            
            CreateTable(
                "dbo.CommunityActivity",
                c => new
                    {
                        CommunityActivityId = c.Int(nullable: false, identity: true),
                        ActivityName = c.String(),
                        ChildId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommunityActivityId)
                .ForeignKey("dbo.Child", t => t.ChildId, cascadeDelete: true)
                .Index(t => t.ChildId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.CommunityActivity", new[] { "ChildId" });
            DropIndex("dbo.Child", new[] { "CommunityMemberId" });
            DropForeignKey("dbo.CommunityActivity", "ChildId", "dbo.Child");
            DropForeignKey("dbo.Child", "CommunityMemberId", "dbo.CommunityMember");
            DropTable("dbo.CommunityActivity");
            DropTable("dbo.Child");
            DropTable("dbo.CommunityMember");
        }
    }
}
