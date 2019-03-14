using AutoMapper;
using MedicineSecurityReport.Domain;
using MedicineSecurityReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineSecurityReport.Common
{
    public class MyProfile : Profile
    {
        public MyProfile()
        {
            
            CreateMap<ReportViewModel, ReportEntity>()
                .ForMember(des => des.ReportDate, op => op.MapFrom(vm => new DateTime(vm.ReportYear,vm.ReportMonth,vm.ReportDay,vm.ReportHour,vm.ReportMinute,0)))
                .ForMember(des => des.OccurrenceDate, op => op.MapFrom(vm => new DateTime(vm.OccurrenceDateYear, vm.OccurrenceDateMonth, vm.OccurrenceDateDay, vm.OccurrenceDateHour, vm.OccurrenceDateMinute, 0)))
                .ForMember(des => des.CurativeTime, op => op.MapFrom(vm => new DateTime(vm.CurativeTimeYear, vm.CurativeTimeMonth, vm.CurativeTimeDay, vm.CurativeTimeHour, vm.CurativeTimeMinute, 0)));
            CreateMap<ReportEntity, ReportViewModel>()
                .ForMember(des => des.ReportYear, op => op.MapFrom(md => md.ReportDate.Year))
                .ForMember(des => des.ReportMonth, op => op.MapFrom(md => md.ReportDate.Month))
                .ForMember(des => des.ReportDay, op => op.MapFrom(md => md.ReportDate.Day))
                .ForMember(des => des.ReportHour, op => op.MapFrom(md => md.ReportDate.Hour))
                .ForMember(des => des.ReportMinute, op => op.MapFrom(md => md.ReportDate.Minute))
                .ForMember(des => des.OccurrenceDateYear, op => op.MapFrom(md => md.OccurrenceDate.Year))
                .ForMember(des => des.OccurrenceDateMonth, op => op.MapFrom(md => md.OccurrenceDate.Month))
                .ForMember(des => des.OccurrenceDateDay, op => op.MapFrom(md => md.OccurrenceDate.Day))
                .ForMember(des => des.OccurrenceDateHour, op => op.MapFrom(md => md.OccurrenceDate.Hour))
                .ForMember(des => des.OccurrenceDateMinute, op => op.MapFrom(md => md.OccurrenceDate.Minute));

            CreateMap<NurseReportViewModel, NurseReportEntity>()
               .ForMember(des => des.OccurrenceDate, op => op.MapFrom(vm => new DateTime(vm.OccurrenceDateYear, vm.OccurrenceDateMonth, vm.OccurrenceDateDay, vm.OccurrenceDateHour, vm.OccurrenceDateMinute, 0)))
               .ForMember(des => des.OfficeSignDate, op => op.MapFrom(vm => new DateTime(vm.OfficeSignYear, vm.OfficeSignMonth, vm.OfficeSignDay)))
               .ForMember(des => des.NursingDepartmentSignDate, op => op.MapFrom(vm => new DateTime(vm.NursingDepartmentSignYear, vm.NursingDepartmentSignMonth, vm.NursingDepartmentSignDay)));
            CreateMap<NurseReportEntity, NurseReportViewModel>()
                .ForMember(des => des.OfficeSignYear, op => op.MapFrom(md => md.OfficeSignDate.Year))
                .ForMember(des => des.OfficeSignMonth, op => op.MapFrom(md => md.OfficeSignDate.Month))
                .ForMember(des => des.OfficeSignDay, op => op.MapFrom(md => md.OfficeSignDate.Day))
                .ForMember(des => des.NursingDepartmentSignYear, op => op.MapFrom(md => md.NursingDepartmentSignDate.Year))
                .ForMember(des => des.NursingDepartmentSignMonth, op => op.MapFrom(md => md.NursingDepartmentSignDate.Month))
                .ForMember(des => des.NursingDepartmentSignDay, op => op.MapFrom(md => md.NursingDepartmentSignDate.Day))
                .ForMember(des => des.OccurrenceDateYear, op => op.MapFrom(md => md.OccurrenceDate.Year))
                .ForMember(des => des.OccurrenceDateMonth, op => op.MapFrom(md => md.OccurrenceDate.Month))
                .ForMember(des => des.OccurrenceDateDay, op => op.MapFrom(md => md.OccurrenceDate.Day))
                .ForMember(des => des.OccurrenceDateHour, op => op.MapFrom(md => md.OccurrenceDate.Hour))
                .ForMember(des => des.OccurrenceDateMinute, op => op.MapFrom(md => md.OccurrenceDate.Minute));
        }
    }
}