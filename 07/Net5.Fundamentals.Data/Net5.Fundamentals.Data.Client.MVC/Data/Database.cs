using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.Fundamentals.Data.Client.MVC.Data
{
    public class Database
    {
        public List<Customer> ListCustomers()
        {
            List<Customer> customers = new List<Customer>();

            string strConn = "Data Source=.;Initial Catalog=Pharmacy;User ID=sa;Password=Password1234";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string querySql = "SELECT [CustomerCode],[CustomerName],[CustomerAddress],[District],[Birthday],[Sex],[Dni],[Ruc],[Telephone],[Mobile]  FROM [dbo].[Customer]";
                using (SqlCommand cmd = new SqlCommand(querySql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //onsole.WriteLine($"{reader[0]},{reader[1]},{reader[2]},{reader[3]},{reader[4]},{reader[5]},{reader[6]},{reader[7]},{reader[8]}");
                            Customer customer = new Customer();
                            customer.CustomerCode = reader.GetString(0);
                            customer.CustomerName = reader.GetString(1);
                            customer.CustomerAddress = reader.GetString(2);
                            customer.District = reader.GetString(3);
                            customer.Birthday = reader.GetDateTime(4);
                            customer.Sex = reader.GetString(5);
                            customer.Dni = reader.GetString(6);
                            customer.Ruc = reader.GetString(7);
                            customer.Telephone = reader.GetInt32(8);
                            customer.Mobile = reader.GetInt32(9);

                            customers.Add(customer);
                        };
                    }

                    reader.Close();
                    conn.Close();
                }
            }

            return customers;
        }
    }
}
