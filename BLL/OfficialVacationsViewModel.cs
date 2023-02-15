using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
   public class OfficialVacationsViewModel
    {
        [Key]
        public int id { get; set; }
        [Display(Name = " day")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل  اليوم  ")]
        public string day { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل  التاريخ ")]
        public Nullable<System.DateTime> date { get; set; }
    }
}
