using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDAL.Interface
{
    public interface IDbCustomers
    {
        DataTable GetCustomers();
        DataTable GetCustomerOrders(string CustomerID);
        DataTable GetCustomersByCountry(string CountryCode);
        bool InsertCustomer();
    }
}
