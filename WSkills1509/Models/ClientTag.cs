using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSkills1509.Models
{
	public class ClientTag
	{
		public int Id { get; set; }

		public virtual Client Client { get; set; }

		public virtual Tag Tag { get; set; }
	}
}
