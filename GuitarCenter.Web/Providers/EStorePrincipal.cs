using System;
using System.Collections.Generic;
using GuitarCenter.Web.Models.Users;
using System.Security.Principal;

namespace GuitarCenter.Web.Providers
{
    public class EStorePrincipal : IPrincipal
    {
        public EStorePrincipal(IIdentity identity)
        {
            Identity = identity;
        }

        public IIdentity Identity
        {
            get;
            private set;
        }

        public UserViewModel User { get; set; }

        public bool IsInRole(string role)
        {
            if (User.Role.ToString() == role)
            {
                return true;
            }
            return false;
        }
    }
}