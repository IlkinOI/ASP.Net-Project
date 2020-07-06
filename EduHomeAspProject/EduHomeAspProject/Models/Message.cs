using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EduHomeAspProject.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
        [Required, MaxLength(30)]
        public string Email { get; set; }
        [Required, MaxLength(30)]
        public string Subject { get; set; }
        [Required, MaxLength(150)]
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UserId { get; set; }
        public int? BlogId { get; set; }
        public int? EventId { get; set; }
        public int? CourseId { get; set; }
        public int? ContactId { get; set; }
        public User User { get; set; }
        public Blog Blog { get; set; }
        public Event Event { get; set; }
        public Course Course { get; set; }
        public Contact Contact { get; set; }
    }
}