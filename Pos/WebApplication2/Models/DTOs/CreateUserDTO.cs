using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models.DTOs
{
    public class CreateUserDTO
    {

        [Required(ErrorMessage = "alan boş bırakılamaz")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "alan boş bırakılamaz")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "alan boş bırakılamaz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "alan boş bırakılamaz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ImagePath { get; set; }

      

        [Required(ErrorMessage = "alan boş bırakılamaz")]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }


    }
}
