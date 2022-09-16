using DocumentManage.IServices;
using DocumentManage.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentManage.Services
{
    public class UrgencyServices : IUrgencyServices
    {
        private readonly DocumentManageContext _context;
        public UrgencyServices(DocumentManageContext context)
        {
            _context = context;
        }

        public IQueryable<dynamic> GetAll()
        {
            return _context.Urgencies.Include(c => c.Documents);
        }
        public dynamic AddNew(Urgency urgency)
        {
            _context.Urgencies.Add(urgency);
            _context.SaveChanges();
            return urgency;
        }
        public dynamic Update(Urgency urgency)
        {
            var data = _context.Urgencies.FirstOrDefault(m => m.Id == urgency.Id);
            if (data == null)
            {
                return false;
            }
            data.Urgencyy = urgency.Urgencyy;
            _context.Urgencies.Update(data);
            _context.SaveChanges();
            return true;
        }
        public dynamic Delete(Urgency urgency)
        {
            var data = _context.Urgencies.FirstOrDefault(m => m.Id == urgency.Id);
            if (data == null)
            {
                return false;
            }
            _context.Urgencies.Remove(data);
            _context.SaveChanges();
            return true;
        }
    }
}
