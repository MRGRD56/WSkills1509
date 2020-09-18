using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WSkills1509.Models;

namespace WSkills1509.ViewModel
{
	public class AppViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<ClientVM> allClientVMs; //All the clients
		public ObservableCollection<ClientVM> AllClientVMs
		{
			get => allClientVMs;
			set
			{
				allClientVMs = value;
				OnPropertyChanged("AllClientVMs");
			}
		}

		private ObservableCollection<ClientVM> filteredClientVMs;
		public ObservableCollection<ClientVM> FilteredClientVMs
		{
			get => filteredClientVMs;
			set
			{
				filteredClientVMs = value;
				OnPropertyChanged("FilteredClientVMs");
			}
		}

		private ObservableCollection<ClientVM> clientVMs; //Visible clients
		public ObservableCollection<ClientVM> ClientVMs
		{
			get => clientVMs;
			set 
			{
				clientVMs = value;
				OnPropertyChanged("ClientVMs");
			}
		}

		private int clientsPageNumber;
		public int ClientsPageNumber
		{
			get => clientsPageNumber;
			set
			{
				clientsPageNumber = value;
				OnPropertyChanged("ClientsPageNumber");
			}
		}
		public int clientsInOnePage;
		public int ClientsInOnePage
		{
			get => clientsInOnePage;
			set
			{
				clientsInOnePage = value;
				OnPropertyChanged("ClientsInOnePage");
			}
		}

		public AppViewModel()
		{
			ClientsPageNumber = 1;
			ClientsInOnePage = 50;

			//ClientVMs = new ObservableCollection<ClientVM>(App.DbHelper.Clients.Select(x => new ClientVM
			//{
			//	AdditionDate = x.AdditionDate,
			//	BirthDate = x.BirthDate,
			//	Email = x.Email,
			//	FirstName = x.FirstName,
			//	Gender = x.Gender,
			//	LastName = x.LastName,
			//	LastVisitDate = x.LastVisitDate,
			//	Patronymic = x.Patronymic,
			//	PhoneNumber = x.PhoneNumber,
			//	VisitsCount = x.VisitsCount,
			//	TagsString = String.Join(", ", App.DbHelper.ClientTags
			//		.Where(y => y.Client.Id == x.Id)
			//		.Select(y => y.Tag.TagName).ToList())
			//}));
			AllClientVMs = new ObservableCollection<ClientVM>();
			for (int i = 0; i < App.DbHelper.Clients.Count(); i++)
			{
				var clientvm = new ClientVM();
				var origClient = App.DbHelper.Clients.ToList()[i];
				clientvm.AdditionDate = origClient.AdditionDate;
				clientvm.BirthDate = origClient.BirthDate;
				clientvm.Email = origClient.Email == null ? "" : origClient.Email;
				clientvm.FirstName = origClient.FirstName;
				clientvm.LastName = origClient.LastName;
				clientvm.Patronymic = origClient.Patronymic == null ? "" : origClient.Patronymic;
				clientvm.VisitsCount = origClient.VisitsCount;
				clientvm.PhoneNumber = origClient.PhoneNumber == null ? "" : origClient.PhoneNumber;
				clientvm.Gender = origClient.Gender;
				clientvm.LastVisitDate = origClient.LastVisitDate;
				clientvm.TagsString = String.Join(", ", App.DbHelper.ClientTags
					.Where(y => y.Client.Id == origClient.Id)
					.Select(y => y.Tag.TagName).ToList());
				AllClientVMs.Add(clientvm);
			}
			FilteredClientVMs = AllClientVMs;
			UpdateVisibleClients();
		}

		public void UpdateVisibleClients()
		{
			ClientVMs = new ObservableCollection<ClientVM>(FilteredClientVMs
				.Skip((ClientsPageNumber - 1) * ClientsInOnePage)
				.Take(ClientsInOnePage));
		}

		public void FilterClients(string fname, string lname, string pat, string gender, string email, string phone)
		{
			FilteredClientVMs = new ObservableCollection<ClientVM>(AllClientVMs.Where(x =>
				x.FirstName.ToLower().Contains(fname) &&
				x.LastName.ToLower().Contains(lname) &&
				x.Patronymic.ToLower().Contains(pat) &&
				((gender == "") ? true : x.Gender == gender) &&
				x.Email.ToLower().Contains(email) &&
				x.PhoneNumber.Contains(phone)
			));
		}
		
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
