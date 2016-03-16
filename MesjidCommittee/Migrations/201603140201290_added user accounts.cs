namespace MesjidCommittee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeduseraccounts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAccount",
                c => new
                    {
                        UserAccountId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Username = c.String(),
                        UserPassword = c.String(),
                    })
                .PrimaryKey(t => t.UserAccountId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserAccount");
        }
    }
}
