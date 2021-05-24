using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE
{
    public class Utility
    {
        public static int userId { get; set; }
        public static DateTime Now()
        {
            //for multi countries adjustment 
            return DateTime.Now;
        }
    }
}
