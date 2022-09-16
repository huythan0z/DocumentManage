using DocumentManage.IServices;
using DocumentManage.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentManage.Services
{
    public class StatusServices : IStatusServices
    {
        private readonly DocumentManageContext _context;
        public StatusServices(DocumentManageContext context)
        {
            _context = context;
        }

        public IQueryable<dynamic> GetAll()
        {
            return _context.Statuses;
        }
        public dynamic AddNew(Status status)
        {
            _context.Statuses.Add(status);
            _context.SaveChanges();
            return status;
        }
        public dynamic Update(Status status)
        {
            var data = _context.Statuses.FirstOrDefault(m => m.Id == status.Id);
            if (data == null)
            {
                return false;
            }
            data.Statuss = status.Statuss;
            _context.Statuses.Update(data);
            _context.SaveChanges();
            return true;
        }
        public dynamic Delete(Status status)
        {
            var data = _context.Statuses.FirstOrDefault(m => m.Id == status.Id);
            if (data == null)
            {
                return false;
            }
            _context.Statuses.Remove(data);
            _context.SaveChanges();
            return true;
        }
    }
}
