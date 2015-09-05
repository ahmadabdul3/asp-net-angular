namespace MesjidCommittee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedgenderfieldtochildmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Child", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Child", "Gender");
        }
    }
}
