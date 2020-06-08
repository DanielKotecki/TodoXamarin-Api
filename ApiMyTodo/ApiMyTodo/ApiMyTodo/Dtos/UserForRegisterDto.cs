using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMyTodo.Dtos
{
    public class UserForRegisterDto
    {
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Hasło jest wymagana")]
        [StringLength(9, MinimumLength = 4, ErrorMessage = "Hasło musi mieć od 4 do 9 znaków")]
        public string Password { get; set; }


    }
}
