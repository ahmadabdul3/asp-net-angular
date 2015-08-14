namespace MesjidCommitteeOld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommunityMember",
                c => new
                    {
                        CommunityMemberID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        city = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(),
                        Age = c.Int(),
                        NumberOfIndividualsInFamily = c.Int(),
                        NumberOfChildren = c.Int(),
                    })
                .PrimaryKey(t => t.CommunityMemberID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CommunityMember");
        }
    }
}
