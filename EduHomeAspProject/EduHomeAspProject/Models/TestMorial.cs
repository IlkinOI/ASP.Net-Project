using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduHomeAspProject.Models
{
    public class TestMorial
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [MaxLength(250)]
        public string ImageBG { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageBGFile { get; set; }
        [Required, MaxLength(250)]
        public string Text { get; set; }
        [Required, MaxLength(50)]
        public string Fullname { get; set; }
        [Required, MaxLength(100)]
        public string Occupation { get; set; }
    }
}