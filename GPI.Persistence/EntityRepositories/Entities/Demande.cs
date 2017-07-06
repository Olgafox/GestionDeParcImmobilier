using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPI.Persistence.EntityRepositories
{
	public partial class Demande
	{
		public override string ToString()
		{
			if(Client.Nom !=null)
				return string.Format("{0}", Client.Nom);
			return "";
		}
	}
}
