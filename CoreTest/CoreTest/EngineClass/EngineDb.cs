using CoreTest.Models.Context;
using CoreTest.Models.System;
using CoreTestLogical;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTest.EngineClass
{
    public class EngineDb 
    {
        public bool UserCreate (UserApi user , EngineContext context)
        {
            bool resultado = false;
            user.CreateDate = DateTime.UtcNow;
            EngineLogical Funcion = new EngineLogical();
            user.Password = Funcion.ConvertirBase64(user.Email + user.Password);
            try
            {
                using (context)
                {
                    context.UserApi.Add(user);
                    context.SaveChanges();
                }
                resultado = true;
            }
            catch  { }
            return resultado;
        }

        public UserApi GetUser (string password , EngineContext context)
        {
            UserApi user = null;
            try
            {
                using (context)
                {
                    user = context.UserApi.Where(s => s.Password == password).FirstOrDefault();
                    if (user != null)
                        return user;
                }
            }
            catch { }
            return null;
        }
   
        public bool PutPasswordUser (Client user,EngineContext context)
        {
            bool resultado = false;
            UserApi usuarioApi = null;
            EngineLogical Funcion = new EngineLogical();
            string password64 = Funcion.ConvertirBase64(user.Email + user.Password);
            try
            {
                using (context)
                {
                    usuarioApi = context.UserApi.Where(s => s.Password == password64).FirstOrDefault();
                    if(usuarioApi != null)
                    {
                        string newPassword64 = Funcion.ConvertirBase64(user.Email + user.NewPassword);
                        usuarioApi.Password = newPassword64;
                        context.SaveChanges();
                        resultado = true;
                    }
                }
            }
            catch { }
            return resultado;
        }

        public bool DeleteUser(UserApi user, EngineContext context)
        {
            bool resultado = false;
            UserApi usuarioApi = null;
            EngineLogical Funcion = new EngineLogical();
            string password = Funcion.ConvertirBase64(user.Email + user.Password);
            try
            {
                using (context)
                {
                    usuarioApi= context.UserApi.Where(s => s.Password == password).FirstOrDefault();
                    if (usuarioApi != null)
                    {
                        context.UserApi.Attach(usuarioApi);
                        context.UserApi.Remove(usuarioApi);
                        context.SaveChanges();
                        resultado = true;
                    }
                }
            }
            catch { }
            return resultado;
        }

        public bool CreateClient (Company client , EngineContext context)
        {
            bool resultado = false;
            EngineLogical Funcion = new EngineLogical();
            client.CreateDate = DateTime.UtcNow;
            client.TypeCompany = Funcion.TypeCompany(client.AnnualGross);
            try
            {
                using (context)
                {
                    context.Company.Add(client);
                    context.SaveChanges();
                    int id = client.Id;
                    if (client.Subsidiary != null)
                    {
                        foreach(Subsidiary item in client.Subsidiary)
                        {
                            item.CompanyId = id;
                            context.Subsidiary.Add(item);
                            context.SaveChanges();
                        }
                    }
                }
                resultado = true;
            }
            catch {}
            return resultado;
        }

        public Company GetClient (string nameCompany , EngineContext context)
        {
            Company client = null;
            try
            {
                using (context)
                {
                    client = context.Company.Where(s => s.NameCompany == nameCompany).FirstOrDefault();
                    if (client != null)
                        client.Subsidiary = context.Subsidiary.Where(s => s.CompanyId == client.Id).ToList();
                    return client;    
                }
            }
            catch { }
            return null;
        }
    }
}
