using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MedicineSecurityReport.Models;
using MedicineSecurityReport.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace MedicineSecurityReport.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IReportRepository _reportRepository;
        public HomeController(IReportRepository reportRepository,
            IMapper mapper)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }
        [Authorize]
        public async Task<IActionResult> Index(int? page, string PatientName = "",string MedicalDepartment="",string HospitalNumber="")
        {
            int pageNumber = page ?? 1;
            ViewBag.page = pageNumber;
            int recordPerPage = 10;
            ViewBag.recordPerPage = recordPerPage;
            var reportList = new List<ReportViewModel>();
            IEnumerable<ReportEntity> entities = null;
            try
            {
                entities = await _reportRepository.GetAllAsync();
            }
            catch
            {
            }
            reportList = _mapper.Map<List<ReportViewModel>>(entities);
            if(!string.IsNullOrEmpty(PatientName))
            {
                reportList = reportList.Where(p => p.PatientName.Contains(PatientName)).ToList();
            }
            if (!string.IsNullOrEmpty(MedicalDepartment))
            {
                reportList = reportList.Where(p => p.MedicalDepartment.Contains(MedicalDepartment)).ToList();
            }
            if (!string.IsNullOrEmpty(HospitalNumber))
            {
                reportList = reportList.Where(p => p.HospitalNumber.Contains(HospitalNumber)).ToList();
            }
            ViewBag.totalRecord = reportList.Count();
            ViewBag.totalPage = (int)Math.Ceiling((double)reportList.Count() / (double)recordPerPage);
            reportList = reportList.Skip((int)(pageNumber - 1) * recordPerPage).Take(recordPerPage).ToList();
            ViewBag.PatientName = PatientName;
            ViewBag.MedicalDepartment = MedicalDepartment;
            ViewBag.HospitalNumber = HospitalNumber;
            return View(reportList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 新增医疗质量安全报告
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> Create(ReportViewModel model)
        {
            string message = string.Empty;
            if (ModelState.IsValid)
            {
                if(!string.IsNullOrEmpty(model.DateCheckMessage))
                {
                    return Json(new { Success = false,Message= model.DateCheckMessage });
                }
                try
                {
                    var entity = _mapper.Map<ReportEntity>(model);
                    if (string.IsNullOrEmpty(model.Id))
                    {
                        entity.Id = Guid.NewGuid().ToString();
                        await _reportRepository.InsertAsync(entity);
                    }
                    else
                    {
                        await _reportRepository.UpdateAsync(entity);
                    }
                    return Json(new { Success = true, Message = "保存成功！" });
                }
                catch
                {
                    return Json(new { Success = false, Message = "保存失败！" });
                }
            }
            return Json(new { Success = false, Message = "保存失败！" });
        }
        

        public async Task<IActionResult> Detail(string id)
        {
            var vm = new ReportViewModel();
            ReportEntity entity = null;
            try
            {
                entity = await _reportRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
            }
            vm = _mapper.Map<ReportViewModel>(entity);
            return View(vm);
        }
        public async Task<IActionResult> Delete(string id)
        {
            var vm = new ReportViewModel();
            ReportEntity entity = null;
            try
            {
                entity = await _reportRepository.GetByIdAsync(id);
                await _reportRepository.DeleteAsync(entity);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(string id)
        {
            var vm = new ReportViewModel();
            ReportEntity entity = null;
            try
            {
                entity = await _reportRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
            }
            vm = _mapper.Map<ReportViewModel>(entity);
            return View(vm);
        }
    }
}
