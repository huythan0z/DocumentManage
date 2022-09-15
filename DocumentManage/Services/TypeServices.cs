using DocumentManage.IServices;
using DocumentManage.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentManage.Services
{
    public class TypeServices : ITypeServices

    {
        private readonly DocumentManageContext _context;
        public TypeServices(DocumentManageContext context)
        {
            _context = context;
        }

        public IQueryable<dynamic> GetAll()
        {
            return _context.Types.Include(c => c.Documents);
        }
        public dynamic AddNew(Models.Type type)
        {
            _context.Types.Add(type);
            _context.SaveChanges();
            return type;
        }
        public dynamic Update(Models.Type type)
        {
            var data = _context.Types.FirstOrDefault(m => m.TypeId == type.TypeId);
            if (data == null)
            {
                return false;
            }
            data.DocumentType = type.DocumentType;
            _context.Types.Update(data);
            _context.SaveChanges();
            return true;
        }
        public dynamic Delete(Models.Type type)
        {
            var data = _context.Types.FirstOrDefault(m => m.TypeId == type.TypeId);
            if (data == null)
            {
                return false;
            }
            _context.Types.Remove(data);
            _context.SaveChanges();
            return true;
        }

        //public dynamic AddNew(System.Type type)
        //{
        //    throw new NotImplementedException();
        //}

        //public dynamic Update(System.Type type)
        //{
        //    throw new NotImplementedException();
        //}

        //public dynamic Delete(System.Type type)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
