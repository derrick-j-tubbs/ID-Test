using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Initech
{
    /// <summary>
    /// Interaction logic for IssuesByCustomerName.xaml
    /// </summary>
    public partial class IssuesByCustomerName : Page
    {
        public IssuesByCustomerName()
        {
            InitializeComponent();
        }

        private void btnReturnToMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(MainPage.mainPage);
        }

        private void btnFindIssues_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != "")
            {
                String customerName = txtName.Text;

                DataTable table = new DataTable();
                DataColumn column1 = new DataColumn("Issue Date", typeof(String));
                DataColumn column2 = new DataColumn("Contact Name", typeof(String));
                DataColumn column3 = new DataColumn("Issue Responded", typeof(String));

                table.Columns.Add(column1);
                table.Columns.Add(column2);
                table.Columns.Add(column3);

                List<String[]> customerIssues = SelectHelpers.IssuesByCustomerName(customerName);

                foreach (String[] issue in customerIssues)
                {
                    DataRow row = table.NewRow();
                    row["Issue Date"] = issue[0].ToString();
                    row["Contact Name"] = issue[1].ToString();
                    row["Issue Responded"] = issue[2].ToString();
                    table.Rows.Add(row);
                }

                Binding bind = new Binding();

                bind.Source = table;
                issueGrid.SetBinding(ListView.ItemsSourceProperty, bind);
            } else
            {
                lblOutput.Content = "Customer Name is required.";
                lblOutput.Foreground = GeneralHelpers.redBrush;
            }
        }
    }
}
