using DocumentManage.Models;

namespace DocumentManage.IServices
{
    public interface IwStatusServices
    {
        IQueryable<dynamic> GetAll();
        dynamic AddNew(WStatus wstatus);
        dynamic Update(WStatus wstatus);
        dynamic Delete(WStatus wstatus);
    }
}
