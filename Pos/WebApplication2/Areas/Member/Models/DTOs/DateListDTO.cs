using Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Areas.Member.Models.DTOs
{
    public class DateListDTO
    {
        public  SatisHrk Item { get; set; }
        public DateTime Baslangic { get; set; }
        public DateTime Bitis { get; set; }
        public int Selected { get; set; }


    }
}
