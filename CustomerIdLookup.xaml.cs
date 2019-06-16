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
using Initech;

namespace Initech
{
    /// <summary>
    /// Interaction logic for CustomerIdLookup.xaml
    /// </summary>
    public partial class CustomerIdLookup : Page
    {
        public CustomerIdLookup()
        {
            InitializeComponent();
        }

        private void btnNameSearch_Click(object sender, RoutedEventArgs e)
        {
            int customerId;
            if (txtName.Text != "")
            {
                String customerName = txtName.Text;

                if ((customerId = SelectHelpers.CustomerNameLookup(customerName)) > 0)
                {
                    lblOutput.Content = "CustomerID is " + customerId.ToString();
                    lblOutput.Foreground = GeneralHelpers.greenBrush;
                } else
                {
                    lblOutput.Content = "Customer not found";
                    lblOutput.Foreground = GeneralHelpers.redBrush;
                }
            } else
            {
                lblOutput.Content = "Customer ID is required.";
                lblOutput.Foreground = GeneralHelpers.redBrush;
            }
        }

        private void btnReturnToMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(MainPage.mainPage);
        }
    }
}
