using CORE.DAL.Model;
using CORE.ViewModel.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE.BL.Repository.Administrator
{
    public interface ILocation
    {
        Task<string> SaveLocation(SaveLocationVM loc);

        Task<string> DeleteLocation(int id);

        Task<List<GetLocationVM>> GetLocation(int id);


    }
}
