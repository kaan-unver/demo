﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DTO.EMail
{
    public class MeetingNotificationEmailContentDto : EmailContentDto
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
    }
}
