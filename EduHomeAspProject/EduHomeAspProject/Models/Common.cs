using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduHomeAspProject.Models
{
    public class Common
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string Address { get; set; }
        [Required, MaxLength(50)]
        public string Phone1 { get; set; }
        [MaxLength(50)]
        public string Phone2 { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(150)]
        public string LogoFooter { get; set; }
        [NotMapped]
        public HttpPostedFileBase LogoFooterFile { get; set; }
        [MaxLength(150)]
        public string LogoHeader { get; set; }
        [NotMapped]
        public HttpPostedFileBase LogoHeaderFile { get; set; }
        [MaxLength(150)]
        public string BookLogoWhite { get; set; }
        [NotMapped]
        public HttpPostedFileBase BookLogoWhiteFile { get; set; }
        [MaxLength(150)]
        public string BookLogoRed { get; set; }
        [NotMapped]
        public HttpPostedFileBase BookLogoRedFile { get; set; }
        [Required, MaxLength(50)]
        public string Site { get; set; }
        [Required, MaxLength(250)]
        public string Video { get; set; }
        [MaxLength(150)]
        public string ImageVBG { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageVBGFile { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [Required, MaxLength(50)]
        public string Slogan { get; set; }
        public List<SocialCommon> SocialCommons { get; set; }
    }
}