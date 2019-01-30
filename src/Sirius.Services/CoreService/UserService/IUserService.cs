using Sirius.Core.Data;
using Sirius.Core.DependencyInjection;
using Sirius.Core.Models;
using Sirius.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Services.CoreService
{
    [ServiceRegister(RegisterTypes.PerLifetimeScope, typeof(UserService))]
    public interface IUserService : IDatabaseEntityService<User>
    {
        OperationResult<List<User>> GetUsers();
        OperationResult<User> GetUserById(int id);
        OperationResult<User> GetUserByUserName(string userName);
        bool IsPermitted(string lastChanged);
        List<Claim> GetClaims(int userId);
    }
}
