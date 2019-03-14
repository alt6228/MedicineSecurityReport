using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineSecurityReport.Models
{
    public class NurseReportViewModel
    {
        public string Id { get; set; }
        public string NurseName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string ProfessionalTitle { get; set; }
        /// <summary>
        /// 能级
        /// </summary>
        public string AbilityLevel { get; set; }
        // <summary>
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
        /// 科室签字年
        /// </summary>
        public int OfficeSignYear { get; set; }
        /// <summary>
        /// 科室签字月
        /// </summary>
        public int OfficeSignMonth { get; set; }
        /// <summary>
        /// 科室签字日
        /// </summary>
        public int OfficeSignDay { get; set; }
        /// <summary>
        /// 护理部处理及整改意见
        /// </summary>
        public string NursingDepartmentImprovementMeasure { get; set; }
        /// <summary>
        /// 护理部签字年
        /// </summary>
        public int NursingDepartmentSignYear { get; set; }
        /// <summary>
        /// 护理部签字月
        /// </summary>
        public int NursingDepartmentSignMonth { get; set; }
        /// <summary>
        /// 护理部签字日
        /// </summary>
        public int NursingDepartmentSignDay { get; set; }
        public string DateCheckMessage
        {
            get
            {
                List<string> messageList = new List<string>();
                DateTime result;
                try
                {
                    if (!DateTime.TryParse($"{this.OccurrenceDateYear}-{this.OccurrenceDateMonth}-{this.OccurrenceDateDay} {this.OccurrenceDateHour}:{this.OccurrenceDateMinute}:00", out result))
                    {
                        messageList.Add("事件发生的时间不是有效的日期，请重新输入。");
                    }
                    if (!DateTime.TryParse($"{this.OfficeSignYear}-{this.OfficeSignMonth}-{this.OfficeSignDay}", out result))
                    {
                        messageList.Add("科室签字日期不是有效的日期，请重新输入。");
                    }
                    if (!DateTime.TryParse($"{this.NursingDepartmentSignYear}-{this.NursingDepartmentSignMonth}-{this.NursingDepartmentSignDay}", out result))
                    {
                        messageList.Add("护理部签字日期不是有效的日期，请重新输入。");
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
