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
using System.Data.SqlClient;

namespace Initech
{
    /// <summary>
    /// Interaction logic for EditCustomer.xaml
    /// </summary>
    public partial class EditCustomer : Page
    {
        public EditCustomer()
        {
            InitializeComponent();
        }

        private void btnReturnToMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(MainPage.mainPage);
        }

        private void btnFindCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (txtCustomerId.Text != "")
            {
                int customerId = -1;
                if (Int32.TryParse(txtCustomerId.Text, out customerId))
                {
                    List<String> customerInfo = SelectHelpers.CustomerIdLookup(customerId);

                    txtName.Text = customerInfo[0];
                    txtAddress.Text = customerInfo[1];
                } else
                {
                    lblOutput.Content = "Customer ID must be a number.";
                    lblOutput.Foreground = GeneralHelpers.redBrush;
                }
            }
        }

        private void btnEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != "" && txtAddress.Text != "")
            {
                string customerName = txtName.Text;
                string customerAddress = txtAddress.Text;
                if (txtCustomerId.Text != "")
                {
                    int customerId = -1;
                    if (Int32.TryParse(txtCustomerId.Text, out customerId))
                    {
                        if (UpdateHelpers.EditCustomerById(customerId, customerName, customerAddress) > 0)
                        {
                            lblOutput.Content = "Customer Successfully updated";
                            lblOutput.Foreground = GeneralHelpers.greenBrush;
                            ClearForm();
                        }
                        else
                        {
                            lblOutput.Content = "Something went wrong with the database.";
                            lblOutput.Foreground = GeneralHelpers.redBrush;
                        }
                    }
                }
            }
        }

        private void ClearForm()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtCustomerId.Text = "";
        }
    }
}
