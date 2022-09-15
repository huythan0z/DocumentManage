using DocumentManage.Models;

namespace DocumentManage.IServices
{
    public interface IPositionServices
    {
        IQueryable<dynamic> GetAll();
        dynamic AddNew(Position position);
        dynamic Update(Position position);
        dynamic Delete(Position position);
    }
}
