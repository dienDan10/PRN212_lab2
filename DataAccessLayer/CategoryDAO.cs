using BusinessObjects;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CategoryDAO
    {

        private static CategoryDAO instance = null;
        private static readonly object instanceLock = new object();

        private CategoryDAO() { }
        public static CategoryDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CategoryDAO();
                    }
                    return instance;
                }
            }

        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            try
            {
                using MyStoreContext context = new MyStoreContext();
                categories = context.Categories.ToList();
            } catch (Exception ex)
            {

            }
            return categories;
        }
    }
}
