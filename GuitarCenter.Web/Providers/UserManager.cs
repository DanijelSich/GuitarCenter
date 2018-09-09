using GuitarCenter.AppService.Abstractions.Users;
using GuitarCenter.Model.Entities.Users;
using GuitarCenter.Web.Infrastructure;
using GuitarCenter.Web.Mappings.Users;
using GuitarCenter.Web.Models.Users;
using System;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace GuitarCenter.Web.Providers
{
    public static class UserManager
    {
        public static UserViewModel User
        {
            get
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    // The user is authenticated. Return the user from the forms auth ticket.
                    return ((EStorePrincipal)(HttpContext.Current.User)).User;
                }
                else if (HttpContext.Current.Items.Contains("User"))
                {
                    // The user is not authenticated, but has successfully logged in.
                    return (UserViewModel)HttpContext.Current.Items["User"];
                }
                else
                {
                    return null;
                }
            }
        }

        public static UserViewModel AuthenticateUser(string email, string password)
        {
            UserViewModel user = null;

            IUserService userService = (IUserService)new NinjectDependencyResolver().GetService(typeof(IUserService));
            User dbUser = userService.ReadUsers().
                Users.Where(x => x.Email == email && x.Password == password).
                FirstOrDefault();

            // Lookup user in database, web service, etc. We'll just generate a fake user for this demo.
            if (dbUser != null)
            {
                user = new UserViewModel { UserId = dbUser.UserId, Username = dbUser.Username, Email = dbUser.Email, Role = dbUser.Role };
            }

            return user;
        }

        public static bool ValidateUser(UserViewModel logonUser, HttpResponseBase response)
        {
            bool result = false;

            if (Membership.ValidateUser(logonUser.Email, logonUser.Password))
            {
                // Create the authentication ticket with custom user data.
                var serializer = new JavaScriptSerializer();
                string userData = serializer.Serialize(UserManager.User);

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                        UserManager.User.Username,
                        DateTime.Now,
                        DateTime.Now.AddDays(30),
                        true,
                        userData,
                        FormsAuthentication.FormsCookiePath);

                // Encrypt the ticket.
                string encTicket = FormsAuthentication.Encrypt(ticket);

                // Create the cookie.
                response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                result = true;
            }
            return result;
        }

        public static void Logoff(HttpSessionStateBase session, HttpResponseBase response)
        {
            // Delete the user details from cache.
            session.Abandon();

            // Delete the authentication ticket and sign out.
            FormsAuthentication.SignOut();

            // Clear authentication cookie.
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            response.Cookies.Add(cookie);
        }
    }
}
