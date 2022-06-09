using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfAppNote9
{
	public static class DBConnector
	{
		public static MySqlConnection MainConnection = GetDBConnection();

		public static MySqlConnection HelpConnection = GetDBConnection();

		public static MySqlConnection RemindConnection = GetDBConnection();

		private static bool IsConnected = false;

		public static MySqlConnection GetDBConnection()
		{
			string host = "188.120.245.106";
			int port = 3306;
			string database = "Note9";
			string username = "Note9";
			string password = "NZC9RMrYpdDqPgXI";

			string connString = $"Server = {host}; Database = {database}; port = {port}; User Id = {username}; password = {password}";

			return new MySqlConnection(connString);
		}

		public static bool OpenDBConnection()
		{
			if (IsConnected)
			{
				//MessageBox.Show("Подключение уже создано");
				return false;
			}

			try
			{
				MainConnection.Open();
				HelpConnection.Open();
				RemindConnection.Open();
				IsConnected = true;
				return true;
			}
			catch (Exception)
			{
				MessageBoxResult result = MessageBox.Show("Возможно нет подключения к интернету. Повторить попытку?", "Note9", MessageBoxButton.YesNo, MessageBoxImage.Error, MessageBoxResult.No, MessageBoxOptions.DefaultDesktopOnly);
				if (result == MessageBoxResult.Yes)
					OpenDBConnection();
				else
					Environment.Exit(0);
				return false;
			}
		}

		public static bool CloseDBConnection()
		{
			if (!IsConnected)
			{
				//MessageBox.Show("Подключение не создано");
				return false;
			}
				
			try
			{
				RemindConnection.Close();
				HelpConnection.Close();
				MainConnection.Close();
				IsConnected = false;
				return true;
			}
			catch (Exception)
			{
				MessageBoxResult result = MessageBox.Show("Возможно нет подключения к интернету. Повторить попытку?", "Note9", MessageBoxButton.YesNo, MessageBoxImage.Error, MessageBoxResult.No, MessageBoxOptions.DefaultDesktopOnly);
				if (result == MessageBoxResult.Yes)
					CloseDBConnection();
				else
					Environment.Exit(0);
				return false;
			}
		}
	}
}