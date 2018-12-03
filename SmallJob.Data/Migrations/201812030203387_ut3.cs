namespace SmallJob.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ut3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Worker", "PhoneNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Worker", "PhoneNumber");
        }
    }
}
