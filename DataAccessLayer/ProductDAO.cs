using BusinessObjects;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        private static ProductDAO instance;
        private static readonly object instanceLock = new object();

        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        public  List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                using var context = new MyStoreContext();
                products = context.Products.ToList();

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return products;
        }

        public  void SaveProduct(Product p)
        {
            
            try
            {
                using var context = new MyStoreContext();
                context.Products.Add(p);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }

        public  void UpdateProduct(Product p)
        {

            try
            {
                using var context = new MyStoreContext();
                context.Products.Update(p);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public  void DeleteProduct(Product p)
        {
            try
            {
                using var context = new MyStoreContext();
                context.Products.Remove(p);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public  Product GetProductById(int id)
        {
            Product product = null;
            try
            {
                using var context = new MyStoreContext();
                product = context.Products.FirstOrDefault(p => p.ProductId == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return product;
        }
    }
}
