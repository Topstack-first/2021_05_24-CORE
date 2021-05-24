using CORE.ViewModel.ProjectTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE.BL.Repository.Administrator
{
    public interface IProjectTracker
    {
        Task<List<GetProjectTrackingVM>> GetProjectTracking(int id);


    }
}
