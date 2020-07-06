namespace EduHomeAspProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagerqdelete1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Commons", "Image", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Commons", "Image", c => c.String(nullable: false, maxLength: 250));
        }
    }
}
