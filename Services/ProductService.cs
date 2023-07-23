using PurchaseOrderExtraction.Models;
using System.Data.SqlClient;

namespace PurchaseOrderExtraction.Services
{
    public class ProductService : IProductService
    {
        //private static string db_source = "poserver1.database.windows.net";
        //private static string db_name = "podb";
        //private static string db_userid = "sqlAdmin";
        //private static string db_password = "Mitsui@123";

        private readonly IConfiguration _configuration;

        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Get Connection
        private SqlConnection GetConnection()
        {
            //var _builder = new SqlConnectionStringBuilder();
            //_builder.DataSource = db_source;
            //_builder.UserID = db_userid;
            //_builder.Password = db_password;
            //_builder.InitialCatalog = db_name;
            //return new SqlConnection(_builder.ConnectionString);

            return new SqlConnection(_configuration.GetConnectionString("SQLConnection"));
        }

        public List<Product> GetProducts()
        {
            var products = new List<Product>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var sql = "SELECT * FROM Products";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product
                            {
                                ProductId = reader.GetInt32(0),
                                ProductName = reader.GetString(1),
                                Quantity = reader.GetInt32(2)
                            });
                        }
                    }
                }
                connection.Close();
            }
            return products;
        }


        //Get Connection string
        //private static string GetConnectionString()
        //{
        //    return $"Data Source={db_source};Initial Catalog={db_name};User ID={db_userid};Password={db_password}";
        //}

    }
}
