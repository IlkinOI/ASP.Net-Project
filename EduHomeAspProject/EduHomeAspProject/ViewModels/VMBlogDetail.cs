using EduHomeAspProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduHomeAspProject.ViewModels
{
    public class VMBlogDetail
    {
        public BGImage BGImage { get; set; }
        public Blog Blog { get; set; }
        public List<BlogCategory> Categories { get; set; }
        public List<Blog> LatestBlogs { get; set; }
        public List<Blog> Blogs { get; set; }
        public Common Common { get; set; }
    }
}