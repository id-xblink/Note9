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

namespace WpfAppNote9
{
    public partial class HelpHistoryW : Window
    {
        public HelpHistoryW()
        {
            InitializeComponent();
        }

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			BRefresh_Click(sender, e);
		}

		private void BLeave_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		int pages = 0;
		int currentPage = 0;

		private void NotePage_Click(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;

			switch (button.Tag.ToString())
			{
				case "Start":
					{
						if (currentPage != 1)
						{
							currentPage = 1;
							TBPage.Text = $"{currentPage} из {pages}";
							RefreshNotes();
						}
						break;
					}
				case "Previous":
					{
						if (currentPage - 1 > 0)
						{
							currentPage--;
							TBPage.Text = $"{currentPage} из {pages}";
							RefreshNotes();
						}
						break;
					}
				case "Next":
					{
						if (currentPage + 1 <= pages)
						{
							currentPage++;
							TBPage.Text = $"{currentPage} из {pages}";
							RefreshNotes();
						}
						break;
					}
				case "End":
					{
						if (currentPage != pages)
						{
							currentPage = pages;
							TBPage.Text = $"{currentPage} из {pages}";
							RefreshNotes();
						}
						break;
					}
			}
		}

		public void RefreshPages()
		{
			string query = $"SELECT COUNT(*) FROM `note` AS n INNER JOIN `note_history` AS h ON `n`.`id` = `h`.`note_id` WHERE `n`.`user_id` = {User.ID} AND `h`.`note_id` = {NoteData.ID_Note}";
			if (TBFind.Text != "")
				query += $" AND `h`.`title` LIKE '%{TBFind.Text}%'";

			double rows = Convert.ToInt32(new MySqlCommand(query, DBConnector.MainConnection).ExecuteScalar());

			pages = Convert.ToInt32(Math.Ceiling(rows / 15));

			if (pages > 0)
			{
				currentPage = 1;
				TBPage.Text = $"{currentPage} из {pages}";
				BStart.IsEnabled = true;
				BPrevious.IsEnabled = true;
				BNext.IsEnabled = true;
				BEnd.IsEnabled = true;
			}
			else
			{
				TBPage.Text = "0 из 0";
				BStart.IsEnabled = false;
				BPrevious.IsEnabled = false;
				BNext.IsEnabled = false;
				BEnd.IsEnabled = false;
			}
		}

		public void RefreshNotes()
		{
			GList.Children.Clear();
			int i = 0;

			string query = $"SELECT `h`.`id` as {"id2"}, `h`.`note_id`, `h`.`title`, `h`.`text`, `h`.`create_datetime` , `h`.`remind_datetime` FROM `note` AS n INNER JOIN `note_history` AS h ON `n`.`id` = `h`.`note_id` WHERE `n`.`user_id` = {User.ID} AND `h`.`note_id` = {NoteData.ID_Note}";
			if (TBFind.Text != "")
				query += $" AND `h`.`title` LIKE '%{TBFind.Text}%'";
			query += $" LIMIT {15 * (currentPage - 1)}, 15";
			MySqlDataReader reader = new MySqlCommand(query, DBConnector.MainConnection).ExecuteReader();


			if (reader.HasRows)
			{
				while (reader.Read())
				{
					DateTime dateTime = Convert.ToDateTime(reader["create_datetime"]);

					HelpNoteItemUC helpNoteItem = new HelpNoteItemUC();
					helpNoteItem.TBTitle.Text = reader["title"].ToString();
					helpNoteItem.TBDate.Text = $"Создана {dateTime.ToString("dd.MM.yyyy")} в {dateTime.ToString("HH:mm:ss")}";
					helpNoteItem.TBText.Text = reader["text"].ToString();

					helpNoteItem.BShow.Tag = reader["id2"].ToString();
					helpNoteItem.BChoose.Tag = reader["id2"].ToString();

					helpNoteItem.BShow.Click += NoteShow_Click;
					helpNoteItem.BChoose.Click += NoteChoose_Close;

					helpNoteItem.SetValue(Grid.RowProperty, i);

					if (reader["id2"].ToString() == NoteData.ID_Note_History)
						helpNoteItem.IsEnabled = false;

					GList.Children.Add(helpNoteItem);
					i++;
				}
			}
			reader.Close();
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			BRefresh_Click(sender, e);
		}

		private void NoteChoose_Close(object sender, RoutedEventArgs e)
		{
			//Выбор заметки
			Button button = sender as Button;
			NoteData.ID_Note_History = button.Tag.ToString();
			BLeave_Click(sender, e);
		}

		private void NoteShow_Click(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;
			ShowNoteW showNote = new ShowNoteW
			{
				Tag = false
			};

			showNote.BGo.Tag = button.Tag;

			string note_history_id = NoteData.ID_Note_History;

			showNote.ShowDialog();

			if (note_history_id != NoteData.ID_Note_History)
				BLeave_Click(sender, e);
		}

		private void BRefresh_Click(object sender, RoutedEventArgs e)
		{
			RefreshPages();
			RefreshNotes();
		}

		private void TBFind_TextChanged(object sender, TextChangedEventArgs e)
		{
			BRefresh_Click(sender, e);
		}

		private void BClearFind_Click(object sender, RoutedEventArgs e)
		{
			TBFind.Text = "";
		}

		private void Field_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (e.Text == "'" || e.Text == "\"" || e.Text == "\\")
				e.Handled = true;
		}
	}
}