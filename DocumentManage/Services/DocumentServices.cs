using DocumentManage.IServices;
using DocumentManage.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

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
            var output = _context.Documents.OrderByDescending(c => c.Id);
            return output;

        }
        public IQueryable<dynamic> GetDocGo()
        {
            var items = _context.Documents.Include(u => u.Departments);
            var output = from item in items
                         where item.ArrivalDate == null
                         select new
                         {
                             item.Id,
                             item.Address,
                             item.Sender,
                             item.Signer,
                             item.SignDate,
                             item.ExpirationDate,
                             item.Note,
                             item.DocumentFile,
                             item.Receiver,
                             item.Type.DocumentType,
                             item.Urgency.Urgencyy,
                             item.Status.Statuss,
                             department = from d in item.Departments
                                          select new
                                          {
                                              d.DepartmentName,
                                          }
                         };
            return output;
            return null;
        }
        public IQueryable<dynamic> GetDocArrive()
        {

            var items = _context.Documents.Include(u => u.Profiles);
            var output = from item in items
                         where item.ArrivalDate != null
                         orderby item.Id descending 
                         select new
                         {
                             item.Id,
                             item.Address,
                             item.Signer,
                             item.SignDate,
                             item.ArrivalDate,
                             item.ExpirationDate,
                             item.Note,
                             item.DocumentFile,
                             item.Receiver,
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
        public dynamic AddNewArrive(Document document)
        {
            var items = _context.Documents.Include(u => u.Profiles);
            Document doc = new Document
            {
                Address = document.Address,
                Signer = document.Signer,
                SignDate = document.SignDate,
                ArrivalDate = document.ArrivalDate,
                ExpirationDate = document.ExpirationDate,
                Note = document.Note,
                DocumentFile = document.DocumentFile,
                Receiver = document.Receiver,
                TypeId = document.TypeId,
                UrgencyId = document.UrgencyId,
                StatusId = document.StatusId
            };
            var a = document.Profiles.ToList();
            foreach (var item in a)
            {
                var data = _context.Profiles.Where(c => c.Id == item.Id);
                doc.Profiles.Add(data.FirstOrDefault());
            }
            _context.Update(doc);
            _context.SaveChanges();
            return doc;
        }
        public dynamic AddNewGoOut(Document document)
        {
            Document doc = new Document
            {
                Address = document.Address, 
                Signer = document.Signer,
                SignDate = document.SignDate,
                ArrivalDate = null,
                ExpirationDate = document.ExpirationDate,
                Note = document.Note,
                DocumentFile = document.DocumentFile,
                Sender = document.Sender,
                Receiver = document.Receiver,
                TypeId = document.TypeId,
                UrgencyId = document.UrgencyId,
                StatusId = document.StatusId
            };
            _context.Documents.Add(doc);
            _context.SaveChanges();
            return doc;
        }
        public dynamic AddNewGoProfile(Document document)
        {
            if (document.Address == null || document.Address == "")
            {
                Document doc = new Document
                {
                    Address = null,
                    Signer = document.Signer,
                    SignDate = document.SignDate,
                    ArrivalDate = null,
                    ExpirationDate = document.ExpirationDate,
                    Note = document.Note,
                    DocumentFile = document.DocumentFile,
                    Receiver = document.Receiver,
                    Sender = document.Sender,
                    TypeId = document.TypeId,
                    UrgencyId = document.UrgencyId,
                    StatusId = document.StatusId
                };
                var a = document.Profiles.ToList();
                Console.WriteLine(a);
                foreach (var item in a)
                {
                    var data = _context.Profiles.Where(c => c.Id == item.Id);
                    doc.Profiles.Add(data.FirstOrDefault());
                }
                _context.Documents.Update(doc);
                _context.SaveChanges();
                return doc;
            }
            return false;
        }
        public dynamic AddNewGoDepart(Document document)
        {
            if (document.Address == null || document.Address == "")
            {
                Document doc = new Document
                {
                    Address = null,
                    Signer = document.Signer,
                    SignDate = document.SignDate,
                    ArrivalDate=null,
                    ExpirationDate = document.ExpirationDate,
                    Note = document.Note,
                    DocumentFile = document.DocumentFile,
                    Receiver = document.Receiver,
                    Sender = document.Sender,
                    TypeId = document.TypeId,
                    UrgencyId = document.UrgencyId,
                    StatusId = document.StatusId
                };
                var a = document.Departments.ToList();
                foreach (var item in a)
                {
                    var data = _context.Departments.Where(c => c.Id == item.Id);
                    doc.Departments.Add(data.FirstOrDefault());
                }
                _context.Documents.Update(doc);
                _context.SaveChanges();
                return doc;
            }
            return false;
        }

        public dynamic UpdateDocGo(Document document)
        {
            var data = _context.Documents.Include(c => c.Departments).FirstOrDefault(m => m.Id == document.Id);
            if (data == null)
            {
                return false;
            }
            data.Address = document.Address;
            data.Sender = document.Sender;
            data.Signer = document.Signer;
            data.SignDate = document.SignDate;
            data.ArrivalDate = null;
            data.ExpirationDate = document.ExpirationDate;
            data.Note = document.Note;
            data.DocumentFile = document.DocumentFile;
            data.Receiver = document.Receiver;
            data.TypeId = document.TypeId;
            data.UrgencyId = document.UrgencyId;
            data.StatusId = document.StatusId;
            var del = data.Departments.ToList();
            foreach (var i in del)
            {
                data.Departments.Remove(i);
            }
            _context.Update(data);
            _context.SaveChanges();
            var a = document.Departments.ToList();
            foreach (var item in a)
            {
                var data1 = _context.Departments.Where(c => c.Id == item.Id);
                data.Departments.Add(data1.FirstOrDefault());
            }
            _context.Update(data);
            _context.SaveChanges();
            return data;
        }
        public dynamic UpdateDocArrive(Document document)
        {
            var data = _context.Documents.Include(c => c.Profiles).FirstOrDefault(m => m.Id == document.Id);
            if (data == null)
            {
                return false;
            }
            data.Address = document.Address;
            data.Signer = document.Signer;
            data.SignDate = document.SignDate;
            data.ArrivalDate = document.ArrivalDate;
            data.ExpirationDate = document.ExpirationDate;
            data.Note = document.Note;
            data.DocumentFile = document.DocumentFile;
            data.Receiver = document.Receiver;
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
