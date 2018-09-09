using GuitarCenter.AppService.Abstractions.Users;
using GuitarCenter.AppService.Messages.Users;
using GuitarCenter.Model.Entities.Users;
using GuitarCenter.Web.Models.Users;
using GuitarCenter.Web.Providers;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace GuitarCenter.Web.Controllers
{
    public class AccountController : Controller
    {
        IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel user, string returnUrl)
        {
            if (UserManager.ValidateUser(user, Response))
            {
                return Redirect(returnUrl ?? Url.Action("Index", "Product", new { area = "Products" }));
            }
            else
            {
                ViewBag.ErrorMessage = "Nije korektno korisničko ime ili lozinka";
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Product", new { area = "Products" });
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserViewModel user)
        {
            CreateUserRequest request = new CreateUserRequest();
            CreateUserResponse response = new CreateUserResponse();
            request.UserId = Guid.NewGuid();
            request.Username = user.Username;
            request.Password = user.Password;
            request.Email = user.Email;
            request.Role = Role.User.ToString();
            response = userService.CreateUser(request);
            if (response.Success)
            {
                UserManager.ValidateUser(user, Response);
                return Redirect(Url.Action("Index", "Product", new { area = "Products" }));
            }
            else
            {
                ViewBag.ErrorMessage = "Nije korektno korisničko ime ili lozinka";
                return View();
            }
        }
    }
}
