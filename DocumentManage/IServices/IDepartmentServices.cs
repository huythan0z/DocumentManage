using DocumentManage.Models;

namespace DocumentManage.IServices
{
    public interface IDepartmentServices
    {
        IQueryable<dynamic> GetAll();
        dynamic AddNew(Department department);
        dynamic Update(Department department);
        dynamic Delete(Department department);
    }
}
