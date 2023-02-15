using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using BLL;


namespace UI.Controllers
{
    //[Authorize(Roles = "hr")]

    public class SettingController : Controller
    {
        HoursRepository HoursRepository = new HoursRepository();
        WeekalyHolidayRepository WeekalyHolidayRepository = new WeekalyHolidayRepository();
        OfficialVacationsRepository OfficialVacationsRepository = new OfficialVacationsRepository();
        EmpolyeePersonalDataRepository EmpolyeePersonalDataRepository = new EmpolyeePersonalDataRepository();
        EmployeeWorkDataRepository EmployeeWorkDataRepository = new EmployeeWorkDataRepository();
        AttendanceRpositry AttendanceRpositry = new AttendanceRpositry();
        // GET: Setting
        //[Authorize(Roles = "hr")]
        public ActionResult Index()
        {
            if ((bool)Session["IsLogined"] == false)
            {
                return RedirectToAction("Login", "HR");
            }

            return View();
        }
        [HttpPost]
        public JsonResult AddPublicSetting(PublicSetting setting)
        {
            try
            {
                var result = HoursRepository.GetALL().FirstOrDefault();
                if (result != null)
                {
                    HoursRepository.delete(result.id);
                    var old = WeekalyHolidayRepository.GetALL();
                    foreach (var item in old)
                    {
                        WeekalyHolidayRepository.delete(item.id);
                    }

                }

                HoursRepository.add(setting.HoursViewModel);
                
                WeekalyHolidayRepository.add(setting.WeekalyHolidayViewModel);
                

                return Json("success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public ActionResult OfficialVacations()
        {
            if ((bool)Session["IsLogined"] == false)
            {
                return RedirectToAction("Login", "HR");
            }
            return View();
        }
        [HttpPost]
        public JsonResult AddOfficialVacations(OfficialVacationsViewModel officialVacations)
        {

            try
            {
                OfficialVacationsRepository.add(officialVacations);
                ViewBag.Success = "Data added Successfully";

                return Json("success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }


        }
        public JsonResult GetOfficialVacations()
        {
            var obj = OfficialVacationsRepository.GetALL();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetOfficialVacationsByID(int id)
        {
            var obj = OfficialVacationsRepository.GetByID(id);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult UpdateOfficialVacations(OfficialVacationsViewModel official)
        {
            var result = OfficialVacationsRepository.update(official);
            if (result)
            {
                return Json("success", JsonRequestBehavior.AllowGet);

            }
            return Json("field", JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteOfficialVacationsByID(int id)
        {
            var obj = OfficialVacationsRepository.GetByID(id);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteOfficialVacations(int id)
        {
            var result = OfficialVacationsRepository.delete(id);
            if (result)
            {
                return Json("success", JsonRequestBehavior.AllowGet);

            }
            return Json("field", JsonRequestBehavior.AllowGet);
        }
        public ActionResult ReportAttended()
        {
            if ((bool)Session["IsLogined"] == false)
            {
                return RedirectToAction("Login", "HR");
            }
            ViewBag.employees = EmpolyeePersonalDataRepository.GetALL();
            return View();
        }

        public JsonResult GetattendByID(int id)
        {
            var obj = AttendanceRpositry.GetByID(id);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteattendByID(int id)
        {
            var obj = AttendanceRpositry.GetByID(id);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Deleteattend(int id)
        {
            var result = AttendanceRpositry.delete(id);
            if (result)
            {
                return Json("success", JsonRequestBehavior.AllowGet);

            }
            return Json("field", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Updateattend(AttendanceViewModel attendance)
        {
            var result = AttendanceRpositry.update(attendance);
            if (result)
            {
                return Json("success", JsonRequestBehavior.AllowGet);

            }
            return Json("field", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddAttended(AttendanceViewModel attendanceViewModel)
        {

            try
            {
                AttendanceRpositry.add(attendanceViewModel);
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }


        }
        //public JsonResult GetAllAttendeds(string search, DateTime? from, DateTime? to)
        //{

        //    try
        //    {
        //       var result= AttendanceRpositry.GetALL(search , from , to);

        //        return Json(result, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }


        //}
        public JsonResult GetAllAttendeds(string search)
        {

            try
            {
               var result= AttendanceRpositry.GetALL(search);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }


        }


        public ActionResult sallaryemployee(string search , int year = 0 , int month = 0)
        {
            if ((bool)Session["IsLogined"] == false)
            {
               return RedirectToAction("Login", "HR");
            }
            List<SallaryReportViewModel> sallaryReportViewModels = new List<SallaryReportViewModel>();
            var attendances = AttendanceRpositry.GetALL("");
            var employees = EmployeeWorkDataRepository.GetALL();
            var firstDayOfMonth = new DateTime();
            var lastDayOfMonth = new DateTime();
            DateTime date = DateTime.Now;
            if (year <= 0 && month <= 0)
            {
                date = DateTime.Now;
                firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            }
            else
            {
                firstDayOfMonth = new DateTime(year, month, 1);
                lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            }
            
            foreach (var item in employees)          
            {
                SallaryReportViewModel sallaryReportViewModel = new SallaryReportViewModel();
                foreach (var obj in attendances.Where(x=>x.employeeId == item.employeeID  && x.attend >= firstDayOfMonth && x.attend <= lastDayOfMonth))
                {

                    if(obj.Departure.Value.Hour>=item.outDate.Value.Hour)
                    {
                        sallaryReportViewModel.OverTimeHours += obj.Departure.Value.Hour - item.outDate.Value.Hour;
                    }
                    else
                    {
                        sallaryReportViewModel.HoursDiscount += item.outDate.Value.Hour - obj.Departure.Value.Hour;
                    }
                    sallaryReportViewModel.HoursDiscount += obj.attend.Value.Hour - item.attandanceDate.Value.Hour;
             
                    sallaryReportViewModel.Employeename = obj.employeeName;
                    sallaryReportViewModel.DepartmentName = obj.department;
                    sallaryReportViewModel.sallary = item.sallery;
                    sallaryReportViewModel.AttendedDay += 1;
                    var totalDays = 0;
                    if (year <= 0 && month <= 0)
                    {
                         totalDays = WorkDays(date.Year, date.Month);

                    }
                    else
                    {
                        totalDays = WorkDays(year, month);

                    }
                    sallaryReportViewModel.DeparturedDay = totalDays - sallaryReportViewModel.AttendedDay;
                }
                if (sallaryReportViewModel.Employeename != null)
                {
                   var hours = HoursRepository.GetALL().FirstOrDefault();
                    decimal? hour = item.sallery / 30 / 8;
                    decimal? day = hour * 8;
                    var DeparturedDays = sallaryReportViewModel.DeparturedDay * day;
                    sallaryReportViewModel.totalExtra = (hour * sallaryReportViewModel.OverTimeHours) * hours.addHours;
                    sallaryReportViewModel.totalDiscount = (hour * sallaryReportViewModel.HoursDiscount) * hours.removeHours;

                    sallaryReportViewModel.totalExtra = (decimal)Math.Round((double)sallaryReportViewModel.totalExtra , 2);
                    sallaryReportViewModel.totalDiscount = (decimal)Math.Round((double)(DeparturedDays + sallaryReportViewModel.totalDiscount) , 2);
                    sallaryReportViewModel.employeeID = item.employeeID;
                    sallaryReportViewModel.NetSallary = item.sallery + sallaryReportViewModel.totalExtra - sallaryReportViewModel.totalDiscount;
                    sallaryReportViewModel.NetSallary = (decimal)Math.Round((double)sallaryReportViewModel.NetSallary, 2);
                    sallaryReportViewModels.Add(sallaryReportViewModel);

                }
            }

            if (!String.IsNullOrEmpty(search))
            {
                if (sallaryReportViewModels.Where(x => x.Employeename.Contains(search)).Count() == 0)
                {
                    ViewBag.massage = "من فضلك ادخل اسم موظف صالح ";
                }

                return View(sallaryReportViewModels.Where(x => x.Employeename.Contains(search)));
            }
            if (sallaryReportViewModels.Count() == 0)
            {
                ViewBag.CorrectYear = "من فضلك اختر سنه صحيحه ";
            }
            return View(sallaryReportViewModels);

        }


        private int WorkDays(int year, int month)
        {
            var officialVacations = OfficialVacationsRepository.GetALL().Where(x=>x.date.Value.Year == year && x.date.Value.Month == month);

            int days = Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                     .Select(day => new DateTime(year, month, day))
                     .Count(d => d.DayOfWeek != DayOfWeek.Saturday &&
                                 d.DayOfWeek != DayOfWeek.Friday);
           var result = days - officialVacations.Count();

            return result;
        }

    }
}