﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE.ViewModel.StakeHolder
{
    public class SaveStakeHolderVM
    {
        public int StakeHolderId { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string IconUrl { get; set; }
        public string UserId { get; set; }

    }
}
