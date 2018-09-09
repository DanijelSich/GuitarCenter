using GuitarCenter.Model.Entities.Brands;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace GuitarCenter.Repository.Brands
{
    public class BrandRepository : IBrandRepository
    {
        private string _connectionString;

        public BrandRepository()
        {
            _connectionString =
                ConfigurationManager.ConnectionStrings["EStoreConnectionString"].ConnectionString;
        }

        public void Create(Brand entity)
        {
            string insertSql = "INSERT INTO T_BRAND (Name) " +
                "VALUES (@Name)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = insertSql;
                command.Parameters.Add(new SqlParameter("@BrandId", entity.BrandId));
                command.Parameters.Add(new SqlParameter("@Name", entity.Name));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string deleteSql = "DELETE T_BRAND WHERE BrandId = @BrandId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = deleteSql;
                command.Parameters.Add(new SqlParameter("@BrandId", id));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Brand> ReadAll()
        {
            List<Brand> brands = new List<Brand>();
            string queryString = "SELECT * FROM dbo.T_BRAND";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = queryString;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Brand brand;
                    while (reader.Read())
                    {
                        brand = new Brand();
                        brand.BrandId = Int32.Parse(reader["BrandId"].ToString());
                        brand.Name = reader["Name"].ToString();
                        brands.Add(brand);
                    }
                }
            }
            return brands;
        }

        public void Update(Brand entity)
        {
            string updateSql = "UPDATE dbo.T_BRAND SET Name = @Name WHERE BrandId = @BrandId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = updateSql;
                command.Parameters.Add(new SqlParameter("@BrandId", entity.BrandId));
                command.Parameters.Add(new SqlParameter("@Name", entity.Name));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}