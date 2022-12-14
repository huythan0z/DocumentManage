using DocumentManage.IServices;
using DocumentManage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrgencyController : ControllerBase
    {
        private readonly IUrgencyServices _urgencyServices;
        public UrgencyController(IUrgencyServices urgencyServices)
        {
            _urgencyServices = urgencyServices;
        }
        [Route("All")]
        [HttpGet]
        public dynamic GetAll()
        {
            try
            {
                var data = _urgencyServices.GetAll();
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("AddNew")]
        [HttpPost]
        public dynamic AddNew(Urgency urgency)
        {
            try
            {
                _urgencyServices.AddNew(urgency);
                return Ok(urgency);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("Update")]
        [HttpPut]
        public dynamic Update(Urgency urgency)
        {
            try
            {
                var data = _urgencyServices.Update(urgency);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("Delete")]
        [HttpDelete]
        public dynamic Delete(Urgency urgency)
        {
            try
            {
                var data = _urgencyServices.Delete(urgency);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}

