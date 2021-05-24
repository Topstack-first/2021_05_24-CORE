using CORE.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE.BL.Repository.AdminSetting
{
    public interface IBackupManagement
    {

        Task<string> SaveNewBackup(SaveNewBackupVM model);
        Task<string> RestoreTheBackup(SaveNewBackupVM model);
        Task<string> SaveBackupSchedule(SaveBackupSchedule model);
    }
}
