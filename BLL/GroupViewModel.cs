using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
   public class GroupViewModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = " اسم المجموعه")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل  اسم المجموعة ")]
        public string name { get; set; }
    }
}
