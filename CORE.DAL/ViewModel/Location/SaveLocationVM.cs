﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE.ViewModel.Location
{
    public class SaveLocationVM
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public string UserId { get; set; }
    }
}