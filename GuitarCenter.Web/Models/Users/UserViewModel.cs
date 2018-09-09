using System;
using System.Collections.Generic;
using GuitarCenter.Model.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace GuitarCenter.Web.Models.Users
{
    public class UserViewModel
    {
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "Korisničko ime mora biti uneto")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Lozinka mora biti uneta")]
        public string Password { get; set; }
        [Required(ErrorMessage = "E-mail adresa mora biti uneta")]
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}