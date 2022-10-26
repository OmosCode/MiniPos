using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Areas.Admin.Models.DTOs
{
    public class CreateAnaGrupDTO
    {
        [Required(ErrorMessage = "Bu alan bş bırakılamaz!")]
        [MinLength(2), MaxLength(100)]
        public string UrunAnagrup { get; set; }


      

    }
}
