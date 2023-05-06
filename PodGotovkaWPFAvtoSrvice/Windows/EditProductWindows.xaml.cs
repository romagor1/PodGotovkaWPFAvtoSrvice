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
using System.Windows.Shapes;

namespace PodGotovkaWPFAvtoSrvice.Windows
{
	/// <summary>
	/// Логика взаимодействия для EditProductWindows.xaml
	/// </summary>
	public partial class EditProductWindows : Window
	{
		private test_tbEntities _context;
		private Product _product;
		private ProductTable _window;
		public EditProductWindows(test_tbEntities context, object o, ProductTable productTable)
		{
			InitializeComponent();
			_window = productTable;
			_product = (o as Button).DataContext as Product;
			_context = context;
			TxtTitleProduct.Text = _product.Title;
			TxtCosteProduct.Text = Convert.ToString(_product.Cost);
			TxtDescriptionProduct.Text = _product.Description;
			TxtIsActiveProduct.Text = Convert.ToString(_product.IsActive);
			TxtMainImagePathroduct.Text = _product.ImagePath;
			CmdManufacturerProduct.ItemsSource = _context.Manufacturer.ToList();
		}

		private void BtnDeleteproduct_Click(object sender, RoutedEventArgs e)
		{
			var result = MessageBox.Show(_product.Title, "Хотите удалить продукт?", MessageBoxButton.YesNo);
			if (result == MessageBoxResult.Yes)
			{
				_context.Product.Remove(_product);
				_context.SaveChanges();
				_window.RefreshProduct();
				this.Close();
			}
        }

		private void UpdateProductInfo_Click(object sender, RoutedEventArgs e)
		{
			_product.Title = TxtTitleProduct.Text;
			_product.Description = TxtDescriptionProduct.Text;
			_product.Cost = (decimal)Convert.ToDouble(TxtCosteProduct.Text);
			_product.Manufacturer = CmdManufacturerProduct.SelectedItem as Manufacturer;
			_product.MainImagePath = TxtMainImagePathroduct.Text;
			_window.RefreshProduct();
			_context.SaveChanges();
			this.Close();
		}
    }
}
