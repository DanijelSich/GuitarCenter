using GuitarCenter.AppService.Messages.Users;
using GuitarCenter.Model.Entities.Users;
using System;

namespace GuitarCenter.AppService.Mappings.Users
{
    public static class UserMapper
    {
        public static User ConvertToUser(this CreateUserRequest createRequest)
        {
            User user = new User();
            user.UserId = createRequest.UserId;
            user.Username = createRequest.Username;
            user.Password = createRequest.Password;
            user.Email = createRequest.Email;
            user.Role = (Role)Enum.Parse(typeof(Role), createRequest.Role);

            return user;
        }

        public static User ConvertToUser(this UpdateUserRequest updateRequest)
        {
            User user = new User();
            user.UserId = updateRequest.UserId;
            user.Username = updateRequest.Username;
            user.Password = updateRequest.Password;
            user.Email = updateRequest.Email;
            user.Role = (Role)Enum.Parse(typeof(Role), updateRequest.Role);

            return user;
        }
    }
}