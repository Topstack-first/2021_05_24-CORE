using CORE.BL.Repository.Administrator;
using CORE.DAL.Model;
using CORE.ViewModel.ProjectTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE.DAL.Services.Administrator
{
    public class ProjectTrackingDAL: IProjectTracker
    {
        private BecipDbContext _context;
        public ProjectTrackingDAL(BecipDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public string GetCurrentUserId()
        {
            return "Test123";
        }
        public async Task<List<GetProjectTrackingVM>> GetProjectTracking(int id)
        {
            var _c = new List<ProjectTracker>();
            if (id > 0)
                _c = await _context.ProjectTrackers.Where(x => x.Id == id).ToListAsync();
            else
                _c = await _context.ProjectTrackers.ToListAsync();


            var transForm = _c.AsEnumerable().Select(x => new GetProjectTrackingVM
            {

                DaystoML = x.DaystoML,
                ExistingPercentage = x.ExistingPercentage,
                MilestoneDate = x.MilestoneDate,
                MilestoneName = x.MilestoneName,
                ProjectName = x.ProjectName,
                ProposedPersentage = x.ProposedPersentage

            }).ToList();
            return transForm;
        }

    }
}
