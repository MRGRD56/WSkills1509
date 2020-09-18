using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WSkills1509.Pages
{
	/// <summary>
	/// Логика взаимодействия для ClientsPage.xaml
	/// </summary>
	public partial class ClientsPage : Page
	{
		private MainWindow MW { get; }
		public ViewModel.AppViewModel ViewModel { get; } = new ViewModel.AppViewModel();

		public ClientsPage(MainWindow mw)
		{
			InitializeComponent();
			MW = mw;
			DataContext = ViewModel;

			MW.Width = ClientsDG.Columns.Sum(x => x.Width.DesiredValue) + 50;
			MW.Height = 700;
			MW.WindowStartupLocation = WindowStartupLocation.CenterScreen;

			UpdateCC();
		}

		private void ShowLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			var senderLabel = (Label)sender;
			var senderContent = senderLabel.Content.ToString();
			var ciop = senderContent == "ВСЕ" ? Int32.MaxValue : Convert.ToInt32(senderContent);
			ViewModel.ClientsInOnePage = ciop;
			ViewModel.UpdateVisibleClients();
			new List<Label>
			{
				Show10Label,
				Show50Label,
				Show200Label,
				ShowAllLabel
			}.ForEach(x => x.FontWeight = FontWeight.FromOpenTypeWeight(400));
			senderLabel.FontWeight = FontWeight.FromOpenTypeWeight(900);
			UpdateCC();
		}

		private void PrevPage_Click(object sender, RoutedEventArgs e)
		{
			if (ViewModel.ClientsPageNumber > 1)
			{
				ViewModel.ClientsPageNumber--;
				ViewModel.UpdateVisibleClients();
				UpdateCC();
			}
		}

		private void NextPage_Click(object sender, RoutedEventArgs e)
		{
			ViewModel.ClientsPageNumber++;
			ViewModel.UpdateVisibleClients();
			UpdateCC();
		}

		public void UpdateCC()
		{
			var visible = ViewModel.ClientVMs.Count;
			var all = ViewModel.AllClientVMs.Count;
			ClientsCountLabel.Content = $"{visible}/{all}";
		}

		private void FiltrationButton_Click(object sender, RoutedEventArgs e)
		{
			new Windows.ClientsFiltrationWindow(this).Show();
		}

		private void SortByLastname_Click(object sender, RoutedEventArgs e)
		{
			ViewModel.ClientVMs = new ObservableCollection<ViewModel.ClientVM>(ViewModel.ClientVMs.OrderBy(x => x.LastName));
		}

		private void SortByLastVisitDate_Click(object sender, RoutedEventArgs e)
		{
			ViewModel.ClientVMs = new ObservableCollection<ViewModel.ClientVM>(ViewModel.ClientVMs.OrderByDescending(x => x.LastVisitDate));
		}

		private void SortByVisitsCount_Click(object sender, RoutedEventArgs e)
		{
			ViewModel.ClientVMs = new ObservableCollection<ViewModel.ClientVM>(ViewModel.ClientVMs.OrderByDescending(x => x.VisitsCount));
		}

		private void BirthdaySoon_Click(object sender, RoutedEventArgs e)
		{
			ViewModel.ClientVMs = new ObservableCollection<ViewModel.ClientVM>(ViewModel.ClientVMs.Where(x => x.BirthDate.Value.Month == DateTime.Now.Month));
		}
	}
}
