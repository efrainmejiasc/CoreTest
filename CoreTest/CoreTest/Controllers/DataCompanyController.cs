using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CoreTest.EngineClass;
using CoreTest.Models.Context;
using CoreTest.Models.System;
using CoreTestLogical;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataCompanyController : ControllerBase
    {
        private readonly EngineContext context;
        private IEngineDb Metodo;

        public DataCompanyController(EngineContext _context,IEngineDb _Metodo)
        {
            context = _context;
            Metodo = _Metodo;
        }

        [Authorize]
        [HttpPost]
        [ActionName("CreateClient")]
        [Route("CreateClient")]
        public HttpResponseMessage CreateClient ([FromBody] Company Client)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            if (!ModelState.IsValid )
            {
                response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return response;
            }
           
            bool resultado = Metodo.CreateClient(Client, context);
            if (!resultado)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return response;
            }

            response.Content = new StringContent(EngineValue.transaccionExitosa, Encoding.Unicode);
            response.Headers.Location = new Uri(EngineData.UrlBase + EngineValue.Client);
            return response;
        }


        [Authorize]
        [HttpGet]
        [ActionName("GetClient")]
        [Route("GetClient")]
        public string  GetClient (string NameCompany)
        {
            string response = EngineValue.NoData;
            if (NameCompany == string.Empty || NameCompany == null)
            {
                response = HttpStatusCode.BadRequest.ToString(); ;
                return response;
            }
            Company client = new Company();
            client = Metodo.GetClient(NameCompany, context);
            if (client == null)
                return response;

            return JsonConvert.SerializeObject(client, Formatting.Indented);

        }


        [Authorize]
        [HttpPut]
        [ActionName("UpdateClient")]
        [Route("UpdateClient")]
        public HttpResponseMessage UpdateClient([FromBody] Company client)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            if (!ModelState.IsValid)
            {
                response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return response;
            }
            bool resultado = Metodo.PutClient(client, context);
            if (!resultado)
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError);

            response.Headers.Location = new Uri(EngineData.UrlBase + EngineValue.Client);
            return response;
        }

        [Authorize]
        [HttpDelete]
        [ActionName("DeleteClient")]
        [Route("DeleteClient")]
        public HttpResponseMessage DeleteClient([FromBody]Client Ide)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            if (Ide.Id <= 0)
            {
                response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return response;
            }
            Company client = new Company();
            bool resultado = Metodo.DeleteClient(Ide.Id, context);
            if (!resultado)
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError);

            response.Headers.Location = new Uri(EngineData.UrlBase + EngineValue.Client);
            return response;
        }

    }
}