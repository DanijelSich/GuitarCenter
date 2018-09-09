using System;
using System.Collections.Generic;
using GuitarCenter.Web.Models.Users;
using System.Web;

namespace GuitarCenter.Web.Areas.Administrations.Models
{
    public class UserListPageViewModel
    {
        public List<UserViewModel> UserViewModels { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}