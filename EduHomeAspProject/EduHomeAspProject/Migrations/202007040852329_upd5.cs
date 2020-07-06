namespace EduHomeAspProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upd5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "PhoneLogo", c => c.String(maxLength: 150));
            AlterColumn("dbo.Contacts", "AddressLogo1", c => c.String(maxLength: 150));
            AlterColumn("dbo.Contacts", "AddressLogo2", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "AddressLogo2", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Contacts", "AddressLogo1", c => c.String(nullable: false, maxLength: 150));
            DropColumn("dbo.Contacts", "PhoneLogo");
        }
    }
}
