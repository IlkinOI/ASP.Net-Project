using EduHomeAspProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduHomeAspProject.ViewModels
{
    public class VMHome
    {
        public List<Slider> Sliders { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Course> Courses { get; set; }
        public List<Event> Events { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<TestMorial> TestMorials { get; set; }
        public TestMorial TestMorial { get; set; }
        public Common Common { get; set; }
        public About About { get; set; }
    }
}