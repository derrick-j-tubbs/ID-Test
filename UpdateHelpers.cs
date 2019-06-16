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
    class UpdateHelpers
    {
        public static int EditCustomerById(int customerId, String customerName, String customerAddress)
        {
            SqlConnection connection;
            using (connection = new SqlConnection(MainPage.connectionString.ConnectionString))
            {
                String updateQuery = "UPDATE customers SET CustomerName=@customerName, " +
                    "CustomerAddress=@customerAddress WHERE CustomerId=@customerId";


                connection.Open();

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@customerName", customerName);
                    command.Parameters.AddWithValue("@customerAddress", customerAddress);
                    command.Parameters.AddWithValue("@customerId", customerId);

                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
