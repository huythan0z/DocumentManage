using DocumentManage.IServices;
using DocumentManage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileServices _profileServices;
        public ProfileController(IProfileServices profileServices)
        {
            _profileServices = profileServices;
        }
        [Route("All")]
        [HttpGet]
        public dynamic GetAll()
        {
            try
            {
                var data = _profileServices.GetAll();
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("AddNew")]
        [HttpPost]
        public dynamic AddNew(Profile profile)
        {
            try
            {
                _profileServices.AddNew(profile);
                return Ok(profile);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("Update")]
        [HttpPut]
        public dynamic Update(Profile profile)
        {
            try
            {
                var data = _profileServices.Update(profile);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("Delete")]
        [HttpDelete]
        public dynamic Delete(Profile profile)
        {
            try
            {
                var data = _profileServices.Delete(profile);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("SearchByPosition")]
        [HttpPost]
        public dynamic GetPosition(Profile profile)
        {
            try
            {
                var data = _profileServices.GetPosition(profile);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
