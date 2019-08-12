using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CoreTest.Models.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreTestLogical;
using CoreTest.EngineClass;
using Microsoft.Extensions.Configuration;
using CoreTest.Models.System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CoreTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly EngineContext context;
        private IEngineDb Metodo;
        private IEngineLogical Funcion;

        public UserController(EngineContext _context, IEngineDb _Metodo,IEngineLogical _Funcion)
        {
            context = _context;
            Metodo = _Metodo;
            Funcion = _Funcion;
        }

        [AllowAnonymous]
        [HttpPost]
        [ActionName("CreateUser")]
        [Route("CreateUser")]
        public HttpResponseMessage CreateUser ([FromBody] UserApi user)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            if (user.Email == string.Empty || user.Password == string.Empty)
            {
                response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.Content = new StringContent(EngineValue.modeloImcompleto,Encoding.Unicode);
                return response;
            }
               
            bool resultado = false;
            resultado = Funcion.EmailEsValido(user.Email);
            if (!resultado)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(EngineValue.emailNoValido, Encoding.Unicode);
                return response;
            }
            resultado = Metodo.UserCreate(user,context,Funcion);
            if (!resultado)
            {
                response.Content = new StringContent(EngineValue.falloCrearUsuario, Encoding.Unicode);
            }
            else
            {
                response.Content = new StringContent(EngineValue.transaccionExitosa, Encoding.Unicode);
                response.Headers.Location = new Uri(EngineData.UrlBase + EngineValue.Login);
            }
               

            return response;
        }


        [AllowAnonymous]
        [HttpPost]
        [ActionName("Login")]
        [Route("Login")]
        public IActionResult Login([FromBody] Client login)
        {
            IActionResult response = Unauthorized();
            string password64 = Funcion.ConvertirBase64(login.Email + login.Password);
            UserApi user = Metodo.GetUser(password64,context,Funcion);
            if (user == null)
                return response;

            var tokenString = GenerateJSONWebToken(user);
            response = Ok(new { token = tokenString });
            return response;
        }


        private string GenerateJSONWebToken(UserApi userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(EngineData.JwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var KClaims = new[] {
                               new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                               new Claim(JwtRegisteredClaimNames.Birthdate, userInfo.CreateDate.ToString()),
                               new Claim("HoraToken", DateTime.UtcNow.ToString()),
                               new Claim(JwtRegisteredClaimNames.UniqueName, Guid.NewGuid().ToString())
            };

              var token = new JwtSecurityToken(
                              EngineData.JwtIssuer, 
                              EngineData.JwtAudience,
                              claims: KClaims,
                              expires: DateTime.UtcNow.AddMinutes(5),
                              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        [Authorize]
        [HttpPut]
        [ActionName("UpdateUser")]
        [Route("UpdateUser")]
        public HttpResponseMessage UpdateUser ([FromBody] Client user)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            if (user.Email == string.Empty || user.Password == string.Empty || user.NewPassword == string.Empty)
            {
                response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.Content = new StringContent(EngineValue.modeloImcompleto, Encoding.Unicode);
                return response;
            }
            bool resultado = Metodo.PutPasswordUser(user,context,Funcion);
            if (!resultado)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(EngineValue.noExisteUsuario, Encoding.Unicode);
                return response;
            }

            response.Content = new StringContent(EngineValue.transaccionExitosa, Encoding.Unicode);
            return response;
        }


        [Authorize]
        [HttpDelete]
        [ActionName("DeleteUser")]
        [Route("DeleteUser")]
        public HttpResponseMessage DeleteUser([FromBody] UserApi user)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            if (user.Email == string.Empty || user.Password == string.Empty)
            {
                response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.Content = new StringContent(EngineValue.modeloImcompleto, Encoding.Unicode);
                return response;
            }
            bool resultado = Metodo.DeleteUser(user, context,Funcion);
            if (!resultado)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(EngineValue.noExisteUsuario, Encoding.Unicode);
                return response;
            }

            response.Content = new StringContent(EngineValue.transaccionExitosa, Encoding.Unicode);
            return response;
        }

    }
}