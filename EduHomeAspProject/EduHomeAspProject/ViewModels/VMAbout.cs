using EduHomeAspProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduHomeAspProject.ViewModels
{
    public class VMAbout
    {
        public BGImage BgImage { get; set; }
        public Common Common { get; set; }
        public About About { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<SocialTeacher> SocialsT { get; set; }
        public List<TestMorial> TestMorials { get; set; }
        public List<Event> Events { get; set; }
        public TestMorial TestMorial { get; set; }
    }
}