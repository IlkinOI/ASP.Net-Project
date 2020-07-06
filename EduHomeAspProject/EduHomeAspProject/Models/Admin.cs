using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduHomeAspProject.Models
{
    public class Admin
    {
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Firstname { get; set; }
        [Required, MaxLength(50)]
        public string Lastname { get; set; }
        [Required,MaxLength(30)]
        public string Username { get; set; }
        [Required, MaxLength(30)]
        public string Email { get; set; }
        [Required,MaxLength(250)]
        public string Password { get; set; }
        [MaxLength(150)]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}