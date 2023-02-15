using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using BLL;

namespace DAL
{
    interface IRolesRepository
    {
        Roles add(RolesViewModel model);
        bool update(RolesViewModel model);
        bool delete(int id);
        RolesViewModel GetByID(int id);
        IEnumerable<RolesViewModel> GetALL();
    }
  public  class RolesRepository : IRolesRepository
    {

        HREntities db = new HREntities();
        public Roles add(RolesViewModel model)
        {
            try
            {
                Roles roles = new Roles();
                roles.RolrId = roles.RolrId;
                roles.RoleName = roles.RoleName;
                var result = db.Roles.Add(roles);
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
                    Roles roles = db.Roles.FirstOrDefault(x => x.RolrId == id);
                    if (roles != null)
                    {
                        db.Roles.Remove(roles);
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

        public IEnumerable<RolesViewModel> GetALL()
        {
            try
            {
                List<RolesViewModel> roles = new List<RolesViewModel>();
                foreach (var item in db.Roles)
                {
                    RolesViewModel model = new RolesViewModel();
                    model.RolrId= item.RolrId;
                    model.RoleName = item.RoleName;

                    roles.Add(model);
                }
                return roles;
            }
            catch
            {
                throw;
            }
        }

        public RolesViewModel GetByID(int id)
        {
            try
            {


                Roles roles = db.Roles.FirstOrDefault(x => x.RolrId == id);
                RolesViewModel obj = new RolesViewModel();
                obj.RolrId = roles.RolrId;
                obj.RoleName = roles.RoleName;

                return obj;

            }
            catch
            {
                throw;
            }
        }

        public bool update(RolesViewModel model)
        {
            try
            {
                Roles roles = db.Roles.FirstOrDefault(x => x.RolrId == model.RolrId);
                if (roles != null)
                {
                    roles.RolrId = model.RolrId;
                    roles.RoleName = model.RoleName;
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
