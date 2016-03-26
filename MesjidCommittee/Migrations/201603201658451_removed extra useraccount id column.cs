namespace MesjidCommittee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedextrauseraccountidcolumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserAccount", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAccount", "UserId", c => c.Int(nullable: false));
        }
    }
}
