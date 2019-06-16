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
    /// Interaction logic for AddIssue.xaml
    /// </summary>
    public partial class AddIssue : Page
    {
        public AddIssue()
        {
            InitializeComponent();
        }

        private void btnReturnToMain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(MainPage.mainPage);
        }

        private void btnAddIssue_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                var customerName = txtName.Text;
                var contactName = txtContact.Text;
                bool responded;
                if (checkYes.IsChecked == true) {
                    responded = true;
                } else {
                    responded = false;
                }

                if (InsertHelpers.InsertIssue(customerName, DateTime.Now, contactName, responded) > 0)
                {
                    lblOutput.Content = "Customer Successfully Added";
                    lblOutput.Foreground = GeneralHelpers.greenBrush;
                    ClearForm();
                }
                else
                {
                    lblOutput.Content = "Customer Does Not Exist";
                    lblOutput.Foreground = GeneralHelpers.redBrush;
                }
            } else
            {
                lblOutput.Foreground = GeneralHelpers.redBrush;
            }
        }

       private bool ValidateForm()
       {
            if (txtName.Text == "") {
                lblOutput.Content = "Please enter a company name";
                return false;
            }
            if (txtContact.Text == "") {
                lblOutput.Content = "Please enter a contact name";
                return false;
            }
            return true;
        }
        
        private void ClearForm()
        {
            txtName.Text = "";
            txtContact.Text = "";
            checkYes.IsChecked = true;
        }
    }
}
