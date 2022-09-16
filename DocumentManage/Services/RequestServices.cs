using DocumentManage.IServices;
using DocumentManage.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentManage.Services
{
    public class RequestServices : IRequestServices
    {
        private readonly DocumentManageContext _context;
        public RequestServices(DocumentManageContext context)
        {
            _context = context;
        }
        public IQueryable<dynamic> GetAll()
        {
            return _context.Requests.Include(c => c.Document);
        }
        public dynamic AddNew(Request request)
        {
            
            _context.Requests.Add(request);
            _context.SaveChanges();
            return request;
        }
        public dynamic Update(Request request)
        {
            var data = _context.Requests.FirstOrDefault(m => m.Id == request.Id);
            if (data == null)
            {
                return false;
            }
            data.DocumentId = request.DocumentId;
            data.ProfileId = request.ProfileId;
            data.Deadline = Convert.ToDateTime(request.Deadline);
            data.Note = request.Note;
            data.StatusId = request.StatusId;
            _context.Requests.Update(data);
            _context.SaveChanges();
            return true;
        }
        public dynamic Delete(Request request)
        {
            var data = _context.Requests.FirstOrDefault(m => m.Id == request.Id);
            if (data == null)
            {
                return false;
            }
            _context.Requests.Remove(data);
            _context.SaveChanges();
            return true;
        }
    }
}

