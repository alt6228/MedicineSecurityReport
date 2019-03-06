using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SuHaFabric.Repository.Dapper;

namespace MedicineSecurityReport.Domain
{
    public class ReportDBContext : DapperDBContext
    {
        public ReportDBContext(IOptions<DapperDBContextOptions> optionsAccessor)
            : base(optionsAccessor)
        {
        }

        protected override IDbConnection CreateConnection(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException(nameof(connectionString));

            return new SqlConnection(connectionString);
        }
    }
}
