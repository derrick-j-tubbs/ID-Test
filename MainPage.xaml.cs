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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public static MainPage mainPage;
        public static SqlConnectionStringBuilder connectionString;
        private MainWindow _mainWindow;

        public MainPage(SqlConnectionStringBuilder _connectionString, MainWindow mainWindow)
        {
            InitializeComponent();
            connectionString = _connectionString;
            mainPage = this;
            _mainWindow = mainWindow;
        }

        private void btnCustomerID_Click(object sender, RoutedEventArgs e)
        {
            var issuesByCustomerID = new IssuesByCustomerId();
            NavigationService.Navigate(issuesByCustomerID);
        }

        private void btnCustomerName_Click(object sender, RoutedEventArgs e)
        {
            var issuesByCustomerName = new IssuesByCustomerName();
            NavigationService.Navigate(issuesByCustomerName);
        }

        private void btnUnrespondedIssues_Click(object sender, RoutedEventArgs e)
        {
            var unrespondedIssues = new UnrespondedIssues();
            NavigationService.Navigate(unrespondedIssues);
        }

        private void btnViewCustomers_Click(object sender, RoutedEventArgs e)
        {
            var viewCustomers = new ViewCustomers();
            NavigationService.Navigate(viewCustomers);
        }

        private void btnFindCustomerID_Click(object sender, RoutedEventArgs e)
        {
            var customerIdLookup = new CustomerIdLookup();
            NavigationService.Navigate(customerIdLookup);
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var addCustomerPage = new AddCustomer();
            NavigationService.Navigate(addCustomerPage);
        }

        private void btnEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            var editCustomer = new EditCustomer();
            NavigationService.Navigate(editCustomer);
        }

        private void btnAddIssue_Click(object sender, RoutedEventArgs e)
        {
            var addIssuePage = new AddIssue();
            NavigationService.Navigate(addIssuePage);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Close();
        }
    }
}
