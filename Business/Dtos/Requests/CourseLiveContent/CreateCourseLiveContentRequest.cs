﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests.CourseLiveContent
{
    public class CreateCourseLiveContentRequest
    {
        public Guid CourseId { get; set; }
        public Guid LiveContentId { get; set; }
    }
}
