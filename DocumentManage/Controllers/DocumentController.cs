using DocumentManage.IServices;
using DocumentManage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace DocumentManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentServices _documentServices;
        public DocumentController(IDocumentServices documentServices)
        {
            _documentServices = documentServices;
        }
        [Route("DocumentGo")]
        [HttpGet]
        public dynamic GetdocGo()
        {
            try
            {
                var data = _documentServices.GetDocGo();
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("DocumentArrive")]
        [HttpGet]
        public dynamic GetdocArrive()
        {
            try
            {
                var data = _documentServices.GetDocArrive();
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("AddNewGo")]
        [HttpPost]
        public dynamic AddNewGo(Models.Document document)
        {
            try
            {
                var data = _documentServices.AddNewGo(document);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("AddNewArrive")]
        [HttpPost]
        public dynamic AddNewArrive(Models.Document document)
        {

            try
            {
                var data = _documentServices.AddNewArrive(document);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("UpdateDocGo")]
        [HttpPut]
        public dynamic UpdateDocGo(Models.Document document)
        {
            try
            {
                var data = _documentServices.UpdateDocGo(document);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("UpdateDocArrive")]
        [HttpPut]
        public dynamic UpdateDocArrive(Models.Document document)
        {
            try
            {
                var data = _documentServices.UpdateDocArrive(document);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("Delete")]
        [HttpDelete]
        public dynamic Delete(Models.Document document)
        {
            try
            {
                var data = _documentServices.Delete(document);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("SearchByType")]
        [HttpPost]
        public dynamic GetType(Models.Document document)
        {
            try
            {
                var data = _documentServices.GetType(document);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("SearchByUrgency")]
        [HttpPost]
        public dynamic GetUr(Models.Document document)
        {
            try
            {
                var data = _documentServices.GetUrgency(document);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}
