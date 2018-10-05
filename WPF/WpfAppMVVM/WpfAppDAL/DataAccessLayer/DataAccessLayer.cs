using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Collections.Generic;

namespace WpfAppDAL.DataAccessLayer
{
    public class DataAccessLayer
    {
        public void ExecuteNonQuery()
        {
            string FirstName = "Sachidanand";
            string IsPermanentEmployee = "Y";
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            string query = "INSERT INTO Customers (Name, Country) VALUES (@Name, @Country)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Name", FirstName));
            parameters.Add(new SqlParameter("@Country", IsPermanentEmployee));
            int rowsAffected = SqlHelper.ExecuteNonQuery(constr, CommandType.Text, query, parameters.ToArray());
        }

        public DataTable GetEmployeeData()
        {
            DataTable dataSet = new DataTable();
            string constr = "Data Source =.; " + 
                            "Initial Catalog=DatabaseOne;" +
                            "Integrated Security=SSPI;"; 
            string query = "select * from Employee;";
            SqlDataReader sdr = SqlHelper.ExecuteReader(constr, CommandType.Text, query);
            DataTable dtSchema = sdr.GetSchemaTable();

            dataSet.Load(sdr);

            return dataSet;
        }

        public DataTable GetCity(int no)
        {
            DataTable dataSet = new DataTable();
            string constr = "Data Source =.; " +
                            "Initial Catalog=DatabaseOne;" +
                            "Integrated Security=SSPI;";
            string query = "select * from City;";
            SqlDataReader sdr = SqlHelper.ExecuteReader(constr, CommandType.Text, query);
            DataTable dtSchema = sdr.GetSchemaTable();

            dataSet.Load(sdr);

            return dataSet;
        }
    }
}
