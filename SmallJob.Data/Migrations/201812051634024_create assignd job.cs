namespace SmallJob.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createassigndjob : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignedJobs",
                c => new
                    {
                        AssignmentId = c.Int(nullable: false, identity: true),
                        JobId = c.Int(nullable: false),
                        TitleOfJob = c.String(),
                        WorkerId = c.Int(nullable: false),
                        JobComplete = c.Boolean(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.AssignmentId)
                .ForeignKey("dbo.JobsAvailable", t => t.JobId, cascadeDelete: true)
                .ForeignKey("dbo.Worker", t => t.WorkerId, cascadeDelete: true)
                .Index(t => t.JobId)
                .Index(t => t.WorkerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignedJobs", "WorkerId", "dbo.Worker");
            DropForeignKey("dbo.AssignedJobs", "JobId", "dbo.JobsAvailable");
            DropIndex("dbo.AssignedJobs", new[] { "WorkerId" });
            DropIndex("dbo.AssignedJobs", new[] { "JobId" });
            DropTable("dbo.AssignedJobs");
        }
    }
}
