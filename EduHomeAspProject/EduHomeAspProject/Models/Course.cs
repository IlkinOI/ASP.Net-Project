using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduHomeAspProject.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [Required, Column(TypeName = "ntext")]
        public string Content { get; set; }
        [Required, MaxLength(150)]
        public string Link { get; set; }
        [Required, MaxLength(30)]
        public string StartDate { get; set; }
        [Required]
        public byte CourseDuration { get; set; }
        public byte ClassDuration { get; set; }
        [Required, MaxLength(20)]
        public string SkillLevel { get; set; }
        [Required, MaxLength(20)]
        public string Language { get; set; }
        [Required]
        public int StudentsCount { get; set; }
        [Required, MaxLength(20)]
        public string Assessments { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CourseCategoryId { get; set; }
        public CourseCategory CourseCategory { get; set; }
        public List<Message> Messages { get; set; }
    }
}