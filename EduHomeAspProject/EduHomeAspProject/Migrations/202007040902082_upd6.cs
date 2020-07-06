namespace EduHomeAspProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upd6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Address3", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "Address3");
        }
    }
}
