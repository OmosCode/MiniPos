using Microsoft.AspNetCore.Http;
using Model.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Entities.Concrete
{
  public  class AppUser : BaseEntity
    {
        public AppUser()
        {
            Recetes = new List<Recete>();
            satisHrk = new List<SatisHrk>();
            Basket = new List<Basket>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string IdentityId { get; set; }

        public string FullName => FirstName + " " + LastName;


      


        public List<Recete> Recetes { get; set; }
        public List<SatisHrk>  satisHrk { get; set; }
        public List<Basket>  Basket { get; set; }



    }
}
