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
        private test_tbEntities _context = new test_tbEntities();
        private List<Product> _product = new List<Product>();
		private List<User> _User = new List<User>();
		private string _SelectedManufacturer;
        private string _FindendName;
        public MainWindow()
        {
            InitializeComponent();
            ListProduct.ItemsSource = _context.Product.OrderBy(product => product.Title).ToList();

            List<Manufacturer> manufacturers= new List<Manufacturer>();
            manufacturers.Add(new Manufacturer() {Name = "Все производители" });
            manufacturers.AddRange(_context.Manufacturer.OrderBy(m => m.Name).ToList());
            CmbMonufactureProduct.ItemsSource = manufacturers; 
            
            this._product = _context.Product.ToList();
        }

     
        private void RefreshProduct()
        {
            if (CmbMonufactureProduct.SelectedItem != null)
            {
                if ((CmbMonufactureProduct.SelectedItem as Manufacturer).Name != "Все производители")
                {
                    Manufacturer manufacturer = CmbMonufactureProduct.SelectedItem as Manufacturer;
                    _SelectedManufacturer = manufacturer.Name;
                    _product = (from p in _product.OrderBy(t => t.Manufacturer.Name).ToList()
                                where p.Manufacturer.Name == _SelectedManufacturer
                                select p).ToList();
                }
                else if ((CmbMonufactureProduct.SelectedItem as Manufacturer).Name == "Все производители")
                {
                    _product = _context.Product.OrderBy(p => p.Title).ToList();
                }
            }
            if (TxtFindendproduct.Text != "")
            {
                _product = _product.OrderBy(t => t.Title).Where(t => t.Title.ToLower().Contains(_FindendName)).ToList();
            }
            

            if ((bool)ChbAtuale.IsChecked)
            {
                _product = _product.OrderBy(p => p.Title).Where(p => p.IsActive == true).ToList();
            }
            ListProduct.ItemsSource = _product;
        }

        private void TxtFindendproduct_TextChanged(object sender, TextChangedEventArgs e)
        {
            _product = _context.Product.OrderBy(p => p.Title).ToList();
            _FindendName = TxtFindendproduct.Text;
            RefreshProduct();
            
        }

        private void CmbMonufactureProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _product = _context.Product.OrderBy(p => p.Title).ToList();
            RefreshProduct();
        }

        private void ChbAtuale_Checked(object sender, RoutedEventArgs e)
        {
            _product = _context.Product.OrderBy(p => p.Title).ToList();
            RefreshProduct();
        }

        private void ChbAtuale_Unchecked(object sender, RoutedEventArgs e)
        {
            _product = _context.Product.OrderBy(p => p.Title).ToList();
            RefreshProduct();
        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Windows.AvtorizationForAdmin window = new Windows.AvtorizationForAdmin();
			window.Show();
		}

		private void BtnBuyProdust_Click(object sender, RoutedEventArgs e)
		{
			Windows.Avtorizacia window = new Windows.Avtorizacia();
			window.Show();
		}
	}
}
