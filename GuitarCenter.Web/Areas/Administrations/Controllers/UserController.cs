using GuitarCenter.AppService.Abstractions.Users;
using GuitarCenter.AppService.Messages.Users;
using GuitarCenter.Web.Areas.Administrations.Models;
using GuitarCenter.Web.Mappings.Users;
using GuitarCenter.Web.Models.Users;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GuitarCenter.Web.Areas.Administrations.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Index()
        {
            UserListPageViewModel model = new UserListPageViewModel();
            FindAllUsersResponse response = userService.ReadUsers();
            if (response.Success)
            {
                model.UserViewModels = response.Users.ConvertToUserViewModelList();
                model.Success = true;
            }
            else
            {
                model.Success = false;
                model.ErrorMessage = response.Message;
            }

            return View(model);
        }

        public ActionResult Create()
        {
            UserSinglePageViewModel model = new UserSinglePageViewModel();
            model.UserViewModel = new UserViewModel();
            model.Success = true;
            return View("Edit", model);
        }

        public ActionResult Edit(Guid userId)
        {
            UserSinglePageViewModel model = new UserSinglePageViewModel();
            FindAllUsersResponse response = userService.ReadUsers();
            if (response.Success)
            {
                model.UserViewModel = response.Users.
                    Where(x => x.UserId == userId).
                    FirstOrDefault().
                    ConvertToUserViewModel();
                model.Success = true;
            }
            else
            {
                model.Success = false;
                model.ErrorMessage = response.Message;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UserSinglePageViewModel model)
        {
            if (model.UserViewModel.UserId.Equals(Guid.Empty))
            {
                CreateUserRequest request = new CreateUserRequest();
                CreateUserResponse response = new CreateUserResponse();
                request.UserId = Guid.NewGuid();
                request.Username = model.UserViewModel.Username;
                request.Password = model.UserViewModel.Password;
                request.Email = model.UserViewModel.Email;
                request.Role = model.UserViewModel.Role.ToString();

                response = userService.CreateUser(request);
                if (response.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    model.Success = false;
                    model.ErrorMessage = response.Message;
                    return View(model);
                }
            }
            else
            {
                UpdateUserRequest request = new UpdateUserRequest();
                UpdateUserResponse response = new UpdateUserResponse();
                request.UserId = model.UserViewModel.UserId;
                request.Username = model.UserViewModel.Username;
                request.Password = model.UserViewModel.Password;
                request.Email = model.UserViewModel.Email;
                request.Role = model.UserViewModel.Role.ToString();

                response = userService.UpdateUser(request);
                if (response.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    model.Success = false;
                    model.ErrorMessage = response.Message;
                    return View(model);
                }
            }
        }

        public ActionResult Delete(Guid userId)
        {
            DeleteUserRequest request = new DeleteUserRequest();
            DeleteUserResponse response = new DeleteUserResponse();
            request.UserId = userId;
            response = userService.DeleteUser(request);
            if (response.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ProductListPageViewModel model = new ProductListPageViewModel();
                model.Success = false;
                model.ErrorMessage = response.Message;
                return View("Index", model);
            }
        }
    }
}
