using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduHomeAspProject.Models
{
    public class About
    {
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string Title1 { get; set; }
        [Required, MaxLength(20)]
        public string Title2 { get; set; }
        [Required, MaxLength(500)]
        public string WelcomeMessage1 { get; set; }
        [MaxLength(500)]
        public string WelcomeMessage2 { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}