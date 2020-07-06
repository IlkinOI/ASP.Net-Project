using EduHomeAspProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduHomeAspProject.ViewModels
{
    public class VMBlog
    {
        public BGImage BGImage { get; set; }
        public List<Message> Messages { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Blog> LatestBlogs { get; set; }
        public Common Common { get; set; }
        public List<BlogCategory> Categories { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
    }
}