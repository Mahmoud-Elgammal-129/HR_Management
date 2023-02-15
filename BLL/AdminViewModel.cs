using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
   public class AdminViewModel
    {
        [Key]
        public int Id { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل  الاسم بالكامل ")]
        public string name { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل اسم المستخدم")]
        public string userName { get; set; }
        [EmailAddress(ErrorMessage = "ايميل خطا")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل الايميل ")]
        public string email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "هذا الباسورد خطا", AllowEmptyStrings = false)]
        [StringLength(20, ErrorMessage = "password must be 8 cahr long")]
        public string password { get; set; }
        [Required(ErrorMessage = "اختر صلاحية من فضلك", AllowEmptyStrings = false)]
        public Nullable<int> groupId { get; set; }
        [Required(ErrorMessage = "اختر شرط من فضلك", AllowEmptyStrings = false)]
        public int? RolrId { get; set; }
    }
}
