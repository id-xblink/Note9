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
using MySql.Data.MySqlClient;

namespace WpfAppNote9
{
    public partial class AvatarW : Window
    {
        public AvatarW()
        {
            InitializeComponent();
        }

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			int i = 0;
			string query = $"SELECT * FROM `avatar`";
			MySqlDataReader reader = new MySqlCommand(query, DBConnector.MainConnection).ExecuteReader();

			while (reader.Read())
			{
				AvatarItemUC avatarItem = new AvatarItemUC();

				if (reader["image"].ToString() != "")
				{
					BitmapImage bi = new BitmapImage();
					bi.BeginInit();
					bi.StreamSource = new MemoryStream((byte[])(reader["image"]));
					bi.EndInit();
					avatarItem.IAvatar.Source = bi;
				}
				avatarItem.BChoose.Tag = reader["id"].ToString();
				avatarItem.BChoose.Click += BChoose_Click;

				if (reader["id"].ToString() == User.Avatar_ID)
					avatarItem.BChoose.IsEnabled = false;

				GList.RowDefinitions.Add(new RowDefinition { Height = new GridLength(70) });
				
				avatarItem.SetValue(Grid.RowProperty, i);

				GList.Children.Add(avatarItem);
				i++;
			}
			reader.Close();
		}

		private void BBack_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void BChoose_Click(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;
			User.Avatar_ID = button.Tag.ToString();
			BBack_Click(sender, e);
		}
	}
}