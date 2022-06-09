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
using MaterialDesignThemes.Wpf;

namespace WpfAppNote9
{
    public partial class ChangeFieldW : Window
    {
		public string type = "SNL";

        public ChangeFieldW()
        {
            InitializeComponent();
        }

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			switch (type)
			{
				case "SNL":
					{
						TBlockHint.Text = "Что редактировать?";
						SPSNL.Visibility = Visibility.Visible;
						BChange.IsEnabled = false;
						break;
					}
				case "DateBirth":
					{
						TBlockHint.Text = "Выберите новую дату рождения:";
						DPBirth.Visibility = Visibility.Visible;
						break;
					}
				case "Login":
					{
						TBlockHint.Text = "Введите новый логин:";
						TBText.Visibility = Visibility.Visible;
						break;
					}
				case "Pass":
					{
						TBlockHint.Text = "Введите новый пароль:";
						PBPass.Visibility = Visibility.Visible;
						break;
					}
			}
		}

		private void BChange_Click(object sender, RoutedEventArgs e)
		{
			ProfileW design = Tag as ProfileW;

			switch (type)
			{
				case "SNL":
					{
						if ((bool)RBSurname.IsChecked)
						{
							design.TBSurname.Text = TBText.Text;
						}

						if ((bool)RBName.IsChecked)
						{
							design.TBName.Text = TBText.Text;
						}

						if ((bool)RBLastname.IsChecked)
						{
							design.TBLastname.Text = TBText.Text;
						}
						break;
					}
				case "DateBirth":
					{
						design.TBDateBirthValue.Text = DPBirth.Text;
						break;
					}
				case "Login":
					{
						design.TBLoginValue.Text = TBText.Text;
						break;
					}
				case "Pass":
					{
						string stars = "";
						for (int i = 0; i < PBPass.Password.Length; i++)
							stars += "*";

						if (design.PIIcon.Kind == PackIconKind.EyeOff)
						{
							design.TBPassValue.Text = stars;
							design.BViewPass.Tag = PBPass.Password;
						}
						else
						{
							design.TBPassValue.Text = PBPass.Password;
							design.BViewPass.Tag = stars;
						}
						break;
					}
			}
			Exit_Click(sender, e);
		}

		private void RBSNL_Click(object sender, RoutedEventArgs e)
		{
			TBlockHint.Text = "Что редактировать?";
			SPSNL.Visibility = Visibility.Collapsed;
			TBText.Visibility = Visibility.Visible;

			RadioButton rb = sender as RadioButton;
			if (rb.Content.ToString() == "Фамилию")
				HintAssist.SetHint(TBText, "Фамилия");
			else
				HintAssist.SetHint(TBText, rb.Content);
			BChange.IsEnabled = true;
		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void Field_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (e.Text == "'" || e.Text == "\"" || e.Text == "\\")
				e.Handled = true;
		}
	}
}