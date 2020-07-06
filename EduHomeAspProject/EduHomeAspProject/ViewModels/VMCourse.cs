using EduHomeAspProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduHomeAspProject.ViewModels
{
    public class VMCourse
    {
        public BGImage BGImage { get; set; }
        public List<Course> Courses { get; set; }
        public List<Blog> LatestBlogs { get; set; }
        public Common Common { get; set; }
    }
}