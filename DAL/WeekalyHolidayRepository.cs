using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DataModel;

namespace DAL
{
    interface IWeekalyHolidayRepository
    {
        WeekalyHolidayViewModel add(WeekalyHolidayViewModel model);
        bool update(WeekalyHolidayViewModel model);
        bool delete(int id);
        WeekalyHolidayViewModel GetByID(int id);
        IEnumerable<WeekalyHolidayViewModel> GetALL();
    }
    public class WeekalyHolidayRepository : IWeekalyHolidayRepository
    {
        HREntities db = new HREntities();
        public WeekalyHolidayViewModel add(WeekalyHolidayViewModel model)
        {
            {
                try
                {
                    WeekalyHoliday obj = new WeekalyHoliday();
                    obj.id = model.id;
                    obj.day1 = model.day1;
                    obj.day2 = model.day2;

                    var result = db.WeekalyHoliday.Add(obj);
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
                    WeekalyHoliday obj = db.WeekalyHoliday.FirstOrDefault(x => x.id == id);
                    if (obj != null)
                    {
                        db.WeekalyHoliday.Remove(obj);
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

        public IEnumerable<WeekalyHolidayViewModel> GetALL()
        {
            try
            {
                List<WeekalyHolidayViewModel> models = new List<WeekalyHolidayViewModel>();
                foreach (var item in db.WeekalyHoliday)
                {
                    WeekalyHolidayViewModel obj = new WeekalyHolidayViewModel();
                    obj.id = item.id;
                    obj.day1 = item.day1;
                    obj.day2 = item.day2;


                    models.Add(obj);
                }
                return models;
            }
            catch
            {
                throw;
            }
        }

        public WeekalyHolidayViewModel GetByID(int id)
        {
            try
            {


                WeekalyHoliday holiday = db.WeekalyHoliday.FirstOrDefault(x => x.id == id);
                WeekalyHolidayViewModel obj = new WeekalyHolidayViewModel();
                obj.id = holiday.id;
                obj.day1 = holiday.day1;
                obj.day2 = holiday.day2;

                return obj;

            }
            catch
            {
                throw;
            }
        }

        public bool update(WeekalyHolidayViewModel model)
        {
            try
            {
                WeekalyHoliday obj = db.WeekalyHoliday.FirstOrDefault(x => x.id == model.id);
                if (obj != null)
                {
                    obj.id = model.id;
                    obj.day1 = model.day1;
                    obj.day2 = model.day2;

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
