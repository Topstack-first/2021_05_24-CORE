﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE.Models
{
    public class UpdateAccountStatusbyUserId
    {
        public int[] UserID { get; set; }
        public bool AccountStatus { get; set; }
    }
}
