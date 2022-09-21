using DocumentManage.IServices;
using DocumentManage.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using System.Security.Cryptography.Xml;
using System.Linq;

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
            var items = _context.Profiles.Include(u => u.Documents);
            var output = from item in items
                         select new
                         {
                             item.Id,
                             item.Name,
                             item.Address,
                             item.PhoneNumber,
                             item.Email,
                             item.Password,
                             item.Position.Positionn,
                         
                             document = from d in item.Documents
                                       select new
                                       {
                                           d.Id,
                                           d.Sender,
                                           d.DateSend,
                                           d.Receiver,
                                           d.Deadline,
                                           d.Note,
                                           d.DocumentFile,
                                           d.Type.DocumentType,
                                           d.Urgency.Urgencyy,
                                           d.Status.Statuss
                                       }
                         };
            return output;
        }
        public dynamic AddNew(Profile profile)
        {
            if (profile.PhoneNumber.All(char.IsDigit))
            {
                _context.Profiles.Add(profile);
                _context.SaveChanges();
                return profile;
            }
            else
            {
                return false;
            }
        }
        public dynamic Update(Profile profile)
        {       
            var check = _context.Profiles.Where(c => c.PhoneNumber == profile.PhoneNumber);
            if (profile.PhoneNumber.All(char.IsDigit))
            {
                //profile.PhoneNumber.All(char.IsDigit);
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
                _context.Profiles.Update(data);
                _context.SaveChanges();
                return data;
            }
            else
            {
                return false;
            }
        }
        public dynamic Delete(Profile profile)
        {
            var data = _context.Profiles.FirstOrDefault(m => m.Id == profile.Id);
            if (data == null)
            {
                return false;
            }
            _context.Profiles.Remove(data);
            _context.SaveChanges();
            return true;
        }
        public dynamic GetPosition(Profile profile)
        {
            var data = _context.Profiles.Where(m => m.PositionId == profile.PositionId);
            return data.Select(m => new
            {
                m.Name,
                m.Address,
                m.PhoneNumber,
                m.Email,
                m.Position.Positionn
            });
        }
        public dynamic Login(Profile profile)
        {
            var data = _context.Profiles.FirstOrDefault(m => m.Email == profile.Email 
                                                      && m.Password == profile.Password);
            if (data == null)
            {
                return false;
            }
            return data;
        }
    }
}
