using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using BLL;

namespace DAL
{
    interface IGroupRepository
    {
        Group add(GroupViewModel model);
        bool update(GroupViewModel model);
        bool delete(int id);
        GroupViewModel GetByID(int id);
        IEnumerable<GroupViewModel> GetALL();
    }
  public  class GroupRepository : IGroupRepository
    {
        HREntities db = new HREntities();
        public Group add(GroupViewModel model)
        {
            try {
                Group group = new Group();
                group.name = model.name;
                var result = db.Group.Add(group);
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
                    Group group = db.Group.FirstOrDefault(x => x.Id == id);
                    if (group != null)
                    {
                        db.Group.Remove(group);
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

        public IEnumerable<GroupViewModel> GetALL()
        {
            try
            {
                List<GroupViewModel> groups = new List<GroupViewModel>();
                foreach (var item in db.Group)
                {
                    GroupViewModel group = new GroupViewModel();
                    group.Id = item.Id;
                    group.name = item.name;

                    groups.Add(group);
                }
                return groups;
            }
            catch
            {
                throw;
            }
           
        }

        public GroupViewModel GetByID(int id)
        {
            try
            {


                Group group = db.Group.FirstOrDefault(x => x.Id == id);
                GroupViewModel obj= new GroupViewModel();
                obj.Id = group.Id;
                obj.name = group.name;
                
                return obj;

            }
            catch
            {
                throw;
            }
           
        }

        public bool update(GroupViewModel model)
        {
            try
            {
                Group group = db.Group.FirstOrDefault(x => x.Id == model.Id);
                if (group != null)
                {
                    group.name = model.name;
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
