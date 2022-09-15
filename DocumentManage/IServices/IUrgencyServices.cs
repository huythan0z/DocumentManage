using DocumentManage.Models;

namespace DocumentManage.IServices
{
    public interface IUrgencyServices
    {
        IQueryable<dynamic> GetAll();
        dynamic AddNew(Urgency urgency);
        dynamic Update(Urgency urgency);
        dynamic Delete(Urgency urgency);
    }
}
