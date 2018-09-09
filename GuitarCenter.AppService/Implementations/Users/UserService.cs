using GuitarCenter.AppService.Abstractions.Users;
using GuitarCenter.AppService.Mappings.Users;
using GuitarCenter.AppService.Messages.Users;
using GuitarCenter.Model.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuitarCenter.AppService.Implementations.Users
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public CreateUserResponse CreateUser(CreateUserRequest request)
        {
            CreateUserResponse response = new CreateUserResponse();
            try
            {
                User user = request.ConvertToUser();

                List<User> users = userRepository.ReadAll();

                if (users.Where(x => x.Username == user.Username).Count() > 0)
                    throw new Exception("Korisnik sa datim korisničkim imenom već postoji u bazi!");

                if (users.Where(x => x.Password == user.Password).Count() > 0)
                    throw new Exception("Korisnik sa datim email-om već postoji u bazi!");

                userRepository.Create(user);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public FindAllUsersResponse ReadUsers()
        {
            FindAllUsersResponse response = new FindAllUsersResponse();
            try
            {
                response.Users = userRepository.ReadAll();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public UpdateUserResponse UpdateUser(UpdateUserRequest request)
        {
            UpdateUserResponse response = new UpdateUserResponse();
            try
            {
                User user = request.ConvertToUser();
                userRepository.Update(user);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }


        public DeleteUserResponse DeleteUser(DeleteUserRequest request)
        {
            DeleteUserResponse response = new DeleteUserResponse();
            try
            {
                userRepository.Delete(request.UserId);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public AuthenticateUserResponse AuthenticateUser(AuthenticateUserRequest request)
        {
            AuthenticateUserResponse response = new AuthenticateUserResponse();

            try
            {
                response.Authenticated = userRepository.ReadAll().
                    Exists(x => x.Email == request.Email && x.Password == request.Password);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }
    }
}
