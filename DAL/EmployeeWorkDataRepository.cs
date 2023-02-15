using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DataModel;

namespace DAL
{
    interface IEmployeeWorkDataRepository
    {
        EmployeeWorkDataViewModel add(EmployeeWorkDataViewModel model);
        bool update(EmployeeWorkDataViewModel model);
        bool delete(int id);
        EmployeeWorkDataViewModel GetByID(int id);
        IEnumerable<EmployeeWorkDataViewModel> GetALL();
    }
    public class EmployeeWorkDataRepository : IEmployeeWorkDataRepository
    {
        HREntities db = new HREntities();
        public EmployeeWorkDataViewModel add(EmployeeWorkDataViewModel model)
        {
            try
            {
                EmployeeWorkData obj = new EmployeeWorkData();
                obj.id = model.id;
                obj.workDate = model.workDate;
                obj.sallery = model.sallery;
                obj.attandanceDate = model.attandanceDate;
                obj.outDate = model.outDate;
                obj.employeeID = model.employeeID;
                var result = db.EmployeeWorkData.Add(obj);
                db.SaveChanges();
                return model;
            }
            catch
            {
                throw;
            }
        }

        public bool delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    EmployeeWorkData obj = db.EmployeeWorkData.FirstOrDefault(x => x.id == id);
                    if (obj != null)
                    {
                        db.EmployeeWorkData.Remove(obj);
                        db.SaveChanges();
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<EmployeeWorkDataViewModel> GetALL()
        {
            try
            {
                List<EmployeeWorkDataViewModel> employees = new List<EmployeeWorkDataViewModel>();
                foreach (var item in db.EmployeeWorkData)
                {
                    EmployeeWorkDataViewModel obj = new EmployeeWorkDataViewModel();
                    obj.id = item.id;
                    obj.workDate = item.workDate;
                    obj.sallery = item.sallery;
                    obj.attandanceDate = item.attandanceDate;
                    obj.outDate = item.outDate;

                    obj.employeeID = item.employeeID;

                    employees.Add(obj);
                }
                return employees;
            }
            catch
            {
                throw;
            }
        }

        public EmployeeWorkDataViewModel GetByID(int id)
        {
            try
            {

                EmployeeWorkData employee = db.EmployeeWorkData.FirstOrDefault(x => x.id == id);
                EmployeeWorkDataViewModel obj = new EmployeeWorkDataViewModel();
                obj.id = employee.id;
                    obj.workDate = employee.workDate;
                    obj.sallery = employee.sallery;
                    obj.attandanceDate = employee.attandanceDate;
                    obj.outDate = employee.outDate;

                    obj.employeeID = employee.employeeID;
                return obj;
            }
            catch
            {
                throw;
            }
        }

        public bool update(EmployeeWorkDataViewModel model)
        {
            try
            {
                EmployeeWorkData obj = db.EmployeeWorkData.FirstOrDefault(x => x.id == model.id);
                if (obj != null)
                {
                    obj.id = model.id;
                    obj.workDate = model.workDate;
                    obj.sallery = model.sallery;
                    obj.attandanceDate = model.attandanceDate;
                    obj.outDate = model.outDate;
                    obj.employeeID = model.employeeID;
                    db.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
