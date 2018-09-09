using GuitarCenter.AppService.Messages.Abstractions;
using GuitarCenter.Model.Entities.Users;
using System.Collections.Generic;

namespace GuitarCenter.AppService.Messages.Users
{
    public class FindAllUsersResponse : ResponseBase
    {
        public List<User> Users { get; set; }
    }
}