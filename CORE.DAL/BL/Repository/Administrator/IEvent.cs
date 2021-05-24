﻿using CORE.ViewModel.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE.BL.Repository.Administrator
{
    public interface IEvent
    {
        Task<string> SaveEvent(SaveEventVM eve);

        Task<string> DeleteEvent(int id);

        Task<List<GetEventVM>> GetEvent(int id);


    }
}
