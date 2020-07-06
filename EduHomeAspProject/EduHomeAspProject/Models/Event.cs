using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduHomeAspProject.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Image { get; set; }
        [Required, Column(TypeName = "ntext")]
        public string Content { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [Required, MaxLength(20)]
        public string EventDate { get; set; }
        [Required, MaxLength(20)]
        public string EventTime { get; set; }
        [Required, MaxLength(20)]
        public string EventVenue { get; set; }
        [Required, MaxLength(150)]
        public string Link { get; set; }
        public DateTime CreatedDate { get; set; }
        public int EventCategoryId { get; set; }
        public EventCategory EventCategory { get; set; }
        public List<EventSpeaker> EventSpeakers { get; set; }
        public List<Message> Messages { get; set; }
    }
}