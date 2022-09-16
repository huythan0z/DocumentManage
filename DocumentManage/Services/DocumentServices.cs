using DocumentManage.IServices;
using DocumentManage.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace DocumentManage.Services
{
    public class DocumentServices : IDocumentServices
    {
        private readonly DocumentManageContext _context;
        public DocumentServices(DocumentManageContext context)
        {
            _context = context;
        }
        public IQueryable<dynamic> GetAll()
        {
            var items = _context.Documents.Include(u => u.Requests);
            var output = from item in items
                         select new
                         {
                             item.Sender,
                             item.DateSend,
                             item.Receiver,
                             item.Note,
                             item.DocumentFile,
                             item.Type.DocumentType,
                             item.Urgency.Urgencyy,
                             Request = from r in item.Requests
                                       select new
                                       {
                                           r.ProfileId,
                                           r.Deadline,
                                           r.Note,
                                           r.Status.Statuss
                                       }
                         };
            return output;
        }
        public dynamic AddNew(Document document)
        {
            _context.Documents.Add(document);
            _context.SaveChanges();
            return document;
        }
        public dynamic Update(Document document)
        {
            var data = _context.Documents.FirstOrDefault(m => m.Id == document.Id);
            if (data == null)
            {
                return false;
            }
            data.Sender = document.Sender;
            data.DateSend = document.DateSend;
            data.Receiver = document.Receiver;
            data.Note = document.Note;
            data.DocumentFile = document.DocumentFile;
            data.TypeId = document.TypeId;
            data.UrgencyId = document.UrgencyId;
            _context.Documents.Update(data);
            _context.SaveChanges();
            return true;
        }
        public dynamic Delete(Document document)
        {
            var data = _context.Documents.FirstOrDefault(m => m.Id == document.Id);
            if (data == null)
            {
                return false;
            }
            _context.Documents.Remove(data);
            _context.SaveChanges();
            return true;
        }
        public dynamic GetType(Document document)
        {
            var data = _context.Documents.Where(c => c.TypeId == document.TypeId);
            return data.Include(m => m.Requests) ;
        }
        public dynamic GetUrgency(Document document)
        {
            var data = _context.Documents.Where(c => c.UrgencyId == document.UrgencyId);
            return data.Include(m => m.Requests);
        }
    }
}
