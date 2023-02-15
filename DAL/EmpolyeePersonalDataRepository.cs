using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using BLL;

namespace DAL
{
    interface IEmpolyeePersonalDataRepository
    {
        EmpolyeePersonalData add(EmpolyeePersonalDataViewModel model);
        bool update(EmpolyeePersonalDataViewModel model);
        bool delete(int id);
        EmpolyeePersonalDataViewModel GetByID(int id);
        IEnumerable<EmpolyeePersonalDataViewModel> GetALL();
    }
    public class EmpolyeePersonalDataRepository : IEmpolyeePersonalDataRepository
    {
        HREntities db = new HREntities();
        public EmpolyeePersonalData add(EmpolyeePersonalDataViewModel model)
        {
            try
            {
                EmpolyeePersonalData obj = new EmpolyeePersonalData();
                obj.id = model.id;
                obj.name = model.name;
                obj.address = model.address;
                obj.phone = model.phone;
                obj.gender = model.gender;
                obj.national = model.national;
                obj.birthday = model.birthday;
                obj.nationalID = model.nationalID;
                obj.departmentID = model.departmentID;
                var result = db.EmpolyeePersonalData.Add(obj);
                db.SaveChanges();
                return result;
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
                    EmpolyeePersonalData obj = db.EmpolyeePersonalData.FirstOrDefault(x => x.id == id);
                    if (obj != null)
                    {
                        db.EmpolyeePersonalData.Remove(obj);
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

        public IEnumerable<EmpolyeePersonalDataViewModel> GetALL()
        {
            try
            {
                List<EmpolyeePersonalDataViewModel> employees = new List<EmpolyeePersonalDataViewModel>();
                foreach (var item in db.EmpolyeePersonalData)
                {
                    EmpolyeePersonalDataViewModel obj = new EmpolyeePersonalDataViewModel();
                    obj.id = item.id;
                    obj.name = item.name;
                    obj.address = item.address;
                    obj.phone = item.phone;
                    obj.gender = item.gender;
                    obj.national = item.national;
                    obj.birthday = item.birthday;
                    obj.nationalID = item.nationalID;
                    obj.departmentID = item.departmentID;

                    employees.Add(obj);
                }
                return employees;
            }
            catch
            {
                throw;
            }
        }

        public EmpolyeePersonalDataViewModel GetByID(int id)
        {
            try
            {

                EmpolyeePersonalData employee = db.EmpolyeePersonalData.FirstOrDefault(x => x.id == id);
                EmpolyeePersonalDataViewModel obj = new EmpolyeePersonalDataViewModel();
                obj.id = employee.id;
                obj.name = employee.name;
                obj.address = employee.address;
                obj.phone = employee.phone;
                obj.gender = employee.gender;
                obj.national = employee.national;
                obj.birthday = employee.birthday;
                obj.nationalID = employee.nationalID;
                obj.departmentID = employee.departmentID;
                return obj;
            }
            catch
            {
                throw;
            }
        }

        public bool update(EmpolyeePersonalDataViewModel model)
        {
            try
            {
                EmpolyeePersonalData obj = db.EmpolyeePersonalData.FirstOrDefault(x => x.id == model.id);
                if (obj != null)
                {
                    obj.id = model.id;
                    obj.name = model.name;
                    obj.address = model.address;
                    obj.phone = model.phone;
                    obj.gender = model.gender;
                    obj.national = model.national;
                    obj.birthday = model.birthday;
                    obj.nationalID = model.nationalID;
                    obj.departmentID = model.departmentID;
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
