using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace MedicineSecurityReport.Domain
{

    [Table("NurseSecurityReport")]
    public class NurseReportEntity
    {
        [ExplicitKey]
        public string Id { get; set; }
        public string NurseName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string ProfessionalTitle { get; set; }
        /// <summary>
        /// 能级
        /// </summary>
        public string AbilityLevel { get; set; }
        /// <summary>
        /// 发生日期
        /// </summary>
        public DateTime OccurrenceDate { get; set; }
        /// <summary>
        /// 贵宾
        /// </summary>
        public string DistinguishedGuests { get; set; }
        public string GuestsSex { get; set; }
        public int GuestsAge { get; set; }
        public string Job { get; set; }
        public string HospitalNumber { get; set; }
        public string OccurrencePlace { get; set; }
        public string MainDiagnoses { get; set; }
        public string EventsLevel { get; set; }
        /// <summary>
        /// 次要责任人
        /// </summary>
        public string MinorChargePerson { get; set; }
        /// <summary>
        /// 事件发生的过程及采取的措施
        /// </summary>
        public string EventsCourseHandleSituations { get; set; }
        /// <summary>
        /// 分析定性
        /// </summary>
        public string QualitativeAnalysis { get; set; }
        /// <summary>
        /// 科室处理及整改意见
        /// </summary>
        public string OfficeImprovementMeasure { get; set; }
        /// <summary>
        /// 科室签字日期
        /// </summary>
        public DateTime OfficeSignDate { get; set; }
        /// <summary>
        /// 护理部处理及整改意见
        /// </summary>
        public string NursingDepartmentImprovementMeasure { get; set; }
        /// <summary>
        /// 护理部签字日期
        /// </summary>
        public DateTime NursingDepartmentSignDate { get; set; }
    }
}
