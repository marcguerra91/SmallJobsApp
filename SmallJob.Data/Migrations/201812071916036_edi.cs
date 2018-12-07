namespace SmallJob.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Worker", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Worker", "FullName");
        }
    }
}
