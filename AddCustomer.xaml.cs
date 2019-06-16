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
using Initech;

namespace Initech
{
    /// <summary>
    /// Interaction logic for AddCustomerPage.xaml
    /// </summary>
    public partial class AddCustomer : Page {

        public AddCustomer()
        {
            InitializeComponent();
        }

        private void btnReturnToMain_Click(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(MainPage.mainPage);
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                var customerName = txtName.Text;
                var customerAddress = txtAddress.Text;

                if (Int32.TryParse(txtDay.Text, out int day)
                        && Int32.TryParse(txtMonth.Text, out int month)
                        && Int32.TryParse(txtYear.Text, out int year))
                {
                    if (ValidateDate(day, month))
                    {
                        DateTime datePurchased = new DateTime(year, month, day);

                        if (InsertHelpers.InsertCustomer(customerName, customerAddress, datePurchased) > 0)
                        {
                            lblOutput.Content = "Customer Successfully Added";
                            lblOutput.Foreground = GeneralHelpers.greenBrush;
                            ClearForm();
                        } else
                        {
                            lblOutput.Content = "Something went wrong with the database.";
                            lblOutput.Foreground = GeneralHelpers.redBrush;
                        }
                    }
                    else
                    {
                        lblOutput.Foreground = GeneralHelpers.redBrush;
                    }
                } else
                {
                    lblOutput.Content = "Day, Month, and Year must be numbers";
                    lblOutput.Foreground = GeneralHelpers.redBrush;
                }
            } else
            {
                lblOutput.Foreground = GeneralHelpers.redBrush;
            }
        }

        private bool ValidateForm() {
            if (txtName.Text == "") {
                lblOutput.Content = "Please enter a company name";
                return false;
            }
            if (txtAddress.Text == "") {
                lblOutput.Content = "Please enter a company address";
                return false;
            }
            if (txtDay.Text.Length > 2) { 
                lblOutput.Content = "Day is too long";
                return false;
            }
            if (txtMonth.Text.Length > 2){
                lblOutput.Content = "Month is too long";
                return false;
            }
            if (txtYear.Text.Length > 4) {
                lblOutput.Content = "Year is too long";
                return false;
            }
            return true;
        }

        private bool ValidateDate(int day, int month) {
            if (month >= 12 || month <= 0) {
                lblOutput.Content = "Please enter a valid value for month (1-12)";
                return false;
            }
            if (day <= 0) {
                lblOutput.Content = "Please enter a valid value for day greater than 0";
                return false;
            }
            switch (month) {
                case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                    if (day <= 31) {
                        return true;
                    } else {
                        lblOutput.Content = "Please enter a valid value for day (1-31)";
                        return false;
                    }
                case 2:
                    if (day <= 28) {
                        return true;
                    } else {
                        lblOutput.Content = "Please enter a valid value for day (1-28)";
                        return false;
                    }
                case 4: case 6: case 9: case 11:
                    if (day <= 30) {
                        return true;
                    } else {
                        lblOutput.Content ="Please enter a valid value for day (1-30)";
                        return false;
                    }
                default:
                    lblOutput.Content = "Please enter a valid day value for the month selected.";
                    return false;
            }
        }
        private void ClearForm()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtMonth.Text = "";
            txtDay.Text = "";
            txtYear.Text = "";
        }
    }
}
