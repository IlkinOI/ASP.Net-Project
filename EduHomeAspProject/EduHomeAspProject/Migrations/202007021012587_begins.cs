namespace EduHomeAspProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class begins : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        WelcomeMessage1 = c.String(nullable: false, maxLength: 500),
                        WelcomeMessage2 = c.String(maxLength: 500),
                        Image = c.String(nullable: false, maxLength: 250),
                        Link = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BGImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TItle = c.String(nullable: false, maxLength: 50),
                        Page = c.String(nullable: false, maxLength: 20),
                        Image = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BlogCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Content = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Image = c.String(nullable: false, maxLength: 150),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        CreatedDate = c.DateTime(nullable: false),
                        ReplyCount = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        BlogCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogCategories", t => t.BlogCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.BlogCategoryId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(nullable: false, maxLength: 30),
                        Text = c.String(nullable: false, maxLength: 150),
                        CreatedDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        BlogId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.BlogId)
                .Index(t => t.EventId)
                .Index(t => t.CourseId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Address1 = c.String(nullable: false, maxLength: 100),
                        Address2 = c.String(maxLength: 100),
                        AddressLogo1 = c.String(nullable: false, maxLength: 150),
                        AddressLogo2 = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Image = c.String(nullable: false, maxLength: 150),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        Link = c.String(nullable: false, maxLength: 150),
                        StartDate = c.String(nullable: false, maxLength: 30),
                        CourseDuration = c.Byte(nullable: false),
                        ClassDuration = c.Byte(nullable: false),
                        SkillLevel = c.String(nullable: false, maxLength: 20),
                        Language = c.String(nullable: false, maxLength: 20),
                        StudentsCount = c.Int(nullable: false),
                        Assessments = c.String(nullable: false, maxLength: 20),
                        CreatedDate = c.DateTime(nullable: false),
                        CourseCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseCategories", t => t.CourseCategoryId, cascadeDelete: true)
                .Index(t => t.CourseCategoryId);
            
            CreateTable(
                "dbo.CourseCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Content = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Image = c.String(nullable: false, maxLength: 150),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        EventDate = c.String(nullable: false, maxLength: 20),
                        EventTime = c.String(nullable: false, maxLength: 20),
                        EventVenue = c.String(nullable: false, maxLength: 20),
                        Link = c.String(nullable: false, maxLength: 150),
                        CreatedDate = c.DateTime(nullable: false),
                        EventCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventCategories", t => t.EventCategoryId, cascadeDelete: true)
                .Index(t => t.EventCategoryId);
            
            CreateTable(
                "dbo.EventCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Content = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventSpeakers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpeakerId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Speakers", t => t.SpeakerId, cascadeDelete: true)
                .Index(t => t.SpeakerId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.Speakers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 50),
                        Position = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 50),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 250),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 30),
                        Image = c.String(nullable: false, maxLength: 150),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Commons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false, maxLength: 150),
                        Phone1 = c.String(nullable: false, maxLength: 50),
                        Phone2 = c.String(maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        LogoFooter = c.String(nullable: false, maxLength: 150),
                        LogoHeader = c.String(nullable: false, maxLength: 150),
                        BookLogoWhite = c.String(nullable: false, maxLength: 150),
                        BookLogoRed = c.String(nullable: false, maxLength: 150),
                        Site = c.String(nullable: false, maxLength: 50),
                        Video = c.String(nullable: false, maxLength: 250),
                        ImageVBG = c.String(nullable: false, maxLength: 150),
                        Image = c.String(nullable: false, maxLength: 250),
                        Slogan = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SocialCommons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Icon = c.String(nullable: false, maxLength: 20),
                        Link = c.String(nullable: false, maxLength: 150),
                        CommonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Commons", t => t.CommonId, cascadeDelete: true)
                .Index(t => t.CommonId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 50),
                        Image = c.String(nullable: false, maxLength: 150),
                        About = c.String(nullable: false, maxLength: 500),
                        Degree = c.String(nullable: false, maxLength: 20),
                        Experience = c.String(nullable: false, maxLength: 20),
                        Hobbies = c.String(nullable: false, maxLength: 100),
                        Faculty = c.String(maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(maxLength: 20),
                        Skype = c.String(maxLength: 30),
                        PositionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.SocialTeachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Icon = c.String(nullable: false, maxLength: 20),
                        Link = c.String(nullable: false, maxLength: 150),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.TeacherSkills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        SkillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Skills", t => t.SkillId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.SkillId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Progress = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Text = c.String(nullable: false, maxLength: 200),
                        Link = c.String(nullable: false, maxLength: 150),
                        Image = c.String(nullable: false, maxLength: 150),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subscribes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestMorials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(nullable: false, maxLength: 250),
                        ImageBG = c.String(nullable: false, maxLength: 250),
                        Text = c.String(nullable: false, maxLength: 250),
                        Fullname = c.String(nullable: false, maxLength: 50),
                        Occupation = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherSkills", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.TeacherSkills", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.SocialTeachers", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.SocialCommons", "CommonId", "dbo.Commons");
            DropForeignKey("dbo.Messages", "UserId", "dbo.Users");
            DropForeignKey("dbo.Blogs", "UserId", "dbo.Users");
            DropForeignKey("dbo.Messages", "EventId", "dbo.Events");
            DropForeignKey("dbo.EventSpeakers", "SpeakerId", "dbo.Speakers");
            DropForeignKey("dbo.EventSpeakers", "EventId", "dbo.Events");
            DropForeignKey("dbo.Events", "EventCategoryId", "dbo.EventCategories");
            DropForeignKey("dbo.Messages", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "CourseCategoryId", "dbo.CourseCategories");
            DropForeignKey("dbo.Messages", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Messages", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.Blogs", "BlogCategoryId", "dbo.BlogCategories");
            DropIndex("dbo.TeacherSkills", new[] { "SkillId" });
            DropIndex("dbo.TeacherSkills", new[] { "TeacherId" });
            DropIndex("dbo.SocialTeachers", new[] { "TeacherId" });
            DropIndex("dbo.Teachers", new[] { "PositionId" });
            DropIndex("dbo.SocialCommons", new[] { "CommonId" });
            DropIndex("dbo.EventSpeakers", new[] { "EventId" });
            DropIndex("dbo.EventSpeakers", new[] { "SpeakerId" });
            DropIndex("dbo.Events", new[] { "EventCategoryId" });
            DropIndex("dbo.Courses", new[] { "CourseCategoryId" });
            DropIndex("dbo.Messages", new[] { "ContactId" });
            DropIndex("dbo.Messages", new[] { "CourseId" });
            DropIndex("dbo.Messages", new[] { "EventId" });
            DropIndex("dbo.Messages", new[] { "BlogId" });
            DropIndex("dbo.Messages", new[] { "UserId" });
            DropIndex("dbo.Blogs", new[] { "BlogCategoryId" });
            DropIndex("dbo.Blogs", new[] { "UserId" });
            DropTable("dbo.TestMorials");
            DropTable("dbo.Subscribes");
            DropTable("dbo.Sliders");
            DropTable("dbo.Skills");
            DropTable("dbo.TeacherSkills");
            DropTable("dbo.SocialTeachers");
            DropTable("dbo.Teachers");
            DropTable("dbo.Positions");
            DropTable("dbo.SocialCommons");
            DropTable("dbo.Commons");
            DropTable("dbo.Users");
            DropTable("dbo.Speakers");
            DropTable("dbo.EventSpeakers");
            DropTable("dbo.EventCategories");
            DropTable("dbo.Events");
            DropTable("dbo.CourseCategories");
            DropTable("dbo.Courses");
            DropTable("dbo.Contacts");
            DropTable("dbo.Messages");
            DropTable("dbo.Blogs");
            DropTable("dbo.BlogCategories");
            DropTable("dbo.BGImages");
            DropTable("dbo.Abouts");
        }
    }
}
