using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Data.SqlClient;

namespace Initech
{
    class SelectHelpers
    {
        public static int CustomerNameLookup(String customerName)
        {
            int customerId = -1;
            SqlConnection connection;
            using (connection = new SqlConnection(MainPage.connectionString.ConnectionString))
            {
                SqlCommand selectQuery = new SqlCommand("SELECT CustomerID from customers WHERE CustomerName=@customerName", connection);
                selectQuery.Parameters.AddWithValue("@customerName", customerName);

                connection.Open();

                using (SqlDataReader reader = selectQuery.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Int32.TryParse(reader[0].ToString(), out customerId);
                    }
                }
                return customerId;
            }
        }

        public static List<String> CustomerIdLookup(int customerId)
        {
            SqlConnection connection;
            List<String> data = new List<String>();
            using (connection = new SqlConnection(MainPage.connectionString.ConnectionString))
            {
                SqlCommand selectQuery = new SqlCommand("SELECT CustomerName, CustomerAddress from " +
                    "customers WHERE CustomerID=@customerId", connection);
                selectQuery.Parameters.AddWithValue("@customerId", customerId.ToString());

                connection.Open();

                using (SqlDataReader reader = selectQuery.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            data.Add(reader.GetString(0));
                            data.Add(reader.GetString(1));
                        }
                    }
                }
                return data;
            }
        }

        public static List<String[]> IssuesByCustomerId(int customerId)
        {
            List<String[]> customerIssues = new List<String[]>();

            SqlConnection connection;
            List<String> data = new List<String>();
            using (connection = new SqlConnection(MainPage.connectionString.ConnectionString))
            {
                SqlCommand selectQuery = new SqlCommand("SELECT IssueRecieved, ContactName, IssueResponded from " +
                    "issues WHERE CustomerID=@customerId", connection);
                selectQuery.Parameters.AddWithValue("@customerId", customerId.ToString());

                connection.Open();

                using (SqlDataReader reader = selectQuery.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            String[] dataRetrieved = new String[3];
                            dataRetrieved[0] = reader.GetDateTime(0).ToString("dd/MM/yyyy");
                            dataRetrieved[1] = reader.GetString(1);
                            if (reader.GetBoolean(2) == true)
                            {
                                dataRetrieved[2] = "Yes";
                            } else
                            {
                                dataRetrieved[2] = "No";
                            }
                            customerIssues.Add(dataRetrieved);
                        }
                    }
                }
            }
            return customerIssues;
        }

        public static List<String[]> IssuesByCustomerName(string customerName)
        {
            List<String[]> customerIssues = new List<String[]>();

            SqlConnection connection;
            List<String> data = new List<String>();
            using (connection = new SqlConnection(MainPage.connectionString.ConnectionString))
            {
                int customerId = CustomerNameLookup(customerName);
                SqlCommand selectQuery = new SqlCommand("SELECT IssueRecieved, ContactName, IssueResponded from " +
                    "issues WHERE CustomerID=@customerId", connection);
                selectQuery.Parameters.AddWithValue("@customerId", customerId);

                connection.Open();

                using (SqlDataReader reader = selectQuery.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            String[] dataRetrieved = new String[3];
                            dataRetrieved[0] = reader.GetDateTime(0).ToString("dd/MM/yyyy");
                            dataRetrieved[1] = reader.GetString(1);
                            if (reader.GetBoolean(2) == true)
                            {
                                dataRetrieved[2] = "Yes";
                            }
                            else
                            {
                                dataRetrieved[2] = "No";
                            }
                            customerIssues.Add(dataRetrieved);
                        }
                    }
                }
            }
            return customerIssues;
        }

        public static List<String[]> UnresolvedIssues()
        {
            List<String[]> customerIssues = new List<String[]>();

            SqlConnection connection;
            List<String> data = new List<String>();

            String query = "SELECT CustomerName, IssueRecieved, ContactName, IssueResponded " +
                                "FROM customers as c, issues as i " +
                                "WHERE IssueResponded = 0 AND c.CustomerID = i.CustomerID";
            using (connection = new SqlConnection(MainPage.connectionString.ConnectionString))
            {
                SqlCommand selectQuery = new SqlCommand(query, connection);

                connection.Open();

                using (SqlDataReader reader = selectQuery.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            String[] dataRetrieved = new String[4];
                            dataRetrieved[0] = reader.GetString(0);
                            dataRetrieved[1] = reader.GetDateTime(1).ToString("dd/MM/yyyy");
                            dataRetrieved[2] = reader.GetString(2);
                            if (reader.GetBoolean(3) == true)
                            {
                                dataRetrieved[3] = "Yes";
                            }
                            else
                            {
                                dataRetrieved[3] = "No";
                            }
                            customerIssues.Add(dataRetrieved);
                        }
                    }
                }
            }
            return customerIssues;
        }
        public static List<String[]> ViewCustomers()
        {
            List<String[]> customers = new List<String[]>();

            SqlConnection connection;
            List<String> data = new List<String>();

            String query = "SELECT CustomerID, CustomerName, CustomerAddress FROM customers";
            using (connection = new SqlConnection(MainPage.connectionString.ConnectionString))
            {
                SqlCommand selectQuery = new SqlCommand(query, connection);

                connection.Open();

                using (SqlDataReader reader = selectQuery.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            String[] dataRetrieved = new String[4];
                            dataRetrieved[0] = reader.GetInt32(0).ToString();
                            dataRetrieved[1] = reader.GetString(1);
                            dataRetrieved[2] = reader.GetString(2);
                            customers.Add(dataRetrieved);
                        }
                    }
                }
            }
            return customers;
        }

    }
}
