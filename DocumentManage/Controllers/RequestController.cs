using DocumentManage.IServices;
using DocumentManage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestServices _requestServices;
        public RequestController(IRequestServices requestServices)
        {
            _requestServices = requestServices;
        }
        [Route("All")]
        [HttpGet]
        public dynamic GetAll()
        {
            try
            {
                var data = _requestServices.GetAll();
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("AddNew")]
        [HttpPost]
        public dynamic AddNew(Request request)
        {
            try
            {
                _requestServices.AddNew(request);
                return Ok(request);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("update")]
        [HttpPut]
        public dynamic update(Request request)
        {
            try
            {
                var data = _requestServices.Update(request);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("Delete")]
        [HttpDelete]
        public dynamic Delete(Request request)
        {
            try
            {
                var data = _requestServices.Delete(request);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
