using EduHomeAspProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduHomeAspProject.ViewModels
{
    public class VMTeacher
    {
        public BGImage BGImage { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<SocialTeacher> SocialTeachers { get; set; }
    }
}