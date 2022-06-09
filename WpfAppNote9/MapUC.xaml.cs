using Microsoft.Maps.MapControl.WPF;
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
using MaterialDesignThemes.Wpf;

namespace WpfAppNote9
{
    public partial class MapUC : UserControl
    {
        public MapUC()
        {
            InitializeComponent();
        }

		public void RefreshNotes()
		{
			MMap.Children.Clear();
			List<TextBlock> vs = new List<TextBlock>();
			SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#bd0000"));
			//Запрос на показ меток
			string query = $"SELECT * FROM `note` WHERE `user_id` = {User.ID}";
			MySqlCommand command = new MySqlCommand(query, DBConnector.MainConnection);
			MySqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				query = $"SELECT * FROM `note_history` WHERE `id` = {reader["current_note_id"]}";
				MySqlDataReader reader1 = new MySqlCommand(query, DBConnector.HelpConnection).ExecuteReader();
				if (reader1.HasRows)
				{
					reader1.Read();
					TextBlock tb = new TextBlock
					{
						Text = reader1["title"].ToString(),
						Tag = reader1["id"].ToString(),
					};
					vs.Add(tb);
				}
				reader1.Close();
			}
			reader.Close();

			foreach (TextBlock tb in vs)
			{
				
				query = $"SELECT * FROM `map` WHERE `note_history_id` = {tb.Tag}";
				reader = new MySqlCommand(query, DBConnector.HelpConnection).ExecuteReader();
				if (reader.HasRows)
				{
					reader.Read();
					Location location = new Location(Convert.ToDouble(reader["latitude"]), Convert.ToDouble(reader["longitude"]));
					//Добавление метки
					PackIcon icon = new PackIcon
					{
						Kind = PackIconKind.MapMarker,
						Width = 45,
						Height = 45,
						Foreground = brush,
					};

					Canvas canvas = new Canvas
					{
						Width = 45,
						Height = 45,
					};

					canvas.Children.Add(icon);
					
					MapLayer.SetPositionOrigin(canvas, PositionOrigin.BottomCenter);
					MapLayer.SetPosition(canvas, location);
					MMap.Children.Add(canvas);

					//Добавление заголовка
					Border border = new Border
					{
						CornerRadius = new CornerRadius(10),
						Margin = new Thickness(0, 0, 0, 45),
					};
					border.SetValue(BackgroundProperty, Application.Current.FindResource("MaterialDesignPaper"));

					TextBlock textBlock = new TextBlock
					{
						Text = tb.Text,
						Margin = new Thickness(8, 2, 8, 2),
					};

					Button button = new Button
					{
						Height = double.NaN,
						FontSize = 14,
						Padding = new Thickness(0),
						Tag = tb.Tag,
					};
					button.SetValue(StyleProperty, Application.Current.FindResource("MaterialDesignFlatButton"));
					button.SetValue(ForegroundProperty, Application.Current.FindResource("MaterialDesignBody"));
					button.Content = textBlock;
					button.Click += NoteMarker_Click;
					border.Child = button;

					MapLayer.SetPositionOrigin(border, PositionOrigin.BottomCenter);
					MapLayer.SetPosition(border, location);
					MMap.Children.Add(border);
				}
				reader.Close();
			}
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			RefreshNotes();
		}

		private void NoteMarker_Click(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;

			ShowNoteW showNote = new ShowNoteW
			{
				Tag = true,
			};
			showNote.BGo.Tag = button.Tag;
			showNote.ShowDialog();
			
			RefreshNotes();
		}
	}
}