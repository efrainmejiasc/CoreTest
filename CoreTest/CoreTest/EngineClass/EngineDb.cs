using CoreTest.Models.Context;
using CoreTest.Models.System;
using CoreTestLogical;
using System;
using System.Collections.Generic;
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
            catch (Exception ex)
            {
            }
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
    }
}
