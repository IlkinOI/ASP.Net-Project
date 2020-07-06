using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduHomeAspProject.ViewModels
{
    public class VMMessage
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public string Page { get; set; }
        public int? UserId { get; set; }
        public int? BlogId { get; set; }
        public int? EventId { get; set; }
        public int? CourseId { get; set; }
        public int? ContactId { get; set; }
    }
}