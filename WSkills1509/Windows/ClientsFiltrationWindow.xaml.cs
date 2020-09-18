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
using WSkills1509.Pages;

namespace WSkills1509.Windows
{
	/// <summary>
	/// Логика взаимодействия для ClientsFiltrationWindow.xaml
	/// </summary>
	public partial class ClientsFiltrationWindow : Window
	{
		private ClientsPage CP { get; }

		public ClientsFiltrationWindow(ClientsPage cp)
		{
			InitializeComponent();
			CP = cp;
			CP.FiltrationButton.IsEnabled = false;
		}

		private void ResetButton_Click(object sender, RoutedEventArgs e)
		{
			LastNameTB.Text = "";
			FirstNameTB.Text = "";
			PatronymicTB.Text = "";
			MGenderRB.IsChecked = false;
			FGenderRB.IsChecked = false;
			EmailTB.Text = "";
			PhoneNumberTB.Text = "";
			ChangeFilter();
		}

		private void Window_Closed(object sender, EventArgs e)
		{
			CP.FiltrationButton.IsEnabled = true;
		}

		private void FilterChanged(object sender, TextChangedEventArgs e)
		{
			ChangeFilter();
		}

		private void RB_FilterChanged(object sender, RoutedEventArgs e)
		{
			ChangeFilter();
		}

		private void ChangeFilter()
		{
			var fname = FirstNameTB.Text.Trim().ToLower();
			var lname = LastNameTB.Text.Trim().ToLower();
			var pat = PatronymicTB.Text.Trim().ToLower();
			var gender = MGenderRB.IsChecked == true ? MGenderRB.Content.ToString() :
				FGenderRB.IsChecked == true ? FGenderRB.Content.ToString() : "";
			var email = EmailTB.Text.Trim().ToLower();
			var phone = PhoneNumberTB.Text.Trim();
			CP.ViewModel.FilterClients(fname, lname, pat, gender, email, phone);
			CP.ViewModel.UpdateVisibleClients();
			CP.UpdateCC();
		}
	}
}
