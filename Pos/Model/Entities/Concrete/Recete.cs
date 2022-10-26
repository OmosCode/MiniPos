using Microsoft.AspNetCore.Http;
using Model.Entities.Abstract;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Entities.Concrete
{
  public  class Recete :BaseEntity
    {
        public Recete()
        {
            satisHrk = new List<SatisHrk>();
            Basket = new List<Basket>();
            
        }
      
      
        public string UrunAdi { get; set; }


        public string ImagePath { get; set; }  // dosya yolunu tutacak

        [NotMapped]
        public IFormFile Image { get; set; } // dosyayı okuyup,kaydedecek.


        public int UrunFiyat { get; set; }

        private Boyut _boyuts = Boyut.tam;

        public Boyut Boyut
        {
            get { return _boyuts; }
            set { _boyuts = value; }
        }


        // 1 ürünün 1 ana grubu olur.
        public int AnaGrupID { get; set; }

        public Rec_Category  Rec_Category { get; set; }

        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public List<SatisHrk>  satisHrk { get; set; }
        public List<Basket>  Basket { get; set; }
      

    }
}
