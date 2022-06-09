using MySql.Data.MySqlClient;
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

namespace WpfAppNote9
{
	public partial class ShowNoteW : Window
	{
		public ShowNoteW()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00bd32")); //Зелёный

			string id = BGo.Tag.ToString();

			string query = $"SELECT * FROM `note_history` WHERE `id` = {id}";

			MySqlDataReader reader = new MySqlCommand(query, DBConnector.MainConnection).ExecuteReader();
			reader.Read();
			DateTime dateTime = Convert.ToDateTime(reader["create_datetime"]);
			TBTitle.Text = reader["title"].ToString();
			TBDate.Text = $"Создана {dateTime.ToString("dd.MM.yyyy")} в {dateTime.ToString("HH:mm:ss")}";
			TBText.Text = reader["text"].ToString();

			//Напоминалка
			if (reader["remind_datetime"].ToString() != "")
			{
				IAlarm.ToolTip = new ToolTip { Content = new TextBlock { Text = $"Дата и время напоминания: {Convert.ToDateTime(reader["remind_datetime"])}" } };
				IAlarm.Foreground = brush;
			}
			else
			{
				IAlarm.ToolTip = new ToolTip { Content = new TextBlock { Text = $"Нет напоминания" } };
			}

			//Карта
			if (new MySqlCommand($"SELECT * FROM `map` WHERE `note_history_id` = {id}", DBConnector.HelpConnection).ExecuteScalar() != null)
			{
				IMap.ToolTip = new ToolTip { Content = new TextBlock { Text = $"Отмечена на карте" } };
				IMap.Foreground = brush;
			}
			else
			{
				IMap.ToolTip = new ToolTip { Content = new TextBlock { Text = $"Нет метки на карте" } };
			}
			
			//История
			int count = Convert.ToInt32(new MySqlCommand($"SELECT COUNT(*) FROM `note_history` WHERE `note_id` = {reader["note_id"]}", DBConnector.HelpConnection).ExecuteScalar());
			if (count > 1)
			{
				IHistory.ToolTip = new ToolTip { Content = new TextBlock { Text = $"История записей: {count}" } };
				IHistory.Foreground = brush;
			}
			else
			{
				IHistory.ToolTip = new ToolTip { Content = new TextBlock { Text = $"Нет истории записей" } };
			}

			reader.Close();


			if (!Convert.ToBoolean(Tag))
				BGo.Content = "Выбрать";
		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void BGo_Click(object sender, RoutedEventArgs e)
		{
			if (Convert.ToBoolean(Tag))
			{
				//Если работает по назначению (изменение)
				NoteData.Clear();
				NoteData.ID_Note_History = BGo.Tag.ToString();
				EditNoteW editNote = new EditNoteW();
				editNote.ShowDialog();
				Exit_Click(sender, e);
			}
			else
			{
				//Если работает как выбор
				NoteData.ID_Note_History = BGo.Tag.ToString();
				Exit_Click(sender, e);
			}
		}
	}
}