using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DataModel;


namespace DAL
{
    interface IOfficialVacationsRepository
    {
        OfficialVacationsViewModel add(OfficialVacationsViewModel model);
        bool update(OfficialVacationsViewModel model);
        bool delete(int id);
        OfficialVacationsViewModel GetByID(int id);
        IEnumerable<OfficialVacationsViewModel> GetALL();
    }
    public class OfficialVacationsRepository : IOfficialVacationsRepository
    {
        HREntities db = new HREntities();
        public OfficialVacationsViewModel add(OfficialVacationsViewModel model)
        {
            {
                try
                {
                    OfficialVacations obj = new OfficialVacations();
                    obj.id = model.id;
                    obj.day = model.day;
                    obj.date = model.date;

                    var result = db.OfficialVacations.Add(obj);
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
                    OfficialVacations obj = db.OfficialVacations.FirstOrDefault(x => x.id == id);
                    if (obj != null)
                    {
                        db.OfficialVacations.Remove(obj);
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

        public IEnumerable<OfficialVacationsViewModel> GetALL()
        {

            try
            {
                List<OfficialVacationsViewModel> officials = new List<OfficialVacationsViewModel>();
                foreach (var item in db.OfficialVacations)
                {
                    OfficialVacationsViewModel obj = new OfficialVacationsViewModel();
                    obj.id = item.id;
                    obj.day = item.day;
                    obj.date = item.date;


                    officials.Add(obj);
                }
                return officials;
            }
            catch
            {
                throw;
            }
        }

        public OfficialVacationsViewModel GetByID(int id)
        {
            try
            {


                OfficialVacations official = db.OfficialVacations.FirstOrDefault(x => x.id == id);
                OfficialVacationsViewModel obj = new OfficialVacationsViewModel();
                obj.id = official.id;
                obj.day = official.day;
                obj.date = official.date;

                return obj;

            }
            catch
            {
                throw;
            }
        }

        public bool update(OfficialVacationsViewModel model)
        {
            try
            {
                OfficialVacations obj = db.OfficialVacations.FirstOrDefault(x => x.id == model.id);
                if (obj != null)
                {
                    obj.id = model.id;
                    obj.day = model.day;
                    obj.date = model.date;

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
