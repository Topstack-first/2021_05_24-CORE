using CORE.ViewModel.Index;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE.BL.Repository.Administrator
{
    public interface IIndex
    {
        Task<string> SaveIndex(AddIndexVM category);

        Task<string> DeleteIndex(int id);

        Task<List<GetIndexVM>> GetIndex(int id);
    }
}
