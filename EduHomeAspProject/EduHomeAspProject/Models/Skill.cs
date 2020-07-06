using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EduHomeAspProject.Models
{
    public class Skill
    {
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
        [Required,Range(0,100)]
        public byte Progress { get; set; }
        public List<TeacherSkill> TeacherSkills { get; set; }
    }
}