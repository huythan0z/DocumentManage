using DocumentManage.Models;

namespace DocumentManage.IServices
{
    public interface IDocumentServices
    {
        IQueryable<dynamic> GetAll();
        IQueryable<dynamic> GetDocGo();
        IQueryable<dynamic> GetDocArrive();
        dynamic AddNewGoDepart(Document document);
        dynamic AddNewGoOut(Document document);
        dynamic AddNewGoProfile(Document document);
        dynamic AddNewArrive(Document document);
        dynamic UpdateDocGo(Document document);
        dynamic UpdateDocArrive(Document document);
        dynamic Delete(Document document);
        dynamic GetType(Document document);
        dynamic GetUrgency(Document document);
    }
}
