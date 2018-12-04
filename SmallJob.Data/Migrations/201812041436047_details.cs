namespace SmallJob.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class details : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Worker", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Worker", "CreatedUtc");
        }
    }
}
