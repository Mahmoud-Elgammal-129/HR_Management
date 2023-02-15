using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
  public  class AttendanceViewModel
    {
        [Key]
        public int id { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = " من فضلك  ادخل موعد الحضور ")]
        public Nullable<System.DateTime> attend { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل  موعد الانصراف ")]
        public Nullable<System.DateTime> Departure { get; set; }
       
        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل  اسم الموظف ")]
        public string employeeName { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل القسم ")]
        public string department { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل الموظف ")]
        public Nullable<int> employeeId { get; set; }
    }
}
