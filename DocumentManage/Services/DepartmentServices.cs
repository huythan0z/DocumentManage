using DocumentManage.IServices;
using DocumentManage.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentManage.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly DocumentManageContext _context;
        public DepartmentServices(DocumentManageContext context)
        {
            _context = context;
        }
        public IQueryable<dynamic> GetAll()
        {
            return _context.Departments.Include(c => c.Profiles);
        }
        public dynamic AddNew(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
            return department;
        }

        public dynamic Delete(Department department)
        {
            var data = _context.Departments.FirstOrDefault(m => m.Id == department.Id);
            if (data == null)
            {
                return false;
            }
            _context.Departments.Remove(data);
            _context.SaveChanges();
            return true;
        }

        public dynamic Update(Department department)
        {
            var data = _context.Departments.FirstOrDefault(m => m.Id == department.Id);
            if (data == null)
            {
                return false;
            }
            data.DepartmentName = department.DepartmentName;
            _context.Departments.Update(data);
            _context.SaveChanges();
            return true;
        }
    }
}
