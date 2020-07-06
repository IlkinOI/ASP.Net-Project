namespace EduHomeAspProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Image", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "Image");
        }
    }
}
