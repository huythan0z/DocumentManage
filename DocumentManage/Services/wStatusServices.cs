using DocumentManage.IServices;
using DocumentManage.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace DocumentManage.Services
{
    public class wStatusServices : IwStatusServices
    {
        private readonly DocumentManageContext _context;
        public wStatusServices(DocumentManageContext context)
        {
            _context = context;
        }

        public IQueryable<dynamic> GetAll()
        {
            return _context.WStatuses.Include(c => c.Profiles);
        }
        public dynamic AddNew(WStatus wstatus)
        {
            _context.WStatuses.Add(wstatus);
            _context.SaveChanges();
            return wstatus;
        }
        public dynamic Update(WStatus wstatus)
        {
            var data = _context.WStatuses.FirstOrDefault(m => m.Id == wstatus.Id);
            if (data == null)
            {
                return false;
            }
            data.WStatuss = wstatus.WStatuss;
            _context.WStatuses.Update(data);
            _context.SaveChanges();
            return true;
        }
        public dynamic Delete(WStatus wstatus)
        {
            var data = _context.WStatuses.FirstOrDefault(m => m.Id == wstatus.Id);
            if (data == null)
            {
                return false;
            }
            _context.WStatuses.Remove(data);
            _context.SaveChanges();
            return true;
        }
    }
}
