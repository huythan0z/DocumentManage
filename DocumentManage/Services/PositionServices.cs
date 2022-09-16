using DocumentManage.IServices;
using DocumentManage.Models;

namespace DocumentManage.Services
{
    public class PositionServices : IPositionServices
    {
        private readonly DocumentManageContext _context;
        public PositionServices(DocumentManageContext context)
        {
            _context = context;
        }

        public IQueryable<dynamic> GetAll()
        {
            return _context.Positions;
        }
        public dynamic AddNew(Position position)
        {
            _context.Positions.Add(position);
            _context.SaveChanges();
            return position;
        }
        public dynamic Update(Position position)
        {
            var data = _context.Positions.FirstOrDefault(m => m.Id == position.Id);
            if (data == null)
            {
                return false;
            }
            data.Positionn = position.Positionn;
            _context.Positions.Update(data);
            _context.SaveChanges();
            return true;
        }
        public dynamic Delete(Position position)
        {
            var data = _context.Positions.FirstOrDefault(m => m.Id == position.Id);
            if (data == null)
            {
                return false;
            }
            _context.Positions.Remove(data);
            _context.SaveChanges();
            return true;
        }
    }
}
