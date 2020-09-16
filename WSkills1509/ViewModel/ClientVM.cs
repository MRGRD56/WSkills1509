using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSkills1509.ViewModel
{
	public class ClientVM
	{
		public string Gender { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Patronymic { get; set; }
		public DateTime? BirthDate { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public DateTime? AdditionDate { get; set; }
		public DateTime? LastVisitDate { get; set; }
		public int? VisitsCount { get; set; }
		public string TagsString { get; set; }
	}
}
