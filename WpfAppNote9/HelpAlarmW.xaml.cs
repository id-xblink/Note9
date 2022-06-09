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
    public partial class HelpAlarmW : Window
    {
        public HelpAlarmW()
        {
            InitializeComponent();
        }

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			DPDate.SelectedDateChanged += DPDate_SelectedDateChanged;
			TPTime.SelectedTimeChanged += TPTime_SelectedTimeChanged;
			if (NoteData.Action_Datetime != "")
			{
				DateTime dateTime = Convert.ToDateTime(NoteData.Action_Datetime);
				DPDate.Text = dateTime.ToShortDateString();
				TPTime.Text = dateTime.ToLongTimeString();
			}
			else
			{
				DPDate.SelectedDate = DateTime.Now.AddDays(1);
				TPTime.SelectedTime = Convert.ToDateTime("01.01.2000 12:00:00");
			}
		}

		private void BBack_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void BCancel_Click(object sender, RoutedEventArgs e)
		{
			//Очистка
			NoteData.Action_Datetime = "";
			BBack_Click(sender, e);
		}

		private void BSave_Click(object sender, RoutedEventArgs e)
		{
			if (DPDate.Text != "" && TPTime.Text != null)
			{
				NoteData.Action_Datetime = $"{DPDate.Text} {Convert.ToDateTime(TPTime.SelectedTime).ToLongTimeString()}";
				BBack_Click(sender, e);
			}
			else
				MessageBox.Show("Необходима дата и время срабатывания, чтобы добавить напоминание", "Напоминание", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
		}

		private void DPDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
		{
			RefreshResult();
		}

		private void RefreshResult()
		{
			if (DPDate.Text != "" && TPTime.Text != null)
				TBResult.Text = $"Напоминание сработает {DPDate.Text} в {Convert.ToDateTime(TPTime.SelectedTime).ToLongTimeString()}";
			else
				TBResult.Text = $"Напоминание нельзя создать без даты и времени";
		}

		private void TPTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
		{
			RefreshResult();
		}
	}
}