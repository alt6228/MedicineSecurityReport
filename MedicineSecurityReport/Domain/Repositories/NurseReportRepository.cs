using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineSecurityReport.Domain;
using SuHaFabric.Repository.Dapper;

namespace MedicineSecurityReport.Domain
{
    public class NurseReportRepository : DapperRepository<NurseReportEntity>, INurseReportRepository
    {
        public NurseReportRepository(DapperDBContext context) : base(context)
        {
        }
    }
}
