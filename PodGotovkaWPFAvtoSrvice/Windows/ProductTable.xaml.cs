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
	/// Логика взаимодействия для ProductTable.xaml
	/// </summary>
	public partial class ProductTable : Window
	{
		public static test_tbEntities _context = new test_tbEntities();
		private Product _product;
		private int _currentPage = 1;
		private int _maxPage = 0;

		public ProductTable()
		{
			InitializeComponent();
			RefreshProduct();
		}

		public void RefreshProduct()
		{
			DataGridProduct.ItemsSource = _context.Product.OrderBy(n => n.Title).ToList();
			_maxPage = Convert.ToInt32( Math.Ceiling(_context.Product.ToList().Count * 1.0 /10) );
			var ListProduct = _context.Product.ToList().Skip((_currentPage -1)*10).Take(10).ToList();

			lblTotalPage.Content = "of" + _maxPage.ToString();
			TxtPageNumber.Text = _currentPage.ToString();

			DataGridProduct.ItemsSource = ListProduct;
		}

		private void DataGridProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

        }
		//редактирование данных  
		private void BtnEditProduct_Click(object sender, RoutedEventArgs e)
		{
			EditProductWindows windows = new EditProductWindows(_context,sender,this);
			windows.ShowDialog();
		}
		//Переход к первой странице
		private void GoFirstPAgeButton_Click(object sender, RoutedEventArgs e)
		{
			_currentPage = 1;
			RefreshProduct();
		}
		//Переход к предыдющей странице
		private void GoPrevPAgeButton_Click(object sender, RoutedEventArgs e)
		{
			if(_currentPage -1 < 1)
			{
				return;
			}
			_currentPage--;

			RefreshProduct();
		}

		private void TxtPageNumber_TextChanged(object sender, TextChangedEventArgs e)
		{
			if(_currentPage > 0 && _currentPage < _maxPage && TxtPageNumber.Text != "")
			{
				_currentPage = Convert.ToInt32(TxtPageNumber.Text);
			    RefreshProduct();
			}
        }
		//Переход к следующей странице
		private void GoNextPageButton_Click(object sender, RoutedEventArgs e)
		{
			if(_currentPage + 1 > _maxPage)
			{
				return;
			}
			_currentPage++;
			RefreshProduct();
        }
		//Переход к послденей странице
		private void GoLastPageButton_Click(object sender, RoutedEventArgs e)
		{
			_currentPage = _maxPage;
			RefreshProduct();
		}

		private void BtnAddproduct_Click(object sender, RoutedEventArgs e)
		{
			AddHotelWindows addHotelWindows = new AddHotelWindows(_context,this);
			addHotelWindows.ShowDialog();
		}
	}
}
