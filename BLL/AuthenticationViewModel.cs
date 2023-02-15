using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class AuthenticationViewModel
    {

        public int Id { get; set; }
        public string name { get; set; }
        public Nullable<bool> canAdd { get; set; }
        public Nullable<bool> canUpdate { get; set; }
        public Nullable<bool> canDelete { get; set; }
        public Nullable<bool> canView { get; set; }
        public Nullable<int> groupId { get; set; }
    }
}
