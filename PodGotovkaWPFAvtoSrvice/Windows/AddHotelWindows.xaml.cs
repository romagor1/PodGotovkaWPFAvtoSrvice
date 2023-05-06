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
	/// Логика взаимодействия для AddHotelWindows.xaml
	/// </summary>
	public partial class AddHotelWindows : Window
	{
		private test_tbEntities _context;
		private ProductTable _window;

		public AddHotelWindows(test_tbEntities context, ProductTable productTable)
		{
			InitializeComponent();
			this._context = context;
			this._window = productTable;
			CmdManufacturerProduct.ItemsSource = _context.Manufacturer.ToList();
		}

		private void AddProductInfo_Click(object sender, RoutedEventArgs e)
		{
			_context.Product.Add(new Product
			{
				Title = TxtTitleProduct.Text,
				Description = TxtDescriptionProduct.Text,
				Cost = (decimal)Convert.ToDouble(TxtCosteProduct.Text),
				Manufacturer = CmdManufacturerProduct.SelectedItem as Manufacturer,
				MainImagePath = TxtMainImagePathroduct.Text,
			});
			_context.SaveChanges();
			_window.RefreshProduct();
			this.Close();
        }
    }
}
