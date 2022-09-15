using DocumentManage.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DocumentManage.Models;
using Type = DocumentManage.Models.Type;

namespace DocumentManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly ITypeServices _typeServices;
        public TypeController(ITypeServices typeServices)
        {
            _typeServices = typeServices;
        }
        [Route("All")]
        [HttpGet]
        public dynamic GetAll()
        {
            try
            {
                var data = _typeServices.GetAll();
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("AddNew")]
        [HttpPost]
        public dynamic AddNew(Type type)
        {
            try
            {
                _typeServices.AddNew(type);
                return Ok(type);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("Update")]
        [HttpPut]
        public dynamic Update(Type type)
        {
            try
            {
                var data = _typeServices.Update(type);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("Delete")]
        [HttpDelete]
        public dynamic Delete(Type type)
        {
            try
            {
                var data = _typeServices.Delete(type);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
