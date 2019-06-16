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
    /// Interaction logic for ViewCustomers.xaml
    /// </summary>
    public partial class ViewCustomers : Page
    {
        public ViewCustomers()
        {
            InitializeComponent();
            DataTable table = new DataTable();
            DataColumn column0 = new DataColumn("Customer ID", typeof(String));
            DataColumn column1 = new DataColumn("Customer Name", typeof(String));
            DataColumn column2 = new DataColumn("Customer Address", typeof(String));
        

            table.Columns.Add(column0);
            table.Columns.Add(column1);
            table.Columns.Add(column2);

            List<String[]> customerIssues = SelectHelpers.ViewCustomers();

            foreach (String[] issue in customerIssues)
            {
                DataRow row = table.NewRow();
                row["Customer ID"] = issue[0].ToString();
                row["Customer Name"] = issue[1].ToString();
                row["Customer Address"] = issue[2].ToString();
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
