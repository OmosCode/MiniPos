using Model.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities.Concrete
{
   public class SatisHrk:BaseEntity
    {
        
       

        

        public int Adet { get; set; }

        public decimal ToplamTutar { get; set; }

        public int Fiyat { get; set; }
        public int ReceteID { get; set; }

        public Recete  Recete { get; set; }



        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }


    }
}
