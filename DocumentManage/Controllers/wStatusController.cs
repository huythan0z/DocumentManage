using DocumentManage.IServices;
using DocumentManage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace DocumentManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class wStatusController : ControllerBase
    {
        private readonly IwStatusServices _wstatusServices;
        public wStatusController(IwStatusServices wstatusServices)
        {
            _wstatusServices = wstatusServices;
        }
        [Route("All")]
        [HttpGet]
        public dynamic GetAll()
        {
            try
            {
                var data = _wstatusServices.GetAll();
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("AddNew")]
        [HttpPost]
        public dynamic AddNew(WStatus wstatus)
        {
            try
            {
                _wstatusServices.AddNew(wstatus);
                return Ok(wstatus);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("Update")]
        [HttpPut]
        public dynamic Update(WStatus wstatus)
        {
            try
            {
                var data = _wstatusServices.Update(wstatus);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("Delete")]
        [HttpDelete]
        public dynamic Delete(WStatus wstatus)
        {
            try
            {
                var data = _wstatusServices.Delete(wstatus);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
