using DocumentManage.IServices;
using DocumentManage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionServices _positionServices;
        public PositionController(IPositionServices positionServices)
        {
            _positionServices = positionServices;
        }
        [Route("All")]
        [HttpGet]
        public dynamic GetAll()
        {
            try
            {
                var data = _positionServices.GetAll();
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("AddNew")]
        [HttpPost]
        public dynamic AddNew(Position position)
        {
            try
            {
                _positionServices.AddNew(position);
                return Ok(position);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("Update")]
        [HttpPut]
        public dynamic Update(Position position)
        {
            try
            {
                var data = _positionServices.Update(position);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("Delete")]
        [HttpDelete]
        public dynamic Delete(Position position)
        {
            try
            {
                var data = _positionServices.Delete(position);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
