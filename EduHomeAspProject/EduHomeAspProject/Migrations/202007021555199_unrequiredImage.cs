namespace EduHomeAspProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unrequiredImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Speakers", "Image", c => c.String(maxLength: 250));
            AlterColumn("dbo.Abouts", "Image", c => c.String(maxLength: 250));
            AlterColumn("dbo.BGImages", "Image", c => c.String(maxLength: 150));
            AlterColumn("dbo.Blogs", "Image", c => c.String(maxLength: 150));
            AlterColumn("dbo.Courses", "Image", c => c.String(maxLength: 150));
            AlterColumn("dbo.Events", "Image", c => c.String(maxLength: 150));
            AlterColumn("dbo.Users", "Image", c => c.String(maxLength: 150));
            AlterColumn("dbo.Commons", "LogoFooter", c => c.String(maxLength: 150));
            AlterColumn("dbo.Commons", "LogoHeader", c => c.String(maxLength: 150));
            AlterColumn("dbo.Commons", "BookLogoWhite", c => c.String(maxLength: 150));
            AlterColumn("dbo.Commons", "BookLogoRed", c => c.String(maxLength: 150));
            AlterColumn("dbo.Teachers", "Image", c => c.String(maxLength: 150));
            AlterColumn("dbo.Sliders", "Image", c => c.String(maxLength: 150));
            AlterColumn("dbo.TestMorials", "Image", c => c.String(maxLength: 250));
            AlterColumn("dbo.TestMorials", "ImageBG", c => c.String(maxLength: 250));
            DropColumn("dbo.Sliders", "Link");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sliders", "Link", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.TestMorials", "ImageBG", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.TestMorials", "Image", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Sliders", "Image", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Teachers", "Image", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Commons", "BookLogoRed", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Commons", "BookLogoWhite", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Commons", "LogoHeader", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Commons", "LogoFooter", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Users", "Image", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Events", "Image", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Courses", "Image", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Blogs", "Image", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.BGImages", "Image", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Abouts", "Image", c => c.String(nullable: false, maxLength: 250));
            DropColumn("dbo.Speakers", "Image");
        }
    }
}
