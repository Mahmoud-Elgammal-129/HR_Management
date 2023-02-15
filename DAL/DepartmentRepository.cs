using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using BLL;

namespace DAL
{
    interface IDepartmentRepository
    {
        DepartmentViewModel add(DepartmentViewModel model);
        bool update(DepartmentViewModel model);
        bool delete(int id);
        DepartmentViewModel GetByID(int id);
        IEnumerable<DepartmentViewModel> GetALL();
    }
    public class DepartmentRepository : IDepartmentRepository
    {
        HREntities db = new HREntities();
        public DepartmentViewModel add(DepartmentViewModel model)
        {
            try
            {
                Department obj = new Department();
                obj.id = model.id;
                obj.name = model.name;
                db.Department.Add(obj);
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
                    Department obj = db.Department.FirstOrDefault(x => x.id == id);
                    if (obj != null)
                    {
                        db.Department.Remove(obj);
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

        public IEnumerable<DepartmentViewModel> GetALL()
        {
            try
            {
                List<DepartmentViewModel> departments = new List<DepartmentViewModel>();
                foreach (var item in db.Department)
                {
                    DepartmentViewModel obj = new DepartmentViewModel();
                    obj.id = item.id;
                    obj.name = item.name;
                    departments.Add(obj);
                }
                return departments;
            }
            catch
            {
                throw;
            }
        }

        public DepartmentViewModel GetByID(int id)
        {
            try
            {

                Department depts = db.Department.FirstOrDefault(x => x.id == id);
                DepartmentViewModel obj = new DepartmentViewModel();
                obj.id = depts.id;
                obj.name = depts.name;
                
                return obj;
            }
            catch
            {
                throw;
            }
        }

        public bool update(DepartmentViewModel model)
        {
            try
            {
                Department obj = db.Department.FirstOrDefault(x => x.id == model.id);
                if (obj != null)
                {
                    obj.id = model.id;
                    obj.name = model.name;
                   
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
