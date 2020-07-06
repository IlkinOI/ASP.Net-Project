using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduHomeAspProject.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Fullname { get; set; }
        [MaxLength(150)]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [Required, MaxLength(500)]
        public string About { get; set; }
        [Required, MaxLength(20)]
        public string Degree { get; set; }
        [Required, MaxLength(20)]
        public string Experience { get; set; }
        [Required, MaxLength(100)]
        public string Hobbies { get; set; }
        [MaxLength(50)]
        public string Faculty { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string Phone { get; set; }
        [MaxLength(30)]
        public string Skype { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public List<SocialTeacher> SocialTeachers { get; set; }
        public List<TeacherSkill> TeacherSkills { get; set; }
    }
}