using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineSecurityReport.Domain;
using SuHaFabric.Repository;

namespace MedicineSecurityReport.Domain
{
    public interface IReportRepository : IRepository<ReportEntity>
    {
    }
}
