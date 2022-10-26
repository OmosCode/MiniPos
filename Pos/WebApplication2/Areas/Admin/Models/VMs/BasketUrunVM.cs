using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Areas.Admin.Models.VMs
{
    public class BasketUrunVM
    {
        public string UrunAdi { get; set; }

        public int Fiyat { get; set; }

        public int ReceteID { get; set; }

        public int AppUserId { get; set; }

        public int ToplamTutar { get; set; }
    }
}
