using DocumentManage.IServices;
using DocumentManage.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentManage.Services
{
    public class ProfileServices : IProfileServices
    {
        private readonly DocumentManageContext _context;
        public ProfileServices(DocumentManageContext context)
        {
            _context = context;
        }
        public IQueryable<dynamic> GetAll()
        {
            return _context.Profiles.Include(c => c.Requests);
        }
        public dynamic AddNew(Profile profile)
        {
            _context.Profiles.Add(profile);
            _context.SaveChanges();
            return profile;
        }
        public dynamic Update(Profile profile)
        {
            var data = _context.Profiles.FirstOrDefault(m => m.Id == profile.Id);
            if (data == null)
            {
                return false;
            }
            data.Name = profile.Name;
            data.Address = profile.Address;
            data.PhoneNumber = profile.PhoneNumber;
            data.Email = profile.Email;
            data.Password = profile.Password;
            data.PositionId = profile.PositionId;
            data.WStatus = profile.WStatus;

            _context.Profiles.Update(data);
            _context.SaveChanges();
            return true;
        }
        public dynamic Delete(Profile document)
        {
            var data = _context.Profiles.FirstOrDefault(m => m.Id == document.Id);
            if (data == null)
            {
                return false;
            }
            _context.Profiles.Remove(data);
            _context.SaveChanges();
            return true;
        }
    }
}
