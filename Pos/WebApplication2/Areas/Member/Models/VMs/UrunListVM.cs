using Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Areas.Member.Models.VMs
{
    public class UrunListVM
    {
        public int ID { get; set; }
        public string UrunAdi { get; set; }


        public string ImagePath { get; set; }  // dosya yolunu tutacak



        public int UrunFiyat { get; set; }




        // 1 ürünün 1 ana grubu olur.
        public int AnaGrupID { get; set; }

       

        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }
    }
}
