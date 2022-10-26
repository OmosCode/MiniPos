using Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Areas.Admin.Models.VMs
{
    public class CreateBasketVM
    {

        
        public int Adet { get; set; }
        public int Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }


        public int ReceteID { get; set; }

        //public Recete Recete { get; set; }



        public int AppUserId { get; set; }

        //public AppUser AppUser { get; set; }

    }
}
