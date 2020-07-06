using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduHomeAspProject.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string Title { get; set; }
        [MaxLength(150)]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [Required, Column(TypeName ="ntext")]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ReplyCount { get; set; }
        public int UserId { get; set; }
        public int BlogCategoryId { get; set; }
        public User User { get; set; }
        public BlogCategory BlogCategory { get; set; }
        public List<Message> Messages { get; set; }
    }
}