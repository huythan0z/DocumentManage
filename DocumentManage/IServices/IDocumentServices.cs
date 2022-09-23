using DocumentManage.Models;

namespace DocumentManage.IServices
{
    public interface IDocumentServices
    {
        IQueryable<dynamic> GetDocGo();
        IQueryable<dynamic> GetDocArrive();
        dynamic AddNewGo(Document document);
        dynamic AddNewArrive(Document document);
        dynamic UpdateDocGo(Document document);
        dynamic UpdateDocArrive(Document document);
        dynamic Delete(Document document);
        dynamic GetType(Document document);
        dynamic GetUrgency(Document document);
    }
}
