using GuitarCenter.Web.Infrastructure;
using GuitarCenter.Web.Models.Users;
using GuitarCenter.Web.Providers;
using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace GuitarCenter.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            DependencyResolver.SetResolver(new NinjectDependencyResolver());

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                // Get the forms authentication ticket.
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                var identity = new GenericIdentity(authTicket.Name, "Forms");
                var principal = new EStorePrincipal(identity);

                // Get the custom user data encrypted in the ticket.
                string userData = ((FormsIdentity)(Context.User.Identity)).Ticket.UserData;

                // Deserialize the json data and set it on the custom principal.
                var serializer = new JavaScriptSerializer();
                principal.User = (UserViewModel)serializer.Deserialize(userData, typeof(UserViewModel));

                // Set the context user.
                Context.User = principal;
            }
        }
    }
}