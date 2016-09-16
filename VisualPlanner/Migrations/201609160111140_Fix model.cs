namespace VisualPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TaskModels", "ParentTaskId", "dbo.TaskModels");
            DropForeignKey("dbo.TaskViewModels", "TaskId", "dbo.TaskModels");
            DropForeignKey("dbo.TaskModels", "UserId", "dbo.UserModels");
            DropIndex("dbo.TaskModels", new[] { "UserId" });
            DropIndex("dbo.TaskModels", new[] { "ParentTaskId" });
            DropIndex("dbo.TaskViewModels", new[] { "TaskId" });
            DropPrimaryKey("dbo.TaskModels");
            DropPrimaryKey("dbo.AspNetUsers");
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        RoleId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ProviderKey = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AddColumn("dbo.TaskModels", "ParentTask_Id", c => c.String(maxLength: 128, storeType: "nvarchar"));
            AddColumn("dbo.TaskViewModels", "Task_Id", c => c.String(maxLength: 128, storeType: "nvarchar"));
            AddColumn("dbo.AspNetUsers", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PasswordHash", c => c.String(unicode: false));
            AddColumn("dbo.AspNetUsers", "SecurityStamp", c => c.String(unicode: false));
            AddColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String(unicode: false));
            AddColumn("dbo.AspNetUsers", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime(precision: 0));
            AddColumn("dbo.AspNetUsers", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false, maxLength: 256, storeType: "nvarchar"));
            AlterColumn("dbo.TaskModels", "Id", c => c.String(nullable: false, maxLength: 128, storeType: "nvarchar"));
            AlterColumn("dbo.TaskModels", "UserId", c => c.String(nullable: false, maxLength: 128, storeType: "nvarchar"));
            AlterColumn("dbo.TaskModels", "Period", c => c.Int());
            AlterColumn("dbo.TaskModels", "EndPeriod", c => c.DateTime(precision: 0));
            AlterColumn("dbo.AspNetUsers", "Id", c => c.String(nullable: false, maxLength: 128, storeType: "nvarchar"));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256, storeType: "nvarchar"));
            AddPrimaryKey("dbo.TaskModels", "Id");
            AddPrimaryKey("dbo.AspNetUsers", "Id");
            CreateIndex("dbo.TaskModels", "UserId");
            CreateIndex("dbo.TaskModels", "ParentTask_Id");
            CreateIndex("dbo.TaskViewModels", "Task_Id");
            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
            AddForeignKey("dbo.TaskModels", "ParentTask_Id", "dbo.TaskModels", "Id");
            AddForeignKey("dbo.TaskViewModels", "Task_Id", "dbo.TaskModels", "Id");
            AddForeignKey("dbo.TaskModels", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.AspNetUsers", "Password");
            DropColumn("dbo.AspNetUsers", "Login");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Login", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.AspNetUsers", "Password", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            DropForeignKey("dbo.TaskModels", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TaskViewModels", "Task_Id", "dbo.TaskModels");
            DropForeignKey("dbo.TaskModels", "ParentTask_Id", "dbo.TaskModels");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.TaskViewModels", new[] { "Task_Id" });
            DropIndex("dbo.TaskModels", new[] { "ParentTask_Id" });
            DropIndex("dbo.TaskModels", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropPrimaryKey("dbo.AspNetUsers");
            DropPrimaryKey("dbo.TaskModels");
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.AspNetUsers", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.TaskModels", "EndPeriod", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.TaskModels", "Period", c => c.Int(nullable: false));
            AlterColumn("dbo.TaskModels", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.TaskModels", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.AspNetUsers", "UserName");
            DropColumn("dbo.AspNetUsers", "AccessFailedCount");
            DropColumn("dbo.AspNetUsers", "LockoutEnabled");
            DropColumn("dbo.AspNetUsers", "LockoutEndDateUtc");
            DropColumn("dbo.AspNetUsers", "TwoFactorEnabled");
            DropColumn("dbo.AspNetUsers", "PhoneNumberConfirmed");
            DropColumn("dbo.AspNetUsers", "PhoneNumber");
            DropColumn("dbo.AspNetUsers", "SecurityStamp");
            DropColumn("dbo.AspNetUsers", "PasswordHash");
            DropColumn("dbo.AspNetUsers", "EmailConfirmed");
            DropColumn("dbo.TaskViewModels", "Task_Id");
            DropColumn("dbo.TaskModels", "ParentTask_Id");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            AddPrimaryKey("dbo.AspNetUsers", "Id");
            AddPrimaryKey("dbo.TaskModels", "Id");
            CreateIndex("dbo.TaskViewModels", "TaskId");
            CreateIndex("dbo.TaskModels", "ParentTaskId");
            CreateIndex("dbo.TaskModels", "UserId");
            AddForeignKey("dbo.TaskModels", "UserId", "dbo.UserModels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TaskViewModels", "TaskId", "dbo.TaskModels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TaskModels", "ParentTaskId", "dbo.TaskModels", "Id");
        }
    }
}
