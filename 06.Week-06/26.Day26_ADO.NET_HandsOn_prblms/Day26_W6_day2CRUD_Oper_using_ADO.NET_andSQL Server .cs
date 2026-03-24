using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace ProdcutApp
{
    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"ID: {ProductId}, Name: {ProductName}, Category:{Category},Price:{Price}";
        }
    }

    class Program
    {
        static string connStr;
        static void Main(string[] args)
        {
            // Build configuration
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            //now read the connecting string
            connStr = config.GetConnectionString("DefaultConnection");
            while (true)
            { 
                Console.WriteLine("=======PRODUCT MANAGEMENT APP=====================");
                Console.WriteLine("\n1.Insert || 2.Delete  || 3.Update ||  4.View || 5.GetProductById || 6.Exit");
                Console.Write("Enter choice: ");
                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            InsertProduct();
                            break;
                        case 2:
                            DeleteProduct();
                            break;
                        case 3:
                            UpdateProduct();
                            break;
                        case 4:
                            ViewProducts();
                            break;
                        case 5:
                            GetProductById();
                            break;
                        case 6: return;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
               
            }

        }
        //==================Inserting===========
        static void InsertProduct()
        {
            Product p = new Product();

            Console.Write("Name: ");
            p.ProductName = Console.ReadLine();

            Console.Write("Category: ");
            p.Category = Console.ReadLine();

            Console.Write("Price: ");
            p.Price = decimal.Parse(Console.ReadLine());

            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("sp_InsertProduct", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductName", p.ProductName);
            cmd.Parameters.AddWithValue("@Category", p.Category);
            cmd.Parameters.AddWithValue("@Price", p.Price);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine(" Product is Inserted");
        }
        //===================delete===================
        static void DeleteProduct()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());

            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("sp_DeleteProduct", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductId", id);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Product is Deleted");

        }
        //=======================update=================
        static void UpdateProduct()
        {
            Product p = new Product();

            Console.Write("Enter ID: ");
            p.ProductId = int.Parse(Console.ReadLine());

            Console.Write("New Name: ");
            p.ProductName = Console.ReadLine();

            Console.Write("New Category: ");
            p.Category = Console.ReadLine();

            Console.Write("New Price: ");
            p.Price = decimal.Parse(Console.ReadLine());

            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("sp_UpdateProduct", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductId", p.ProductId);
            cmd.Parameters.AddWithValue("@ProductName", p.ProductName);
            cmd.Parameters.AddWithValue("@Category", p.Category);
            cmd.Parameters.AddWithValue("@Price", p.Price);

            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("===Product Updated====");
        }
        //=====================view all products===========================
        static void ViewProducts()
        {
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("sp_GetAllProducts", con);

            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product> list = new List<Product>();
            while (reader.Read())
            {
                Product p = new Product()
                {
                    ProductId = (int)reader["ProductId"],
                    ProductName = reader["ProductName"].ToString(),
                    Category = reader["Category"].ToString(),
                    Price = (decimal)reader["Price"]

                };
                list.Add(p);
            }
            Console.WriteLine("\n--- Product List ---");
            foreach (var p in list)
                Console.WriteLine(p);
        }

        //===================get product by id particular=======
        static void GetProductById()
        {
            Console.Write("Enter Product ID: ");
            int id = int.Parse(Console.ReadLine());

            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("GetProductByID", con);

            cmd.CommandType = CommandType.StoredProcedure;

            // pass parameter
            cmd.Parameters.AddWithValue("@ProductID", id);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\n--- Product Details ---");

            while (reader.Read())
            {
                Console.WriteLine("ID: " + reader["ProductId"]);
                Console.WriteLine("Name: " + reader["ProductName"]);
                Console.WriteLine("Category: " + reader["Category"]);
                Console.WriteLine("Price: " + reader["Price"]);
            }

            con.Close();
        }

    }
}