using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Sirius.Core;
using Sirius.Core.Data;
using Sirius.Core.Models;
using Sirius.Data;
using Sirius.Entities;
using Sirius.Entities.Models;
using Sirius.Services.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Sirius.Services.CoreService
{
    public class ClaimService : DatabaseEntityService<Claim>, IClaimService
    {
        private readonly IAppLogger<ClaimService> _logger;
        private readonly IMainRepository<Claim> _claimRepository;
        private readonly MainContext _mainContext;

        public ClaimService(IAppLogger<ClaimService> logger
            , IMainRepository<Claim> claimRepository
            , MainContext mainContext)
            : base(claimRepository, logger)
        {
            _logger = logger;
            _claimRepository = claimRepository;
            _mainContext = mainContext;
        }

        public void LoadClaims()
        {
            var claimTypes = new List<Type>();
            FillClaimTypes(typeof(ClaimConst), claimTypes);


            var sb = new StringBuilder();
            sb.AppendLine(@"CREATE TABLE #tmp_claim
(
    [name] VARCHAR(500)
)");

            for (int i = 0; i < claimTypes.Count; i++)
            {
                var fInfo = claimTypes[i].GetFields();
                if (fInfo == null)
                    continue;
                for (int j = 0; j < fInfo.Count(); j++)
                {
                    var info = fInfo[j];
                    var val = info.GetValue(null);
                    sb.AppendLine($"insert into #tmp_claim values('{val}')");
                }
            }

            sb.AppendLine(@"insert into dbo.Claims
select tc.name from #tmp_claim tc where tc.name not in (select c.name from dbo.Claims c)

DROP TABLE #tmp_claim");
             

            _mainContext.ExecuteSqlCommand(new RawSqlString(sb.ToString()), timeout: 5000);
        }

        static void FillClaimTypes(Type type, List<Type> result)
        {
            result.Add(type);
            var types = type.GetNestedTypes();
            if (types == null || types.Length == 0)
                return;
            for (int i = 0; i < types.Length; i++)
                FillClaimTypes(types[i], result);
        }


    }
}
