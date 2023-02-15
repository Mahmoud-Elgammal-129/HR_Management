using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using BLL;

namespace DAL
{
    interface IAdminRepository
    {
        AdminViewModel add(AdminViewModel model);
        bool update(AdminViewModel model);
        bool login(AdminViewModel model);
        bool delete(int id);
        AdminViewModel GetByID(int id);
        IEnumerable<AdminViewModel> GetALL();
    }
    public class AdminRepository : IAdminRepository
    {
        HREntities db = new HREntities();
        public AdminViewModel add(AdminViewModel model)
        {
            try
            {
                Admin obj = new Admin();
                obj.Id = model.Id;
                obj.name = model.name;
                obj.userName = model.userName;
                obj.email = model.email;
                obj.password = model.password;
                obj.groupId = model.groupId;
                obj.RoleId = model.RolrId;
                var result = db.Admin.Add(obj);
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
                    Admin obj = db.Admin.FirstOrDefault(x => x.Id == id);
                    if (obj != null)
                    {
                        db.Admin.Remove(obj);
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

        public IEnumerable<AdminViewModel> GetALL()
        {
            try
            {
                List<AdminViewModel> admins = new List<AdminViewModel>();
                foreach (var item in db.Admin)
                {
                    AdminViewModel obj = new AdminViewModel();
                    obj.Id = item.Id;
                    obj.name = item.name;
                    obj.userName = item.userName;
                    obj.email = item.email;
                    obj.password = item.password;
                   
                    obj.groupId = item.groupId;
                    obj.RolrId = item.RoleId;
                    admins.Add(obj);
                }
                return admins;
            }
            catch
            {
                throw;
            }
        }

        public AdminViewModel GetByID(int id)
        {
            try
            {


                Admin admins = db.Admin.FirstOrDefault(x => x.Id == id);
                AdminViewModel obj = new AdminViewModel();
                obj.Id = admins.Id;
                obj.name = admins.name;
                obj.userName = admins.userName;
                obj.email = admins.email;
                obj.password = admins.password;  
                obj.groupId = admins.groupId;
                obj.RolrId = admins.RoleId;
                return obj;

            }
            catch
            {
                throw;
            }

        }

        public bool login(AdminViewModel model)
        {
            try
            {
                var result = db.Admin.FirstOrDefault(x => x.userName == model.userName && x.password == model.password);
                if (result != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool update(AdminViewModel model)
        {
            try
            {
                Admin obj = db.Admin.FirstOrDefault(x => x.Id == model.Id);
                if (obj != null)
                {
                    obj.Id = model.Id;
                    obj.name = model.name;
                    obj.userName = model.userName;
                    obj.email = model.email;
                    obj.password = model.password;
                    obj.groupId = model.groupId;
                    obj.RoleId = model.RolrId;
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
