namespace EduHomeAspProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class message : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.Messages", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Messages", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Messages", "EventId", "dbo.Events");
            DropForeignKey("dbo.Messages", "UserId", "dbo.Users");
            DropIndex("dbo.Messages", new[] { "UserId" });
            DropIndex("dbo.Messages", new[] { "BlogId" });
            DropIndex("dbo.Messages", new[] { "EventId" });
            DropIndex("dbo.Messages", new[] { "CourseId" });
            DropIndex("dbo.Messages", new[] { "ContactId" });
            AddColumn("dbo.Messages", "Name", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Messages", "Email", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Messages", "UserId", c => c.Int());
            AlterColumn("dbo.Messages", "BlogId", c => c.Int());
            AlterColumn("dbo.Messages", "EventId", c => c.Int());
            AlterColumn("dbo.Messages", "CourseId", c => c.Int());
            AlterColumn("dbo.Messages", "ContactId", c => c.Int());
            CreateIndex("dbo.Messages", "UserId");
            CreateIndex("dbo.Messages", "BlogId");
            CreateIndex("dbo.Messages", "EventId");
            CreateIndex("dbo.Messages", "CourseId");
            CreateIndex("dbo.Messages", "ContactId");
            AddForeignKey("dbo.Messages", "BlogId", "dbo.Blogs", "Id");
            AddForeignKey("dbo.Messages", "ContactId", "dbo.Contacts", "Id");
            AddForeignKey("dbo.Messages", "CourseId", "dbo.Courses", "Id");
            AddForeignKey("dbo.Messages", "EventId", "dbo.Events", "Id");
            AddForeignKey("dbo.Messages", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "UserId", "dbo.Users");
            DropForeignKey("dbo.Messages", "EventId", "dbo.Events");
            DropForeignKey("dbo.Messages", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Messages", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Messages", "BlogId", "dbo.Blogs");
            DropIndex("dbo.Messages", new[] { "ContactId" });
            DropIndex("dbo.Messages", new[] { "CourseId" });
            DropIndex("dbo.Messages", new[] { "EventId" });
            DropIndex("dbo.Messages", new[] { "BlogId" });
            DropIndex("dbo.Messages", new[] { "UserId" });
            AlterColumn("dbo.Messages", "ContactId", c => c.Int(nullable: false));
            AlterColumn("dbo.Messages", "CourseId", c => c.Int(nullable: false));
            AlterColumn("dbo.Messages", "EventId", c => c.Int(nullable: false));
            AlterColumn("dbo.Messages", "BlogId", c => c.Int(nullable: false));
            AlterColumn("dbo.Messages", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Messages", "Email");
            DropColumn("dbo.Messages", "Name");
            CreateIndex("dbo.Messages", "ContactId");
            CreateIndex("dbo.Messages", "CourseId");
            CreateIndex("dbo.Messages", "EventId");
            CreateIndex("dbo.Messages", "BlogId");
            CreateIndex("dbo.Messages", "UserId");
            AddForeignKey("dbo.Messages", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Messages", "EventId", "dbo.Events", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Messages", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Messages", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Messages", "BlogId", "dbo.Blogs", "Id", cascadeDelete: true);
        }
    }
}
