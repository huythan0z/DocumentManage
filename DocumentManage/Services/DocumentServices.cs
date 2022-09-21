using DocumentManage.IServices;
using DocumentManage.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Hosting;

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
            var items = _context.Documents.Include(u => u.Profiles);
            var output = from item in items
                         select new
                         {
                             item.Id,
                             item.Sender,
                             item.DateSend,
                             item.Receiver,
                             item.Note,
                             item.DocumentFile,
                             item.Type.DocumentType,
                             item.Urgency.Urgencyy,
                             item.Status.Statuss,
                             Profile = from p in item.Profiles
                                       select new
                                       {
                                           p.Id,
                                           p.Name,
                                           p.Address,
                                           p.PhoneNumber,
                                           p.Email,
                                           p.Position.Positionn

                                       }
                         };
            return output;
        }
        public dynamic AddNew(Document document)
        {         
            Document doc = new Document
            {
                Sender = document.Sender,
                DateSend = document.DateSend,
                Receiver = document.Receiver,
                Deadline = document.Deadline,
                Note = document.Note,
                DocumentFile = document.DocumentFile,
                TypeId = document.TypeId,
                UrgencyId = document.UrgencyId,
                StatusId = document.StatusId
            };
            //_context.Documents.Add(doc);
            //_context.SaveChanges();
            var a = document.Profiles.ToList();   
            foreach (var item in a)
            {
                var data = _context.Profiles.Where(c => c.Id == item.Id);
                doc.Profiles.Add(data.FirstOrDefault());
            }
            _context.Update(doc);
            _context.SaveChanges();
            return doc;

            //var prof = document.Profiles.ToList();
            //var doc = new List<Document>();
            //var res = new List<Request>();
            //_context.Add(doc);
            //_context.SaveChangesAsync();
            //foreach (var id in prof)
            //{
            //    var item = new Request();
            //    {
            //        item.DocumentId = document.Id;
            //        item.ProfileId = id.Id;
            //    }
            //    res.Add(item);
            //}
            //_context.Add(res);
            //_context.SaveChangesAsync();
            //return true;
        }
        public dynamic Update(Document document)
        {
            var data = _context.Documents.Include(c => c.Profiles).FirstOrDefault(m => m.Id == document.Id);
            if (data == null)
            {
                return false;
            }
            data.Id = document.Id;
            data.Sender = document.Sender;
            data.DateSend = document.DateSend;
            data.Receiver = document.Receiver;
            data.Deadline = document.Deadline;
            data.Note = document.Note;
            data.DocumentFile = document.DocumentFile;
            data.TypeId = document.TypeId;
            data.UrgencyId = document.UrgencyId;
            data.StatusId = document.StatusId;

            var del = data.Profiles.ToList();
            foreach (var i in del)
            {
                data.Profiles.Remove(i);
            }
            _context.Update(data);
            _context.SaveChanges();
            var a = document.Profiles.ToList();
            foreach (var item in a)
            {
                var data1 = _context.Profiles.Where(c => c.Id == item.Id);
                data.Profiles.Add(data1.FirstOrDefault());
            }
            _context.Update(data);
            _context.SaveChanges();
            return data;
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
            return data.Include(m => m.Profiles);
        }
        public dynamic GetUrgency(Document document)
        {
            var data = _context.Documents.Where(c => c.UrgencyId == document.UrgencyId);
            return data.Include(m => m.Profiles);
        }
    }
}
