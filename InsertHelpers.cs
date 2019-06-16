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
    class InsertHelpers
    {
        public static int InsertCustomer(String customerName, String customerAddress, DateTime purchaseDate)
        {
            String query = "INSERT INTO customers (CustomerName, CustomerAddress, PurchaseDate) " +
                        "VALUES (@customerName, @customerAddress, @purchaseDate)";

            SqlConnection connection;
            using (connection = new SqlConnection(MainPage.connectionString.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@customerName", customerName);
                    command.Parameters.AddWithValue("@customerAddress", customerAddress);
                    command.Parameters.AddWithValue("@purchaseDate", purchaseDate);

                    return command.ExecuteNonQuery();
                }
            }
        }

        public static int InsertIssue(String customerName, DateTime dateRecieved, String contactName, bool issueResponded)
        {
            int customerID = -1;
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
                        Int32.TryParse(reader[0].ToString(), out customerID);
                    }
                }
                


                if (customerID != -1)
                {
                    string insertQuery = "INSERT INTO issues (IssueRecieved, ContactName, IssueResponded, CustomerID) " +
                            "VALUES (@dateRecieved, @contactName, @issueResponded, @customerID)";


                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@dateRecieved", dateRecieved);
                        command.Parameters.AddWithValue("@ContactName", contactName);
                        command.Parameters.AddWithValue("@issueResponded", issueResponded);
                        command.Parameters.AddWithValue("@customerID", customerID);

                        return command.ExecuteNonQuery();
                    }
                }
                return -1;
            }
        }
    }
}
