using DocumentManage.Models;

namespace DocumentManage.IServices
{
    public interface IDocumentServices
    {
        IQueryable<dynamic> GetAll();
        dynamic AddNew(Document document);
        dynamic Update(Document document);
        dynamic Delete(Document document);
    }
}
