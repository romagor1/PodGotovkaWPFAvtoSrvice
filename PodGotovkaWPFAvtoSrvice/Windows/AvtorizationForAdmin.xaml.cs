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
	/// Логика взаимодействия для AvtorizationForAdmin.xaml
	/// </summary>
	public partial class AvtorizationForAdmin : Window
	{
		private test_tbEntities _context = new test_tbEntities();
		private List<User> _User = new List<User>();
		public AvtorizationForAdmin()
		{
			InitializeComponent();
		}

		private void BtnLoginUser_Click(object sender, RoutedEventArgs e)
		{
			_User = _context.User.ToList();
			var CurrentUser = _User.FirstOrDefault(u => u.Login == txtLoginBox.Text && u.Paswrord == txtPasswordBox.Text && u.Role == "admin");
				if (CurrentUser != null)
				{
					ProductTable window = new ProductTable();
					window.Show();
					
				}
				else
				{
					MessageBox.Show("Нет права доступа");
				}
			this.Close();
		}
    }
}
