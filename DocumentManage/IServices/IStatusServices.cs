using DocumentManage.Models;

namespace DocumentManage.IServices
{
    public interface IStatusServices
    {
        IQueryable<dynamic> GetAll();
        dynamic AddNew(Status status);
        dynamic Update(Status status);
        dynamic Delete(Status status);
    }
}
