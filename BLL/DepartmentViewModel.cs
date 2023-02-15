using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
   public class DepartmentViewModel
    {
        [Key]
        public int id { get; set; }
       
        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل القسم  ")]
        public string name { get; set; }
    }
}
