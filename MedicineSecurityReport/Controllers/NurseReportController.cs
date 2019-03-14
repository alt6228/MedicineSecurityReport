using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MedicineSecurityReport.Models;
using MedicineSecurityReport.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using MedicineSecurityReport.Common;

namespace MedicineSecurityReport.Controllers
{
    public class NurseReportController : Controller
    {
        private readonly IMapper _mapper;
        private readonly INurseReportRepository _nurseReportRepository;
        public NurseReportController(INurseReportRepository nurseReportRepository,
            IMapper mapper)
        {
            _nurseReportRepository = nurseReportRepository;
            _mapper = mapper;
        }
        [Authorize]
        public async Task<IActionResult> Index(int? page, string distinguishedGuests = "", string nurseName = "", string hospitalNumber = "")
        {
            int pageNumber = page ?? 1;
            ViewBag.page = pageNumber;
            int recordPerPage = 10;
            ViewBag.recordPerPage = recordPerPage;
            var nurseReportList = new List<NurseReportViewModel>();
            IEnumerable<NurseReportEntity> entities = null;
            try
            {
                entities = await _nurseReportRepository.GetAllAsync();
            }
            catch
            {
            }
            nurseReportList = _mapper.Map<List<NurseReportViewModel>>(entities);
            if (!string.IsNullOrEmpty(distinguishedGuests))
            {
                nurseReportList = nurseReportList.Where(p => p.DistinguishedGuests.Contains(distinguishedGuests)).ToList();
            }
            if (!string.IsNullOrEmpty(nurseName))
            {
                nurseReportList = nurseReportList.Where(p => p.NurseName.Contains(nurseName)).ToList();
            }
            if (!string.IsNullOrEmpty(hospitalNumber))
            {
                nurseReportList = nurseReportList.Where(p => p.HospitalNumber.Contains(hospitalNumber)).ToList();
            }
            ViewBag.totalRecord = nurseReportList.Count();
            ViewBag.totalPage = (int)Math.Ceiling((double)nurseReportList.Count() / (double)recordPerPage);
            nurseReportList = nurseReportList.Skip((int)(pageNumber - 1) * recordPerPage).Take(recordPerPage).ToList();
            ViewBag.DistinguishedGuests = distinguishedGuests;
            ViewBag.NurseName = nurseName;
            ViewBag.HospitalNumber = hospitalNumber;
            ViewBag.AllowedMD = SiteConfig.GetSite("MD");
            return View(nurseReportList);
        }

        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 新增护理不良事件讨论改进记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> Create(NurseReportViewModel model)
        {
            string message = string.Empty;
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.DateCheckMessage))
                {
                    return Json(new { Success = false, Message = model.DateCheckMessage });
                }
                try
                {
                    var entity = _mapper.Map<NurseReportEntity>(model);
                    if (string.IsNullOrEmpty(model.Id))
                    {
                        entity.Id = Guid.NewGuid().ToString();
                        await _nurseReportRepository.InsertAsync(entity);
                    }
                    else
                    {
                        await _nurseReportRepository.UpdateAsync(entity);
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
            var vm = new NurseReportViewModel();
            NurseReportEntity entity = null;
            try
            {
                entity = await _nurseReportRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
            }
            vm = _mapper.Map<NurseReportViewModel>(entity);
            return View(vm);
        }
        public async Task<IActionResult> Delete(string id)
        {
            var vm = new NurseReportViewModel();
            NurseReportEntity entity = null;
            try
            {
                entity = await _nurseReportRepository.GetByIdAsync(id);
                await _nurseReportRepository.DeleteAsync(entity);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(string id)
        {
            var vm = new NurseReportViewModel();
            NurseReportEntity entity = null;
            try
            {
                entity = await _nurseReportRepository.GetByIdAsync(id);
            }
            catch
            {
            }
            vm = _mapper.Map<NurseReportViewModel>(entity);
            return View(vm);
        }
    }
}