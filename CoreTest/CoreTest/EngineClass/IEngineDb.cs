using CoreTest.Models.Context;
using CoreTest.Models.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTest.EngineClass
{
    public interface IEngineDb
    {
        bool DeleteClient(int id, EngineContext context);
        bool UserCreate(UserApi user, EngineContext context);
        bool DeleteUser(UserApi user, EngineContext context);
        bool PutClient(Company client, EngineContext context);
        UserApi GetUser(string password, EngineContext context);
        bool CreateClient(Company client, EngineContext context);
        bool PutPasswordUser(Client user, EngineContext context);
        Company GetClient(string nameCompany, EngineContext context);
    }
}
