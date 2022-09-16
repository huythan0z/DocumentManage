using DocumentManage.Models;

namespace DocumentManage.IServices
{
    public interface IProfileServices
    {
        IQueryable<dynamic> GetAll();
        dynamic AddNew(Profile profile);
        dynamic Update(Profile profile);
        dynamic Delete(Profile profile);
        dynamic GetPosition(Profile profile);
    }
}
