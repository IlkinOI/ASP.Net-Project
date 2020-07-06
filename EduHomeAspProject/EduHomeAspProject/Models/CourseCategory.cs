using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EduHomeAspProject.Models
{
    public class CourseCategory
    {
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
        [Required, MaxLength(500)]
        public string Content { get; set; }
        public List<Course> Courses { get; set; }
    }
}