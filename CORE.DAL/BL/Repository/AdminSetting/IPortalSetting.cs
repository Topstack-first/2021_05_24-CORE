using CORE.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE.BL.Repository.AdminSetting
{
    public interface IPortalSetting
    {
        Task<string> SavePortalSetting(SavePortalSettingVM model);
        Task<PortalSettingObjVM> GetPortalSettings();
    }
}
