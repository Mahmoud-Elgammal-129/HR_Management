using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
    public class LoginViewModel
    {
        [Display(Name = " اسم المستخدم")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل  الاسم بالكامل ")]
        public string userName { get; set; }
        
        [Display(Name = " كلمة المرور")]
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل  كلمة المرور ")]
        public string password { get; set; }
    }
}
