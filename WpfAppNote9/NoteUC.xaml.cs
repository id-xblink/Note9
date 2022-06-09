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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppNote9
{
	public partial class NoteUC : UserControl
	{
		int pages = 0;
		int currentPage = 0;

		public NoteUC()
		{
			InitializeComponent();
		}

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
			string query = $"SELECT COUNT(*) FROM `note` AS n INNER JOIN `note_history` AS h ON `n`.`current_note_id` = `h`.`id` WHERE `n`.`user_id` = {User.ID}";
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

			string query = $"SELECT `n`.`id`, `n`.`current_note_id`, `n`.`user_id`, `h`.`id` as {"id2"}, `h`.`note_id`, `h`.`title`, `h`.`text`, `h`.`create_datetime` , `h`.`remind_datetime` FROM `note` AS n INNER JOIN `note_history` AS h ON `n`.`current_note_id` = `h`.`id` WHERE `n`.`user_id` = {User.ID}";

			if (TBFind.Text != "")
				query += $" AND `h`.`title` LIKE '%{TBFind.Text}%'";
			query += $" LIMIT {15 * (currentPage - 1)}, 15";
			if (currentPage != 0)
			{
				MySqlDataReader reader = new MySqlCommand(query, DBConnector.MainConnection).ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						DateTime dateTime = Convert.ToDateTime(reader["create_datetime"]);

						NoteItemUC itemUC = new NoteItemUC();
						itemUC.TBTitle.Text = reader["title"].ToString();
						itemUC.TBDate.Text = $"Создана {dateTime.ToString("dd.MM.yyyy")} в {dateTime.ToString("HH:mm:ss")}";
						itemUC.TBText.Text = reader["text"].ToString();

						itemUC.BShow.Tag = reader["id2"].ToString();
						itemUC.BEdit.Tag = reader["id2"].ToString();
						itemUC.BErase.Tag = reader["id2"].ToString();

						itemUC.BShow.Click += NoteShow_Click;
						itemUC.BEdit.Click += NoteEdit_Click;
						itemUC.BErase.Click += NoteErase_Click;

						itemUC.SetValue(Grid.RowProperty, i);

						GList.Children.Add(itemUC);
						i++;
					}
				}
				reader.Close();
			}
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			BRefresh_Click(sender, e);
		}

		private void NoteShow_Click(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;
			ShowNoteW showNote = new ShowNoteW
			{
				Tag = true
			};
			showNote.BGo.Tag = button.Tag;

			showNote.ShowDialog();
			BRefresh_Click(sender, e);
		}

		private void NoteEdit_Click(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;
			NoteData.Clear();
			NoteData.ID_Note_History = button.Tag.ToString();
			EditNoteW editNote = new EditNoteW();
			editNote.ShowDialog();
			BRefresh_Click(sender, e);
		}

		private void NoteErase_Click(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;
			MessageBoxResult answer = MessageBox.Show("Удаление повлечёт за собой также и удаление всей истории. Продолжить?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.DefaultDesktopOnly);
			if (answer == MessageBoxResult.Yes)
			{
				string query = $"DELETE FROM `note` WHERE `current_note_id` = {button.Tag.ToString()}";
				try
				{
					new MySqlCommand(query, DBConnector.MainConnection).ExecuteNonQuery();
					MessageBox.Show("Заметка успешно удалена!", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Ошибка: " + ex.Message);
				}
				BRefresh_Click(sender, e);
			}
		}

		private void BRefresh_Click(object sender, RoutedEventArgs e)
		{
			RefreshPages();
			RefreshNotes();
		}

		private void BAdd_Click(object sender, RoutedEventArgs e)
		{
			NoteData.Clear();
			EditNoteW editNote = new EditNoteW();
			editNote.ShowDialog();
			BRefresh_Click(sender, e);
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