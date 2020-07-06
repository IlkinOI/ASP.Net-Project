namespace EduHomeAspProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagerqdelete : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Commons", "ImageVBG", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Commons", "ImageVBG", c => c.String(nullable: false, maxLength: 150));
        }
    }
}
