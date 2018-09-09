using GuitarCenter.Model.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace GuitarCenter.Repository.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private string _connectionString;

        public CategoryRepository()
        {
            _connectionString =
                ConfigurationManager.ConnectionStrings["EStoreConnectionString"].ConnectionString;
        }

        public void Create(Category entity)
        {
            string insertSql = "INSERT INTO T_CATEGORY (Name) " +
                "VALUES (@Name)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = insertSql;
                command.Parameters.Add(new SqlParameter("@CategoryId", entity.CategoryId));
                command.Parameters.Add(new SqlParameter("@Name", entity.Name));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string deleteSql = "DELETE T_CATEGORY WHERE CategoryId = @CategoryId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = deleteSql;
                command.Parameters.Add(new SqlParameter("@CategoryId", id));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Category> ReadAll()
        {
            List<Category> categories = new List<Category>();
            string queryString = "SELECT * FROM dbo.T_CATEGORY";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = queryString;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Category category;
                    while (reader.Read())
                    {
                        category = new Category();
                        category.CategoryId = Int32.Parse(reader["CategoryId"].ToString());
                        category.Name = reader["Name"].ToString();
                        categories.Add(category);
                    }
                }
            }
            return categories;
        }

        public void Update(Category entity)
        {
            string updateSql = "UPDATE dbo.T_CATEGORY SET Name = @Name WHERE CategoryId = @CategoryId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = updateSql;
                command.Parameters.Add(new SqlParameter("@CategoryId", entity.CategoryId));
                command.Parameters.Add(new SqlParameter("@Name", entity.Name));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}