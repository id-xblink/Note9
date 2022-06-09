using System;
using System.Collections.Generic;
using System.Drawing;
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
using Microsoft.Win32;
using MySql.Data.MySqlClient;

namespace WpfAppNote9
{
	public partial class StartW : Window
	{
		public StartW()
		{
			InitializeComponent();
		}

		private void BGo_Click(object sender, RoutedEventArgs e)
		{
			DBConnector.CloseDBConnection();
			DBConnector.OpenDBConnection();
			if (Convert.ToBoolean(TBlockSwap.Tag))
			{
				//Авторизация
				Authorization(TBLogin.Text, PBPass.Password);
			}
			else
			{
				//Регистрации
				TBLogin.Text = TBLogin.Text.Trim();
				PBPass.Password = PBPass.Password.Trim();
				if (TBLogin.Text != "" && PBPass.Password != "")
				{
					string query = $"SELECT `id`, `login`, `password` FROM `user` WHERE `login` = '{TBLogin.Text}'";
					int id = Convert.ToInt32(new MySqlCommand(query, DBConnector.MainConnection).ExecuteScalar());
					if (id == 0)
					{
						if (PBPass.Password == PBRepPass.Password)
						{
							new MySqlCommand($"INSERT INTO `user` (`login`, `password`, `registration_datetime`) VALUES ('{TBLogin.Text}', '{PBPass.Password}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}');", DBConnector.MainConnection).ExecuteNonQuery();
							MessageBox.Show("Регистрация прошла успешно", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
							TBlockSwap_PreviewMouseLeftButtonUp(sender, null);
							PBRepPass.Password = "";
							PBPass.Password = "";
							TBLogin.Text = "";
							CBRemember.IsChecked = false;
						}
						else
							MessageBox.Show("Для регистрации пароли должны совпадать", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
					}
					else
						MessageBox.Show("Такой логин уже занят", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
				}
				else
					MessageBox.Show("Введите логин и пароль", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
			}
		}

		private void Authorization(string login, string password)
		{
			string query = $"SELECT `id`, `login`, `password` FROM `user` WHERE `login` = '{login}' and `password` = '{password}'";
			int id = Convert.ToInt32(new MySqlCommand(query, DBConnector.MainConnection).ExecuteScalar());
			if (id != 0)
			{
				//Автологин
				if (Convert.ToBoolean(CBRemember.IsChecked))
				{
					//Если есть чекер
					RegistryKey CurrentUserKey = Registry.CurrentUser;
					RegistryKey Note9Key = CurrentUserKey.CreateSubKey("Note9");
					Note9Key.SetValue("login", TBLogin.Text);
					Note9Key.SetValue("password", PBPass.Password);
					Note9Key.Close();
				}
				//
				User.Refresh(id.ToString());
				DashboardW dashboard = new DashboardW();
				dashboard.Show();
				Close();
				return;
			}
			else
				MessageBox.Show("Введены неверные логин или пароль", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			TBLogin.Focus();
			DBConnector.OpenDBConnection();
			RegistryKey CurrentUserKey = Registry.CurrentUser;
			RegistryKey Note9Key = CurrentUserKey.CreateSubKey("Note9");
			if (Note9Key.GetValue("login") != null && Note9Key.GetValue("password") != null)
			{
				string login = Note9Key.GetValue("login").ToString();
				string password = Note9Key.GetValue("password").ToString();
				Authorization(login, password);
			}
			Note9Key.Close();
		}

		private void TBlockSwap_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			if (Convert.ToBoolean(TBlockSwap.Tag))
			{
				TBlockSwap.Content = "Регистрация";
				PBRepPass.Visibility = Visibility.Visible;
				CBRemember.Visibility = Visibility.Collapsed;
			}
			else
			{
				TBlockSwap.Content = "Авторизация";
				PBRepPass.Visibility = Visibility.Collapsed;
				CBRemember.Visibility = Visibility.Visible;
			}
			TBlockSwap.Tag = !Convert.ToBoolean(TBlockSwap.Tag);
			TBLogin.Focus();
		}

		private void Field_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (e.Text == "'" || e.Text == "\"" || e.Text == "\\")
				e.Handled = true;
		}
	}
}