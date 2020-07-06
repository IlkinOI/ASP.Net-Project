using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduHomeAspProject.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string Phone { get; set; }
        [Required, MaxLength(100)]
        public string Address1 { get; set; }
        [MaxLength(100)]
        public string Address2 { get; set; }
        [MaxLength(100)]
        public string Address3 { get; set; }
        [MaxLength(150)]
        public string AddressLogo1 { get; set; }
        [NotMapped]
        public HttpPostedFileBase AddressLogo1File { get; set; }
        [MaxLength(150)]
        public string AddressLogo2 { get; set; }
        [NotMapped]
        public HttpPostedFileBase AddressLogo2File { get; set; }
        [MaxLength(150)]
        public string PhoneLogo { get; set; }
        [NotMapped]
        public HttpPostedFileBase PhoneLogoFile { get; set; }
        public List<Message> Message { get; set; }
    }
}