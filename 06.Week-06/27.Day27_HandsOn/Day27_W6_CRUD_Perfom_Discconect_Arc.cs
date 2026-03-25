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
            SqlConnection con = new SqlConnection(connStr); //create conection object using conection string

          SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Products",con); // act as brdige b/w  DB and data set

            SqlCommandBuilder cb = new SqlCommandBuilder(da); //auto generate sql cmds 

            DataSet ds = new DataSet(); //in memroy DB for temaporary  storage
            da.Fill(ds,"Products"); //load data from DB into dataset

            DataRow row = ds.Tables["Products"].NewRow();//it create new empty row in memory

            Console.Write("Name: ");
            row["ProductName"]=Console.ReadLine();

            Console.Write("Category: ");
            row["Category"] = Console.ReadLine();

            Console.Write("Price: ");
            row["Price"] = decimal.Parse(Console.ReadLine());

            ds.Tables["Products"].Rows.Add(row); //add rows to DataSet but still not saved to databse

            da.Update(ds, "Products");//changes from DataSet to Database

            Console.WriteLine(" Product inserted using  Disconnected");
        }
        //===================delete===================
        static void DeleteProduct()
        {
            SqlConnection con = new SqlConnection(connStr);

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Products", con);

            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            DataSet ds = new DataSet();//temporary in memory DB
            da.Fill(ds, "Products");

            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());

            DataTable dt = ds.Tables["Products"];//acess Product table from dataset

            foreach (DataRow row in dt.Rows)
            {
                if ((int)row["ProductId"] == id)
                {
                    row.Delete();
                    break;
                }
            }

            da.Update(ds, "Products");
            Console.WriteLine(" Product Deleted using Disconnected");

        }
        //=======================update=================
        static void UpdateProduct()
        {
            SqlConnection con = new SqlConnection(connStr);

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Products", con);

            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            DataSet ds = new DataSet();
            da.Fill(ds, "Products");

            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());

            DataTable dt = ds.Tables["Products"];

            foreach (DataRow row in dt.Rows)
            {
                if ((int)row["ProductId"] == id)
                {
                    Console.Write("New Name: ");
                    row["ProductName"] = Console.ReadLine();

                    Console.Write("New Category: ");
                    row["Category"] = Console.ReadLine();

                    Console.Write("New Price: ");
                    row["Price"] = decimal.Parse(Console.ReadLine());

                    break;
                }
            }
            da.Update(ds, "Products");//changes from DataSet to Database
            Console.WriteLine("===Product Updated====");
        }
        //=====================view all products===========================
        static void ViewProducts()
        {

            SqlConnection con = new SqlConnection(connStr);

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Products", con);

            DataSet ds = new DataSet();

            da.Fill(ds, "Products");   // Load data into memory

            Console.WriteLine("\n--- Product List ---");

            foreach (DataRow row in ds.Tables["Products"].Rows)
            {
                Console.WriteLine($"ID: {row["ProductId"]}, Name: {row["ProductName"]}, Category: {row["Category"]}, Price: {row["Price"]}");
            }
        }

        //===================get product by id particular=======
        static void GetProductById()
        {
            SqlConnection con = new SqlConnection(connStr);

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Products", con);

            DataSet ds = new DataSet();
            da.Fill(ds, "Products");

            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            bool found = false;
            foreach (DataRow row in ds.Tables["Products"].Rows)
            {
                if ((int)row["ProductId"] == id)
                {
                    Console.WriteLine("ID: " + row["ProductId"]);
                    Console.WriteLine("Name: " + row["ProductName"]);
                    Console.WriteLine("Category: " + row["Category"]);
                    Console.WriteLine("Price: " + row["Price"]);
                }

                if(!found)
                {
                    Console.WriteLine("Product Id is Not Found Try Another One..!");
                }
               
            }
        }

    }
}