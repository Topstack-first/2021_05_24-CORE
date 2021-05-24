using CORE.BL.Repository;
using CORE.BL.Repository.AdminSetting;
using CORE.DAL.Model;
using CORE.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CORE.DAL.Services.GeneralDAL;

namespace CORE.DAL.Services.AdminSetting
{
    public class PortalSettingDAL : IPortalSetting
    {
        private IGeneral _generalServices;
        private BecipDbContext _context;
        public PortalSettingDAL(BecipDbContext appDbContext,IGeneral generalServices)
        {
            _generalServices = generalServices;
            _context = appDbContext;
        }

        public async Task<PortalSettingObjVM> GetPortalSettings()
        {
            var obj = await _context.PortalSettings.Select(a => new PortalSettingObjVM
            {
                Id = a.PortalSettingId,
                CompanyLogo = _generalServices.GetFileLocationWithWebRootPath(a.CompanyLogo),
                CompanyName = a.CompanyName,
                CorePortalShortName = a.CorePortalShortName,
                Favicon = _generalServices.GetFileLocationWithWebRootPath( a.Favicon),
                LoginPageBackground = _generalServices.GetFileLocationWithWebRootPath(a.LoginPageBackground),
                PortalLogo = _generalServices.GetFileLocationWithWebRootPath(a.PortalLogo),
                SiteTitle = a.SiteTitle
            }).FirstOrDefaultAsync();

            return obj;





        }

        public async Task<string> SavePortalSetting(SavePortalSettingVM model)
        {
            var isFirstEntry = _context.PortalSettings.FirstOrDefault();
            var op_type = isFirstEntry == null ? "add" : "update";

            var obj = new PortalSetting();
            if (op_type == "update")
            {
                obj = isFirstEntry;
            }

            if (op_type == "add")
            {
                obj.CompanyLogo = _generalServices.SaveImages(model.CompanyLogo, ImageFoldersPath_.CompanyLogoImage);
                obj.PortalLogo= _generalServices.SaveImages(model.PortalLogo, ImageFoldersPath_.PortalLogoImage);
                obj.Favicon = _generalServices.SaveImages(model.Favicon, ImageFoldersPath_.FaviconImage);
                obj.LoginPageBackground = _generalServices.SaveImages(model.LoginPageBackground, ImageFoldersPath_.LoginPageBg);
            }
            else
            {
                if (model.CompanyLogo != null)
                {
                    obj.CompanyLogo = _generalServices.SaveImages(model.CompanyLogo, ImageFoldersPath_.CompanyLogoImage);
                }
                if (model.PortalLogo != null)
                {
                    obj.PortalLogo = _generalServices.SaveImages(model.PortalLogo, ImageFoldersPath_.PortalLogoImage);
                }
                if (model.Favicon != null)
                {
                    obj.Favicon = _generalServices.SaveImages(model.Favicon, ImageFoldersPath_.FaviconImage);
                }
                if(model.LoginPageBackground!=null)
                {
                    obj.LoginPageBackground = _generalServices.SaveImages(model.LoginPageBackground, ImageFoldersPath_.LoginPageBg);
                }

            }
            obj.CompanyName = model.CompanyName;
            obj.SiteTitle = model.SiteTitle;
            obj.CorePortalShortName = model.CorePortalShortName;
            if (op_type == "add")
                _context.PortalSettings.Add(obj);
            await _context.SaveChangesAsync();
            var response = op_type == "add" ? "Successfully Added" : "Successfully Updated";
            return response;
        }
    }
}
