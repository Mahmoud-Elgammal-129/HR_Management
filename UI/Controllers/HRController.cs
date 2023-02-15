using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using BLL;
using System.Web.Security;
namespace UI.Controllers
{
    
    public class HRController : Controller
    {

        GroupRepository groupRepository = new GroupRepository();
        AdminRepository adminRepository = new AdminRepository();
        AuthenticationRepository authenticationRepository = new AuthenticationRepository();
        EmployeeWorkDataRepository EmployeeWorkDataRepository = new EmployeeWorkDataRepository();
        EmpolyeePersonalDataRepository EmpolyeePersonalDataRepository = new EmpolyeePersonalDataRepository();
        DepartmentRepository DepartmentRepository = new DepartmentRepository();
        RolesRepository RolesRepository = new RolesRepository();
        // GET: HR
        public ActionResult Index()
        {
            if ((bool)Session["IsLogined"] == false)
            {
                return RedirectToAction("Login", "HR");
            }
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            Session["IsLogined"] = false;

            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminViewModel model)
        {
            try
            {
                var result = adminRepository.login(model);
                if(result)
                {
                    Session["IsLogined"] = true;
                    return RedirectToAction("Authentication");
                }
              
                Session["IsLogined"] = false;

                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        //[Authorize(Roles ="hr")]
        //[Authorize(Users ="omar")]
        public ActionResult Authentication()
        {
            if ((bool)Session["IsLogined"] == false)
            {
                return RedirectToAction("Login", "HR");
            }
            return View();
        }
  
        [HttpPost]
        public JsonResult Authentication(List<AuthenticationViewModel> authenticationViewModel , GroupViewModel groupViewModel)
        {
            try
            {
           
                var result = groupRepository.add(groupViewModel);
                foreach (var item in authenticationViewModel)
                {
                    item.groupId = result.Id;
                    authenticationRepository.add(item);
                }
                return Json("success");
            }
            catch (Exception)
            {

                throw;
            }
        }
        //[Authorize(Roles = "hr,Admin")]
        public ActionResult admin()
        {
            if ((bool)Session["IsLogined"] == false)
            {
                return RedirectToAction("Login", "HR");
            }
            ViewBag.groups = groupRepository.GetALL();
            ViewBag.roles = RolesRepository.GetALL();

            return View();
        }
        
        [HttpPost]
        public JsonResult admin(AdminViewModel  model)
        {

            try
            {
         
                adminRepository.add(model);
                        ViewBag.Success = "Data added Successfully";
                      
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }

            
        }
        
        public ActionResult groups()
        {
            if ((bool)Session["IsLogined"] == false)
            {
                return RedirectToAction("Login", "HR");
            }
            IEnumerable<GroupViewModel> obj = groupRepository.GetALL();
            return View(obj);
        }
        public ActionResult employee()
        {
            if ((bool)Session["IsLogined"] == false)
            {
                return RedirectToAction("Login", "HR");
            }
            ViewBag.departments = DepartmentRepository.GetALL();
            return View();
        }
        [HttpPost]
        public JsonResult employee(Model model )
        {
            try
            {
               
             var result =  EmpolyeePersonalDataRepository.add(model.empolyeePersonalDataViewModel);
               model.employeeWorkDataViewModel.employeeID=result.id;

             EmployeeWorkDataRepository.add(model.employeeWorkDataViewModel);
                ViewBag.Success = "Data added Successfully";

                return Json("success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public ActionResult employee(int id = 0)
        {
            if ((bool)Session["IsLogined"] == false)
            {
                return RedirectToAction("Login", "HR");
            }
            ViewBag.departments = DepartmentRepository.GetALL();

            if (id <= 0)
            {
                return View(new AllEmployeeViewModel());
            }
           var employess = EmpolyeePersonalDataRepository.GetByID(id);
           var obj = EmployeeWorkDataRepository.GetALL().FirstOrDefault(x => x.employeeID == id);
            AllEmployeeViewModel model = new AllEmployeeViewModel();
            model.address = employess.address;
            model.birthday = employess.birthday;
            model.departmentID = employess.departmentID;
            model.gender = employess.gender;
            model.name = employess.name;
            model.national = employess.national;
            model.nationalID = employess.nationalID;
            model.phone = employess.phone;
            model.attandanceDate = obj.attandanceDate;
            model.employeeID = obj.employeeID;
            model.workDate = obj.workDate;
            model.sallery = obj.sallery;
            model.outDate = obj.outDate;
           
            return View(model);
        }
        [Authorize(Roles = "hr")]
        public ActionResult departments()
        {
            if ((bool)Session["IsLogined"] == false)
            {
                return RedirectToAction("Login", "HR");
            }
            return View();
        }
        [HttpPost]
        public JsonResult departments(DepartmentViewModel model)
        {
            DepartmentRepository.add(model);
             ViewBag.Success = "Data added Successfully";

            return Json("success", JsonRequestBehavior.AllowGet);
        }

    }
}