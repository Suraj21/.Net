using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppDAL.Interface;
using Microsoft.ApplicationBlocks.Data;

namespace WpfAppDAL.DALLayer
{
    public class CustomersData : IDbCustomers
    {
        public DataTable GetCustomers()
        {
            string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

            using (OleDbConnection cnn = new OleDbConnection (ConnectionString))
            {
                string cmdString = "SELECT CustomerID," + "CompanyName,ContactName " + "FROM Customers";

                OleDbCommand cmd = new OleDbCommand(cmdString, cnn);

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                DataTable dt = new DataTable("Customers");

                da.Fill(dt);

                return dt;
            }

            
        }
        public DataTable GetCustomerOrders(string CustomerID)
        {
            // TBD
            return null;
        }
        public DataTable GetCustomersByCountry
           (string CountryCode)
        {
            // TBD
            return null;
        }
        public bool InsertCustomer()
        {
            // TBD
            return false;
        }
    }
}
