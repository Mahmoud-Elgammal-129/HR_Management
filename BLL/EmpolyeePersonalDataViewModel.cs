using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
  public  class EmpolyeePersonalDataViewModel
    {
        [Key]
        public int id { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل  الاسم بالكامل ")]
        public string name { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل  العنوان ")]
        public string address { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string phone { get; set; }
        [Required(ErrorMessage = "gender Required")]
        public string gender { get; set; }
        [Required(ErrorMessage = "national Required")]
        public string national { get; set; }
        [Required(ErrorMessage = "birthday Required")]
        public Nullable<System.DateTime> birthday { get; set; }
        [Required(ErrorMessage = "nationalid Required")]
        public string nationalID { get; set; }
        [Required(ErrorMessage = "من فضلك اختر قسم ")]
        public Nullable<int> departmentID { get; set; }
    }
}
