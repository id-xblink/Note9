using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppNote9
{
	public static class NoteData
	{
		public static string ID_Note = ""; //ИД из основной таблицы
		public static string ID_Note_History = ""; //ИД из истории
		public static string Map_ID { get; set; }
		public static string Latitude { get; set; }
		public static string Longitude { get; set; }
		public static string Action_Datetime { get; set; } //Напоминание
		public static string Title { get; set; }
		public static string Text { get; set; }
		public static string Create_Datetime { get; set; }

		public static void GetData(string id)
		{
			Clear();
			string query = $"SELECT * FROM `note_history` WHERE `id` = {id}";
			MySqlDataReader reader = new MySqlCommand(query, DBConnector.MainConnection).ExecuteReader();
			reader.Read();
			ID_Note = reader["note_id"].ToString();
			ID_Note_History = reader["id"].ToString();
			Title = reader["title"].ToString();
			Text = reader["text"].ToString();
			Create_Datetime = Convert.ToDateTime(reader["create_datetime"]).ToString("dd.MM.yyyy HH:mm:ss");

			if (reader["remind_datetime"].ToString() != "")
				Action_Datetime = Convert.ToDateTime(reader["remind_datetime"]).ToString("dd.MM.yyyy HH:mm:ss");

			reader.Close();
			
			query = $"SELECT * FROM `map` WHERE `note_history_id` = {id}";
			reader = new MySqlCommand(query, DBConnector.MainConnection).ExecuteReader();

			if (reader.HasRows)
			{
				reader.Read();
				Latitude = reader["latitude"].ToString();
				Longitude = reader["longitude"].ToString();
			}

			reader.Close();
		}

		public static void Clear()
		{
			ID_Note_History = "";
			ID_Note = "";
			Latitude = "";
			Longitude = "";
			Map_ID = "";
			Action_Datetime = "";
			Title = "";
			Text = "";
			Create_Datetime = "";
		}
	}
}