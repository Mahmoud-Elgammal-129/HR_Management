using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using BLL;

namespace DAL
{
    interface IAuthenticationRepository
    {
        AuthenticationViewModel add(AuthenticationViewModel model);
        bool update(AuthenticationViewModel model);
        bool delete(int id);
        AuthenticationViewModel GetByID(int id);
        IEnumerable<AuthenticationViewModel> GetALL();
    }
  public  class AuthenticationRepository : IAuthenticationRepository
    {
        HREntities db = new HREntities();
        public AuthenticationViewModel add(AuthenticationViewModel model)
        {
            try
            {
                Authentication obj  = new Authentication();
                obj.Id = model.Id;
                obj.name = model.name;
                obj.canAdd = model.canAdd;
                obj.canDelete = model.canDelete;
                obj.canUpdate = model.canUpdate;
                obj.canView = model.canView;
                obj.groupId = model.groupId;
                var result = db.Authentication.Add(obj);
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
                    Authentication obj = db.Authentication.FirstOrDefault(x => x.Id == id);
                    if (obj != null)
                    {
                        db.Authentication.Remove(obj);
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

        public IEnumerable<AuthenticationViewModel> GetALL()
        {
            try
            {
                List<AuthenticationViewModel> authentications = new List<AuthenticationViewModel>();
                foreach (var item in db.Authentication)
                {
                    AuthenticationViewModel obj = new AuthenticationViewModel();
                    obj.Id = item.Id;
                    obj.name = item.name;
                    obj.canAdd = item.canAdd;
                    obj.canDelete = item.canDelete;
                    obj.canUpdate = item.canUpdate;
                    obj.canView = item.canView;
                    obj.groupId = item.groupId;

                    authentications.Add(obj);
                }
                return authentications;
            }
            catch
            {
                throw;
            }
        }

        public AuthenticationViewModel GetByID(int id)
        {

            try
            {


                Authentication authentions = db.Authentication.FirstOrDefault(x => x.Id == id);
                AuthenticationViewModel obj = new AuthenticationViewModel();
                obj.Id = authentions.Id;
                obj.name = authentions.name;
                obj.canAdd = authentions.canAdd;
                obj.canDelete = authentions.canDelete;
                obj.canUpdate = authentions.canUpdate;
                obj.canView = authentions.canView;
                obj.groupId = authentions.groupId;
                return obj;

            }
            catch
            {
                throw;
            }

        }

        public bool update(AuthenticationViewModel model)
        {
            try
            {
                Authentication obj = db.Authentication.FirstOrDefault(x => x.Id == model.Id);
                if (obj != null)
                {
                    obj.Id = model.Id;
                    obj.name = model.name;
                    obj.canAdd = model.canAdd;
                    obj.canDelete = model.canDelete;
                    obj.canUpdate = model.canUpdate;
                    obj.canView = model.canView;
                    obj.groupId = model.groupId;


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
