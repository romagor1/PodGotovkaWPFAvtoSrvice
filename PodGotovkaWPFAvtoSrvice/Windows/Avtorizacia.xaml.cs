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

namespace PodGotovkaWPFAvtoSrvice.Windows
{
	/// <summary>
	/// Логика взаимодействия для Avtorizacia.xaml
	/// </summary>
	public partial class Avtorizacia : Window
	{
		private test_tbEntities _context = new test_tbEntities();
		private List<User> _User = new List<User>();
		public Avtorizacia()
		{
			InitializeComponent();
		}

		private void BtnLoginUser_Click(object sender, RoutedEventArgs e)
		{
			_User = _context.User.ToList();
			var CurrentUser = _User.FirstOrDefault(u => u.Login == txtLoginBox.Text && u.Paswrord == txtPasswordBox.Text);
			if (CurrentUser != null)
			{
				BuyProductWindow window = new BuyProductWindow();
				window.Show();

			}
			else
			{
				MessageBox.Show("Данные не коректы");
			}
			this.Close();
		}

		private void BtnRegistrationUser_Click(object sender, RoutedEventArgs e)
		{
			Windows.Registration window = new Windows.Registration();
			window.Show();
		}
	}
}
