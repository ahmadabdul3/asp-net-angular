namespace MesjidCommittee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedreturnurltouseraccounts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAccount", "ReturnUrl", c => c.String());
            AlterColumn("dbo.UserAccount", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.UserAccount", "UserPassword", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserAccount", "UserPassword", c => c.String());
            AlterColumn("dbo.UserAccount", "Username", c => c.String());
            DropColumn("dbo.UserAccount", "ReturnUrl");
        }
    }
}
