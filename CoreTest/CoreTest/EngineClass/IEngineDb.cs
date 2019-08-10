using CoreTest.Models.Context;
using CoreTest.Models.System;
using CoreTestLogical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTest.EngineClass
{
    public interface IEngineDb
    {
        bool DeleteClient(int id, EngineContext context);
        bool UserCreate(UserApi user, EngineContext context, IEngineLogical funcion);
        bool DeleteUser(UserApi user, EngineContext context, IEngineLogical funcion);
        bool PutClient(Company client, EngineContext context, IEngineLogical funcion);
        UserApi GetUser(string password, EngineContext context, IEngineLogical funcion);
        bool CreateClient(Company client, EngineContext context, IEngineLogical funcion);
        bool PutPasswordUser(Client user, EngineContext context, IEngineLogical funcion);
        Company GetClient(string nameCompany, EngineContext context);
    }
}
