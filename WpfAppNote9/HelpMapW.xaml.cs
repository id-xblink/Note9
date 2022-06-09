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
using Microsoft.Maps.MapControl.WPF;
using MaterialDesignThemes.Wpf;

namespace WpfAppNote9
{
    public partial class HelpMapW : Window
    {
		Location location = new Location();

		PackIcon icon = new PackIcon
		{
			Kind = PackIconKind.MapMarker,
			Width = 45,
			Height = 45,
			Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#bd0000")),
		};

		Canvas canvas = new Canvas
		{
			Width = 45,
			Height = 45,
		};

		bool first = false;

		public HelpMapW()
        {
            InitializeComponent();
        }

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			canvas.Children.Add(icon);
			MapLayer.SetPositionOrigin(canvas, PositionOrigin.BottomCenter);

			if (NoteData.Latitude != "")
			{
				MMap.Children.Add(canvas);
				location = new Location(Convert.ToDouble(NoteData.Latitude), Convert.ToDouble(NoteData.Longitude));
				MapLayer.SetPosition(canvas, location);


				MMap.Center = location;
				MMap.ZoomLevel = 14;
			}
			else
			{
				first = true;
			}
		}

		private void BBack_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void BCancel_Click(object sender, RoutedEventArgs e)
		{
			NoteData.Latitude = "";
			NoteData.Longitude = "";
			BBack_Click(sender, e);
		}

		private void BSave_Click(object sender, RoutedEventArgs e)
		{
			if (!first)
			{
				NoteData.Latitude = location.Latitude.ToString();
				NoteData.Longitude = location.Longitude.ToString();
				BBack_Click(sender, e);
			}
			else
				MessageBox.Show("Необходима метка, чтобы использовать карту", "Карта", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
		}

		private void MMap_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
		{
			if (first)
			{
				MMap.Children.Add(canvas);
				first = false;
			}

			Point mousePoint = e.GetPosition(MMap);
			location = MMap.ViewportPointToLocation(mousePoint);
			MapLayer.SetPosition(canvas, location);
		}
	}
}