using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DataModel;

namespace DAL
{
    interface IAttendanceRpositry
    {
        AttendanceViewModel add(AttendanceViewModel model);
        bool update(AttendanceViewModel model);
        bool delete(int id);
        AttendanceViewModel GetByID(int id);
        IEnumerable<AttendanceViewModel> GetALL(string search);
    }
    public class AttendanceRpositry : IAttendanceRpositry
    {
        HREntities db = new HREntities();
        public AttendanceViewModel add(AttendanceViewModel model)
        {
            //TimeSpan? ToralHours = model.attend - model.Departure;

            {
                try
                {
                    //AutoMapper
                    Attendance obj = new Attendance();
                    obj.id = model.id;
                    obj.attend = model.attend;
                    obj.Departure= model.Departure;
                    obj.employeeId= model.employeeId;

                    //obj.TotalHours = Convert.ToDouble(ToralHours);
                    var result = db.Attendance.Add(obj);
                    db.SaveChanges();
                    return model;
                }
                catch
                {
                    throw;
                }
            }
        }

        public bool delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    Attendance obj = db.Attendance.FirstOrDefault(x => x.id == id);
                    if (obj != null)
                    {
                        db.Attendance.Remove(obj);
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

        public IEnumerable<AttendanceViewModel> GetALL(string search)
        {
            try
            {
                List<AttendanceViewModel> attendances = new List<AttendanceViewModel>();
                foreach (var item in db.Attendance)
                {
                    AttendanceViewModel obj = new AttendanceViewModel();
                    obj.id = item.id;
                    obj.attend = item.attend;
                    obj.Departure = item.Departure;
                    obj.employeeId = item.employeeId;
                    obj.employeeName = item.EmpolyeePersonalData.name;
                    obj.department = item.EmpolyeePersonalData.Department.name;

                    attendances.Add(obj);
                }
                var r = attendances.Where(x => x.employeeName.Contains(search) || x.department.Contains(search));
                return r;
            }
            catch
            {
                throw;
            }
        }

        public AttendanceViewModel GetByID(int id)
        {
            try
            {


                Attendance attendance = db.Attendance.FirstOrDefault(x => x.id == id);
                AttendanceViewModel obj = new AttendanceViewModel();
                obj.id = attendance.id;
                obj.attend = attendance.attend;
                obj.Departure = attendance.Departure;
                obj.employeeId = attendance.employeeId;

                return obj;

            }
            catch
            {
                throw;
            }
        }

        public bool update(AttendanceViewModel model)
        {
            try
            {
                Attendance obj = db.Attendance.FirstOrDefault(x => x.id == model.id);
                if (obj != null)
                {
                    obj.id = model.id;
                    obj.attend = model.attend;
                    obj.Departure = model.Departure;
                    obj.employeeId = model.employeeId;

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
