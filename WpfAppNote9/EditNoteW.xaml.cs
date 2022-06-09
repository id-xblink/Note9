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
    public partial class EditNoteW : Window
    {
		SolidColorBrush brushGreen = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00bd32"));
		SolidColorBrush brushRed = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#bd0000"));

		public EditNoteW()
        {
            InitializeComponent();
        }

		private void BExit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void BGo_Click(object sender, RoutedEventArgs e)
		{
			if (TBTitle.Text != "" && TBText.Text != "")
			{
				//Создание заметки
				string query = "";

				if (NoteData.ID_Note == "") //Если идёт добавление новой заметки
				{
					if (NoteData.Action_Datetime != "")
					{
						//Добавление с напоминанием
						query = $"INSERT INTO `note_history` (`title`, `text`, `create_datetime`, `remind_datetime`) VALUES ('{TBTitle.Text}', '{TBText.Text}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{Convert.ToDateTime(NoteData.Action_Datetime).ToString("yyyy-MM-dd HH:mm:ss")}'); SELECT LAST_INSERT_ID();";
					}
					else
					{
						//Обычное добавление
						query = $"INSERT INTO `note_history` (`title`, `text`, `create_datetime`) VALUES ('{TBTitle.Text}', '{TBText.Text}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}'); SELECT LAST_INSERT_ID();";
					}
					//Получаем ид последней добавленной записи из истории заметок
					string idHistory = new MySqlCommand(query, DBConnector.MainConnection).ExecuteScalar().ToString();
					//Получаем ид последней добавленной записи из заметок
					string idNote = new MySqlCommand($"INSERT INTO `note` (current_note_id, user_id) VALUES ({idHistory}, {User.ID}); SELECT LAST_INSERT_ID();", DBConnector.MainConnection).ExecuteScalar().ToString();
					//Прикрепляем ид последней добавленой записи из истории заметок к последней добавленной записи из заметок
					new MySqlCommand($"UPDATE `note_history` SET `note_id` = {idNote} WHERE `id` = {idHistory}", DBConnector.MainConnection).ExecuteNonQuery();
					//Прикрепляем карту, если есть
					if (NoteData.Latitude != "")
					{
						query = $"INSERT INTO `map` (`note_history_id`, `latitude`, `longitude`) VALUES ({idHistory}, '{NoteData.Latitude}', '{NoteData.Longitude}')";
						new MySqlCommand(query, DBConnector.MainConnection).ExecuteNonQuery();
					}
					MessageBox.Show("Новая заметка успешно добавлена!", "Добавление", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
				}
				else
				{
					//Редактирование
					if (NoteData.Action_Datetime != "")
					{
						//Добавление с напоминанием
						query = $"INSERT INTO `note_history` (`note_id`, `title`, `text`, `create_datetime`, `remind_datetime`) VALUES ({NoteData.ID_Note}, '{TBTitle.Text}', '{TBText.Text}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{Convert.ToDateTime(NoteData.Action_Datetime).ToString("yyyy-MM-dd HH:mm:ss")}'); SELECT LAST_INSERT_ID();";
					}
					else
					{
						//Обычное добавление
						query = $"INSERT INTO `note_history` (`note_id`, `title`, `text`, `create_datetime`) VALUES ({NoteData.ID_Note}, '{TBTitle.Text}', '{TBText.Text}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}'); SELECT LAST_INSERT_ID();";
					}
					//Получаем ид последней добавленной записи из истории заметок
					string idHistory = new MySqlCommand(query, DBConnector.MainConnection).ExecuteScalar().ToString();
					//Изменяем ид в главные заметки на последнюю актуальную запись из истории заметок
					new MySqlCommand($"UPDATE `note` SET `current_note_id` = {idHistory} WHERE `id` = {NoteData.ID_Note};", DBConnector.MainConnection).ExecuteNonQuery();
					//Прикрепляем карту, если есть
					if (NoteData.Latitude != "")
					{
						query = $"INSERT INTO `map` (`note_history_id`, `latitude`, `longitude`) VALUES ({idHistory}, '{NoteData.Latitude}', '{NoteData.Longitude}')";
						new MySqlCommand(query, DBConnector.MainConnection).ExecuteNonQuery();
					}
					MessageBox.Show("Текущая заметка успешно изменена!", "Изменение", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

				}
				BExit_Click(sender, e);
			}
			else
			{
				if (NoteData.ID_Note == "")
					MessageBox.Show("Необходимо иметь заполненные поля заголовка и текста, чтобы добавить заметку", "Добавление", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
				else
					MessageBox.Show("Необходимо иметь заполненные поля заголовка и текста, чтобы изменить заметку", "Изменение", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
			}
		}

		private void GetDataNote()
		{
			NoteData.GetData(NoteData.ID_Note_History);
			TBTitle.Text = NoteData.Title;
			TBText.Text = NoteData.Text;
			Highlight();
		}
		
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			if (NoteData.ID_Note_History != "")
			{
				//Изменение
				TBHeading.Text = "Изменение заметки";
				BGo.Content = "Изменить";
				BHistory.IsEnabled = true;
				GetDataNote();
				if (Convert.ToInt32(new MySqlCommand($"SELECT COUNT(*) FROM `note_history` WHERE `note_id` = {NoteData.ID_Note}", DBConnector.HelpConnection).ExecuteScalar()) > 1)
					BHistory.Foreground = brushGreen;
				else
					BHistory.IsEnabled = false;
			}
		}

		private void BAlarm_Click(object sender, RoutedEventArgs e)
		{
			HelpAlarmW helpAlarm = new HelpAlarmW();
			helpAlarm.ShowDialog();
			Highlight();
		}

		private void BMap_Click(object sender, RoutedEventArgs e)
		{
			HelpMapW helpMap = new HelpMapW();
			helpMap.ShowDialog();
			Highlight();
		}

		private void BHistory_Click(object sender, RoutedEventArgs e)
		{
			string note_history_id = NoteData.ID_Note_History;
			HelpHistoryW helpHistory = new HelpHistoryW();
			helpHistory.ShowDialog();
			//Если была выбрана заметка из истории
			if (note_history_id != NoteData.ID_Note_History)
				GetDataNote();
		}

		private void Highlight()
		{
			if (NoteData.Action_Datetime != "")
				BAlarm.Foreground = brushGreen;
			else
				BAlarm.Foreground = brushRed;

			if (NoteData.Latitude != "")
				BMap.Foreground = brushGreen;
			else
				BMap.Foreground = brushRed;
		}

		private void Field_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (e.Text == "'" || e.Text == "\"" || e.Text == "\\")
				e.Handled = true;
		}
	}
}