using DocumentManage.IServices;
using DocumentManage.Models;
using Microsoft.EntityFrameworkCore;

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
            return _context.Documents.Include(c => c.Requests);
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
    }
}
