using DocumentManage.IServices;
using DocumentManage.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging.Abstractions;
using System.Data;

namespace DocumentManage.Services
{
    public class RequestServices : IRequestServices
    {
        private readonly DocumentManageContext _context;
        public RequestServices(DocumentManageContext context)
        {
            _context = context;
        }
        
    }
}