using Model.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities.Concrete
{
   public class Rec_Category: BaseEntity
    {
        public Rec_Category()
        {
            Recete = new List<Recete>();   
        }
      
        public string UrunAnagrup { get; set; }


        public List<Recete> Recete { get; set; }


    }
}
