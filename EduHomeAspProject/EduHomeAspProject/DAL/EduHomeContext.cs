using EduHomeAspProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EduHomeAspProject.DAL
{
    public class EduHomeContext:DbContext
    {
        public EduHomeContext() : base("EduConnection")
        {

        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<BGImage> BGImages { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Common> Commons { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SocialCommon> SocialCommons { get; set; }
        public DbSet<SocialTeacher> SocialTeachers { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<TestMorial> TestMorials { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<EventSpeaker> EventSpeakers { get; set; }
        public DbSet<TeacherSkill> TeacherSkills { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}