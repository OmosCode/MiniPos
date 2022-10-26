using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Areas.Admin.Models.DTOs;

namespace WebApplication2.Areas.Admin.Models.VMs
{
    public class CreateReceteVM
    {
       
        [Required(ErrorMessage = "Bu alan bş bırakılamaz!")]
        [MinLength(2), MaxLength(100)]
        public string UrunAdi { get; set; }

        [Required(ErrorMessage = "bu alan boş bırakılamaz")]
        public Microsoft.AspNetCore.Http.IFormFile Image { get; set; }
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Bu alan bş bırakılamaz!")]
    
        public int UrunFiyat { get; set; }

        public int AnaGrupID { get; set; }
        public List<GetAnaGrupDTO>  Anagrup { get; set; }

    }
}
