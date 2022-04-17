﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Contact : Base
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
