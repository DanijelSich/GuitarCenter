using GuitarCenter.Model.Entities.Brands;
using GuitarCenter.Model.Entities.Categories;
using GuitarCenter.Model.Entities.Products;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace GuitarCenter.Repository.Products
{
    public class ProductRepository : IProductRepository
    {
        private string _connectionString;

        public ProductRepository()
        {
            _connectionString =
                ConfigurationManager.ConnectionStrings["EStoreConnectionString"].ConnectionString;
        }

        public List<Product> ReadAll()
        {
            List<Product> products = new List<Product>();
            string queryStringProduct =
                "SELECT p.ProductId, p.Name, p.Description, p.Price, p.Color, p.Size, p.ImageData, p.ImageMimeType, " +
                "       b.BrandId, b.Name, " +
                "       c.CategoryId, c.Name " +
                "FROM dbo.T_PRODUCT p, dbo.T_BRAND b, dbo.T_CATEGORY c " +
                "WHERE p.BrandId = b.BrandId AND p.CategoryId = c.CategoryId";
            string queryStringProductImages =
                "SELECT ProductId, ImageData, ImageMimeType FROM dbo.T_PRODUCT_IMAGE WHERE ProductId = @ProductId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = queryStringProduct;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Product product;
                    while (reader.Read())
                    {
                        product = new Product();
                        product.ProductId = Int32.Parse(reader[0].ToString());
                        product.Name = reader[1].ToString();
                        product.Description = reader[2].ToString();
                        product.Price = Decimal.Parse(reader[3].ToString());
                        product.Color = reader[4].ToString();
                        product.Size = reader[5].ToString();

                        product.ProductImage = new ProductImage();
                        product.ProductImage.ImageData = string.IsNullOrEmpty(reader[6].ToString()) ? null : (byte[])reader[6];
                        product.ProductImage.ImageMimeType = reader[7].ToString();

                        product.Brand = new Brand();
                        product.Brand.BrandId = Int32.Parse(reader[8].ToString());
                        product.Brand.Name = reader[9].ToString();

                        product.Category = new Category();
                        product.Category.CategoryId = Int32.Parse(reader[10].ToString());
                        product.Category.Name = reader[11].ToString();

                        products.Add(product);
                    }
                }

                foreach (Product product in products)
                {
                    product.ProductImages = new List<ProductImage>();
                    SqlCommand commandProductImage = connection.CreateCommand();
                    commandProductImage.CommandText = queryStringProductImages;
                    commandProductImage.Parameters.Add(new SqlParameter("@ProductId", product.ProductId));
                    using (SqlDataReader reader = commandProductImage.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductImage productImage = new ProductImage();
                            productImage.ImageData = (byte[])reader[1];
                            productImage.ImageMimeType = reader[2].ToString();
                            product.ProductImages.Add(productImage);
                        }
                    }
                }
            }
            return products;
        }

        public void Update(Product entity)
        {
            string updateProductSql =
                "UPDATE T_PRODUCT SET Name = @Name, Description = @Description, Price = @Price, Color = @Color, " +
                "Size = @Size, BrandId = @BrandId, CategoryId = @CategoryId, ImageData = @ImageData, ImageMimeType = @ImageMimeType " +
                "WHERE ProductId = @ProductId;";
            string deleteProductImageSql =
                "DELETE T_PRODUCT_IMAGE WHERE ProductId = @ProductId;";
            string insertProductImageSql =
                "INSERT INTO T_PRODUCT_IMAGE (ProductId, ImageData, ImageMimeType) " +
                "VALUES (@ProductId, @ImageData, @ImageMimeType)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand commandProduct = connection.CreateCommand();
                commandProduct.CommandText = updateProductSql;
                commandProduct.Parameters.Add(new SqlParameter("@ProductId", entity.ProductId));
                commandProduct.Parameters.Add(new SqlParameter("@Name", entity.Name));
                commandProduct.Parameters.Add(new SqlParameter("@Description", entity.Description));
                commandProduct.Parameters.Add(new SqlParameter("@Price", entity.Price));
                commandProduct.Parameters.Add(new SqlParameter("@Color", entity.Color));
                commandProduct.Parameters.Add(new SqlParameter("@Size", entity.Size));
                commandProduct.Parameters.Add(new SqlParameter("@BrandId", entity.Brand.BrandId));
                commandProduct.Parameters.Add(new SqlParameter("@CategoryId", entity.Category.CategoryId));
                commandProduct.Parameters.Add(new SqlParameter("@ImageData", entity.ProductImage.ImageData));
                commandProduct.Parameters.Add(new SqlParameter("@ImageMimeType", entity.ProductImage.ImageMimeType));
                connection.Open();
                commandProduct.ExecuteNonQuery();

                SqlCommand commandDeleteProductImages = connection.CreateCommand();
                commandDeleteProductImages.CommandText = deleteProductImageSql;
                commandDeleteProductImages.Parameters.Add(new SqlParameter("@ProductId", entity.ProductId));
                commandDeleteProductImages.ExecuteNonQuery();

                SqlCommand commandInsertProductImages = connection.CreateCommand();
                commandInsertProductImages.CommandText = insertProductImageSql;
                foreach (ProductImage productImage in entity.ProductImages)
                {
                    commandInsertProductImages.Parameters.Clear();
                    commandInsertProductImages.Parameters.Add(new SqlParameter("@ProductId", entity.ProductId));
                    commandInsertProductImages.Parameters.Add(new SqlParameter("@ImageData", productImage.ImageData));
                    commandInsertProductImages.Parameters.Add(new SqlParameter("@ImageMimeType", productImage.ImageMimeType));
                    commandInsertProductImages.ExecuteNonQuery();
                }
            }
        }

        public void Create(Product entity)
        {
            string insertProductSql =
                "INSERT INTO T_PRODUCT (Name, Description, Price, Color, Size, BrandId, CategoryId, ImageData, ImageMimeType) " +
                "VALUES (@Name, @Description, @Price, @Color, @Size, @BrandId, @CategoryId, @ImageData, @ImageMimeType); " +
                "SELECT CAST(SCOPE_IDENTITY() AS INT);";
            string insertProductImageSql =
                "INSERT INTO T_PRODUCT_IMAGE (ProductId, ImageData, ImageMimeType) " +
                "VALUES (@ProductId, @ImageData, @ImageMimeType)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand commandProduct = connection.CreateCommand();
                commandProduct.CommandText = insertProductSql;
                commandProduct.Parameters.Add(new SqlParameter("@Name", entity.Name));
                commandProduct.Parameters.Add(new SqlParameter("@Description", entity.Description));
                commandProduct.Parameters.Add(new SqlParameter("@Price", entity.Price));
                commandProduct.Parameters.Add(new SqlParameter("@Color", entity.Color));
                commandProduct.Parameters.Add(new SqlParameter("@Size", entity.Size));
                commandProduct.Parameters.Add(new SqlParameter("@BrandId", entity.Brand.BrandId));
                commandProduct.Parameters.Add(new SqlParameter("@CategoryId", entity.Category.CategoryId));
                commandProduct.Parameters.Add(new SqlParameter("@ImageData", entity.ProductImage.ImageData));
                commandProduct.Parameters.Add(new SqlParameter("@ImageMimeType", entity.ProductImage.ImageMimeType));
                connection.Open();
                int insertedId = (int)commandProduct.ExecuteScalar();

                SqlCommand commandProductImage = connection.CreateCommand();
                commandProductImage.CommandText = insertProductImageSql;
                foreach (ProductImage productImage in entity.ProductImages)
                {
                    commandProductImage.Parameters.Clear();
                    commandProductImage.Parameters.Add(new SqlParameter("@ProductId", insertedId));
                    commandProductImage.Parameters.Add(new SqlParameter("@ImageData", productImage.ImageData));
                    commandProductImage.Parameters.Add(new SqlParameter("@ImageMimeType", productImage.ImageMimeType));
                    commandProductImage.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            string deleteSql = "DELETE T_PRODUCT WHERE ProductId = @ProductId;" +
                "DELETE T_PRODUCT_IMAGE WHERE ProductId = @ProductId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = deleteSql;
                command.Parameters.Add(new SqlParameter("@ProductId", id));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
