using Net5.Fundamentals.AspNet.Data.Entities;
using Net5.Fundamentals.AspNet.Data.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.Fundamentals.AspNet.Data.Repositories
{
    class ProductRepository
    {
        private readonly IDapper _database;
        public ProductRepository(IDapper database)
        {
            _database = database;
        }

        public List<Product> List()
        {
            List<Product> customers = new List<Product>();
            string query = @"
                SELECT [product_id]
                      ,[product_name]
                      ,[brand_id]
                      ,[category_id]
                      ,[model_year]
                      ,[list_price]
                  FROM [BikeStores].[production].[products]";

            customers = _database.GetAll<Product>(query, null, CommandType.Text);

            return customers;
        }
    }
}
