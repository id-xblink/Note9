using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using MySql.Data.MySqlClient;

namespace WpfAppNote9
{
	public static class User
	{
		public static string ID { get; set; }
		public static string Login { get; set; }
		public static string Password { get; set; }
		public static string Surname { get; set; }
		public static string Name { get; set; }
		public static string Lastname { get; set; }
		public static string Birthday { get; set; }
		public static string Theme_ID { get; set; }
		public static string Registration_Datetime { get; set; }
		public static string Avatar_ID { get; set; }

		public static bool Refresh(string id)
		{
			try
			{
				Clear();
				string query = $"SELECT * FROM `user` WHERE `id` = {id}";
				MySqlDataReader reader = new MySqlCommand(query, DBConnector.MainConnection).ExecuteReader();
				reader.Read();

				ID = reader["id"].ToString();
				Login = reader["login"].ToString();
				Password = reader["password"].ToString();
				Surname = reader["surname"].ToString();
				Name = reader["name"].ToString();
				Lastname = reader["lastname"].ToString();
				if (reader["birthday"].ToString() != "")
					Birthday = Convert.ToDateTime(reader["birthday"]).ToString("dd.MM.yyyy");
				Theme_ID = reader["theme_id"].ToString();
				if (reader["registration_datetime"].ToString() != "")
					Registration_Datetime = Convert.ToDateTime(reader["registration_datetime"]).ToString("dd.MM.yyyy");
				Avatar_ID = reader["avatar_id"].ToString();
				
				reader.Close();
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Не удалось обновить данные пользователя. Ошибка: " + ex.Message);
				return false;
			}
		}

		public static void Clear()
		{
			ID = "";
			Login = "";
			Password = "";
			Surname = "";
			Name = "";
			Lastname = "";
			Birthday = "";
			Theme_ID = "";
			Registration_Datetime = "";
			Avatar_ID = "";
		}
	}
}