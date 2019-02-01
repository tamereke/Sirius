using Sirius.Core.Data;
using Sirius.Core.DependencyInjection;
using Sirius.Core.Models;
using Sirius.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Services.CoreService
{
    [ServiceRegister(RegisterTypes.PerLifetimeScope, typeof(ClaimService))]
    public interface IClaimService : IDatabaseEntityService<Claim>
    {
        void LoadClaims();
    }
}
