using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DataModel;

namespace DAL
{
    interface IHoursRepository
    {
        HoursViewModel add(HoursViewModel model);
        bool update(HoursViewModel model);
        bool delete(int id);
        HoursViewModel GetByID(int id);
        IEnumerable<HoursViewModel> GetALL();
    }


    public class HoursRepository : IHoursRepository
    {

        HREntities db = new HREntities();
        public HoursViewModel add(HoursViewModel model)
        {
            {
                try
                {
                    Hours obj = new Hours();
                    obj.id = model.id;
                    obj.addHours = model.addHours;
                    obj.removeHours = model.removeHours;
                   
                    var result = db.Hours.Add(obj);
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
                    Hours obj = db.Hours.FirstOrDefault(x => x.id == id);
                    if (obj != null)
                    {
                        db.Hours.Remove(obj);
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

        public IEnumerable<HoursViewModel> GetALL()
        {
            try
            {
                List<HoursViewModel> hours = new List<HoursViewModel>();
                foreach (var item in db.Hours)
                {
                    HoursViewModel obj = new HoursViewModel();
                    obj.id = item.id;
                    obj.addHours = item.addHours;
                    obj.removeHours = item.removeHours;
                   

                    hours.Add(obj);
                }
                return hours;
            }
            catch
            {
                throw;
            }
        }

        public HoursViewModel GetByID(int id)
        {
             try
            {


                Hours hour= db.Hours.FirstOrDefault(x => x.id == id);
                HoursViewModel obj = new HoursViewModel();
                obj.id = hour.id;
                obj.addHours= hour.addHours;
                obj.removeHours = hour.removeHours;
               
                return obj;

            }
            catch
            {
                throw;
            }
        }

        public bool update(HoursViewModel model)
        {
            try
            {
                Hours obj = db.Hours.FirstOrDefault(x => x.id == model.id);
                if (obj != null)
                {
                    obj.id = model.id;
                    obj.addHours = model.addHours;
                    obj.removeHours = model.removeHours;
                    
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
