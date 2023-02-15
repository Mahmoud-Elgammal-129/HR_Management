using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
   public class HoursViewModel
    {
        [Key]
        public int id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "  من فضلك ادخل  عددالساعات الاضافة")]
        public Nullable<int> addHours { get; set; }
       
        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل  عدد الساعات الحذف")]
        public Nullable<int> removeHours { get; set; }
    }
}
