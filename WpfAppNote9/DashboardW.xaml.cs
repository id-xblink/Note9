using Microsoft.Win32;
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
using MySql.Data.MySqlClient;
using System.IO;
using System.Drawing;

namespace WpfAppNote9
{
	public partial class DashboardW : Window
	{
		System.Windows.Forms.NotifyIcon TrayIcon = null;
		System.Windows.Forms.MenuItem itemShow = new System.Windows.Forms.MenuItem
		{
			Text = "Развернуть",
			Visible = false,
		};

		public DashboardW()
		{
			InitializeComponent();
		}

		//Переопределяем обработку первичной инициализации приложения
		protected override void OnSourceInitialized(EventArgs e)
		{
			base.OnSourceInitialized(e); //Базовый функционал приложения в момент запуска
			CreateTrayIcon(); //Создание иконки
		}

		private void CreateTrayIcon()
		{
			//Контекстное меню
			System.Windows.Forms.ContextMenu menu = new System.Windows.Forms.ContextMenu();
			System.Windows.Forms.MenuItem itemClose = new System.Windows.Forms.MenuItem
			{
				Text = "Выход"
			};
			//Действия
			itemShow.Click += Show;
			itemClose.Click += Exit;
			//
			menu.MenuItems.Add(itemShow);
			menu.MenuItems.Add("-");
			menu.MenuItems.Add(itemClose);
			//
			TrayIcon = new System.Windows.Forms.NotifyIcon
			{
				Icon = new Icon("logo.ico"),
				Text = "Note9",
				ContextMenu = menu,
			};
			TrayIcon.Visible = true; //Иконка видима в трее
		}

		private void Show(object sender, EventArgs e)
		{
			foreach (Window window in Application.Current.Windows)
			{
				if (window.GetType().ToString() == "WpfAppNote9.DashboardW")
				{
					if (!window.IsVisible)
					{
						window.Show();
						itemShow.Visible = false;
						break;
					}
				}
			}
		}

		private void Exit(object sender, EventArgs e)
		{
			TrayIcon.Dispose();
			Reminder.StopReminder();
			DBConnector.CloseDBConnection();
			Environment.Exit(0);
		}

		private void LVMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			TransitioningContentSlide.OnApplyTemplate();
			GCursor.Margin = new Thickness(0, 60 * LVMenu.SelectedIndex, 0, 0);
			//Открытие разделов
			GMainContent.Children.Clear();
			switch (LVMenu.SelectedIndex)
			{
				case 0:
					{
						//Заметки
						GMainContent.Children.Add(new NoteUC());
						break;
					}
				case 1:
					{
						//Карта
						GMainContent.Children.Add(new MapUC());
						break;
					}
				case 2:
					{
						//Профиль
						ProfileW profile = new ProfileW
						{
							Tag = this,
						};

						string avatar_id = User.Avatar_ID;
						profile.ShowDialog();
						CheckTheme();
						if (avatar_id != User.Avatar_ID)
							RefreshAvatar(User.Avatar_ID, true);
						LVMenu.SelectedIndex = 0;
						break;
					}
				case 3:
					{
						//Фоновый режим
						MessageBoxResult answer = MessageBox.Show("Переход в фоновый режим позволит ассистенту отслеживать напоминания о заметках, но будет всё ещё использоваться системой. Действительно перейти?", "Фоновый режим", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.DefaultDesktopOnly);
						if (answer == MessageBoxResult.Yes)
						{
							Hide();
							itemShow.Visible = true;
						}
						LVMenu.SelectedIndex = 0;
						break;
					}
				case 4:
					{
						//Выйти
						MessageBoxResult answer = MessageBox.Show("Выход из аккаунта не позволит получать уведомления о заметках. Если нужно закрыть приложение, то воспользуйтесь функцией \"Фоновый режим\". Действительно выйти?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.DefaultDesktopOnly);
						if (answer == MessageBoxResult.Yes)
						{
							RegistryKey CurrentUserKey = Registry.CurrentUser;
							RegistryKey Note9Key = CurrentUserKey.CreateSubKey("Note9");
							if (Note9Key.GetValue("login") != null)
								Note9Key.DeleteValue("login");
							if (Note9Key.GetValue("password") != null)
								Note9Key.DeleteValue("password");
							Note9Key.Close();
							Reminder.StopReminder();
							StartW start = new StartW();
							start.Show();
							Close();
						}
						else
							LVMenu.SelectedIndex = 0;
						break;
					}
				case 5:
					{
						//Выключить
						MessageBoxResult answer = MessageBox.Show("Выход из приложения не позволит получать уведомления о заметках. Действительно выйти?", "Выключение", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.DefaultDesktopOnly);
						if (answer == MessageBoxResult.Yes)
							Exit(sender, e);
						else
							LVMenu.SelectedIndex = 0;
						break;
					}
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			Reminder.StartReminder();
			RefreshAvatar(User.Avatar_ID, true);
			CheckTheme();
			LVMenu.SelectedIndex = 0;
		}

		private void CheckTheme()
		{
			if (User.Theme_ID == "1")
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

		private void Window_Closed(object sender, EventArgs e)
		{
			TrayIcon.Dispose();
		}

		private void IAvatar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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
				string query = $"UPDATE `user` SET `avatar_id` = {User.Avatar_ID} WHERE `user`.`id` = {User.ID}";
				new MySqlCommand(query, DBConnector.MainConnection).ExecuteNonQuery();
				reload = true;
				MessageBox.Show("Ваш аватар успешно изменён!", "Аватар", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
			}

			if (reload)
			{
				//Загрузка картинки
				string query = $"SELECT `a`.* FROM `user` as u INNER JOIN `avatar` as a ON `a`.`id` = `u`.`avatar_id` WHERE `u`.`id` = {User.ID}";
				MySqlDataReader reader = new MySqlCommand(query, DBConnector.MainConnection).ExecuteReader();
				reader.Read();
				BitmapImage bi = new BitmapImage();
				bi.BeginInit();
				bi.StreamSource = new MemoryStream((byte[])(reader["image"]));
				bi.EndInit();
				IAvatar.Source = bi;
				IAvatar.Tag = reader["id"];
				reader.Close();
			}
		}
	}
}