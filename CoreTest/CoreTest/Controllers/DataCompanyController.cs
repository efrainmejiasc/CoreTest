using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CoreTest.EngineClass;
using CoreTest.Models.Context;
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

        public DataCompanyController(EngineContext _context)
        {
            context = _context;
        }

        [Authorize]
        [HttpPost]
        [ActionName("CreateClient")]
        public HttpResponseMessage CreateClient ([FromBody] Company Client)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            if (!ModelState.IsValid )
            {
                response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return response;
            }
            EngineDb Metodo = new EngineDb();
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


       // [Authorize]
        [HttpGet]
        [ActionName("GetClient")]
        public string  GetClient (string NameCompany)
        {
            string response = EngineValue.NoData;
            if (NameCompany == string.Empty || NameCompany == null)
            {
                response = HttpStatusCode.BadRequest.ToString(); ;
                return response;
            }
            EngineDb Metodo = new EngineDb();
            Company client = new Company();
            client = Metodo.GetClient(NameCompany, context);
            if (client == null)
                return response;

            return JsonConvert.SerializeObject(client, Formatting.Indented);

            //return response = JsonConvert.SerializeObject(client);
        }

    }
}