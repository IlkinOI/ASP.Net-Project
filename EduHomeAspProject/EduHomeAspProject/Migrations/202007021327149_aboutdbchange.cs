namespace EduHomeAspProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aboutdbchange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "Title1", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Abouts", "Title2", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Abouts", "Title");
            DropColumn("dbo.Abouts", "Link");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abouts", "Link", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.Abouts", "Title", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Abouts", "Title2");
            DropColumn("dbo.Abouts", "Title1");
        }
    }
}
