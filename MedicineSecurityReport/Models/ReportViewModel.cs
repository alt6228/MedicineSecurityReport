using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineSecurityReport.Models
{
    public class ReportViewModel
    {
        public string Id { get; set; }
        /// <summary>
        /// 报告日期年
        /// </summary>
        public int ReportYear { get; set; }
        /// <summary>
        /// 报告日期月
        /// </summary>
        public int ReportMonth { get; set; }
        /// <summary>
        /// 报告日期天
        /// </summary>
        public int ReportDay { get; set; }
        /// <summary>
        /// 报告日期时
        /// </summary>
        public int ReportHour { get; set; }
        /// <summary>
        /// 报告日期分
        /// </summary>
        public int ReportMinute { get; set; }

        /// <summary>
        /// 发生日期年
        /// </summary>
        public int OccurrenceDateYear { get; set; }
        /// <summary>
        /// 发生日期月
        /// </summary>
        public int OccurrenceDateMonth { get; set; }
        /// <summary>
        /// 发生日期天
        /// </summary>
        public int OccurrenceDateDay { get; set; }
        /// <summary>
        /// 发生日期时
        /// </summary>
        public int OccurrenceDateHour { get; set; }
        /// <summary>
        /// 发生日期分
        /// </summary>
        public int OccurrenceDateMinute { get; set; }
        public string PatientName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string Job { get; set; }
        public string Address { get; set; }
        public string MedicalDepartment { get; set; }
        public string BedNum { get; set; }
        public string HospitalNumber { get; set; }

        /// <summary>
        /// 诊疗时间年
        /// </summary>
        public int CurativeTimeYear { get; set; }
        /// <summary>
        /// 诊疗时间月
        /// </summary>
        public int CurativeTimeMonth { get; set; }
        /// <summary>
        /// 诊疗时间天
        /// </summary>
        public int CurativeTimeDay { get; set; }
        /// <summary>
        /// 诊疗时间时
        /// </summary>
        public int CurativeTimeHour { get; set; }
        /// <summary>
        /// 诊疗时间分
        /// </summary>
        public int CurativeTimeMinute { get; set; }
        /// <summary>
        /// 临床诊断
        /// </summary>
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
        public string DateCheckMessage
        {
            get
            {
                List<string> messageList = new List<string>();
                DateTime result;
                try
                { 
                if (!DateTime.TryParse($"{this.ReportYear}-{this.ReportMonth}-{this.ReportDay} {this.ReportHour}:{this.ReportMinute}:00", out result))
                {
                    messageList.Add("报告日期不是有效的日期，请重新输入。");
                }
                if (!DateTime.TryParse($"{this.OccurrenceDateYear}-{this.OccurrenceDateMonth}-{this.OccurrenceDateDay} {this.OccurrenceDateHour}:{this.OccurrenceDateMinute}:00", out result))
                {
                    messageList.Add("事件发生日期不是有效的日期，请重新输入。");
                }
                if (!DateTime.TryParse($"{this.CurativeTimeYear}-{this.CurativeTimeMonth}-{this.CurativeTimeDay} {this.CurativeTimeHour}:{this.CurativeTimeMinute}:00", out result))
                {
                    messageList.Add("诊疗时间不是有效的日期，请重新输入。");
                }
                    return string.Join("<br>", messageList);
                }
                catch
                {
                    return "日期输入错误，请检查并重新输入。";
                }
            }

        }
    }
}
