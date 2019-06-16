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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnectionStringBuilder _builder;
        private MainWindow _mainWindow;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
            _builder = Secret.generateConnectionString();
            _mainWindow = this;
        }

        private void MainPage_Loaded (object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new MainPage(_builder, _mainWindow));
        }

    }
}
