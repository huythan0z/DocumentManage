using DocumentManage.Models;
using Type = DocumentManage.Models.Type;

namespace DocumentManage.IServices
{
    public interface ITypeServices
    {
        IQueryable<dynamic> GetAll();
        dynamic AddNew(Type type);
        dynamic Update(Type type);
        dynamic Delete(Type type);
    }
}
