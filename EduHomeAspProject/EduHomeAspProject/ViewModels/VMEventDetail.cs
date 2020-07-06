using EduHomeAspProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduHomeAspProject.ViewModels
{
    public class VMEventDetail
    {
        public BGImage BGImage { get; set; }
        public Event Event { get; set; }
        public List<EventCategory> Categories { get; set; }
        public List<Event> Events { get; set; }
        public List<EventSpeaker> EventSpeakers { get; set; }
        public List<Blog> LatestBlogs { get; set; }
        public Common Common { get; set; }
    }
}