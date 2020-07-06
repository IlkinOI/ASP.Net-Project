using EduHomeAspProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduHomeAspProject.ViewModels
{
    public class VMTeacherDetail
    {
        public BGImage BGImage { get; set; }
        public Teacher Teacher { get; set; }
        public List<SocialTeacher> SocialTeachers { get; set; }
        public List<TeacherSkill> TeacherSkills { get; set; }

    }
}