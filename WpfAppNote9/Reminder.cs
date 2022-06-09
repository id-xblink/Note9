using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using MySql.Data.MySqlClient;

namespace WpfAppNote9
{
    public static class Reminder
    {


		static System.Windows.Threading.DispatcherTimer reminder = new System.Windows.Threading.DispatcherTimer();

		public static void StartReminder()
		{
			reminder.Tick += new EventHandler(Check);
			reminder.Interval = new TimeSpan(0, 0, 1);
			reminder.Start();
		}

		public static void StopReminder()
		{
			reminder.Stop();
			reminder.Tick -= new EventHandler(Check);
		}

		private static void Check(object sender, EventArgs e)
		{
			try
			{
				string query = $"SELECT `h`.`title`, `h`.`text`, `h`.`remind_datetime` FROM `note` AS n INNER JOIN `note_history` AS h ON `n`.`current_note_id` = `h`.`id` WHERE `n`.`user_id` = {User.ID} and `h`.`remind_datetime` = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}'";
				MySqlDataReader reader = new MySqlCommand(query, DBConnector.RemindConnection).ExecuteReader();

				if (reader.HasRows)
					while (reader.Read())
					{
						MessageBox.Show($"Заголовок: {reader["title"]}\n\nТекст: {reader["text"]}\n", "Напоминание", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
					}
				reader.Close();
			}
			catch (Exception)
			{
				StopReminder();
				MessageBox.Show($"Непредвиденная ошибка. Возможно был потерян доступ к интернету. Запустите приложение заного, чтобы продолжить работу", "Note9", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
				Environment.Exit(0);
			}
		}
	}
}