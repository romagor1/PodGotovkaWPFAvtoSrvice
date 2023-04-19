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

namespace PodGotovkaWPFAvtoSrvice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        test_tbEntities _context = new test_tbEntities();
        public MainWindow()
        {
            InitializeComponent();
            ListProduct.ItemsSource = _context.Product.OrderBy(product => product.Title).ToList();
        }

        private void TxtFindendproduct_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CmbMonufactureProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ChbAtuale_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ChbAtuale_Unchecked(object sender, RoutedEventArgs e)
        {

        }
    }
}
