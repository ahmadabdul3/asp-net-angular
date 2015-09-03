namespace MesjidCommittee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddateofbirthpropertyforchildmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Child", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Child", "DateOfBirth");
        }
    }
}
