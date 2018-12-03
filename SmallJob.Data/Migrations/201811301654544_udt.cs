namespace SmallJob.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class udt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobsAvailable", "Pay", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobsAvailable", "Pay", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
