﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class LinkDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Code { get; set; }
        public string GeneratedLink { get; set; }
    }
}
