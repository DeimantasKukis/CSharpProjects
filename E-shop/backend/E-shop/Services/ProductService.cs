using E_shop.Models;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Collections.Generic;


namespace E_shop.Services
{
    public class ProductService
    {
        private string _connection;

        public ProductService()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .Build();
            _connection = config.GetValue<string>("ConnectionStrings:DefaultConnection");
        }
    public List<Product> GetProducts()
        {
            MySqlConnection conn = new MySqlConnection(_connection);
            conn.Open();

            var products = new List<Product>();

            using(var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT productId, productName, productDescription, startPrice, discount, photo FROM products";
                var reader = cmd.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        var product = new Product(
                            reader.GetString(1),
                            reader.GetString(0),
                            reader.GetString(2),
                            reader.GetDouble(3),
                            reader.GetDouble(4),
                            reader.GetString(5)
                        );
                        products.Add(product);
                    
                    }
                }
            }
            return products;
  
        }
       public Product GetProduct(string productId)
        {
            MySqlConnection conn = new MySqlConnection(_connection);

            conn.Open();
            using(var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT productId, productName, productDescription, startPrice, discount, photo FROM products WHERE productId=@productId";

                cmd.Parameters.Add(
                    new MySqlParameter()
                {
                    ParameterName = "@productId",
                    DbType = System.Data.DbType.String,
                    Value = productId
                }
                );

                var reader = cmd.ExecuteReader();

                using (reader)
                {
                    reader.Read();

                    return new Product(
                            reader.GetString(1),
                            reader.GetString(0),
                            reader.GetString(2),
                            reader.GetDouble(3),
                            reader.GetDouble(4),
                            reader.GetString(5));

                }
            
            }
        }
       
        public void CreateProduct(Product product)
        {
            MySqlConnection conn = new MySqlConnection(_connection);

            conn.Open();

            using(var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO products(productId, productName, productDescription, startPrice, discount, photo)" +
                    "VALUES(@productId, @productName, @productDescription, @startPrice, @discount, @photo)";
                cmd.Parameters.Add(
                    new MySqlParameter()
                    {
                    ParameterName = "@productId",
                    DbType = System.Data.DbType.String,
                    Value = product.Id
                }
                );

                cmd.Parameters.Add(
                    new MySqlParameter()
                    {
                        ParameterName = "@productName",
                        DbType = System.Data.DbType.String,
                        Value = product.ProductName
                    }
                    );

                cmd.Parameters.Add(
                    new MySqlParameter()
                    {
                        ParameterName = "@productDescription",
                        DbType = System.Data.DbType.String,
                        Value = product.ProductDescription
                    }
                    );

                cmd.Parameters.Add(
                    new MySqlParameter()
                    {
                        ParameterName = "@startPrice",
                        DbType = System.Data.DbType.Double,
                        Value = product.StartPrice
                    }
                    );

                cmd.Parameters.Add(
                    new MySqlParameter()
                    {
                        ParameterName = "@discount",
                        DbType = System.Data.DbType.Int32,
                        Value = product.Discount
                    }
                    );
                cmd.Parameters.Add(
                    new MySqlParameter()
                    {
                        ParameterName = "@photo",
                        DbType = System.Data.DbType.String,
                        Value = product.Photo
                    });
                cmd.ExecuteNonQuery();

            }
        }

    }
}
