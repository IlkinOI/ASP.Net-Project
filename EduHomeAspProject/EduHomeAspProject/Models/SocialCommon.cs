using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduHomeAspProject.Models
{
    public class SocialCommon
    {
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
        [Required, MaxLength(20)]
        public string Icon { get; set; }
        [Required, MaxLength(150)]
        public string Link { get; set; }
        public int CommonId { get; set; }
        public Common Common { get; set; }
    }
}