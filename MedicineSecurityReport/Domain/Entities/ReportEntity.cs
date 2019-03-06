using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace MedicineSecurityReport.Domain
{
    [Table("MedicineSecurityReport")]
    public class ReportEntity
    {
        [ExplicitKey]
        public string Id { get; set; }
        /// <summary>
        /// 报告日期
        /// </summary>
        public DateTime ReportDate { get; set; }
        /// <summary>
        /// 发生日期
        /// </summary>
        public DateTime OccurrenceDate { get; set; }
        public string PatientName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string Job { get; set; }
        public string Address { get; set; }
        public string MedicalDepartment { get; set; }
        public string BedNum { get; set; }
        public string HospitalNumber { get; set; }
        /// <summary>
        /// 诊疗时间
        /// </summary>
        public DateTime CurativeTime { get; set; }
        public string ClinicalDiagnosis { get; set; }
        public string OccurrencePlace { get; set; }
        public string BadResult { get; set; }
        public string BedResultDescription { get; set; }
        public string EventsCourse { get; set; }
        public string BadEventsType { get; set; }
        public string HandleSituations { get; set; }
        /// <summary>
        /// 不良事件评价
        /// </summary>
        public string EventsEvaluate { get; set; } = string.Empty;
        public string EventsLevel { get; set; }
        public string Reason { get; set; }
        /// <summary>
        /// 主管意见
        /// </summary>
        public string SupervisorOpinion { get; set; }
        /// <summary>
        /// 改进措施
        /// </summary>
        public string ImprovementMeasure { get; set; }
        public string ReportPersonType { get; set; }
        public string ClientType { get; set; }
        public string ProfessionalTitle { get; set; }
        public string ReportPersonName { get; set; }
        public string ReportAdministrativeOffice { get; set; }
        public string ReportContactPhoneNum { get; set; }
    }
}
