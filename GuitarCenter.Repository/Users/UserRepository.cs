using GuitarCenter.Model.Entities.Users;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace GuitarCenter.Repository.Users
{
    public class UserRepository : IUserRepository
    {
        private string _connectionString;

        public UserRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["EStoreConnectionString"].ConnectionString;
        }

        public List<User> ReadAll()
        {
            List<User> users = new List<User>();
            string queryString = "SELECT * FROM dbo.T_USER";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = queryString;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    User user;
                    while (reader.Read())
                    {
                        user = new User();
                        user.UserId = new Guid(reader["UserId"].ToString());
                        user.Username = reader["Username"].ToString();
                        user.Password = reader["Password"].ToString();
                        user.Email = reader["Email"].ToString();
                        user.Role = (Role)Enum.Parse(typeof(Role), reader["Role"].ToString());
                        users.Add(user);
                    }
                }
            }
            return users;
        }

        public void Update(User entity)
        {
            string updateSql = "UPDATE dbo.T_USER SET Username = @Username, " +
                "Password = @Password, Email = @Email, Role = @Role WHERE UserId = @UserId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = updateSql;
                command.Parameters.Add(new SqlParameter("@UserId", entity.UserId));
                command.Parameters.Add(new SqlParameter("@Username", entity.Username));
                command.Parameters.Add(new SqlParameter("@Password", entity.Password));
                command.Parameters.Add(new SqlParameter("@Email", entity.Email));
                command.Parameters.Add(new SqlParameter("@Role", entity.Role));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Create(User entity)
        {
            string insertSql = "INSERT INTO T_USER (UserId, Username, Password, Email, Role) " +
                "VALUES (@UserId, @Username, @Password, @Email, @Role)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = insertSql;
                command.Parameters.Add(new SqlParameter("@UserId", entity.UserId));
                command.Parameters.Add(new SqlParameter("@Username", entity.Username));
                command.Parameters.Add(new SqlParameter("@Password", entity.Password));
                command.Parameters.Add(new SqlParameter("@Email", entity.Email));
                command.Parameters.Add(new SqlParameter("@Role", entity.Role));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(Guid userId)
        {
            string deleteSql = "DELETE T_USER WHERE UserId = @UserId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = deleteSql;
                command.Parameters.Add(new SqlParameter("@UserId", userId));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
