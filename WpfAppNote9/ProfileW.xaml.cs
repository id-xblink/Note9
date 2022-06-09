using System;
using System.Collections.Generic;
using System.IO;
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
using MaterialDesignThemes.Wpf;
using MySql.Data.MySqlClient;

namespace WpfAppNote9
{
    public partial class ProfileW : Window
    {
        public ProfileW()
        {
            InitializeComponent();
        }

		private void TextBlockChange_PreviewMouseUp(object sender, MouseButtonEventArgs e)
		{
			TextBlock tb = sender as TextBlock;
			ChangeFieldW changeFieldW = new ChangeFieldW
			{
				Tag = this,
				type = tb.Tag.ToString(),
			};
			changeFieldW.ShowDialog();
			DesignCheck();
		}

		public void DesignCheck()
		{
			if (TBSurname.Text == "" && TBName.Text == "" && TBLastname.Text == "")
			{
				TBWarning.Visibility = Visibility.Visible;
			}
			else
			{
				TBWarning.Visibility = Visibility.Collapsed;
			}

			if (TBDateBirthValue.Text == "")
			{
				TBBirthWarning.Visibility = Visibility.Visible;
			}
			else
			{
				TBBirthWarning.Visibility = Visibility.Collapsed;
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			if (User.Theme_ID == "1")
				RBLight.IsChecked = true;
			else
				RBDark.IsChecked = true;

			if (User.Surname == "" && User.Name == "" && User.Lastname == "")
				TBWarning.Visibility = Visibility.Visible;
			else
			{
				TBSurname.Text = User.Surname;
				TBName.Text = User.Name;
				TBLastname.Text = User.Lastname;
			}

			TBDateRegValue.Text = User.Registration_Datetime;

			if (User.Birthday != "")
				TBDateBirthValue.Text = User.Birthday;
			else
				TBBirthWarning.Visibility = Visibility.Visible;

			TBLoginValue.Text = User.Login;

			BViewPass.Tag = User.Password;

			string temporary = "";

			for (int i = 0; i < User.Password.Length; i++)
				temporary += "*";
			TBPassValue.Text = temporary;

			string query = $"SELECT `a`.* FROM `user` as u INNER JOIN `avatar` as a ON `a`.`id` = `u`.`avatar_id` WHERE `u`.`id` = {User.ID}";
			MySqlDataReader reader = new MySqlCommand(query, DBConnector.MainConnection).ExecuteReader();
			reader.Read();
			BitmapImage bi = new BitmapImage();
			bi.BeginInit();
			bi.StreamSource = new MemoryStream((byte[])(reader["image"]));
			bi.EndInit();
			IBAvatar.ImageSource = bi;
			BAvatar.Tag = reader["id"].ToString();
			reader.Close();

			RBLight.Checked += RBThemeChange_Checked;
			RBDark.Checked += RBThemeChange_Checked;
		}

		private void BViewPass_Click(object sender, RoutedEventArgs e)
		{
			string temporary = "";
			temporary = TBPassValue.Text;
			TBPassValue.Text = BViewPass.Tag.ToString();
			BViewPass.Tag = temporary;
			if (PIIcon.Kind == PackIconKind.EyeOff)
				PIIcon.Kind = PackIconKind.Eye;
			else
				PIIcon.Kind = PackIconKind.EyeOff;
		}

		private void BBack_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void BAvatar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			string avatar_id = User.Avatar_ID;
			AvatarW avatar = new AvatarW();
			avatar.ShowDialog();
			RefreshAvatar(avatar_id, false);
		}

		private void RefreshAvatar(string id, bool reload)
		{
			if (User.Avatar_ID != id)
			{
				string query = $"SELECT * FROM `avatar` WHERE `avatar`.`id` = {User.Avatar_ID}";
				User.Avatar_ID = id;

				MySqlDataReader reader = new MySqlCommand(query, DBConnector.MainConnection).ExecuteReader();
				reader.Read();
				BitmapImage bi = new BitmapImage();
				bi.BeginInit();
				bi.StreamSource = new MemoryStream((byte[])(reader["image"]));
				bi.EndInit();
				IBAvatar.ImageSource = bi;
				BAvatar.Tag = reader["id"];
				reader.Close();
			}
		}

		private void BChange_Click(object sender, RoutedEventArgs e)
		{
			string password = "";

			if (PIIcon.Kind == PackIconKind.EyeOff)
				password = BViewPass.Tag.ToString();
			else
				password = TBPassValue.Text;

			if (TBLoginValue.Text != "" && password != "")
			{
				string query = $"SELECT `id` FROM `user` WHERE `login` = '{TBLoginValue.Text}' and `id` != {User.ID}";
				int id = Convert.ToInt32(new MySqlCommand(query, DBConnector.MainConnection).ExecuteScalar());
				if (id == 0)
				{
					query = $"UPDATE `user` SET `surname` = '{TBSurname.Text}', `name` = '{TBName.Text}', `lastname` = '{TBLastname.Text}', `login` = '{TBLoginValue.Text}', `password` = '{password}', `avatar_id` = {BAvatar.Tag} WHERE `user`.`id` = {User.ID}";
					new MySqlCommand(query, DBConnector.MainConnection).ExecuteNonQuery();

					if (TBDateBirthValue.Text == "")
						query = $"UPDATE `user` SET `birthday` = NULL";
					else
						query = $"UPDATE `user` SET `birthday` = '{Convert.ToDateTime(TBDateBirthValue.Text).ToString("yyyy-MM-dd")}'";
					query += $" WHERE `user`.`id` = {User.ID}";
					new MySqlCommand(query, DBConnector.MainConnection).ExecuteNonQuery();

					if (Convert.ToBoolean(RBLight.IsChecked))
						query = $"UPDATE `user` SET `theme_id` = 1";
					else
						query = $"UPDATE `user` SET `theme_id` = 2";
					query += $" WHERE `user`.`id` = {User.ID}";
					new MySqlCommand(query, DBConnector.MainConnection).ExecuteNonQuery();



					User.Refresh(User.ID);
					MessageBox.Show("Профиль успешно изменена!", "Профиль", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
					BBack_Click(sender, e);
				}
				else
					MessageBox.Show("Пользователь с таким логином уже существует", "Профиль", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
			}
			else
				MessageBox.Show("Профиль обязан содержать в себе логин и пароль", "Профиль", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
		}

		private void RBThemeChange_Checked(object sender, RoutedEventArgs e)
		{
			RadioButton rb = sender as RadioButton;
			if (rb.Tag.ToString() == "Light")
			{
				Application.Current.Resources.MergedDictionaries[0].Source = new Uri(Application.Current.Resources.MergedDictionaries[0].Source.ToString().Replace("Dark", "Light"));
				Application.Current.Resources.MergedDictionaries[4].Source = new Uri(Application.Current.Resources.MergedDictionaries[4].Source.ToString().Replace("Dark", "Light"));
			}
			else
			{
				Application.Current.Resources.MergedDictionaries[0].Source = new Uri(Application.Current.Resources.MergedDictionaries[0].Source.ToString().Replace("Light", "Dark"));
				Application.Current.Resources.MergedDictionaries[4].Source = new Uri(Application.Current.Resources.MergedDictionaries[4].Source.ToString().Replace("Light", "Dark"));
			}
		}
	}
}