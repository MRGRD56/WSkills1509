using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSkills1509.ViewModel
{
	public class AppViewModel
	{
		public ObservableCollection<ClientVM> ClientVMs { get; set; }

		public AppViewModel()
		{
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
			ClientVMs = new ObservableCollection<ClientVM>();
			for (int i = 0; i < App.DbHelper.Clients.Count(); i++)
			{
				var clientvm = new ClientVM();
				var origClient = App.DbHelper.Clients.ToList()[i];
				clientvm.AdditionDate = origClient.AdditionDate;
				clientvm.BirthDate = origClient.BirthDate;
				clientvm.Email = origClient.Email;
				clientvm.FirstName = origClient.FirstName;
				clientvm.LastName = origClient.LastName;
				clientvm.Patronymic = origClient.Patronymic;
				clientvm.VisitsCount = origClient.VisitsCount;
				clientvm.PhoneNumber = origClient.PhoneNumber;
				clientvm.Gender = origClient.Gender;
				clientvm.LastVisitDate = origClient.LastVisitDate;
				clientvm.TagsString = String.Join(", ", App.DbHelper.ClientTags
					.Where(y => y.Client.Id == origClient.Id)
					.Select(y => y.Tag.TagName).ToList());
				ClientVMs.Add(clientvm);
			}
		}
	}
}
