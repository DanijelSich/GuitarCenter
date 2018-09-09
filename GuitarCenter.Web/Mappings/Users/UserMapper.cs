using GuitarCenter.Model.Entities.Users;
using GuitarCenter.Web.Models.Users;
using System.Collections.Generic;

namespace GuitarCenter.Web.Mappings.Users
{
    public static class UserMapper
    {
        public static List<UserViewModel> ConvertToUserViewModelList(this List<User> users)
        {
            List<UserViewModel> userViewModels = new List<UserViewModel>();
            foreach (User user in users)
            {
                userViewModels.Add(user.ConvertToUserViewModel());
            }
            return userViewModels;
        }

        public static UserViewModel ConvertToUserViewModel(this User user)
        {
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.UserId = user.UserId;
            userViewModel.Username = user.Username;
            userViewModel.Email = user.Email;
            userViewModel.Password = user.Password;
            userViewModel.Role = user.Role;

            return userViewModel;
        }
    }
}
