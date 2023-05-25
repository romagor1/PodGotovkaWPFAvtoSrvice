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
	/// Логика взаимодействия для Registration.xaml
	/// </summary>
	public partial class Registration : Window
	{
		public static test_tbEntities _context = new test_tbEntities();
		public Registration()
		{
			InitializeComponent();
		}

		private void AddNewUser_Click(object sender, RoutedEventArgs e)
		{
			_context.User.ToList();

			_context.User.Add(new User
			{
				Name = TxtNameUser.Text,
				Login = TxtLoginUser.Text,
				Paswrord = TxtPasswordUser.Text,
				Role = "user",
			});
			_context.SaveChanges();
			this.Close();
		}
	}
}
