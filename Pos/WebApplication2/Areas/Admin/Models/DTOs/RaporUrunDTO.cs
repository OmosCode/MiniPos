using Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Areas.Admin.Models.DTOs
{
    public class RaporUrunDTO
    {
       
        public int ReceteID { get; set; }
        public string UrunAdi { get; set; }
        public int Adet { get; set; }

        public decimal ToplamTutar { get; set; }

        public int Fiyat { get; set; }
        public Recete Recete { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
