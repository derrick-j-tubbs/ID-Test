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
    /// Interaction logic for Unresolved_ssues.xaml
    /// </summary>
    public partial class UnrespondedIssues : Page
    {
        public UnrespondedIssues()
        {
            InitializeComponent();
            DataTable table = new DataTable();
            DataColumn column0 = new DataColumn("Customer Name", typeof(String));
            DataColumn column1 = new DataColumn("Issue Date", typeof(String));
            DataColumn column2 = new DataColumn("Contact Name", typeof(String));
            DataColumn column3 = new DataColumn("Issue Responded", typeof(String));

            table.Columns.Add(column0);
            table.Columns.Add(column1);
            table.Columns.Add(column2);
            table.Columns.Add(column3);

            List<String[]> customerIssues = SelectHelpers.UnresolvedIssues();

            foreach (String[] issue in customerIssues)
            {
                DataRow row = table.NewRow();
                row["Customer Name"] = issue[0].ToString();
                row["Issue Date"] = issue[1].ToString();
                row["Contact Name"] = issue[2].ToString();
                row["Issue Responded"] = issue[3].ToString();
                table.Rows.Add(row);
            }

            Binding bind = new Binding();

            bind.Source = table;
            issueGrid.SetBinding(ListView.ItemsSourceProperty, bind);
        }

        private void btnReturnToMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(MainPage.mainPage);
        }
    }
}
