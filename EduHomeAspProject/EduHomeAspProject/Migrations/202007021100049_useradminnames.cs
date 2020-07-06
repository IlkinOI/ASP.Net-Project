namespace EduHomeAspProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useradminnames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Firstname", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Admins", "Lastname", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Users", "Firstname", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Users", "Lastname", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Admins", "Fullname");
            DropColumn("dbo.Users", "Fullname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Fullname", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Admins", "Fullname", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Users", "Lastname");
            DropColumn("dbo.Users", "Firstname");
            DropColumn("dbo.Admins", "Lastname");
            DropColumn("dbo.Admins", "Firstname");
        }
    }
}
