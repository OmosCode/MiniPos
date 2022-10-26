using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Areas.Admin.Models.DTOs
{
    public class DTO
    {
        public int ID { get; set; }
        public string UrunAdi { get; set; }
        public int Adet { get; set; }
        public int ToplamTutar { get; set; }

    }
}
