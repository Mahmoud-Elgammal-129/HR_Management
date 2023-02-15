using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
  public  class WeekalyHolidayViewModel
    {
        public int id { get; set; }
        [Display(Name = " day1")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل  اليوم الاول ")]
        public string day1 { get; set; }
        [Display(Name = " day2")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل  اليوم الثانى ")]
        public string day2 { get; set; }
    }
}
