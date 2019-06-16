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
    class GeneralHelpers
    {
        private static Color red = Color.FromRgb(255, 0, 0);
        public static Brush redBrush = new SolidColorBrush(red);

        private static Color green = Color.FromRgb(0, 255, 0);
        public static Brush greenBrush = new SolidColorBrush(green);
    }
}
