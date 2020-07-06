﻿using EduHomeAspProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduHomeAspProject.ViewModels
{
    public class VMEvent
    {
        public BGImage BGImage { get; set; }
        public List<Event> Events { get; set; }
        public List<Blog> LatestBlogs { get; set; }
        public List<EventCategory> Categories { get; set; }
        public Common Common { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
    }
}