namespace VisualPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_TaskId : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Priority = c.Int(nullable: false),
                        Title = c.String(nullable: false, unicode: false),
                        TimeBegin = c.DateTime(nullable: false, precision: 0),
                        TimeEnd = c.DateTime(nullable: false, precision: 0),
                        Note = c.String(unicode: false),
                        Remind = c.Boolean(nullable: false),
                        Type = c.Int(nullable: false),
                        Repeat = c.Boolean(nullable: false),
                        Period = c.Int(nullable: false),
                        EndPeriod = c.DateTime(nullable: false, precision: 0),
                        ProjectId = c.Int(),
                        ParentTaskId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TaskModels", t => t.ParentTaskId)
                .ForeignKey("dbo.UserModels", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ParentTaskId);
            
            CreateTable(
                "dbo.TaskViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        X = c.Int(nullable: false),
                        Y = c.Int(nullable: false),
                        TypeView = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TaskModels", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, unicode: false),
                        Password = c.String(nullable: false, unicode: false),
                        Login = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskModels", "UserId", "dbo.UserModels");
            DropForeignKey("dbo.TaskViewModels", "TaskId", "dbo.TaskModels");
            DropForeignKey("dbo.TaskModels", "ParentTaskId", "dbo.TaskModels");
            DropIndex("dbo.TaskViewModels", new[] { "TaskId" });
            DropIndex("dbo.TaskModels", new[] { "ParentTaskId" });
            DropIndex("dbo.TaskModels", new[] { "UserId" });
            DropTable("dbo.UserModels");
            DropTable("dbo.TaskViewModels");
            DropTable("dbo.TaskModels");
        }
    }
}
