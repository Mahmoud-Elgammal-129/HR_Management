using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
   public class EmployeeWorkDataViewModel
    {
        [Key]
        public int id { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل بيانات العمل ")]
        public Nullable<System.DateTime> workDate { get; set; }
       
        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل  المرتب ")]
        public Nullable<decimal> sallery { get; set; }
       
        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل  موعد الحضور ")]
        public Nullable<System.DateTime> attandanceDate { get; set; }
      
        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل  موعد النصراف ")]
        public Nullable<System.DateTime> outDate { get; set; }
        public int? employeeID { get; set; }
    }
}
