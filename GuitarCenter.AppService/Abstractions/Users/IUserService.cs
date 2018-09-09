using System;
using System.Collections.Generic;
using GuitarCenter.AppService.Messages.Users;
using System.Text;
using System.Threading.Tasks;

namespace GuitarCenter.AppService.Abstractions.Users
{
    public interface IUserService
    {
        CreateUserResponse CreateUser(CreateUserRequest request);
        FindAllUsersResponse ReadUsers();
        UpdateUserResponse UpdateUser(UpdateUserRequest request);
        DeleteUserResponse DeleteUser(DeleteUserRequest request);
        AuthenticateUserResponse AuthenticateUser(AuthenticateUserRequest request);
    }
}